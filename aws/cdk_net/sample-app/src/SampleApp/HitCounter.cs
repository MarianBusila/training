﻿
using System.Collections.Generic;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.Lambda;
using Constructs;

namespace SampleApp
{
    public class HitCounterProps
    {
        // The function for which we want to count url hits
        public IFunction Downstream { get; set; }
    }
    public class HitCounter: Construct
    {
        public Function Handler { get; }
        public readonly Table MyTable;

        public HitCounter(Construct scope, string id, HitCounterProps props) : base(scope, id)
        {
            MyTable = new Table(this, "Hits", new TableProps
            {
                PartitionKey = new Attribute
                {
                    Name = "path",
                    Type = AttributeType.STRING
                }
            });

            Handler = new Function(this, "HitCounterHandler", new FunctionProps
            {
                Runtime = Runtime.NODEJS_14_X,
                Handler = "hitcounter.handler",
                Code = Code.FromAsset("lambda"),
                Environment = new Dictionary<string, string>
                {
                    ["DOWNSTREAM_FUNCTION_NAME"] = props.Downstream.FunctionName,
                    ["HITS_TABLE_NAME"] = MyTable.TableName
                }
            });

            // Grant the lambda role read/write permissions to our table
            MyTable.GrantReadWriteData(Handler);

            // Grant the lambda role invoke permissions to the downstream function
            props.Downstream.GrantInvoke(Handler);

        }

    }
}

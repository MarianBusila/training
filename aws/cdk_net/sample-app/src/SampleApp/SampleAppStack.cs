using Amazon.CDK;
using Amazon.CDK.AWS.SNS;
using Amazon.CDK.AWS.SNS.Subscriptions;
using Amazon.CDK.AWS.SQS;
using Constructs;

namespace SampleApp
{
    public class SampleAppStack : Stack
    {
        internal SampleAppStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {

        }
    }
}

using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.Lambda.Nodejs;
using Amazon.CDK.AWS.StepFunctions;
using Amazon.CDK.AWS.StepFunctions.Tasks;
using Constructs;

namespace RandomNumberStepfunction
{
    public class RandomNumberStepfunctionStack : Stack
    {
        internal RandomNumberStepfunctionStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // Lambda to generate a random number
            var generateRandomNumber = new NodejsFunction(this, "GenerateRandomNumber", new NodejsFunctionProps
            {
                Runtime = Runtime.NODEJS_14_X,
                Entry = "lambda/generateRandomNumber.js",
                Handler = "handler",
                DepsLockFilePath = "lambda/package-lock.json",
                Timeout = Duration.Seconds(3)
            });

            // Lambda invocation for generating a random number
            var generateRandomNumberInvocation = new LambdaInvoke(this, "GenerateRandomNumberInvocation", new LambdaInvokeProps {
            LambdaFunction    = generateRandomNumber,
            OutputPath = "$.Payload"
            });

            // Lambda function called if the generated number is greater than the expected number
            var greaterThan = new NodejsFunction(this, "GreaterThan", new NodejsFunctionProps
            {
                Runtime = Runtime.NODEJS_14_X,
                Entry = "lambda/greater.js",
                Handler = "handler",
                DepsLockFilePath = "lambda/package-lock.json",
                Timeout = Duration.Seconds(3)
            });

            // Lambda invocation if the generated number is greater than the expected number
            var greaterThanInvocation = new LambdaInvoke(this, "GreaterThanInvocation", new LambdaInvokeProps
            {
                LambdaFunction = greaterThan,
                InputPath = "$",
                OutputPath = "$"
            });

            // Lambda function called if the generated number is less than or equal to the expected number
            var lessThanOrEqual = new NodejsFunction(this, "LessThanOrEqual", new NodejsFunctionProps
            {
                Runtime = Runtime.NODEJS_14_X,
                Entry = "lambda/lessOrEqual.js",
                Handler = "handler",
                DepsLockFilePath = "lambda/package-lock.json",
                Timeout = Duration.Seconds(3)
            });

            // Lambda invocation if the generated number is less than or equal to the expected number
            var lessThanOrEqualInvocation = new LambdaInvoke(this, "LessThanOrEqualInvocation", new LambdaInvokeProps
            {
                LambdaFunction = lessThanOrEqual,
                InputPath = "$",
                OutputPath = "$"
            });

            // Condition to wait 1 second
            var wait1Sec = new Wait(this, "Wait1Second", new WaitProps{Time = WaitTime.Duration(Duration.Seconds(1))});

            // choice condition for workflow
            var numberChoice = new Choice(this, "NumberChoice")
                .When(Condition.NumberGreaterThanJsonPath("$.generatedRandomNumber", "$.numberToCheck"), greaterThanInvocation)
                .When(Condition.NumberLessThanEqualsJsonPath("$.generatedRandomNumber", "$.numberToCheck"), lessThanOrEqualInvocation)
                .Otherwise(lessThanOrEqualInvocation);

            // create the workflow definition
            var definition = generateRandomNumberInvocation.Next(wait1Sec).Next(numberChoice);

            // create the state machine
            var stateMachine = new StateMachine(this, "StateMachine", new StateMachineProps{
            Definition    = definition,
            StateMachineName = "randomNumberStateMachine",
            Timeout = Duration.Minutes(5)
            });

        }
    }
}

using Amazon.CDK;

namespace RandomNumberStepfunction
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new RandomNumberStepfunctionStack(app, "RandomNumberStepfunctionStack", new StackProps
            {
                Description = "This stack includes a test step function",
                Env = new Environment
                {
                    Account = "810275592917",
                    Region = "us-east-1"
                }
            });
            app.Synth();
        }
    }
}

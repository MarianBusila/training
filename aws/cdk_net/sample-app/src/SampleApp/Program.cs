using Amazon.CDK;

namespace SampleApp
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new SampleAppStack(app, "SampleAppStack");

            app.Synth();
        }
    }
}

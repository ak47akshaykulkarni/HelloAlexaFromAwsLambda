using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace helloAlexaFromAwsLambda
{
    public class Function
    {
        public SkillResponse FunctionHandler(SkillRequest skillRequest, ILambdaContext context)
        {
            if (skillRequest.GetRequestType() != typeof(IntentRequest))
                return new SkillResponse()
                {
                    Response = new ResponseBody
                    {
                        ShouldEndSession = true,
                        OutputSpeech = new PlainTextOutputSpeech
                        {
                            Text = "I did not understand what that was, but still, I'll say, Typical Hello World"
                        }
                    },
                    Version = "1.0"
                };
            return new SkillResponse()
            {
                Response = new ResponseBody()
                {
                    OutputSpeech = new PlainTextOutputSpeech() { Text = "Good! There you go... Hello World from AWS Lambda Function" },
                    ShouldEndSession = true
                },
                Version = "1.0"
            };
        }
    }
}

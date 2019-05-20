using Alexa.NET.Request;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RateMeSoftly
{
    public class Function : Core
    {
        public async Task<SkillResponse> FunctionHandler(APLSkillRequest request, ILambdaContext context)
        {
            Core core = new Core();
            await core.Init(request, context);
            await InvokeHandler(core);

            await Database.SaveState();
            SkillResponse response = Response.GetResponse();
            Logger.Write($"Response detail: {JsonConvert.SerializeObject(response)}");
            Logger.Write($"Latest user state detail: {JsonConvert.SerializeObject(State)}");
            Logger.Write($"**************** [{SkillMetadata.Name}] processing ended ****************");

            return response;
        }

        private async Task InvokeHandler(Core core)
        {
            object handlerInstance = core.GetHandlerInstance();

            if (handlerInstance != null)
            {
                MethodBase handler = core.GetRequestHandler(handlerInstance.GetType());
                await (Task)handler.Invoke(handlerInstance, null);
            }
        }
    }
}

using Alexa.NET.APL;
using Alexa.NET.Request;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RateMeSoftly
{
    public class Core
    {
        public static Echo Echo;
        public static Response Response;

        protected static Input Input;
        protected static State State;
        protected static Logger Logger;
        protected static Database Database;

        protected static RequestManager RequestManager;


        public async Task Init(APLSkillRequest request, ILambdaContext context)
        {
            AddRequestConverters();

            Logger = new Logger(context.Logger);
            Logger.Write($"**************** [{SkillMetadata.Name}] started ****************");
            Logger.Write($"System locale: [{request.Request.Locale}]");
            Logger.Write($"Request detail: {JsonConvert.SerializeObject(request)}");

            string userId = GetUserId(request);
            SetComponents(request, userId);
            await SetState();
        }

        private void SetComponents(APLSkillRequest request, string userId)
        {
            Input = new Input(request);
            Echo = new Echo();
            Response = new Response();
            Database = new Database(userId);
            RequestManager = new RequestManager();
        }

        private async Task SetState()
        {
            Database.SetContext();
            State = await Database.GetState();
            Logger.Write($"Retrieved user state detail: {JsonConvert.SerializeObject(State)}");
        }

        private string GetUserId(APLSkillRequest request)
        {
            Session session = request.Session;
            APLContext skillContext = request.Context;

            return session != null ? session.User.UserId : skillContext.System.User.UserId;
        }

        public object GetHandlerInstance()
        {
            string requestName = Input.GetRequestName();
            Logger.Write($"Request type: [{requestName}]");

            List<RequestType> requestTypeList = RequestManager.GetRequestTypes();

            foreach (RequestType requestType in requestTypeList)
            {
                if (requestName.Equals(requestType.name))
                {
                    State.NumPrompted = 0;
                    return Activator.CreateInstance(requestType.type);
                }
            }

            return Activator.CreateInstance(typeof(FallbackIntentHandler));
        }

        public MethodBase GetRequestHandler(Type requestType)
        {
            MethodBase handler = requestType.GetMethod(BuiltInRequest.RequestHandler,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            return handler;
        }

        private void AddRequestConverters()
        {
            new UserEventRequestHandler().AddToRequestConverter();
            //new SystemExceptionEncounteredRequestTypeConverter().AddToRequestConverter();
        }
    }
}

using System.Collections.Generic;

namespace RateMeSoftly
{
    public class RequestManager
    {
        private List<RequestType> requestTypeList;


        public RequestManager()
        {
            SetRequestTypes();
        }

        public List<RequestType> GetRequestTypes()
        {
            return requestTypeList;
        }

        private void SetRequestTypes()
        {
            requestTypeList = new List<RequestType>
            {
                new RequestType
                {
                    name = BuiltInRequest.LaunchRequest,
                    type = typeof(LaunchRequestHandler)
                },
                new RequestType
                {
                    name = CustomRequest.RateIntent,
                    type = typeof(RateIntentHandler)
                },
                new RequestType
                {
                    name = CustomRequest.MenuIntent,
                    type =typeof(MenuIntentHandler)
                },
                new RequestType
                {
                    name = BuiltInRequest.AplUserEventRequest,
                    type = typeof(AplUserEventRequestHandler)
                },
                new RequestType
                {
                    name = BuiltInRequest.SessionEndedRequest,
                    type = typeof(SessionEndedRequestHandler)
                },
                new RequestType
                {
                    name = BuiltInRequest.StopIntent,
                    type = typeof(StopIntentHandler)
                }
            };
        }
    }
}

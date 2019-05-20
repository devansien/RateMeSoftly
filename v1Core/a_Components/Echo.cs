using Alexa.NET.APL;
using Alexa.NET.Request;
using System.Collections.Generic;

namespace RateMeSoftly
{
    public class Echo : Core
    {
        public Echo()
        {
            DisplayManager.DeviceHeight = IsRound ? 480f : 1080f;
        }

        public bool IsRound
        {
            get
            {
                APLSkillRequest request = Input.GetRequest();
                try { return request.Context.Viewport.Shape == ViewportShape.Round; }
                catch { return false; }
            }
        }

        public bool HasScreen
        {
            get
            {
                APLSkillRequest request = Input.GetRequest();
                try { return request.Context.System.Device.IsInterfaceSupported(SessionKey.AlexaPresentationApl); }
                catch { return false; }
            }
        }

        public AlexaViewport Viewport
        {
            get
            {
                APLSkillRequest request = Input.GetRequest();

                if (request.Context.Viewport == null)
                {
                    request.Context.Viewport = SessionManager.Get<AlexaViewport>(SessionKey.Viewport);
                    return request.Context.Viewport;
                }
                else
                {
                    if (request.Session == null)
                        request.Session = new Session();

                    if (request.Session.Attributes == null)
                        request.Session.Attributes = new Dictionary<string, object>();

                    if (!request.Session.Attributes.ContainsKey(SessionKey.Viewport))
                        SessionManager.Set(SessionKey.Viewport, request.Context.Viewport);

                    return request.Context.Viewport;
                }
            }
        }
    }
}

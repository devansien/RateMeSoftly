using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Alexa.NET.Response.Directive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RateMeSoftly
{
    public class Response : Core
    {
        private readonly SkillResponse response;


        public Response()
        {
            response = ResponseBuilder.Empty();
        }

        public SkillResponse GetResponse()
        {
            return response;
        }

        public void SetSession()
        {
            Session session = Input.GetRequest().Session;
            if (session != null && session.Attributes != null)
                response.SessionAttributes = session.Attributes;
        }

        public void SetDirective(bool clear, IDirective directive)
        {
            if (clear)
                ClearDirective();

            response.Response.Directives.Add(directive);
        }

        public void SetDirectives(params IDirective[] directives)
        {
            foreach (IDirective directive in directives)
                response.Response.Directives.Add(directive);
        }

        public void ReplaceDirective(Type directiveType, IDirective directive)
        {
            ClearDirective(directiveType);
            response.Response.Directives.Add(directive);
        }

        public void SetSpeech(bool endSession, bool isSsml, string speech, params string[] reprompts)
        {
            string reprompt = string.Empty;
            if (reprompts != null && reprompts.Any())
                reprompt = GetReprompt(reprompts);

            if (isSsml)
            {
                string ssmlSpeech = $"<speak>{speech}</speak>";
                response.Response.OutputSpeech = new SsmlOutputSpeech() { Ssml = ssmlSpeech };
            }
            else
                response.Response.OutputSpeech = new PlainTextOutputSpeech() { Text = speech };

            if (!string.IsNullOrEmpty(reprompt))
            {
                response.Response.Reprompt = new Reprompt();

                if (isSsml)
                {
                    string ssmlSpeech = $"<speak>{reprompt}</speak>";
                    response.Response.Reprompt.OutputSpeech = new SsmlOutputSpeech { Ssml = ssmlSpeech };
                }
                else
                    response.Response.Reprompt.OutputSpeech = new PlainTextOutputSpeech { Text = reprompt };
            }

            //response.Response.ShouldEndSession = endSession;
            response.Response.ShouldEndSession = null;
        }

        private string GetReprompt(string[] reprompts)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string reprompt in reprompts)
                builder.Append(reprompt);

            return builder.ToString();
        }

        private void ClearDirective()
        {
            if (response.Response.Directives == null)
                return;

            List<IDirective> directives = new List<IDirective>();
            foreach (var directive in response.Response.Directives)
            {
                if (directive.GetType() != typeof(VideoAppDirective) &&
                    directive.GetType() != typeof(RenderDocumentDirective) &&
                    directive.GetType() != typeof(AudioPlayerPlayDirective) &&
                    directive.GetType() != typeof(ExecuteCommandsDirective))

                    directives.Add(directive);
            }

            response.Response.Directives = directives;
        }

        private void ClearDirective(Type directiveType)
        {
            List<IDirective> directives = new List<IDirective>();
            foreach (var directive in response.Response.Directives)
            {
                if (directive.GetType() != directiveType)
                    directives.Add(directive);
            }

            response.Response.Directives = directives;
        }
    }
}

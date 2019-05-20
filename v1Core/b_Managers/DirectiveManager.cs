using Alexa.NET.APL.Layouts;
using Alexa.NET.Response;
using Alexa.NET.Response.APL;
using System.Collections.Generic;

namespace RateMeSoftly
{
    class DirectiveManager : Core
    {
        public static RenderDocumentDirective GetRenderDirective(string token, string hint, params APLComponent[] components)
        {
            APLDocument document = new APLDocument();
            AlexaFooter.ImportInto(document);

            document.MainTemplate = new Layout(new AlexaFooter(hint)).AsMain();
            document.MainTemplate.Items = new List<APLComponent>();
            for (int i = 0; i < components.Length; i++)
                document.MainTemplate.Items.Add(components[i]);

            RenderDocumentDirective renderDirective = new RenderDocumentDirective
            {
                Token = token,
                Document = document
            };

            return renderDirective;
        }
    }
}

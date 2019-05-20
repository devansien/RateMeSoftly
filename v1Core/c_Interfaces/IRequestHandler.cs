using System.Threading.Tasks;

namespace RateMeSoftly
{
    interface IRequestHandler
    {
        Task HandleRequest();
    }
}

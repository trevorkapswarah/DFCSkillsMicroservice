using System.Threading.Tasks;

namespace DFC.Microservices.Skills.Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
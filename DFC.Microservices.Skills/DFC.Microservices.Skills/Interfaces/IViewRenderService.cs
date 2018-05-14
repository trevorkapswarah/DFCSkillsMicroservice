using System.Threading.Tasks;

namespace DFC.Microservices.Skills.Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
using TorgObject.ApplicationServices.GetPechatProductListUseCase;
using System.Net;
using Newtonsoft.Json;
using TorgObject.ApplicationServices.Ports;

namespace TorgObject.InfrastructureServices.Presenters
{
    public class PechatProductListPresenter : IOutputPort<GetPechatProductListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PechatProductListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetPechatProductListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.PechatProducts) : JsonConvert.SerializeObject(response.Message);
        }
    }
}

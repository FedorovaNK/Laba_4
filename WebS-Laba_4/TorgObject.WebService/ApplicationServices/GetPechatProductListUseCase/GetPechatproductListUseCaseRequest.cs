using TorgObject.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorgObject.ApplicationServices.GetPechatProductListUseCase
{
    public class GetPechatProductListUseCaseRequest : IUseCaseRequest<GetPechatProductListUseCaseResponse>
    {
        public string IsDistrict { get; private set; }
        public long? PechatProductId { get; private set; }

        private GetPechatProductListUseCaseRequest()
        { }

        public static GetPechatProductListUseCaseRequest CreateAllPechatProductsRequest()
        {
            return new GetPechatProductListUseCaseRequest();
        }

        public static GetPechatProductListUseCaseRequest CreatePechatProductRequest(long pechatproductId)
        {
            return new GetPechatProductListUseCaseRequest() { PechatProductId = pechatproductId };
        }
        public static GetPechatProductListUseCaseRequest CreateIsDistrictPechatProductsRequest(string isdistrict)
        {
            return new GetPechatProductListUseCaseRequest() { IsDistrict = isdistrict };
        }
    }
}

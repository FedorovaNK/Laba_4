using TorgObject.DomainObjects;
using TorgObject.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorgObject.ApplicationServices.GetPechatProductListUseCase
{
    public class GetPechatProductListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<PechatProduct> PechatProducts { get; }

        public GetPechatProductListUseCaseResponse(IEnumerable<PechatProduct> pechatproducts) => PechatProducts = pechatproducts;
    }
}

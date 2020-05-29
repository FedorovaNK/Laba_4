using System.Threading.Tasks;
using System.Collections.Generic;
using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using TorgObject.ApplicationServices.Ports;

namespace TorgObject.ApplicationServices.GetPechatProductListUseCase
{
    public class GetPechatProductListUseCase : IGetPechatProductListUseCase
    {
        private readonly IReadOnlyPechatProductRepository _readOnlyPechatProductRepository;

        public GetPechatProductListUseCase(IReadOnlyPechatProductRepository readOnlyPechatProductRepository) 
            => _readOnlyPechatProductRepository = readOnlyPechatProductRepository;

        public async Task<bool> Handle(GetPechatProductListUseCaseRequest request, IOutputPort<GetPechatProductListUseCaseResponse> outputPort)
        {
            IEnumerable<PechatProduct> PechatProducts = null;
            if (request.PechatProductId != null)
            {
                var pechatproduct = await _readOnlyPechatProductRepository.GetPechatProduct(request.PechatProductId.Value);
                PechatProducts = (pechatproduct != null) ? new List<PechatProduct>() { pechatproduct } : new List<PechatProduct>();
                
            }
            else if (request.IsDistrict != null)
            {
                PechatProducts = await _readOnlyPechatProductRepository.QueryPechatProducts(new IsDistrictCriteria(request.IsDistrict));
            }
            else
            {
                PechatProducts = await _readOnlyPechatProductRepository.GetAllPechatProducts();
            }
            outputPort.Handle(new GetPechatProductListUseCaseResponse(PechatProducts));
            return true;
        }
    }
}

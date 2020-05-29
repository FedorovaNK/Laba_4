using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TorgObject.DomainObjects.Ports
{
    public interface IReadOnlyPechatProductRepository
    {
        Task<PechatProduct> GetPechatProduct(long id);

        Task<IEnumerable<PechatProduct>> GetAllPechatProducts();

        Task<IEnumerable<PechatProduct>> QueryPechatProducts(ICriteria<PechatProduct> criteria);

    }

    public interface IPechatProductRepository
    {
        Task AddPechatProduct(PechatProduct pechatproduct);

        Task RemovePechatProduct(PechatProduct pechatproduct);

        Task UpdatePechatProduct(PechatProduct pechatproduct);
    }
}

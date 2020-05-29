using TorgObject.DomainObjects;
using TorgObject.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TorgObject.ApplicationServices.Repositories
{
    public class InMemoryPechatProductRepository : IReadOnlyPechatProductRepository,
                                           IPechatProductRepository 
    {
        private readonly List<PechatProduct> _pechatproducts = new List<PechatProduct>();

        public InMemoryPechatProductRepository(IEnumerable<PechatProduct> pechatproducts = null)
        {
            if (pechatproducts != null)
            {
                _pechatproducts.AddRange(pechatproducts);
            }
        }

        public Task AddPechatProduct(PechatProduct pechatproduct)
        {
            _pechatproducts.Add(pechatproduct);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<PechatProduct>> GetAllPechatProducts()
        {
            return Task.FromResult(_pechatproducts.AsEnumerable());
        }

        public Task<PechatProduct> GetPechatProduct(long id)
        {
            return Task.FromResult(_pechatproducts.Where(mp => mp.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<PechatProduct>> QueryPechatProducts(ICriteria<PechatProduct> criteria)
        {
            return Task.FromResult(_pechatproducts.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemovePechatProduct(PechatProduct pechatproduct)
        {
            _pechatproducts.Remove(pechatproduct);
            return Task.CompletedTask;
        }

        public Task UpdatePechatProduct(PechatProduct pechatproduct)
        {
            var foundPechatProduct = GetPechatProduct(pechatproduct.Id).Result;
            if (foundPechatProduct == null)
            {
                AddPechatProduct(pechatproduct);
            }
            else
            {
                if (foundPechatProduct != pechatproduct)
                {
                    _pechatproducts.Remove(foundPechatProduct);
                    _pechatproducts.Add(pechatproduct);
                }
            }
            return Task.CompletedTask;
        }
    }
}

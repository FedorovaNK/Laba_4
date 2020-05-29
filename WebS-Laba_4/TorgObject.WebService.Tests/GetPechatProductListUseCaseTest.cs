using TorgObject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using TorgObject.ApplicationServices.GetPechatProductListUseCase;
using System.Linq.Expressions;
using TorgObject.ApplicationServices.Ports;
using TorgObject.DomainObjects.Ports;
using TorgObject.ApplicationServices.Repositories;

namespace TorgObject.WebService.Core.Tests
{
    public class GetPechatProductListUseCaseTest
    {
        private InMemoryPechatProductRepository CreatePechatProducttRepository()
        {
            var repo = new InMemoryPechatProductRepository(new List<PechatProduct> {
                new PechatProduct { Id = 1, District = "СЗАО", Name = "НТО ул. Авиационная, вл.68", Area = "Щукино", Address = "город Москва, Авиационная улица, дом 68", Period = "с 1 января по 31 декабря",  Number = "НТО-09-02-002652", FacilityArea = "9", NameOfBusinessEntity = "Компания ФРЕГАТ"},
                new PechatProduct { Id = 2, District = "СВАО", Name = "НТО Абрамцевская ул., вл.1", Area = "Лианозово",Address = "город Москва, Абрамцевская улица, дом 1", Period = "с 1 января по 31 декабря",  Number = "НТО-09-02-000716", FacilityArea = "9", NameOfBusinessEntity = "Сейлс"},
            });
            return repo;
        }
        [Fact]
        public void TestGetAllPechatProducts()
        {
            var useCase = new GetPechatProductListUseCase(CreatePechatProducttRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetPechatProductListUseCaseRequest.CreateAllPechatProductsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.PechatProducts.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.PechatProducts.Select(ds => ds.Id));
        }

        [Fact]
        public void TestGetAllPechatProductsFromEmptyRepository()
        {
            var useCase = new GetPechatProductListUseCase(new InMemoryPechatProductRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetPechatProductListUseCaseRequest.CreateAllPechatProductsRequest(), outputPort).Result);
            Assert.Empty(outputPort.PechatProducts);
        }

        [Fact]
        public void TestGetPechatProduct()
        {
            var useCase = new GetPechatProductListUseCase(CreatePechatProducttRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetPechatProductListUseCaseRequest.CreatePechatProductRequest(2), outputPort).Result);
            Assert.Single(outputPort.PechatProducts, ds => 2 == ds.Id);
        }

        [Fact]
        public void TestTryGetNotExistingPechatProduct()
        {
            var useCase = new GetPechatProductListUseCase(CreatePechatProducttRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetPechatProductListUseCaseRequest.CreatePechatProductRequest(999), outputPort).Result);
            Assert.Empty(outputPort.PechatProducts);
        }
      
    }

    class OutputPort : IOutputPort<GetPechatProductListUseCaseResponse>
    {
        public IEnumerable<PechatProduct> PechatProducts { get; private set; }

        public void Handle(GetPechatProductListUseCaseResponse response)
        {
            PechatProducts = response.PechatProducts;
        }
    }
}

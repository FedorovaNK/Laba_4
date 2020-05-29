using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TorgObject.DomainObjects;
using TorgObject.ApplicationServices.GetPechatProductListUseCase;
using TorgObject.InfrastructureServices.Presenters;

namespace TorgObject.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PechatProductsController : ControllerBase
    {
        private readonly ILogger<PechatProductsController> _logger;
        private readonly IGetPechatProductListUseCase _getPechatProductListUseCase;

        public PechatProductsController(ILogger<PechatProductsController> logger,
                                IGetPechatProductListUseCase getPechatProductListUseCase)
        {
            _logger = logger;
            _getPechatProductListUseCase = getPechatProductListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPechatProducts()
        {
            var presenter = new PechatProductListPresenter();
            await _getPechatProductListUseCase.Handle(GetPechatProductListUseCaseRequest.CreateAllPechatProductsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{pechatproductId}")]
        public async Task<ActionResult> GetPechatProduct(long pechatproductId)
        {
            var presenter = new PechatProductListPresenter();
            await _getPechatProductListUseCase.Handle(GetPechatProductListUseCaseRequest.CreatePechatProductRequest(pechatproductId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("isdistrict/{isdistrict}")]
        public async Task<ActionResult> GetIsDistrictPechatProducts(string isdistrict)
        {
            var presenter = new PechatProductListPresenter();
            await _getPechatProductListUseCase.Handle(GetPechatProductListUseCaseRequest.CreateIsDistrictPechatProductsRequest(isdistrict), presenter);
            return presenter.ContentResult;
        }
    }
}

using CE.Api.ViewModels;
using CE.Contracts;
using CE.Domain.Entities;
using CE.Services.Features.Orders.Requests.Queries;
using CE.Services.Features.Products.Requests.Commands;
using CE.Services.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CE.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Readonly Fields

        private readonly IMediator _mediatR;
        private readonly ILoggerService _loggerService;

        #endregion

        #region Ctor

        public ProductController(IMediator mediatR, ILoggerService loggerService)
        {
            _mediatR = mediatR;
            _loggerService = loggerService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult>GetTopFiveProducts()
        {
            try
            {
                var results = await _mediatR.Send(new GetTopFiveProductsSoldRequest());

                if (results == null)
                    return NotFound("No orders were found");

                var response = Map(results);

                _loggerService.LoginIngo($"{response.Count} Products found");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTopFiveProducts")]
        public async Task<IActionResult> GetTopFiveOrders()
        {
            try
            {
                 var results = await _mediatR.Send(new GetTOpFiveOrdersWithIDRequest());

                if (results == null)
                    return NotFound("No orders were found");

                return Ok(Map(results, true));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult>UpdateProductQty(ProductToBeUpdatedWithId product)
        {
            try
            {
                var results = await _mediatR.Send(
                    new UpdateProductQtyCommand(
                        product.Id, product.GTIN, product.Description, product.Qty));

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private List<TopFiveProduct> Map(List<Line> prods)
        {
            var outgoingProds = new List<TopFiveProduct>();

            prods.ForEach(x =>
            {
                var outgoingProd = new TopFiveProduct();
                outgoingProd.Gtin = x.Gtin;
                outgoingProd.Name = x.Description;
                outgoingProd.TotalQty = x.Quantity;

                outgoingProds.Add(outgoingProd);
            });

            return outgoingProds;
        }

        private List<ProductToBeUpdated> Map(Root root, bool @override)
        {
            var outgoingOrders = new List<ProductToBeUpdated>();

            root.Content.ForEach(x =>
            {
                var outgoing = new ProductToBeUpdated();
                outgoing.Id = x.Id;
                outgoing.OrderDate = x.OrderDate.ToString("yyyy-MM-dd");
                x.Lines.ForEach(x =>
                {
                    outgoing.Lines.Add(new LineToBeUpdated { Description = x.Description, Gtin = x.Gtin, Qty = x.Quantity });
                });


                outgoingOrders.Add(outgoing);
            });

            return outgoingOrders;
        }

        #endregion
    }
}

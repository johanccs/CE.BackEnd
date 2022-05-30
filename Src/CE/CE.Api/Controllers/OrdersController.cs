using CE.Api.ViewModels;
using CE.Contracts;
using CE.Domain.Entities;
using CE.Services.Features.Orders.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CE.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Readonly Fields
      
        private readonly IMediator _mediatR;
        private readonly ILoggerService _loggerService;

        #endregion

        #region Ctor

        public OrdersController(IMediator mediatR, ILoggerService loggerService)
        {
           _mediatR = mediatR;
            _loggerService = loggerService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult>GetOrdersByInProgressStatus()
        {
            try
            {
               var results = await _mediatR.Send(new GetOrdersByInProgressStatusRequest());

                if (results == null)
                    return NotFound("No orders were found");

                return Ok(Map(results));
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private List<OrderInProgress> Map(Root root)
        {
            var outgoingOrders = new List<OrderInProgress>();

            root.Content.ForEach(x =>
            {
                var outgoingOrder = new OrderInProgress();
                outgoingOrder.Id = x.Id;
                outgoingOrder.OrderDate = x.OrderDate.ToString("yyyy-MM-dd");
                outgoingOrder.TotalQtyOrdered = x.Lines.Sum(x => x.Quantity);

                outgoingOrders.Add(outgoingOrder);
            });

            return outgoingOrders;
        }

        #endregion
    }
}

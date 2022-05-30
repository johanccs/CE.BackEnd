using CE.Api.ViewModels;
using CE.Domain.Dtos;
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

        #endregion

        #region Ctor

        public OrdersController(IMediator mediatR)
        {
           _mediatR = mediatR;
        }

        #endregion

        #region Methods

        [HttpGet]
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

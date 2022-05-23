using CE.Services.Features.Orders.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CE.Api.Controllers
{
    [Route("api/[controller]")]
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

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}

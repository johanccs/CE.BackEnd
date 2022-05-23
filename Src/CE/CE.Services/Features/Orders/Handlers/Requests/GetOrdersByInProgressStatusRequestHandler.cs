using CE.Contracts;
using CE.Domain.Dtos;
using CE.Services.Features.Orders.Requests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CE.Services.Features.Orders.Handlers.Requests
{
    public class GetOrdersByInProgressStatusRequestHandler : IRequestHandler<GetOrdersByInProgressStatusRequest, List<Order>>
    {
        #region Readonly Fields

        private readonly IOrderService _orderService;

        #endregion

        #region Ctor

        public GetOrdersByInProgressStatusRequestHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        public async Task<List<Order>> Handle(GetOrdersByInProgressStatusRequest request, CancellationToken cancellationToken)
        {
            var results = await _orderService.GetAllByInProgressStatus();

            return results;
        }
    }
}

using CE.Contracts;
using CE.Domain.Entities;
using CE.Services.Features.Orders.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CE.Services.Features.Orders.Handlers.Queries
{
    public class GetOrdersByInProgressStatusRequestHandler : IRequestHandler<GetOrdersByInProgressStatusRequest, Root>
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

        public async Task<Root> Handle(GetOrdersByInProgressStatusRequest request, CancellationToken cancellationToken)
        {
            var results = await _orderService.GetAllByInProgressStatus();

            return results;
        }
    }
}

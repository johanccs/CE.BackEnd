using CE.Contracts;
using CE.Domain.Dtos;
using CE.Services.Features.Orders.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CE.Services.Features.Orders.Handlers.Queries
{
    public class GetTOpFiveOrdersWithIDRequestHandler : IRequestHandler<GetTOpFiveOrdersWithIDRequest, Root>
    {
        #region Readonly Fields

        private readonly IOrderService _orderService;

        #endregion

        #region Ctor

        public GetTOpFiveOrdersWithIDRequestHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        #region Methods

        public async Task<Root> Handle(GetTOpFiveOrdersWithIDRequest request, CancellationToken cancellationToken)
        {
            var results = await _orderService.GetTopFiveProductsWithIDSold();

            return results;
        }

        #endregion
    }
}

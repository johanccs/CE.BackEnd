using CE.Contracts;
using CE.Domain.Entities;
using CE.Services.Features.Products.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CE.Services.Features.Products.Handlers.Queries
{
    public class GetTopFiveProductsSoldRequestHandler : IRequestHandler<GetTopFiveProductsSoldRequest, List<Line>>
    {
        #region Readonly Fields

        private readonly IOrderService _orderService;

        #endregion

        #region Ctor

        public GetTopFiveProductsSoldRequestHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        public async Task<List<Line>> Handle(GetTopFiveProductsSoldRequest request, CancellationToken cancellationToken)
        {
            var results = await _orderService.GetTopFiveProductsSold();

            return results;
        }
    }
}

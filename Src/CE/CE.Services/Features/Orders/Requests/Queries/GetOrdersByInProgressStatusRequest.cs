using CE.Domain.Entities;
using MediatR;

namespace CE.Services.Features.Orders.Requests.Queries
{
    public class GetOrdersByInProgressStatusRequest : IRequest<Root>
    {
    }
}

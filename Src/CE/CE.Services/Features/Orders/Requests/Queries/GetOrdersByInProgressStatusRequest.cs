using CE.Domain.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CE.Services.Features.Orders.Requests.Queries
{
    public class GetOrdersByInProgressStatusRequest : IRequest<Root>
    {
    }
}

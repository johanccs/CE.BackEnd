using CE.Domain.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CE.Services.Features.Orders.Requests
{
    public class GetOrdersByInProgressStatusRequest:IRequest<List<Order>>
    {
    }
}

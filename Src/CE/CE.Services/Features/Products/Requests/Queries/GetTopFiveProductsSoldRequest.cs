using CE.Domain.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CE.Services.Features.Products.Requests.Queries
{
    public class GetTopFiveProductsSoldRequest:IRequest<List<Line>>
    {

    }
}

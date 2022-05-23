using CE.Domain.Dtos;
using System.Collections.Generic;

namespace CE.Contracts
{
    public interface IOrderService
    {
        IReadOnlyList<Order> GetAllByInProgressStatus();
        IReadOnlyList<Line> GetTopFiveProductsSold();
    }
}
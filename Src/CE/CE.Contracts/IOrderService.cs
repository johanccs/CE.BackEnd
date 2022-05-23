using CE.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CE.Contracts
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllByInProgressStatus();
        Task<List<Line>> GetTopFiveProductsSold();
    }
}
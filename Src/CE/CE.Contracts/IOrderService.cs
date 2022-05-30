using CE.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CE.Contracts
{
    public interface IOrderService
    {
        Task<Root> GetAllByInProgressStatus();
        Task<List<Line>> GetTopFiveProductsSold();
        Task<Root> GetTopFiveProductsWithIDSold();
    }
}
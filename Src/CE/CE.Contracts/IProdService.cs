using CE.Domain.Entities.Products;
using System.Threading.Tasks;

namespace CE.Contracts
{
    public interface IProdService
    {
        Task<bool> UpdateProductQty(string name, int qty);
    }
}

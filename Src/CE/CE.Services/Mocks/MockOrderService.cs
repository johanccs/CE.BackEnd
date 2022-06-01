using CE.Contracts;
using CE.Domain.Entities;
using CE.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CE.Services.Mocks
{
    public class MockOrderService : IOrderService
    {
        #region Fields

        List<Content> _orders;
        Root root;

        #endregion

        #region Ctor

        public MockOrderService()
        {
            root = new Root();

            _orders = new List<Content>()
            {
                new Content(){Id = 10, Status = STATUSES.IN_PROGRESS,
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 1},
                     }
                },
                new Content(){Id = 2, Status = STATUSES.AWAITING_PAYMENT,
                      Lines = new List<Line>{
                        new Line () {Gtin = "8719351029111", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 10},
                     }
                },
                new Content(){Id = 3, Status = STATUSES.CANCELED,
                     Lines = new List<Line>{
                        new Line () {Gtin = "8719351029111", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 5},
                     }
                },
                new Content(){Id = 9, Status = STATUSES.IN_PROGRESS,
                     Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: M", Quantity = 1},
                     }
                },
                new Content(){Id = 8, Status = STATUSES.IN_PROGRESS,
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: XL", Quantity = 2},
                     }
                },
                new Content(){Id = 7, Status = STATUSES.IN_PROGRESS,
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 1},
                    }
                },
                new Content(){Id = 6, Status = STATUSES.IN_PROGRESS,
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: M", Quantity = 3},
                    }
                },
                new Content(){Id = 5, Status = STATUSES.IN_PROGRESS,
                      Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 2},
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: L", Quantity = 1},
                    }
                },
            };

            root.Content = _orders;
        }

        #endregion

        public async Task<Root> GetAllByInProgressStatus()
        {
             root.Content.Where(x => x.Status == STATUSES.IN_PROGRESS);

            return await Task.FromResult(root);
        }

        public async Task<List<Line>> GetTopFiveProductsSold()
        {
            var root = await GetAllByInProgressStatus();

            var topFiveProducts = root.Content.SelectMany(x => x.Lines).OrderByDescending(x => x.Quantity).Take(5).ToList();

            return topFiveProducts;
        }

        public Task<Root> GetTopFiveProductsWithIDSold()
        {
            throw new System.NotImplementedException();
        }
    }
}
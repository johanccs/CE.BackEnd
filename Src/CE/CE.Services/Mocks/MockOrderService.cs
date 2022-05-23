using CE.Contracts;
using CE.Domain.Dtos;
using CE.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CE.Services.Mocks
{
    public class MockOrderService : IOrderService
    {
        #region Fields

        IReadOnlyList<Order> _orders;

        #endregion

        #region Ctor

        public MockOrderService()
        {
            _orders = new List<Order>()
            {
                new Order(){Id = 10, Status = STATUSES.IN_PROGRESS, 
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 1},
                     } 
                },

                new Order(){Id = 2, Status = STATUSES.AWAITING_PAYMENT,
                      Lines = new List<Line>{
                        new Line () {Gtin = "8719351029111", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 10},
                     }
                },
                new Order(){Id = 3, Status = STATUSES.CANCELED,
                     Lines = new List<Line>{
                        new Line () {Gtin = "8719351029111", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 5},
                     }
                },
                new Order(){Id = 9, Status = STATUSES.IN_PROGRESS,
                     Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: M", Quantity = 1},
                     }
                },
                new Order(){Id = 8, Status = STATUSES.IN_PROGRESS,   
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: XL", Quantity = 2},
                     } 
                },
                new Order(){Id = 7, Status = STATUSES.IN_PROGRESS,
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 1},
                    }
                },
                new Order(){Id = 6, Status = STATUSES.IN_PROGRESS,
                    Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: M", Quantity = 3},
                    }
                },
                new Order(){Id = 5, Status = STATUSES.IN_PROGRESS,
                      Lines = new List<Line>{
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: S", Quantity = 2},
                        new Line () {Gtin = "8719351029609", Description = "T-shirt met lange mouw BASIC petrol: L", Quantity = 1},
                    }
                },
            };
        }

        #endregion

        public IReadOnlyList<Order> GetAllByInProgressStatus()
        {
            return _orders.Where(x=>x.Status == STATUSES.IN_PROGRESS).ToList();
        }

        public IReadOnlyList<Line> GetTopFiveProductsSold()
        {
            var inprogress_Orders = GetAllByInProgressStatus();

            var topFiveProducts = inprogress_Orders.SelectMany(x => x.Lines).OrderByDescending(x => x.Quantity).Take(5).ToList();
           
            return topFiveProducts;
        }
    }
}
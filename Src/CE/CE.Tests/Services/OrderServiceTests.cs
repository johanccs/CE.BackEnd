using CE.Contracts;
using CE.Domain.Entities;
using CE.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CE.Tests.Services
{
    public class OrderServiceTests
    {
        #region Readonly Fields

        IOrderService _orderService;

        #endregion

        #region Ctor

        public OrderServiceTests()
        {
            _orderService = new OrderService();
        }

        #endregion

        #region Methods

        [Fact]
        public async Task Should_NotReturn_NullInProgressStatus_List()
        {

            var results = await _orderService.GetAllByInProgressStatus();

            Assert.NotNull(results);
        }

        [Fact]
        public async Task Should_Return_One_Or_More_Orders()
        {

            var results = await _orderService.GetAllByInProgressStatus();

            Assert.True(results.Content.Count > 0);
        }

        [Fact]
        public async Task Should_Return_Top_Five_Products_Sold()
        {

            var results = await _orderService.GetTopFiveProductsWithIDSold();

            Assert.True(results.Content.Count == 5);
            
            Assert.True(results.GetType() == typeof(Root));
        }

        #endregion

    }
}

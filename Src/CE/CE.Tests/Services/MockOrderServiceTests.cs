﻿using CE.Contracts;
using CE.Domain.Dtos;
using CE.Services.Mocks;
using System.Collections.Generic;
using Xunit;

namespace CE.Tests.Services
{
    public class MockOrderServiceTests
    {
        #region Readonly Fields

        IOrderService _orderService;

        #endregion

        public MockOrderServiceTests()
        {
            _orderService = new MockOrderService();
        }

        [Fact]
        public void Should_NotReturn_NullInProgressStatus_List()
        {

            var results = _orderService.GetAllByInProgressStatus();

            Assert.NotNull(results);
        }

        [Fact]
        public void Should_Return_One_Or_More_Orders()
        {

            var results = _orderService.GetAllByInProgressStatus();

            Assert.True(results.Count > 0);
        }

        [Fact]
        public void Should_Return_Top_Five_Products_Sold()
        {

            var results = _orderService.GetTopFiveProductsSold();

            Assert.True(results.Count == 5);
            Assert.True(results.GetType() == typeof(List<Line>));
        }
    }
}

﻿using CE.Contracts;
using CE.Domain.Dtos;
using CE.Services.Helper;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Linq;

namespace CE.Services
{
    public class OrderService : IOrderService
    {
        #region Readonly Fields

        private readonly string api_key = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private readonly string url = "https://api-dev.channelengine.net/api/v2/orders";
        private readonly string status = "IN_PROGRESS";

        #endregion

        #region Ctor

        public OrderService()
        {

        }

        #endregion


        public async Task<Root> GetAllByInProgressStatus()
        {
            try
            {
                var options = new JsonSerializerOptions()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString 
                };

                var result = await RemoteApiHelper.Get(url, api_key, status);

                Root returnResult = JsonSerializer.Deserialize<Root>(result, options);

                return returnResult;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Line>> GetTopFiveProductsSold()
        {
            try
            {
                var result = await RemoteApiHelper.Get(url, api_key, status);

                Root returnResult = JsonSerializer.Deserialize<Root>(result);

                var topFiveProducts = returnResult.Content.SelectMany(x => x.Lines).OrderByDescending(x => x.Quantity).Take(5).ToList();

                return topFiveProducts;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Root> GetTopFiveProductsWithIDSold()
        {
            try
            {
                var result = await RemoteApiHelper.Get(url, api_key, status);

                Root returnResult = JsonSerializer.Deserialize<Root>(result);

                return returnResult;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

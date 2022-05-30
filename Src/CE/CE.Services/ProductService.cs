using CE.Contracts;
using CE.Domain.Entities.Products;
using CE.Services.Helper;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace CE.Services
{
    public class ProductService : IProdService
    {
        #region Readonly Fields

        private readonly string _api_key = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private readonly string _url = "https://api-dev.channelengine.net/api/v2/products";

        #endregion

        #region Ctor

        public ProductService(string url, string api_key)
        {
            _url = url;
            _api_key = api_key;
        }

        #endregion

        #region Methods

        public async Task<bool> UpdateProductQty(string name, int qty)
        {
            try
            {
                var root = await GetProductByName(name);
                root.Content[0].Stock = qty;

                var jsonContent = JsonSerializer.Serialize(root.Content);

                var result = await RemoteApiHelper.PostAsync(_url, jsonContent, _api_key);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private async Task<Root> GetProductByName(string name)
        {
            var api_url = $"{_url}?search={name}";
            var result = await RemoteApiHelper.GetAsync(api_url, _api_key, name);

            Root returnResult = JsonSerializer.Deserialize<Root>(result);

            return returnResult;
        }

        #endregion
    }
}

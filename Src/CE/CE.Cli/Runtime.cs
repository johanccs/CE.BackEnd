using CE.Contracts;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CE.Cli
{
    public class Runtime
    {
        #region Readonly Fields

        private readonly IOrderService _orderService;

        #endregion

        #region Ctor

        public Runtime(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        #region Methods

        public async Task Run()
        {
            var results = await _orderService.GetAllByInProgressStatus();

            if (results.Count > 0)
            {
                var builder = new StringBuilder();
                builder.AppendLine("Id | Order Date | ");

                foreach (var result in results)
                {
                    builder.AppendLine($"{nameof(result.Id)}: {result.Id} | ");

                }

                Console.WriteLine(builder.ToString());
                Console.Read();
            }
        }

        #endregion
    }
}

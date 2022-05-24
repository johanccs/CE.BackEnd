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
            var answer = await DisplayMenu();

            await DisplayByMenuItem(answer);
        }

        private async Task<int> DisplayMenu()
        {
            Console.WriteLine("Please select an action from the menu");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("1. Orders By In progress status");
            Console.WriteLine("2. Top five products sold");
            Console.WriteLine("3. Update product quantity");

            Console.WriteLine("");

            Console.Write("Answer: ");
            
            return await Task.FromResult(Convert.ToInt32(Console.ReadLine()));
        }

        private async Task DisplayByMenuItem(int answer)
        {
            switch(answer)
            {
                case 1:
                     PrintAndClearEmptyLine();
                     await DisplayOrdersInProgress();
                     break;

                case 2:
                    await DisplayTopFiveProducts();
                    break;

                case 3:
                    await UpdateOrderQuantity();
                    break;

                default:
                    Console.Clear();
                    await DisplayMenu();
                    return;

            }

            Console.WriteLine("");
            Console.Write("Press 9 to go to Main Menu: ");
            var ans = Convert.ToInt32(Console.ReadLine());

            if (ans == 9)
            {
                Console.Clear();
                await DisplayMenu();
            }
        }

        private Task UpdateOrderQuantity()
        {
            throw new NotImplementedException();
        }

        private async Task DisplayTopFiveProducts()
        {
            throw new NotImplementedException();
        }

        private async Task DisplayOrdersInProgress()
        {
            var results = await _orderService.GetAllByInProgressStatus();

            if (results.Count > 0)
            {
                DisplayFormattedData.WriteHeader();
                DisplayFormattedData.WriteBody(results);
            }
        }

        private void PrintAndClearEmptyLine()
        {
            Console.Clear();
            Console.WriteLine("");
        }

        #endregion
    }
}

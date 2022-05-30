using CE.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Cli
{
    public static class DisplayFormattedData
    {
        public static void WriteHeader()
        {
            var builder = new StringBuilder();
            Console.WriteLine("{0,5}  {1,15}  {2,20}", "Id", "Order Date", "Total Quantity");
            builder.AppendLine("---------------------------------------------------");

            Console.WriteLine(builder.ToString());
        }

        public static void WriteBody(List<Content> orders)
        {
            var builder = new StringBuilder();

            foreach (var order in orders)
            {
                Console.WriteLine("{0,5} {1,15} {2,20}", order.Id, order.OrderDate.ToString("yyyy-MM-dd"), order.Lines.Sum(x=>x.Quantity));
            }
        }
    }
}

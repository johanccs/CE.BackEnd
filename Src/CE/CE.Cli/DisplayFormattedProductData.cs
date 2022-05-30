using CE.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Cli
{
    public static class DisplayFormattedProductData
    {
        public static void WriteHeader()
        {
            var builder = new StringBuilder();
            Console.WriteLine("{0,10}  {1,25}  {2,50}", "GTIN", "Name", "Total Quantity Sold");
            builder.AppendLine("---------------------------------------------------------------------------------------------");

            Console.WriteLine(builder.ToString());
        }

        public static void WriteBody(List<Line> products)
        {
            var builder = new StringBuilder();

            foreach (var prod in products)
            {
                Console.WriteLine("{0,5} {1,45} {2,20}", prod.Gtin, prod.Description, prod.Quantity);
            }
        }
    }
}

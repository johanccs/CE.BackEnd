using System.Collections.Generic;

namespace CE.Api.ViewModels
{
    public class ProductToBeUpdated
    {
        public int Id { get; set; }

        public string OrderDate { get; set; }

        public List<LineToBeUpdated> Lines { get; set; } = new List<LineToBeUpdated>();
    }
}

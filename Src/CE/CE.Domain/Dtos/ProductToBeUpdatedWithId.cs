namespace CE.Domain.Entities
{
    public class ProductToBeUpdatedWithId
    {
        public int Id { get; set; }

        public string GTIN { get; set; }

        public string Description { get; set; }

        public int Qty { get; set; }
    }
}

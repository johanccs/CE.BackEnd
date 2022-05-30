using MediatR;

namespace CE.Services.Features.Products.Requests.Commands
{
    public class UpdateProductQtyCommand: IRequest<bool>
    {
        #region Properties

        public int Id { get; set; }

        public string Gtin { get; set; }

        public string Description { get; set; }

        public int Qty { get; set; }

        #endregion

        #region Ctor
        public UpdateProductQtyCommand(int id, string gtin, string description, int qty)
        {
            Id = id;
            Gtin = gtin;
            Description = description;
            Qty = qty;
        }

        #endregion
    }
}

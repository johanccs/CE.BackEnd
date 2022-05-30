using CE.Contracts;
using CE.Services.Features.Products.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CE.Services.Features.Products.Handlers.Commands
{
    public class UpdateProductQtyCommandHandler : IRequestHandler<UpdateProductQtyCommand, bool>
    {
        #region Fields

        private readonly IProdService _prodService;
     
        #endregion

        #region Ctor

        public UpdateProductQtyCommandHandler(IProdService prodService)
        {
            _prodService = prodService;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(UpdateProductQtyCommand request, CancellationToken cancellationToken)
        {
            return await _prodService.UpdateProductQty(request.Description, request.Qty);
        }

        #endregion

    }
}

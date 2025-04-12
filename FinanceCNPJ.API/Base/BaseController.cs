using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCNPJ.API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        protected IMediator Mediator => _mediator;
    }
}

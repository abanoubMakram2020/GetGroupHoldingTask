using GetGroupHoldingTask.Application.DTOs.InputDTOs;
using GetGroupHoldingTask.Application.Interfases.UseCases.V1_0.CustomerUseCases;
using GetGroupHoldingTask.Presentation.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Common;
using SharedKernal.Middlewares.Basees;

namespace GetGroupHoldingTask.Presentation.API.Areas.V1_0.Controllers
{
    [ApiVersion(version: APIVersion.Version1)]
    public class CustomerController : BaseController
    {
        [HttpGet]
        [MapToApiVersion(APIVersion.Version1)]
        public async Task<IActionResult> Search([FromServices] ICustomerSearchUseCase customerSearchUseCase,  [FromQuery] CustomerSearchInputDTO model) =>
            await Presenter.Handle(customerSearchUseCase.Handle, new BaseRequestDto<CustomerSearchInputDTO>
            {
                Data = model
            });
    }
}

using GetGroupHoldingTask.Application.DTOs.InputDTOs;
using GetGroupHoldingTask.Application.DTOs.OutputDTOs;
using SharedKernal.Middlewares.Basees;

namespace GetGroupHoldingTask.Application.Interfases.UseCases.V1_0.CustomerUseCases
{
    public interface ICustomerSearchUseCase:IBaseUseCase<CustomerSearchInputDTO,List<CustomerSearchOutputDTO>>
    {
    }
}

using GetGroupHoldingTask.Application.DTOs.InputDTOs;
using GetGroupHoldingTask.Application.DTOs.OutputDTOs;
using GetGroupHoldingTask.Application.Interfases.UseCases.V1_0.CustomerUseCases;
using GetGroupHoldingTask.Domain.Data.Entities;
using SharedKernal.Common.Enum;
using SharedKernal.DataRepositories;
using SharedKernal.Middlewares.Basees;

namespace GetGroupHoldingTask.Application.UseCases.V1_0.CustomerUseCases
{
    public class CustomerSearchUseCase : BaseUseCase, ICustomerSearchUseCase
    {
        public IGenericRepository<Customer, int> CustomerRepository { get; set; }
        public async Task<ResponseResultDto<List<CustomerSearchOutputDTO>>> Handle(BaseRequestDto<CustomerSearchInputDTO> model)
        {
            if (model.Data is null)
                return ResponseResultDto<List<CustomerSearchOutputDTO>>.InvalidData(result: null, message: MessageResource.GetMessage(ResponseStatusCode.InvalidData));

            var customers = CustomerRepository.Get();

            //search for customer name
            if (!string.IsNullOrWhiteSpace(model.Data.CustomerName) && model.Data.CustomerNameSearchOperator is not null)
            {
                if (model.Data.CustomerNameSearchOperator == StringSearchOperator.contains)
                {
                    customers = customers.Where(x => x.Name.Contains(model.Data.CustomerName));
                }
                else if (model.Data.CustomerNameSearchOperator == StringSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.Name == model.Data.CustomerName);
                }
            }

            //search for Job name
            if (!string.IsNullOrWhiteSpace(model.Data.Job) && model.Data.JobSearchOperator is not null)
            {
                if (model.Data.JobSearchOperator == StringSearchOperator.contains)
                {
                    customers = customers.Where(x => x.Job.Contains(model.Data.Job));
                }
                else if (model.Data.JobSearchOperator == StringSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.Job == model.Data.Job);
                }
            }

            //search for Address name
            if (!string.IsNullOrWhiteSpace(model.Data.Address) && model.Data.AddressSearchOperator is not null)
            {
                if (model.Data.AddressSearchOperator == StringSearchOperator.contains)
                {
                    customers = customers.Where(x => x.Address.Contains(model.Data.Address));
                }
                else if (model.Data.AddressSearchOperator == StringSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.Address == model.Data.Address);
                }
            }

            //search for Phone name
            if (!string.IsNullOrWhiteSpace(model.Data.Phone) && model.Data.PhoneSearchOperator is not null)
            {
                if (model.Data.PhoneSearchOperator == StringSearchOperator.contains)
                {
                    customers = customers.Where(x => x.Phone.Contains(model.Data.Phone));
                }
                else if (model.Data.PhoneSearchOperator == StringSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.Phone == model.Data.Phone);
                }
            }

            //search for Email name
            if (!string.IsNullOrWhiteSpace(model.Data.Email) && model.Data.EmailSearchOperator is not null)
            {
                if (model.Data.EmailSearchOperator == StringSearchOperator.contains)
                {
                    customers = customers.Where(x => x.Email.Contains(model.Data.Email));
                }
                else if (model.Data.EmailSearchOperator == StringSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.Email == model.Data.Email);
                }
            }

            //search for DateOfBirth name
            if (model.Data.DateOfBirth is not null && model.Data.DateOfBirthSearchOperator is not null)
            {
                if (model.Data.DateOfBirthSearchOperator == DateSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.DateOfBirth == model.Data.DateOfBirth);
                }
                else if (model.Data.DateOfBirthSearchOperator == DateSearchOperator.GreaterThan)
                {
                    customers = customers.Where(x => x.DateOfBirth > model.Data.DateOfBirth);
                }
                else if (model.Data.DateOfBirthSearchOperator == DateSearchOperator.LessThan)
                {
                    customers = customers.Where(x => x.DateOfBirth < model.Data.DateOfBirth);
                }
            }

            //search for NumberOfOrders name
            if (model.Data.NumberOfOrders is not null && model.Data.NumberOfOrdersSearchOperator is not null)
            {
                if (model.Data.NumberOfOrdersSearchOperator == NumbersSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.Orders.Count() == model.Data.NumberOfOrders);
                }
                else if (model.Data.NumberOfOrdersSearchOperator == NumbersSearchOperator.GreaterThan)
                {
                    customers = customers.Where(x => x.Orders.Count() > model.Data.NumberOfOrders);
                }
                else if (model.Data.NumberOfOrdersSearchOperator == NumbersSearchOperator.LessThan)
                {
                    customers = customers.Where(x => x.Orders.Count() < model.Data.NumberOfOrders);
                }
            }
            //search for TotalAmountOfTotalOrders name
            if (model.Data.TotalAmountOfTotalOrders is not null && model.Data.TotalAmountOfTotalOrdersSearchOperator is not null)
            {
                if (model.Data.TotalAmountOfTotalOrdersSearchOperator == NumbersSearchOperator.Equal)
                {
                    customers = customers.Where(x => x.Orders.Sum(x => x.TotalAmount) == model.Data.TotalAmountOfTotalOrders);
                }
                else if (model.Data.TotalAmountOfTotalOrdersSearchOperator == NumbersSearchOperator.GreaterThan)
                {
                    customers = customers.Where(x => x.Orders.Sum(x => x.TotalAmount) > model.Data.TotalAmountOfTotalOrders);
                }
                else if (model.Data.TotalAmountOfTotalOrdersSearchOperator == NumbersSearchOperator.LessThan)
                {
                    customers = customers.Where(x => x.Orders.Sum(x => x.TotalAmount) < model.Data.TotalAmountOfTotalOrders);
                }
            }

            customers = model.Data.OrderType == OrderEnum.Asc ? customers.OrderBy(x => x.Id) : customers.OrderByDescending(x => x.Id);
            var result = Mapper.Map<List<CustomerSearchOutputDTO>>(customers);
            return ResponseResultDto<List<CustomerSearchOutputDTO>>.Success(result: result, message: MessageResource.GetMessage(ResponseStatusCode.Successfully));
        }

    }
}

namespace GetGroupHoldingTask.Application.DTOs.OutputDTOs
{
    public class CustomerSearchOutputDTO : BaseOutputDTO<int>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

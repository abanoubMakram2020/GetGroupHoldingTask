namespace GetGroupHoldingTask.Application.DTOs.OutputDTOs
{
    public class BaseOutputDTO<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
    }
}

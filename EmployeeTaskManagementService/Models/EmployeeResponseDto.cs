namespace EmployeeTaskManagementService.Models
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? TeamName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<TaskResponseDto> AssignedTasks { get; set; } = new List<TaskResponseDto>();
    }
}

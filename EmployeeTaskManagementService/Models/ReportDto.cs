namespace EmployeeTaskManagementService.Models
{
    public class ReportDto
    {
        public string TeamName { get; set; }
        public List<TaskResponseDto> AssignedTasks { get; set; }
        public int OpenTasks { get; set; }
        public int CloseTasks { get; set; }
        public int InProgressTasks { get; set; }
    }
}

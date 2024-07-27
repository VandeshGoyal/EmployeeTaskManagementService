using EmployeeTaskManagementService.DataAcessLayer.Models;

namespace EmployeeTaskManagementService.Models
{
    public class TaskResponseDto
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public int EmployeeId { get; set; }
        public List<string> AttachedDocs { get; set; }
    }
}

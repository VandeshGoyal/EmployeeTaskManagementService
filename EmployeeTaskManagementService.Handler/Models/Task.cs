using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTaskManagementService.DataAcessLayer.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public string AssignedTeam { get; set; }
        public int EmployeeID { get; set; }
        public Employee AssignedEmployee { get; set; }

        [NotMapped]
        public List<string> AttachedDocs { get; set; }
    }
}

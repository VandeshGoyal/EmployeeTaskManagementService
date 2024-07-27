using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementService.Models
{
    public class EmployeeRequestDto
    {
        public string? Name { get; set; }
        public string? TeamName { get; set; }
    }
}

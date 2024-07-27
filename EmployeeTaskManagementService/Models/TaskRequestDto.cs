using EmployeeTaskManagementService.DataAcessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementService.Models
{
    public class TaskRequestDto
    {
        [Required]
        public string? TaskName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Estimated Days should be greater than 0")]
        public int EstimatedDays { get; set; }
    }
}

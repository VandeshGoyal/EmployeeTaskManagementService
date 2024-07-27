namespace EmployeeTaskManagementService.DataAcessLayer.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TeamName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<Models.Task> AssignedTasks { get; set; }
    }
}

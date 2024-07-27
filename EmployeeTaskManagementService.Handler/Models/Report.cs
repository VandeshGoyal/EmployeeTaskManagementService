namespace EmployeeTaskManagementService.DataAcessLayer.Models
{
    public class Report
    {
        public string TeamName { get; set; }
        public List<Models.Task> AssignedTasks { get; set; }
        public int OpenTasks { get; set; }
        public int ClosedTasks { get; set; }
        public int InProgressTasks { get; set; }
    }
}

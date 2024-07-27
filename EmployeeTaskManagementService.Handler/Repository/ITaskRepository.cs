namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public interface ITaskRepository
    {
        public Task<Models.Task> GetTaskById(int taskId);
        public Task<Models.Task> CreateTask(Models.Task task);
        public Task<string> UpdateTaskStatus(int taskId, Models.Status status);
        public Task<string> AssignTaskToEmployee(int taskId, int empId);
        public Task<List<Models.Task>> GetAllTasksAssignedToTeam(string teamName);
    }
}

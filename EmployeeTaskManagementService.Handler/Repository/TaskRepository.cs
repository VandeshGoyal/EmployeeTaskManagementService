
using EmployeeTaskManagementService.DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly EmployeeTaskDbContext _dbContext;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDocumentRepository _documentRepository;

        public TaskRepository(EmployeeTaskDbContext employeeTaskDbContext, IEmployeeRepository employeeRepository, IDocumentRepository documentRepository)
        {
            _dbContext = employeeTaskDbContext;
            _employeeRepository = employeeRepository;
            _documentRepository = documentRepository;
        }

        public async Task<string> AssignTaskToEmployee(int taskId, int empId)
        {
            var task = await _dbContext.Tasks.FindAsync(taskId);

            if (task == null)
            {
                throw new ApplicationException($"Task for the given Id: {taskId} not found.");
            }

            var employee = await _dbContext.Employees.FindAsync(empId);

            if (employee == null)
            {
                throw new ApplicationException("Employee Not found");
            }

            task.EmployeeID= employee.Id;
            task.AssignedTeam = employee.TeamName;
            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync();

            return $"Employee with Id:{empId} is assigned with task Id: {taskId}";


        }

        public async Task<Models.Task> CreateTask(Models.Task task)
        {
            var ent = _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<List<Models.Task>> GetAllTasksAssignedToTeam(string teamName)
        {
            var tasks = await _dbContext.Tasks.Where(t => t.AssignedTeam == teamName).ToListAsync();

            if (!tasks.Any())
            {
                return new List<Models.Task>();
            }

            foreach (var task in tasks)
            {
                var fileKeys = await _documentRepository.GetAllDocumentsForTask(task.Id);
                task.AttachedDocs = new List<string>(fileKeys);
            }

            return tasks;
        }

        public async Task<Models.Task> GetTaskById(int taskId)
        {
            var task = await _dbContext.Tasks.FindAsync(taskId);

            if (task == null)
            {
                throw new ApplicationException($"Task for the given Id: {taskId} not found.");
            }

            return task;
        }

        public async Task<string> UpdateTaskStatus(int taskId, Models.Status status)
        {
            var task = await _dbContext.Tasks.FindAsync(taskId);

            if (task == null)
            {
                throw new ApplicationException($"Task for the given Id: {taskId} not found.");
            }

            task.Status= status;
            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync();

            return $"Task with Id: {taskId} was updated with status {status}";
        }
    }
}

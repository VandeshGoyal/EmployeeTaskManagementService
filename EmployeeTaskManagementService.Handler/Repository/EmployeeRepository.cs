using EmployeeTaskManagementService.DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeTaskDbContext _dbContext;
        private readonly IDocumentRepository _documentRepository;

        public EmployeeRepository(EmployeeTaskDbContext employeeTaskDbContext, IDocumentRepository documentRepository) { 
            _dbContext = employeeTaskDbContext;
            _documentRepository = documentRepository;
        }

        public async Task<Models.Employee> CreateEmployee(Models.Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<string> DeleteEmployee(int empId)
        {
            var employee = await _dbContext.Employees.FindAsync(empId);

            if (employee == null)
            {
                throw new ApplicationException("Employee Not found");
            }

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return $"Employee with Id:{empId} deleted successfully";
        }

        public async Task<Models.Employee> GetAssignedUserTask(int empId)
        {
            var employee = await _dbContext.Employees.FindAsync(empId);
            if (employee == null)
            {
                throw new ApplicationException("Employee Not found");
            }

            var tasks = await _dbContext.Tasks.Where(t => t.EmployeeID == empId).ToListAsync();
            
            if(!tasks.Any())
            {
                return employee;
            }

            foreach (var task in tasks)
            {
                var fileKeys = await _documentRepository.GetAllDocumentsForTask(task.Id);
                task.AttachedDocs = new List<string>(fileKeys);
            }

            employee.AssignedTasks = new List<Models.Task>(tasks);

            return employee;
        }
    }
}

namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public interface IEmployeeRepository
    {
        public Task<Models.Employee> CreateEmployee(Models.Employee employee);
        public Task<string> DeleteEmployee(int empId);
        public Task<Models.Employee> GetAssignedUserTask(int empId);

    }
}

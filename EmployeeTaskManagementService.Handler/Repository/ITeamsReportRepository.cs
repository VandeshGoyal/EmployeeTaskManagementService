using EmployeeTaskManagementService.DataAcessLayer.Models;

namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public interface ITeamsReportRepository
    {
        public Task<ICollection<Report>> GetTeamsReport();
    }
}

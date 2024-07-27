using EmployeeTaskManagementService.DataAcessLayer.Repository;
using EmployeeTaskManagementService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ITeamsReportRepository _teamsReportRepository;

        public ReportController(ITeamsReportRepository teamsReportRepository)
        {
            _teamsReportRepository= teamsReportRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDto>>> GetReport()
        {
            try
            {
                var report = await _teamsReportRepository.GetTeamsReport();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

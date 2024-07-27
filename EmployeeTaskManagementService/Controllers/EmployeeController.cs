using EmployeeTaskManagementService.DataAcessLayer.Models;
using EmployeeTaskManagementService.DataAcessLayer.Repository;
using EmployeeTaskManagementService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponseDto>> Create(EmployeeRequestDto employee)
        {
            try
            {
                var resp = await _employeeRepository.CreateEmployee(employee.ToEmployeeEntity());
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                var resp = await _employeeRepository.DeleteEmployee(id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("employee/{id}/tasks")]
        public async Task<ActionResult<EmployeeResponseDto>> GetAssignedTask(int id)
        {
            try
            {
                var resp = await _employeeRepository.GetAssignedUserTask(id);
                return Ok(resp.ToEmployeeResponseDto());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

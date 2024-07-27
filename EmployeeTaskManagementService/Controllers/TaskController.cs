using EmployeeTaskManagementService.DataAcessLayer.Models;
using EmployeeTaskManagementService.DataAcessLayer.Repository;
using EmployeeTaskManagementService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IDocumentRepository _documentRepository;

        public TaskController(ITaskRepository taskRepository, IDocumentRepository documentRepository)
        {
            _taskRepository= taskRepository;
            _documentRepository= documentRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Create(TaskRequestDto task)
        {
            try
            {
                var resp = await _taskRepository.CreateTask(task.ToTaskEntity());
                return Ok(resp);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            } 
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TaskResponseDto>> UpdateStatus(int id, Status status)
        {
            try
            {
                var resp = await _taskRepository.UpdateTaskStatus(id, status);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}/assign/{userId}")]
        public async Task<ActionResult<string>> AssignUserATask(int id, int userId)
        {
            try
            {
                var resp = await _taskRepository.AssignTaskToEmployee(id, userId);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("team/{teamName}")]
        public async Task<ActionResult<List<Models.TaskResponseDto>>> GetTeamTask(string teamName)
        {
            try
            {
                var resp = await _taskRepository.GetAllTasksAssignedToTeam(teamName);
                return Ok(resp.ToTaskResponseDtoList());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

using EmployeeTaskManagementService.DataAcessLayer.Models;
using System.Threading.Tasks;
using Task = EmployeeTaskManagementService.DataAcessLayer.Models.Task;

namespace EmployeeTaskManagementService.Models
{
    public static class ModelsExtension
    {
        public static Employee ToEmployeeEntity(this EmployeeRequestDto employeeRequestDto)
        {
            return new Employee
            {
                Name = employeeRequestDto.Name,
                TeamName = employeeRequestDto.TeamName,
                CreatedDate = DateTime.UtcNow,
                AssignedTasks = new List<DataAcessLayer.Models.Task>()
            };
        }

        public static EmployeeResponseDto ToEmployeeResponseDto(this Employee employee)
        {
            List<TaskResponseDto> tasks = new List<TaskResponseDto>();
            foreach(var task in employee.AssignedTasks?? new List<DataAcessLayer.Models.Task>())
            {
                tasks.Add(task.ToTaskResponseDto());
            }
            return new EmployeeResponseDto
            {
                EmployeeId = employee.Id,
                Name = employee.Name,
                TeamName = employee.TeamName,
                CreatedDate = employee.CreatedDate,
                AssignedTasks = new List<TaskResponseDto>(tasks)
            };
        }

        public static Task ToTaskEntity(this TaskRequestDto taskRequestDto)
        {
            return new Task
            {
                TaskName = taskRequestDto.TaskName,
                CreatedDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(taskRequestDto.EstimatedDays),
                Status = Status.Open,
                AssignedTeam = "",
                EmployeeID = 1
            };
        }

        public static TaskResponseDto ToTaskResponseDto(this  Task task)
        {
            return new TaskResponseDto
            {
                TaskId = task.Id,
                TaskName = task.TaskName,
                CreatedDate = task.CreatedDate,
                DueDate = task.DueDate,
                Status = task.Status,
                EmployeeId = task.EmployeeID,
                AttachedDocs= new List<string>( task.AttachedDocs)
            };
        }

        public static List<TaskResponseDto> ToTaskResponseDtoList(this List<Task> tasks)
        {
            List<TaskResponseDto> tasksDto = new List<TaskResponseDto>();
            foreach (var t in tasks ?? new List<DataAcessLayer.Models.Task>())
            {
                tasksDto.Add(t.ToTaskResponseDto());
            }

            return tasksDto;
        }
    }
}

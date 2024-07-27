using EmployeeTaskManagementService.DataAcessLayer.Models;

namespace EmployeeTaskManagementService.DataAcessLayer.Repository
{
    public class TeamReportRepository : ITeamsReportRepository
    {
        private readonly EmployeeTaskDbContext _dbContext;

        public TeamReportRepository(EmployeeTaskDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<ICollection<Report>> GetTeamsReport()
        {
            var tasks = _dbContext.Tasks.ToList();

            if(!tasks.Any())
            {
                throw new ApplicationException("No Tasks found");
            }

            Dictionary<string, Report> result = new Dictionary<string, Report>();

            foreach(var task in tasks)
            {
                if(result.ContainsKey(task.AssignedTeam.ToLower()))
                {
                    result[task.AssignedTeam.ToLower()].AssignedTasks.Add(task);
                    if (task.Status == Status.Open)
                        result[task.AssignedTeam.ToLower()].OpenTasks++;
                    else if(task.Status == Status.InProgress)
                        result[task.AssignedTeam.ToLower()].InProgressTasks++;
                    else if(task.Status == Status.Completed || task.Status == Status.Cancelled)
                        result[task.AssignedTeam.ToLower()].ClosedTasks++;

                }
                else
                {
                    result.Add(task.AssignedTeam.ToLower(), new Report
                    {
                        TeamName = task.AssignedTeam,
                        AssignedTasks = new List<Models.Task>(),
                        OpenTasks = 0,
                        ClosedTasks = 0,
                        InProgressTasks = 0,
                    });

                    result[task.AssignedTeam.ToLower()].AssignedTasks.Add(task);
                    if (task.Status == Status.Open)
                        result[task.AssignedTeam.ToLower()].OpenTasks++;
                    else if (task.Status == Status.InProgress)
                        result[task.AssignedTeam.ToLower()].InProgressTasks++;
                    else if (task.Status == Status.Completed || task.Status == Status.Cancelled)
                        result[task.AssignedTeam.ToLower()].ClosedTasks++;
                }
            }

            if (result.Any())
            {
                return result.Values.ToList();
            }

            return new List<Report>();

        }
    }
}

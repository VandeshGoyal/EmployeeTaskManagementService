using EmployeeTaskManagementService.DataAcessLayer.Repository;

namespace EmployeeTaskManagementService
{
    public static class DependencyInjectionResolver
    {
        public static void ResolveDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<ITaskRepository, TaskRepository>();
            builder.Services.AddTransient<ITeamsReportRepository, TeamReportRepository>();
            builder.Services.AddTransient<IDocumentRepository, DocumentRepository>();
        }
    }
}

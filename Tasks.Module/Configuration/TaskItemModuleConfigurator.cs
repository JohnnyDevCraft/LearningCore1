using LearningCore1.WebApi.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tasks.Module.Configuration;

public static class TaskItemModuleConfigurator
{
    public static void AddTaskItemModule(this WebApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<TasksModuleDbContext>("TaskItemsDb");
    }
}
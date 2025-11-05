using LearningCore1.DataAccess;
using LearningCore1.Entities;
using LearningCore1.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningCore1.Endpoints;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/tasks")
            .WithTags("Tasks");

        group.MapPost("", async ([FromBody] TaskItem taskItem, [FromServices] TaskItemsContext context) =>
        {
            taskItem.Id =  Guid.NewGuid();
            
            context.TaskItems.Add(taskItem);
            await context.SaveChangesAsync();
            
            Results.Ok(taskItem);
        });

        group.MapGet("{id}", async ([FromRoute] Guid id, [FromServices] TaskItemsContext context) => 
        Results.Ok(context.TaskItems.SingleOrDefault(x => x.Id == id)));
        
        group.MapGet("", async ([FromServices] TaskItemsContext context) => Results.Ok(context.TaskItems.ToList()));
    }
}
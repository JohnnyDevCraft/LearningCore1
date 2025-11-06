using System.Security.Claims;
using LearningCore1.WebApi.DataAccess;
using LearningCore1.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LearningCore1.WebApi.Endpoints;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/tasks")
            .WithTags("Tasks");

        group.MapPost("", async ([FromBody] TaskItem taskItem, [FromServices] TaskItemsContext context, HttpContext httpContext) =>
        {
            taskItem.Id =  Guid.NewGuid();
            var user  = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            taskItem.AssignedToId = Guid.Parse(user?.Value ?? "");
            
            context.TaskItems.Add(taskItem);
            await context.SaveChangesAsync();
            
            Results.Ok(taskItem);
        })
        .RequireAuthorization();

        group.MapGet("{id}", async ([FromRoute] Guid id, [FromServices] TaskItemsContext context, HttpContext httpContext) =>
            {
                var userId = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var taskItem = context.TaskItems.SingleOrDefault(x => x.Id == id && x.AssignedToId == Guid.Parse(userId));
                if (taskItem == null)
                {
                    return Results.NotFound();
                }
                
                return Results.Ok(taskItem);
            })
        
        .RequireAuthorization();
        
        group.MapGet("", async ([FromServices] TaskItemsContext context, HttpContext httpContext) =>
            {
                var userId = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                return Results.Ok(context.TaskItems.Where(x => x.AssignedToId == Guid.Parse(userId)).ToList());
            })
        .RequireAuthorization();
    }
}
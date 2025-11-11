using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Tasks.Contracts.Requests;

namespace Tasks.Module.EndPoints;

public static class ModuleEndpoints
{
    public static void UseTaskItemModule(this WebApplication app)
    {
        var tasksGroup = app.MapGroup("api/tasks")
            .WithTags("Tasks");

        tasksGroup.MapPost("",
            async (CreateNewTaskRequest createNewTaskRequest, ISender sender, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(createNewTaskRequest, cancellationToken);
                return Results.Ok(result);
            });
    }
}
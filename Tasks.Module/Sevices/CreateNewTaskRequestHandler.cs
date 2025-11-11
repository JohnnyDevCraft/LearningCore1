using System.Security.Claims;
using LearningCore1.WebApi.DataAccess;
using LearningCore1.WebApi.Entities;
using Mediator;
using Microsoft.AspNetCore.Http;
using Tasks.Contracts.Requests;
using Tasks.Module.Mappers;

namespace Tasks.Module.Sevices;

public class CreateNewTaskRequestHandler(TasksModuleDbContext dbContext, IHttpContextAccessor accessor) : IRequestHandler<CreateNewTaskRequest, CreateNewTaskRequestResult>
{
    public async ValueTask<CreateNewTaskRequestResult> Handle(CreateNewTaskRequest request, CancellationToken cancellationToken)
    {
        var user = accessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var taskItem = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            AssignedToId = Guid.Parse(user ?? Guid.Empty.ToString())
        };

        dbContext.TaskItems.Add(taskItem);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateNewTaskRequestResult(taskItem.ToDto());
    }
}
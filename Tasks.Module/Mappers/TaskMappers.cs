using LearningCore1.WebApi.Entities;
using Tasks.Contracts.DataTransfer;

namespace Tasks.Module.Mappers;

public static class TaskMappers
{
    public static TaskItemDto ToDto(this TaskItem taskItem)
    {
        return new TaskItemDto()
        {
            Id = taskItem.Id,
            AssignedToId = taskItem.AssignedToId,
            AssignedToEmail = "",
            AssignedToName = "",
            Description = taskItem.Description,
            DueDate = taskItem.DueDate,
            IsDone = taskItem.IsDone,
            Title = taskItem.Title,
        };
    }
}
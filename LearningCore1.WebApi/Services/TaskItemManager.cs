using LearningCore1.WebApi.Entities;

namespace LearningCore1.WebApi.Services;

public class TaskItemManager
{
    public static Dictionary<Guid, TaskItem> TaskItems { get; set; } = new();
}
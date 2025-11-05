using LearningCore1.Entities;

namespace LearningCore1.Services;

public class TaskItemManager
{
    public static Dictionary<Guid, TaskItem> TaskItems { get; set; } = new();
}
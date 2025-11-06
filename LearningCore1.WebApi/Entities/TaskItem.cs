namespace LearningCore1.WebApi.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }

    public Guid? AssignedToId { get; set; }
    public TaskUser? AssignedTo { get; set; }
}
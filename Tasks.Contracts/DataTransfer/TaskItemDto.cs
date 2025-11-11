namespace Tasks.Contracts.DataTransfer;

public class TaskItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }

    public Guid? AssignedToId { get; set; }
    public string? AssignedToEmail { get; set; }
    public string? AssignedToName { get; set; }
}
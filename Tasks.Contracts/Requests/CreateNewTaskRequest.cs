using Mediator;
using Tasks.Contracts.DataTransfer;

namespace Tasks.Contracts.Requests;

public record CreateNewTaskRequest(string Title, string Description, DateTime DueDate, bool IsDone = false) : IRequest<CreateNewTaskRequestResult>;

public record CreateNewTaskRequestResult(TaskItemDto Task);
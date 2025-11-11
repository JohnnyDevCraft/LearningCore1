using Mediator;
using Tasks.Contracts.DataTransfer;

namespace Tasks.Contracts.Requests;

public record PatchTaskDueDateRequest(Guid TaskId, DateTime NewDueDate) : IRequest<PatchTaskDueDateRequestResult>;

public record PatchTaskDueDateRequestResult(TaskItemDto TaskItem);
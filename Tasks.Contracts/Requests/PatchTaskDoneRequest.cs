using Mediator;
using Tasks.Contracts.DataTransfer;

namespace Tasks.Contracts.Requests;

public record PatchTaskDoneRequest(Guid Id, bool IsDone) : IRequest<PatchTaskDoneRequestResult>;

public record PatchTaskDoneRequestResult(TaskItemDto Task);
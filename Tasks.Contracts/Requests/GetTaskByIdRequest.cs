using Mediator;
using Tasks.Contracts.DataTransfer;

namespace Tasks.Contracts.Requests;

public record GetTaskByIdRequest(Guid Id) : IRequest<GetTaskByIdRequestResult>;

public record GetTaskByIdRequestResult(TaskItemDto Task);
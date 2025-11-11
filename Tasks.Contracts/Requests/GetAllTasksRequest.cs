using Mediator;
using Tasks.Contracts.DataTransfer;

namespace Tasks.Contracts.Requests;

public record GetAllTasksRequest(int page, int PageSize) : IRequest<GetAllTasksRequestResult>;

public record GetAllTasksRequestResult(IEnumerable<TaskItemDto> Tasks);
using HexPersonalSoft.Application.Common.Mappings;
using HexPersonalSoft.Domain.Entities;

namespace HexPersonalSoft.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

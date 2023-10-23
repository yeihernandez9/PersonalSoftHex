using HexPersonalSoft.Application.Common.Mappings;
using HexPersonalSoft.Domain.Entities;

namespace HexPersonalSoft.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}

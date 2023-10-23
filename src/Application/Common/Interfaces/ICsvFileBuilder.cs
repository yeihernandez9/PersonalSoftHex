using HexPersonalSoft.Application.TodoLists.Queries.ExportTodos;

namespace HexPersonalSoft.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}

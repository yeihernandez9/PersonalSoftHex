using System.Globalization;
using HexPersonalSoft.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace HexPersonalSoft.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}

using HexPersonalSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HexPersonalSoft.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Poliza> Polizas { get; }



    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

using System;
using HexPersonalSoft.Application.Common.Exceptions;
using HexPersonalSoft.Application.Common.Interfaces;
using HexPersonalSoft.Application.TodoItems.Commands.DeleteTodoItem;
using HexPersonalSoft.Domain.Entities;
using HexPersonalSoft.Domain.Events;
using MediatR;

namespace HexPersonalSoft.Application.Polizas.Commands.DeletePolizaCommand;

public record DeletePolizaCommand(int Id) : IRequest;

public class DeletePolizaCommandHandler : IRequestHandler<DeletePolizaCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePolizaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePolizaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Polizas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Poliza), request.Id);
        }

        _context.Polizas.Remove(entity);

        entity.AddDomainEvent(new PolizaDeleteEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}


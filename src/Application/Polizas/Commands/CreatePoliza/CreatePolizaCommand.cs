
using HexPersonalSoft.Application.Common.Interfaces;
using HexPersonalSoft.Domain.Entities;
using HexPersonalSoft.Domain.Events;
using MediatR;

namespace HexPersonalSoft.Application.Polizas.Commands.CreatePolizaCommand;

public record CreatePolizaCommand : IRequest<int>
{
    public int ListId { get; init; }
    public int Poliza { get; set; }
    public string? ClientName { get; set; }
    public string? ClientIdentification { get; set; }
    public string? DateBirth { get; set; }
    public string? DateCretePolicy { get; set; }
    public string? Coverage { get; set; }
    public string? ValueMax { get; set; }
    public string? PlanPolicyName { get; set; }
    public string? HomeCity { get; set; }
    public string? AddressHome { get; set; }
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
    public bool Inspeccion { get; set; }
    public string Polizaa { get; set; }
}

public class CreatePolizaCommandHandler : IRequestHandler<CreatePolizaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePolizaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePolizaCommand request, CancellationToken cancellationToken)
    {
        var entity = new Poliza
        {
            ListId = request.ListId,
            Polizaa = request.Poliza,
            ClientName = request.ClientName,
            ClientIdentification = request.ClientIdentification,
            DateBirth = request.DateBirth,
            DateCretePolicy = request.DateCretePolicy,
            Coverage = request.Coverage,
            ValueMax = request.ValueMax,
            PlanPolicyName = request.PlanPolicyName,
            HomeCity = request.HomeCity,
            AddressHome = request.AddressHome,
            Placa = request.Placa,
            Modelo = request.Modelo,
            Inspeccion = request.Inspeccion,

        };

        entity.AddDomainEvent(new PolizaCreatedEvent(entity));

        _context.Polizas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}



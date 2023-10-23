using System;
using HexPersonalSoft.Application.Common.Mappings;
using HexPersonalSoft.Domain.Entities;

namespace HexPersonalSoft.Application.Polizas.Queries.GetPolizaWhitPagination;

public class PolizaListDto : IMapFrom<Poliza>
{
    public int Id { get; init; }
    public int Polizaa { get; init; }
    public string? ClientName { get; init; }
    public string? ClientIdentification { get; init; }
    public string? DateBirth { get; init; }
    public string? DateCretePolicy { get; init; }
    public string? Coverage { get; init; }
    public string? ValueMax { get; init; }
    public string? PlanPolicyName { get; init; }
    public string? HomeCity { get; init; }
    public string? AddressHome { get; init; }
    public string? Placa { get; init; }
    public string? Modelo { get; init; }
    public bool Inspeccion { get; init; }
}



namespace HexPersonalSoft.Domain.Entities;

public class Poliza: BaseAuditableEntity
{
    public int ListId { get; set; }
    public int Polizaa { get; set; }
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

}


using System;
namespace HexPersonalSoft.Domain.Events;

public class PolizaCreatedEvent:  BaseEvent
{
    public PolizaCreatedEvent(Poliza item)
    {
        Item = item;
    }
    public Poliza Item { get; }
}


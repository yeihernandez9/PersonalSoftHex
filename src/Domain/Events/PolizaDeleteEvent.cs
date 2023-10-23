using System;
namespace HexPersonalSoft.Domain.Events;

public class PolizaDeleteEvent : BaseEvent
{
    public PolizaDeleteEvent(Poliza item)
    {
        Item = item;
    }

    public Poliza Item { get; }
}


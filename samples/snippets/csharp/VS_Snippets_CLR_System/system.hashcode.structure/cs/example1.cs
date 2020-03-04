// <Snippet1>
using System;
using System.Collections.Generic;

public struct OrderOrderLine : IEquatable<OrderOrderLine>
{
    public int OrderId { get; }
    public int OrderLineId { get; }

    public OrderOrderLine(int orderId, int orderLineId) => (OrderId, OrderLineId) = (orderId, orderLineId);

    public override bool Equals(object obj) => obj is OrderOrderLine o && Equals(o);

    public bool Equals(OrderOrderLine other) => OrderId == other.OrderId && OrderLineId == other.OrderLineId;

    public override int GetHashCode() => HashCode.Combine(OrderId, OrderLineId);
}

class Program
{
    static void Main(string[] args)
    {
        var set = new HashSet<OrderOrderLine>
        {
            new OrderOrderLine(1, 1),
            new OrderOrderLine(1, 1),
            new OrderOrderLine(1, 2)
        };

        Console.WriteLine($"Item count: {set.Count}.");
    }
}
// The example displays the following output:
// Item count: 2.
// </Snippet1>
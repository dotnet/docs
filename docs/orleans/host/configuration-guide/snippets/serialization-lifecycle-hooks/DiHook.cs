using Microsoft.Extensions.Logging;
using Orleans;

namespace SerializationLifecycleHooks;

// <DiHookType>
[GenerateSerializer]
[SerializationCallbacks(typeof(OrderHooks))]
public class Order
{
    [Id(0)]
    public string OrderId { get; set; } = string.Empty;

    [Id(1)]
    public decimal Total { get; set; }

    [Id(2)]
    public List<string> Items { get; set; } = [];
}
// </DiHookType>

// <DiHookClass>
public class OrderHooks
{
    private readonly ILogger<OrderHooks> _logger;

    public OrderHooks(ILogger<OrderHooks> logger)
    {
        _logger = logger;
    }

    public void OnSerializing(Order value)
    {
        _logger.LogDebug(
            "Serializing order {OrderId} with {Count} items",
            value.OrderId,
            value.Items.Count);
    }

    public void OnDeserialized(Order value)
    {
        _logger.LogDebug(
            "Deserialized order {OrderId}, total: {Total:C}",
            value.OrderId,
            value.Total);
    }
}
// </DiHookClass>

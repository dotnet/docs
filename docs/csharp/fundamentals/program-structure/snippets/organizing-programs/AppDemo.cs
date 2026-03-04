// <ProjectStructure>
// MyApp.Core (class library) — shared business logic
namespace MyApp.Core;

public class Order
{
    public required string ProductName { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal Total => Quantity * UnitPrice;
}
// </ProjectStructure>

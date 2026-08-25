// <BlockScopedNamespace>
namespace MyApp.Models
{
    class Product
    {
        public required string Name { get; init; }
        public decimal Price { get; init; }

        public override string ToString() => $"{Name}: {Price:C}";
    }
}
// </BlockScopedNamespace>

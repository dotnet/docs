// <FileScopedNamespace>
namespace MyApp.Models;

class Customer
{
    public required string Name { get; init; }
    public string? Email { get; init; }

    public override string ToString() => $"{Name} ({Email ?? "no email"})";
}
// </FileScopedNamespace>

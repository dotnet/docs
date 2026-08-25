// <SnippetBasicAnonymousType>
var person = new { Name = "Alice", Age = 30 };
Console.WriteLine($"{person.Name} is {person.Age} years old.");
// Output:
// Alice is 30 years old.
// </SnippetBasicAnonymousType>

// <SnippetInferredNames>
string productName = "Laptop";
decimal price = 999.99m;
var product = new { productName, price };
Console.WriteLine($"{product.productName}: {product.price:C}");
// Output:
// Laptop: $999.99
// </SnippetInferredNames>

// <SnippetLinqProjection>
var words = new[] { "apple", "blueberry", "cherry" };

var results = words.Select(w => new { Word = w, Length = w.Length });

foreach (var item in results)
{
    Console.WriteLine($"{item.Word} has {item.Length} letters.");
}
// Output:
// apple has 5 letters.
// blueberry has 9 letters.
// cherry has 6 letters.
// </SnippetLinqProjection>

// <SnippetEquality>
var a = new { Name = "Alice", Age = 30 };
var b = new { Name = "Alice", Age = 30 };
var c = new { Name = "Bob", Age = 25 };

Console.WriteLine(a.Equals(b));  // True
Console.WriteLine(a.Equals(c));  // False
// </SnippetEquality>

// <SnippetNested>
var order = new
{
    OrderId = 1,
    Customer = new { Name = "Alice", City = "Seattle" },
    Total = 150.00m
};
Console.WriteLine($"Order {order.OrderId} for {order.Customer.Name} in {order.Customer.City}");
// Output:
// Order 1 for Alice in Seattle
// </SnippetNested>

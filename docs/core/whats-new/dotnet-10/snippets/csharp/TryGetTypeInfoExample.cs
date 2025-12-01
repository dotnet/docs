using System;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace TryGetTypeInfoExamples;

public class TryGetTypeInfoExample
{
    public static void Example()
    {
        // <TryGetTypeInfoExample>
        var options = new JsonSerializerOptions();
        
        // Try to get type info for a type
        if (options.TryGetTypeInfo(typeof(Product), out JsonTypeInfo? typeInfo))
        {
            Console.WriteLine($"Type info found for {typeInfo!.Type.Name}");
            Console.WriteLine($"Kind: {typeInfo.Kind}");
            
            // Use the type info for serialization
            Product product = new("Widget", 19.99m);
            string json = JsonSerializer.Serialize(product, typeInfo.Type, options);
            Console.WriteLine($"Serialized: {json}");
        }
        else
        {
            Console.WriteLine("Type info not found");
        }
        // </TryGetTypeInfoExample>
    }
}

record Product(string Name, decimal Price);

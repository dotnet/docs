using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TryGetTypeInfoSourceGenExamples;

// <TryGetTypeInfoSourceGen>
[JsonSerializable(typeof(Customer))]
public partial class MyJsonContext : JsonSerializerContext
{
    // Instead of duplicating logic for each type, use TryGetTypeInfo
    public override JsonTypeInfo? GetTypeInfo(Type type)
    {
        if (Options.TryGetTypeInfo(type, out JsonTypeInfo? typeInfo))
        {
            return typeInfo;
        }
        
        return null;
    }
}
// </TryGetTypeInfoSourceGen>

record Customer(string Name, string Email);

---
title: Custom serialization and deserialization contracts
description: "Learn how to write your own contract resolution logic to customize the JSON contract for a type."
ms.date: 09/26/2022
---
# Customize a JSON contract

The <xref:System.Text.Json?displayProperty=fullName> library constructs a JSON *contract* for each .NET type, which defines how the type should be serialized and deserialized. The contract is derived from the type's shape, which includes characteristics such as its properties and fields and whether it implements the <xref:System.Collections.IEnumerable> or <xref:System.Collections.IDictionary> interface. Types are mapped to contracts either at run time using reflection or at compile time using the source generator.

Starting in .NET 7, you can customize these JSON contracts to provide more control over how types are converted into JSON and vice versa. The following list shows just some examples of the types of customizations you can make to serialization and deserialization:

- Serialize private fields.
- Support multiple names for a single property (for example, if a previous library version used a different name).
- Construct new properties for serialization.
- Ignore properties with a specific name, type, or value.
- Replace `null` values with some other value.
- Distinguish between explicit `null` values vs. lack of a value in the JSON payload.

## Other ways to customize

Besides customizing a contract, there are other ways to influence serialization and deserialization behavior, including the following:

- The use of attributes derived from <xref:System.Text.Json.Serialization.JsonAttribute>, for example, <xref:System.Text.Json.Serialization.JsonIgnoreAttribute> and <xref:System.Text.Json.Serialization.JsonPropertyOrderAttribute>.
- Modifying <xref:System.Text.Json.JsonSerializerOptions>, for example, to set a naming policy or serialize enumeration values as strings instead of numbers.
- Writing a custom converter that does the actual work of writing the JSON and, during deserialization, constructing an object.

Contract customization is an improvement over these pre-existing customizations because you might not have access to the type to add attributes, and writing a custom converter is complex and hurts performance.

## How to opt in

There are two ways to plug into customization. Both involve obtaining a resolver, whose job is to provide a <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> instance for each type that needs to be serialized.

- By calling the <xref:System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver.%23ctor> constructor to obtain the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver?displayProperty=nameWithType> and adding your custom actions to its <xref:System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver.Modifiers> property.

  For example:

  ```csharp
  JsonSerializerOptions options = new()
  {
      TypeInfoResolver = new DefaultJsonTypeInfoResolver()
      {
          Modifiers =
          {
              MyCustomModifier1,
              MyCustomModifier2
          }
      }
  };
  ```

  If you add multiple modifiers, they'll be called serially.

- By writing a custom resolver that implements <xref:System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver>.

  - If a type is not handled, <xref:System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver.GetTypeInfo%2A?displayProperty=nameWithType> should return `null` for that type.
  - You can also combine your custom resolver with others, for example, the default resolver. The resolvers will be queried in order until a non-null <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> value is returned for the type.

## Configurable aspects

The <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo.Kind?displayProperty=nameWithType> property for a type indicates which aspects of its JSON contract are configurable. The `JsonTypeInfoKind.Object` kind ...



## See also

- [JSON contract customization blog post](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-6/#json-contract-customization)

- Combine reflection-based resolver with source-generated resolver

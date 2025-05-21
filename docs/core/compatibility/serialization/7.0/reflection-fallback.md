---
title: "Breaking change: System.Text.Json source generator fallback"
description: Learn about the .NET 7 breaking change in serialization where the System.Text.Json source generator no longer fall backs to reflection-based serialization for unrecognized types.
ms.date: 09/12/2022
ms.topic: concept-article
---
# System.Text.Json source generator fallback

When using one of the <xref:System.Text.Json.JsonSerializer> methods that accepts <xref:System.Text.Json.JsonSerializerOptions>, the <xref:System.Text.Json?displayProperty=fullName> source generator will no longer implicitly fall back to reflection-based serialization for unrecognized types.

## Previous behavior

Consider the following source generation example in .NET 6:

```csharp
JsonSerializer.Serialize(new Poco2(), typeof(Poco2), MyContext.Default);

[JsonSerializable(typeof(Poco1))]
public partial class MyContext : JsonSerializerContext {}

public class Poco1 { }
public class Poco2 { }
```

Since `MyContext` does not include `Poco2` in its serializable types, the serialization will correctly fail with the following exception:

```output
System.InvalidOperationException:

'Metadata for type 'Poco2' was not provided to the serializer. The serializer method used does not 
support reflection-based creation of serialization-related type metadata. If using source generation, 
ensure that all root types passed to the serializer have been indicated with 'JsonSerializableAttribute', 
along with any types that might be serialized polymorphically.
```

Now consider the following call, which tries to serialize the same type (`MyContext`) using the <xref:System.Text.Json.JsonSerializerOptions> instance constructed by the source generator:

```csharp
JsonSerializer.Serialize(new Poco2(), MyContext.Default.Options);
```

The options instance silently incorporates the default reflection-based contract resolver as a fallback mechanism, and as such, the type serializes successfully&mdash;using reflection.

The same fallback logic applies to <xref:System.Text.Json.JsonSerializerOptions.GetConverter(System.Type)?displayProperty=nameWithType> for options instances that are attached to a <xref:System.Text.Json.Serialization.JsonSerializerContext>. The following statement will return a converter using the built-in reflection converter:

```csharp
JsonConverter converter = MyContext.Default.Options.GetConverter(typeof(Poco2));
```

## New behavior

Starting in .NET 7, the following call fails with the same exception (<xref:System.InvalidOperationException>) as when using the <xref:System.Text.Json.Serialization.JsonSerializerContext> overload:

```csharp
JsonSerializer.Serialize(new Poco2(), MyContext.Default.Options);
```

In addition, the following statement will fail with a <xref:System.NotSupportedException>:

```csharp
JsonConverter converter = MyContext.Default.Options.GetConverter(typeof(Poco2));
```

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The previous behavior violates the principle of least surprise and ultimately defeats the purpose of source generation. With the release of a feature that allows you to [customize the JSON serialization contracts of your types](https://github.com/dotnet/runtime/issues/63686), you have the ability to fine tune the sources of your contract metadata. With this in mind, silently introducing alternative sources becomes even less desirable.

## Recommended action

You might depend on the previous behavior, either intentionally or unintentionally. The recommended course of action is to update your <xref:System.Text.Json.Serialization.JsonSerializerContext> definition so that it includes all type dependencies:

```csharp
[JsonSerializable(typeof(Poco1))]
[JsonSerializable(typeof(Poco2))]
public partial class MyContext : JsonSerializerContext {}
```

This will let your application take full advantage of the benefits of source generation, including trim safety.

In certain cases, however, making such a change might not be practical or possible. Even though it's not recommended, there are a couple of ways you can re-enable reflection fallback in your source-generated serializer.

### Use a custom contract resolver

You can use the new contract customization feature to build a custom contract resolver that falls back to reflection-based resolution where required:

```csharp
var options = new JsonSerializerOptions
{
     TypeInfoResolver = JsonTypeInfoResolver.Combine(MyContext.Default, new DefaultJsonTypeInfoResolver());
}

JsonSerializer.Serialize(new Poco2(), options); // Contract resolution falls back to the default reflection-based resolver.
options.GetConverter(typeof(Poco2)); // Returns the reflection-based converter.
```

### Use an AppContext switch

Starting in .NET 7, you can re-enable reflection fallback globally using the provided AppContext compatibility switch. Add the following entry to your application's project file to re-enable reflection fallback for all source-generated contexts in your app. For more information on using AppContext switches, see the article on [.NET runtime configuration settings](../../../runtime-config/index.md).

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Text.Json.Serialization.EnableSourceGenReflectionFallback" Value="true" />
</ItemGroup>
```

## Affected APIs

- <xref:System.Text.Json.JsonSerializerOptions.GetConverter(System.Type)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize(System.IO.Stream,System.Object,System.Type,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize(System.Object,System.Type,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize(System.Text.Json.Utf8JsonWriter,System.Object,System.Type,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(System.IO.Stream,%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Serialize%60%601(System.Text.Json.Utf8JsonWriter,%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.SerializeAsync(System.IO.Stream,System.Object,System.Type,System.Text.Json.JsonSerializerOptions,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.SerializeAsync%60%601(System.IO.Stream,%60%600,System.Text.Json.JsonSerializerOptions,System.Threading.CancellationToken)?displayProperty=fullName>

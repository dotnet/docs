---
title: "Breaking change: Reflection-based deserializer resolves metadata eagerly"
description: Learn about the .NET 8 breaking change in System.Text.Json serialization where the reflection-based deserializer resolves property metadata eagerly.
ms.date: 09/13/2023
ms.topic: concept-article
---
# Reflection-based deserializer resolves metadata eagerly

The System.Text.Json reflection-based serializer previously used a lazy loading approach to resolve property metadata. That approach made it possible for POCOs that contained unsupported property types to deserialize successfully, provided that the underlying JSON didn't bind to any of the unsupported properties. (This was despite the fact that instances of the same type would fail to *serialize*.)

Starting with .NET 8, the serializer has been changed so that all properties are resolved eagerly in both serialization and deserialization. This change was made to add better support for combining multiple resolvers, which necessitates early analysis of the serialized type graph. A side-effect of this change is that if you depended on the previous behavior, you could start seeing new runtime deserialization errors.

## Previous behavior

The following deserialization code succeeded in .NET 7.

```csharp
var result = JsonSerializer.Deserialize<MyPoco>("""{ "Value": 1 }"""); //, MyContext.Default.MyPoco);
Console.WriteLine(result.Value);

public class MyPoco
{
    public int Value { get; set; }

    public NestedValue Unsupported { get; set; }
}

public class NestedValue
{
    public ReadOnlySpan<byte> Span => Array.Empty<byte>();
}
```

## New behavior

Starting in .NET 8, the same code from the [Previous behavior](#previous-behavior) section throws an <xref:System.InvalidOperationException> at run time.

> System.InvalidOperationException: The type 'System.ReadOnlySpan`1[System.Byte]' of property 'Span' on type 'NestedValue' is invalid for serialization or deserialization because it is a pointer type, is a ref struct, or contains generic parameters that have not been replaced by specific types.

This error is consistent with the error that was thrown even in previous versions if you attempted to serialize an instance of the same type. It's also consistent with the source generator, which produces a compile-time error.

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was necessitated by new requirements related to fast-path serialization support in combined source generated contexts (see [dotnet/runtime#71933](https://github.com/dotnet/runtime#71933)).

## Recommended action

If this change is problematic for you, you can:

- Remove the unsupported property from your type.
- Author a custom converter for the unsupported type.
- Add the <xref:System.Text.Json.Serialization.JsonIgnoreAttribute> attribute:

  ```csharp
  public class MyPoco
  {
      public int Value { get; set; }

      [JsonIgnore]
      public NestedValue Unsupported { get; set; }
  }
  ```

## Affected APIs

- <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=fullName>

---
title: "Breaking change: In-box BinaryFormatter implementation removed and always throws"
description: Learn about the .NET 9 breaking change in serialization where the in-box BinaryFormatter implementation was removed and always throws exceptions.
ms.date: 08/06/2024
ms.topic: concept-article
---
# In-box BinaryFormatter implementation removed and always throws

The "in box" <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> implementation now throws exceptions at run time in all cases. This is the final stage of the [BinaryFormatter obsoletion plan](https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md).

## Previous behavior

You could construct a <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> instance and use it to serialize and deserialize payloads.

## New behavior

Starting in .NET 9, the in-box <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> implementation throws exceptions on use, even with the settings that previously enabled its use. Those settings are also removed.

## Version introduced

.NET 9 Preview 6

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

`BinaryFormatter` is an insecure format and the cause of many security bugs. Removing it from the framework increases the overall safety of .NET.

## Recommended action

If your code uses `BinaryFormatter`, you should select a new serialization format and migrate your code.

If you judge the risk of `BinaryFormatter` acceptable for your use cases and you're committed to using a class that can't be made secure, you'll still be able to use `BinaryFormatter` through a separate, unsupported NuGet package.

For more information, including guidance on alternative serializers, see the [BinaryFormatter migration guide](../../../../standard/serialization/binaryformatter-migration-guide/index.md).

## Affected APIs

- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=fullName>

## See also

- [Announcement: BinaryFormatter is being removed in .NET 9](https://github.com/dotnet/runtime/issues/98245)
- [BinaryFormatter disabled across most project types (.NET 8)](../8.0/binaryformatter-disabled.md)
- [BinaryFormatter serialization APIs produce compiler errors (.NET 7)](../7.0/binaryformatter-apis-produce-errors.md)
- [SerializationFormat.Binary is obsolete (.NET 7)](../7.0/serializationformat-binary.md)
- [BinaryFormatter serialization methods are obsolete (.NET 5)](../5.0/binaryformatter-serialization-obsolete.md)

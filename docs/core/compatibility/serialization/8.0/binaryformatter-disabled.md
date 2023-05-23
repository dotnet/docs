---
title: "Breaking change: BinaryFormatter disabled across most project types"
description: Learn about the .NET 7 breaking change in serialization where serialize and deserialize methods on BinaryFormatter now through an exception at run time.
ms.date: 05/01/2023
---
# BinaryFormatter disabled across most project types

The <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType> and <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType> methods now through a <xref:System.NotSupportedException> at run time across nearly all project types, including console applications.

## Previous behavior

In .NET 7, the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType> and <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType> methods were marked obsolete and raised an error at compile time. However, if your application suppressed the obsoletion, it could still call the methods and they functioned properly in most project types (excluding ASP.NET, WASM, and MAUI). For example, the APIs functioned correctly in a console app.

## New behavior

Starting in .NET 8, the affected methods throw a <xref:System.NotSupportedException> at run time across all project types except Windows Forms and WPF. The APIs continue to remain obsolete (as error) across all project types, including Windows Forms and WPF.

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This run-time change is the next stage of the [BinaryFormatter obsoletion plan](https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md), in which <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> will eventually be removed from .NET.

## Recommended action

**The best course of action is to migrate away from `BinaryFormatter` due to its security and reliability flaws.**

However, should you need to continue using `BinaryFormatter`, you can set a compatibility switch in your project file to re-enable `BinaryFormatter` functionality. For more information, see the [Recommended action](../7.0/binaryformatter-apis-produce-errors.md#recommended-action) section of the .NET 7 breaking change notification. That compatibility switch continues to be honored in .NET 8.

## Affected APIs

- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)?displayProperty=fullName>

## See also

- [BinaryFormatter serialization methods are obsolete (.NET 5)](../5.0/binaryformatter-serialization-obsolete.md)
- [SerializationFormat.Binary is obsolete (.NET 7)](../7.0/serializationformat-binary.md)
- [BinaryFormatter serialization APIs produce compiler errors (.NET 7)](../7.0/binaryformatter-apis-produce-errors.md)

---
title: Framework Libraries
description: Learn how .NET libraries provide implementations for many general and app-specific types, algorithms, and utility functionality.
author: richlander
ms.date: 10/06/2021
ms.assetid: 7b77b6c1-8367-4602-bff3-91e4c05ac643
---
# Framework libraries

.NET has an expansive standard set of class libraries, referred to as either the base class libraries (core set) or framework class libraries (complete set). These libraries provide implementations for many general and app-specific types, algorithms, and utility functionality. Both commercial and community libraries build on top of the framework class libraries, providing easy to use, off-the-shelf libraries for a wide set of computing tasks.

A subset of these libraries are provided with each .NET implementation. Base class library (BCL) APIs are expected with any .NET implementation, both because developers will want them and because popular libraries will need them to run. App-specific libraries above the BCL, such as ASP.NET, will not be available on all .NET implementations.

## Base class library

The BCL provides the most foundational types and utility functionality and is the base of all other .NET class libraries. The BCL aims to provide general implementations without bias to any workload. Performance is an important consideration, since apps might prefer a particular policy, such as low-latency to high-throughput or low-memory to low-CPU usage. The BCL is intended to be high-performance generally, and take a middle-ground approach according to these various performance concerns. For most apps, this approach has been quite successful.

## Primitives and other basic types

.NET includes a set of basic types that are used (to varying degrees) in all programs. These types contain data, such as numbers, strings, bytes, and arbitrary objects. The C# language includes keywords for these types. A sample set of these types is listed below, with the matching C# keywords.

| Type | C# keyword | Description |
| - | - | - |
| <xref:System.Object?displayProperty=nameWithType> | [object](../csharp/language-reference/builtin-types/reference-types.md#the-object-type) | The ultimate base class in the CLR type system. It is the root of the type hierarchy. |
| <xref:System.Int16?displayProperty=nameWithType> | [short](../csharp/language-reference/builtin-types/integral-numeric-types.md) | A 16-bit signed integer type. The unsigned <xref:System.UInt16> also exists. |
| <xref:System.Int32?displayProperty=nameWithType> | [int](../csharp/language-reference/builtin-types/integral-numeric-types.md) | A 32-bit signed integer type. The unsigned [UInt32](../csharp/language-reference/builtin-types/integral-numeric-types.md) also exists. |
| <xref:System.Single?displayProperty=nameWithType> | [float](../csharp/language-reference/builtin-types/floating-point-numeric-types.md) | A 32-bit floating-point type. |
| <xref:System.Decimal?displayProperty=nameWithType> | [decimal](../csharp/language-reference/builtin-types/floating-point-numeric-types.md) | A 128-bit decimal type. |
| <xref:System.Byte?displayProperty=nameWithType> | [byte](../csharp/language-reference/builtin-types/integral-numeric-types.md) | An unsigned 8-bit integer that represents a byte of memory. |
| <xref:System.Boolean?displayProperty=nameWithType> | [bool](../csharp/language-reference/builtin-types/bool.md) | A Boolean type that represents `true` or `false`. |
| <xref:System.Char?displayProperty=nameWithType> | [char](../csharp/language-reference/builtin-types/char.md) | A 16-bit numeric type that represents a Unicode character. |
| <xref:System.String?displayProperty=nameWithType> | [string](../csharp/language-reference/builtin-types/reference-types.md#the-string-type) | Represents a series of characters. Different than a `char[]`, but enables indexing into each individual `char` in the `string`. |

## Data structures

.NET includes a set of data structures that are the workhorses of many .NET apps. These are mostly collections, but also include other types.

* <xref:System.Array> - Represents an array of strongly typed objects that can be accessed by index. Has a fixed size, per its construction.
* <xref:System.Collections.Generic.List%601> - Represents a strongly typed list of objects that can be accessed by index. Is automatically resized as needed.
* <xref:System.Collections.Generic.Dictionary%602> - Represents a collection of values that are indexed by a key. Values can be accessed via key. Is automatically resized as needed.
* <xref:System.Uri> - Provides an object representation of a uniform resource identifier (URI) and easy access to the parts of the URI.
* <xref:System.DateTime> - Represents an instant in time, typically expressed as a date and time of day.

## Utility APIs

.NET includes a set of utility APIs that provide functionality for many important tasks.

* <xref:System.Net.Http.HttpClient> - An API for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
* <xref:System.Xml.Linq.XDocument> - An API for loading and querying XML documents with LINQ.
* <xref:System.IO.StreamReader> - An API for reading files.
* <xref:System.IO.StreamWriter> - An API for writing files.

## App-Model APIs

There are many app-models that can be used with .NET, for example:

* [ASP.NET](https://dotnet.microsoft.com/apps/aspnet) - A web framework for building Web sites and services. Supported on Windows, Linux, and macOS (depends on ASP.NET version).
* [Xamarin](https://dotnet.microsoft.com/apps/xamarin) - An app platform for building Android and iOS apps with .NET and C#. Supported on Windows and macOS.
* [Windows Desktop](https://www.nuget.org/packages/Microsoft.WindowsDesktop.App.Ref/) - Includes Windows Presentation Foundation (WPF) and Windows Forms.

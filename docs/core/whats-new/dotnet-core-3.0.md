---
title: What's new in .NET Core 3.0
description: Learn about the new features found in .NET Core 3.0.
dev_langs: 
  - "csharp"
  - "vb"
author: thraka
ms.author: adegeo
ms.date: 11/XX/2018
---

# What's new in .NET Core 3.0 (Preview 1)

This article describes what is new in .NET Core 3.0 (preview 1). One of the biggest enhancements is support for Windows desktop applications. By utilizing a .NET Core 3.0 Desktop Pack, you can port your Windows Forms and Windows Presentation Foundation based applications. To be clear, the Desktop Packs are only supported on Windows. See below for more information.

.NET Core 3.0 supports C# 8.0, F# 5.0, and Visual Basic.NET 16.0.

Download the latest preview release of .NET Core 3.0 at [http://LINK].

## .NET Standard 2.1

With .NET Core 3.0 comes support for .NET Standard 2.1. For more information about .NET Standard, see [LINK].

## Tooling

The .NET Core 3.0 SDK (v3.0.0000) tooling includes the following changes:

## Deployment

## Build


## Desktop Packs

## Built-in JSON support

JSON is an essential part of virtually all modern .NET applications. However, .NET has never had a good built-in way to work with JSON. Microsoft has relied on the amazing [Json.NET](LINK) library, which will continue to work with .NET Core. The [Json.NET](LINK) library uses the .NET String type as the base datatype, which is UTF-16 encoded strings. In .NET Core 2.1, new high performance memory access APIs were added, such as `Span<T>` and `Memory<T>`. Using these new types, new APIs have been added that make it possible to parse JSON with much less memory, based on UTF-8 strings. Given that a lot of JSON used in protocol communication (such as HTTP) is based on UTF-8, you will avoid transcoding UTF-8 into UTF-16 when using the built-in .NET Core 3.0 JSON parser.

The new JSON types live in the `System.Text.Json` namespace.

```csharp
SAMPLE
```

## API changes

### SerialPort

.NET Core 3.0 now supports <xref:System.IO.Ports.SerialPort?displayProperty=nameWithType> on Linux.

Previously, .NET Core only supported using the `SerialPort` type on Windows.

### MetadataLoadContext

A new type has been introduced, `MetadataLoadContext`, that enables reading assembly metadata without affecting the caller's application domain. This new type is similar to `AssemblyLoadContext`, but is not based on it. `MetadataLoadContext` returns `Assembly` objects, allowing you to use the familiar reflection-based API. However, execution-orientated APIs, such as `MethodBase.Invoke` are not allowed and will throw `InvalidOperationException`.

You can use `MetadataLoadContext` to inspect APIs in a completely isolated manner. 

For more information, see the [].NET Core 3.0 announcement][announcement].

## See also

* [What's new in .NET Core](index.md)  
* [New features in EF Core 3.0](/ef/core/what-is-new/...ef-core-3.0)  
* [What's new in ASP.NET Core 3.0](/aspnet/core/...aspnetcore-3.0)

[announcement]: http://LINK

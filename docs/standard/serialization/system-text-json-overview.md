---
title: "Serialize and deserialize JSON using C# - .NET"
description: This overview describes the System.Text.Json namespace functionality for serializing to and deserializing from JSON in .NET.
ms.date: "01/10/2020"
no-loc: [System.Text.Json, Newtonsoft.Json]
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# JSON serialization and deserialization (marshalling and unmarshalling) in .NET - overview

The `System.Text.Json` namespace provides functionality for serializing to and deserializing from JavaScript Object Notation (JSON).

The library design emphasizes high performance and low memory allocation over an extensive feature set. Built-in UTF-8 support optimizes the process of reading and writing JSON text encoded as UTF-8, which is the most prevalent encoding for data on the web and files on disk.

The library also provides classes for working with an in-memory document object model (DOM). This feature enables random read-only access of the elements in a JSON file or string.

## How to get the library

* The library is built-in as part of the [.NET Core 3.0](https://aka.ms/netcore3download) shared framework.
* For other target frameworks, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:
  * .NET Standard 2.0 and later versions
  * .NET Framework 4.7.2 and later versions
  * .NET Core 2.0, 2.1, and 2.2

## Additional resources

* [How to use the library](system-text-json-how-to.md)
* [How to migrate from Newtonsoft.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [How to write converters](system-text-json-converters-how-to.md)
* [System.Text.Json source code](https://github.com/dotnet/runtime/tree/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
<!-- * [Roadmap](https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/roadmap/README.md)-->

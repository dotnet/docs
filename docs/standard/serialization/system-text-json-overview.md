---
title: "JSON serialization in .NET"
ms.date: "09/02/2019"
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.assetid: 4d1111c0-9447-4231-a997-96a2b74b3453
---

# JSON serialization in .NET

The `System.Text.Json` namespace provides functionality for serializing to and from JavaScript Object Notation (JSON).

The library design emphasizes high performance and low memory allocation over an extensive feature set. Built-in UTF-8 support optimizes the process of reading and writing JSON text encoded as UTF-8, which is the most prevalent encoding for data on the web and files on disk.

The library also provides classes for working with an in-memory document object model (DOM). This feature enables random read-only access of the elements in a JSON file. 

## How to get the library

* The library is built-in as part of the .NET Core 3.0 shared framework.
* For other target frameworks, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:
  * .NET Standard 2.0
  * .NET Framework 4.61
  * .NET Core 2.x

## Additional resources

* [How to use the library](system-text-json-how-to.md)
* [Source code](https://github.com/dotnet/corefx/tree/master/src/System.Text.Json)
* [API reference](xref:System.Text.Json)
* [Roadmap](https://github.com/dotnet/corefx/blob/master/src/System.Text.Json/roadmap/README.md)
* [GitHub issue with discussion about the development of System.Text.Json](https://github.com/dotnet/corefx/issues/33115)

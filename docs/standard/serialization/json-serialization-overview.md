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

The <xref:System.Text.Json> namespace provides functionality for serializing to and from JavaScript Object Notation (JSON). The library design emphasizes high performance and low memory allocation over an extensive feature set. Built-in UTF-8 support  speeds up the process of reading and writing JSON text encoded as UTF-8.

You can also do random read-only access of the elements in a JSON file. The library provides classes for working with an in-memory document object model (DOM).

## How to get the library

* For apps and libraries that target .NET Core 3.0, `System.Text.Json` is included in the shared framework.
* For other target frameworks, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package:
  * .NET Standard
  * .NET Framework
  * .NET Core 2.x

## Additional resources

* [How to use the library](json-serialization-how-to.md)
* [Source code](https://github.com/dotnet/corefx/tree/master/src/System.Text.Json)
* [Roadmap](https://github.com/dotnet/corefx/blob/master/src/System.Text.Json/roadmap/README.md)
* [GitHub issue with discussion about development of System.Text.Json](https://github.com/dotnet/corefx/issues/33115)


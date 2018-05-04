---
title: What's new in .NET Core 
description: Learn about the new features found in .NET Core.
author: rpetrusha
ms.author: ronpet
ms.date: 05/07/2018
---
# What's new in .NET Core

The most recent release of .NET Core is .NET Core 2.1. .NET Core 2.1 includes enhancements and new features in the following areas:

- [Tooling](#tooling)


- [Language support](#language-support)
- [Platform improvements](#platform-improvements)
- [API changes](#api-changes-and-library-support)
- [Visual Studio integration](#visual-studio-integration)
- [Documentation improvements](#documentation-improvements)

For information on new features and enhancements in earlier releases of .NET Core, see the following topics:

- [What's new in .NET Core 2.0](whats-new-in-core-20.md)

## Tooling

The tooling included with .NET Core 2.1 includes the following changes and enhancements:

### Build performance improvements

A major focus of .NET Core 2.1 is improving build-time performance, particularly for incremental builds. These performance improvements apply to both command-line builds using `dotnet build` and to builds in Visual Studio. Some individual areas of improvement include:

- For package asset resolution, resolving only assets used by a build rather than all assets. Improvements in package asset resolution in regular and incremental builds. Previously, all items in a package were resolved. With .NET Core 2.1, only items that are used by the build are resolved.

- Caching of assembly references.

- Use of long-running SDK build servers, which are processes that span individual `dotnet build` invocations. They eliminate the need to JIT-compile large blocks of code every time `dotnet build` is run. Build server processes can be automatically terminated with the following command:

   ```console
   dotnet buildserver shutdown
   ```







## See also
 [What's new in ASP.NET Core 2.0](/aspnet/core/aspnetcore-2.0)

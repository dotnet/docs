---
title: Building native libraries
description: How to build native libraries with Native AOT
author: agocke
ms.author: angocke
ms.date: 04/17/2024
ms.topic: concept-article
---

# Building native libraries

Publishing .NET class libraries as Native AOT allows creating libraries that can be consumed from non-.NET programming languages. The produced native library is self-contained and doesn't require a .NET runtime to be installed.

> [!NOTE]
> Only "shared libraries" (also known as DLLs on Windows) are supported. Static libraries are not officially supported and may require compiling Native AOT from source. Unloading Native AOT libraries (via `dlclose` or `FreeLibrary`, for example) is not supported.

Publishing a class library as Native AOT creates a native library that exposes methods of the class library annotated with <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> with a non-null `EntryPoint` field. For more information, see the [native library sample](https://github.com/dotnet/samples/tree/main/core/nativeaot/NativeLibrary) available in the dotnet/samples repository on GitHub.

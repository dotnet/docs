---
title: Native AOT libraries
description: How to compile native libraries with Native AOT
author: agocke
ms.author: angocke
ms.date: 04/17/2024
---

## Build native libraries

Publishing .NET class libraries as Native AOT allows creating libraries that can be consumed from non-.NET programming languages. The produced native library is self-contained and doesn't require a .NET runtime to be installed.

> [!NOTE]
> Only "shared libraries" (also known as DLLs on Windows) are supported. Static libraries may require compiling Native AOT from source and are not officially supported.

Publishing a class library as Native AOT creates a native library that exposes methods of the class library annotated with <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> with a non-null `EntryPoint` field. For more information, see the [native library sample](https://github.com/dotnet/samples/tree/main/core/nativeaot/NativeLibrary) available in the dotnet/samples repository on GitHub.

### Limitations

**Avoid** features which have process-wide effects or expect to own process-wide state. For example, `EventSourceSupport` should be disabled in production, because Event Source does not support multiple implementations running in the same process.

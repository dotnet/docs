---
title: Core.CompilationMappingAttribute Constructor (F#)
description: Core.CompilationMappingAttribute Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e297cc7f-afb4-4e6c-be81-b4acccd4d46a 
---

# Core.CompilationMappingAttribute Constructor (F#)

Creates an instance of the attribute.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
new CompilationMappingAttribute : SourceConstructFlags * int * int -> CompilationMappingAttribute
new CompilationMappingAttribute : SourceConstructFlags * int -> CompilationMappingAttribute
new CompilationMappingAttribute : SourceConstructFlags -> CompilationMappingAttribute

// Usage:
new CompilationMappingAttribute (sourceConstructFlags, variantNumber, sequenceNumber)
new CompilationMappingAttribute (sourceConstructFlags, sequenceNumber)
new CompilationMappingAttribute (sourceConstructFlags)
```

#### Parameters
*sourceConstructFlags*
Type: [SourceConstructFlags](https://msdn.microsoft.com/library/6da6a0c5-25d0-407d-8536-70182654d738)


Indicates the type of source construct.


*variantNumber*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


*sequenceNumber*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

## Return Value

A new `CompilationMappingAttribute` instance.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Core.CompilationMappingAttribute Class &#40;F&#35;&#41;](Core.CompilationMappingAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
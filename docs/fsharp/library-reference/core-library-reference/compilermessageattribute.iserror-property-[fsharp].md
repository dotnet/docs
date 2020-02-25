---
title: CompilerMessageAttribute.IsError Property (F#)
description: CompilerMessageAttribute.IsError Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e7359d02-a73a-4f95-99ac-137bf4091ac4 
---

# CompilerMessageAttribute.IsError Property (F#)

Indicates if the message should indicate a compiler error. Error numbers less than 10000 are considered reserved for use by the F# compiler and libraries.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
member this.IsError :  bool with get, set

// Usage:
compilerMessageAttribute.IsError
compilerMessageAttribute.IsError <- isError
```

#### Parameters
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.CompilerMessageAttribute Class &#40;F&#35;&#41;](Core.CompilerMessageAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
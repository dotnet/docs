---
title: Printf.kbprintf<'Result,'T> Function (F#)
description: Printf.kbprintf<'Result,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8b5e93c4-371d-414d-9fed-73fbc487b0f4
---

# Printf.kbprintf<'Result,'T> Function (F#)

Like [bprintf](https://msdn.microsoft.com/library/5448c060-a61d-4f3d-a9ec-e0cc998b4d87), but calls the specified function to generate the result. See [kprintf](https://msdn.microsoft.com/library/fa31f68e-f039-4406-b9e1-688945430124).

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
kbprintf : (unit -> 'Result) -> StringBuilder -> BuilderFormat<'T,'Result> -> 'T

// Usage:
kbprintf continuation builder format
```

#### Parameters
*continuation*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt; 'Result**


The function called after formatting to generate the format result.


*builder*
Type: **System.Text.StringBuilder**


The input StringBuilder.


*format*
Type: [BuilderFormat](https://msdn.microsoft.com/library/79f817c8-9d0c-440c-9174-d6ef1eabcaa0)**&lt;'T,'Result&gt;**


The input formatter.

## Return Value

The arguments of the formatter.

## Remarks
This function is named `PrintFormatToStringBuilderThen` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

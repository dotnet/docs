---
title: Printf.kfprintf<'Result,'T> Function (F#)
description: Printf.kfprintf<'Result,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6025c93c-ed63-4ad3-b07d-9e98521b5380
---

# Printf.kfprintf<'Result,'T> Function (F#)

Like [fprintf](https://msdn.microsoft.com/library/18f16c19-14e9-4eea-b147-cc302132c1e8), but calls the specified function to generate the result. See [kprintf](https://msdn.microsoft.com/library/fa31f68e-f039-4406-b9e1-688945430124).

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
kfprintf : (unit -> 'Result) -> TextWriter -> TextWriterFormat<'T,'Result> -> 'T

// Usage:
kfprintf continuation textWriter format
```

#### Parameters
*continuation*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt; 'Result**


The function called after formatting to generate the format result.


*textWriter*
Type: **System.IO.TextWriter**


The **System.IO.TextWriter** instance that receives the output.


*format*
Type: [TextWriterFormat](https://msdn.microsoft.com/library/869f361a-8789-4c2d-acfc-38adec848c68)**&lt;'T,'Result&gt;**


The input formatter.

## Return Value

The arguments of the formatter.

## Remarks
This function is named `PrintFormatToTextWriterThen` in the compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

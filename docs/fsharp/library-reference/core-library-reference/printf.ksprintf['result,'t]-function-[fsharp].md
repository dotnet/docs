---
title: Printf.ksprintf<'Result,'T> Function (F#)
description: Printf.ksprintf<'Result,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 337fd262-3dc9-48d4-b402-13736a473bf3
---

# Printf.ksprintf<'Result,'T> Function (F#)

Like [sprintf](https://msdn.microsoft.com/library/d66bc456-582f-48ec-8054-ca48d99d6ffd), but calls the specified function to generate the result. See [kprintf](https://msdn.microsoft.com/library/fa31f68e-f039-4406-b9e1-688945430124).

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
ksprintf : (string -> 'Result) -> StringFormat<'T,'Result> -> 'T

// Usage:
ksprintf continuation format
```

#### Parameters
*continuation*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)**-&gt; 'Result**


The function called to generate a result from the formatted string.


*format*
Type: [StringFormat](https://msdn.microsoft.com/library/d69a911f-3a25-42fa-bd51-a9c9c1102fa8)**&lt;'T,'Result&gt;**


The input formatter.

## Return Value

The arguments of the formatter.

## Remarks
This function is named `PrintFormatToStringThen` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

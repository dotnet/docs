---
title: Printf.eprintf<'T> Function (F#)
description: Printf.eprintf<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 81d9fa8b-5683-45e9-adad-cf72e912758d
---

# Printf.eprintf<'T> Function (F#)

Prints formatted output to `stderr`.

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
eprintf : TextWriterFormat<'T> -> 'T

// Usage:
eprintf format
```

#### Parameters
*format*
Type: [TextWriterFormat](https://msdn.microsoft.com/library/2080c4a5-7bdd-4a01-8e01-10b498af92de)**&lt;'T&gt;**


The input formatter.

## Return Value

The return type and arguments of the formatter.

## Remarks
This function is named `PrintFormatToError` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also
[Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

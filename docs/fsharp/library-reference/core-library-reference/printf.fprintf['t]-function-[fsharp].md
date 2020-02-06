---
title: Printf.fprintf<'T> Function (F#)
description: Printf.fprintf<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: af185428-2e98-453e-8cba-bbf6babbaae6
---

# Printf.fprintf<'T> Function (F#)

Prints to a text writer.

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
fprintf : TextWriter -> TextWriterFormat<'T> -> 'T

// Usage:
fprintf textWriter format
```

#### Parameters
*textWriter*
Type: **System.IO.TextWriter**


The TextWriter instance to print to.


*format*
Type: [TextWriterFormat](https://msdn.microsoft.com/library/2080c4a5-7bdd-4a01-8e01-10b498af92de)**&lt;'T&gt;**


The input formatter.

## Return Value

The return type and arguments of the formatter.

## Remarks
This function is named `PrintFormatToTextWriter` in compiled assemblies. If accessing the member from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

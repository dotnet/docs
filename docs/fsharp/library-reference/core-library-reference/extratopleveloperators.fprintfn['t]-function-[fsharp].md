---
title: ExtraTopLevelOperators.fprintfn<'T> Function (F#)
description: ExtraTopLevelOperators.fprintfn<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 05e4ab22-12f9-44f3-b738-d2d2a2a26915 
---

# ExtraTopLevelOperators.fprintfn<'T> Function (F#)

The fprintfn prints to a file using the given format, and add a newline.

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
fprintfn : TextWriter -> TextWriterFormat<'T> -> 'T

// Usage:
fprintfn textWriter format
```

#### Parameters
*textWriter*
Type: **System.IO.TextWriter**


*format*
Type: [TextWriterFormat](https://msdn.microsoft.com/library/2080c4a5-7bdd-4a01-8e01-10b498af92de)**&lt;'T&gt;**

## Remarks
This function is named `PrintFormatLineToTextWriter` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `fprintfn` to print a listing of the contents of a directory to a specified file, `directorylisting.txt`.

[!code-fsharp[Main](snippets/fscorelib2/snippet5.fs)]
[!code-fsharp[Main](snippets/fscorelib2/snippet6.fs)]

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
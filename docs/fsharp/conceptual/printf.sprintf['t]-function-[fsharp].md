---
title: Printf.sprintf<'T> Function (F#)
description: Printf.sprintf<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0727bac3-5b08-49a0-9ee5-cce19d679e60
---

# Printf.sprintf<'T> Function (F#)

Prints to a string via an internal string buffer and returns the result as a string. Helper printers must return strings.

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
sprintf : StringFormat<'T> -> 'T

// Usage:
sprintf format
```

#### Parameters
*format*
Type: [StringFormat](https://msdn.microsoft.com/library/4226a2e7-9ebc-466f-8547-da79f0b05cd1)**&lt;'T&gt;**


The input formatter.

## Return Value

The formatted string.

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

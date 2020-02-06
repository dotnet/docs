---
title: ExtraTopLevelOperators.sprintf<'T> Function (F#)
description: ExtraTopLevelOperators.sprintf<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 758b851a-9b80-4d3d-bc2c-c6f6298e33e1 
---

# ExtraTopLevelOperators.sprintf<'T> Function (F#)

The sprintf function prints to a string using the given format.

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

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

## Remarks
This function is named `PrintFormatToString` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fscorelib2/snippet10.fs)]

```
Formatted string with value 109...
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
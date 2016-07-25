---
title: ExtraTopLevelOperators.int8<^T> Function (F#)
description: ExtraTopLevelOperators.int8<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dbb7565f-95ef-4e92-a6a6-07fa2f9eda58 
---

# ExtraTopLevelOperators.int8<^T> Function (F#)

Converts the argument to signed byte. This is a direct conversion for all primitive numeric types. For strings, the input is converted using `System.SByte.Parse(System.String)` with `System.Globalization.CultureInfo.InvariantCulture` settings. Otherwise the operation requires and invokes a `ToSByte` method on the input type

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
int8 : ^T -> sbyte (requires ^T with static member op_Explicit)

// Usage:
int8 value
```

#### Parameters
*value*
Type: **^T**


The value to convert.

## Return Value

The converted value of type [sbyte](https://msdn.microsoft.com/library/fbc28b7f-2dbf-4361-acb3-830886820068).

## Remarks
This function is named `ToSByte` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
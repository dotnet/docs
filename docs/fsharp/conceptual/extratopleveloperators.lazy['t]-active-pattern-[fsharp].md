---
title: ExtraTopLevelOperators.Lazy<'T> Active Pattern (F#)
description: ExtraTopLevelOperators.Lazy<'T> Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fa742165-33da-49a2-b1a7-88469903ba05 
---

# ExtraTopLevelOperators.Lazy<'T> Active Pattern (F#)

An active pattern to force the execution of values of type [Lazy](https://msdn.microsoft.com/library/b29d0af5-6efb-4a55-a278-2662a4ecc489).

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |Lazy| ) : Lazy<'T> -> 'T
```

#### Parameters
*input*
Type: [Lazy](https://msdn.microsoft.com/library/b29d0af5-6efb-4a55-a278-2662a4ecc489)**&lt;'T&gt;**

## Remarks
This function is named `LazyPattern` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fscorelib2/snippet8.fs)]

**Output**

```
10 factorial is 3628800
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
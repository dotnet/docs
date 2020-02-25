---
title: Option.isSome<'T> Function (F#)
description: Option.isSome<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 60e4c027-f76b-4c8f-9a42-9ea4aa342323
---

# Option.isSome<'T> Function (F#)

Returns `true` if the option is not `None`.

**Namespace/Module Path:** Microsoft.FSharp.Core.Option

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
isSome : 'T option -> bool

// Usage:
isSome option
```

#### Parameters
*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.

## Return Value

`true` if the option is not `None`.

## Remarks
This function is named `IsSome` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

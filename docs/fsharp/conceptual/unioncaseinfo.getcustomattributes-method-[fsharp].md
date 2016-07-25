---
title: UnionCaseInfo.GetCustomAttributes Method (F#)
description: UnionCaseInfo.GetCustomAttributes Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a7dd67ce-d68c-495a-ba15-3f6f4bf76a1c 
---

# UnionCaseInfo.GetCustomAttributes Method (F#)

Returns the custom attributes associated with the case matching the given attribute type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
member this.GetCustomAttributes : Type -> obj []
member this.GetCustomAttributes : unit -> obj []

// Usage:
unionCaseInfo.GetCustomAttributes (attributeType)
unionCaseInfo.GetCustomAttributes ()
```

#### Parameters
*attributeType*
Type: **System.Type**


The type of attributes to return.

## Return Value

An array of custom attributes.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.UnionCaseInfo Class &#40;F&#35;&#41;](Reflection.UnionCaseInfo-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)
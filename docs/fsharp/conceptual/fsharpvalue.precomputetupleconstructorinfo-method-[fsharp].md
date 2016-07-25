---
title: FSharpValue.PreComputeTupleConstructorInfo Method (F#)
description: FSharpValue.PreComputeTupleConstructorInfo Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cb7823f0-2372-4a55-b7d8-995214a26863 
---

# FSharpValue.PreComputeTupleConstructorInfo Method (F#)

Gets a method that constructs objects of the given tuple type. For small tuples, no additional type will be returned.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeTupleConstructorInfo : Type -> ConstructorInfo * Type option

// Usage:
FSharpValue.PreComputeTupleConstructorInfo (tupleType)
```

#### Parameters
*tupleType*
Type: **System.Type**


The input tuple type.

## Return Value

The description of the tuple type constructor and an optional extra type for large tuples.

## Remarks
For large tuples, an additional type is returned indicating that a nested encoding has been used for the tuple type. In this case the suffix portion of the tuple type has the given type and an object of this type must be created and passed as the last argument to the `System.Reflection.ConstructorInfo`. A recursive call to `PreComputeTupleConstructorInfo` can be used to determine the constructor for that the suffix type.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)
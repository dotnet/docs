---
title: Core.StructuralEqualityAttribute Class (F#)
description: Core.StructuralEqualityAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9855e16e-6808-4bb5-afa5-411a4b6dc92b 
---

# Core.StructuralEqualityAttribute Class (F#)

Adding this attribute to a record, union or struct type confirms the automatic generation of overrides for `System.Object.Equals(System.Object)` and `System.Object.GetHashCode` for the type.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type StructuralEqualityAttribute =
class
new StructuralEqualityAttribute : unit -> StructuralEqualityAttribute
end
```

## Remarks
You can also use the short form of the name, `StructuralEquality`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/d8995048-26bc-4b14-a260-f89191a8c28b)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
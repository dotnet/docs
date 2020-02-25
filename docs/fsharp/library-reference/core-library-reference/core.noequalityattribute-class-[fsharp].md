---
title: Core.NoEqualityAttribute Class (F#)
description: Core.NoEqualityAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 19212f07-c79a-431c-9b58-f748674d5154 
---

# Core.NoEqualityAttribute Class (F#)

Adding this attribute to a type indicates it is a type where equality is an abnormal operation. This means that the type does not satisfy the F# equality constraint. Within the bounds of the F# type system, this helps ensure that the F# generic equality function is not instantiated directly at this type. The attribute and checking does not constrain the use of comparison with base or child types of this type.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Interface ||| AttributeTargets.Delegate ||| AttributeTargets.Struct ||| AttributeTargets.Enum, AllowMultiple = false)>]
[<Sealed>]
type NoEqualityAttribute =
class
new NoEqualityAttribute : unit -> NoEqualityAttribute
end
```

## Remarks
You can also use the short form of the name, `NoEquality`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/72c10252-c40b-4644-b07b-e604f30b9699)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
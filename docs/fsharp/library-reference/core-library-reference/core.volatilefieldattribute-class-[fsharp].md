---
title: Core.VolatileFieldAttribute Class (F#)
description: Core.VolatileFieldAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e4926a0f-ce12-4183-9150-c3937123cf0e 
---

# Core.VolatileFieldAttribute Class (F#)

Adding this attribute to an F# mutable binding causes the `volatile` prefix to be used for all accesses to the field.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Field, AllowMultiple = false)>]
[<Sealed>]
type VolatileFieldAttribute =
class
new VolatileFieldAttribute : unit -> VolatileFieldAttribute
end
```

## Remarks
You can also use the short form of the name, `VolatileField`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/de9cffb9-6a8a-4052-b47e-b7ef4fec46b5)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
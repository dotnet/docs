---
title: System.Lazy<'T> Class (F#)
description: System.Lazy<'T> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 398d261a-ef77-48d6-8a2d-617192c3c505 
---

# System.Lazy<'T> Class (F#)

Encapsulates a lazily computed value.

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AllowNullLiteral>]
type Lazy<'T> =
class
member this.IsValueCreated :  bool
member this.Value :  'T
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Lazy`.


## Instance Members


|Member|Description|
|------|-----------|
|[IsValueCreated](https://msdn.microsoft.com/library/1e192d02-b3ad-4903-9d5b-e6af1d884c70)|Is true if the value is ready to be accessed.|
|[Value](https://msdn.microsoft.com/library/3ce0a337-a960-4464-bc19-7e70bf37d4db)|The value contained in the Lazy.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)
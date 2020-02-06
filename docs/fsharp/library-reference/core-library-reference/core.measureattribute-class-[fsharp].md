---
title: Core.MeasureAttribute Class (F#)
description: Core.MeasureAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 714dc8fd-8cd3-4186-bc1d-3c3c8f7796cc 
---

# Core.MeasureAttribute Class (F#)

Adding this attribute to a type causes it to be interpreted as a unit of measure. This may only be used under very limited conditions.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.GenericParameter ||| AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type MeasureAttribute =
class
new MeasureAttribute : unit -> MeasureAttribute
end
```

## Remarks
You can also use the short form of the name, `Measure`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/1c633a8a-8ea3-4d5f-babe-a7b5f6399549)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
---
title: Core.CustomComparisonAttribute Class (F#)
description: Core.CustomComparisonAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2b8dbf60-c61b-4bc6-9028-9b0b891e8204 
---

# Core.CustomComparisonAttribute Class (F#)

Adding this attribute to a type indicates it is a type with a user-defined implementation of comparison.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Struct, AllowMultiple = false)>]
[<Sealed>]
type CustomComparisonAttribute =
class
new CustomComparisonAttribute : unit -> CustomComparisonAttribute
end
```

## Remarks
You can also use the short form of the name, `CustomComparison`.

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/223b18a8-ed4c-4846-90f4-bc209d76adcf)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
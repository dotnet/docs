---
title: Core.MeasureAnnotatedAbbreviationAttribute Class (F#)
description: Core.MeasureAnnotatedAbbreviationAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 077643e2-6c3e-4d97-8854-286764bd7498 
---

# Core.MeasureAnnotatedAbbreviationAttribute Class (F#)

Adding this attribute to a type causes it to be interpreted as a refined type, currently limited to measure-parameterized types. This may only be used under very limited conditions.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type MeasureAnnotatedAbbreviationAttribute =
class
new MeasureAnnotatedAbbreviationAttribute : unit -> MeasureAnnotatedAbbreviationAttribute
end
```

## Remarks
You can also use the short form of the name, `MeasureAnnotatedAbbreviation`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/78abf1c9-b9e7-4faf-b41b-690872d91787)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
---
title: Core.StructuralComparisonAttribute Class (F#)
description: Core.StructuralComparisonAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 29be7dca-1585-414a-b2e9-2178b4f9a55d 
---

# Core.StructuralComparisonAttribute Class (F#)

Adding this attribute to a record, union, exception, or structure type confirms the automatic generation of implementations for `System.IComparable` for the type.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type StructuralComparisonAttribute =
class
new StructuralComparisonAttribute : unit -> StructuralComparisonAttribute
end
```

## Remarks
You can also use the short form of the name, `StructuralComparison`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/a50dbe83-811a-486f-987e-236e4fd18cda)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
---
title: Core.Ref<'T> Record (F#)
description: Core.Ref<'T> Record (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cd36b2ab-a426-4ffe-bc62-9e1d70c61fda 
---

# Core.Ref<'T> Record (F#)

The type of mutable references. Use the operators  `:=` and `!` to get and set values of this type.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<StructuralEquality>]
[<StructuralComparison>]
type Ref<'T> =
{ mutable contents : 'T }
with
interface IStructuralEquatable
interface IComparable
interface IComparable
interface IStructuralComparable
member this.Value :  'T with get, set
end
```

## Remarks
For an overview of reference cells, see [Reference Cells &#40;F&#35;&#41;](Reference-Cells-%5BFSharp%5D.md).

This type is named `FSharpRef` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Fields


|Field|Description|
|-----|-----------|
|*contents*|**Type**: **'T**<br /><br />The current value of the reference cell.|

## Instance Members


|Member|Description|
|------|-----------|
|[Value](https://msdn.microsoft.com/library/4f7eac48-f3c9-4dd5-ab06-5f6cde41f56c)|The current value of the reference cell|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
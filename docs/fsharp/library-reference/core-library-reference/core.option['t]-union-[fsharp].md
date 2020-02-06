---
title: Core.Option<'T> Union (F#)
description: Core.Option<'T> Union (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 160b9e4e-55ab-40fa-b4cf-5148889842cd 
---

# Core.Option<'T> Union (F#)

Specifies the type of optional values, which you use when there might or might not be a value.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<DefaultAugmentation(false)>]
[<StructuralEquality>]
[<StructuralComparison>]
type Option<'T> =
| None
| Some of 'T
with
interface IStructuralEquatable
interface IComparable
interface IComparable
interface IStructuralComparable
static member Some : 'T -> 'T option
member this.IsNone :  bool
member this.IsSome :  bool
static member None :  'T option
member this.Value :  'T
end
```

## Remarks
Use the constructors `Some` and `None`to create values of this type. Use the values in the [Option module](https://msdn.microsoft.com/library/e615e4d3-bbbb-49ba-addc-6061ea2e2f4c) to manipulate values of this type, or pattern match against the values directly. `None` values appear as the value `null` to other .NET Framework languages. Instance methods of this type appear as static methods to other .NET Framework languages because of the use of `null` as a value representation.

For an overview of options, see [Options &#40;F&#35;&#41;](Options-%5BFSharp%5D.md).

This type is named `FSharpOption` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Instance Members


|Member|Description|
|------|-----------|
|[IsNone](https://msdn.microsoft.com/library/f08532ca-1716-4f60-ae59-8ef6256df234)|Returns **true** if the option is a **None** value.|
|[IsSome](https://msdn.microsoft.com/library/c5088d51-c5d7-425f-a77f-12c379bb356f)|Returns **true** if the option is a **Some** value.|
|[Value](https://msdn.microsoft.com/library/c79f68e8-11fd-45b1-a053-e8fc38b56df7)|Gets the value of a **Some** option. A **NullReferenceException** is raised if the option is **None**.|

## Static Members


|Member|Description|
|------|-----------|
|[None](https://msdn.microsoft.com/library/83ef260a-aa33-4e6f-aee6-b9bf0a461476)|Creates an option value that is a **None** value.|
|[Some](https://msdn.microsoft.com/library/12f048d2-e293-4596-accb-de036ecd63fc)|Creates an option value that is a **Some** value.|

## Union Cases


|Case|Description|
|----|-----------|
|`None`|Specifies that there is no value.|
|`Some of 'T`|Contains the value, when there is a value.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
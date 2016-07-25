---
title: Collections.List<'T> Union (F#)
description: Collections.List<'T> Union (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 69576cb7-5556-4c88-806b-edd0d52b40e6 
---

# Collections.List<'T> Union (F#)

The type of immutable singly-linked lists.

**Namespace/Module Path**: Microsoft.FSharp.Collections

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<DefaultAugmentation(false)>]
[<StructuralEquality>]
[<StructuralComparison>]
type List<'T> =
| ( [] )
| ( :: ) of 'T * 'T list
with
interface IStructuralEquatable
interface IComparable
interface IComparable
interface IStructuralComparable
interface IEnumerable
interface IEnumerable
static member List.Cons : 'T * 'T list -> 'T list
static member List.Empty :  'T list
member this.Head :  'T
member this.IsEmpty :  bool
member this.Item (int) :  'T
member this.Length :  int
member this.Tail :  'T list
end
```

## Remarks
Use the constructors `[]` and `::` (infix) to create values of this type, or the notation `[1;2;3]`. Use the values in the `List` module to manipulate values of this type, or pattern match against the values directly.

This type is named `FSharpList` in the .NET assembly. If accessing the type from a .NET language other than F#, or through reflection, use this name.


## Instance Members

|Member|Description|
|------|-----------|
|[Head](https://msdn.microsoft.com/library/5f9414fd-6bdb-470a-8b72-40016db30740)|Gets the first element of the list.|
|[IsEmpty](https://msdn.microsoft.com/library/3ba087b2-2fc2-406d-b10a-cff6a19322da)|Gets a value indicating if the list contains no entries.|
|[Item](https://msdn.microsoft.com/library/bdb2553a-0e54-4ff8-baed-ab1aac8f5dae)|Gets the element of the list at the given position.|
|[Length](https://msdn.microsoft.com/library/25f715c8-9daa-4c4d-a6c7-26772f9dab4d)|Gets the number of items contained in the list.|
|[Tail](https://msdn.microsoft.com/library/2a6f8eb9-dc32-41aa-8b62-2baffaface91)|Gets the tail of the list, which is a list containing all the elements of the list, excluding the first element.|

## Static Members

|Member|Description|
|------|-----------|
|[Cons](https://msdn.microsoft.com/library/73ae40fd-3f79-4437-b2c5-5b1570e73713)|Returns a list with the first argument as its first element and the second argument as its subsequent elements.|
|[Empty](https://msdn.microsoft.com/library/44406ecb-1918-4d32-b32a-ca1f69840386)|Returns an empty list of a particular type.|

## Union Cases

|Case|Description|
|----|-----------|
|( :: ) of 'T &#42; 'T list|The cons operator.|
|( [] )|The empty list.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)
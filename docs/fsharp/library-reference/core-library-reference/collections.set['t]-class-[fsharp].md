---
title: Collections.Set<'T> Class (F#)
description: Collections.Set<'T> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 994e4d8f-4f70-4b88-9097-5e9f69da254f 
---

# Collections.Set<'T> Class (F#)

Immutable sets based on binary trees, where comparison is the F# structural comparison function, potentially using implementations of the [`System.IComparable`](https://msdn.microsoft.com/library/system.icomparable.aspx) interface on key values.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
[<Sealed>]
type Set<[<EqualityConditionalOnAttribute>] 'T (requires comparison)> =
class
interface IComparable
interface IEnumerable
interface IEnumerable
interface ICollection
new Set : seq<'T> -> Set<'T>
member this.Add : 'T -> Set<'T>
member this.Contains : 'T -> bool
member this.IsProperSubsetOf : Set<'T> -> bool
member this.IsProperSupersetOf : Set<'T> -> bool
member this.IsSubsetOf : Set<'T> -> bool
member this.IsSupersetOf : Set<'T> -> bool
member this.Remove : 'T -> Set<'T>
member this.Count :  int
member this.IsEmpty :  bool
member this.MaximumElement :  'T
member this.MinimumElement :  'T
static member ( + ) : Set<'T> * Set<'T> -> Set<'T>
static member ( - ) : Set<'T> * Set<'T> -> Set<'T>
end
```

## Remarks

See the Set module for further operations on sets. All members of this class are thread-safe and may be used concurrently from multiple threads.

This type is named `FSharpSet` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/384b858c-e794-4f70-865f-80160bcbdf2d)|Create a set containing elements drawn from the given sequence.|

## Instance Members


|Member|Description|
|------|-----------|
|[Add](https://msdn.microsoft.com/library/81a5d225-7c60-4243-9b4e-7162cb0e001b)|A useful shortcut for [Set.add](https://msdn.microsoft.com/library/d06ab305-1183-487c-8dc0-9076ed0b4c28). Note this operation produces a new set and does not mutate the original set. The new set will share many storage nodes with the original.|
|[Contains](https://msdn.microsoft.com/library/beb0d4f8-15a0-46cd-bb2a-0d5f7f100ddd)|A useful shortcut for [Set.contains](https://msdn.microsoft.com/library/7d616d1e-bca9-463e-b11e-88b5dc8b930b). See the Set module for further operations on sets.|
|[Count](https://msdn.microsoft.com/library/bd2f4d91-a58f-4067-a27b-13f0737d824d)|The number of elements in the set|
|[IsEmpty](https://msdn.microsoft.com/library/93451723-0b3c-4304-a263-4d04ec00eed2)|A useful shortcut for [Set.isEmpty](https://msdn.microsoft.com/library/64ddfbfd-3313-4495-9067-b614dd530aa7).|
|[IsProperSubsetOf](https://msdn.microsoft.com/library/bd0a671b-51ff-4c9e-b2fb-5089244750f5)|Evaluates to **true** if all elements of the first set are in the second, and at least one element of the second is not in the first.|
|[IsProperSupersetOf](https://msdn.microsoft.com/library/4c2a373c-8a5b-494b-94a7-004a5f1333be)|Evaluates to **true** if all elements of the second set are in the first, and at least one element of the first is not in the second.|
|[IsSubsetOf](https://msdn.microsoft.com/library/2069807c-c9fe-403f-b51c-0edc043ed796)|Evaluates to **true** if all elements of the first set are in the second.|
|[IsSupersetOf](https://msdn.microsoft.com/library/07974083-5980-4f70-bad8-52b4a287b9ee)|Evaluates to **true** if all elements of the second set are in the first.|
|[MaximumElement](https://msdn.microsoft.com/library/d7f4b139-1b41-41bf-9e23-d946d20cb512)|Returns the highest element in the set according to the ordering being used for the set.|
|[MinimumElement](https://msdn.microsoft.com/library/8b173df1-2ab8-4bbe-83a5-3e365d104bfe)|Returns the lowest element in the set according to the ordering being used for the set.|
|[Remove](https://msdn.microsoft.com/library/c2f6c66a-39c0-4aa9-b17b-127180dfe82d)|A useful shortcut for [Set.remove](https://msdn.microsoft.com/library/812a6d19-c1f0-4c57-9cbe-15d141d64ddb). Note this operation produces a new set and does not mutate the original set. The new set will share many storage nodes with the original.|

## Static Members

|Member|Description|
|------|-----------|
|[( + )](https://msdn.microsoft.com/library/ddf0fc46-185a-4f5a-9a07-30ee7a461b20)|Compute the union of the two sets.|
|[( - )](https://msdn.microsoft.com/library/25274a0f-01e0-4e11-8ca0-42f664cb5405)|Returns a new set with the elements of the second set removed from the first.|

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)
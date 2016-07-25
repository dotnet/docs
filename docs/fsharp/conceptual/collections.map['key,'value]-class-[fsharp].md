---
title: Collections.Map<'Key,'Value> Class (F#)
description: Collections.Map<'Key,'Value> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 705eb7d5-960e-4937-b28f-9581b0e29893 
---

# Collections.Map<'Key,'Value> Class (F#)

Immutable maps. Keys are ordered by F# generic comparison.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
[<Sealed>]
type Map<[<EqualityConditionalOnAttribute>] 'Key,[<ComparisonConditionalOnAttribute>] [<EqualityConditionalOnAttribute>] 'Value (requires comparison)> =
class
interface IEnumerable
interface IComparable
interface IEnumerable
interface ICollection
interface IDictionary
new Map : seq<'Key * 'Value> -> Map< 'Key, 'Value>
member this.Add : 'Key * 'Value -> Map<'Key, 'Value>
member this.ContainsKey : 'Key -> bool
member this.Remove : 'Key -> Map<'Key, 'Value>
member this.TryFind : 'Key -> 'Value option
member this.Count :  int
member this.IsEmpty :  bool
member this.Item ('Key) : 'Value
end
```

## Remarks

Maps based on generic comparison are efficient for small keys. They are not a suitable choice if keys are recursive data structures or if keys require bespoke comparison semantics. All members of this class are thread-safe and may be used concurrently from multiple threads.

This type is named `FSharpMap` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/90fe335c-fe3d-4a81-9c82-ff4aed80fe4c)|Builds a map that contains the bindings of the given **System.Collections.Generic.IEnumerable&#96;1**.|

## Instance Members

|Member|Description|
|------|-----------|
|[Add](https://msdn.microsoft.com/library/7126bb07-f521-421f-ae84-41e0321f4279)|Returns a new map with the binding added to the given map.|
|[ContainsKey](https://msdn.microsoft.com/library/02b7326c-f089-4b0d-8f6b-df8fd7aa2532)|Tests if an element is in the domain of the map.|
|[Count](https://msdn.microsoft.com/library/d5b0bf76-74e9-4c02-bca9-72234cbacf7d)|The number of bindings in the map.|
|[IsEmpty](https://msdn.microsoft.com/library/2a61a916-b6a4-461c-9c2e-dad736cb855b)|Returns true if there are no bindings in the map.|
|[Item](https://msdn.microsoft.com/library/3b7fee5c-edb6-437e-8810-8304d8048adc)|Lookup an element in the map. Raise **System.Collections.Generic.KeyNotFoundException** if no binding exists in the map.|
|[Remove](https://msdn.microsoft.com/library/91504235-d9ff-4117-bb40-7d0e11a84ae7)|Removes an element from the domain of the map. No exception is raised if the element is not present.|
|[TryFind](https://msdn.microsoft.com/library/a282a8bb-65aa-4bca-94e1-7d239ca12edc)|Lookup an element in the map, returning a **Some** value if the element is in the domain of the map and **None** if not.|

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
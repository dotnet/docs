---
title: Seq.init<'T> Function (F#)
description: Seq.init<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 624da124-7ca3-4a73-81f7-1a1de63be090
---

# Seq.init<'T> Function (F#)

Generates a new sequence which, when iterated, will return successive elements by calling the given function, up to the given count.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.init : int -> (int -> 'T) -> seq<'T>

// Usage:
Seq.init count initializer
```

#### Parameters
*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The maximum number of items to generate for the sequence.


*initializer*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T**


A function that generates an item in the sequence from a given index.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|	Thrown when count is negative.|

## Return Value
The result sequence.

## Remarks
Each element is saved after its initialization. The function is passed the index of the item being generated.

This function is named `Initialize` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Thread Safety
The returned sequence may be passed between threads safely. However, individual `IEnumerator` values generated from the returned sequence should not be accessed concurrently.

## Example

The following example demonstrates the use of `Seq.init` to create a sequence of the first five multiples of 10.

[!code-fsharp[Main](snippets/fssequences/snippet10.fs)]

```
0 10 20 30 40
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

---
title: Seq.maxBy<'T,'U> Function (F#)
description: Seq.maxBy<'T,'U> Function (F#)
ms.date: 02/26/2020
---

# Seq.maxBy<'T,'U> Function (F#)

Returns the greatest of all elements of the sequence, compared by using [Operators.max](operators.max['t]-function-[fsharp].md) on the function result.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

## Syntax

```fsharp
// Signature:
Seq.maxBy : ('T -> 'U) -> seq<'T> -> 'T (requires comparison)

// Usage:
Seq.maxBy projection source
```

#### Parameters
*projection*
Type: **'T -&gt; 'U**

A function to transform items from the input sequence into comparable keys.

*source*
Type: [seq](collections.seq['t]-type-abbreviation-[fsharp].md)**&lt;'T&gt;**

The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception)|Thrown when the input sequence is empty.|
|[ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception)|Thrown when the input sequence is null.|

## Return Value

The result sequence.

## Remarks
This function is named `MaxBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

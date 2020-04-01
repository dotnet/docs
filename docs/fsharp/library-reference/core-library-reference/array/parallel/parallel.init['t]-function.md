---
title: Parallel.init<'T> Function
description: Parallel.init<'T> Function
ms.date: 02/27/2020
---

# Parallel.init<'T> Function

Create an array given the dimension and a generator function to compute the elements.

**Namespace/Module Path:** Microsoft.FSharp.Collections.ArrayModule.Parallel

## Syntax

```fsharp
// Signature:
init : int -> (int -> 'T) -> 'T []

// Usage:
init count initializer
```

#### Parameters
*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The size of the array.

*initializer*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T**

The function that generates the elements.

## Return Value

The created array.

## Remarks
Performs the operation in parallel using `System.Threading.Tasks.Parallel.For`. The order in which the given function is applied to indices is not specified.

This function is named `Initialize` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)

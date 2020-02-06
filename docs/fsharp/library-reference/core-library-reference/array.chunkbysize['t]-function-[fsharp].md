---
title: Array.chunkBySize<'T> Function (F#)
description: Array.chunkBySize<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: erikschierboom
manager: danielfe
ms.date: 03/12/2017
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 887bba8d-ec0b-460b-bf56-661083fb2226
---

# Array.chunkBySize<'T> Function (F#)

Divides the input array into chunks of size at most `chunkSize`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.chunkBySize: chunkSize:int -> array:'T[] -> 'T[] []

// Usage:
Array.chunkBySize chunkSize array
```

#### Parameters

*chunkSize*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The maximum size of each chunk.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when `chunkSize` is not positive.|

## Return Value

The input array divided into chunks.

## Remarks

This function is named `ChunkBySize` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use Array.chunkBySize.
[!code-fsharp[Main](snippets/fsarrays/snippet75.fs)]

### Output

```
[|[|1; 2|]; [|3; 4|]; [|5; 6|]; [|7; 8|]; [|9; 10|]|]
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
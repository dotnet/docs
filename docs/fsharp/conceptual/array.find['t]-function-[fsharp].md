---
title: Array.find<'T> Function (F#)
description: Array.find<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7c9c2263-06e6-4a3f-b080-20bf3cf4ebd9 
---

# Array.find<'T> Function (F#)

Returns the first element for which the given function returns `true`. Raise [KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx) if no such element exists.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp

// Signature:
Array.find : ('T -> bool) -> 'T [] -> 'T

// Usage:
Array.find predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)

The function to test the input elements.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Exceptions
|Exception|Condition|
|---------|---------|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown if predicate does not return true for any element.|

## Return Value
The first element for which *predicate* returns `true`.

## Remarks
This function is named `Find` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following example demonstrates the use of `Array.find` and `Array.findIndex` to identify the first integer greater than 1 that is both a square and a cube.

[!code-fsharp[Main](snippets/fsarrays/snippet25.fs)]

```
The first element that is both a square and a cube is 64 and its index is 62.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

[Array.findIndex&#60;'T&#62; Function &#40;F&#35;&#41;](Array.findIndex%5B%27T%5D-Function-%5BFSharp%5D.md)
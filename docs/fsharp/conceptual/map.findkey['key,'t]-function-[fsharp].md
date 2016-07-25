---
title: Map.findKey<'Key,'T> Function (F#)
description: Map.findKey<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7d1e584b-5f97-4b92-be5e-a8df0171084c
---

# Map.findKey<'Key,'T> Function (F#)

Evaluates the function on each mapping in the collection and returns the key for the first mapping where the function returns `true`. If no such element exists, this function raises `System.Collections.Generic.KeyNotFoundException`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.findKey : ('Key -> 'T -> bool) -> Map<'Key,'T> -> 'Key (requires comparison)

// Usage:
Map.findKey predicate table
```

#### Parameters
*predicate*
Type: **'Key -&gt; 'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Exceptions
|Exception|Condition|
|----|----|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown if the key does not exist in the map.|

## Return Value

The first key for which the predicate evaluates true.

## Remarks
This function is named `FindKey` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example shows how to use Map.findKey.

[!code-fsharp[Main](snippets/fsmaps/snippet7.fs)]

**Output**

```
With value "one", found key 1.
With value "two", found key 2.
With value 9, found key 3.
With value 25, found key 5.
Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

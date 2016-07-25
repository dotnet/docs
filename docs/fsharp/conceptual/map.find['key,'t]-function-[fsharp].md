---
title: Map.find<'Key,'T> Function (F#)
description: Map.find<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a3b17fac-ce16-4798-81f2-5f208723c22f
---

# Map.find<'Key,'T> Function (F#)

Looks up an element in the map. If no binding exists in the map, raises `System.Collections.Generic.KeyNotFoundException`.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Map

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.find : 'Key -> Map<'Key,'T> -> 'T (requires comparison)

// Usage:
Map.find key table
```

#### Parameters
*key*
Type: **'Key**


The input key.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Exceptions
|Exception|Condition|
|----|----|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown when the key does not exist in the map.|

## Return Value

The value mapped to the given key.

## Remarks
This function is named `Find` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following examples shows how to use Map.filter.

[!code-fsharp[Main](snippets/fsmaps/snippet6.fs)]

**Output**

```
With key 1, found value "one".
With key 2, found value "two".
With key 3, found value 9.
With key 5, found value 25.
The given key was not present in the dictionary.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

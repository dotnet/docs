---
title: Map.fold<'Key,'T,'State> Function (F#)
description: Map.fold<'Key,'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fbe27bf5-32e1-47ec-ac1f-0bdb92846b9a
---

# Map.fold<'Key,'T,'State> Function (F#)

Folds over the bindings in the map

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.fold : ('State -> 'Key -> 'T -> 'State) -> 'State -> Map<'Key,'T> -> 'State (requires comparison)

// Usage:
Map.fold folder state table
```

#### Parameters
*folder*
Type: **'State -&gt; 'Key -&gt; 'T -&gt; 'State**


The function to update the state given the input key/value pairs.


*state*
Type: **'State**


The initial state.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Return Value

`The final state value.`

## Remarks
This function is named `Fold` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet8.fs)]

**Output**

```
Result: 6
Result: one two three
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

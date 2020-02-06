---
title: List.scanBack<'T,'State> Function (F#)
description: List.scanBack<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5aa8d78d-78e9-418c-93be-c51db42491cd 
---

# List.scanBack<'T,'State> Function (F#)

Like [`List.foldBack`](https://msdn.microsoft.com/library/b9a58e66-efe1-445f-a90c-ac9ffb9d40c7), but returns both the intermediate and final results.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.scanBack : ('T -> 'State -> 'State) -> 'T list -> 'State -> 'State list

// Usage:
List.scanBack folder list state
```

#### Parameters
*folder*
Type: **'T -&gt; 'State -&gt; 'State**


The function to update the state given the input elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.


*state*
Type: **'State**


The initial state.

## Return Value

The list of states.

## Remarks
This function is named `ScanBack` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example shows how to use `List.scanBack`, and also contrasts its behavior with [`List.scan`](https://msdn.microsoft.com/library/21f636db-885c-4a72-970e-e3841f33a1b8).

[!code-fsharp[Main](snippets/fslists/snippet61.fs)]

**Output**

```
Operations:
add 1  add 2  subtract 5
List.scan List.scanBack
10         10
11          5
13          7
8          8
Operations:
add 1  multiply by 5  square
List.scan List.scanBack
10         10
11        100
55        500
3025        501
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
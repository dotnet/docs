---
title: List.choose<'T,'U> Function (F#)
description: List.choose<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 05b8d922-bf23-4f32-bbb5-0395cc0d05b7 
---

# List.choose<'T,'U> Function (F#)

Applies the given function `f` to each element `x` of the list. Returns the list comprised of the results for each element where the function returns `Some(f(x))`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.choose : ('T -> 'U option) -> 'T list -> 'U list

// Usage:
List.choose chooser list
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The function to generate options from the elements.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The list comprising the values selected from the chooser function.

## Remarks

This function is named `Choose` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code demonstrates the use of List.choose to select capitalized words out of a list of words.

[!code-fsharp[Main](snippets/fslists/snippet25.fs)]

**Output**

```
["Rome's"; "Bob's"]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
---
title: Option.foldBack<'T,'State> Function (F#)
description: Option.foldBack<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 504f9309-9240-4eb0-b564-11be04eae3ef 
---

# Option.foldBack<'T,'State> Function (F#)

Performs the equivalent of the [List.foldBack](https://msdn.microsoft.com/library/b9a58e66-efe1-445f-a90c-ac9ffb9d40c7) operation on an option.

**Namespace/Module Path:** Microsoft.FSharp.Core.Option

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
foldBack : ('T -> 'State -> 'State) -> 'T option -> 'State -> 'State

// Usage:
foldBack folder option state
```

#### Parameters
*folder*
Type: **'T -&gt; 'State -&gt; 'State**


A function to update the state data when given a value from an option.


*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.


*state*
Type: **'State**


The initial state.



**If the option is None, it returns the initial value of state. Otherwise, it returns the updated state, the result of applying the folder function with the option value and the initial state.**
## Remarks
The expression **fold f inp s** evaluates to **match inp with None -&gt; s | Some x -&gt; f x s**.

This function is named **FoldBack** in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

**The following code illustrates the use of Option.foldBack.**
[!code-fsharp[Main](snippets/fsoptions/snippet5.fs)]
**Output**
**[1; 2; 3; 4; 5; 6; 7; 8; 9; 10][0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10]**
## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)


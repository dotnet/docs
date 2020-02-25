---
title: Option.fold<'T,'State> Function (F#)
description: Option.fold<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d97bd16a-a064-4668-9346-896b369e1c2b 
---

# Option.fold<'T,'State> Function (F#)

Evaluates the equivalent of [List.fold](https://msdn.microsoft.com/library/c272779e-bae7-4983-8d7f-16b345bb33a0) for an option.

**Namespace/Module Path**: Microsoft.FSharp.Core.Option

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
fold : ('State -> 'T -> 'State) -> 'State -> 'T option -> 'State

// Usage:
fold folder state option
```

#### Parameters
*folder*
Type: **'State -&gt; 'T -&gt; 'State**


A function to update the state data when given a value from an option.


*state*
Type: **'State**


The initial state.


*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.



**The original state if the option is None, otherwise it returns the updated state with the folder and the option value.**
## Remarks
The expression **fold f s inp** evaluates to **match inp with None -&gt; s | Some x -&gt; f s x**.

This function is named **Fold** in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

**The following code illustrates the use of Option.fold.**
[!code-fsharp[Main](snippets/fsoptions/snippet4.fs)]
**Output**
**[1; 2; 3; 4; 5; 6; 7; 8; 9; 10][0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10]Enter a number: New list: []Enter a number: 10New list: [10]Enter a number: 1New list: [1; 10]Enter a number: abcNew list: [1; 10]Enter a number: 9New list: [9; 1; 10]**
## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)


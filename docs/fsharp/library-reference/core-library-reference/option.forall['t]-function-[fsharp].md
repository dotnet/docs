---
title: Option.forall<'T> Function (F#)
description: Option.forall<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e967a6b5-e168-4051-94c8-6e047d8ea307 
---

# Option.forall<'T> Function (F#)

Evaluates the equivalent of [List.forall](https://msdn.microsoft.com/library/e11a5233-d612-40ac-833b-d5cf496900b7) for an option type.

**Namespace/Module Path**: Microsoft.FSharp.Core.Option

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
forall : ('T -> bool) -> 'T option -> bool

// Usage:
forall predicate option
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function that evaluates to a Boolean when given a value from the option type.


*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.



**true if the option is None, otherwise it returns the result of applying the predicate to the option value.**
## Remarks
The expression **forall p inp** evaluates to **match inp with None -&gt; true | Some x -&gt; p x**.

This function is named **ForAll** in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

**The following code illustrates the use of Option.forall.**
[!code-fsharp[Main](snippets/fsoptions/snippet6.fs)]
**Output**
**truetruefalsefalsetruefalse**
## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)


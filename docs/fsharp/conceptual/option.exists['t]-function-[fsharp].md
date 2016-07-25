---
title: Option.exists<'T> Function (F#)
description: Option.exists<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e20cafad-f36e-40c5-8330-bfa9420fce0f 
---

# Option.exists<'T> Function (F#)

Evaluates the equivalent of [List.exists](https://msdn.microsoft.com/library/15a3ebd5-98f0-44c0-8220-7dedec3e68a8) for an option.

**Namespace/Module Path:** Microsoft.FSharp.Core.Option

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
exists : ('T -> bool) -> 'T option -> bool

// Usage:
exists predicate option
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


A function that evaluates to a Boolean when given a value from the option type.


*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.



**Returns false if the option is None, otherwise it returns the result of applying the predicate to the option value.**
## Remarks
The expression **exists p inp** evaluates to **match inp with None -&gt; false | Some x -&gt; p x**.

This function is named **Exists** in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

**The following code illustrates the use of Option.exists.**
[!code-fsharp[Main](snippets/fsoptions/snippet3.fs)]
**Output**
**truefalsefalse**
## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)


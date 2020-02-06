---
title: do Bindings (F#)
description: do Bindings (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4c1057a3-3aa1-4b64-b46a-25ffe33f0be9
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/functions/do-bindings 
---

# do Bindings (F#)

A `do` binding is used to execute code without defining a function or value. Also, do bindings can be used in classes, see [do Bindings in Classes &#40;F&#35;&#41;](do-Bindings-in-Classes-%5BFSharp%5D.md).


## Syntax

```fsharp
[ attributes ]
[ do ]expression
```

## Remarks
Use a `do` binding when you want to execute code independently of a function or value definition. The expression in a `do` binding must return `unit`. Code in a top-level `do` binding is executed when the module is initialized. The keyword `do` is optional.

Attributes can be applied to a top-level `do` binding. For example, if your program uses COM interop, you might want to apply the `STAThread` attribute to your program. You can do this by using an attribute on a `do` binding, as shown in the following code.

[!code-fsharp[Main](snippets/fslangref1/snippet201.fs)]
    
## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Functions &#40;F&#35;&#41;](Functions-%5BFSharp%5D.md)


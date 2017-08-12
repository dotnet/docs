---
title: do Bindings (F#)
description: Learn how an F# 'do' binding is used to execute code without defining a function or value.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 4c1057a3-3aa1-4b64-b46a-25ffe33f0be9 
---

# do Bindings

A `do` binding is used to execute code without defining a function or value. Also, do bindings can be used in classes, see [`do` Bindings in Classes](../members/do-bindings-in-classes.md).


## Syntax

```fsharp
[ attributes ]
[ do ]expression
```

## Remarks
Use a `do` binding when you want to execute code independently of a function or value definition. The expression in a `do` binding must return `unit`. Code in a top-level `do` binding is executed when the module is initialized. The keyword `do` is optional.

Attributes can be applied to a top-level `do` binding. For example, if your program uses COM interop, you might want to apply the `STAThread` attribute to your program. You can do this by using an attribute on a `do` binding, as shown in the following code.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet201.fs)]
    
## See Also
[F# Language Reference](../index.md)

[Functions](index.md)


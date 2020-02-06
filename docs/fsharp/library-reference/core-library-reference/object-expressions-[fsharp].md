---
title: Object Expressions (F#)
description: Object Expressions (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c6dcf4c9-e7fd-4eee-9e4e-1176f4c27f57
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/object-expressions
---

# Object Expressions (F#)

An *object expression* is an expression that creates a new instance of a dynamically created, anonymous object type that is based on an existing base type, interface, or set of interfaces.


## Syntax

```fsharp
// When typename is a class:
{ new typename [type-params]arguments with
member-definitions
[ additional-interface-definitions ]
}
// When typename is not a class:
{ new typename [generic-type-args] with
member-definitions
[ additional-interface-definitions ]
}
```

## Remarks
In the previous syntax, the *typename* represents an existing class type or interface type. *type-params* describes the optional generic type parameters. The *arguments* are used only for class types, which require constructor parameters. The *member-definitions* are overrides of base class methods, or implementations of abstract methods from either a base class or an interface.

The following example illustrates several different types of object expressions.

[!code-fsharp[Main](snippets/fslangref2/snippet4301.fs)]

## Using Object Expressions
You use object expressions when you want to avoid the extra code and overhead that is required to create a new, named type. If you use object expressions to minimize the number of types created in a program, you can reduce the number of lines of code and prevent the unnecessary proliferation of types. Instead of creating many types just to handle specific situations, you can use an object expression that customizes an existing type or provides an appropriate implementation of an interface for the specific case at hand.


## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

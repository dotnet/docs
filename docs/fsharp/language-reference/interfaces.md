---
title: Interfaces (F#)
description: Learn how F# Interfaces specify sets of related members that other classes implement.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 3a082459-17d4-45cf-9153-0b7550a154ec 
---

# Interfaces

*Interfaces* specify sets of related members that other classes implement.

## Syntax

```fsharp
// Interface declaration:
[ attributes ]
type interface-name =
    [ interface ]     [ inherit base-interface-name ...]
    abstract member1 : [ argument-types1 -> ] return-type1
    abstract member2 : [ argument-types2 -> ] return-type2
    ...
[ end ]

// Implementing, inside a class type definition:
interface interface-name with
    member self-identifier.member1argument-list = method-body1
    member self-identifier.member2argument-list = method-body2

// Implementing, by using an object expression:
[ attributes ]
let class-name (argument-list) =
    { new interface-name with
        member self-identifier.member1argument-list = method-body1
        member self-identifier.member2argument-list = method-body2
        [ base-interface-definitions ]
    }
    member-list
```

## Remarks
Interface declarations resemble class declarations except that no members are implemented. Instead, all the members are abstract, as indicated by the keyword `abstract`. You do not provide a method body for abstract methods. However, you can provide a default implementation by also including a separate definition of the member as a method together with the `default` keyword. Doing so is equivalent to creating a virtual method in a base class in other .NET languages. Such a virtual method can be overridden in classes that implement the interface.

You can optionally give each method parameter a name using normal F# syntax:

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet24032.fs)]

In the above `ISprintable` example, the `Print` method has a single parameter of the type `string` with the name `format`.

There are two ways to implement interfaces: by using object expressions, and by using class types. In either case, the class type or object expression provides method bodies for abstract methods of the interface. Implementations are specific to each type that implements the interface. Therefore, interface methods on different types might be different from each other.

The keywords `interface` and `end`, which mark the start and end of the definition, are optional when you use lightweight syntax. If you do not use these keywords, the compiler attempts to infer whether the type is a class or an interface by analyzing the constructs that you use. If you define a member or use other class syntax, the type is interpreted as a class.

The .NET coding style is to begin all interfaces with a capital `I`.


## Implementing Interfaces by Using Class Types
You can implement one or more interfaces in a class type by using the `interface` keyword, the name of the interface, and the `with` keyword, followed by the interface member definitions, as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2801.fs)]

Interface implementations are inherited, so any derived classes do not need to reimplement them.


## Calling Interface Methods
Interface methods can be called only through the interface, not through any object of the type that implements the interface. Thus, you might have to upcast to the interface type by using the `:>` operator or the `upcast` operator in order to call these methods.

To call the interface method when you have an object of type `SomeClass`, you must upcast the object to the interface type, as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2802.fs)]

An alternative is to declare a method on the object that upcasts and calls the interface method, as in the following example.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2803.fs)]
    
## Implementing Interfaces by Using Object Expressions
Object expressions provide a short way to implement an interface. They are useful when you do not have to create a named type, and you just want an object that supports the interface methods, without any additional methods. An object expression is illustrated in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2804.fs)]
    
## Interface Inheritance
Interfaces can inherit from one or more base interfaces.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2805.fs)]
    
## See Also
[F# Language Reference](index.md)

[Object Expressions](object-expressions.md)

[Classes](classes.md)

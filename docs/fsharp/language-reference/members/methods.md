---
title: Methods (F#)
description: Learn how an F# method is a function associated with a type that are used to expose and implement the functionality and behavior of objects and types.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 1febab3b-c922-49c6-889f-c22db107710c
---

# Methods

A *method* is a function that is associated with a type. In object-oriented programming, methods are used to expose and implement the functionality and behavior of objects and types.


## Syntax

```fsharp
// Instance method definition.
[ attributes ]
member [inline] self-identifier.method-nameparameter-list [ : return-type ]=
    method-body

// Static method definition.
[ attributes ]
static member [inline] method-nameparameter-list [ : return-type ]=
    method-body

// Abstract method declaration or virtual dispatch slot.
[ attributes ]
abstract member self-identifier.method-name : type-signature

// Virtual method declaration and default implementation.
[ attributes ]
abstract member [inline] self-identifier.method-name : type-signature
[ attributes ]
default member [inline] self-identifier.method-nameparameter-list[ : return-type ] =
    method-body

// Override of inherited virtual method.
[ attributes ]
override member [inline] self-identifier.method-nameparameter-list [ : return-type ]=
    method-body

// Optional and DefaultParameterValue attributes on input parameters
[ attributes ]
[ modifier ] member [inline] self-identifier.method-name ([<Optional; DefaultParameterValue([ default-value ])>] input) [ : return-type ]
```

## Remarks
In the previous syntax, you can see the various forms of method declarations and definitions. In longer method bodies, a line break follows the equal sign (=), and the whole method body is indented.

Attributes can be applied to any method declaration. They precede the syntax for a method definition and are usually listed on a separate line. For more information, see [Attributes](../attributes.md).

Methods can be marked `inline`. For information about `inline`, see [Inline Functions](../functions/inline-functions.md).

Non-inline methods can be used recursively within the type; there is no need to explicitly use the `rec` keyword.


## Instance Methods
Instance methods are declared with the `member` keyword and a *self-identifier*, followed by a period (.) and the method name and parameters. As is the case for `let` bindings, the *parameter-list* can be a pattern. Typically, you enclose method parameters in parentheses in a tuple form, which is the way methods appear in F# when they are created in other .NET Framework languages. However, the curried form (parameters separated by spaces) is also common, and other patterns are supported also.

The following example illustrates the definition and use of a non-abstract instance method.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3401.fs)]

Within instance methods, do not use the self identifier to access fields defined by using let bindings. Use the self identifier when accessing other members and properties.


## Static Methods
The keyword `static` is used to specify that a method can be called without an instance and is not associated with an object instance. Otherwise, methods are instance methods.

The example in the next section shows fields declared with the `let` keyword, property members declared with the `member` keyword, and a static method declared with the `static` keyword.

The following example illustrates the definition and use of static methods. Assume that these method definitions are in the `SomeType` class in the previous section.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3402.fs)]

## Abstract and Virtual Methods
The keyword `abstract` indicates that a method has a virtual dispatch slot and might not have a definition in the class. A *virtual dispatch slot* is an entry in an internally maintained table of functions that is used at run time to look up virtual function calls in an object-oriented type. The virtual dispatch mechanism is the mechanism that implements *polymorphism*, an important feature of object-oriented programming. A class that has at least one abstract method without a definition is an *abstract class*, which means that no instances can be created of that class. For more information about abstract classes, see [Abstract Classes](../abstract-classes.md).

Abstract method declarations do not include a method body. Instead, the name of the method is followed by a colon (:) and a type signature for the method. The type signature of a method is the same as that shown by IntelliSense when you pause the mouse pointer over a method name in the Visual Studio Code Editor, except without parameter names. Type signatures are also displayed by the interpreter, fsi.exe, when you are working interactively. The type signature of a method is formed by listing out the types of the parameters, followed by the return type, with appropriate separator symbols. Curried parameters are separated by `->` and tuple parameters are separated by `*`. The return value is always separated from the arguments by a `->` symbol. Parentheses can be used to group complex parameters, such as when a function type is a parameter, or to indicate when a tuple is treated as a single parameter rather than as two parameters.

You can also give abstract methods default definitions by adding the definition to the class and using the `default` keyword, as shown in the syntax block in this topic. An abstract method that has a definition in the same class is equivalent to a virtual method in other .NET Framework languages. Whether or not a definition exists, the `abstract` keyword creates a new dispatch slot in the virtual function table for the class.

Regardless of whether a base class implements its abstract methods, derived classes can provide implementations of abstract methods. To implement an abstract method in a derived class, define a method that has the same name and signature in the derived class, except use the `override` or `default` keyword, and provide the method body. The keywords `override` and `default` mean exactly the same thing. Use `override` if the new method overrides a base class implementation; use `default` when you create an implementation in the same class as the original abstract declaration. Do not use the `abstract` keyword on the method that implements the method that was declared abstract in the base class.

The following example illustrates an abstract method `Rotate` that has a default implementation, the equivalent of a .NET Framework virtual method.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3403.fs)]

The following example illustrates a derived class that overrides a base class method. In this case, the override changes the behavior so that the method does nothing.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3404.fs)]

## Overloaded Methods
Overloaded methods are methods that have identical names in a given type but that have different arguments. In F#, optional arguments are usually used instead of overloaded methods. However, overloaded methods are permitted in the language, provided that the arguments are in tuple form, not curried form.

## Optional Arguments

Starting with F# 4.1, you can also have optional arguments with a default parameter value in methods.  This is to help facilitate interoperation with C# code.  The following example demonstrates the syntax:

```fsharp
// A class with a method M, which takes in an optional integer argument.
type C() =
    __.M([<Optional; DefaultParameterValue(12)>] i) = i + 1
```

Note that the value passed in for `DefaultParameterValue` must match the input type.  In the above sample, it is an `int`.  Attempting to pass a non-integer value into `DefaultParameterValue` would result in a compile error.

## Example: Properties and Methods
The following example contains a type that has examples of fields, private functions, properties, and a static method.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3406.fs)]

## See Also
[Members](index.md)

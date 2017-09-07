---
title: Generics (F#)
description: Learn how to use F# generic functions and types, which enable you to write code that works with a variety of types without repeating code.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: a9f2e2ee-bcb1-4ce3-8531-850aa183040f 
---

# Generics

F# function values, methods, properties, and aggregate types such as classes, records, and discriminated unions can be *generic*. Generic constructs contain at least one type parameter, which is usually supplied by the user of the generic construct. Generic functions and types enable you to write code that works with a variety of types without repeating the code for each type. Making your code generic can be simple in F#, because often your code is implicitly inferred to be generic by the compiler's type inference and automatic generalization mechanisms.


## Syntax

```fsharp
// Explicitly generic function.
let function-name<type-parameters> parameter-list =
function-body

// Explicitly generic method.
[ static ] member object-identifer.method-name<type-parameters> parameter-list [ return-type ] =
method-body

// Explicitly generic class, record, interface, structure,
// or discriminated union.
type type-name<type-parameters> type-definition
```

## Remarks
The declaration of an explicitly generic function or type is much like that of a non-generic function or type, except for the specification (and use) of the type parameters, in angle brackets after the function or type name.

Declarations are often implicitly generic. If you do not fully specify the type of every parameter that is used to compose a function or type, the compiler attempts to infer the type of each parameter, value, and variable from the code you write. For more information, see [Type Inference](../type-inference.md). If the code for your type or function does not otherwise constrain the types of parameters, the function or type is implicitly generic. This process is named *automatic generalization*. There are some limits on automatic generalization. For example, if the F# compiler is unable to infer the types for a generic construct, the compiler reports an error that refers to a restriction called the *value restriction*. In that case, you may have to add some type annotations. For more information about automatic generalization and the value restriction, and how to change your code to address the problem, see [Automatic Generalization](automatic-generalization.md).

In the previous syntax, *type-parameters* is a comma-separated list of parameters that represent unknown types, each of which starts with a single quotation mark, optionally with a constraint clause that further limits what types may be used for that type parameter. For the syntax for constraint clauses of various kinds and other information about constraints, see [Constraints](constraints.md).

The *type-definition* in the syntax is the same as the type definition for a non-generic type. It includes the constructor parameters for a class type, an optional `as` clause, the equal symbol, the record fields, the `inherit` clause, the choices for a discriminated union, `let` and `do` bindings, member definitions, and anything else permitted in a non-generic type definition.

The other syntax elements are the same as those for non-generic functions and types. For example, *object-identifier* is an identifier that represents the containing object itself.

Properties, fields, and constructors cannot be more generic than the enclosing type. Also, values in a module cannot be generic.


## Implicitly Generic Constructs
When the F# compiler infers the types in your code, it automatically treats any function that can be generic as generic. If you specify a type explicitly, such as a parameter type, you prevent automatic generalization.

In the following code example, `makeList` is generic, even though neither it nor its parameters are explicitly declared as generic.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet1700.fs)]

The signature of the function is inferred to be `'a -> 'a -> 'a list`. Note that `a` and `b` in this example are inferred to have the same type. This is because they are included in a list together, and all elements of a list must be of the same type.

You can also make a function generic by using the single quotation mark syntax in a type annotation to indicate that a parameter type is a generic type parameter. In the following code, `function1` is generic because its parameters are declared in this manner, as type parameters.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet1701.fs)]
    
## Explicitly Generic Constructs
You can also make a function generic by explicitly declaring its type parameters in angle brackets (`<type-parameter>`). The following code illustrates this.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet1703.fs)]
    
## Using Generic Constructs
When you use generic functions or methods, you might not have to specify the type arguments. The compiler uses type inference to infer the appropriate type arguments. If there is still an ambiguity, you can supply type arguments in angle brackets, separating multiple type arguments with commas.

The following code shows the use of the functions that are defined in the previous sections.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet1702.fs)]
    
>[!NOTE]
There are two ways to refer to a generic type by name. For example, `list<int>` and `int list` are two ways to refer to a generic type `list` that has a single type argument `int`. The latter form is conventionally used only with built-in F# types such as `list` and `option`. If there are multiple type arguments, you normally use the syntax `Dictionary<int, string>` but you can also use the syntax `(int, string) Dictionary`.

## Wildcards as Type Arguments
To specify that a type argument should be inferred by the compiler, you can use the underscore, or wildcard symbol (`_`), instead of a named type argument. This is shown in the following code.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet1704.fs)]
    
## Constraints in Generic Types and Functions
In a generic type or function definition, you can use only those constructs that are known to be available on the generic type parameter. This is required to enable the verification of function and method calls at compile time. If you declare your type parameters explicitly, you can apply an explicit constraint to a generic type parameter to notify the compiler that certain methods and functions are available. However, if you allow the F# compiler to infer your generic parameter types, it will determine the appropriate constraints for you. For more information, see [Constraints](constraints.md).


## Statically Resolved Type Parameters
There are two kinds of type parameters that can be used in F# programs. The first are generic type parameters of the kind described in the previous sections. This first kind of type parameter is equivalent to the generic type parameters that are used in languages such as Visual Basic and C#. Another kind of type parameter is specific to F# and is referred to as a *statically resolved type parameter*. For information about these constructs, see [Statically Resolved Type Parameters](statically-resolved-type-parameters.md).


## Examples
[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet1705.fs)]
    
## See Also
[Language Reference](../index.md)

[Types](../fsharp-types.md)

[Statically Resolved Type Parameters](statically-resolved-type-parameters.md)

[Generics in the .NET Framework](~/docs/standard/generics/index.md)

[Automatic Generalization](automatic-generalization.md)

[Constraints](constraints.md)

---
title: Classes (F#)
description: Learn how F# Classes are types that represent objects that can have properties, methods, and events.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: d58679d5-7753-4b3b-a12f-6e9f00ed5ba3 
---

# Classes

*Classes* are types that represent objects that can have properties, methods, and events.


## Syntax

```fsharp
// Class definition:
type [access-modifier] type-name [type-params] [access-modifier] ( parameter-list ) [ as identifier ] =
[ class ]
[ inherit base-type-name(base-constructor-args) ]
[ let-bindings ]
[ do-bindings ]
member-list
...
[ end ]
// Mutually recursive class definitions:
type [access-modifier] type-name1 ...
and [access-modifier] type-name2 ...
...
```

## Remarks
Classes represent the fundamental description of .NET object types; the class is the primary type concept that supports object-oriented programming in F#.

In the preceding syntax, the `type-name` is any valid identifier. The `type-params` describes optional generic type parameters. It consists of type parameter names and constraints enclosed in angle brackets (`<` and `>`). For more information, see [Generics](generics/index.md) and [Constraints](generics/constraints.md). The `parameter-list` describes constructor parameters. The first access modifier pertains to the type; the second pertains to the primary constructor. In both cases, the default is `public`.

You specify the base class for a class by using the `inherit` keyword. You must supply arguments, in parentheses, for the base class constructor.

You declare fields or function values that are local to the class by using `let` bindings, and you must follow the general rules for `let` bindings. The `do-bindings` section includes code to be executed upon object construction.

The `member-list` consists of additional constructors, instance and static method declarations, interface declarations, abstract bindings, and property and event declarations. These are described in [Members](members/index.md).

The `identifier` that is used with the optional `as` keyword gives a name to the instance variable, or self identifier, which can be used in the type definition to refer to the instance of the type. For more information, see the section Self Identifiers later in this topic.

The keywords `class` and `end` that mark the start and end of the definition are optional.

Mutually recursive types, which are types that reference each other, are joined together with the `and` keyword just as mutually recursive functions are. For an example, see the section Mutually Recursive Types.


## Constructors
The constructor is code that creates an instance of the class type. Constructors for classes work somewhat differently in F# than they do in other .NET languages. In an F# class, there is always a primary constructor whose arguments are described in the `parameter-list` that follows the type name, and whose body consists of the `let` (and `let rec`) bindings at the start of the class declaration and the `do` bindings that follow. The arguments of the primary constructor are in scope throughout the class declaration.

You can add additional constructors by using the `new` keyword to add a member, as follows:

`new`(`argument-list`) = `constructor-body`

The body of the new constructor must invoke the primary constructor that is specified at the top of the class declaration.

The following example illustrates this concept. In the following code, `MyClass` has two constructors, a primary constructor that takes two arguments and another constructor that takes no arguments.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2401.fs)]
    
## let and do Bindings

The `let` and `do` bindings in a class definition form the body of the primary class constructor, and therefore they run whenever a class instance is created. If a `let` binding is a function, then it is compiled into a member. If the `let` binding is a value that is not used in any function or member, then it is compiled into a variable that is local to the constructor. Otherwise, it is compiled into a field of the class. The `do` expressions that follow are compiled into the primary constructor and execute initialization code for every instance. Because any additional constructors always call the primary constructor, the `let` bindings and `do` bindings always execute regardless of which constructor is called.

Fields that are created by `let` bindings can be accessed throughout the methods and properties of the class; however, they cannot be accessed from static methods, even if the static methods take an instance variable as a parameter. They cannot be accessed by using the self identifier, if one exists.


## Self Identifiers

A *self identifier* is a name that represents the current instance. Self identifiers resemble the `this` keyword in C# or C++ or `Me` in Visual Basic. You can define a self identifier in two different ways, depending on whether you want the self identifier to be in scope for the whole class definition or just for an individual method.

To define a self identifier for the whole class, use the `as` keyword after the closing parentheses of the constructor parameter list, and specify the identifier name.

To define a self identifier for just one method, provide the self identifier in the member declaration, just before the method name and a period (.) as a separator.

The following code example illustrates the two ways to create a self identifier. In the first line, the `as` keyword is used to define the self identifier. In the fifth line, the identifier `this` is used to define a self identifier whose scope is restricted to the method `PrintMessage`.

```fsharp
type MyClass2(dataIn) as self =
    let data = dataIn
    do
        self.PrintMessage()
    member this.PrintMessage() =
        printf "Creating MyClass2 with Data %d" data
```

Unlike in other .NET languages, you can name the self identifier however you want; you are not restricted to names such as `self`, `Me`, or `this`.

The self identifier that is declared with the `as` keyword is not initialized until after the `let` bindings are executed. Therefore, it cannot be used in the `let` bindings. You can use the self identifier in the `do` bindings section.


## Generic Type Parameters

Generic type parameters are specified in angle brackets (`<` and `>`), in the form of a single quotation mark followed by an identifier. Multiple generic type parameters are separated by commas. The generic type parameter is in scope throughout the declaration. The following code example shows how to specify generic type parameters.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2403.fs)]

Type arguments are inferred when the type is used. In the following code, the inferred type is a sequence of tuples.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet24031.fs)]
    
## Specifying Inheritance

The `inherit` clause identifies the direct base class, if there is one. In F#, only one direct base class is allowed. Interfaces that a class implements are not considered base classes. Interfaces are discussed in the [Interfaces](Interfaces.md) topic.

You can access the methods and properties of the base class from the derived class by using the language keyword `base` as an identifier, followed by a period (.) and the name of the member.

For more information, see [Inheritance](inheritance.md).


## Members Section
You can define static or instance methods, properties, interface implementations, abstract members, event declarations, and additional constructors in this section. Let and do bindings cannot appear in this section. Because members can be added to a variety of F# types in addition to classes, they are discussed in a separate topic, [Members](members/index.md).


## Mutually Recursive Types
When you define types that reference each other in a circular way, you string together the type definitions by using the `and` keyword. The `and` keyword replaces the `type` keyword on all except the first definition, as follows.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2404.fs)]

The output is a list of all the files in the current directory.


## When to Use Classes, Unions, Records, and Structures
Given the variety of types to choose from, you need to have a good understanding of what each type is designed for to select the appropriate type for a particular situation. Classes are designed for use in object-oriented programming contexts. Object-oriented programming is the dominant paradigm used in applications that are written for the .NET Framework. If your F# code has to work closely with the .NET Framework or another object-oriented library, and especially if you have to extend from an object-oriented type system such as a UI library, classes are probably appropriate.

If you are not interoperating closely with object-oriented code, or if you are writing code that is self-contained and therefore protected from frequent interaction with object-oriented code, you should consider using records and discriminated unions. A single, well thought–out discriminated union, together with appropriate pattern matching code, can often be used as a simpler alternative to an object hierarchy. For more information about discriminated unions, see [Discriminated Unions](discriminated-unions.md).

Records have the advantage of being simpler than classes, but records are not appropriate when the demands of a type exceed what can be accomplished with their simplicity. Records are basically simple aggregates of values, without separate constructors that can perform custom actions, without hidden fields, and without inheritance or interface implementations. Although members such as properties and methods can be added to records to make their behavior more complex, the fields stored in a record are still a simple aggregate of values. For more information about records, see [Records](records.md).

Structures are also useful for small aggregates of data, but they differ from classes and records in that they are .NET value types. Classes and records are .NET reference types. The semantics of value types and reference types are different in that value types are passed by value. This means that they are copied bit for bit when they are passed as a parameter or returned from a function. They are also stored on the stack or, if they are used as a field, embedded inside the parent object instead of stored in their own separate location on the heap. Therefore, structures are appropriate for frequently accessed data when the overhead of accessing the heap is a problem. For more information about structures, see [Structures](structures.md).


## See Also
[F# Language Reference](index.md)

[Members](members/index.md)

[Inheritance](inheritance.md)

[Interfaces](interfaces.md)


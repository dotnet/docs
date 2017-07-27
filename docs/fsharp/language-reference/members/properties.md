---
title: Properties (F#)
description: Learn about F# properties, which are members that represent values associated with an object.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 98b363a5-ee6a-4b7b-b8ae-b244f2a0b316
---

# Properties

*Properties* are members that represent values associated with an object.


## Syntax

```fsharp
// Property that has both get and set defined.
[ attributes ]
[ static ] member [accessibility-modifier] [self-identifier.]PropertyName
with [accessibility-modifier] get() =
    get-function-body
and [accessibility-modifier] set parameter =
    set-function-body

// Alternative syntax for a property that has get and set.
[ attributes-for-get ]
[ static ] member [accessibility-modifier-for-get] [self-identifier.]PropertyName =
    get-function-body
[ attributes-for-set ]
[ static ] member [accessibility-modifier-for-set] [self-identifier.]PropertyName
with set parameter =
    set-function-body

// Property that has get only.
[ attributes ]
[ static ] member [accessibility-modifier] [self-identifier.]PropertyName =
    get-function-body

// Alternative syntax for property that has get only.
[ attributes ]
[ static ] member [accessibility-modifier] [self-identifier.]PropertyName
with get() =
    get-function-body

// Property that has set only.
[ attributes ]
[ static ] member [accessibility-modifier] [self-identifier.]PropertyName
with set parameter =
    set-function-body

// Automatically implemented properties.
[ attributes ]
[ static ] member val [accessibility-modifier] PropertyName = initialization-expression [ with get, set ]
```

## Remarks
Properties represent the "has a" relationship in object-oriented programming, representing data that is associated with object instances or, for static properties, with the type.

You can declare properties in two ways, depending on whether you want to explicitly specify the underlying value (also called the backing store) for the property, or if you want to allow the compiler to automatically generate the backing store for you. Generally, you should use the more explicit way if the property has a non-trivial implementation and the automatic way when the property is just a simple wrapper for a value or variable. To declare a property explicitly, use the `member` keyword. This declarative syntax is followed by the syntax that specifies the `get` and `set` methods, also named *accessors*. The various forms of the explicit syntax shown in the syntax section are used for read/write, read-only, and write-only properties. For read-only properties, you define only a `get` method; for write-only properties, define only a `set` method. Note that when a property has both `get` and `set` accessors, the alternative syntax enables you to specify attributes and accessibility modifiers that are different for each accessor, as is shown in the following code.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3201.fs)]

For read/write properties, which have both a `get` and `set` method, the order of `get` and `set` can be reversed. Alternatively, you can provide the syntax shown for `get` only and the syntax shown for `set` only instead of using the combined syntax. Doing this makes it easier to comment out the individual `get` or `set` method, if that is something you might need to do. This alternative to using the combined syntax is shown in the following code.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3203.fs)]

Private values that hold the data for properties are called *backing stores*. To have the compiler create the backing store automatically, use the keywords `member val`, omit the self-identifier, then provide an expression to initialize the property. If the property is to be mutable, include `with get, set`. For example, the following class type includes two automatically implemented properties. `Property1` is read-only and is initialized to the argument provided to the primary constructor, and `Property2` is a settable property initialized to an empty string:

```fsharp
type MyClass(property1 : int) =
member val Property1 = property1
member val Property2 = "" with get, set
```

Automatically implemented properties are part of the initialization of a type, so they must be included before any other member definitions, just like `let` bindings and `do` bindings in a type definition. Note that the expression that initializes an automatically implemented property is only evaluated upon initialization, and not every time the property is accessed. This behavior is in contrast to the behavior of an explicitly implemented property. What this effectively means is that the code to initialize these properties is added to the constructor of a class. Consider the following code that shows this difference:

```fsharp
type MyClass() =
    let random  = new System.Random()
    member val AutoProperty = random.Next() with get, set
    member this.ExplicitProperty = random.Next()

let class1 = new MyClass()

printfn "class1.AutoProperty = %d" class1.AutoProperty
printfn "class1.AutoProperty = %d" class1.AutoProperty
printfn "class1.ExplicitProperty = %d" class1.ExplicitProperty
printfn "class1.ExplicitProperty = %d" class1.ExplicitProperty
```

**Output**

```
class1.AutoProperty = 1853799794
class1.AutoProperty = 1853799794
class1.ExplicitProperty = 978922705
class1.ExplicitProperty = 1131210765
```

The output of the preceding code shows that the value of AutoProperty is unchanged when called repeatedly, whereas the ExplicitProperty changes each time it is called. This demonstrates that the expression for an automatically implemented property is not evaluated each time, as is the getter method for the explicit property.


>[!WARNING]
There are some libraries, such as the Entity Framework (`System.Data.Entity`) that perform custom operations in base class constructors that don't work well with the initialization of automatically implemented properties. In those cases, try using explicit properties.

Properties can be members of classes, structures, discriminated unions, records, interfaces, and type extensions and can also be defined in object expressions.

Attributes can be applied to properties. To apply an attribute to a property, write the attribute on a separate line before the property. For more information, see [Attributes](../attributes.md).

By default, properties are public. Accessibility modifiers can also be applied to properties. To apply an accessibility modifier, add it immediately before the name of the property if it is meant to apply to both the `get` and `set` methods; add it before the `get` and `set` keywords if different accessibility is required for each accessor. The *accessibility-modifier* can be one of the following: `public`, `private`, `internal`. For more information, see [Access Control](../access-control.md).

Property implementations are executed each time a property is accessed.


## Static and Instance Properties
Properties can be static or instance properties. Static properties can be invoked without an instance and are used for values associated with the type, not with individual objects. For static properties, omit the self-identifier. The self-identifier is required for instance properties.

The following static property definition is based on a scenario in which you have a static field `myStaticValue` that is the backing store for the property.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3204.fs)]

Properties can also be array-like, in which case they are called *indexed properties*. For more information, see [Indexed Properties](indexed-properties.md).


## Type Annotation for Properties
In many cases, the compiler has enough information to infer the type of a property from the type of the backing store, but you can set the type explicitly by adding a type annotation.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3205.fs)]

## Using Property set Accessors
You can set properties that provide `set` accessors by using the `<-` operator.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3206.fs)]

The output is **20**.


## Abstract Properties
Properties can be abstract. As with methods, `abstract` just means that there is a virtual dispatch associated with the property. Abstract properties can be truly abstract, that is, without a definition in the same class. The class that contains such a property is therefore an abstract class. Alternatively, abstract can just mean that a property is virtual, and in that case, a definition must be present in the same class. Note that abstract properties must not be private, and if one accessor is abstract, the other must also be abstract. For more information about abstract classes, see [Abstract Classes](../abstract-classes.md).

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3207.fs)]

## See Also
[Members](index.md)

[Methods](methods.md)

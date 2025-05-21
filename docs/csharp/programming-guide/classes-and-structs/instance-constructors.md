---
title: "Instance constructors"
description: Instance constructors in C# create and initialize any instance member variables when you use the new expression to create an instance of a type.
ms.date: 05/29/2024
helpviewer_keywords:
  - "constructors [C#], instance constructors"
  - "instance constructors [C#]"
ms.topic: article
---
# Instance constructors (C# programming guide)

You declare an instance constructor to specify the code that is executed when you create a new instance of a type with the [`new` expression](../../language-reference/operators/new-operator.md). To initialize a [static](../../language-reference/keywords/static.md) class or static variables in a nonstatic class, you can define a [static constructor](static-constructors.md).

As the following example shows, you can declare several instance constructors in one type:

:::code language="csharp" source="snippets/instance-constructors/coords/Program.cs":::

In the preceding example, the first, parameterless, constructor calls the second constructor with both arguments equal `0`. To do that, use the `this` keyword.

When you declare an instance constructor in a derived class, you can call a constructor of a base class. To do that, use the `base` keyword, as the following example shows:

:::code language="csharp" source="snippets/instance-constructors/shapes/Program.cs":::

## Parameterless constructors

If a *class* has no explicit instance constructors, C# provides a parameterless constructor that you can use to instantiate an instance of that class, as the following example shows:

:::code language="csharp" source="snippets/instance-constructors/person/Program.cs":::

That constructor initializes instance fields and properties according to the corresponding initializers. If a field or property has no initializer, its value is set to the [default value](../../language-reference/builtin-types/default-values.md) of the field's or property's type. If you declare at least one instance constructor in a class, C# doesn't provide a parameterless constructor.

A *structure* type always provides a parameterless constructor. The parameterless constructor is either an implicit parameterless constructor that produces the default value of a type or an explicitly declared parameterless constructor. For more information, see the [Struct initialization and default values](../../language-reference/builtin-types/struct.md#struct-initialization-and-default-values) section of the [Structure types](../../language-reference/builtin-types/struct.md) article.

## Primary constructors

Beginning in C# 12, you can declare a *primary constructor* in classes and structs. You place any parameters in parentheses following the type name:

:::code language="csharp" source="./snippets/instance-constructors/widgets/Program.cs" id="BasePrimaryConstructor":::

The parameters to a primary constructor are in scope in the entire body of the declaring type. They can initialize properties or fields. They can be used as variables in methods or local functions. They can be passed to a base constructor.

A primary constructor indicates that these parameters are necessary for any instance of the type. Any explicitly written constructor must use the `this(...)` initializer syntax to invoke the primary constructor. That ensures that the primary constructor parameters are definitely assigned by all constructors. For any `class` type, including `record class` types, the implicit parameterless constructor isn't emitted when a primary constructor is present. For any `struct` type, including `record struct` types, the implicit parameterless constructor is always emitted, and always initializes all fields, including primary constructor parameters, to the 0-bit pattern. If you write an explicit parameterless constructor, it must invoke the primary constructor. In that case, you can specify a different value for the primary constructor parameters. The following code shows examples of primary constructors.

:::code language="csharp" source="./snippets/instance-constructors/widgets/Program.cs" id="DerivedPrimaryConstructor":::

You can add attributes to the synthesized primary constructor method by specifying the `method:` target on the attribute:

:::code language="csharp" source="./snippets/instance-constructors/widgets/Program.cs" id="PrimaryConstructorAttribute":::

If you don't specify the `method` target, the attribute is placed on the class rather than the method.

In `class` and `struct` types, primary constructor parameters are available anywhere in the body of the type. The parameter can be implemented as a captured private field. If the only references to a parameter are initializers and constructor calls, that parameter isn't captured in a private field. Uses in other members of the type cause the compiler to capture the parameter in a private field.

If the type includes the `record` modifier, the compiler instead synthesizes a public property with the same name as the primary constructor parameter. For `record class` types, if a primary constructor parameter uses the same name as a base primary constructor, that property is a public property of the base `record class` type. It isn't duplicated in the derived `record class` type. These properties aren't generated for non-`record` types.

## See also

- [Classes, structs, and records](../../fundamentals/object-oriented/index.md)
- [Constructors](constructors.md)
- [Finalizers](finalizers.md)
- [base](../../language-reference/keywords/base.md)
- [this](../../language-reference/keywords/this.md)
- [Primary constructors feature spec](~/_csharplang/proposals/csharp-12.0/primary-constructors.md)

---
title: "Instance constructors - C# programming guide"
description: Instance constructors in C# create and initialize any instance member variables when you use the new expression to create an instance of a type.
ms.date: 09/27/2021
helpviewer_keywords: 
  - "constructors [C#], instance constructors"
  - "instance constructors [C#]"
ms.assetid: 24663779-c1e5-4af4-a942-ca554e4c542d
---
# Instance constructors (C# programming guide)

You declare an instance constructor to specify the code that is executed when you create a new instance of a type with the [`new` expression](../../language-reference/operators/new-operator.md). To initialize a [static](../../language-reference/keywords/static.md) class or static variables in a non-static class, you can define a [static constructor](static-constructors.md).

As the following example shows, you can declare several instance constructors in one type:

:::code language="csharp" source="snippets/instance-constructors/coords/Program.cs":::

In the preceding example, the first, parameterless, constructor calls the second constructor with both arguments equal `0`. To do that, use the `this` keyword.

When you declare an instance constructor in a derived class, you can call a constructor of a base class. To do that, use the `base` keyword, as the following example shows:

:::code language="csharp" source="snippets/instance-constructors/shapes/Program.cs":::

## Parameterless constructors

If a *class* has no explicit instance constructors, C# provides a parameterless constructor that you can use to instantiate an instance of that class, as the following example shows:

:::code language="csharp" source="snippets/instance-constructors/person/Program.cs":::

That constructor initializes instance fields and properties according to the corresponding initializers. If a field or property has no initializer, its value is set to the [default value](../../language-reference/builtin-types/default-values.md) of the field's or property's type. If you declare at least one instance constructor in a class, C# doesn't provide a parameterless constructor.

A *structure* type always provides a parameterless constructor as follows:

- In C# 9.0 and earlier, that is an implicit parameterless constructor that produces the [default value](../../language-reference/builtin-types/default-values.md) of a type.
- In C# 10 and later, that is either an implicit parameterless constructor that produces the default value of a type or an explicitly declared parameterless constructor. For more information, see the [Parameterless constructors and field initializers](../../language-reference/builtin-types/struct.md#parameterless-constructors-and-field-initializers) section of the [Structure types](../../language-reference/builtin-types/struct.md) article.

## See also

- [C# programming guide](../index.md)
- [Classes, structs, and records](../../fundamentals/object-oriented/index.md)
- [Constructors](constructors.md)
- [Finalizers](finalizers.md)
- [base](../../language-reference/keywords/base.md)
- [this](../../language-reference/keywords/this.md)

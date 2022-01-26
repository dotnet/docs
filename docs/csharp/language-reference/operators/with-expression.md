---
title: "with expression - C# reference"
description: "Learn about a with expression that performs nondestructive mutation of C# records and structures"
ms.date: 09/15/2021
f1_keywords:
  - "with_CSharpKeyword"
helpviewer_keywords:
  - "with expression [C#]"
  - "with operator [C#]"
---
# with expression (C# reference)

Available in C# 9.0 and later, a `with` expression produces a copy of its operand with the specified properties and fields modified:

:::code language="csharp" source="snippets/with-expression/BasicExample.cs" :::

As the preceding example shows, you use [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) syntax to specify what members to modify and their new values.

In C# 9.0, a left-hand operand of a `with` expression must be of a [record type](../builtin-types/record.md). Beginning with C# 10, a left-hand operand of a `with` expression can also be of a [structure type](../builtin-types/struct.md) or an [anonymous type](../../fundamentals/types/anonymous-types.md).

The result of a `with` expression has the same run-time type as the expression's operand, as the following example shows:

:::code language="csharp" source="snippets/with-expression/InheritanceExample.cs" :::

In the case of a reference-type member, only the reference to a member instance is copied when an operand is copied. Both the copy and original operand have access to the same reference-type instance. The following example demonstrates that behavior:

:::code language="csharp" source="snippets/with-expression/ExampleWithReferenceType.cs" :::

## Custom copy semantics

Any record class type has the *copy constructor*. That is a constructor with a single parameter of the containing record type. It copies the state of its argument to a new record instance. At evaluation of a `with` expression, the copy constructor gets called to instantiate a new record instance based on an original record. After that, the new instance gets updated according to the specified modifications. By default, the copy constructor is implicit, that is, compiler-generated. If you need to customize the record copy semantics, explicitly declare a copy constructor with the desired behavior. The following example updates the preceding example with an explicit copy constructor. The new copy behavior is to copy list items instead of a list reference when a record is copied:

:::code language="csharp" source="snippets/with-expression/UserDefinedCopyConstructor.cs" :::

You cannot customize the copy semantics for structure types.

## C# language specification

For more information, see the following sections of the [records feature proposal note](~/_csharplang/proposals/csharp-9.0/records.md):

- [`with` expression](~/_csharplang/proposals/csharp-9.0/records.md#with-expression)
- [Copy and Clone members](~/_csharplang/proposals/csharp-9.0/records.md#copy-and-clone-members)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Records](../builtin-types/record.md)
- [Structure types](../builtin-types/struct.md)

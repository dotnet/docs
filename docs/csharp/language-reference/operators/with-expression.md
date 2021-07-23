---
title: "with expression - C# reference"
description: "Learn about a with expression that performs non-destructive mutation of C# records"
ms.date: 11/12/2020
f1_keywords:
  - "with_CSharpKeyword"
helpviewer_keywords:
  - "with expression [C#]"
  - "with operator [C#]"
---
# with expression (C# reference)

Available in C# 9.0 and later, a `with` expression produces a copy of its [record](../builtin-types/record.md) operand with the specified properties and fields modified:

:::code language="csharp" source="snippets/with-expression/BasicExample.cs" :::

As the preceding example shows, you use [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) syntax to specify what members to modify and their new values. In a `with` expression, a left-hand operand must be of a record type.

The result of a `with` expression has the same run-time type as the expression's operand, as the following example shows:

:::code language="csharp" source="snippets/with-expression/InheritanceExample.cs" :::

In the case of a reference-type member, only the reference to an instance is copied when a record is copied. Both the copy and original record have access to the same reference-type instance. The following example demonstrates that behavior:

:::code language="csharp" source="snippets/with-expression/ExampleWithReferenceType.cs" :::

Any record type has the *copy constructor*. That is a constructor with a single parameter of the containing record type. It copies the state of its argument to a new record instance. At evaluation of a `with` expression, the copy constructor gets called to instantiate a new record instance based on an original record. After that, the new instance gets updated according to the specified modifications. By default, the copy constructor is implicit, that is, compiler-generated. If you need to customize the record copy semantics, explicitly declare a copy constructor with the desired behavior. The following example updates the preceding example with an explicit copy constructor. The new copy behavior is to copy list items instead of a list reference when a record is copied:

:::code language="csharp" source="snippets/with-expression/UserDefinedCopyConstructor.cs" :::

## C# language specification

For more information, see the following sections of the [records feature proposal note](~/_csharplang/proposals/csharp-9.0/records.md):

- [`with` expression](~/_csharplang/proposals/csharp-9.0/records.md#with-expression)
- [Copy and Clone members](~/_csharplang/proposals/csharp-9.0/records.md#copy-and-clone-members)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Records](../builtin-types/record.md)

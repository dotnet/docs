---
description: "Learn more about: Nothing keyword (Visual Basic)"
title: "Nothing keyword"
ms.date: 07/20/2015
f1_keywords:
  - "Nothing"
  - "vb.Nothing"
helpviewer_keywords:
  - "Nothing keyword [Visual Basic]"
  - "Nothing keyword [Visual Basic], syntax"
ms.assetid: 06176e2d-bbf7-4a37-afaa-a86ad21ee99f
---
# Nothing keyword (Visual Basic)

Represents the default value of any data type. For reference types, the default value is the `null` reference. For value types, the default value depends on whether the value type is nullable.

> [!NOTE]
> For non-nullable value types, `Nothing` in Visual Basic differs from `null` in C#. In Visual Basic, if you set a variable of a non-nullable value type to `Nothing`, the variable is set to the default value for its declared type. In C#, if you assign a variable of a non-nullable value type to `null`, a compile-time error occurs.

## Remarks

`Nothing` represents the default value of a data type. The default value depends on whether the variable is of a value type or of a reference type.

A variable of a *value type* directly contains its value. Value types include all numeric data types, `Boolean`, `Char`, `Date`, all structures, and all enumerations. A variable of a *reference type* stores a reference to an instance of the object in memory. Reference types include classes, arrays, delegates, and strings. For more information, see [Value Types and Reference Types](../programming-guide/language-features/data-types/value-types-and-reference-types.md).

If a variable is of a value type, the behavior of `Nothing` depends on whether the variable is of a nullable data type. To represent a nullable value type, add a `?` modifier to the type name. Assigning `Nothing` to a nullable variable sets the value to `null`. For more information and examples, see [Nullable Value Types](../programming-guide/language-features/data-types/nullable-value-types.md).

If a variable is of a value type that is not nullable, assigning `Nothing` to it sets it to the default value for its declared type. If that type contains variable members, they are all set to their default values. The following example illustrates this for scalar types.

[!code-vb[VbVbalrKeywords#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/Class2.vb#7)]

If a variable is of a reference type, assigning `Nothing` to the variable sets it to a `null` reference of the variable's type. A variable that is set to a `null` reference is not associated with any object. The following example demonstrates this:

[!code-vb[VbVbalrKeywords#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/class3.vb#8)]

When checking whether a reference (or nullable value type) variable is `null`, do not use `= Nothing` or `<> Nothing`. Always use `Is Nothing` or `IsNot Nothing`.

For strings in Visual Basic, the empty string equals `Nothing`. Therefore, `"" = Nothing` is true.

The following example shows comparisons that use the `Is` and `IsNot` operators:

[!code-vb[VbVbalrKeywords#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/Class4.vb#9)]

If you declare a variable without using an `As` clause and set it to `Nothing`, the variable has a type of `Object`. An example of this is `Dim something = Nothing`. A compile-time error occurs in this case when `Option Strict` is on and `Option Infer` is off.

When you assign `Nothing` to an object variable, it no longer refers to any object instance. If the variable had previously referred to an instance, setting it to `Nothing` does not terminate the instance itself. The instance is terminated, and the memory and system resources associated with it are released, only after the garbage collector (GC) detects that there are no active references remaining.

`Nothing` differs from the <xref:System.DBNull> object, which represents an uninitialized variant or a nonexistent database column.

## See also

- [Dim Statement](./statements/dim-statement.md)
- [Object Lifetime: How Objects Are Created and Destroyed](../programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md)
- [Lifetime in Visual Basic](../programming-guide/language-features/declared-elements/lifetime.md)
- [Is Operator](./operators/is-operator.md)
- [IsNot Operator](./operators/isnot-operator.md)
- [Nullable Value Types](../programming-guide/language-features/data-types/nullable-value-types.md)

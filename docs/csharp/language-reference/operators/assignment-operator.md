---
title: "Assignment operators - assign an expression to a variable"
description: "C# Assignment sets the value of the expression. Alternatively, `ref` assignment sets the reference of a reference variable."
ms.date: 06/11/2025
f1_keywords:
  - "=_CSharpKeyword"
helpviewer_keywords:
  - "= operator [C#]"
---
# Assignment operators (C# reference)

The assignment operator `=` assigns the *value* of its right-hand operand to a variable, a [property](../../programming-guide/classes-and-structs/properties.md), or an [indexer](../../programming-guide/indexers/index.md) element given by its left-hand operand. The result of an assignment expression is the value assigned to the left-hand operand. The type of the right-hand operand must be the same as the type of the left-hand operand or implicitly convertible to it.

The assignment operator `=` is right-associative, that is, an expression of the form

```csharp
a = b = c
```

Is evaluated as

```csharp
a = (b = c)
```

The following example demonstrates the usage of the assignment operator with a local variable, a property, and an indexer element as its left-hand operand:

:::code language="csharp" source="snippets/shared/AssignmentOperator.cs" id="SnippetSimple":::

The left-hand operand of an assignment receives the *value* of the right-hand operand. When the operands are of [value types](../builtin-types/value-types.md), assignment copies the contents of the right-hand operand. When the operands are of [reference types](../builtin-types/reference-types.md), assignment copies the reference to the object.

This operation is called *value assignment*: the value is assigned.

Beginning with C# 14, the left hand side of a value assignment can include a [null conditional member expression](./member-access-operators.md#null-conditional-operators--and-), such as `?.` or `?[]`. If the left hand side is null, the right hand side expression isn't evaluated.

## ref assignment

*Ref assignment* `= ref` makes its left-hand operand an alias to the right-hand operand, as the following example demonstrates:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/AssignmentOperator.cs" id="SnippetRefAssignment":::

In the preceding example, the [local reference variable](../statements/declarations.md#reference-variables) `arrayElement` is initialized as an alias to the first array element. Then, it's `ref` reassigned to refer to the last array element. As it's an alias, when you update its value with an ordinary assignment operator `=`, the corresponding array element is also updated.

The left-hand operand of `ref` assignment can be a [local reference variable](../statements/declarations.md#reference-variables), a [`ref` field](../builtin-types/ref-struct.md#ref-fields), and a [`ref`](../keywords/ref.md), [`out`](../keywords/method-parameters.md#out-parameter-modifier), or [`in`](../keywords/method-parameters.md#in-parameter-modifier) method parameter. Both operands must be of the same type.

A `ref` assignment means that a reference variable has a different referrent. It's no longer referring to its previous referrent. Using `ref =` on a `ref` parameter means the parameter no longer refers to its argument. Any actions that modify the state of the object after ref reassigning it make those modifications to the new item. For example, consider the following method:

:::code language="csharp" source="snippets/shared/AssignmentOperator.cs" id="SnippetRefReassignAndModify":::

The following usage shows that the assignment to the parameter `s` isn't visible after the method call because `s` was `ref` reassigned to refer to `sLocal` before the string was modified:

:::code language="csharp" source="snippets/shared/AssignmentOperator.cs" id="Usage":::

## Compound assignment

For a binary operator `op`, a compound assignment expression of the form

```csharp
x op= y
```

Is equivalent to

```csharp
x = x op y
```

Except that `x` is only evaluated once.

The [arithmetic](arithmetic-operators.md#compound-assignment), [Boolean logical](boolean-logical-operators.md#compound-assignment), and [bitwise logical and shift](bitwise-and-shift-operators.md#compound-assignment) operators all support compound assignment.

## Null-coalescing assignment

You can use the null-coalescing assignment operator `??=` to assign the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to `null`. For more information, see the [`??` and `??=` operators](null-coalescing-operator.md) article.

## Operator overloadability

A user-defined type can't [overload](operator-overloading.md) the assignment operator. However, a user-defined type can define an implicit conversion to another type. That way, the value of a user-defined type can be assigned to a variable, a property, or an indexer element of another type. For more information, see [User-defined conversion operators](user-defined-conversion-operators.md).

If a user-defined type overloads a binary operator `op`, the `op=` operator, if it exists, is also implicitly overloaded. Beginning with C# 14, a user-defined type can explicitly overload the compound assignment operators (`op=`) to provide a more efficient implementation. Typically, a type overloads these operators because the value can be updated in place, rather than allocating a new instance to hold the result of the binary operation. If a type doesn't provide an explicit overload, the compiler generates the implicit overload.

## C# language specification

For more information, see the [Assignment operators](~/_csharpstandard/standard/expressions.md#1221-assignment-operators) section of the [C# language specification](~/_csharpstandard/standard/README.md) and the [User defined compound assignment](~/_csharplang/proposals/user-defined-compound-assignment.md) feature specification.

## See also

- [C# operators and expressions](index.md)
- [ref keyword](../keywords/ref.md)
- [Use compound assignment (style rules IDE0054 and IDE0074)](../../../fundamentals/code-analysis/style-rules/ide0054-ide0074.md)

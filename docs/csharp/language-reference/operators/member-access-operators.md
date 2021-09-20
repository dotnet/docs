---
title: "Member access operators and expressions - C# reference"
description: "Learn about C# operators that you can use to access type members."
ms.date: 08/16/2021
author: pkulikov
f1_keywords: 
  - "._CSharpKeyword"
  - "[]_CSharpKeyword"
  - "()_CSharpKeyword"
  - "^_CSharpKeyword"
  - ".._CSharpKeyword"
helpviewer_keywords: 
  - "member access operators [C#]"
  - "member access operator [C#]"
  - "dot operator [C#]"
  - ". operator [C#]"
  - "subscript operator [C#]"
  - "square brackets [] operator [C#]"
  - "indexer operator [C#]"
  - "[] operator [C#]"
  - "null-conditional operators [C#]"
  - "Elvis operator [C#]"
  - "?. operator [C#]"
  - "?[] operator [C#]"
  - "invocation operator [C#]"
  - "method call [C#]"
  - "method invocation [C#]"
  - "delegate invocation [C#]"
  - "() operator [C#]"
  - "^ operator [C#]"
  - "index from end operator [C#]"
  - "hat operator [C#]"
  - ".. operator [C#]"
  - "range operator [C#]"
---
# Member access operators and expressions (C# reference)

You can use the following operators and expressions when you access a type member:

- [`.` (member access)](#member-access-expression-): to access a member of a namespace or a type
- [`[]` (array element or indexer access)](#indexer-operator-): to access an array element or a type indexer
- [`?.` and `?[]` (null-conditional operators)](#null-conditional-operators--and-): to perform a member or element access operation only if an operand is non-null
- [`()` (invocation)](#invocation-expression-): to call an accessed method or invoke a delegate
- [`^` (index from end)](#index-from-end-operator-): to indicate that the element position is from the end of a sequence
- [`..` (range)](#range-operator-): to specify a range of indices that you can use to obtain a range of sequence elements

## Member access expression .

You use the `.` token to access a member of a namespace or a type, as the following examples demonstrate:

- Use `.` to access a nested namespace within a namespace, as the following example of a [`using` directive](../keywords/using-directive.md) shows:

 :::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="NestedNamespace":::

- Use `.` to form a *qualified name* to access a type within a namespace, as the following code shows:

 :::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="QualifiedName":::

  Use a [`using` directive](../keywords/using-directive.md) to make the use of qualified names optional.

- Use `.` to access [type members](../../fundamentals/object-oriented/index.md#members), static and non-static, as the following code shows:

 :::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="TypeMemberAccess" interactive="try-dotnet-method":::

You can also use `.` to access an [extension method](../../programming-guide/classes-and-structs/extension-methods.md).

## Indexer operator []

Square brackets, `[]`, are typically used for array, indexer, or pointer element access.

### Array access

The following example demonstrates how to access array elements:

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="Arrays" interactive="try-dotnet-method":::

If an array index is outside the bounds of the corresponding dimension of an array, an <xref:System.IndexOutOfRangeException> is thrown.

As the preceding example shows, you also use square brackets when you declare an array type or instantiate an array instance.

For more information about arrays, see [Arrays](../../programming-guide/arrays/index.md).

### Indexer access

The following example uses the .NET <xref:System.Collections.Generic.Dictionary%602> type to demonstrate indexer access:

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="Indexers" interactive="try-dotnet-method":::

Indexers allow you to index instances of a user-defined type in the similar way as array indexing. Unlike array indices, which must be integer, the indexer parameters can be declared to be of any type.

For more information about indexers, see [Indexers](../../programming-guide/indexers/index.md).

### Other usages of []

For information about pointer element access, see the [Pointer element access operator []](pointer-related-operators.md#pointer-element-access-operator-) section of the [Pointer related operators](pointer-related-operators.md) article.

You also use square brackets to specify [attributes](../../programming-guide/concepts/attributes/index.md):

```csharp
[System.Diagnostics.Conditional("DEBUG")]
void TraceMethod() {}
```

## Null-conditional operators ?. and ?[]

Available in C# 6 and later, a null-conditional operator applies a [member access](#member-access-expression-), `?.`, or [element access](#indexer-operator-), `?[]`, operation to its operand only if that operand evaluates to non-null; otherwise, it returns `null`. That is,

- If `a` evaluates to `null`, the result of `a?.x` or `a?[x]` is `null`.
- If `a` evaluates to non-null, the result of `a?.x` or `a?[x]` is the same as the result of `a.x` or `a[x]`, respectively.

  > [!NOTE]
  > If `a.x` or `a[x]` throws an exception, `a?.x` or `a?[x]` would throw the same exception for non-null `a`. For example, if `a` is a non-null array instance and `x` is outside the bounds of `a`, `a?[x]` would throw an <xref:System.IndexOutOfRangeException>.

The null-conditional operators are short-circuiting. That is, if one operation in a chain of conditional member or element access operations returns `null`, the rest of the chain doesn't execute. In the following example, `B` is not evaluated if `A` evaluates to `null` and `C` is not evaluated if `A` or `B` evaluates to `null`:

```csharp
A?.B?.Do(C);
A?.B?[C];
```

If `A` might be null but `B` and `C` would not be null if A is not null, you only need to apply the null-conditional operator to `A`:

```csharp
A?.B.C();
```

In the preceding example, `B` is not evaluated and `C()` is not called if `A` is null. However, if the chained member access is interrupted, for example by parentheses as in `(A?.B).C()`, short-circuiting doesn't happen.

The following examples demonstrate the usage of the `?.` and `?[]` operators:

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="SnippetNullConditional" interactive="try-dotnet-method":::
:::code language="csharp" source="snippets/shared/MemberAccessOperators2.cs" interactive="try-dotnet":::

The first of the preceding two examples also uses the [null-coalescing operator `??`](null-coalescing-operator.md) to specify an alternative expression to evaluate in case the result of a null-conditional operation is `null`.

If `a.x` or `a[x]` is of a non-nullable value type `T`, `a?.x` or `a?[x]` is of the corresponding [nullable value type](../builtin-types/nullable-value-types.md) `T?`. If you need an expression of type `T`, apply the null-coalescing operator `??` to a null-conditional expression, as the following example shows:

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="NullConditionalWithNullCoalescing" interactive="try-dotnet-method":::

In the preceding example, if you don't use the `??` operator, `numbers?.Length < 2` evaluates to `false` when `numbers` is `null`.

The null-conditional member access operator `?.` is also known as the Elvis operator.

### Thread-safe delegate invocation

Use the `?.` operator to check if a delegate is non-null and invoke it in a thread-safe way (for example, when you [raise an event](../../../standard/events/how-to-raise-and-consume-events.md)), as the following code shows:

```csharp
PropertyChanged?.Invoke(…)
```

That code is equivalent to the following code that you would use in C# 5 or earlier:

```csharp
var handler = this.PropertyChanged;
if (handler != null)
{
    handler(…);
}
```

That is a thread-safe way to ensure that only a non-null `handler` is invoked. Because delegate instances are immutable, no thread can change the object referenced by the `handler` local variable. In particular, if the code executed by another thread unsubscribes from the `PropertyChanged` event and `PropertyChanged` becomes `null` before `handler` is invoked, the object referenced by `handler` remains unaffected. The `?.` operator evaluates its left-hand operand no more than once, guaranteeing that it cannot be changed to `null` after being verified as non-null.

## Invocation expression ()

Use parentheses, `()`, to call a [method](../../programming-guide/classes-and-structs/methods.md) or invoke a [delegate](../../programming-guide/delegates/index.md).

The following example demonstrates how to call a method, with or without arguments, and invoke a delegate:

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="Invocation" interactive="try-dotnet-method":::

You also use parentheses when you invoke a [constructor](../../programming-guide/classes-and-structs/constructors.md) with the [`new`](new-operator.md) operator.

### Other usages of ()

You also use parentheses to adjust the order in which to evaluate operations in an expression. For more information, see [C# operators](index.md).

[Cast expressions](type-testing-and-cast.md#cast-expression), which perform explicit type conversions, also use parentheses.

## Index from end operator ^

Available in C# 8.0 and later, the `^` operator indicates the element position from the end of a sequence. For a sequence of length `length`, `^n` points to the element with offset `length - n` from the start of a sequence. For example, `^1` points to the last element of a sequence and `^length` points to the first element of a sequence.

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="IndexFromEnd":::

As the preceding example shows, expression `^e` is of the <xref:System.Index?displayProperty=nameWithType> type. In expression `^e`, the result of `e` must be implicitly convertible to `int`.

You can also use the `^` operator with the [range operator](#range-operator-) to create a range of indices. For more information, see [Indices and ranges](../../whats-new/tutorials/ranges-indexes.md).

## Range operator ..

Available in C# 8.0 and later, the `..` operator specifies the start and end of a range of indices as its operands. The left-hand operand is an *inclusive* start of a range. The right-hand operand is an *exclusive* end of a range. Either of operands can be an index from the start or from the end of a sequence, as the following example shows:

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="Ranges":::

As the preceding example shows, expression `a..b` is of the <xref:System.Range?displayProperty=nameWithType> type. In expression `a..b`, the results of `a` and `b` must be implicitly convertible to `int` or <xref:System.Index>.

You can omit any of the operands of the `..` operator to obtain an open-ended range:

- `a..` is equivalent to `a..^0`
- `..b` is equivalent to `0..b`
- `..` is equivalent to `0..^0`

:::code language="csharp" source="snippets/shared/MemberAccessOperators.cs" id="RangesOptional":::

For more information, see [Indices and ranges](../../whats-new/tutorials/ranges-indexes.md).

## Operator overloadability

The `.`, `()`, `^`, and `..` operators cannot be overloaded. The `[]` operator is also considered a non-overloadable operator. Use [indexers](../../programming-guide/indexers/index.md) to support indexing with user-defined types.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Member access](~/_csharplang/spec/expressions.md#member-access)
- [Element access](~/_csharplang/spec/expressions.md#element-access)
- [Null-conditional operator](~/_csharplang/spec/expressions.md#null-conditional-operator)
- [Invocation expressions](~/_csharplang/spec/expressions.md#invocation-expressions)

For more information about indices and ranges, see the [feature proposal note](~/_csharplang/proposals/csharp-8.0/ranges.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [?? (null-coalescing operator)](null-coalescing-operator.md)
- [:: operator](namespace-alias-qualifier.md)

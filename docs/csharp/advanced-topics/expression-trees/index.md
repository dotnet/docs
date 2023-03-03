---
title: "Expression Trees"
description: Learn about expression trees. See how to compile and run code represented by these data structures, where each node is an expression.
ms.date: 03/03/2023
ms.custom: updateeachrelease
---
# Expression Trees

Expression trees represent code in a tree-like data structure, where each node is an expression, for example, a method call or a binary operation such as `x < y`.

You can compile and run code represented by expression trees. This enables dynamic modification of executable code, the execution of LINQ queries in various databases, and the creation of dynamic queries. For more information about expression trees in LINQ, see [How to use expression trees to build dynamic queries (C#)](./how-to-use-expression-trees-to-build-dynamic-queries.md).
  
Expression trees are also used in the dynamic language runtime (DLR) to provide interoperability between dynamic languages and .NET and to enable compiler writers to emit expression trees instead of Microsoft intermediate language (MSIL). For more information about the DLR, see [Dynamic Language Runtime Overview](../../../../framework/reflection-and-codedom/dynamic-language-runtime-overview.md).

You can have the C# or Visual Basic compiler create an expression tree for you based on an anonymous lambda expression, or you can create expression trees manually by using the <xref:System.Linq.Expressions> namespace.

## Creating Expression Trees from Lambda Expressions

When a lambda expression is assigned to a variable of type <xref:System.Linq.Expressions.Expression%601>, the compiler emits code to build an expression tree that represents the lambda expression.

The C# compiler can generate expression trees only from expression lambdas (or single-line lambdas). It cannot parse statement lambdas (or multi-line lambdas). For more information about lambda expressions in C#, see [Lambda Expressions](../../../language-reference/operators/lambda-expressions.md).

The following code examples demonstrate how to have the C# compiler create an expression tree that represents the lambda expression `num => num < 5`.

```csharp
Expression<Func<int, bool>> lambda = num => num < 5;
```

## Creating Expression Trees by Using the API

## Parsing Expression Trees

## Immutability of Expression Trees

Expression trees should be immutable. This means that if you want to modify an expression tree, you must construct a new expression tree by copying the existing one and replacing nodes in it. You can use an expression tree visitor to traverse the existing expression tree. For more information, see [How to modify expression trees (C#)](./how-to-modify-expression-trees.md).

## Compiling Expression Trees

For more information, see [How to execute expression trees (C#)](./how-to-execute-expression-trees.md).

## Restrictions on language syntax

Expression trees don't support all C# syntax. The types of expressions allowed in an expression tree isn't being updated. It would be a breaking change for all libraries interpreting expression trees to introduce new node types. In general, C# syntax introduced after C# 3 may not be convertible to expression tree elements. The following list is a partial list of C# language elements that can't be used:

- Conditional methods that have been removed
- `base` access
- Method group expressions, including *address-of* (`&`) a method group, and anonymous method expressions
- References to local functions
- Statements, including assignment (`=`) and statement bodied expressions
- Partial methods with only a defining declaration
- Unsafe pointer operations
- `dynamic` operations
- Coalescing operators with `null` or `default` literal left side, null coalescing assignment, and the null propagating operator (`?.`)
- Multi-dimensional array initializers, indexed properties, and dictionary initializers
- Null propagating (`?.`) expressions
- `throw` expressions
- Accessing `static virtual` or `abstract` interface members
- Lambda expressions that have attributes
- Interpolated strings
- UTF-8 string conversions or UTF-8 string literals
- Method invocations using variable arguments, named arguments or optional arguments
- Expressions using <xref:System.Index?displayProperty=nameWithType> or <xref:System.Range?displayProperty=nameWithType>, index "from end" (`^`) operator or range expressions (`..`)
- `async` lambda expressions or `await` expressions (includes `await foreach` and `await using`)
- Tuple literals, tuple conversions, tuple `==` or `!=`, or `with` expressions
- Discards (`_`), deconstructing assignment, pattern matching `is` operator or the pattern matching `switch` expression
- COM call with `ref` omitted on the arguments
- `ref`, `in` or `out` parameters, `ref` return values, `out` arguments, or any values of `ref struct` type

## See also

- <xref:System.Linq.Expressions>
- [How to execute expression trees (C#)](./how-to-execute-expression-trees.md)
- [How to modify expression trees (C#)](./how-to-modify-expression-trees.md)
- [Lambda Expressions](../../../language-reference/operators/lambda-expressions.md)
- [Dynamic Language Runtime Overview](../../../../framework/reflection-and-codedom/dynamic-language-runtime-overview.md)
- [Programming Concepts (C#)](../index.md)

---
title: Some expressions are prohibited in expression trees. Learn which expressions aren't allowed
description: These compiler errors and warnings indicate that an expression would include an expression that isn't allowed in an expression tree. You need to refactor your code to remove the prohibited expression.
f1_keywords:
 - "CS0765"
 - "CS0831"
 - "CS0832"
 - "CS0834"
 - "CS0835"
 - "CS0838"
 - "CS0845"
 - "CS0853"
 - "CS0854"
 - "CS0855"
 - "CS1944"
 - "CS1945"
 - "CS1946"
 - "CS1951"
 - "CS1952"
 - "CS1963"
 - "CS1989"
 - "CS2037"
 - "CS7053"
 - "CS8072"
 - "CS8074"
 - "CS8075"
 - "CS8110"
 - "CS8122"
 - "CS8143"
 - "CS8144"
 - "CS8153"
 - "CS8155"
 - "CS8188"
 - "CS8198"
 - "CS8207"
 - "CS8382"
 - "CS8514"
 - "CS8640"
 - "CS8642"
 - "CS8790"
 - "CS8791"
 - "CS8792"
 - "CS8810"
 - "CS8849"
 - "CS8927"
 - "CS8952"
 - "CS9170"
 - "CS9175"
 - "CS9226"
 - "CS9296"
 - "CS9307"
helpviewer_keywords:
 - "CS0765"
 - "CS0831"
 - "CS0832"
 - "CS0834"
 - "CS0835"
 - "CS0838"
 - "CS0845"
 - "CS0853"
 - "CS0854"
 - "CS0855"
 - "CS1944"
 - "CS1945"
 - "CS1946"
 - "CS1951"
 - "CS1952"
 - "CS1963"
 - "CS1989"
 - "CS2037"
 - "CS7053"
 - "CS8072"
 - "CS8074"
 - "CS8075"
 - "CS8110"
 - "CS8122"
 - "CS8143"
 - "CS8144"
 - "CS8153"
 - "CS8155"
 - "CS8188"
 - "CS8198"
 - "CS8207"
 - "CS8382"
 - "CS8514"
 - "CS8640"
 - "CS8642"
 - "CS8790"
 - "CS8791"
 - "CS8781"
 - "CS8792"
 - "CS8810"
 - "CS8849"
 - "CS8927"
 - "CS8952"
 - "CS9170"
 - "CS9175"
 - "CS9226"
 - "CS9296"
 - "CS9307"
ms.date: 05/27/2025
---
# Resolve errors and warnings generated from expressions prohibited in expression trees

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS0765** - *Partial methods with only a defining declaration or removed conditional methods cannot be used in expression trees.*
- **CS0831** - *An expression tree may not contain a base access.*
- **CS0832** - *An expression tree may not contain an assignment operator*
- **CS0834** - *A lambda expression with a statement body cannot be converted to an expression tree.*
- **CS0835** - *Cannot convert lambda to an expression tree whose type argument 'type' is not a delegate type.*
- **CS0838** - *An expression tree may not contain a multidimensional array initializer.*
- **CS0845** - *An expression tree lambda may not contain a coalescing operator with a null or default literal left-hand side.*
- **CS0853** - *An expression tree may not contain a named argument specification.*
- **CS0854** - *An expression tree may not contain a call or invocation that uses optional arguments.*
- **CS0855** - *An expression tree may not contain an indexed property.*
- **CS1944** - *An expression tree may not contain an unsafe pointer operation.*
- **CS1945** - *An expression tree may not contain an anonymous method expression.*
- **CS1946** - *An anonymous method expression cannot be converted to an expression tree.*
- **CS1951** - *An expression tree lambda may not contain a `ref`, `in` or `out` parameter.*
- **CS1952** - *An expression tree lambda may not contain a method with variable arguments.*
- **CS1963** - *An expression tree may not contain a dynamic operation.*
- **CS1989** - *Async lambda expressions cannot be converted to expression trees.*
- **CS2037** - *An expression tree lambda may not contain a COM call with ref omitted on arguments.*
- **CS7053** - *An expression tree may not contain "feature".*
- **CS8072** - *An expression tree lambda may not contain a null propagating operator.*
- **CS8074** - *An expression tree lambda may not contain a dictionary initializer.*
- **CS8075** - *An extension `Add` method is not supported for a collection initializer in an expression lambda.*
- **CS8110** - *An expression tree may not contain a reference to a local function.*
- **CS8122** - *An expression tree may not contain an '`is`' pattern-matching operator.*
- **CS8143** - *An expression tree may not contain a tuple literal.*
- **CS8144** - *An expression tree may not contain a tuple conversion.*
- **CS8153** - *An expression tree lambda may not contain a call to a method, property, or indexer that returns by reference.*
- **CS8155** - *Lambda expressions that return by reference cannot be converted to expression trees.*
- **CS8188** - *An expression tree may not contain a throw-expression.*
- **CS8198** - *An expression tree may not contain an out argument variable declaration.*
- **CS8207** - *An expression tree may not contain a discard.*
- **CS8382** - *An expression tree may not contain a tuple `==` or `!=` operator.*
- **CS8514** - *An expression tree may not contain a switch expression.*
- **CS8640** - *Expression tree cannot contain value of ref struct or restricted type.*
- **CS8642** - *An expression tree may not contain a null coalescing assignment.*
- **CS8790** - *An expression tree may not contain a pattern <xref:System.Index?displayProperty=fullName> or <xref:System.Range?displayProperty=fullName> indexer access.*
- **CS8791** - *An expression tree may not contain a from-end index ('`^`') expression.*
- **CS8792** - *An expression tree may not contain a range ('`..`') expression.*
- **CS8810** - *'`&`' on method groups cannot be used in expression trees.*
- **CS8849** - *An expression tree may not contain a `with`-expression.*
- **CS8927** - *An expression tree may not contain an access of static virtual or abstract interface member.*
- **CS8952** - *An expression tree may not contain an interpolated string handler conversion.*
- **CS8972** - *A lambda expression with attributes cannot be converted to an expression tree.*
- **CS9170** - *An expression tree may not contain an inline array access or conversion.*
- **CS9175** - *An expression tree may not contain a collection expression.*
- **CS9226** - *An expression tree may not contain an expanded form of non-array params collection parameter.*
- **CS9296** - *An expression tree may not contain an extension property access*.
- **CS9307** - *An expression tree may not contain a named argument specification out of position*.

## Expression tree restrictions

All of the errors in the preceding list indicate you've used a C# expression type that isn't allowed in an expression tree. In most cases, the prohibited expressions represent syntax introduced after C# 3.0. These expressions are prohibited because allowing them would create a breaking change in all libraries that parse expression trees. All libraries would need to be enhanced to parse new C# expressions if newer constructs were allowed.

The following expressions are prohibited:

- Invocations of [partial methods](../keywords/partial-member.md) that don't have an implementing declaration.
- Invocations of [conditional methods](../preprocessor-directives.md#conditional-compilation) that have been removed.
- Invocations of [local functions](../../programming-guide/classes-and-structs/local-functions.md).
- `async` lambda expressions aren't allowed.
- Using [`base`](../keywords/base.md) access to directly call a virtual method declared in a base class.
- [assignment](../operators/assignment-operator.md) operations.
- [statement lambdas](../operators/lambda-expressions.md#statement-lambdas) aren't allowed.
- [multi-dimensional array](../builtin-types/arrays.md#multidimensional-arrays) initializers. Instead, you must create and initialize a multi-dimensional array outside of the expression tree.
- [`dynamic`](../builtin-types/reference-types.md#the-dynamic-type) operations aren't allowed.
- [pattern matching](../operators/patterns.md) expressions aren't allowed.
- [Tuple literals](../builtin-types/value-tuples.md) and many tuple operations, such as equality comparisons aren't allowed.
- [`throw` expressions](../statements/exception-handling-statements.md#the-throw-expression) aren't allowed.
- [discard](../../fundamentals/functional/discards.md) (`_`) declarations.
- The [index and range](../operators/member-access-operators.md#indexer-access) operators aren't allowed.
- Non-destructive mutation using [`with`](../operators/with-expression.md) expressions aren't allowed.
- You can't declare or access [inline arrays](../builtin-types/struct.md#inline-arrays).
- You can't include [collection expressions](../operators/collection-expressions.md).
- The [null propagating](../operators/member-access-operators.md#null-conditional-operators--and-) and [null coalescing](../operators/assignment-operator.md#null-coalescing-assignment) operators aren't allowed.
- [`ref struct`](../builtin-types/ref-struct.md) types, such as <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> aren't allowed.
- `in`, `out`, and `ref` parameters, including `out` variable declarations, aren't allowed.
- `ref` returns aren't allowed.
- Calls to methods that return by `ref` aren't allowed.
- [static abstract interface members](../keywords/interface.md#static-abstract-and-virtual-members) can't be accessed.
- [Inline arrays](../builtin-types/struct.md#inline-arrays).
- The `params` modifier is allowed only on single-dimensional arrays. Other collection types aren't allowed.

Other restrictions are:

- Extension properties can't be accessed as extensions.
- Attributes can't be applied to the lambda expression, its parameters or return.
- The lambda expression must be convertible to a type derived from <xref:System.Linq.Expressions.Expression?displayProperty=fullName> whose type parameter is a delegate type.
- [named and optional parameters](../../programming-guide/classes-and-structs/named-and-optional-arguments.md) are restricted. The expression can't call a method specifying named arguments, and it can't use the default value of an optional parameter.
- [Dictionary initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md#collection-initializers) aren't allowed. Neither are extension `Add` methods.
- The target expression must be a lambda expression. Constants and variables aren't allowed, but a lambda expression that returns a constant or variable is.
- Unsafe pointer operations aren't allowed.
- COM calls must include `ref` on arguments; it can't be implied.
- The unsupported `__arglist` keyword isn't allowed.

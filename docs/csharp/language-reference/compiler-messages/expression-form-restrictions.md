---
title: "Resolve errors from invalid expression contexts"
description: "This article helps you diagnose and correct compiler errors and warnings from expressions that appear in contexts where they are not permitted"
f1_keywords:
  - "CS8115"
  - "CS8185"
  - "CS8209"
  - "CS8310"
  - "CS8312"
helpviewer_keywords:
  - "CS8115"
  - "CS8185"
  - "CS8209"
  - "CS8310"
  - "CS8312"
ms.date: 08/20/2026
ai-usage: ai-assisted
---

# Resolve errors from invalid expression contexts

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS8115**](#throw-expressions-in-expression-contexts): *A throw expression is not allowed in this context.*
- [**CS8185**](#declaration-expressions-in-restricted-contexts): *A declaration is not allowed in this context.*
- [**CS8209**](#void-returning-expression-restrictions): *A value of type 'void' may not be assigned.*
- [**CS8310**](#type-binding-for-default-literals-and-typeless-expressions): *Operator 'operator' cannot be applied to operand 'operand'*
- [**CS8312**](#type-binding-for-default-literals-and-typeless-expressions): *Use of default literal is not valid in this context*

## Throw expressions in expression contexts

- **CS8115**: *A throw expression is not allowed in this context.*

The compiler permits throw expressions only in specific contexts where an expression can appear and the exception is immediately propagated. Move the `throw` expression to a valid context, such as:

- A conditional arm of a ternary or switch expression (where the throw is one of the arms).
- An assignment to evaluate the throw in place of the assigned value.
- An argument to a method call where throwing is appropriate.
- A statement in a lambda or local function body (not within a method that must return a value).

If the throw expression appears in a position where the expression value must be used (such as within arithmetic or operator expressions), extract it into a separate statement or conditional check.

## Declaration expressions in restricted contexts

- **CS8185**: *A declaration is not allowed in this context.*

The compiler permits declaration expressions (`out var`, pattern-matching declarations) only in specific positions. These include `out` parameter declarations in method calls and in certain statement contexts. Remove the declaration expression from contexts where it's not permitted, such as:

- Lambda expression bodies (unless the lambda is a statement body).
- Query expressions where the grammar forbids declarations.
- Inside attribute arguments.
- In contexts that require a read-only expression.

If you need to use an out variable, call the method in a separate statement, then reference the resulting variable. Alternatively, use a local variable declaration before the expression.

## Type binding for default literals and typeless expressions

- **CS8310**: *Operator 'operator' cannot be applied to operand 'operand'*
- **CS8312**: *Use of default literal is not valid in this context*

The `default` literal and typeless expressions (such as `null` or `new` without a target type) require a target type for the compiler to infer the expression type. When an operator is applied to these expressions without enough context, the compiler cannot determine the operand type.

Provide the target type by:

- Adding an explicit type cast: `(int)default` or `(MyType)new`.
- Assigning to a typed variable: `int x = default;`.
- Using a method parameter or return type to establish context.
- Using the verbose form `default(Type)` instead of the `default` literal for clarity.

If the operator itself requires a specific type, ensure the operand can be implicitly converted to that type.

## Void-returning expression restrictions

- **CS8209**: *A value of type 'void' may not be assigned.*

The `void` type is not a value type; it represents the absence of a return value. Remove the assignment of void-returning expressions. If you need to invoke a method that returns `void`, call it as a standalone statement. If you need a result, use a method that returns a value instead.

Ensure that expressions assigned to variables always have a meaningful return type.

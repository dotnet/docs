---
title: "Resolve errors and warnings related to `new` expressions and object creation expressions"
description: "This article helps you diagnose and correct compiler errors and warnings related to `new` expressions and object creation expressions"
f1_keywords:
  - "CS0144"
  - "CS0712"
  - "CS1526"
  - "CS8181"
  - "CS8386"
  - "CS8752"
  - "CS8753"
  - "CS8754"
helpviewer_keywords:
  - "CS0144"
  - "CS0712"
  - "CS1526"
  - "CS8181"
  - "CS8386"
  - "CS8752"
  - "CS8753"
  - "CS8754"
ms.date: 05/15/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for `new` expressions and object creation

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0144**](#types-that-cannot-be-instantiated): *Cannot create an instance of the abstract type or interface 'type'*
- [**CS0712**](#types-that-cannot-be-instantiated): *Cannot create an instance of the static class 'type'*
- [**CS1526**](#new-expression-syntax-errors): *A new expression requires an argument list or (), [], or {} after type*
- [**CS8181**](#new-expression-syntax-errors): *'new' cannot be used with tuple type. Use a tuple literal expression instead.*
- [**CS8386**](#new-expression-syntax-errors): *Invalid object creation*
- [**CS8752**](#target-typed-new-expressions): *The type 'type' may not be used as the target type of new()*
- [**CS8753**](#target-typed-new-expressions): *Use of new() is not valid in this context*
- [**CS8754**](#target-typed-new-expressions): *There is no target type for 'expression'*

## Types that cannot be instantiated

- **CS0144**: *Cannot create an instance of the abstract type or interface 'type'*
- **CS0712**: *Cannot create an instance of the static class 'type'*

The `new` operator can only create instances of concrete, non-static types. The language prohibits instantiating abstract classes, interfaces, and static classes because these types are incomplete or aren't designed to have instances.

- Create a concrete class that derives from the abstract class, or create a class that implements the interface, then instantiate that concrete type (**CS0144**). You can't use `new` directly on an `abstract` class or an `interface` because they don't provide complete implementations. If you own the type, you can also remove the `abstract` modifier to make the class directly instantiable.
- Remove the `new` expression and access the static class members directly through the class name (**CS0712**). Static classes exist solely to group static members and can't be instantiated. If you need an instance, remove the `static` modifier from the class declaration.

For more information, see [abstract](../keywords/abstract.md), [interface](../keywords/interface.md), and [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

## `new` expression syntax errors

- **CS1526**: *A new expression requires an argument list or (), [], or {} after type*
- **CS8181**: *'new' cannot be used with tuple type. Use a tuple literal expression instead.*
- **CS8386**: *Invalid object creation*

These errors occur when the syntax of a `new` expression is malformed or when you use `new` with a type that requires a different creation syntax.

- Add an argument list `()`, array dimensions `[]`, or an initializer `{}` after the type name in a `new` expression (**CS1526**). The `new` operator requires one of these to indicate how the object is constructed. For example, write `new MyClass()` instead of `new MyClass`.
- Replace `new (int, string)(...)` with a tuple literal expression like `(1, "hello")` (**CS8181**). Tuple types use a dedicated literal syntax rather than the `new` operator. To create a tuple, use parenthesized values directly: `(int X, string Y) point = (1, "hello");`.
- Ensure the `new` expression targets a valid constructible type (**CS8386**). This error occurs when the compiler can't determine a valid object creation from the syntax. Verify you're using a type name that supports construction, and that the expression is syntactically complete.

For more information, see [new operator](../operators/new-operator.md) and [Tuple types](../builtin-types/value-tuples.md).

## Target-typed `new` expressions

- **CS8752**: *The type 'type' may not be used as the target type of new()*
- **CS8753**: *Use of new() is not valid in this context*
- **CS8754**: *There is no target type for 'expression'*

Target-typed `new` expressions (introduced in C# 9) let you omit the type name when the compiler can infer it from context, as in `MyClass x = new();`. These errors occur when the compiler can't determine a valid target type or when the inferred type isn't constructible.

- Use an explicit type name instead of target-typed `new()` when the target type is an interface, abstract class, static class, or other non-constructible type (**CS8752**). Target-typed `new()` infers the type from the left-hand side, but the inferred type must be a concrete, instantiable type. Write the full `new ConcreteType()` instead.
- Move the `new()` expression to a context where a target type is available (**CS8753**). Target-typed `new` is valid only in contexts where the compiler can determine a type, such as variable declarations with an explicit type, assignment expressions, return statements with a known return type, or argument positions with a known parameter type. You can't use `new()` in contexts like `var x = new();` where no target type exists.
- Provide an explicit type for the `new` expression when no target type can be inferred (**CS8754**). This error occurs when you use `new()` in a position where the compiler has no way to determine what type to construct. Replace `new()` with `new ExplicitType()`, or declare the variable with an explicit type rather than `var`.

For more information, see [Target-typed new expressions](../operators/new-operator.md#target-typed-new) and [C# 9 - Target-typed new expressions](../../whats-new/csharp-9.md#target-typed-new-expressions).

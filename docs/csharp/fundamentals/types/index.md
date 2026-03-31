---
title: "The C# type system"
description: Learn about the C# type system, including value types, reference types, the common type system, and how to choose the right type construct for your code.
ms.date: 03/24/2026
ms.topic: overview
ai-usage: ai-assisted
---
# The C# type system

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. They walk you through writing programs and introduce types as you go.
>
> **Experienced in another language?** If you already understand type systems, skim the [value vs. reference](#value-types-and-reference-types) distinction and the [choose which kind of type](#choose-which-kind-of-type) guide, then jump to the articles on specific types.

C# is a strongly typed language. Every variable, constant, and expression has a type. The compiler enforces *type safety* by checking that every operation in your code is valid for the types involved. For example, you can add two `int` values, but you can't add an `int` and a `bool`:

:::code language="csharp" source="snippets/index/Program.cs" ID="TypeSafety":::

> [!NOTE]
> Unlike C and C++, in C#, `bool` isn't convertible to `int`.

Type safety catches errors at compile time, before your code runs. The compiler also embeds type information into the executable as metadata, which the common language runtime (CLR) uses for additional safety checks at run time.

## Declare variables with types

When you declare a variable, you specify its type explicitly or use `var` to let the compiler infer the type from the assigned value:

:::code language="csharp" source="snippets/index/Program.cs" ID="Declarations":::

Method parameters and return values also have types. The following method takes a `string` and an `int`, and returns a `string`:

:::code language="csharp" source="snippets/index/Program.cs" ID="MethodSignature":::

After you declare a variable, you can't change its type or assign a value that's incompatible with the declared type. You can convert values to other types. The compiler performs *implicit conversions* that don't lose data automatically. *Explicit conversions* (casts) require you to indicate the conversion in your code. For more information, see [Casting and type conversions](../../programming-guide/types/casting-and-type-conversions.md).

## Built-in types and custom types

C# provides [built-in types](built-in-types.md) for common data: integers, floating-point numbers, `bool`, `char`, and `string`. Every C# program can use these built-in types without any extra references.

Beyond built-in types, you can create your own types by using several constructs:

- [**Classes**](classes.md) — Reference types for modeling behavior and complex objects. Support inheritance and polymorphism.
- [**Structs**](../../language-reference/builtin-types/struct.md) — Value types for small, lightweight data. Each variable holds its own copy.
- [**Records**](records.md) — Classes or structs with compiler-generated equality, `ToString`, and nondestructive mutation through `with` expressions.
- [**Interfaces**](interfaces.md) — Contracts that define members any class or struct can implement.
- [**Enumerations**](enums.md) — Named sets of integral constants, such as days of the week or file access modes.
- [**Tuples**](../../language-reference/builtin-types/value-tuples.md) — Lightweight structural types that group related values without defining a named type.
- [**Generics**](generics.md) — Type-parameterized constructs like `List<T>` and `Dictionary<TKey, TValue>` that provide type safety while reusing the same logic for different types.

## Value types and reference types

Every type in C# is either a *value type* or a *reference type*. This distinction determines how variables store data and how assignment works.

**Value types** hold their data directly. When you assign a value type to a new variable, the runtime copies the data. Changes to one variable don't affect the other. Structs, enums, and the built-in numeric types are all value types.

**Reference types** hold a reference to an object on the managed heap. When you assign a reference type to a new variable, both variables point to the same object. Changes through one variable are visible through the other. Classes, arrays, delegates, and strings are reference types.

The following example shows the difference. The first block shows the definition for the `Coords` record struct, which is a value type. The second block shows the different behavior for value types and reference types.

:::code language="csharp" source="snippets/index/Program.cs" ID="Coords":::

:::code language="csharp" source="snippets/index/Program.cs" ID="ValueVsReference":::

All types ultimately derive from <xref:System.Object?displayProperty=nameWithType>. Value types derive from <xref:System.ValueType?displayProperty=nameWithType>, which derives from `object`. This unified hierarchy is called the [Common Type System](../../../standard/base-types/common-type-system.md) (CTS). For more information about inheritance, see [Inheritance](../object-oriented/inheritance.md).

## Choose which kind of type

When you define a new type, the kind you choose shapes how your code behaves. Use the following guidelines to make an initial decision:

- **Tuple** — Temporary grouping of values that doesn't need a named type or behavior.
- **`struct`** or **`record struct`** — Small data (roughly 64 bytes or less), value semantics, or immutability. Record structs add value-based equality and `with` expressions.
- **`record class`** — Primarily data, with value-based equality, `ToString`, and nondestructive mutation. Supports inheritance.
- **`class`** — Complex behavior, polymorphism, or mutable state. Most custom types are classes.
- **`interface`** — A contract that unrelated types can implement. Defines capabilities rather than identity.
- **`enum`** — A fixed set of named constants, such as status codes or options.

More than one option is often reasonable.

## Compile-time type and run-time type

A variable can have different types at compile time and run time. The *compile-time type* is the declared or inferred type in source code. The *run-time type* is the actual type of the instance the variable refers to. The run-time type must be the same as the compile-time type, or a type that derives from it or implements it. An assignment is only valid when an implicit conversion exists from the run-time type to the compile-time type, such as an identity, reference, boxing, or numeric conversion.

:::code language="csharp" source="snippets/index/Program.cs" ID="CompileVsRuntime":::

In the preceding example, `boxed` has a compile-time type of `object` but a run-time type of `string`. The assignment works because `string` derives from `object`. Similarly, `characters` has a compile-time type of `IEnumerable<char>`, and the assignment works because `string` implements that interface. The compile-time type controls overload resolution and available conversions. The run-time type controls virtual method dispatch, `is` expressions, and `switch` expressions.

## See also

- [Value types](../../language-reference/builtin-types/value-types.md)
- [Reference types](../../language-reference/keywords/reference-types.md)
- [Common Type System](../../../standard/base-types/common-type-system.md)

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

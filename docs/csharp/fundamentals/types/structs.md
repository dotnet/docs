---
title: "C# structs"
description: Learn how to define and use structs in C#, including value semantics, parameterless constructors, auto-default behavior, readonly members, and record structs.
ms.date: 03/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
---
# C# structs

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You'll encounter structs once you need lightweight value types in your code.
>
> **Experienced in another language?** C# structs are value types similar to structs in C++ or Swift, but they live on the managed heap when boxed and support interfaces, constructors, and methods. Skim the [readonly structs](#readonly-structs-and-readonly-members) and [record structs](#record-structs) sections for C#-specific patterns.

A *struct* is a value type that holds its data directly in the variable, rather than through a reference to an object on the heap. When you assign a struct to a new variable, the runtime copies the entire value. Changes to one variable don't affect the other. Use structs for small, lightweight data where identity isn't important—coordinates, colors, measurements, or configuration settings.

## Declare a struct

Define a struct with the `struct` keyword. A struct can contain fields, properties, methods, and constructors, just like a class:

:::code language="csharp" source="snippets/structs/Program.cs" ID="BasicStruct":::

The `Point` struct stores two `double` values and provides a method to calculate the distance between two points. The `DistanceTo` method is marked `readonly` because it doesn't modify the struct's state—a pattern covered in [readonly members](#readonly-structs-and-readonly-members).

## Value semantics

Structs are *value types*. Assignment copies the data, so each variable holds its own independent copy:

:::code language="csharp" source="snippets/structs/Program.cs" ID="ValueSemantics":::

This copy-on-assignment behavior differs from [classes](classes.md), where assignment copies only the reference. Both variables then point to the same object. For more on the distinction, see [Value types and reference types](index.md#value-types-and-reference-types).

## Struct constructors

You can define constructors in structs the same way you do in classes. Starting with C# 10, structs can have *parameterless constructors* that set custom default values:

:::code language="csharp" source="snippets/structs/Program.cs" ID="ParameterlessConstructor":::

A parameterless constructor runs when you use `new` with no arguments. The `default` expression bypasses the constructor and sets all fields to their default values (`0`, `null`, `false`). Be aware of the difference:

:::code language="csharp" source="snippets/structs/Program.cs" ID="DefaultVsConstructor":::

## Auto-default structs

Starting with C# 11, the compiler automatically initializes any fields you don't explicitly set in a constructor. Before C# 11, every field had to be assigned before the constructor returned. Now you can initialize only the fields that need non-default values:

:::code language="csharp" source="snippets/structs/Program.cs" ID="AutoDefault":::

:::code language="csharp" source="snippets/structs/Program.cs" ID="UsingAutoDefault":::

The `IsBlocked` property isn't assigned in the constructor, so the compiler sets it to `false` (the default for `bool`). This feature reduces boilerplate in constructors that only need to set a few fields.

## Readonly structs and readonly members

A `readonly struct` guarantees that no instance member modifies the struct's state. The compiler enforces this guarantee by requiring all fields and auto-implemented properties to be read-only:

:::code language="csharp" source="snippets/structs/Program.cs" ID="ReadonlyStruct":::

:::code language="csharp" source="snippets/structs/Program.cs" ID="UsingReadonly":::

When you don't need the entire struct to be immutable, you can mark individual members as `readonly` instead. A `readonly` member can't modify the struct's state, and the compiler verifies that guarantee:

:::code language="csharp" source="snippets/structs/Program.cs" ID="ReadonlyMembers":::

:::code language="csharp" source="snippets/structs/Program.cs" ID="UsingReadonlyMembers":::

Marking members `readonly` helps the compiler optimize defensive copies. When you pass a `readonly` struct to a method that accepts an `in` parameter, the compiler knows no copy is needed.

## Record structs

A `record struct` combines value type semantics with the compiler-generated members that records provide—value equality, formatted `ToString`, and nondestructive mutation through `with` expressions. Declare a record struct with positional parameters for concise syntax:

:::code language="csharp" source="snippets/structs/Program.cs" ID="RecordStruct":::

The compiler generates properties, `Equals`, `GetHashCode`, `ToString`, and a `Deconstruct` method from the positional parameters:

:::code language="csharp" source="snippets/structs/Program.cs" ID="UsingRecordStruct":::

You can also deconstruct a positional record struct into individual variables:

:::code language="csharp" source="snippets/structs/Program.cs" ID="RecordStructDeconstruct":::

Record structs are mutable by default, unlike `record class` types, which use `init`-only properties. Add the `readonly` modifier (`readonly record struct`) when you want immutability. For a deeper look at records, including record classes, inheritance, and customization, see [Records](records.md).

## Choose structs or classes

Use a struct when your type:

- Represents a single value or a small group of related values (roughly 16 bytes or less).
- Has value semantics—two instances with the same data should be equal.
- Doesn't need inheritance from a base type (structs can't inherit from other structs or classes, but they can implement interfaces).

Use a class when your type has complex behavior, needs inheritance, or when instances represent a shared identity rather than a copied value. For a broader comparison that includes records, tuples, and interfaces, see [Choose which kind of type](index.md#choose-which-kind-of-type).

## See also

- [Type system overview](index.md)
- [Classes](classes.md)
- [Records](records.md)
- [Structure types (C# reference)](../../language-reference/builtin-types/struct.md)

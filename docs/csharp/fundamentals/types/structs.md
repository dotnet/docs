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
> **Experienced in another language?** C# structs are value types similar to structs in C++ or Swift, but they live on the managed heap when boxed and support interfaces, constructors, and methods. Skim the [readonly structs](#readonly-structs-and-readonly-members) section for C#-specific patterns. For record structs, see [Records](records.md).

A *struct* is a value type that holds its data directly in the instance, rather than through a reference to an object on the heap. When you assign a struct to a new variable, the runtime copies the entire instance. Changes to one variable don't affect the other because each variable represents a different instance. Use structs for small, lightweight types whose primary role is storing data rather than modeling behavior. Examples include coordinates, colors, measurements, or configuration settings.

## When to use structs

Use a struct when your type:

- Represents a single value or a small group of related values (roughly 16 bytes or less).
- Has value semantics—two instances with the same data should be equal.
- Is primarily a data container rather than a model of behavior.
- Doesn't need inheritance from a base type (structs can't inherit from other structs or classes, but they can implement interfaces).

For a broader comparison that includes classes, records, tuples, and interfaces, see [Choose which kind of type](index.md#choose-which-kind-of-type).

## Declare a struct

Define a struct with the `struct` keyword. A struct can contain fields, properties, methods, and constructors, just like a class:

:::code language="csharp" source="snippets/structs/Program.cs" ID="BasicStruct":::

The `Point` struct stores two `double` values and provides a method to calculate the distance between two points. The `DistanceTo` method is marked `readonly` because it doesn't modify the struct's state. That pattern is covered in [readonly members](#readonly-structs-and-readonly-members).

## Value semantics

Structs are *value types*. Assignment copies the data, so each variable holds its own independent copy:

:::code language="csharp" source="snippets/structs/Program.cs" ID="ValueSemantics":::

Because structs are data containers, assignment copies every data member into a new, independent instance. Each copy is distinct. Modifying one doesn't affect the other. This behavior differs from [classes](classes.md), where assignment copies only the reference and both variables share the same object. For more on the distinction, see [Value types and reference types](index.md#value-types-and-reference-types).

## Struct constructors

You can define constructors in structs the same way you do in classes. Structs can have *parameterless constructors* that set custom default values. The term "parameterless constructor" distinguishes an instance created with `new` (which runs your constructor logic) from a *default* instance created with the `default` expression (which zero-initializes all fields):

:::code language="csharp" source="snippets/structs/Program.cs" ID="ParameterlessConstructor":::

A parameterless constructor runs when you use `new` with no arguments. The `default` expression bypasses the constructor and sets all fields to their default values (`0`, `null`, `false`). Be aware of the difference:

:::code language="csharp" source="snippets/structs/Program.cs" ID="DefaultVsConstructor":::

The compiler automatically initializes any fields you don't explicitly set in a constructor. You can initialize only the fields that need non-default values:

:::code language="csharp" source="snippets/structs/Program.cs" ID="AutoDefault":::

The following example displays the default value for `IsBlocked`:

:::code language="csharp" source="snippets/structs/Program.cs" ID="UsingAutoDefault":::

The `IsBlocked` property isn't assigned in the constructor, so the compiler sets it to `false` (the default for `bool`). This feature reduces boilerplate in constructors that only need to set a few fields.

## Readonly structs and readonly members

A `readonly struct` guarantees that no instance member modifies the struct's state. The compiler enforces this guarantee by requiring all fields and auto-implemented properties to be read-only:

:::code language="csharp" source="snippets/structs/Program.cs" ID="ReadonlyStruct":::

The following example creates a `Temperature` instance and reads its properties:

:::code language="csharp" source="snippets/structs/Program.cs" ID="UsingReadonly":::

When you don't need the entire struct to be immutable, mark individual members as `readonly` instead. A `readonly` member can't modify the struct's state, and the compiler verifies that guarantee:

:::code language="csharp" source="snippets/structs/Program.cs" ID="ReadonlyMembers":::

The following example shows that `readonly` members return updated values when mutable properties change:

:::code language="csharp" source="snippets/structs/Program.cs" ID="UsingReadonlyMembers":::

Marking members `readonly` helps the compiler optimize defensive copies. When you pass a `readonly` struct to a method that accepts an `in` parameter, the compiler knows no copy is needed.

## See also

- [Type system overview](index.md)
- [Classes](classes.md)
- [Records](records.md)
- [Structure types (C# reference)](../../language-reference/builtin-types/struct.md)

---
title: Explore union types in C#
description: "Union types let a single value hold one of a fixed set of types. Learn to declare union types, match their cases exhaustively, build custom unions, and use unions with generics."
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 07/02/2026
ai-usage: ai-assisted
#customer intent: As a C# developer, I model a value that can be one of several types so the compiler enforces that I handle every case.
---
# Tutorial: Explore C# union types

A *union type* holds a single value that's one of a fixed set of types. Those types typically aren't related by inheritance, so a union lets you group unrelated types without forcing them into a common base class or interface. Unions are useful when a value is conceptually "one of these," such as a sensor reading that's a number, a switch state, or a status message. Because the set of cases is fixed, the compiler can verify that you handle every case when you read the value.

In this tutorial, you build the readings layer of a smart-home telemetry monitor. You declare union types for sensor data, you replace a hand-rolled result type with a union, and you create a custom union for performance-sensitive code.

In this tutorial, you:

> [!div class="checklist"]
>
> * Declare union types and match their cases exhaustively.
> * Handle null contents in a union.
> * Add members and use generics with union declarations.
> * Build a custom union type that avoids boxing.

## Prerequisites

This tutorial uses preview language features. You need an SDK that supports union types and a language version set to `preview`.

- The .NET 11 SDK that includes the union types preview feature. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet).
- An editor such as Visual Studio or Visual Studio Code with the C# Dev Kit.

> [!IMPORTANT]
> Union types are a preview feature. The syntax and supporting types can change before the feature ships. Set `<LangVersion>preview</LangVersion>` in your project to enable it.

## Create the sample solution

You build a class library, `SmartHome.Core`, that holds the union types, and a console app, `SmartHome.App`, that exercises them.

1. Create the solution and projects:

   ```dotnetcli
   dotnet new sln -n TelemetryMonitor
   dotnet new classlib -n SmartHome.Core
   dotnet new console -n SmartHome.App
   dotnet sln add SmartHome.Core SmartHome.App
   dotnet add SmartHome.App reference SmartHome.Core
   ```

1. In each project file, set the language version to `preview`:

   ```xml
   <PropertyGroup>
     <LangVersion>preview</LangVersion>
   </PropertyGroup>
   ```

## Declare a union type

Start with the raw sensor data. A reading arrives as a number, a switch state, or a status message, so you model it as a union of those three types.

1. In `SmartHome.Core`, add a file named `Readings.cs` and declare the `Reading` union. A *union declaration* lists the case types in parentheses:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Readings.cs" id="ReadingUnion":::

1. In the same file, add a method that reads a `Reading` by switching over its case types:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Readings.cs" id="ReadingConsume":::

Each type pattern applies to the union's *contents*, not to the `Reading` instance, because most patterns unwrap the union. The `string?` case is nullable, so the compiler treats null as a distinct case and requires the `null` arm. The switch is exhaustive: if you remove any arm, the compiler reports that a case isn't covered. That guarantee is one benefit of a union. When you add a case type later, every switch that reads the union flags the missing arm. For more information, see [Union exhaustiveness](../../language-reference/builtin-types/union.md#union-exhaustiveness) and [Union patterns](../../language-reference/operators/patterns.md#union-patterns).

## Migrate a result type to a generic union

When a sensor read can fail, you need a type that carries either a value or an error. Many codebases model that type with a class that exposes a success flag and two fields. Replace that class with a generic union.

1. In `SmartHome.Core`, add a file named `Result.cs` with the hand-rolled result class that the migration replaces:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Result.cs" id="ResultBefore":::

1. Replace that class with a generic union. A `Result<T>` holds either a `T` or an `Exception`:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Result.cs" id="ResultUnion":::

1. Add a method that reads the result by switching over its case types:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Result.cs" id="ResultConsume":::

The original class lets a caller incorrectly read `Value` on a failure or `Error` on a success. The union removes those invalid states: a `Result<T>` is either a `T` that holds the successful result or an `Exception` that explains why the operation failed. Each case converts to the union implicitly, so you assign an instance of `T` or an instance of `Exception` directly to a `Result<T>`. When you read the result, a switch verifies that you handle the success value, the failure, and null. For more information, see [Union declarations](../../language-reference/builtin-types/union.md#union-declarations) and [Union conversions](../../language-reference/builtin-types/union.md#union-conversions).

## Reuse a generic union across numeric types

Sensors report at different resolutions: a contact sensor uses a `byte`, a position sensor uses a `short`, and a counter uses an `int`. Rather than write a union per type, write one generic union and instantiate it with each numeric type.

1. In `SmartHome.Core`, add a file named `Sample.cs` and declare the `Sample<T>` union. It holds either an in-range reading of type `T` or a `Saturated` marker for a sensor that railed. Give the union a body that adds an `InRange` property:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Sample.cs" id="SampleUnion":::

1. Add a `Normalize` method that scales any reading to a fraction of full scale:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Sample.cs" id="SampleConsume":::

The `where T : struct, INumber<T>` constraint keeps `T` a non-nullable numeric value type and lets a single method process every numeric width through <xref:System.Numerics.INumber`1> arithmetic. The same `Normalize` method works for a `Sample<byte>`, a `Sample<short>`, or a `Sample<int>`. Because `Saturated` is a value type and `T` is constrained to a value type, neither case is nullable, so the switch is exhaustive without a null arm. The `InRange` property shows that a union declaration can carry its own members and pattern over `this`. For more information, see [Union declarations](../../language-reference/builtin-types/union.md#union-declarations).

## Build a custom union that avoids boxing

A union declaration is a struct that stores its value in a single `object?` field, so a value-type case boxes when you store it. For performance-sensitive code, implement the union pattern by hand to store the value without boxing.

1. In `SmartHome.Core`, add a file named `Quantity.cs`. Apply the `[Union]` attribute to a struct, and provide the access members the compiler uses to match each case:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Quantity.cs" id="QuantityUnion":::

1. Add a method that consumes the custom union the same way you consume a union declaration:

   :::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Quantity.cs" id="QuantityConsume":::

The `HasValue` property and the `TryGetValue` overloads let the compiler match each case without boxing. The struct stores the value in a `double` field and a discriminator, so neither the `int` case nor the `double` case allocates. The switch over `int` and `double` is exhaustive, and no null arm is needed because neither case type is nullable. For more information, see [Custom union types](../../language-reference/builtin-types/union.md#custom-union-types).

> [!NOTE]
> Another scenario for a custom union is to add language support to an existing type that models a union. If your app has union-like types you created before C# had `union` types, apply the `Union` attribute and implement the `IUnion` interface on those types. The compiler then gives your custom type the same language support as a union declaration. For details, see the [Unions feature specification](~/_csharplang/proposals/unions.md).

## Run the sample

The console app drives each union. Replace the contents of `Program.cs`:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.App/Program.cs" id="UnionMain":::

Run the app:

```dotnetcli
dotnet run --project SmartHome.App
```

The readings, results, samples, and quantities each print through their exhaustive switches:

```output
Reading: 23.5
Reading: on
Reading: offline
Reading: no reading
Success: 42
Failure: sensor timed out
Sample: 78% (in range: True)
Sample: 100% (in range: False)
3 items
2.50 units
```

## Summary

You built the readings layer of a smart-home telemetry monitor and, in the process, worked through the core union scenarios. You:

- Declared a `Reading` union and read it with an exhaustive switch, letting the compiler flag any case you don't handle.
- Handled a nullable case, where the compiler requires a `null` arm.
- Replaced a hand-rolled result type with a generic `Result<T>` union that models success or failure without invalid states.
- Reused a generic `Sample<T>` union across several numeric types with a constraint, and added members to the union declaration.
- Built a custom `[Union]` struct that avoids boxing for performance-sensitive code.

## Related content

- [Closed hierarchies tutorial](closed-hierarchies.md)
- [Pattern matching overview](../../fundamentals/functional/pattern-matching.md)
- [What's new in C# 15](../csharp-15.md)

---
title: Explore union types in C#
description: "Union types let a single value hold one of a fixed set of types. Learn to declare union types, match their cases exhaustively, build custom unions, and use unions with generics."
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 02/16/2026
ai-usage: ai-assisted
#customer intent: As a C# developer, I model a value that can be one of several types so the compiler enforces that I handle every case.
---
# Tutorial: Explore C# union types

A *union type* holds a single value that's one of a fixed set of types. Unions are useful when a value is conceptually "one of these," such as a sensor reading that's a number, a switch state, or a status message. Because the set of cases is fixed, the compiler can verify that you handle every case when you read the value.

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

- The .NET SDK that includes the union types preview feature. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet).
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

A *union declaration* lists the case types in parentheses. The following declaration says a `Reading` holds a `double`, a `bool`, or a `string`:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Readings.cs" id="ReadingUnion":::

The `string?` case is nullable, so the contents of a `Reading` can be null. The compiler treats null as a distinct case you must handle.

To read a union, switch over the case types. Each type pattern applies to the union's *contents*, not to the `Reading` value:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Readings.cs" id="ReadingConsume":::

The switch is exhaustive. Because `string?` is nullable, the compiler requires the `null` arm. If you remove any arm, the compiler reports that a case isn't covered. That guarantee is the central benefit of a union: when you add a case type later, every switch that reads the union flags the missing arm.

## Migrate a result type to a generic union

Unions work well with generics. A common pattern is a result type that holds either a success value or an error. Many codebases model that with a class that exposes a success flag and two fields:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Result.cs" id="ResultBefore":::

Nothing stops a caller from reading `Value` on a failure or `Error` on a success. A generic union expresses the same intent and removes the invalid states. A `Result<T>` holds either a `T` or an `Exception`:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Result.cs" id="ResultUnion":::

To read the result, switch over the case types. The compiler verifies that you handle the value, the error, and null:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Result.cs" id="ResultConsume":::

A value converts to the union implicitly, so you assign a `T` or an `Exception` directly to a `Result<T>`.

## Add members to a union

A union declaration can include a body with members. The following generic union normalizes a value that's either a single item or a sequence. Its `AsEnumerable` method switches over `this` to return a uniform sequence:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Readings.cs" id="OneOrMore":::

The `null` arm handles the default value of the union. Because a union is a struct, an uninitialized `OneOrMore<T>` has null contents, so the switch must cover that case.

## Build a custom union that avoids boxing

A union declaration lowers to a struct that stores its value in a single `object?` field, so a value-type case boxes when you store it. For performance-sensitive code, you can implement the union pattern by hand to store the value without boxing. Apply the `[Union]` attribute to the struct, and provide the access members the compiler uses to match each case:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Quantity.cs" id="QuantityUnion":::

The `HasValue` property and the `TryGetValue` overloads let the compiler match each case without boxing. The struct stores the value in a `double` field and a discriminator, so neither the `int` case nor the `double` case allocates.

You consume a custom union the same way you consume a union declaration. The switch over `int` and `double` is exhaustive, and no null arm is needed because neither case type is nullable:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Quantity.cs" id="QuantityConsume":::

## Run the sample

The console app drives each union. Replace the contents of `Program.cs`:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.App/Program.cs" id="ProgramMain":::

Run the app:

```dotnetcli
dotnet run --project SmartHome.App
```

The readings, results, and quantities each print through their exhaustive switches:

```output
Reading: 23.5
Reading: on
Reading: offline
Reading: no reading
Rooms: Kitchen, Garage
Success: 42
Failure: sensor timed out
3 items
2.50 units
```

## Related content

- [Closed hierarchies tutorial](closed-hierarchies.md)
- [Pattern matching overview](../../fundamentals/functional/pattern-matching.md)
- [What's new in C# 15](../csharp-15.md)

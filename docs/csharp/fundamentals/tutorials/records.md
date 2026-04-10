---
title: Use record types tutorial
description: Build a small app that models temperature data with records, compares record behavior, and uses with expressions for nondestructive mutation.
ms.date: 04/10/2026
ms.topic: tutorial
ai-usage: ai-assisted
---

# Use record types

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You get comfortable with classes, methods, and loops there.
>
> **Experienced in another language?** This tutorial focuses on C# record features you use every day: value equality, positional syntax, and `with` expressions.

In this tutorial, you build a console app that models daily temperatures by using records and record structs.

In this tutorial, you learn how to:

- Declare positional records and record structs.
- Build a small record hierarchy.
- Use compiler-generated equality and formatting.
- Use `with` expressions for nondestructive mutation.

## Prerequisites

[!INCLUDE [Prerequisites](../../../../includes/prerequisites-basic-winget.md)]

## Create the app and your first record

Create a folder for your app, run `dotnet new console`, and open the generated project.

Add a file named *InterimSteps.cs*, and add a positional `readonly record struct` for temperature values:

:::code language="csharp" source="./snippets/records/InterimSteps.cs" ID="DailyRecord":::

Add a file named *Program.cs*, and create sample temperature data:

:::code language="csharp" source="./snippets/records/Program.cs" ID="DeclareData":::

This syntax gives you concise data modeling with immutable value semantics.

## Add behavior to the record struct

Create a file named *DailyTemperature.cs* and add a computed `Mean` property:

:::code language="csharp" source="./snippets/records/DailyTemperature.cs" ID="TemperatureRecord":::

A record struct works well here because each value is small and self-contained.

## Build record types for degree-day calculations

Add a hierarchy for heating and cooling degree-day calculations:

:::code language="csharp" source="./snippets/records/InterimSteps.cs" ID="DegreeDaysRecords":::

Now calculate totals from your `Main` method:

:::code language="csharp" source="./snippets/records/Program.cs" ID="HeatingAndCooling":::

The generated `ToString` output is useful for quick diagnostics while you iterate.

## Customize output by overriding PrintMembers

When default output includes too much noise, override `PrintMembers` in the base record:

:::code language="csharp" source="./snippets/records/DegreeDays.cs" ID="AddPrintMembers":::

This override keeps output focused on the information you need.

## Use with expressions for nondestructive mutation

Use `with` to create modified copies without mutating the original record:

:::code language="csharp" source="./snippets/records/Program.cs" ID="GrowingDegreeDays":::

You can extend that idea to compute rolling totals from slices of your input data:

:::code language="csharp" source="./snippets/records/Program.cs" ID="RunningFiveDayTotal":::

This approach is useful when you need transformations while preserving original values.

## Next steps

- Review [C# record types](../types/records.md) for deeper guidance.
- Continue with [Object-oriented C#](oop.md) for broader design patterns.
- Explore [Converting types](safely-cast-using-pattern-matching-is-and-as-operators.md) to combine records with safe conversion patterns.

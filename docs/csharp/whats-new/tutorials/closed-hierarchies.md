---
title: Explore closed hierarchies in C#
description: "A closed hierarchy restricts a base type's direct subtypes to one assembly so the compiler can verify exhaustive matches. Learn to declare closed hierarchies, decide what to seal, and use them with generics."
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 10/19/2026
ai-usage: ai-assisted
#customer intent: As a C# developer, I model a fixed set of related types so the compiler enforces that I handle every subtype.
---
# Tutorial: Explore C# closed hierarchies

A *closed hierarchy* restricts the direct subtypes of a base type to the assembly that declares it. Because the compiler knows the full set of subtypes, it can verify that a `switch` expression is exhaustive without a default arm. Closed hierarchies suit domains where the set of cases is stable and you want the compiler to flag every place that needs to change when you add a case.

In this tutorial, you build the sensor model of a smart-home telemetry monitor. You declare a closed hierarchy of sensor types, match the sensors exhaustively, and decide which cases to seal and which to leave open for extension.

In this tutorial, you:

> [!div class="checklist"]
>
> * Declare a closed hierarchy and match its cases exhaustively.
> * Decide which subtypes to seal and which to leave open.
> * Extend an open case from another assembly.
> * Use a closed hierarchy with generics.

## Prerequisites

This tutorial uses C# 15 closed hierarchies. To get started, you need:

- The .NET 11 RC1 SDK or later. Use the current RC2 SDK from the [.NET download site](https://dotnet.microsoft.com/download/dotnet/11.0).
- An editor such as Visual Studio or Visual Studio Code with the C# Dev Kit.

Projects that target `net11.0` use C# 15 by default. You don't need to set `LangVersion` to `preview`.

## Create the sample solution

You build a class library, `SmartHome.Core`, that holds the closed hierarchy, a second library, `SmartHome.Extensions`, that extends an open case, and a console app, `SmartHome.App`, that drives them.

1. Open a terminal and run the following `dotnet` commands from a new folder previously created to store the code for tutorial:

   ```dotnetcli
   dotnet new sln -n TelemetryMonitor
   dotnet new classlib -f net11.0 -n SmartHome.Core
   dotnet new classlib -f net11.0 -n SmartHome.Extensions
   dotnet new console -f net11.0 -n SmartHome.App
   dotnet sln add SmartHome.Core SmartHome.Extensions SmartHome.App
   dotnet add SmartHome.Extensions reference SmartHome.Core
   dotnet add SmartHome.App reference SmartHome.Core SmartHome.Extensions
   ```

1. In each project file, verify that the target framework is .NET 11. The SDK selects C# 15 for this target:

   ```xml
   <PropertyGroup>
     <TargetFramework>net11.0</TargetFramework>
   </PropertyGroup>
   ```

## Declare a closed hierarchy

Start with the sensor model. The monitor supports a fixed set of sensor kinds, so you model them as a closed hierarchy in a single assembly.

1. In `SmartHome.Core`, add a file named `Sensors.cs` and declare the `Sensor` base type with the `closed` modifier and its three derived types:

   :::code language="csharp" source="snippets/shared/telemetry-monitor/SmartHome.Core/Sensors.cs" id="ClosedSensor":::

1. In the same file, add a method that matches every sensor with a switch expression:

   :::code language="csharp" source="snippets/shared/telemetry-monitor/SmartHome.Core/Sensors.cs" id="SensorExhaustive":::

1. Build the project. The .NET 11 SDK supplies the language support and the `IsClosedTypeAttribute` marker used by the compiler, so no polyfill is needed.

The `closed` modifier restricts the direct subtypes of `Sensor` to the declaring assembly, and a `closed` type is implicitly abstract, so you can't instantiate it directly. Because the compiler knows the complete set of subtypes, the switch needs no default arm. If you add a new sensor type later, the compiler reports that this switch no longer covers every case. That feedback is the central benefit of a closed hierarchy. The compiler points you to every match that needs to change. The `Temperature` and `Humidity` cases are sealed because their shape is final, while `Contact` stays open as an extension point that the next section covers. For more information, see the [`closed` modifier](../../language-reference/keywords/closed.md) and [Closed hierarchy patterns](../../language-reference/operators/patterns.md#closed-hierarchy-patterns).

## Decide what to seal

A subtype of a closed type isn't itself closed unless you declare it so. For each subtype, you have three choices:

- Mark it `closed` to continue the hierarchy: further subtypes are allowed, but only in the same assembly.
- Mark it `sealed` to end the hierarchy: no further subtypes are allowed anywhere.
- Leave it unmarked to make it open: other assemblies can derive from it, and those derived types still match the original case.

You left `Contact` unmarked for that reason, so now you extend it from another assembly.

1. In `SmartHome.Extensions`, add a file named `DoorContact.cs` that derives from the open `Contact` case:

   :::code language="csharp" source="snippets/shared/telemetry-monitor/SmartHome.Extensions/DoorContact.cs" id="DoorContact":::

1. In `SmartHome.App`, add code that matches a `DoorContact` through the existing `Sensor` switch:

   :::code language="csharp" source="snippets/shared/telemetry-monitor/SmartHome.App/Program.cs" id="DoorContactConsume":::

A `DoorContact` can't derive from `Sensor` directly, because it's closed to other assemblies. `DoorContact` extends the open `Contact` leaf instead. A `DoorContact` still matches the `Contact` case, so the exhaustive switch over `Sensor` stays correct without any change. When you choose what to seal, weigh the trade-off: seal a case to lock its shape and keep the hierarchy fully known, or leave a case open to allow extension at the cost of a less precise match, because the switch sees the open base case rather than the derived type. For more information, see the [`closed` modifier](../../language-reference/keywords/closed.md).

## Use a closed hierarchy with generics

A closed hierarchy can be generic. A report from the monitor is either a single value or a group of nested reports, so model it as a generic closed hierarchy.

1. In `SmartHome.Core`, add a file named `Report.cs` and declare the closed `Report<T>` base with its two cases. A derived type can't introduce a type parameter that the base type doesn't have, but it can supply fixed arguments for one or more of the base type's type parameters:

   :::code language="csharp" source="snippets/shared/telemetry-monitor/SmartHome.Core/Report.cs" id="ClosedReport":::

1. Add a recursive method that accumulates the report by switching over its cases:

   :::code language="csharp" source="snippets/shared/telemetry-monitor/SmartHome.Core/Report.cs" id="ReportFold":::

The switch over `Single<T>` and `Group<T>` is exhaustive because `Report<T>` is closed, so the recursive accumulator needs no default arm. For more information, see [Closed hierarchy patterns](../../language-reference/operators/patterns.md#closed-hierarchy-patterns).

## Run the sample

The console app builds each sensor and report, then prints them through the exhaustive switches. Open `Program.cs` and add the following code:

:::code language="csharp" source="snippets/shared/telemetry-monitor/SmartHome.App/Program.cs" id="ClosedMain":::

Then, run the app:

```dotnetcli
dotnet run --project SmartHome.App
```

The sensors and report print through their exhaustive switches:

```output
Sensor: 21.4°C
Sensor: 55% RH
Sensor: open
Sensor: closed
Report leaves: 3
```

## Summary

You built the sensor model of a smart-home telemetry monitor and, in the process, worked through closed-hierarchy scenarios. You:

- Declared a `closed Sensor` base type and matched its subtypes with an exhaustive switch that needs no default arm.
- Weighed the three choices for each subtype: `closed` to continue the hierarchy in the same assembly, `sealed` to end it, or unmarked to leave an extension point.
- Extended the open `Contact` case from a separate assembly with `DoorContact`, and confirmed it still matches the `Contact` case in the existing switch.
- Declared a generic closed hierarchy, `Report<T>`, and folded it with a recursive exhaustive switch.

## Related content

- [Union types tutorial](unions.md)
- [Pattern matching overview](../../fundamentals/patterns/pattern-matching.md)
- [What's new in C# 15](../csharp-15.md)

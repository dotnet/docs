---
title: Explore closed hierarchies in C#
description: "A closed hierarchy restricts a base type's direct subtypes to one assembly so the compiler can verify exhaustive matches. Learn to declare closed hierarchies, decide what to seal, and use them with generics."
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 02/16/2026
ai-usage: ai-assisted
#customer intent: As a C# developer, I model a fixed set of related types so the compiler enforces that I handle every subtype.
---
# Tutorial: Explore C# closed hierarchies

A *closed hierarchy* restricts the direct subtypes of a base type to the assembly that declares it. Because the compiler knows the full set of subtypes, it can verify that a switch handles every one without a default arm. Closed hierarchies suit domains where the set of cases is stable and you want the compiler to flag every place that needs to change when you add a case.

In this tutorial, you build the sensor model of a smart-home telemetry monitor. You declare a closed hierarchy of sensor types, you match the sensors exhaustively, and you decide which cases to seal and which to leave open for extension.

In this tutorial, you:

> [!div class="checklist"]
>
> * Declare a closed hierarchy and match its cases exhaustively.
> * Decide which subtypes to seal and which to leave open.
> * Extend an open case from another assembly.
> * Use a closed hierarchy with generics.

## Prerequisites

This tutorial uses preview language features. You need an SDK that supports closed hierarchies and a language version set to `preview`.

- The .NET SDK that includes the closed hierarchies preview feature. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet).
- An editor such as Visual Studio or Visual Studio Code with the C# Dev Kit.

> [!IMPORTANT]
> Closed hierarchies are a preview feature. The syntax and behavior can change before the feature ships. Set `<LangVersion>preview</LangVersion>` in your project to enable it.

## Create the sample solution

You build a class library, `SmartHome.Core`, that holds the closed hierarchy, a second library, `SmartHome.Extensions`, that extends an open case, and a console app, `SmartHome.App`, that drives them.

1. Create the solution and projects:

   ```dotnetcli
   dotnet new sln -n TelemetryMonitor
   dotnet new classlib -n SmartHome.Core
   dotnet new classlib -n SmartHome.Extensions
   dotnet new console -n SmartHome.App
   dotnet sln add SmartHome.Core SmartHome.Extensions SmartHome.App
   dotnet add SmartHome.Extensions reference SmartHome.Core
   dotnet add SmartHome.App reference SmartHome.Core SmartHome.Extensions
   ```

1. In each project file, set the language version to `preview`:

   ```xml
   <PropertyGroup>
     <LangVersion>preview</LangVersion>
   </PropertyGroup>
   ```

## Declare a closed hierarchy

The `closed` modifier on a base type restricts its direct subtypes to the declaring assembly. A `closed` type is implicitly abstract, so you can't instantiate it directly. The following declaration defines a `Sensor` base with three cases:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Sensors.cs" id="ClosedSensor":::

The `Temperature` and `Humidity` cases are sealed because their shape is final. The `Contact` case stays open as an extension point, which the next section covers.

## Match the hierarchy exhaustively

Because `Sensor` is closed, the compiler knows the complete set of subtypes. A switch that handles every case needs no default arm:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Sensors.cs" id="SensorExhaustive":::

If you add a new sensor type to the hierarchy, the compiler reports that this switch no longer covers every case. That feedback is the central benefit of a closed hierarchy: the compiler points you to every match that needs to change.

## Decide what to seal

A subtype of a closed type isn't itself closed unless you declare it so. A sealed subtype can't be extended at all. A subtype that's neither sealed nor closed becomes an *escape hatch*: other assemblies can derive from it, and those derived types still match the original case.

The `Contact` case is left open for that reason. A second assembly can specialize it without breaking the closed hierarchy. The following type lives in `SmartHome.Extensions` and derives from `Contact`:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Extensions/DoorContact.cs" id="DoorContact":::

A `DoorContact` can't derive from `Sensor` directly, because the hierarchy is closed to other assemblies. It extends the open `Contact` leaf instead. A `DoorContact` still matches the `Contact` case, so the exhaustive switch over `Sensor` stays correct without any change:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.App/Program.cs" id="DoorContactConsume":::

When you choose what to seal, weigh the trade-off. Seal a case to lock its shape and keep the hierarchy fully known. Leave a case open to allow extension at the cost of a less precise match: the switch sees the open base case, not the derived type.

## Use a closed hierarchy with generics

A closed hierarchy can be generic. Each type parameter of a derived type must appear in the base type, so a single derived construction exhausts each constructed base type. The following hierarchy models a report that's either a single value or a pair of nested reports:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Report.cs" id="ClosedReport":::

A recursive method folds the report. The switch over `Single<T>` and `Group<T>` is exhaustive because `Report<T>` is closed:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.Core/Report.cs" id="ReportFold":::

## Run the sample

The console app builds each sensor and report, then prints them through the exhaustive switches:

:::code language="csharp" source="snippets/telemetry-monitor/SmartHome.App/Program.cs" id="ProgramMain":::

Run the app:

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

## Related content

- [Union types tutorial](unions.md)
- [Pattern matching overview](../../fundamentals/functional/pattern-matching.md)
- [What's new in C# 15](../csharp-15.md)

---
title: What is .NET 5
description: In this article you will learn about .NET 5, a cross platform, and open-source project that convergences .NET framework and .NET Core together.
ms.date: 08/26/2020
ms.topic: overview
ms.author: dapine
author: IEvangelist
---

# What is .NET 5

The .NET ecosystem is being simplified with the convergence of .NET Core and .NET Framework. Naming things is hard, but unifying versions of two disparate .NET implementations can be harder. This article details .NET 5, which can be thought of as .NET Core vNext. With .NET Core concluding at version 3.1 and .NET Framework at version 4.8, to avoid ambiguity the next logical version is .NET version 5.0.

## Evolution of .NET

The advent of .NET Core has evolved the .NET ecosystem in compelling ways. It matured as an open-source project on GitHub, celebrating community contributions, and humbly improving over time. With .NET 5, you get all of the things you loved about .NET Core:

> [!div class="checklist"]
>
> - Cross-platform
> - Open-source and community-oriented
> - Side-by-side installation
> - Small project files (SDK-style)
> - High performance
> - Command-line tooling
> - Visual Studio, Visual Studio for Mac, and Visual Studio Code integration
> - Flexible deployment

In addition to all of these key characteristics, .NET 5 is making significant [performance improvements](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5).

During Microsoft Build - 2020, Scott Hunter and Scott Hanselman presented "The Journey to One .NET".

> [!VIDEO <https://channel9.msdn.com/Events/Build/2020/BOD106/player>]

## .NET release schedule

.NET has a formal release schedule, where a new major version is planned every November. .NET 5 will not have long-term support (LTS), however; .NET 6 in 2021 will be LTS. As major .NET versions ship, even-numbered releases will receive LTS. Minor releases will occur as needed.

:::image type="content" source="media/dotnet-schedule.svg" alt-text=".NET release schedule":::

## What happens to .NET Standard

With .NET 5, .NET Standard is being de-emphasized. If you're planning on sharing code between .NET Framework, .NET Core, and .NET 5 workloads - you can do so by targeting `netstandard2.0` as your target framework moniker (TFM).

// TODO: add compatibility matrix here...

## C# updates

C# will move forward in lock-step with .NET releases. Developers writing .NET 5 apps will have access to the latest C# version and features. In other words .NET 5 is paired with C# 9. C# 9 is bringing many new features to the language, here are a few highlights:

- Records: Immutable reference types that behave like value types, and introduce the new `with` keyword into the language.
- Relational pattern matching: Extends pattern matching capabilities to relational operators for comparative evaluations and expressions, including logical patterns - new keywords `and`, `or`, and `not`.
- Top-level statements: As a means for accelerating adoption and learning of C#, the `Main` method can be omitted and applications as simple as `System.Console.Write("Hello world!")` are valid.
- Functional pointers: Language constructs that expose intermediate language (IL) the following opcodes `ldftn` and `calli`.

<!--TODO: add this once the article is written [What's new in C# 9](csharp/whats-new/csharp-9.md). -->
For more complete listing of the available C# 9 features, see What's new in C# 9.

### Source generators

In addition to some of the highlighted new C# features, source generators are making their way into developer projects. Source generators allow code that runs during compilation to inspect your program and produce additional file that are compiled together with the rest of your code.

For more information on source generators, see [Introducing C# source generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators) and [C# source generator samples](https://devblogs.microsoft.com/dotnet/new-c-source-generator-samples).

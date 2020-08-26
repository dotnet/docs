---
title: What is .NET 5
description: In this article you will learn about .NET 5, a cross platform, and open-source project that convergences .NET framework and .NET Core together.
ms.date: 08/26/2020
ms.topic: overview
ms.author: dapine
author: IEvangelist
---

The .NET ecosystem is being simplified with the convergence of .NET Core and .NET Framework. Naming things is hard, but versioning things can be harder. This article details .NET 5, which can be thought of as .NET Core vNext. With .NET Core concluding at version 3.1 and .NET Framework at version 4.8, the next logical version to avoid ambiguity is .NET version 5.0.

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

## .NET release schedule

.NET has a formal release schedule, where a new major version is planned every November. .NET 5 will not have long-term support (LTS), however; .NET 6 in 2021 will be LTS. As major .NET versions ship, even-numbered releases will receive LTS. Minor releases will occur as needed.

:::image type="content" source="media/dotnet-schedule.svg" lightbox="media/dotnet-schedule.svg" alt-text=".NET release schedule":::

## What happens to .NET Standard

With .NET 5, .NET Standard is being de-emphasized. If you're planning on sharing code between .NET Framework, .NET Core, and .NET 5 workloads - you can do so by targeting `netstandard2.0` as your target framework moniker (TFM).

## C# 9 features

.NET 5 is paired with C# 9. C# 9 is brining many new features to the language.

- Records: Immutable reference types that behave like value types.
- Relational pattern matching: Extends pattern matching capabilities to relational operators for comparative evaluations and expressions, including logical patterns.

// TODO: add links to "what's new in C# 9" links, and additional features.

// TODO: source generators aren't really a C# 9 feature.

- Source generators: Code that runs during compilation that inspects your program to produce additional file that are compiled together with the rest of your code.

// TODO: add more content ...

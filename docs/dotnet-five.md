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

With .NET 5, .NET Standard is being de-emphasized. If you're planning on sharing code between .NET Framework, .NET Core, and .NET 5 workloads - you can do so by specifying `netstandard2.0` as your target framework moniker (TFM). For more information, see [How to specify target frameworks](standard/frameworks.md#how-to-specify-target-frameworks).

## What happens to C\#

C# will move forward in lock-step with .NET releases. Developers writing .NET 5 apps will have access to the latest C# version and features. In other words .NET 5 is paired with C# 9. C# 9 is bringing many new features to the language, here are a few highlights:

- Records: Immutable reference types that behave like value types, and introduce the new `with` keyword into the language.
- Relational pattern matching: Extends pattern matching capabilities to relational operators for comparative evaluations and expressions, including logical patterns - new keywords `and`, `or`, and `not`.
- Top-level statements: As a means for accelerating adoption and learning of C#, the `Main` method can be omitted and application as simple as the following is valid:

   ```csharp
   System.Console.Write("Hello world!");
   ```

- Functional pointers: Language constructs that expose intermediate language (IL) the following opcodes `ldftn` and `calli`.

For more information on the available C# 9 features, see [What's new in C# 9](csharp/whats-new/csharp-9.md).

### Source generators

In addition to some of the highlighted new C# features, source generators are making their way into developer projects. Source generators allow code that runs during compilation to inspect your program and produce additional files that are compiled together with the rest of your code.

For more information on source generators, see [Introducing C# source generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators) and [C# source generator samples](https://devblogs.microsoft.com/dotnet/new-c-source-generator-samples).

## What happens to Xamarin

As part of the .NET unification, [Xamarin.iOS](/xamarin/ios) and [Xamarin.Android](/xamarin/android) will become part of .NET 6 as .NET for iOS and .NET for Android. Because these bindings are projections of the SDKs shipped from Apple and Google, nothing changes there, however build tooling, target framework monikers, and runtime framework monikers will be updated to match all other .NET 6 workloads. Our commitment to keeping .NET developers up-to-date with the latest mobile SDKs is foundational to .NET MAUI and remains firm. When .NET 6 ships, we expect to ship a final release of Xamarin SDKs in their current form that will be serviced for a year. All modern work will at that time shift to .NET 6.

[Xamarin.Forms](/xamarin/get-started) will ship a new major version later this year, and continue to ship minor and service releases every 6 weeks through .NET 6 GA in November 2021. The final release of Xamarin.Forms will be serviced for a year after shipping, and all modern work will shift to .NET MAUI.

### .NET MAUI

.NET MAUI is an evolution of the increasingly popular Xamarin.Forms toolkit, and is open-source on GitHub at [dotnet/maui](https://github.com/dotnet/maui). With .NET MAUI, the choice for .NET developers is simplified, providing a single stack that supports all modern workloads: Android, iOS, macOS, and Windows. With .NET MAUI, you get a single project developer experience that targets multiple platforms and devices.

#### Model-View-Update pattern

Developers love modern development patterns. A fluent approach to UI development, inspired by "The Elm Architecture" is the [model-view-update](https://elmprogramming.com/model-view-update-part-1.html) or MVU pattern. MVU promotes a one-way flow of data and state management, as well as a code-first development experience that rapidly updates the UI by applying only the changes necessary.

As an example, consider the following counter written in .NET MAUI using the MVU pattern:

```csharp
readonly State<int> _count = 0;

[Body]
View body() => new StackLayout
{
    new Label("Welcome to .NET MAUI!"),
    new Button(
        () => $"You clicked {_count} times.",
        () => ++ _count.Value)
    )
};
```

For more information, see the [.NET MAUI roadmap](https://github.com/dotnet/maui/wiki/Roadmap), and [Introducing .NET MAUI](https://devblogs.microsoft.com/dotnet/introducing-net-multi-platform-app-ui) article.

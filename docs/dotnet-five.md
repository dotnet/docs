---
title: The evolution of .NET Core - .NET 5
description: In this article you will learn about .NET 5, a cross platform, and open-source project that is the next evolution of .NET Core.
ms.date: 08/31/2020
ms.topic: overview
ms.author: dapine
author: IEvangelist
---

# The evolution of .NET Core - .NET 5

The .NET ecosystem is being simplified with the evolution of .NET Core. Naming things is hard, but unifying versions of two disparate .NET implementations can be harder. This article details .NET 5, which can be thought of as .NET Core vNext. With .NET Core concluding at version 3.1 and .NET Framework at version 4.8, to avoid ambiguity the next logical version is .NET version 5.0.

The advent of .NET Core has evolved the .NET ecosystem in compelling ways. It matured as an open-source project on GitHub, celebrating community contributions, and humbly improving over time. .NET 5 is cross-platform, allows for side-by-side installation, and continues support of small project files (SDK-style).

### What .NET 5 is not

To be clear, .NET 5 is not a replacement for .NET Framework. There are no plans to port the following workloads from .NET Framework to .NET 5, as such there are recommended alternatives:

| Technology                             | Recommendation                                              |
|----------------------------------------|-------------------------------------------------------------|
| Web Forms                              | [ASP.NET Core Blazor](/aspnet/core/blazor)                  |
| Windows Communication Foundation (WCF) | [gRPC](/aspnet/core/grpc)                                   |
| Windows Workflow (WF)                  | [Open-source CoreWF](https://github.com/UiPath-Open/corewf) |

## .NET release schedule

A new major version of .NET is planned to release every November. .NET 5 will not have long-term support (LTS), however; .NET 6 in 2021 will be LTS. As major .NET versions ship, even-numbered releases will receive LTS. Minor releases will occur as needed.

:::image type="content" source="media/dotnet-schedule.svg" alt-text=".NET release schedule":::

## What happens to .NET Standard

With .NET 5, .NET Standard is being de-emphasized. New application development can specify the `net5.0` target framework moniker (TFM) for all project types, including class libraries. Sharing code between .NET 5 workloads is simplified in that all you need is the `net5.0` TFM.

However, if you're planning on sharing code between .NET Framework, .NET Core, and .NET 5 workloads - you can do so by specifying `netstandard2.0` as your TFM. For more information, see [How to specify target frameworks](standard/frameworks.md#how-to-specify-target-frameworks).

## Language updates

With .NET 5, the .NET programming languages are continuing to improve.

### C# updates

C# will move forward in lock-step with .NET releases. Developers writing .NET 5 apps will have access to the latest C# version and features. .NET 5 is paired with C# 9. C# 9 brings many new features to the language, here are a few highlights:

- Records: Immutable reference types that behave like value types, and introduce the new `with` keyword into the language.
- Relational pattern matching: Extends pattern matching capabilities to relational operators for comparative evaluations and expressions, including logical patterns - new keywords `and`, `or`, and `not`.
- Top-level statements: As a means for accelerating adoption and learning of C#, the `Main` method can be omitted and application as simple as the following is valid:

   ```csharp
   System.Console.Write("Hello world!");
   ```

- Functional pointers: Language constructs that expose intermediate language (IL) the following opcodes `ldftn` and `calli`.

For more information on the available C# 9 features, see [What's new in C# 9](csharp/whats-new/csharp-9.md).

#### Source generators

In addition to some of the highlighted new C# features, source generators are making their way into developer projects. Source generators allow code that runs during compilation to inspect your program and produce additional files that are compiled together with the rest of your code.

For more information on source generators, see [Introducing C# source generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators) and [C# source generator samples](https://devblogs.microsoft.com/dotnet/new-c-source-generator-samples).

### F# updates

F# is the .NET functional programming language, and with .NET 5, developers have access to F# 5. Here are several new features of F# 5, for more information, see [What's new in F# 5](fsharp/whats-new/fsharp-50.md).

#### Interpolated strings

Similar to interpolated string in C#, and even JavaScript - F# supports basic string interpolation.

```fsharp
let name = "David"
let age = 36
let message = $"{name} is {age} years old."
```

In addition to basic string interpolation, there is typed interpolation. With typed interpolation, a given type must match the format specifier.

```fsharp
let name = "David"
let age = 36
let message = $"%s{name} is %d{age} years old."
```

This is similar to the [`sprintf`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-printfmodule.html#sprintf) function that formats a string based on type-safe inputs.

### Visual Basic updates

There are no new language features for Visual Basic in .NET 5. However, with .NET 5, Visual Basic support is extended to:

- Console Application `console`
- Class library `classlib`
- WPF Application `wpf`
- WPF Class library `wpflib`
- WPF Custom Control Library `wpfcustomcontrollib`
- WPF User Control Library `wpfusercontrollib`
- Windows Forms (WinForms) Application `winforms`
- Windows Forms (WinForms) Class library `winformslib`
- Unit Test Project `mstest`
- NUnit 3 Test Project `nunit`
- NUnit 3 Test Item `nunit-test`
- xUnit Test Project `xunit`

For more information on project templates from the .NET CLI, see [`dotnet new`](core/tools/dotnet-new.md).

## What happens to Xamarin

While this article focuses on .NET 5, it is hard not to discuss .NET 6. The [Mono](https://www.mono-project.com) runtime was the original cross-platform implementation of .NET, which empowered Xamarin. However, the groundwork in .NET 5 will enable Xamarin to rebase atop .NET 6. As part of the .NET unification, [Xamarin.iOS](/xamarin/ios) and [Xamarin.Android](/xamarin/android) will become part of .NET 6 as .NET for iOS and .NET for Android.

> [!NOTE]
> When .NET 6 is released, the final release of Xamarin SDKs in their current form will also release, and they'll be serviced for a year. All modern work will at that time shift to .NET 6.

[Xamarin.Forms](/xamarin/get-started) is evolving into the .NET Multi-platform App UI, better known as ".NET MAUI". When .NET 6 ships, the final release of Xamarin.Forms will be serviced for a year after, and all modern work will shift to .NET MAUI.

### .NET MAUI

.NET MAUI is an evolution of the increasingly popular Xamarin.Forms toolkit, and is open-source on GitHub at [dotnet/maui](https://github.com/dotnet/maui). With .NET MAUI, the choice for .NET developers is simplified, providing a single stack that supports all modern workloads: Android, iOS, macOS, and Windows. With .NET MAUI, you get a single project developer experience that targets multiple platforms and devices.

> [!IMPORTANT]
> .NET MAUI is in early preview, and is planned for .NET 6. Sample source code can be found at [xamarin/net6-samples](https://github.com/xamarin/net6-samples).

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

## See also

- [The Journey to one .NET](https://channel9.msdn.com/Events/Build/2020/BOD106)
- [Performance improvements in .NET 5](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5)

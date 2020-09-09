---
title: The evolution of .NET Core to .NET 5
description: Learn about .NET 5, a cross platform and open-source development platform that is the next evolution of .NET Core.
ms.date: 09/02/2020
ms.topic: overview
ms.author: dapine
author: IEvangelist
---

# The evolution of .NET Core to .NET 5

This article details what's included in .NET 5, which is the next release of .NET Core following 3.1. The version number is 5.0 to avoid confusion with .NET Framework 4.x. And "Core" is dropped from the name because it is the main implementation of .NET going forward. ASP.NET Core retains the name "Core" to avoid confusing it with ASP.NET MVC 5. Additionally, Entity Framework Core retains the name "Core" to avoid confusing it with Entity Framework 5 and 6. .NET 5 supports more types of apps and more platforms than .NET Core or .NET Framework.

The advent of .NET Core has evolved the .NET ecosystem in compelling ways. It matured as an open-source project on GitHub, celebrating community contributions, and humbly improving over time.

.NET Core has several primary characteristics:

> [!div class="checklist"]
>
> - Cross-platform
> - Open-source
> - Side-by-side installation
> - Small project files (SDK-style)
> - Flexible deployment

.NET 5 extends these characteristics, making incremental improvements:

- Single file apps
- Windows ARM64 and ARM64 intrinsics
- Sweeping performance improvements to:
  - [Garbage Collection (GC)](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5/#gc)
  - [System.Text.Json](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5/#json)
  - [System.Text.RegularExpressions](https://devblogs.microsoft.com/dotnet/regex-performance-improvements-in-net-5)
  - [Async ValueTask pooling](https://devblogs.microsoft.com/dotnet/async-valuetask-pooling-in-net-5)
  - [Many more areas](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5)
- Container size optimizations
- [App trimming](https://devblogs.microsoft.com/dotnet/app-trimming-in-net-5)
- [C# compiler enhancements](https://devblogs.microsoft.com/dotnet/automatically-find-latent-bugs-in-your-code-with-net-5)
- Tooling support for dump debugging
- Platform is 80% annotated for [nullable reference types](../csharp/nullable-references.md)

### What .NET 5 is not

.NET 5 is not a replacement for .NET Framework. There are no plans to port the following technologies from .NET Framework to .NET 5, but there are supported alternatives included in .NET 5:

| Technology                             | Recommendation                                              |
|----------------------------------------|-------------------------------------------------------------|
| Web Forms                              | [ASP.NET Core Blazor](/aspnet/core/blazor)                  |
| Windows Communication Foundation (WCF) | [gRPC](/aspnet/core/grpc)                                   |
| Windows Workflow (WF)                  | [Open-source CoreWF](https://github.com/UiPath-Open/corewf) |

## .NET Standard

New application development can specify the `net5.0` target framework moniker (TFM) for all project types, including class libraries. Sharing code between .NET 5 workloads is simplified in that all you need is the `net5.0` TFM.

The `net5.0` TFM combines and replaces the `netcoreapp` and `netstandard` names. This TFM will generally only include technologies that work cross-platform, like was done with .NET Standard. However, if you plan to share code between .NET Framework, .NET Core, and .NET 5 workloads, you can do so by specifying `netstandard2.0` as your TFM. For more information, see [How to specify target frameworks](../standard/frameworks.md#how-to-specify-a-target-framework).

## Language updates

With .NET 5, the .NET programming languages are continuing to improve.

### C# updates

Developers writing .NET 5 apps will have access to the latest C# version and features. .NET 5 is paired with C# 9, which brings many new features to the language. Here are a few highlights:

- Records: Immutable reference types that behave like value types, and introduce the new `with` keyword into the language.
- Relational pattern matching: Extends pattern matching capabilities to relational operators for comparative evaluations and expressions, including logical patterns - new keywords `and`, `or`, and `not`.
- Top-level statements: As a means for accelerating adoption and learning of C#, the `Main` method can be omitted and application as simple as the following is valid:

   ```csharp
   System.Console.Write("Hello world!");
   ```

- Function pointers: Language constructs that expose the following intermediate language (IL) opcodes: `ldftn` and `calli`.

For more information on the available C# 9 features, see [What's new in C# 9](../csharp/whats-new/csharp-9.md).

#### Source generators

In addition to some of the highlighted new C# features, source generators are making their way into developer projects. Source generators allow code that runs during compilation to inspect your program and produce additional files that are compiled together with the rest of your code.

For more information on source generators, see [Introducing C# source generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators) and [C# source generator samples](https://devblogs.microsoft.com/dotnet/new-c-source-generator-samples).

### F# updates

F# is the .NET functional programming language, and with .NET 5, developers have access to F# 5. Here are several new features of F# 5:

#### Interpolated strings

Similar to interpolated string in C#, and even JavaScript, F# supports basic string interpolation.

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

This is similar to the [`sprintf`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-printfmodule.html#sprintf) function that formats a string based on type-safe inputs. <!-- For more information, see [What's new in F# 5](fsharp/whats-new/fsharp-50.md). -->

### Visual Basic updates

There are no new language features for Visual Basic in .NET 5. However, with .NET 5, Visual Basic support is extended to:

| Description                            | `dotnet new` parameter |
|----------------------------------------|------------------------|
| Console Application                    | `console`              |
| Class library                          | `classlib`             |
| WPF Application                        | `wpf`                  |
| WPF Class library                      | `wpflib`               |
| WPF Custom Control Library             | `wpfcustomcontrollib`  |
| WPF User Control Library               | `wpfusercontrollib`    |
| Windows Forms (WinForms) Application   | `winforms`             |
| Windows Forms (WinForms) Class library | `winformslib`          |
| Unit Test Project                      | `mstest`               |
| NUnit 3 Test Project                   | `nunit`                |
| NUnit 3 Test Item                      | `nunit-test`           |
| xUnit Test Project                     | `xunit`                |

For more information on project templates from the .NET CLI, see [`dotnet new`](tools/dotnet-new.md).

## .NET MAUI

.NET MAUI is an evolution of the increasingly popular Xamarin.Forms toolkit, and is open-source on GitHub at [dotnet/maui](https://github.com/dotnet/maui). With .NET MAUI, the choice for .NET developers is simplified, providing a single stack that supports all modern workloads: Android, iOS, macOS, and Windows. With .NET MAUI, you get a single project developer experience that targets multiple platforms and devices.

> [!IMPORTANT]
> .NET MAUI is in early preview. Sample source code can be found at [xamarin/net6-samples](https://github.com/xamarin/net6-samples).

### Model-View-Update pattern

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

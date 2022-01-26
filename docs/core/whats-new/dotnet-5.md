---
title: What's new in .NET 5
description: Learn about .NET 5, a cross-platform and open-source development platform that is the next evolution of .NET Core.
ms.date: 11/30/2020
ms.topic: overview
ms.author: dapine
author: IEvangelist
---

# What's new in .NET 5

.NET 5 is the next major release of .NET Core following 3.1. We named this new release .NET 5 instead of .NET Core 4 for two reasons:

- We skipped version numbers 4.x to avoid confusion with .NET Framework 4.x.
- We dropped "Core" from the name to emphasize that this is the main implementation of .NET going forward. .NET 5 supports more types of apps and more platforms than .NET Core or .NET Framework.

ASP.NET Core 5.0 is based on .NET 5 but retains the name "Core" to avoid confusing it with ASP.NET MVC 5. Likewise, Entity Framework Core 5.0 retains the name "Core" to avoid confusing it with Entity Framework 5 and 6.

.NET 5 includes the following improvements and new features compared to .NET Core 3.1:

- [C# updates](#c-updates)
- [F# updates](#f-updates)
- [Visual Basic updates](#visual-basic-updates)
- [System.Text.Json new features](#systemtextjson-new-features)
- [Single file apps](../deploying/single-file.md)
- [App trimming](https://devblogs.microsoft.com/dotnet/app-trimming-in-net-5)
- Windows ARM64 and ARM64 intrinsics
- Tooling support for dump debugging
- The runtime libraries are 80% annotated for [nullable reference types](../../csharp/nullable-references.md)
- Performance improvements:
  - [Garbage Collection (GC)](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5/#gc)
  - [System.Text.Json](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5/#json)
  - [System.Text.RegularExpressions](https://devblogs.microsoft.com/dotnet/regex-performance-improvements-in-net-5)
  - [Async ValueTask pooling](https://devblogs.microsoft.com/dotnet/async-valuetask-pooling-in-net-5)
  - [Container size optimizations](https://github.com/dotnet/dotnet-docker/issues/1814#issuecomment-625294750)
  - [Many more areas](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5)

## .NET 5 doesn't replace .NET Framework

.NET 5 and later versions are the main implementation of .NET going forward but .NET Framework 4.x is still supported. There are no plans to port the following technologies from .NET Framework to .NET 5, but there are alternatives in .NET:

| Technology            | Recommended alternative                                                                         |
|-----------------------|-------------------------------------------------------------------------------------------------|
| Web Forms             | ASP.NET Core [Blazor](/aspnet/core/blazor) or [Razor Pages](/aspnet/core/tutorials/razor-pages) |
| Windows Workflow (WF) | [Elsa-Workflows](https://github.com/elsa-workflows/elsa-core)                                   |

### Windows Communication Foundation

The original implementation of [Windows Communication Foundation (WCF)](../../framework/wcf/index.md) was only supported on Windows. However, there is a client port available from the .NET Foundation. It is entirely [open source](https://github.com/dotnet/wcf), cross platform, and supported by Microsoft. The core NuGet packages are listed below:

- [System.ServiceModel.Duplex](https://www.nuget.org/packages/System.ServiceModel.Duplex)
- [System.ServiceModel.Federation](https://www.nuget.org/packages/System.ServiceModel.Federation)
- [System.ServiceModel.Http](https://www.nuget.org/packages/System.ServiceModel.Http)
- [System.ServiceModel.NetTcp](https://www.nuget.org/packages/System.ServiceModel.NetTcp)
- [System.ServiceModel.Primitives](https://www.nuget.org/packages/System.ServiceModel.Primitives)
- [System.ServiceModel.Security](https://www.nuget.org/packages/System.ServiceModel.Security)

The community maintains the server components that complement the aforementioned client libraries. The GitHub repository can be found at [CoreWCF](https://github.com/CoreWCF/CoreWCF). The server components are _not_ officially supported by Microsoft. For an alternative to WCF, consider [gRPC](/aspnet/core/grpc).

## .NET 5 doesn't replace .NET Standard

New application development can specify the `net5.0` target framework moniker (TFM) for all project types, including class libraries. Sharing code between .NET 5 workloads is simplified in that all you need is the `net5.0` TFM.

For .NET 5 apps and libraries, the `net5.0` Target Framework Moniker (TFM) combines and replaces the `netcoreapp` and `netstandard` TFMs. However, if you plan to share code between .NET Framework, .NET Core, and .NET 5 workloads, you can do so by specifying `netstandard2.0` as your TFM. For more information, see [.NET Standard](../../standard/net-standard.md).

## C# updates

Developers writing .NET 5 apps will have access to the latest C# version and features. .NET 5 is paired with C# 9, which brings many new features to the language. Here are a few highlights:

- Records: reference types with value-based equality semantics and non-destructive mutation supported by a new `with` expression.
- Relational pattern matching: Extends pattern matching capabilities to relational operators for comparative evaluations and expressions, including logical patterns - new keywords `and`, `or`, and `not`.
- Top-level statements: As a means for accelerating adoption and learning of C#, the `Main` method can be omitted and application as simple as the following is valid:

   ```csharp
   System.Console.Write("Hello world!");
   ```

- Function pointers: Language constructs that expose the following intermediate language (IL) opcodes: `ldftn` and `calli`.

For more information on the available C# 9 features, see [What's new in C# 9](../../csharp/whats-new/csharp-9.md).

### Source generators

In addition to some of the highlighted new C# features, source generators are making their way into developer projects. Source generators allow code that runs during compilation to inspect your program and produce additional files that are compiled together with the rest of your code.

For more information on source generators, see [Introducing C# source generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators) and [C# source generator samples](https://devblogs.microsoft.com/dotnet/new-c-source-generator-samples).

## F# updates

F# is the .NET functional programming language, and with .NET 5, developers have access to F# 5. One of the new features is interpolated strings, which is similar to interpolated string in C#, and even JavaScript.

```fsharp
let name = "David"
let age = 36
let message = $"{name} is {age} years old."
```

In addition to basic string interpolation, there's typed interpolation. With typed interpolation, a given type must match the format specifier.

```fsharp
let name = "David"
let age = 36
let message = $"%s{name} is %d{age} years old."
```

This is similar to the [`sprintf`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-printfmodule.html#sprintf) function that formats a string based on type-safe inputs.

For more information, see [What's new in F# 5](../../fsharp/whats-new/fsharp-50.md).

## Visual Basic updates

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

For more information on project templates from the .NET CLI, see [`dotnet new`](../tools/dotnet-new.md).

## System.Text.Json new features

There are new features in and for [System.Text.Json](../../standard/serialization/system-text-json-overview.md):

- [Preserve references and handle circular references](../../standard/serialization/system-text-json-preserve-references.md)
- [HttpClient and HttpContent extension methods](../../standard/serialization/system-text-json-how-to.md#httpclient-and-httpcontent-extension-methods)
- [Allow or write numbers in quotes](../../standard/serialization/system-text-json-invalid-json.md#allow-or-write-numbers-in-quotes)
- [Support immutable types and C# 9 Records](../../standard/serialization/system-text-json-immutability.md)
- [Support non-public property accessors](../../standard/serialization/system-text-json-immutability.md)
- [Support fields](../../standard/serialization/system-text-json-how-to.md#include-fields)
- [Conditionally ignore properties](../../standard/serialization/system-text-json-ignore-properties.md)
- [Support non-string-key dictionaries](../../standard/serialization/system-text-json-migrate-from-newtonsoft-how-to.md#dictionary-with-non-string-key)
- [Allow custom converters to handle null](../../standard/serialization/system-text-json-converters-how-to.md#handle-null-values)
- [Copy JsonSerializerOptions](../../standard/serialization/system-text-json-configure-options.md#copy-jsonserializeroptions)
- [Create JsonSerializerOptions with web defaults](../../standard/serialization/system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions)

## See also

- [The Journey to one .NET](/Events/Build/2020/BOD106)
- [Performance improvements in .NET 5](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5)
- [Download the .NET SDK](https://dotnet.microsoft.com/download)

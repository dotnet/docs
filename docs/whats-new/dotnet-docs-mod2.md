---
title: ".NET docs: What's new for November 2023"
description: "What's new in the .NET docs for November 2023."
ms.custom: November-2023
ms.date: 12/01/2023
---

# .NET docs: What's new for November 2023

Welcome to what's new in the .NET docs for November 2023. This article lists some of the major changes to docs during this period.

## .NET security

### Updated articles

- [Cross-Platform Cryptography in .NET](../standard/security/cross-platform-cryptography.md) - Update x-plat cryptography to cover tvOS and MacCatalyst

## .NET breaking changes

### New articles

- [Enumerable.Sum throws new OverflowException for some inputs](../core/compatibility/core-libraries/8.0/enumerable-sum.md)
- [ProcessStartInfo.WindowStyle honored when UseShellExecute is false](../core/compatibility/core-libraries/8.0/processstartinfo-windowstyle.md)
- [PublishedTrimmed projects fail reflection-based serialization](../core/compatibility/serialization/8.0/publishtrimmed.md)
- [Source Link included in the .NET SDK](../core/compatibility/sdk/8.0/source-link.md)
- [Unlisted packages not installed by default for .NET tools](../core/compatibility/sdk/8.0/unlisted-versions.md)
- [Implicit `using` for System.Net.Http no longer added](../core/compatibility/sdk/8.0/implicit-global-using-netfx.md)
- [SendFile throws NotSupportedException for connectionless sockets](../core/compatibility/networking/8.0/sendfile-connectionless.md)
- [System.Windows.Extensions doesn't reference System.Drawing.Common](../core/compatibility/windows-forms/8.0/extensions-package-deps.md)
- [JSFunctionBinding implicit public default constructor removed](../core/compatibility/interop/8.0/jsfunctionbinding-constructor.md)
- [System.Formats.Cbor DateTimeOffset formatting change](../core/compatibility/extensions/8.0/cbor-datetime.md)

### Updated articles

- [Breaking changes in .NET 6](../core/compatibility/6.0.md) - Remove "introduced version" column

## .NET fundamentals

### New articles

- [Microsoft.DotNet.ApiCompat.Tool global tool](../fundamentals/apicompat/global-tool.md)
- [Networking event counters in .NET](../fundamentals/networking/telemetry/event-counters.md)
- [Networking metrics in .NET](../fundamentals/networking/telemetry/metrics.md)
- [Networking telemetry in .NET](../fundamentals/networking/telemetry/overview.md)
- [CA1862: Use the 'StringComparison' method overloads to perform case-insensitive string comparisons](../fundamentals/code-analysis/quality-rules/ca1862.md)
- [CA1863: Use 'CompositeFormat'](../fundamentals/code-analysis/quality-rules/ca1863.md)
- [Install .NET SDK or .NET Runtime on Ubuntu 23.10](../core/install/linux-ubuntu-2310.md)
- [CA1510: Use ArgumentNullException throw helper](../fundamentals/code-analysis/quality-rules/ca1510.md)
- [CA1511: Use ArgumentException throw helper](../fundamentals/code-analysis/quality-rules/ca1511.md)
- [CA1512: Use ArgumentOutOfRangeException throw helper](../fundamentals/code-analysis/quality-rules/ca1512.md)
- [CA1513: Use ObjectDisposedException throw helper](../fundamentals/code-analysis/quality-rules/ca1513.md)
- [CA2261: Do not use `ConfigureAwaitOptions.SuppressThrowing` with `Task<TResult>`](../fundamentals/code-analysis/quality-rules/ca2261.md)
- [CA2021: Don't call Enumerable.Cast\<T> or Enumerable.OfType\<T> with incompatible types](../fundamentals/code-analysis/quality-rules/ca2021.md)
- [CA1856: Incorrect usage of ConstantExpected attribute](../fundamentals/code-analysis/quality-rules/ca1856.md)
- [CA1857: The parameter expects a constant for optimal performance](../fundamentals/code-analysis/quality-rules/ca1857.md)
- [Service discovery in .NET](../core/extensions/service-discovery.md)
- [Use primary constructor (IDE0290)](../fundamentals/code-analysis/style-rules/ide0290.md)
- [.NET extensions metrics](../core/diagnostics/built-in-metrics-diagnostics.md)
- [Artifacts output layout](../core/sdk/artifacts-output.md)

### Updated articles

- [What's new in .NET 8](../core/whats-new/dotnet-8/overview.md) - Add .NET Aspire
- [Runtime configuration options for garbage collection](../core/runtime-config/garbage-collector.md) - Runtimeconfig template
- [Introduction to trim warnings](../core/deploying/trimming/fixing-warnings.md) - Improvements to trim warnings description and fixes

## C# language

### New articles

- [Static abstract and virtual interface member errors and warnings](../csharp/language-reference/compiler-messages/static-abstract-interfaces.md)
- [Choose diagnostic IDs](../csharp/roslyn-sdk/choosing-diagnostic-ids.md)

### Updated articles

- [Resolve errors and warnings in array and collection declarations and initialization expressions](../csharp/language-reference/compiler-messages/array-declaration-errors.md) - Add latest errors codes
- [Resolve errors and warnings in constructor declarations](../csharp/language-reference/compiler-messages/constructor-errors.md) - Add latest errors codes
- [Errors and warnings associated with reference parameters, variables, and returns](../csharp/language-reference/compiler-messages/ref-modifiers-errors.md) - Add latest errors codes

## F# language

### New articles

- [What's new in F# 7](../fsharp/whats-new/fsharp-7.md)
- [What's new in F# 8](../fsharp/whats-new/fsharp-8.md)

## Azure SDK for .NET

### New articles

- [Develop .NET apps that use Azure AI services](../ai/azure-ai-for-dotnet-developers.md)
- [Get started with the .NET enterprise chat sample using RAG](../ai/get-started-app-chat-template.md)
- [Assess your .NET applications for migration to Azure](../azure/migration/appcat/app-code-assessment-toolkit.md)
- [Analyze applications with the .NET CLI](../azure/migration/appcat/dotnet-cli.md)
- [Install Azure Migrate application and code assessment for .NET](../azure/migration/appcat/install.md)
- [Interpret the analysis results](../azure/migration/appcat/interpret-results.md)
- [Analyze applications with Visual Studio](../azure/migration/appcat/visual-studio.md)

## .NET Framework

### Updated articles

- [Writing Large, Responsive .NET Framework Apps](../framework/performance/writing-large-responsive-apps.md) - Fix build suggestions

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [BartoszKlonowski](https://github.com/BartoszKlonowski) - Bartosz Klonowski ![7 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-7-green)
- [Rageking8](https://github.com/Rageking8) -  ![4 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-4-green)
- [smoothdeveloper](https://github.com/smoothdeveloper) - Gauthier Segay ![4 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-4-green)
- [gurustron](https://github.com/gurustron) -  ![3 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-3-green)
- [WeihanLi](https://github.com/WeihanLi) - Weihan Li ![3 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-3-green)
- [DickBaker](https://github.com/DickBaker) - Dick Baker ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [bakedpatato](https://github.com/bakedpatato) - Chris  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [BenjaminMichaelis](https://github.com/BenjaminMichaelis) - Benjamin Michaelis ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Dixin](https://github.com/Dixin) - Dixin ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [dreamjz](https://github.com/dreamjz) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [entvex](https://github.com/entvex) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ericmutta](https://github.com/ericmutta) - Eric Mutta ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [j-d-b](https://github.com/j-d-b) - Jacob Brady ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [joelhulen](https://github.com/joelhulen) - Joel Hulen ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [loop-evgeny](https://github.com/loop-evgeny) - Evgeny Morozov ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [matbech](https://github.com/matbech) - Mathias Berchtold ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [mvdgun](https://github.com/mvdgun) - Mauro van der Gun ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [niquenen](https://github.com/niquenen) - Cédric Hennequin ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [nnpcYvIVl](https://github.com/nnpcYvIVl) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [peter-csala](https://github.com/peter-csala) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [pkulikov](https://github.com/pkulikov) - Petr Kulikov ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [raymer](https://github.com/raymer) - Jonathan Raymer ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Scottlis26](https://github.com/Scottlis26) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [serpent5](https://github.com/serpent5) - Kirk Larkin ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [SimonCropp](https://github.com/SimonCropp) - Simon Cropp ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [sivaji55](https://github.com/sivaji55) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [stevedunnman](https://github.com/stevedunnman) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [SusheelThapa](https://github.com/SusheelThapa) - Susheel Thapa ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [timdeschryver](https://github.com/timdeschryver) - Tim Deschryver ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Void00000000](https://github.com/Void00000000) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [xp44mm](https://github.com/xp44mm) - xp44mm ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [younes-achachi](https://github.com/younes-achachi) - younes ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)

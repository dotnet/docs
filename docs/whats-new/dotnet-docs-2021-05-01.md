---
title: ".NET docs: What's new for May 1, 2021 - May 31, 2021"
description: "What's new in the .NET docs for May 1, 2021 - May 31, 2021."
ms.date: 06/23/2021
---

# .NET docs: What's new for May 1, 2021 - May 31, 2021

Welcome to what's new in the .NET docs from May 1, 2021 through May 31, 2021. This article lists some of the major changes to docs during this period.

## .NET fundamentals

### New articles

- [Error generated when executable project references mismatched executable](../core/compatibility/sdk/5.0/referencing-executable-generates-error.md) - Executable ref breaking change
- [Create a Queue Service](../core/extensions/queue-service.md) - Worker Services in .NET articles and tutorials
- [Use scoped services within a `BackgroundService`](../core/extensions/scoped-service.md) - Worker Services in .NET articles and tutorials
- [Implement the `IHostedService` interface](../core/extensions/timer-service.md) - Worker Services in .NET articles and tutorials
- [Create a Windows Service using `BackgroundService`](../core/extensions/windows-service.md) - Worker Services in .NET articles and tutorials
- [Worker Services in .NET](../core/extensions/workers.md) - Worker Services in .NET articles and tutorials
- [CA1846: Prefer `AsSpan` over `Substring`](../fundamentals/code-analysis/quality-rules/ca1846.md) - Ca1846
- [Environment.ProcessorCount behavior on Windows](../core/compatibility/core-libraries/6.0/environment-processorcount-on-windows.md) - Add ProcessorCount breaking change
- [SYSLIB0021: Derived cryptographic types are obsolete](../fundamentals/syslib-diagnostics/syslib0021.md) - Add SYSLIB0021-SYSLIB0024
- [SYSLIB0022: The Rijndael and RijndaelManaged types are obsolete](../fundamentals/syslib-diagnostics/syslib0022.md) - Add SYSLIB0021-SYSLIB0024
- [SYSLIB0023: RNGCryptoServiceProvider is obsolete](../fundamentals/syslib-diagnostics/syslib0023.md) - Add SYSLIB0021-SYSLIB0024
- [SYSLIB0024: Creating and unloading AppDomains is not supported and throws an exception](../fundamentals/syslib-diagnostics/syslib0024.md) - Add SYSLIB0021-SYSLIB0024
- [CA1845: Use span-based 'string.Concat'](../fundamentals/code-analysis/quality-rules/ca1845.md) - CA1845
- [MVC doesn't buffer IAsyncEnumerable types when using System.Text.Json](../core/compatibility/aspnet-core/6.0/iasyncenumerable-not-buffered-by-mvc.md) - MVC buffering breaking change
- [Troubleshoot _fxr_, _libhostfxr.so_, and _FrameworkList.xml_ errors](../core/install/linux-package-mixup.md) - Add a doc to help troubleshoot package mixups
- [API obsoletions with non-default diagnostic IDs (.NET 6)](../core/compatibility/core-libraries/6.0/obsolete-apis-with-custom-diagnostics.md) - SYSLIB0017 and SYSLIB0018
- [SYSLIB0017: Strong-name signing is not supported and throws PlatformNotSupportedException](../core/compatibility/syslib-warnings/syslib0017.md) - SYSLIB0017 and SYSLIB0018
- [SYSLIB0018: Reflection-only loading is not supported and throws PlatformNotSupportedException](../core/compatibility/syslib-warnings/syslib0018.md) - SYSLIB0017 and SYSLIB0018
- [Obsolete features in .NET 5+](../fundamentals/syslib-diagnostics/obsoletions-overview.md) - Add SYSLIBXXXX diagnostic details
- [Source-generator diagnostics in .NET 6+](../fundamentals/syslib-diagnostics/source-generator-overview.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1001: Logging method names can't start with an underscore](../fundamentals/syslib-diagnostics/syslib1001.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1002: Don't include log level parameters as templates in the logging message](../fundamentals/syslib-diagnostics/syslib1002.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1003: Logging method parameter names can't start with an underscore](../fundamentals/syslib-diagnostics/syslib1003.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1004: Logging class cannot be in a nested type](../fundamentals/syslib-diagnostics/syslib1004.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1005: Could not find a required type definition](../fundamentals/syslib-diagnostics/syslib1005.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1006: Multiple logging methods cannot use the same event ID](../fundamentals/syslib-diagnostics/syslib1006.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1007: Logging methods must return void](../fundamentals/syslib-diagnostics/syslib1007.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1008: One of the arguments to a logging method must implement the `ILogger` interface](../fundamentals/syslib-diagnostics/syslib1008.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1009: Logging methods must be static](../fundamentals/syslib-diagnostics/syslib1009.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1010: Logging methods must be partial](../fundamentals/syslib-diagnostics/syslib1010.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1011: Logging methods cannot be generic](../fundamentals/syslib-diagnostics/syslib1011.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1012: Redundant qualifier in logging message](../fundamentals/syslib-diagnostics/syslib1012.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1013: Don't include exception parameters as templates in the logging message](../fundamentals/syslib-diagnostics/syslib1013.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1014: Logging template has no corresponding method argument](../fundamentals/syslib-diagnostics/syslib1014.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1015: Argument is not referenced from the logging message](../fundamentals/syslib-diagnostics/syslib1015.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1016: Logging methods cannot have a body](../fundamentals/syslib-diagnostics/syslib1016.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1017: A `LogLevel` value must be supplied in the `LoggerMessage` attribute or as a parameter to the logging method](../fundamentals/syslib-diagnostics/syslib1017.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1018: Don't include logger parameters as templates in the logging message](../fundamentals/syslib-diagnostics/syslib1018.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1019: Couldn't find a field of type `ILogger`](../fundamentals/syslib-diagnostics/syslib1019.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1020: Found multiple fields of type `ILogger`](../fundamentals/syslib-diagnostics/syslib1020.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1021: Multiple message-template item names differ only by case](../fundamentals/syslib-diagnostics/syslib1021.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1022: Can't have malformed format strings](../fundamentals/syslib-diagnostics/syslib1022.md) - Add SYSLIBXXXX diagnostic details
- [SYSLIB1023: Generating more than six arguments is not supported](../fundamentals/syslib-diagnostics/syslib1023.md) - Add SYSLIBXXXX diagnostic details
- [Microsoft.AspNetCore.Http.Features split](../core/compatibility/aspnet-core/6.0/microsoft-aspnetcore-http-features-package-split.md) - Two ASP.NET Core breaking changes
- [Middleware: New Use overload](../core/compatibility/aspnet-core/6.0/middleware-new-use-overload.md) - Two ASP.NET Core breaking changes
- [Compile-time logging source generation](../core/extensions/logger-message-generator.md) - Doc for logging generator
- [dotnet new --install option](../core/tools/dotnet-new-install.md) - dotnet new article - updates for 5.0.3xx SDK
- [dotnet new --list option](../core/tools/dotnet-new-list.md) - dotnet new article - updates for 5.0.3xx SDK
- [.NET default templates for dotnet new](../core/tools/dotnet-new-sdk-templates.md) - dotnet new article - updates for 5.0.3xx SDK
- [dotnet new --search option](../core/tools/dotnet-new-search.md) - dotnet new article - updates for 5.0.3xx SDK
- [dotnet new --uninstall option](../core/tools/dotnet-new-uninstall.md) - dotnet new article - updates for 5.0.3xx SDK
- [dotnet new --update-check and --update-apply options](../core/tools/dotnet-new-update.md) - dotnet new article - updates for 5.0.3xx SDK
- [NETSDK1141: Unable to resolve the .NET SDK version as specified in the global.json](../core/tools/sdk-errors/netsdk1141.md) - Create error page NETSDK1141
- [Inspect managed stack traces (dotnet-stack)](../core/diagnostics/dotnet-stack.md) - Add dotnet-stack docs

### Updated articles

- [Language independence and language-independent components](../standard/language-independence.md) - Consolidate duplicate files

## Azure SDK for .NET

### New articles

- [Thread safety and client lifetime management for Azure SDK objects](../azure/sdk/thread-safety.md) - Article discussing thread safety in Azure SDK objects …
- [Dependency injection with the Azure .NET SDK](../azure/dependency-injection.md) - Add Azure SDK DI doc

## C# language

### New articles

- [Iteration statements (C# reference)](../csharp/language-reference/statements/iteration-statements.md) - C# reference: Consolidate the iteration statements articles

### Updated articles

- [C# Coding Conventions (C# Programming Guide)](../csharp/programming-guide/inside-a-program/coding-conventions.md) - Added naming convention details for C# code

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [azure-sdk](https://github.com/azure-sdk) - Azure SDK Bot (26)
- [tdykstra](https://github.com/tdykstra) - Tom Dykstra (20)
- [Youssef1313](https://github.com/Youssef1313) - Youssef Victor (20)
- [adegeo](https://github.com/adegeo) - Andy (Steve) De George (7)
- [nemrism](https://github.com/nemrism) - Aymeric A (2)
- [NewellClark](https://github.com/NewellClark) - Newell Clark (2)
- [pkulikov](https://github.com/pkulikov) - Petr Kulikov (2)
- [sywhang](https://github.com/sywhang) - Sung Yoon Whang (2)
- [TheBlueSky](https://github.com/TheBlueSky) - Essam (2)
- [Alen-John](https://github.com/Alen-John) (1)
- [Apexal](https://github.com/Apexal) - Frank Matranga (1)
- [BartoszKlonowski](https://github.com/BartoszKlonowski) - Bartosz Klonowski (1)
- [BenjaminMichaelis](https://github.com/BenjaminMichaelis) - Benjamin Michaelis (1)
- [brokenthorn](https://github.com/brokenthorn) - Paul-Sebastian Manole (1)
- [CamSoper](https://github.com/CamSoper) - Cam Soper (1)
- [ChanwooJung1](https://github.com/ChanwooJung1) - Chanwoo Jung (1)
- [DavidCBerry13](https://github.com/DavidCBerry13) - David Berry (1)
- [duracellko](https://github.com/duracellko) - Rastislav Novotný (1)
- [EdwinVW](https://github.com/EdwinVW) - Edwin van Wijk (1)
- [FacioRatio](https://github.com/FacioRatio) - Eric Robson (1)
- [ferenczy](https://github.com/ferenczy) - Dawid Ferenczy Rogožan (1)
- [gfoidl](https://github.com/gfoidl) - Günther Foidl (1)
- [ghogen](https://github.com/ghogen) - Gordon Hogenson (1)
- [Happypig375](https://github.com/Happypig375) - Hadrian Tang (1)
- [hyoshioka0128](https://github.com/hyoshioka0128) - Hiroshi Yoshioka (1)
- [ketchup-cfg](https://github.com/ketchup-cfg) - Trevor Pierce (1)
- [konrad-jamrozik](https://github.com/konrad-jamrozik) - Konrad Jamrozik (1)
- [KrakenZ](https://github.com/KrakenZ) - Paris Julien (1)
- [LakshanF](https://github.com/LakshanF) - Lakshan Fernando (1)
- [maembe](https://github.com/maembe) (1)
- [mstancombe](https://github.com/mstancombe) (1)
- [paulomorgado](https://github.com/paulomorgado) - Paulo Morgado (1)
- [Sankra](https://github.com/Sankra) - Runar Ovesen Hjerpbakk (1)
- [seangwright](https://github.com/seangwright) - Sean G. Wright (1)
- [SebastianKirsch123](https://github.com/SebastianKirsch123) (1)
- [SetTrend](https://github.com/SetTrend) - Axel D. (1)
- [shahriaarrr](https://github.com/shahriaarrr) - shahriaarrr (1)
- [StevenJDH](https://github.com/StevenJDH) - Steven Jenkins De Haro (1)
- [StingyJack](https://github.com/StingyJack) - Andrew Stanton (1)
- [sughosneo](https://github.com/sughosneo) - Sumit Ghosh (1)
- [svick](https://github.com/svick) - Petr Onderka (1)
- [TysonMN](https://github.com/TysonMN) - Tyson Williams (1)
- [v-kents](https://github.com/v-kents) - Kent Sharkey (1)
- [vlada-shubina](https://github.com/vlada-shubina) - Vlada Shubina (1)
- [xPaw](https://github.com/xPaw) - Pavel Djundik (1)

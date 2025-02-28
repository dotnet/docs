---
title: ".NET docs: What's new for January 2025"
description: "What's new in the .NET docs for January 2025."
ms.custom: January-2025
ms.date: 02/01/2025
---

# .NET docs: What's new for January 2025

Welcome to what's new in the .NET docs for January 2025. This article lists some of the major changes to docs during this period.

## .NET breaking changes

### New articles

- [`dotnet sln add` no longer allows invalid file names](../core/compatibility/sdk/9.0/dotnet-sln.md)
- [ActivitySource.CreateActivity and ActivitySource.StartActivity behavior change](../core/compatibility/core-libraries/10.0/activity-sampling.md)
- [API obsoletions with non-default diagnostic IDs (.NET 10)](../core/compatibility/core-libraries/10.0/obsolete-apis.md)
- [Breaking changes in .NET 10](../core/compatibility/10.0.md)
- [C# 14 overload resolution with span parameters](../core/compatibility/core-libraries/10.0/csharp-overload-resolution.md)
- [Consistent shift behavior in generic math](../core/compatibility/core-libraries/10.0/generic-math.md)
- [Default RID used when targeting .NET Framework](../core/compatibility/sdk/9.0/default-rid.md)
- [Environment variable renamed to DOTNET_ICU_VERSION_OVERRIDE](../core/compatibility/globalization/10.0/version-override.md)
- [LDAP DirectoryControl parsing is now more stringent](../core/compatibility/core-libraries/10.0/ldap-directorycontrol-parsing.md)
- [MacCatalyst version normalization](../core/compatibility/core-libraries/10.0/maccatalyst-version-normalization.md)
- [Renamed parameter in HtmlElement.InsertAdjacentElement](../core/compatibility/windows-forms/10.0/insertadjacentelement-orientation.md)
- [TreeView checkbox image truncation](../core/compatibility/windows-forms/10.0/treeview-text-location.md)
- [X500DistinguishedName validation is stricter](../core/compatibility/cryptography/10.0/x500distinguishedname-validation.md)

## AI in .NET

### New articles

- [Create a minimal AI assistant using .NET](/dotnet/ai/quickstarts/create-assistant)

## .NET fundamentals

### New articles

- [.NET SDK container creation overview](../core/containers/overview.md)
- [CA2024: Do not use StreamReader.EndOfStream in async methods](../fundamentals/code-analysis/quality-rules/ca2024.md)
- [Containerize a .NET app with dotnet publish](../core/containers/sdk-publish.md)
- [Distributed tracing in System.Net libraries](../fundamentals/networking/telemetry/tracing.md)
- [Keyed DI support in `IHttpClientFactory`](../core/extensions/httpclient-factory-keyed-di.md)
- [MSTEST0038: Don't use 'Assert.AreSame' or 'Assert.AreNotSame' with value types](../core/testing/mstest-analyzers/mstest0038.md)
- [MSTEST0039: Use newer 'Assert.Throws' methods](../core/testing/mstest-analyzers/mstest0039.md)
- [MSTEST0040: Do not assert inside 'async void' contexts](../core/testing/mstest-analyzers/mstest0040.md)
- [NETSDK1032: RuntimeIdentifier and PlatformTarget must be compatible](../core/tools/sdk-errors/netsdk1032.md)
- [NETSDK1144: Optimizing assemblies for size failed](../core/tools/sdk-errors/netsdk1144.md)
- [Preview APIs](../fundamentals/runtime-libraries/preview-apis.md)
- [QUIC configuration options](../fundamentals/networking/quic/quic-options.md)
- [Serialization extension methods on HttpClient](../standard/serialization/system-text-json/httpclient-extensions.md)
- [SYSLIB0058: Certain SslStream properties are obsolete](../fundamentals/syslib-diagnostics/syslib0058.md)
- [SYSLIB0059: SystemEvents.EventsThreadShutdown callbacks aren't run before the process exits](../fundamentals/syslib-diagnostics/syslib0059.md)
- [SYSLIB0060: Rfc2898DeriveBytes constructors are obsolete](../fundamentals/syslib-diagnostics/syslib0060.md)

### Updated articles

- [Creating metrics](../core/diagnostics/metrics-instrumentation.md) - [diagnostics] Add InstrumentAdvice details to instrumentation doc
- [dotnet-coverage code coverage utility](../core/additional-tools/dotnet-coverage.md) - Update dotnet-coverage docs. Adding uninstrument command
- [Microsoft.Testing.Platform and VSTest comparison](../core/testing/unit-testing-platform-vs-vstest.md) - Add first level info for migration off of VSTest
- [Tutorial: Containerize a .NET app](../core/docker/build-container.md) - Address issues related to .NET containers

## C# language

### New articles

- [Custom attributes that generate flags or options in the Intermediate Language (IL) output](../csharp/language-reference/attributes/pseudo-attributes.md)

## Visual Basic language

### Updated articles

- [Generic types in Visual Basic (Visual Basic)](../visual-basic/programming-guide/language-features/data-types/generic-types.md) - Add VB new features

## Azure SDK for .NET

### New articles

- [Authentication best practices with the Azure Identity library for .NET](../azure/sdk/authentication/best-practices.md)

## Microsoft Orleans

### New articles

- [Grain directory implementation](../orleans/implementation/grain-directory.md)

### Updated articles

- [Background Services and Startup Tasks](../orleans/host/configuration-guide/startup-tasks.md) - [Orleans] Update startup tasks guidance
- [Cluster management in Orleans](../orleans/implementation/cluster-management.md) - [Orleans] Update clustering implementation docs

## .NET Framework

### New articles

- [.NET Framework release notes](../framework/release-notes/release-notes.md)
- [January 2025 cumulative update](../framework/release-notes/2025/01-14-january-cumulative-update.md)

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [shethaadit](https://github.com/shethaadit) - Adit Sheth ![17 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-17-green)
- [BartoszKlonowski](https://github.com/BartoszKlonowski) - Bartosz Klonowski ![7 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-7-green)
- [azarboon](https://github.com/azarboon) - Mahdi Azarboon ![3 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-3-green)
- [theluckyprogrammer](https://github.com/theluckyprogrammer) - Tomasz Osmanowski ![3 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-3-green)
- [mpidash](https://github.com/mpidash) - Mario Pistrich ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [Rageking8](https://github.com/Rageking8) -  ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [frdij](https://github.com/frdij) - Frans van Dijk ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [gregoryagu](https://github.com/gregoryagu) - Greg Gum ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [joproulx](https://github.com/joproulx) - Jonathan ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [K4PS3](https://github.com/K4PS3) - khaled ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [MangelMaxime](https://github.com/MangelMaxime) - Maxime Mangel ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [mguinness](https://github.com/mguinness) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [RandaZraik](https://github.com/RandaZraik) - Randa Zraik ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [rkargMsft](https://github.com/rkargMsft) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [samwherever](https://github.com/samwherever) - Sam Allen ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [SetTrend](https://github.com/SetTrend) - Axel D. ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ShaoHans](https://github.com/ShaoHans) - ShaoHans ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [wasabii](https://github.com/wasabii) - Jerome Haltom ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [willibrandon](https://github.com/willibrandon) - Brandon Williams ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [zacharylayne](https://github.com/zacharylayne) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)

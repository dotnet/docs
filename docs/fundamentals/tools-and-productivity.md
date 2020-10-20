---
title: Tools and productivity in .NET
author: IEvangelist
description: Learn about the various tooling, software development kits, diagnostic tools, and code analyzers available to .NET developers.
ms.author: dapine
ms.date: 10/20/2020
ms.topic: overview
---

# Tools and productivity in .NET

In this article, you'll learn about the various tools available to .NET developers. With .NET, you have a robust software development kit (SDK), that includes a command-line interface (CLI) namely, the .NET CLI. The .NET CLI powers many of the features throughout the .NET-ready integrated development environments (IDEs). This article also provides resources to productivity capabilities, such as .NET CLI tools for diagnosing performance issues, memory leaks, high CPU, deadlocks, and as well as tooling support for code analysis.

## Tools

Many tools are available to .NET developers, such as the .NET SDK, .NET CLI, IDEs, and so on.

### .NET SDK

You can download [.NET SDK](https://dotnet.microsoft.com/download) or .NET Runtime for Windows, Linux, macOS, or Docker. For more information, see [.NET SDK overview](../core/sdk.md).

### .NET CLI

The .NET CLI is a cross-platform toolchain for developing, building, running, and publishing .NET applications. The .NET CLI is included with the .NET SDK. For more information, see [.NET CLI overview](../core/tools/index.md).

### IDEs

The .NET SDK powers language services, that exposes .NET developer functionality in [Visual Studio Code](https://code.visualstudio.com). As part of the [Visual Studio](https://visualstudio.microsoft.com/vs) family, [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac) enables macOS developers to write .NET applications.

### Additional tools

In addition to the more common tools, the .NET team has also provided tools for specific scenarios. Some of the use cases include uninstalling the .NET SDK or the .NET Runtime, or handling Windows Communication Foundation (WCF) refences, XML serialization, and so on. For more information, see [.NET additional tools overview](../core/additional-tools/index.md).

## Productivity

Being a productive developer includes relying on tooling to analyze application performance.

### Diagnostics and instrumentation

As a .NET developer, common performance diagnostic tools exist to monitor, trace, collect, and analyze dump files. You can collect performance metrics with EventCounters, and use profiling tools to gain insights into how apps perform. For more information, see [.NET diagnostics tools](../core/diagnostics/index.md).

### Code analysis

The .NET compiler platform (Roslyn) analyzers inspect your C# or Visual Basic code for code quality and code style issues. For more information, see [.NET source code analysis overview](code-analysis/overview.md).

## See also

- [.NET project SDKs](../core/project-sdk/overview.md)

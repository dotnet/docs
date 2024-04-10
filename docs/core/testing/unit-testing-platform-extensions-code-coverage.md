---
title: Microsoft.Testing.Platform Code Coverage extensions
description: Learn about the various Microsoft.Testing.Platform Code Coverage extensions and how to use them.
author: evangelink
ms.author: amauryleve
ms.date: 04/10/2024
---

# Code coverage extensions

This article list and explains all `Microsoft Testing Platform` extensions related to the code coverage capability.

To determine what proportion of your project's code is being tested by coded tests such as unit tests, you can use the code coverage feature. To effectively guard against bugs, your tests should exercise or 'cover' a large proportion of your code.

## Coverlet

There is currently no Coverlet extension but you can use [Coverlet .NET global tool](https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue).

## Microsoft code coverage

Microsoft Code Coverage analysis is possible for both managed (CLR) and unmanaged (native) code. Both static and dynamic instrumentation are supported. This extension is shipped as part of [Microsoft.Testing.Extensions.CodeCoverage](https://nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) NuGet package.

> [!NOTE]
> Unmanaged (native) code coverage is disabled in the extension by default. Use flags `EnableStaticNativeInstrumentation` and `EnableDynamicNativeInstrumentation` to enable it if needed.
> For more information about unmanaged code coverage, see [Static and dynamic native instrumentation](/visualstudio/test/customizing-code-coverage-analysis?#static-and-dynamic-native-instrumentation).

> [!NOTE]
> The package is shipped with Microsoft .NET LIBRARY closed-source free to use licensing model.

For more information about Microsoft code coverage, see its [GitHub page](https://github.com/microsoft/codecoverage).

Microsoft Code Coverage provides the following options:

| Option | Description |
|--|--|
| `--coverage` | Collect the code coverage using dotnet-coverage tool |
| `--coverage-output` | Output file |
| `--coverage-output-format` | Output file format. Supported values: 'coverage', 'xml' and 'cobertura' |
| `--coverage-settings` | XML code coverage settings |

For more information about the available options, see [settings](../additional-tools/dotnet-coverage.md#settings) and [samples](https://github.com/microsoft/codecoverage/tree/main/samples/Algorithms).

---
title: Microsoft.Testing.Platform Code Coverage extensions
description: Learn about the various Microsoft.Testing.Platform Code Coverage extensions and how to use them.
author: evangelink
ms.author: amauryleve
ms.date: 02/19/2026
ai-usage: ai-assisted
---

# Code coverage extensions

This article lists and explains all Microsoft.Testing.Platform extensions related to the code coverage capability.

You can use the code coverage feature to determine what proportion of your project's code is being tested by coded tests such as unit tests. To effectively guard against bugs, your tests should exercise or *cover* a large proportion of your code.

## Microsoft code coverage

Microsoft Code Coverage analysis is possible for both managed (CLR) and unmanaged (native) code. Both static and dynamic instrumentation are supported. This extension is shipped as part of [Microsoft.Testing.Extensions.CodeCoverage](https://nuget.org/packages/Microsoft.Testing.Extensions.CodeCoverage) NuGet package.

> [!NOTE]
> Unmanaged (native) code coverage is disabled in the extension by default. Use flags `EnableStaticNativeInstrumentation` and `EnableDynamicNativeInstrumentation` to enable it if needed.
> For more information about unmanaged code coverage, see [Static and dynamic native instrumentation](/visualstudio/test/customizing-code-coverage-analysis?#static-and-dynamic-native-instrumentation).

> [!IMPORTANT]
> The package is shipped with Microsoft .NET library closed-source free to use licensing model.

For more information about Microsoft code coverage, see its [GitHub page](https://github.com/microsoft/codecoverage).

Microsoft Code Coverage provides the following options:

| Option                     | Description                                                                   |
|----------------------------|-------------------------------------------------------------------------------|
| `--coverage`               | Collect the code coverage using dotnet-coverage tool.                         |
| `--coverage-output`        | The name or path of the produced coverage file. By default, the file is `TestResults/<guid>.coverage`. |
| `--coverage-output-format` | Output file format. Supported values are: `coverage`, `xml`, and `cobertura`. Default is `coverage`. |
| `--coverage-settings`      | [XML code coverage settings](../additional-tools/dotnet-coverage.md#settings). |

For more information about the available options, see [settings](../additional-tools/dotnet-coverage.md#settings) and [samples](https://github.com/microsoft/codecoverage/tree/main/samples/Algorithms).

> [!NOTE]
> The default value of `IncludeTestAssembly` in Microsoft.Testing.Extensions.CodeCoverage is `false`, while it used to be `true` in VSTest. This means that test projects are excluded by default. For more information, see [Code Coverage configuration](https://github.com/microsoft/codecoverage/blob/main/docs/configuration.md).

## Version compatibility

The following table shows the compatibility between different versions of Microsoft.Testing.Extensions.CodeCoverage and Microsoft.Testing.Platform:

| Microsoft.Testing.Extensions.CodeCoverage | Microsoft.Testing.Platform |
|------------------------------------------|---------------------------|
| 18.1.x                                  | 2.0.x                     |
| 18.0.x                                  | 1.8.x                     |
| 17.14.x                                  | 1.6.2                     |

> [!NOTE]
> For the best compatibility and latest features, it's recommended to use the latest versions of both packages together.

## Coverlet

The Coverlet Microsoft Testing Platform Integration (`coverlet.MTP`) is a native extension for Microsoft.Testing.Platform that implements `coverlet.collector` functionality.

Add the `coverlet.MTP` NuGet package to your test project:

```bash
dotnet add package coverlet.MTP
```

To collect code coverage, run your tests with the `--coverlet` flag:

```bash
dotnet test --coverlet
```

Or run your test executable with the `--coverlet` flag:

```bash
dotnet exec <test-assembly.dll> --coverlet
```

After the test run, a `coverage.json` file containing the results is generated in the current directory.

`coverlet.MTP` provides the following options:

| Option | Description |
| :------- | :------------ |
| `--coverlet` | Enable code coverage data collection. |
| `--coverlet-output-format <format>` | Output formats for the coverage report. Supported formats: `json`, `lcov`, `opencover`, `cobertura`, and `teamcity`. Specify multiple times to include more than one format. |
| `--coverlet-include <filter>` | Include assemblies that match filters, such as `[Assembly]Type`. Specify multiple times to add more filters. |
| `--coverlet-include-directory <path>` | Include extra directories for source files. Specify multiple times to add more directories. |
| `--coverlet-exclude <filter>` | Exclude assemblies that match filters, such as `[Assembly]Type`. Specify multiple times to add more filters. |
| `--coverlet-exclude-by-file <pattern>` | Exclude source files that match glob patterns. Specify multiple times to add more patterns. |
| `--coverlet-exclude-by-attribute <attribute>` | Exclude methods or classes decorated with specific attributes. Specify multiple times to add more attributes. |
| `--coverlet-include-test-assembly` | Include the test assembly in the coverage report. |
| `--coverlet-single-hit` | Limit the number of hits to one for each location in the code. |
| `--coverlet-skip-auto-props` | Skip auto-implemented properties in the coverage. |
| `--coverlet-does-not-return-attribute <attribute>` | Attributes that mark methods as not returning. Specify multiple times to add more attributes. |
| `--coverlet-exclude-assemblies-without-sources <value>` | Exclude assemblies without source code. Values: `MissingAll`, `MissingAny`, and `None`. |

For more information, see the [coverlet.MTP documentation](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/Coverlet.MTP.Integration.md).

---
title: What's new in the SDK and tooling for .NET 10
description: Learn about the new .NET SDK features introduced in .NET 10.
titleSuffix: ""
ms.date: 07/16/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in the SDK and tooling for .NET 10

This article describes new features and enhancements in the .NET SDK for .NET 10.

## .NET tools enhancements

### Platform-specific .NET tools

.NET tools can now be published with support for multiple RuntimeIdentifiers (RIDs) in a single package. Tool authors can bundle binaries for all supported platforms, and the .NET CLI will select the correct one at install or run time. This makes cross-platform tool authoring and distribution much easier.

These enhanced tools support various packaging variations:

- **Framework-dependent, platform-agnostic** (classic mode, runs anywhere with .NET 10 installed)
- **Framework-dependent, platform-specific** (smaller, optimized for each platform)
- **Self-contained, platform-specific** (includes the runtime, no .NET installation required)
- **Trimmed, platform-specific** (smaller, trims unused code)
- **AOT-compiled, platform-specific** (maximum performance and smallest deployment)

These new tools work much like normal published applications, so any publishing options you can use with applications (self-contained, trimmed, AOT, etc.) can apply to tools as well.

### One-shot tool execution

You can now use the `dotnet tool exec` command to execute a .NET tool without installing it globally or locally. This is especially valuable for CI/CD or ephemeral usage.

```bash
dotnet tool exec --source ./artifacts/package/ toolsay "Hello, World!"
```

This downloads and runs the specified tool package in one command. By default, users are prompted to confirm the download if the tool doesn't already exist locally. The latest version of the chosen tool package is used unless an explicit version is specified.

One-shot tool execution works seamlessly with local tool manifests. If you run a tool from a location containing a `.config/dotnet-tools.json` nearby, the version of the tool in that configuration will be used instead of the latest version available.

### The new `dnx` tool execution script

The `dnx` script provides a streamlined way to execute tools. It forwards all arguments to the `dotnet` CLI for processing, making tool usage as simple as possible:

```bash
dnx toolsay "Hello, World!"
```

The actual implementation of the `dnx` command is in the `dotnet` CLI itself, allowing its behavior to evolve over time.

For more information about managing .NET tools, see [Manage .NET tools](/dotnet/core/tools/global-tools).

### CLI introspection with `--cli-schema`

A new `--cli-schema` option is available on all CLI commands. When used, it outputs a JSON representation of the CLI command tree for the invoked command or subcommand. This is useful for tool authors, shell integration, and advanced scripting.

```bash
dotnet clean --cli-schema
```

The output provides a structured, machine-readable description of the command's arguments, options, and subcommands.

## File-based apps enhancements

.NET 10 brings significant updates to the file-based apps experience, including publish support and native AOT capabilities.

### Enhanced file-based apps with publish support and native AOT

File-based apps now support being published to native executables via the `dotnet publish app.cs` command, making it easier to create simple apps that you can redistribute as native executables. All file-based apps now target native AOT by default. If you need to use packages or features that are incompatible with native AOT, you can disable this using the `#:property PublishAot=false` directive in your .cs file.

File-based apps also include enhanced features:

- **Project referencing**: Support for referencing projects via the `#:project` directive
- **Runtime path access**: App file and directory paths are available at runtime via `System.AppContext.GetData`
- **Enhanced shebang support**: Direct shell execution with improved shebang handling, including support for extensionless files

These enhancements make file-based apps more powerful while maintaining their simplicity for quick scripting and prototyping scenarios.

For more information about native AOT, see [.NET native AOT](/dotnet/core/deploying/native-aot/).

## Pruning of framework-provided package references

Starting in .NET 10, the [NuGet Audit](/nuget/concepts/auditing-packages) feature can now [prune framework-provided package references](https://github.com/NuGet/Home/blob/451c27180d14214bca60483caee57f0dc737b8cf/accepted/2024/prune-package-reference.md) that aren't used by the project. This feature is enabled by default for all `net` target frameworks (for example, `net8.0` and `net10.0`) and .NET Standard 2.0 and greater target frameworks. This change helps reduce the number of packages that are restored and analyzed during the build process, which can lead to faster build times and reduced disk space usage. It also can lead to a reduction in false positives from NuGet Audit and other dependency-scanning mechanisms.

When this feature is enabled, you might see a reduction in the contents of your applications' generated *.deps.json* files. Any package references supplied by the .NET runtime are automatically removed from the generated dependency file.

While this feature is enabled by default for the listed TFMs, you can disable it by setting the `RestoreEnablePackagePruning` property to `false` in your project file or *Directory.Build.props* file.

## More consistent command order

Starting in .NET 10, the `dotnet` CLI tool includes new aliases for common commands to make them easier to remember and type. The new commands are shown in the following table.

| New noun-first form                                                 | Alias for                 |
|---------------------------------------------------------------------|---------------------------|
| [`dotnet package add`](../../tools/dotnet-package-add.md)           | `dotnet add package`      |
| [`dotnet package list`](../../tools/dotnet-package-list.md)         | `dotnet list package`     |
| [`dotnet package remove`](../../tools/dotnet-package-remove.md)     | `dotnet remove package`   |
| [`dotnet reference add`](../../tools/dotnet-reference-add.md)       | `dotnet add reference`    |
| [`dotnet reference list`](../../tools/dotnet-reference-list.md)     | `dotnet list reference`   |
| [`dotnet reference remove`](../../tools/dotnet-reference-remove.md) | `dotnet remove reference` |

The new noun-first forms align with general CLI standards, making the `dotnet` CLI more consistent with other tools. While the verb-first forms continue to work, it's better to use the noun-first forms for improved readability and consistency in scripts and documentation.

## CLI commands default to interactive mode in interactive terminals

The `--interactive` flag is now enabled by default for CLI commands in interactive terminals. This change allows commands to dynamically retrieve credentials or perform other interactive behaviors without requiring the flag to be explicitly set. For noninteractive scenarios, you can disable interactivity by specifying `--interactive false`.

## Native shell tab-completion scripts

The `dotnet` CLI now supports generating native tab-completion scripts for popular shells using the `dotnet completions generate [SHELL]` command. Supported shells include `bash`, `fish`, `nushell`, `powershell`, and `zsh`. These scripts improve usability by providing faster and more integrated tab-completion features. For example, in PowerShell, you can enable completions by adding the following to your `$PROFILE`:

```powershell
dotnet completions script pwsh | out-String | Invoke-Expression -ErrorAction SilentlyContinue
```

## Console apps can natively create container images

Console apps can now create container images via `dotnet publish /t:PublishContainer` without requiring the `<EnableSdkContainerSupport>` property in the project file. This aligns console apps with the behavior of ASP.NET Core and Worker SDK apps.

## Explicitly control the image format of containers

A new `<ContainerImageFormat>` property allows you to explicitly set the format of container images to either `Docker` or `OCI`. This property overrides the default behavior, which depends on the base image format and whether the container is multi-architecture.

## Support for Microsoft Testing Platform in `dotnet test`

Starting in .NET 10, `dotnet test` natively supports [Microsoft.Testing.Platform](../../testing/microsoft-testing-platform-intro.md). To enable this feature, add the following configuration to your *dotnet.config* file:

```ini
[dotnet.test.runner]
name = "Microsoft.Testing.Platform"
```

For more details, see [Testing with `dotnet test`](../../testing/unit-testing-with-dotnet-test.md).

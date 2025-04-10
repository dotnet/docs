---
title: What's new in the SDK and tooling for .NET 10
description: Learn about the new .NET SDK features introduced in .NET 10.
titleSuffix: ""
ms.date: 04/09/2025
ms.topic: whats-new
ai-usage: ai-assisted
---

# What's new in the SDK and tooling for .NET 10

This article describes new features and enhancements in the .NET SDK for .NET 10. It's updated for Preview 3.

## Pruning of framework-provided package references

Starting in .NET 10, the [NuGet Audit](/nuget/concepts/auditing-packages) feature can now [prune framework-provided package references](https://github.com/NuGet/Home/blob/451c27180d14214bca60483caee57f0dc737b8cf/accepted/2024/prune-package-reference.md) that aren't used by the project. This feature is enabled by default for all `net` target frameworks (for example, `net8.0` and `net10.0`) and .NET Standard 2.0 and greater target frameworks. This change helps reduce the number of packages that are restored and analyzed during the build process, which can lead to faster build times and reduced disk space usage. It also can lead to a reduction in false positives from NuGet Audit and other dependency-scanning mechanisms.

When this feature is enabled, you may see a reduction in the contents of your applications' generated *.deps.json* files. Any package references supplied by the .NET runtime are automatically removed from the generated dependency file.

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

Starting in .NET 10, `dotnet test` natively supports the [Microsoft.Testing.Platform](../../testing/microsoft-testing-platform-intro.md). To enable this feature, add the following configuration to your *dotnet.config* file:

```ini
[dotnet.test:runner]
name = "Microsoft.Testing.Platform"
```

> [!NOTE]
> The `[dotnet.test:runner]` part will change to `[dotnet.test.runner]` in Preview 4.

For more details, see [Testing with `dotnet test`](../../testing/unit-testing-with-dotnet-test.md).

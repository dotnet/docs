---
title: dotnet tool exec command
description: The dotnet tool exec command downloads and invokes a .NET tool in one step without permanent installation.
ms.date: 09/06/2025
---
# dotnet tool exec

**This article applies to:** ✔️ .NET 10.0.100-preview.6 SDK and later versions

## Name

`dotnet tool exec` - Downloads and invokes a .NET tool without permanently installing it.

## Synopsis

```dotnetcli
dotnet tool exec <PACKAGE_NAME>[@<VERSION>]
    [--allow-roll-forward] [-a|--arch <ARCHITECTURE>]
    [--add-source <SOURCE>] [--configfile <FILE>] [--disable-parallel]
    [--framework <FRAMEWORK>] [--ignore-failed-sources] [--interactive]
    [--no-http-cache] [--prerelease]
    [-v|--verbosity <LEVEL>]
    [--] [<tool-arguments>...]

dotnet tool exec -h|--help
```

## Description

The `dotnet tool exec` command provides a one-shot tool invocation mode for .NET Tools. It automatically downloads the specified tool package to the NuGet cache and invokes it without modifying your system PATH or requiring permanent installation.

When you run `dotnet tool exec`, the command:

1. Checks the version (or version range) you specify (or the latest version if none is specified) against your configured NuGet feeds to decide which package to download
2. Downloads the specified package to the NuGet cache (if not already present)
3. Invokes the tool with any provided arguments
4. Returns the tool's exit code

`dotnet tool exec` works seamlessly with both global and local tools. If you have a local tool manifest available, it uses the manifest to determine which version of the tool to run.

This command also exists in two other forms for easier use

* `dotnet dnx` - a hidden alias for `dotnet tool exec` that is mostly used to give us a point to easily implement the
* `dnx` - a shell script that invokes `dotnet dnx` from the SDK. This script is provided by the installer and is available on the PATH. It allows for very simple use of Tools directly via `dnx <toolname>`.

## Arguments

- **`PACKAGE_NAME`**

  The NuGet package ID of the .NET tool to execute. You can optionally specify a version using the `@` syntax, for example `dotnetsay@2.1.0`.

- **`tool-arguments`**

  Arguments to pass to the tool being executed. Everything after `--` is passed directly to the tool.

## Options

- **`--allow-roll-forward`**

  Allow the tool to use a newer version of the .NET runtime if the runtime it targets isn't installed.

- **`--add-source <SOURCE>`**

  Adds an additional NuGet package source to use during installation. Feeds are accessed in parallel, not in a fallback cascade sequence. If the same package and version is available in multiple feeds, the fastest feed wins. See [What happens when a NuGet package is installed](/nuget/concepts/package-installation-process#what-happens-when-a-nuget-package-is-installed). This can be controlled through the use of NuGet Package Source Mapping. For more information, see [Package Source Mapping](~/nuget/consume-packages/package-source-mapping).

- **`--configfile <FILE>`**

  The NuGet configuration file (*nuget.config*) to use. If specified, only the settings from this file will be used. If not specified, the hierarchy of configuration files from the current directory will be used. For more information, see [Common NuGet Configurations](~/nuget/consume-packages/configuring-nuget-behavior).

- **`--disable-parallel`**

  Disables querying the configured NuGet feeds in parallel.

- **`--ignore-failed-sources`**

  Treats package source failures as warnings.

- **`--interactive`**

  Allows the command to stop and wait for user input or action. For example, to complete authentication. This is defaulted to `true` when the command detects that it's being run directly by a user.

- **`--no-http-cache`**

  Doesn't cache HTTP requests to the configured NuGet feeds.

- **`--prerelease`**

  Allows prerelease packages to be selected when resolving the version to install.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `normal`.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- **`dotnet tool exec dotnetsay`**

  Downloads (if necessary) and runs the latest version of the `dotnetsay` tool.

- **`dotnet tool exec dotnetsay@2.1.0`**

  Downloads (if necessary) and runs version 2.1.0 of the `dotnetsay` tool.

- **`dotnet tool exec dotnetsay@2.*`**

  Downloads (if necessary) and runs the latest version of the `dotnetsay` tool in the 2.x version range.

- **`dotnet tool exec dotnetsay -- Hello World`**

  Runs the `dotnetsay` tool and passes "Hello World" as arguments to the tool.

- **`dotnet tool exec --add-source https://api.nuget.org/v3/index.json mytool`**

  Downloads and runs `mytool` using the specified NuGet source.

## Comparison with other commands

This command is intended to be a unified way to work with .NET Tools. While the previously-available Tool installation commands remain available, we think that `dotnet tool exec` provides a simpler and more flexible experience for most users.

| Command | Purpose | Installation | Scope |
|---------|---------|--------------|-------|
| `dotnet tool exec` | One-shot execution | None (cached only) | Temporary |
| `dotnet tool install -g` | Permanent global installation | Global | System-wide |
| `dotnet tool install` | Permanent local installation | Local manifest | Project |
| `dotnet tool run` | Run an already-installed local tool | Requires prior installation | Project |

The `dotnet tool install -g` command does still serve an important purpose for users who want to permanently install a tool. However, for users who want to try out a tool or run it in a CI/CD pipeline, `dotnet tool exec` is often a better fit.

## See also

- [.NET tools](global-tools.md)
- [dotnet tool install](dotnet-tool-install.md)
- [dotnet tool run](dotnet-tool-run.md)
- [Tutorial: Install and use a .NET global tool using the .NET CLI](global-tools-how-to-use.md)
- [Tutorial: Install and use a .NET local tool using the .NET CLI](local-tools-how-to-use.md)

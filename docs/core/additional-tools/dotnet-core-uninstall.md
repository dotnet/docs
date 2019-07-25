---
title: .NET Core Uninstall Tool
description: An overview of the .NET Core Uninstall Tool, a guided tool that enables the controlled clean-up of .NET Core SDKs and Runtimes.
author: yuchong-pan
ms.date: 07/25/2019
---
# .NET Core Uninstall Tool

The [.NET Core Uninstall Tool (`dotnet-core-uninstall`)](https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool) is a guided tool provided to enable the controlled clean-up of a system such that only the desired versions of .NET Core SDKs and Runtimes remain. A collection of options is available to facilitate the aggregation of uninstallations.

The tool currently supports Windows and macOS. The Linux operating systems are not supported because .NET Core installations and clean-up are well managed by package managers.

Note that the Windows version of this tool can only uninstall .NET Core SDKs and Runtimes that were installed using .NET Core SDK or Runtime installers.

## Installing

You can download the .NET Core Uninstall Tool from [https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool](https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool) and put the single executable (`dotnet-core-uninstall.exe`) in a directory.

__Note__: Be aware that, since the tool requires elevation, it should be installed in a write-protected directory (e.g., `C:\Program Files` on Windows and `/usr/local/bin` on macOS).

## Display installed .NET Core SDKs and Runtimes

`dotnet-core-uninstall list` lists installed .NET Core SDKs and Runtimes that can be removed with this tool.

### Synopsis

```
dotnet-core-uninstall list [options]
```

### Options

# [Windows](#tab/windows)

* **`--aspnet-runtime`**

  List ASP.NET Core Runtimes.

* **`--hosting-bundle`**

  List .NET Core Runtime & Hosting Bundles.

* **`--runtime`**

  List .NET Core Runtimes.

* **`--sdk`**

  List .NET Core SDKs.

* **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

* **`--x64`**

  List x64 .NET Core SDKs or Runtimes.

* **`--x86`**

  List x86 .NET Core SDKs or Runtimes.

# [macOS](#tab/macos)

* **`--runtime`**

  List .NET Core Runtimes.

* **`--sdk`**

  List .NET Core SDKs.

* **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

* **`--x64`**

  List x64 .NET Core SDKs or Runtimes.

* **`--x86`**

  List x86 .NET Core SDKs or Runtimes.
  
---

### Examples

* List all .NET Core SDKs and Runtimes that can be removed with this tool:

  ```
  dotnet-core-uninstall list
  ```

* List all x64 .NET Core SDKs and Runtimes:

  ```
  dotnet-core-uninstall list --x64
  ```

* List all x86 .NET Core SDKs:

  ```
  dotnet-core-uninstall list --sdk --x86
  ```

## Uninstalling .NET Core SDKs and Runtimes

`dotnet-core-uninstall` uses a collection of options to aggregate uninstallations, as shown below.

Since this is a destructive tool, the default behavior of a command execution is a dry run; the tool displays the .NET Core SDKs and Runtimes to be uninstalled. To actually uninstall the items, re-run the command with the `--do-it` option.

Since the tool requires elevation to uninstall .NET Core SDKs and Runtimes, it should be run with elevated access. On Windows, run the tool in a command prompt with administrator privileges. On macOS, add `sudo` before the command.

### Synopsis

```
dotnet-core-uninstall [options] [<VERSION>...]
```

### Arguments

`VERSION`

The specified version to uninstall.

### Options

# [Windows](#tab/windows)

* **`--all`**

  Remove all .NET Core SDKs or Runtimes.

* **`--all-below <VERSION>`**

  Remove .NET Core SDKs or Runtimes below the specified version. The specified version will remain.

* **`--all-but <VERSIONS>`**

  Remove .NET Core SDKs or Runtimes, except those specified.

* **`--all-but-latest`**

  Remove .NET Core SDKs or Runtimes, except the one highest version.

* **`--all-lower-patches`**

  Remove .NET Core SDKs or Runtimes that have been superceded by higher patches.

* **`--all-previews`**

  Remove .NET Core SDKs or Runtimes that are marked as previews.

* **`--all-previews-but-latest`**

  Remove .NET Core SDKs or Runtimes that are marked as previews except the one highest preview.

* **`--aspnet-runtime`**

  Remove ASP.NET Core Runtimes only.

* **`--do-it`**

  Actually uninstall specified .NET Core SDKs or Runtimes.

* **`--hosting-bundle`**

  Remove .NET Core Runtime & Hosting Bundles only.

* **`--major-minor <MAJOR_MINOR>`**

  Remove .NET Core SDKs or Runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Remove .NET Core Runtimes only.

* **`--sdk`**

  Remove .NET Core SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

* **`--x64`**

  Can be used with `--sdk`, `--runtime` and `--aspnet-runtime` to remove x64.

* **`--x86`**

  Can be used with `--sdk`, `--runtime` and `--aspnet-runtime` to remove x86.

Note:
1. Exactly one of `--sdk` and `--runtime` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor` and `[<VERSION>...]` are exclusive.
3. If neither of `--x64` or `--x86` is specified, then both x64 and x86 will be removed.

# [macOS](#tab/macos)

* **`--all`**

  Remove all .NET Core SDKs or Runtimes.

* **`--all-below <VERSION>`**

  Remove .NET Core SDKs or Runtimes below the specified version. The specified version will remain.

* **`--all-but <VERSIONS>`**

  Remove .NET Core SDKs or Runtimes, except those specified.

* **`--all-but-latest`**

  Remove .NET Core SDKs or Runtimes, except the one highest version.

* **`--all-lower-patches`**

  Remove .NET Core SDKs or Runtimes that have been superceded by higher patches.

* **`--all-previews`**

  Remove .NET Core SDKs or Runtimes that are marked as previews.

* **`--all-previews-but-latest`**

  Remove .NET Core SDKs or Runtimes that are marked as previews except the one highest preview.

* **`--aspnet-runtime`**

  Remove ASP.NET Core Runtimes only.

* **`--do-it`**

  Actually uninstall specified .NET Core SDKs or Runtimes.

* **`--hosting-bundle`**

  Remove .NET Core Runtime & Hosting Bundles only.

* **`--major-minor <MAJOR_MINOR>`**

  Remove .NET Core SDKs or Runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Remove .NET Core Runtimes only.

* **`--sdk`**

  Remove .NET Core SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

* **`--x64`**

  Can be used with `--sdk`, `--runtime` and `--aspnet-runtime` to remove x64.

* **`--x86`**

  Can be used with `--sdk`, `--runtime` and `--aspnet-runtime` to remove x86.

Note:
1. Exactly one of `--sdk` and `--runtime` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor` and `[<VERSION>...]` are exclusive.
3. If neither of `--x64` or `--x86` is specified, then both x64 and x86 will be removed.

---

### Examples

* Dry run of uninstalling all .NET Core SDKs that can be removed by this tool:

  ```
  dotnet-core-uninstall --all --sdk
  ```

* Uninstall all .NET Core SDKs below the version `2.2.301`:

  ```
  dotnet-core-uninstall --all-below 2.2.301 --sdk --do-it
  ```

* Uninstall all x86 .NET Core Runtimes except the version `3.0.0-preview6-27804-01`:

  ```
  dotnet-core-uninstall --all-but 3.0.0-preview6-27804-01 --runtime --do-it
  ```

* Uninstall all .NET Core 1.1 SDKs:

  ```
  dotnet-core-uninstall --major-minor 1.1 --do-it
  ```

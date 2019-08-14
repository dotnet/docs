---
title: .NET Core Uninstall Tool
description: An overview of the .NET Core Uninstall Tool, a guided tool that enables the controlled clean-up of .NET Core SDKs and Runtimes.
author: yuchong-pan
ms.date: 08/06/2019
---
# .NET Core Uninstall Tool

The [.NET Core Uninstall Tool (`dotnet-core-uninstall`)](https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool) lets you clean-up .NET Core SDKs and Runtimes on a system such that only the desired versions remain. A collection of options is available to specify which versions you want to uninstall.

The tool supports Windows and macOS. Linux is currently not supported.

Note that the Windows version of this tool can only uninstall .NET Core SDKs and Runtimes that were installed using .NET Core SDK or Runtime installers. Prior to Visual Studio 2019 Update 16.3, the Visual Studio installer called the .NET Core SDK installer and these can be uninstalled with the tool. The `dotnet-core-uninstall list` command displays which SDKs can be uninstalled with the tool.  

## How to use the tool

1. Download and install the tool.
2. Display installed .NET Core SDKs and Runtimes that can be removed by this tool.
3. Do a dry run to ensure the right things will be uninstalled, and uninstall .NET Core SDKs and Runtimes by running the tool with Admin privileges.
4. Optional: delete the `NuGetFallbackFolder` if you no longer need it.
5. Remove the `dotnet-core-unintall`  tool.

Read the following sections for details.

### Installing

You can download the .NET Core Uninstall Tool from [https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool](https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool) and put the single executable (`dotnet-core-uninstall.exe`) in a directory.

__Note__: The tool requires elevation to uninstall .NET Core SDKs and Runtimes. Therefore, it should be installed in a write-protected directory such as `C:\Program Files` on Windows and `/usr/local/bin` on macOS. See also [Elevated access for dotnet commands](https://docs.microsoft.com/dotnet/core/tools/elevated-access).

### Displaying installed .NET Core SDKs and Runtimes

`dotnet-core-uninstall list` lists installed .NET Core SDKs and Runtimes that can be removed with this tool.

On Windows, the .NET Core Uninstall Tool can only uninstall things that have been installed via the .NET Core SDK or Runtime installer, or the Visual Studio installer prior to Visual Studio 2019 16.3. On macOS, the tool can only uninstall things in the `/usr/local/share/dotnet` folder. This tool does not work on Linux. Because of these limitations, the tool may not be able to uninstall all of the .NET Core SDKs and Runtimes on your machine. You can use `dotnet --info` to find all of the .NET Core SDK's and Runtimes available, including those this tool cannot remove.

#### Synopsis

```
dotnet-core-uninstall list [options]
```

#### Options

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

#### Examples

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

### Uninstalling .NET Core SDKs and Runtimes

`dotnet-core-uninstall` uses a collection of options to specify what will be uninstalled.

Since this is a destructive tool, it is **highly** recommended that you run with the `--dry-run` option first to determine the .NET Core SDKs and Runtimes that will be removed. [This article explains which SDKs and Runtimes are safe to remove.](https://docs.microsoft.com/dotnet/core/versions/remove-runtime-sdk-versions#should-i-remove-a-version)

***Warning:*** This tool can uninstall versions of the .NET Core SDK that are required by `global.json` files on your machine. You can reinstall .NET Core SDKs from https://dotnet.microsoft.com/download.

***Warning:*** This tool can uninstall versions of the .NET Core Runtime that are required by framework dependent applications on your machine. You can reinstall .NET Core Runtimes from https://dotnet.microsoft.com/download.

***Warning:*** This tool can uninstall versions of the .NET Core SDK and Runtime that Visual Studio relies on. If you break your Visual Studio installation , run "Repair" in the Visual Studio installer to get back to a working state. 

The tool requires elevation to uninstall .NET Core SDKs and Runtimes. Run the tool in an Administrator command prompt on Windows and with `sudo` on macOS. Elevation is not required when the `--dry-run` switch is used.

#### Synopsis

```
dotnet-core-uninstall [options] [<VERSION>...]
```

#### Arguments

`VERSION`

The specified version to uninstall. You may list several versions, and response files are supported.

#### Options

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

* **`--dry-run`**

  Display .NET Core SDKs and Runtimes that will be removed.

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

* **`-y, --yes`**
  Execute the command without requiring Y/n confirmation.

Note:
1. Exactly one of `--sdk`, `--runtime`, `--aspnet-runtime` and `--hosting-bundle` is required.
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

* **`--dry-run`**

  Display .NET Core SDKs and Runtimes that will be removed.

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

* **`-y, --yes`**
  Execute the command without requiring Y/n confirmation.

Note:
1. Exactly one of `--sdk` and `--runtime` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor` and `[<VERSION>...]` are exclusive.
3. If neither of `--x64` or `--x86` is specified, then both x64 and x86 will be removed.

---

#### Examples

* Dry run of uninstalling all .NET Core Runtimes that have been superceded by higher patches.

  ```
  dotnet-core-uninstall --all-lower-patches --runtime --dry-run
  ```

* Dry run of uninstalling all .NET Core SDKs below the version `2.2.301`:

  ```
  dotnet-core-uninstall --all-below 2.2.301 --sdk --dry-run
  ```

* Uninstall all x86 .NET Core Runtimes except the version `3.0.0-preview6-27804-01` without requiring Y/n confirmation:

  ```
  dotnet-core-uninstall --all-but 3.0.0-preview6-27804-01 --runtime --yes
  ```

* Uninstall all .NET Core 1.1 SDKs without requiring Y/n confirmation:

  ```
  dotnet-core-uninstall --major-minor 1.1 -y
  ```

* Uninstall all .NET Core SDKs that can be removed by this tool:

  ```
  dotnet-core-uninstall --all --sdk
  ```

### Optional: deleting `NuGetFallbackFolder`

In some cases, you no longer need the `NuGetFallbackFolder` and may wish to delete it. See this article on [Removing the NuGet Fallback Folder](../versions/remove-runtime-sdk-versions.md#removing-the-nuget-fallback-folder).

### Remove the `dotnet-core-uninstall` tool

Remove the downloaded single executable `dotnet-core-uninstall.exe` from the directory where it was installed.

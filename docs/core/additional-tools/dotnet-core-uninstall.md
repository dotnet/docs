---
title: .NET Core Uninstall Tool
description: An overview of the .NET Core Uninstall Tool, a guided tool that enables the controlled clean-up of .NET Core SDKs and Runtimes.
author: yuchong-pan
ms.date: 08/06/2019
---
# .NET Core Uninstall Tool

The [.NET Core Uninstall Tool](https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool) (`dotnet-core-uninstall`) lets you clean-up .NET Core SDKs and Runtimes on a system such that only the desired versions remain. A collection of options is available to specify which versions you want to uninstall.

The tool supports Windows and macOS. Linux is currently not supported.

Note that the Windows version of this tool can only uninstall .NET Core SDKs and Runtimes that were installed using .NET Core SDK or Runtime installers. Prior to Visual Studio 2019 Update 16.3, the Visual Studio installer called the .NET Core SDK installer and these can be uninstalled with the tool. The `dotnet-core-uninstall list` command displays which SDKs can be uninstalled with the tool.  

## How to use the tool

1. Download and install the tool.
2. Display installed .NET Core SDKs and Runtimes that can be removed by this tool using `dotnet-core-uninstall list`.
3. Use `dotnet-core-uninstall dry-run` to ensure the right things will be uninstalled.
4. Use `dotnet-core-uninstall remove` to uninstall .NET Core SDKs and Runtimes. This must be run with Admin privileges.
5. Optional: delete the `NuGetFallbackFolder` if you no longer need it.
6. Remove the `dotnet-core-uninstall`  tool.

Read the following sections for details.

### Installing

You can download the .NET Core Uninstall Tool from [https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool](https://dotnet.microsoft.com/download/dotnet-core/uninstall-tool) and put the single executable (*dotnet-core-uninstall.exe*) in a directory.

>[!NOTE]
>The tool requires elevation to uninstall .NET Core SDKs or Runtimes. Therefore, it should be installed in a write-protected directory such as *C:\Program Files* on Windows or */usr/local/bin* on macOS. See also [Elevated access for dotnet commands](../tools/elevated-access.md).

### Displaying installed .NET Core SDKs and Runtimes

`dotnet-core-uninstall list` lists installed .NET Core SDKs and Runtimes that can be removed with this tool. Any SDKs or Runtimes that may be required by Visual Studio or SDKs will be displayed with a note of why it is not recommended to uninstall them.

On Windows, the .NET Core Uninstall Tool can only uninstall things that have been installed via the .NET Core SDK or Runtime installer, or the Visual Studio installer prior to Visual Studio 2019 16.3. On macOS, the tool can only uninstall things in the `/usr/local/share/dotnet` folder. This tool does not work on Linux. Because of these limitations, the tool may not be able to uninstall all of the .NET Core SDKs and Runtimes on your machine. You can use `dotnet --info` to find all of the .NET Core SDK's and Runtimes available, including those this tool cannot remove.

#### Synopsis

``` console
dotnet-core-uninstall list [options]
```

#### Options

### [Windows](#tab/windows)

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

### [macOS](#tab/macos)

* **`--runtime`**

  List .NET Core Runtimes.

* **`--sdk`**

  List .NET Core SDKs.

* **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.
  
---

#### Examples

* List all .NET Core SDKs and Runtimes that can be removed with this tool:

  ``` console
  dotnet-core-uninstall list
  ```

* List all x64 .NET Core SDKs and Runtimes:

  ``` console
  dotnet-core-uninstall list --x64
  ```

* List all x86 .NET Core SDKs:

  ``` console
  dotnet-core-uninstall list --sdk --x86
  ```

### Uninstalling .NET Core SDKs and Runtimes

`dotnet-core-uninstall dry-run` and `dotnet-core-uninstall whatif` display the .NET Core SDKs and Runtimes that will be removed based on the options provided without performing the uninstall. These commands are synonyms.

Since this is a destructive tool, it is **highly** recommended that you do a dry run before the running the remove command. This will tell you what .NET Core SDKs and Runtimes that will be removed. [This article explains which SDKs and Runtimes are safe to remove.](/versions/remove-runtime-sdk-versions#should-i-remove-a-version)

`dotnet-core-uninstall remove` uninstalls .NET Core SDKs and Runtimes that are specified by a collection of options.

>[!WARNING]
>This tool can uninstall versions of the .NET Core SDK that are required by `global.json` files on your machine. You can reinstall .NET Core SDKs from https://dotnet.microsoft.com/download.

>[!WARNING]
>This tool can uninstall versions of the .NET Core Runtime that are required by framework dependent applications on your machine. You can reinstall .NET Core Runtimes from https://dotnet.microsoft.com/download.

>[!WARNING]
>This tool can uninstall versions of the .NET Core SDK and Runtime that Visual Studio relies on. If you break your Visual Studio installation , run "Repair" in the Visual Studio installer to get back to a working state.

The tool requires elevation to uninstall .NET Core SDKs and Runtimes. Run the tool in an Administrator command prompt on Windows and with `sudo` on macOS. The `dry-run` and `whatif` commands do not require elevation.

`dotnet-core-uninstall dry-run`, `dotnet-core-uninstall whatif`, and `dotnet-core-uninstall remove` have the same options and arguments. By defualt, all commands will keep SDKs or Runtimes that may be required by Visual Studio or other SDKs. These SDKs and Runtimes can be uninstalled by listing them explicitly as arguments or by using the --force option.

#### Synopsis

``` console
dotnet-core-uninstall dry-run [options] [<VERSION>...]

dotnet-core-uninstall whatif [options] [<VERSION>...]

dotnet-core-uninstall remove [options] [<VERSION>...]
```

#### Arguments

`VERSION`

The specified version to uninstall. You may list several versions. Response files are supported.

#### Options

### [Windows](#tab/windows)

* **`--all`**

  Remove all .NET Core SDKs or Runtimes.

* **`--all-below <VERSION>`**

  Remove .NET Core SDKs or Runtimes below the specified version. The specified version will remain.

* **`--all-but <VERSIONS>`**

  Remove .NET Core SDKs or Runtimes, except those specified.

* **`--all-but-latest`**

  Remove .NET Core SDKs or Runtimes, except the one highest version.

* **`--all-lower-patches`**

  Remove .NET Core SDKs or Runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Remove .NET Core SDKs or Runtimes marked as previews.

* **`--all-previews-but-latest`**

  Remove .NET Core SDKs or Runtimes marked as previews except the one highest preview.

* **`--aspnet-runtime`**

  Remove ASP.NET Core Runtimes only.

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

* **`--force`**
  Force removal of versions that might be used by Visual Studio.

Notes:

1. Exactly one of `--sdk`, `--runtime`, `--aspnet-runtime` and `--hosting-bundle` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor` and `[<VERSION>...]` are exclusive.
3. If neither of `--x64` or `--x86` is specified, then both x64 and x86 will be removed.

### [macOS](#tab/macos)

* **`--all`**

  Remove all .NET Core SDKs or Runtimes.

* **`--all-below <VERSION>`**

  Remove .NET Core SDKs or Runtimes below the specified version. The specified version will remain.

* **`--all-but <VERSIONS>`**

  Remove .NET Core SDKs or Runtimes, except those specified.

* **`--all-but-latest`**

  Remove .NET Core SDKs or Runtimes, except the one highest version.

* **`--all-lower-patches`**

  Remove .NET Core SDKs or Runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Remove .NET Core SDKs or Runtimes marked as previews.

* **`--all-previews-but-latest`**

  Remove .NET Core SDKs or Runtimes marked as previews except the one highest preview.

* **`--major-minor <MAJOR_MINOR>`**

  Remove .NET Core SDKs or Runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Remove .NET Core Runtimes only.

* **`--sdk`**

  Remove .NET Core SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Set the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

* **`-y, --yes`**
  Execute the command without requiring Y/n confirmation.
  
* **`--force`**
  Force removal of versions that might be used by Visual Studio or SDKs.

Notes:

1. Exactly one of `--sdk` and `--runtime` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor` and `[<VERSION>...]` are exclusive.

---

#### Examples

* Dry run of removing all .NET Core Runtimes that have been superseded by higher patches.

  ``` console
  dotnet-core-uninstall dry-run --all-lower-patches --runtime
  ```

* Dry run of removing all .NET Core SDKs below the version `2.2.301`:

  ``` console
  dotnet-core-uninstall whatif --all-below 2.2.301 --sdk
  ```

* Remove all x86 .NET Core Runtimes except the version `3.0.0-preview6-27804-01` without requiring Y/n confirmation:

  ``` console
  dotnet-core-uninstall remove --all-but 3.0.0-preview6-27804-01 --runtime --yes
  ```

* Remove all .NET Core 1.1 SDKs without requiring Y/n confirmation:

  ``` console
  dotnet-core-uninstall remove --major-minor 1.1 -y
  ```

* Remove all .NET Core SDKs that can be removed by this tool:

  ``` console
  dotnet-core-uninstall remove --all --sdk
  ```

* Remove all .NET Core SDKs specified in the response file `versions.rsp`

  ``` console
  dotnet-core-uninstall remove --sdk @versions.rsp
  ```

  The content of *versions.rsp* is as follows:
  
  ```text
  2.2.300
  2.1.700
  ```

### Optional: deleting `NuGetFallbackFolder`

In some cases, you no longer need the `NuGetFallbackFolder` and may wish to delete it. See this article on [Removing the NuGet Fallback Folder](../versions/remove-runtime-sdk-versions.md#removing-the-nuget-fallback-folder).

### Deleting the `dotnet-core-uninstall` tool

Delete the downloaded single executable *dotnet-core-uninstall.exe* from the directory where it was installed.

---
title: .NET Core Uninstall Tool
description: An overview of the .NET Core Uninstall Tool, a guided tool that enables the controlled clean-up of .NET Core SDKs and runtimes.
author: yuchong-pan
ms.date: 10/31/2019
---
# .NET Core Uninstall Tool

The [.NET Core Uninstall Tool](https://github.com/dotnet/cli-lab/releases) (`dotnet-core-uninstall`) lets you clean up .NET Core SDKs and runtimes on a system such that only the desired versions remain. A collection of options is available to specify which versions you want to uninstall.

The tool supports Windows and macOS. Linux is currently not supported.

Note that the Windows version of this tool can only uninstall .NET Core SDKs and runtimes that were installed using .NET Core SDK and runtime installers. Prior to Visual Studio 2019 Update 16.3, the Visual Studio installer called the .NET Core SDK installer and these versions can be uninstalled with the tool. The `dotnet-core-uninstall list` command displays which SDKs can be uninstalled with the tool.

## Install the tool

You can download the .NET Core Uninstall Tool from [GitHub Releases](https://github.com/dotnet/cli-lab/releases).

> [!NOTE]
> The tool requires elevation to uninstall .NET Core SDKs and runtimes. Therefore, it should be installed in a write-protected directory such as *C:\Program Files* on Windows or */usr/local/bin* on macOS. See also [Elevated access for dotnet commands](../tools/elevated-access.md). Detailed installation instructions are available on the [GitHub Releases page](https://github.com/dotnet/cli-lab/releases).

## How to use the tool

1. Display installed .NET Core SDKs and runtimes that can be removed by this tool using `dotnet-core-uninstall list`.
2. Use `dotnet-core-uninstall dry-run` to ensure the right SDKs and runtimes will be uninstalled.
3. Use `dotnet-core-uninstall remove` to uninstall .NET Core SDKs and runtimes. This command must be run with Admin privileges.
4. Delete the `NuGetFallbackFolder` if you no longer need it (optional).

### Display installed .NET Core SDKs and runtimes

Use the `dotnet-core-uninstall list` command lists installed .NET Core SDKs and runtimes that can be removed with this tool. Some SDKs and runtimes may be required by Visual Studio and they're displayed with a note of why it isn't recommended to uninstall them.

On Windows, the tool can only uninstall SDKs and runtimes that were installed using the .NET Core SDK and runtime installer, or the Visual Studio installer prior to Visual Studio 2019 16.3. On macOS, the tool can only uninstall SDKs and runtimes located in the */usr/local/share/dotnet* folder. This tool doesn't work on Linux. Because of these limitations, the tool may not be able to uninstall all of the .NET Core SDKs and runtimes on your machine. You can use the `dotnet --info` command to find all of the .NET Core SDKs and runtimes available, including those SDKs and runtimes that this tool can't remove.

#### Synopsis

```console
dotnet-core-uninstall list [options]
```

#### Options

## [Windows](#tab/windows)

* **`--aspnet-runtime`**

  Lists all the ASP.NET Core runtimes that are installed on your machine.

* **`--hosting-bundle`**

  Lists all the .NET Core runtime and hosting bundles that are installed on your machine.

* **`--runtime`**

  Lists all .NET Core runtimes that are installed on your machine.

* **`--sdk`**

  Lists all .NET Core SDKs that are installed on your machine.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.

* **`--x64`**

  Lists all x64 .NET Core SDKs and runtimes that are installed on your machine.

* **`--x86`**

  Lists all x86 .NET Core SDKs and runtimes that are installed on your machine.

## [macOS](#tab/macos)

* **`--runtime`**

  Lists all .NET Core runtimes that are installed on your machine.

* **`--sdk`**

  Lists all .NET Core SDKs that are installed on your machine.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.
  
---

#### Examples

* List all .NET Core SDKs and runtimes that can be removed with this tool:

  ```console
  dotnet-core-uninstall list
  ```

* List all x64 .NET Core SDKs and runtimes:

  ```console
  dotnet-core-uninstall list --x64
  ```

* List all x86 .NET Core SDKs:

  ```console
  dotnet-core-uninstall list --sdk --x86
  ```

## Uninstall .NET Core SDKs and runtimes

The `dotnet-core-uninstall dry-run` and `dotnet-core-uninstall whatif` commands display the .NET Core SDKs and runtimes that will be removed based on the options provided without performing the uninstall. These commands are synonyms.

Since this tool has a destructive behavior, it's **highly** recommended that you do a dry run before running the remove command. The dry run will show you what .NET Core SDKs and runtimes will be removed when you use the `remove` command. Refer to [Should I remove a version?](../versions/remove-runtime-sdk-versions.md#should-i-remove-a-version) to learn which SDKs and runtimes are safe to remove.

`dotnet-core-uninstall remove` uninstalls .NET Core SDKs and runtimes that are specified by a collection of options. The tool can't be used to uninstall SDKs and runtimes with version 5.0 or above.

> [!CAUTION]
> Keep in mind the following caveats:
>
>- This tool can uninstall versions of the .NET Core SDK that are required by `global.json` files on your machine. You can reinstall .NET Core SDKs from the [Download .NET Core](https://dotnet.microsoft.com/download/dotnet-core) page.
>- This tool can uninstall versions of the .NET Core runtime that are required by framework dependent applications on your machine. You can reinstall .NET Core runtimes from the [Download .NET Core](https://dotnet.microsoft.com/download/dotnet-core) page.
>- This tool can uninstall versions of the .NET Core SDK and runtime that Visual Studio relies on. If you break your Visual Studio installation, run "Repair" in the Visual Studio installer to get back to a working state.

By default, all commands keep the .NET Core SDKs and runtimes that may be required by Visual Studio or other SDKs. These SDKs and runtimes can be uninstalled by listing them explicitly as arguments or by using the `--force` option.

The tool requires elevation to uninstall .NET Core SDKs and runtimes. Run the tool in an Administrator command prompt on Windows and with `sudo` on macOS. The `dry-run` and `whatif` commands don't require elevation.

`dotnet-core-uninstall dry-run`, `dotnet-core-uninstall whatif`, and `dotnet-core-uninstall remove` have the same options and arguments.

#### Synopsis

```console
dotnet-core-uninstall dry-run [options] [<VERSION>...]

dotnet-core-uninstall whatif [options] [<VERSION>...]

dotnet-core-uninstall remove [options] [<VERSION>...]
```

#### Arguments

`VERSION`

The specified version to uninstall. You may list several versions one after the other, separated by spaces. Response files are also supported.

  > [!TIP]
  > Response files are an alternative to placing all the versions on the command line.
  > They're text files, typically with a \*.rsp extension, and
  > each version is listed on a separate line.
  > To specify a response file for the `VERSION` argument, use the \@ character immediately followed by the response file name.

#### Options

## [Windows](#tab/windows)

* **`--all`**

  Removes all .NET Core SDKs and runtimes.

* **`--all-below <VERSION>`**

  Removes only the .NET Core SDKs and runtimes with a version smaller than the specified version. The specified version remains installed.

* **`--all-but <VERSIONS>`**

  Removes all .NET Core SDKs and runtimes, except those versions specified.

* **`--all-but-latest`**

  Removes .NET Core SDKs and runtimes, except the one highest version.

* **`--all-lower-patches`**

  Removes .NET Core SDKs and runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Removes .NET Core SDKs and runtimes marked as previews.

* **`--all-previews-but-latest`**

  Removes .NET Core SDKs and runtimes marked as previews except the one highest preview.

* **`--aspnet-runtime`**

  Removes ASP.NET Core runtimes only.

* **`--hosting-bundle`**

  Removes .NET Core runtime and hosting bundles only.

* **`--major-minor <MAJOR_MINOR>`**

  Removes .NET Core SDKs and runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Removes .NET Core runtimes only.

* **`--sdk`**

  Removes .NET Core SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.

* **`--x64`**

  Must be used with `--sdk`, `--runtime`, and `--aspnet-runtime` to remove x64 SDKs or runtimes.

* **`--x86`**

  Must be used with `--sdk`, `--runtime`, and `--aspnet-runtime` to remove x86 SDKs or runtimes.

* **`-y, --yes`**
  Executes the command without requiring a yes or no confirmation. Only available for the `dotnet-core-uninstall remove` command.

* **`--force`**
  Forces removal of versions that might be used by Visual Studio.

Notes:

1. Exactly one of `--sdk`, `--runtime`, `--aspnet-runtime`, and `--hosting-bundle` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor`, and `[<VERSION>...]` are exclusive.
3. If `--x64` or `--x86` aren't specified, then both x64 and x86 will be removed.

## [macOS](#tab/macos)

* **`--all`**

  Removes all .NET Core SDKs and runtimes.

* **`--all-below <VERSION>`**

  Removes .NET Core SDKs and runtimes below the specified version. The specified version will remain.

* **`--all-but <VERSIONS>`**

  Removes .NET Core SDKs and runtimes, except those versions specified.

* **`--all-but-latest`**

  Removes .NET Core SDKs and runtimes, except the one highest version.

* **`--all-lower-patches`**

  Removes .NET Core SDKs and runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Removes .NET Core SDKs and runtimes marked as previews.

* **`--all-previews-but-latest`**

  Removes .NET Core SDKs and runtimes marked as previews except the one highest preview.

* **`--major-minor <MAJOR_MINOR>`**

  Removes .NET Core SDKs and runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Removes .NET Core runtimes only.

* **`--sdk`**

  Removes .NET Core SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.

* **`-y, --yes`**
  Executes the command without requiring Y/n confirmation. Only available to for the `dotnet-core-uninstall remove` command.
  
* **`--force`**
  Forces removal of versions that might be used by Visual Studio or SDKs.

Notes:

1. Exactly one of `--sdk` and `--runtime` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor`, and `[<VERSION>...]` are exclusive.

---

#### Examples

> [!NOTE]
> By default, .NET Core SDKs and runtimes that may be required by Visual Studio or other SDKs are kept. In the following examples, some of the specified SDKs and runtimes may remain, depending on the state of the machine. To remove all SDKs and runtimes, list them explicitly as arguments or use the `--force` option.

* Dry run of removing all .NET Core runtimes that have been superseded by higher patches.

  ```console
  dotnet-core-uninstall dry-run --all-lower-patches --runtime
  ```

* Dry run of removing all .NET Core SDKs below the version `2.2.301`:

  ```console
  dotnet-core-uninstall whatif --all-below 2.2.301 --sdk
  ```

* Remove all x86 .NET Core runtimes except the version `3.0.0-preview6-27804-01` without requiring Y/n confirmation:

  ```console
  dotnet-core-uninstall remove --all-but 3.0.0-preview6-27804-01 --runtime --yes
  ```

* Remove all .NET Core 1.1 SDKs without requiring Y/n confirmation:

  ```console
  dotnet-core-uninstall remove --major-minor 1.1 -y
  ```

* Remove all .NET Core SDKs that can safely be removed by this tool:

  ```console
  dotnet-core-uninstall remove --all --sdk
  ```

* Remove all .NET Core SDKs that can be removed by this tool, including those SDKs that may be required by Visual Studio (not recommended):

  ```console
  dotnet-core-uninstall remove --all --sdk --force
  ```

* Remove all .NET Core SDKs that are specified in the response file `versions.rsp`

  ```console
  dotnet-core-uninstall remove --sdk @versions.rsp
  ```

  The content of *versions.rsp* is as follows:
  
  ```text
  2.2.300
  2.1.700
  ```

### Delete NuGetFallbackFolder (optional)

In some cases, you no longer need the `NuGetFallbackFolder` and may wish to delete it. For more information about deleting this folder, see [Remove the NuGetFallbackFolder](../versions/remove-runtime-sdk-versions.md#remove-the-nugetfallbackfolder).

## Uninstall the tool

## [Windows](#tab/windows)

1. Open **Add or Remove Programs**.
2. Search for `Microsoft .NET Core SDK Uninstall Tool`.
3. Select **Uninstall**.

## [macOS](#tab/macos)

Delete the downloaded *dotnet-core-uninstall.tar.gz* file from the directory where it was installed. If you unzipped the contents of this file into another directory, be sure to delete the content as well.

---

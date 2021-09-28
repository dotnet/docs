---
title: Uninstall Tool
description: An overview of the .NET Uninstall Tool, a guided tool that enables the controlled clean-up of .NET SDKs and runtimes.
author: sfoslund
ms.date: 01/28/2021
---
# .NET Uninstall Tool

The [.NET Uninstall Tool](https://aka.ms/dotnet-core-uninstall-tool) (`dotnet-core-uninstall`) lets you remove .NET SDKs and Runtimes from a system. A collection of options is available to specify which versions you want to uninstall.

The tool supports Windows and macOS. Linux is currently not supported.

On Windows, the tool can only uninstall SDKs and Runtimes that were installed using one of the following installers:

- The .NET SDK and runtime installer.
- The Visual Studio installer in versions earlier than Visual Studio 2019 version 16.3.

On macOS, the tool can only uninstall SDKs and runtimes located in the */usr/local/share/dotnet* folder.

Because of these limitations, the tool may not be able to uninstall all of the .NET SDKs and runtimes on your machine. You can use the `dotnet --info` command to find all of the .NET SDKs and runtimes installed, including those SDKs and runtimes that this tool can't remove. The `dotnet-core-uninstall list` command displays which SDKs can be uninstalled with the tool. Versions 1.2 and later can uninstall SDKs and runtimes with version 5.0 or earlier, and previous versions of the tool can uninstall 3.1 and earlier.

## Install the tool

You can download the .NET Uninstall Tool from [the tool's releases page](https://aka.ms/dotnet-core-uninstall-tool) and find the source code at the [dotnet/cli-lab](https://github.com/dotnet/cli-lab) GitHub repository.

> [!NOTE]
> The tool requires elevation to uninstall .NET SDKs and runtimes. Therefore, it should be installed in a write-protected directory such as *C:\Program Files* on Windows or */usr/local/bin* on macOS. See also [Elevated access for dotnet commands](../tools/elevated-access.md). For more information, see the [detailed installation instructions](https://aka.ms/dotnet-core-uninstall-tool).

## Run the tool

The following steps show the recommended approach for running the uninstall tool:

- [Step 1 - Display installed .NET SDKs and runtimes](#step-1---display-installed-net-sdks-and-runtimes)
- [Step 2 - Do a dry run](#step-2---do-a-dry-run)
- [Step 3 - Uninstall .NET SDKs and Runtimes](#step-3---uninstall-net-sdks-and-runtimes)
- [Step 4 - Delete the NuGet fallback folder (optional)](#step-4---delete-the-nuget-fallback-folder-optional)

### Step 1 - Display installed .NET SDKs and runtimes

The `dotnet-core-uninstall list` command lists the installed .NET SDKs and runtimes that can be removed with this tool. Some SDKs and runtimes may be required by Visual Studio and they're displayed with a note of why it isn't recommended to uninstall them.

> [!NOTE]
> The output of the `dotnet-core-uninstall list` command will not match the list of installed versions in the output of `dotnet --info` in most cases. Specifically, this tool will not display versions installed by zip files or managed by Visual Studio (any version installed with Visual Studio 2019 16.3 or later). One way to check if a version is managed by Visual Studio is to view it in `Add or Remove Programs`, where Visual Studio managed versions are marked as such in their display names.

**dotnet-core-uninstall list**

#### Synopsis

```console
dotnet-core-uninstall list [options]
```

#### Options

## [Windows](#tab/windows)

* **`--aspnet-runtime`**

  Lists all the ASP.NET Runtimes that can be uninstalled with this tool.

* **`--hosting-bundle`**

  Lists all the .NET hosting bundles that can be uninstalled with this tool.

* **`--runtime`**

  Lists all .NET Runtimes that can be uninstalled with this tool.

* **`--sdk`**

  Lists all .NET SDKs that can be uninstalled with this tool.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.

* **`--x64`**

  Lists all x64 .NET SDKs and runtimes that can be uninstalled with this tool.

* **`--x86`**

  Lists all x86 .NET SDKs and runtimes that can be uninstalled with this tool.

## [macOS](#tab/macos)

* **`--runtime`**

  Lists all .NET Runtimes that can be uninstalled with this tool.

* **`--sdk`**

  Lists all .NET SDKs that can be uninstalled with this tool.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.
  
---

#### Examples

* List all .NET SDKs and runtimes that can be removed with this tool:

  ```console
  dotnet-core-uninstall list
  ```

* List all x64 .NET SDKs and runtimes:

  ```console
  dotnet-core-uninstall list --x64
  ```

* List all x86 .NET SDKs:

  ```console
  dotnet-core-uninstall list --sdk --x86
  ```

### Step 2 - Do a dry run

The `dotnet-core-uninstall dry-run` and `dotnet-core-uninstall whatif` commands display the .NET SDKs and runtimes that will be removed based on the options provided without performing the uninstall. These commands are synonyms.

**dotnet-core-uninstall dry-run and dotnet-core-uninstall whatif**

#### Synopsis

```console
dotnet-core-uninstall dry-run [options] [<VERSION>...]

dotnet-core-uninstall whatif [options] [<VERSION>...]
```

#### Arguments

* **`VERSION`**

  The specified version to uninstall. You may list several versions one after the other, separated by spaces. Response files are also supported.

  > [!TIP]
  > Response files are an alternative to placing all the versions on the command line.
  > They're text files, typically with a \*.rsp extension, and
  > each version is listed on a separate line.
  > To specify a response file for the `VERSION` argument, use the \@ character immediately followed by the response file name.

#### Options

## [Windows](#tab/windows)

* **`--all`**

  Removes all .NET SDKs and runtimes.

* **`--all-below <VERSION>[ <VERSION>...]`**

  Removes only the .NET SDKs and runtimes with a version smaller than the specified version. The specified version remains installed.

* **`--all-but <VERSIONS>[ <VERSION>...]`**

  Removes all .NET SDKs and runtimes, except those versions specified.

* **`--all-but-latest`**

  Removes .NET SDKs and runtimes, except the one highest version.

* **`--all-lower-patches`**

  Removes .NET SDKs and runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Removes .NET SDKs and runtimes marked as previews.

* **`--all-previews-but-latest`**

  Removes .NET SDKs and runtimes marked as previews except the one highest preview.

* **`--aspnet-runtime`**

  Removes ASP.NET Runtimes only.

* **`--hosting-bundle`**

  Removes .NET Runtime and hosting bundles only.

* **`--major-minor <MAJOR_MINOR>`**

  Removes .NET SDKs and runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Removes .NET Runtimes only.

* **`--sdk`**

  Removes .NET SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.

* **`--x64`**

  Must be used with `--sdk`, `--runtime`, and `--aspnet-runtime` to remove x64 SDKs or runtimes.

* **`--x86`**

  Must be used with `--sdk`, `--runtime`, and `--aspnet-runtime` to remove x86 SDKs or runtimes.

* **`--force`**
  Forces removal of versions that might be used by Visual Studio.

Notes:

1. Exactly one of `--sdk`, `--runtime`, `--aspnet-runtime`, and `--hosting-bundle` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor`, and `[<VERSION>...]` are exclusive.
3. If `--x64` or `--x86` aren't specified, then both x64 and x86 will be removed.

## [macOS](#tab/macos)

* **`--all`**

  Removes all .NET SDKs and runtimes.

* **`--all-below <VERSION>[ <VERSION>...]`**

  Removes .NET SDKs and runtimes below the specified version. The specified version will remain.

* **`--all-but <VERSIONS>[ <VERSION>...]`**

  Removes .NET SDKs and runtimes, except those versions specified.

* **`--all-but-latest`**

  Removes .NET SDKs and runtimes, except the one highest version.

* **`--all-lower-patches`**

  Removes .NET SDKs and runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Removes .NET SDKs and runtimes marked as previews.

* **`--all-previews-but-latest`**

  Removes .NET SDKs and runtimes marked as previews except the one highest preview.

* **`--major-minor <MAJOR_MINOR>`**

  Removes .NET SDKs and runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Removes .NET Runtimes only.

* **`--sdk`**

  Removes .NET SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.
  
* **`--force`**
  Forces removal of versions that might be used by Visual Studio or SDKs.

Notes:

1. Exactly one of `--sdk` and `--runtime` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor`, and `[<VERSION>...]` are exclusive.

---

#### Examples

> [!NOTE]
> By default, .NET SDKs and runtimes that may be required by Visual Studio or other SDKs are not included in `dotnet-core-uninstall dry-run` output. In the following examples, some of the specified SDKs and runtimes may not be included in the output, depending on the state of the machine. To include all SDKs and runtimes, list them explicitly as arguments or use the `--force` option.

* Dry run of removing all .NET Runtimes that have been superseded by higher patches:

  ```console
  dotnet-core-uninstall dry-run --all-lower-patches --runtime
  ```

* Dry run of removing all .NET SDKs below the version `2.2.301`:

  ```console
  dotnet-core-uninstall whatif --all-below 2.2.301 --sdk
  ```

### Step 3 - Uninstall .NET SDKs and Runtimes

`dotnet-core-uninstall remove` uninstalls .NET SDKs and Runtimes that are specified by a collection of options. Versions 1.2 and later can uninstall SDKs and runtimes with version 5.0 or earlier, and previous versions of the tool can uninstall 3.1 and earlier.

Since this tool has a destructive behavior, it's **highly** recommended that you do a dry run before running the remove command. The dry run will show you what .NET SDKs and runtimes will be removed when you use the `remove` command. Refer to [Should I remove a version?](../install/remove-runtime-sdk-versions.md#should-i-remove-a-version) to learn which SDKs and runtimes are safe to remove.

> [!CAUTION]
> Keep in mind the following caveats:
>
>- This tool can uninstall versions of the .NET SDK that are required by `global.json` files on your machine. You can reinstall .NET SDKs from the [Download .NET](https://dotnet.microsoft.com/download/dotnet) page.
>- This tool can uninstall versions of the .NET Runtime that are required by framework dependent applications on your machine. You can reinstall .NET Runtimes from the [Download .NET](https://dotnet.microsoft.com/download/dotnet) page.
>- This tool can uninstall versions of the .NET SDK and runtime that Visual Studio relies on. If you break your Visual Studio installation, run "Repair" in the Visual Studio installer to get back to a working state.

By default, all commands keep the .NET SDKs and runtimes that may be required by Visual Studio or other SDKs. These SDKs and runtimes can be uninstalled by listing them explicitly as arguments or by using the `--force` option.

The tool requires elevation to uninstall .NET SDKs and runtimes. Run the tool in an Administrator command prompt on Windows and with `sudo` on macOS. The `dry-run` and `whatif` commands don't require elevation.

**dotnet-core-uninstall remove**

#### Synopsis

```console
dotnet-core-uninstall remove [options] [<VERSION>...]
```

#### Arguments

* **`VERSION`**

  The specified version to uninstall. You may list several versions one after the other, separated by spaces. Response files are also supported.

  > [!TIP]
  > Response files are an alternative to placing all the versions on the command line.
  > They're text files, typically with a \*.rsp extension, and
  > each version is listed on a separate line.
  > To specify a response file for the `VERSION` argument, use the \@ character immediately followed by the response file name.

#### Options

## [Windows](#tab/windows)

* **`--all`**

  Removes all .NET SDKs and runtimes.

* **`--all-below <VERSION>[ <VERSION>...]`**

  Removes only the .NET SDKs and runtimes with a version smaller than the specified version. The specified version remains installed.

* **`--all-but <VERSIONS>[ <VERSION>...]`**

  Removes all .NET SDKs and runtimes, except those versions specified.

* **`--all-but-latest`**

  Removes .NET SDKs and runtimes, except the one highest version.

* **`--all-lower-patches`**

  Removes .NET SDKs and runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Removes .NET SDKs and runtimes marked as previews.

* **`--all-previews-but-latest`**

  Removes .NET SDKs and runtimes marked as previews except the one highest preview.

* **`--aspnet-runtime`**

  Removes ASP.NET Runtimes only.

* **`--hosting-bundle`**

  Removes .NET hosting bundles only.

* **`--major-minor <MAJOR_MINOR>`**

  Removes .NET SDKs and runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Removes .NET Runtimes only.

* **`--sdk`**

  Removes .NET SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.

* **`--x64`**

  Must be used with `--sdk`, `--runtime`, and `--aspnet-runtime` to remove x64 SDKs or runtimes.

* **`--x86`**

  Must be used with `--sdk`, `--runtime`, and `--aspnet-runtime` to remove x86 SDKs or runtimes.

* **`-y, --yes`**
  Executes the command without requiring a yes or no confirmation.

* **`--force`**
  Forces removal of versions that might be used by Visual Studio.

Notes:

1. Exactly one of `--sdk`, `--runtime`, `--aspnet-runtime`, and `--hosting-bundle` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor`, and `[<VERSION>...]` are exclusive.
3. If `--x64` or `--x86` aren't specified, then both x64 and x86 will be removed.

## [macOS](#tab/macos)

* **`--all`**

  Removes all .NET SDKs and runtimes.

* **`--all-below <VERSION>[ <VERSION>...]`**

  Removes .NET SDKs and runtimes below the specified version. The specified version will remain.

* **`--all-but <VERSIONS>[ <VERSION>...]`**

  Removes .NET SDKs and runtimes, except those versions specified.

* **`--all-but-latest`**

  Removes .NET SDKs and runtimes, except the one highest version.

* **`--all-lower-patches`**

  Removes .NET SDKs and runtimes superseded by higher patches. This option protects global.json.

* **`--all-previews`**

  Removes .NET SDKs and runtimes marked as previews.

* **`--all-previews-but-latest`**

  Removes .NET SDKs and runtimes marked as previews except the one highest preview.

* **`--major-minor <MAJOR_MINOR>`**

  Removes .NET SDKs and runtimes that match the specified `major.minor` version.

* **`--runtime`**

  Removes .NET Runtimes only.

* **`--sdk`**

  Removes .NET SDKs only.

* **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default value is `normal`.

* **`-y, --yes`**
  Executes the command without requiring Y/N confirmation.
  
* **`--force`**
  Forces removal of versions that might be used by Visual Studio or SDKs.

Notes:

1. Exactly one of `--sdk` and `--runtime` is required.
2. `--all`, `--all-below`, `--all-but`, `--all-but-latest`, `--all-lower-patches`, `--all-previews`, `--all-previews-but-latest`, `--major-minor`, and `[<VERSION>...]` are exclusive.

---

#### Examples

> [!NOTE]
> By default, .NET SDKs and runtimes that may be required by Visual Studio or other SDKs are kept. In the following examples, some of the specified SDKs and runtimes may remain, depending on the state of the machine. To remove all SDKs and runtimes, list them explicitly as arguments or use the `--force` option.

* Remove all .NET Runtimes except the version `3.0.0-preview6-27804-01` without requiring Y/N confirmation:

  ```console
  dotnet-core-uninstall remove --all-but 3.0.0-preview6-27804-01 --runtime --yes
  ```

* Remove all .NET Core 1.1 SDKs without requiring Y/n confirmation:

  ```console
  dotnet-core-uninstall remove --sdk --major-minor 1.1 -y
  ```

* Remove the .NET Core 1.1.11 SDK with no console output:

  ```console
  dotnet-core-uninstall remove 1.1.11 --sdk --yes --verbosity q
  ```

* Remove all .NET SDKs that can safely be removed by this tool:

  ```console
  dotnet-core-uninstall remove --all --sdk
  ```

* Remove all .NET SDKs that can be removed by this tool, including those SDKs that may be required by Visual Studio (not recommended):

  ```console
  dotnet-core-uninstall remove --all --sdk --force
  ```

* Remove all .NET SDKs that are specified in the response file `versions.rsp`

  ```console
  dotnet-core-uninstall remove --sdk @versions.rsp
  ```

  The content of *versions.rsp* is as follows:
  
  ```text
  2.2.300
  2.1.700
  ```

### Step 4 - Delete the NuGet fallback folder (optional)

In some cases, you no longer need the `NuGetFallbackFolder` and may wish to delete it. For more information about deleting this folder, see [Remove the NuGetFallbackFolder](../install/remove-runtime-sdk-versions.md#remove-the-nuget-fallback-folder).

## Uninstall the tool

## [Windows](#tab/windows)

1. Open **Add or Remove Programs**.
2. Search for `Microsoft .NET SDK Uninstall Tool`.
3. Select **Uninstall**.

## [macOS](#tab/macos)

Delete the downloaded *dotnet-core-uninstall.tar.gz* file from the directory where it was installed. If you unzipped the contents of this file into another directory, be sure to delete that content as well.

---

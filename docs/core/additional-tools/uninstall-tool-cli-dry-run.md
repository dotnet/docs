---
title: dotnet-core-uninstall dry-run command
description: The dotnet-core-uninstall dry-run command simulates uninstalling the target .NET SDK or runtime. Status is reported for potential removal.
author: adegeo
ms.date: 08/04/2024
zone_pivot_groups: operating-systems-set-three
---

# dotnet-core-uninstall dry-run

**This article applies to:** ✔️ .NET Uninstall Tool 1.7.521001 and later versions

## Name

`dotnet-core-uninstall dry-run` - Display .NET SDKs and Runtimes that will be removed.

> [!TIP]
> The `dotnet-core-uninstall whatif` command is the same command as `dry-run`.

## Synopsis

::: zone pivot="os-windows"

```dotnetcli
dotnet-core-uninstall dry-run <TARGET> [--x64|--x86] <VERSION>...
    [-v|--verbosity <LEVEL>] [--force]

dotnet-core-uninstall dry-run <TARGET> [--x64|--x86] <FILTER>
    [-v|--verbosity <LEVEL>]

dotnet-core-uninstall dry-run -h|--help|-?
```

::: zone-end

::: zone pivot="os-macos"

```dotnetcli
dotnet-core-uninstall dry-run <TARGET> <VERSION>...
    [-v|--verbosity <LEVEL>] [--force] [-y|--yes]

dotnet-core-uninstall dry-run <TARGET> <FILTER>
    [-v|--verbosity <LEVEL>] [--force] [-y|--yes]

dotnet-core-uninstall dry-run -h|--help|-?
```

::: zone-end

## Description

The `dotnet-core-uninstall list` command simulates .NET SDK and runtime removal. A status output is provided for each .NET SDK and runtime that would have been removed by the tool.

### Arguments

**`TARGET`**

  The type you want to uninstall. Valid options are listed in the [Options - TARGET](#options---target) section.

**`VERSION`**

  The version to uninstall. You can list several versions separated by a space. Response files are also supported.

  > [!TIP]
  > Response files are an alternative to placing all the versions on the command line. They're text files, typically with a *\*.rsp* extension, and each version is listed on a separate line. To specify a response file for the `VERSION` argument, use the \@ character immediately followed by the response file name.

**`FILTER`**

  Specifies a value used to filter the `TARGET`. Valid options are listed in the [Options - FILTER](#options---filter) section.

## Options - TARGET

::: zone pivot="os-windows"

- **`--aspnet-runtime`**
  
  Discovers all the ASP.NET Core runtimes that can be uninstalled with this tool.

- **`--hosting-bundle`**
  
  Lists all the .NET hosting bundles that can be uninstalled with this tool.

::: zone-end

- **`--runtime`**

  Lists all the .NET runtimes that can be uninstalled with this tool.

- **`--sdk`**

  Lists all the .NET SDKs that can be uninstalled with this tool.

::: zone pivot="os-windows"

- **`--x64`**

  Lists all the x64 .NET SDKs and runtimes that can be uninstalled with this tool.

  > [!NOTE]
  > If `--x64` or `--x86` isn't specified, then both x64 and x86 will be removed.

- **`--x86`**

  Lists all the x86 .NET SDKs and runtimes that can be uninstalled with this tool.

  > [!NOTE]
  > If `--x64` or `--x86` isn't specified, then both x64 and x86 will be removed.

::: zone-end

## Options - FILTER

These options are exclusive.

- **`--all`**

  Removes all the .NET SDKs and runtimes.

- **`--all-below <VERSION>[ <VERSION>...]`**

  Removes only the .NET SDKs and runtimes with a version smaller than the specified version. The specified version remains installed.

- **`--all-but <VERSION>[ <VERSION>...]`**

  Removes all the .NET SDKs and runtimes, except those versions specified.

- **`--all-but-latest`**

  Removes the .NET SDKs and runtimes, except the highest version.

- **`--all-lower-patches`**

  Removes the .NET SDKs and runtimes superseded by higher patches. This option protects _global.json_ file.

- **`--all-previews`**

  Removes the .NET SDKs and runtimes marked as previews.

- **`--all-previews-but-latest`**

  Removes the .NET SDKs and runtimes marked as previews except the highest preview.

- **`--major-minor <MAJOR_MINOR>`**

  Removes the .NET SDKs and runtimes that match the specified `major.minor` version.

## Options

- **`--force`**

  Forces removal of versions that might be used by Visual Studio.

- **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. The default value is `normal`. Allowed values are:

  - `q[uiet]`
  - `m[inimal]`
  - `n[ormal]`
  - `d[etailed]`
  - `diag[nostic]`.

- **`-?|-h|--help`**

  Shows help and usage information

> [!NOTE]
> By default, .NET SDKs and runtimes that might be required by Visual Studio or other SDKs aren't included in the `dotnet-core-uninstall dry-run` output. Also, depending on the state of the machine, some of the specified SDKs and runtimes might not be included in the output. To include all the SDKs and runtimes, list them explicitly as arguments or use the `--force` option.

- Dry run of removing all the .NET runtimes that have been superseded by higher patches:

  ```console
  dotnet-core-uninstall dry-run --all-lower-patches --runtime
  ```

- Dry run of removing all the .NET SDKs below the version `6.0.301`:

  ```console
  dotnet-core-uninstall whatif --all-below 6.0.301 --sdk
  ```

  > [!TIP]
  > The `dotnet-core-uninstall whatif` command is the same command as `dry-run`.

## See also

- [.NET uninstall tool overview](uninstall-tool-overview.md)
- [dotnet-core-uninstall list](uninstall-tool-cli-list.md)
- [dotnet-core-uninstall remove](uninstall-tool-cli-remove.md)

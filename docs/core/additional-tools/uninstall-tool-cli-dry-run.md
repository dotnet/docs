---
title: dotnet-core-uninstall dry-run command
description: The dotnet-core-uninstall dry-run command simulates uninstalling the target .NET SDK or runtime. Status is reported for potential removal.
author: adegeo
ms.date: 05/27/2026
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
dotnet-core-uninstall dry-run <TARGET> <FILTER> [-v|--verbosity <LEVEL>]
    [--force] [-y|--yes]

dotnet-core-uninstall dry-run -h|--help
```

::: zone-end

::: zone pivot="os-macos"

```dotnetcli
dotnet-core-uninstall dry-run <TARGET> <FILTER> [-v|--verbosity <LEVEL>]
    [--force] [-y|--yes] [--preserve-vs-for-mac-sdks]

dotnet-core-uninstall dry-run -h|--help
```

::: zone-end
## Description

The `dotnet-core-uninstall dry-run` command simulates .NET SDK and runtime removal. A status output is provided for each .NET SDK and runtime that would have been removed by the tool.

### Arguments

**`VERSION`**

  The version to uninstall. You can list several versions separated by a space. Response files are also supported.

  > [!TIP]
  > Response files are an alternative to placing all the versions on the command line. They're text files, typically with a *\*.rsp* extension, and each version is listed on a separate line. To specify a response file for the `VERSION` argument, use the \@ character immediately followed by the response file name.

## Options - TARGET

::: zone pivot="os-windows"

- **`--aspnet-runtime`**

  Removes ASP.NET Core runtimes only.

- **`--hosting-bundle`**

  Removes .NET Core Runtime and Hosting Bundles only.

- **`--runtime`**

  Removes .NET Core runtimes only.

- **`--sdk`**

  Removes .NET Core SDKs only.

- **`--windows-desktop-runtime`**

  Removes Windows Desktop runtimes only.

- **`--arm64`**

  Use with `--sdk`, `--runtime`, `--aspnet-runtime`, and `--windows-desktop-runtime` to remove arm64.

- **`--x64`**

  Use with `--sdk`, `--runtime`, `--aspnet-runtime`, and `--windows-desktop-runtime` to remove x64.

- **`--x86`**

  Use with `--sdk`, `--runtime`, `--aspnet-runtime`, and `--windows-desktop-runtime` to remove x86.

::: zone-end

::: zone pivot="os-macos"

- **`--runtime`**

  Removes .NET Core runtimes only.

- **`--sdk`**

  Removes .NET Core SDKs only.

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

::: zone pivot="os-windows"

- **`--force`**

  Forces removal of versions that might be used by Visual Studio.

::: zone-end

::: zone pivot="os-macos"

- **`--force`**

  Forces removal of versions that might be used by Visual Studio for Mac or SDKs.

- **`--preserve-vs-for-mac-sdks`**

  Prevents removal of SDKs and runtimes that have a high probability of being used by Visual Studio for Mac.

  > [!NOTE]
  > Visual Studio for Mac is out of support.

::: zone-end

- **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. Allowed values are:

  - `q[uiet]`
  - `m[inimal]`
  - `n[ormal]`
  - `d[etailed]`
  - `diag[nostic]`

- **`-?|-h|--help`**

  Shows help and usage information.

::: zone pivot="os-windows"

> [!NOTE]
> By default, SDKs and runtimes that have a high probability of being used by Visual Studio aren't removed. To remove these, specify them individually or use `--force`. If removing SDKs or runtimes causes issues with your Visual Studio installation, run Repair. SDKs and runtimes are available for download at [https://aka.ms/dotnet-core-download](https://aka.ms/dotnet-core-download).

::: zone-end

::: zone pivot="os-macos"

> [!NOTE]
> Use `--preserve-vs-for-mac-sdks` to prevent removal of SDKs and runtimes that have a high probability of being used by Visual Studio for Mac. Visual Studio for Mac is out of support. SDKs and runtimes are available for download at [https://aka.ms/dotnet-core-download](https://aka.ms/dotnet-core-download).

::: zone-end

- Dry run of removing all the .NET runtimes that have been superseded by higher patches:

  ```console
  dotnet-core-uninstall dry-run --all-lower-patches --runtime
  ```

- Dry run of removing all the .NET SDKs below the version `6.0.301`:

  ```console
  dotnet-core-uninstall dry-run --all-below 6.0.301 --sdk
  ```

## See also

- [.NET uninstall tool overview](uninstall-tool-overview.md)
- [dotnet-core-uninstall list](uninstall-tool-cli-list.md)
- [dotnet-core-uninstall remove](uninstall-tool-cli-remove.md)

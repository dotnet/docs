---
title: dotnet-core-uninstall list command
description: The dotnet-core-uninstall list command lists .NET SDKs and runtimes that can be removed with the tool.
author: adegeo
ms.date: 08/04/2024
zone_pivot_groups: operating-systems-set-three
ms.topic: article
---

# dotnet-core-uninstall list

**This article applies to:** ✔️ .NET Uninstall Tool 1.7.521001 and later versions

## Name

`dotnet-core-uninstall list` - List .NET SDKs or runtimes that can be removed with this tool.

## Synopsis

::: zone pivot="os-windows"

```dotnetcli
dotnet-core-uninstall list [--aspnet-runtime] [--hosting-bundle]
    [--runtime] [--sdk] [-v|--verbosity <LEVEL>] [--x64] [--x86]

dotnet-core-uninstall list -?|-h|--help
```

::: zone-end

::: zone pivot="os-macos"

```dotnetcli
dotnet-core-uninstall list [--runtime] [--sdk] [-v|--verbosity <LEVEL>]

dotnet-core-uninstall list -?|-h|--help
```

::: zone-end

## Description

The `dotnet-core-uninstall list` command lists installed .NET SDKs or runtimes that can be removed with this tool. For more information about the limitations of this tool, see [.NET uninstall tool overview](uninstall-tool-overview.md).

## Options

::: zone pivot="os-windows"

- **`--aspnet-runtime`**
  
  Lists all the ASP.NET Core runtimes that can be uninstalled with this tool.

- **`--hosting-bundle`**
  
  Lists all the .NET hosting bundles that can be uninstalled with this tool.

::: zone-end

- **`--runtime`**

  Lists all the .NET runtimes that can be uninstalled with this tool.

- **`--sdk`**

  Lists all the .NET SDKs that can be uninstalled with this tool.

- **`-v, --verbosity <LEVEL>`**

  Sets the verbosity level. The default value is `normal`. Allowed values are:

  - `q[uiet]`
  - `m[inimal]`
  - `n[ormal]`
  - `d[etailed]`
  - `diag[nostic]`.

::: zone pivot="os-windows"

- **`--x64`**

  Lists all the x64 .NET SDKs and runtimes that can be uninstalled with this tool.

- **`--x86`**

  Lists all the x86 .NET SDKs and runtimes that can be uninstalled with this tool.

::: zone-end

- **`-?|-h|--help`**

  Shows help and usage information

## Examples

- List all the .NET SDKs and runtimes that can be removed with this tool:

  ```console
  dotnet-core-uninstall list
  ```

- List all the x64 .NET SDKs and runtimes:

  ```console
  dotnet-core-uninstall list --x64
  ```

- List all the x86 .NET SDKs:

  ```console
  dotnet-core-uninstall list --sdk --x86
  ```

## See also

- [.NET uninstall tool overview](uninstall-tool-overview.md)
- [dotnet-core-uninstall dry-run](uninstall-tool-cli-dry-run.md)
- [dotnet-core-uninstall remove](uninstall-tool-cli-remove.md)

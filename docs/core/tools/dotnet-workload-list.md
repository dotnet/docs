---
title: dotnet workload list command
description: The 'dotnet workload list' command lists installed workloads.
ms.date: 08/31/2021
---
# dotnet workload list

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet workload list` - Lists installed workloads.

### Synopsis

```dotnetcli
dotnet workload list [-v|--verbosity <LEVEL>]

dotnet workload list [-?|-h|--help]
```

## Description

The `dotnet workload list` command lists all installed workloads.

For more information about the `dotnet workload` commands, see the [dotnet workload install](dotnet-workload-install.md#description) command.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

## Examples

- List the installed workloads:

  ```dotnetcli
  dotnet workload list
  ```

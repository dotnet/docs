---
title: dotnet workload command
description: Learn about the base dotnet workload command. Workload commands manage and install optional components of .NET.
ms.date: 10/24/2022
---
# dotnet workload command

**This article applies to:** ✔️ .NET 7 SDK and later versions

## Name

`dotnet workload` - Provides information about the available workload commands and installed workloads.

## Synopsis

```dotnetcli
dotnet workload [--info]

dotnet workload -?|-h|--help
```

## Description

The `dotnet workload` command provides commands for working with .NET workloads. For example, [`dotnet workload install`](dotnet-workload-install.md) installs a particular workload. Each command defines its own options and arguments. All commands support the `--help` option for printing out brief documentation about how to use the command.

## Options

- **`--info`**

  Prints out detailed information about installed workloads, including their installation source, manifest version, manifest path, and install type.

- **`-?|-h|--help`**

  Prints out a list of available commands.

## See also

- [Install a workload](dotnet-workload-install.md)
- [List the installed workloads on your machine](dotnet-workload-list.md)
- [Show workloads available to install](dotnet-workload-search.md)

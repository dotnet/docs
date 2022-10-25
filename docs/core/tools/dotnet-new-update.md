---
title: dotnet new update
description: The dotnet new update command updates installed template packages.
ms.date: 04/29/2021
---
# dotnet new update

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet new update` - updates installed template packages.

## Synopsis

```dotnetcli
dotnet new update [--interactive] [--add-source|--nuget-source <SOURCE>] 
    [-d|--diagnostics] [--verbosity <LEVEL>] [-h|--help]

dotnet new update --check-only|--dry-run [--interactive] [--add-source|--nuget-source <SOURCE>] 
    [-d|--diagnostics] [--verbosity <LEVEL>] [-h|--help]
```

## Description

The `dotnet new update` command updates installed template packages.
The `dotnet new update` command with `--check-only` option checks for available updates for installed template packages without applying them.

> [!NOTE]
> [!INCLUDE [new syntax](../../../includes/dotnet-new-7-0-syntax.md)]
>
> Examples of the old syntax:
>
> - Show help for the `update` subcommand.
>
> - Check for updates for installed template packages:
>
>   ```dotnetcli
>   dotnet new --update-check
>   ```
>
> - Update installed template packages:
>
>   ```dotnetcli
>   dotnet new --update-apply
>   ```

## Options

[!INCLUDE [interactive](../../../includes/cli-interactive-5-0.md)]

- **`--add-source|nuget-source <SOURCE>`**
  
  By default, `dotnet new install` uses the hierarchy of NuGet configuration files from the current directory to determine the NuGet source the package can be installed from. If `--nuget-source` is specified, the source will be added to the list of sources to be checked.  
  To check the configured sources for the current directory use [`dotnet nuget list source`](dotnet-nuget-list-source.md). For more information, see [Common NuGet Configurations](/nuget/consume-packages/configuring-nuget-behavior). Available since .NET SDK 7.0.100.

- **`-d|--diagnostics`**

  Enables diagnostic output. Available since .NET SDK 7.0.100.

- **`-h|--help`**

  Prints out help for the update command. Available since .NET SDK 7.0.100.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, and `diag[nostic]`. Available since .NET SDK 7.0.100.

## Examples

- Updates the installed template packages using NuGet configuration for the current directory:

  ```dotnetcli
  dotnet new update 
  ```

- Updates the installed template packages also checking a custom NuGet source using interactive mode:

  ```dotnetcli
  dotnet new update --add-source "https://api.my-custom-nuget.com/v3/index.json" --interactive
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new search command](dotnet-new-search.md)
- [dotnet new install command](dotnet-new-install.md)
- [Custom templates for dotnet new](custom-templates.md)

---
title: dotnet new update
description: The dotnet new --update-* options check for and apply updates to installed template packages.
ms.date: 04/29/2021
---
# dotnet new update

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet new --update-check` - Checks for available updates for installed template packages.

`dotnet new --update-apply` - Applies updates to installed template packages.

## Synopsis

```dotnetcli
dotnet new --update-check

dotnet new --update-apply
```

## Description

The `dotnet new --update-check` option checks if there are updates available for the template packages that are currently installed.
The `dotnet new --update-apply` option checks if there are updates available for the template packages that are currently installed and installs them.

<!-- markdownlint-disable MD012 -->
> [!NOTE]
> [!INCLUDE [new syntax](../../../includes/dotnet-new-7-0-syntax.md)]
>
> Examples of the new syntax:
>
> - Show help for the `update` subcommand.
>
>   ```dotnetcli
>   dotnet new update --help
>   ```
>
> - Check for updates for installed template packages:
>
>   ```dotnetcli
>   dotnet new update --check
>   ```
>
> - Update installed template packages:
>
>   ```dotnetcli
>   dotnet new update
>   ```



## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new --search option](dotnet-new-search.md)
- [dotnet new --install option](dotnet-new-install.md)
- [Custom templates for dotnet new](custom-templates.md)

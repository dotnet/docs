---
title: dotnet new --update-* options
description: The dotnet new --update-* options check for and apply updates to installed template packages.
ms.date: 04/29/2021
---
# dotnet new --update-check and --update-apply options

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

## Name

`dotnet new --update-check` checks for available updates for installed template packages.

`dotnet new --update-apply` applies updates to installed template packages.

## Synopsis

```dotnetcli
dotnet new --update-check

dotnet new --update-apply
```

## Description

The `dotnet new --update-check` option checks if there are updates available for the template packages that are currently installed.
The `dotnet new --update-apply` option checks if there are updates available for the template packages that are currently installed and installs them.

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new --search option](dotnet-new-search.md)
- [dotnet new --install option](dotnet-new-install.md)
- [Custom templates for dotnet new](custom-templates.md)

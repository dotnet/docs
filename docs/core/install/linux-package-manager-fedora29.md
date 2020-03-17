---
title: Install .NET Core on Fedora 29 - package manager - .NET Core
description: Use a package manager to install .NET Core SDK and runtime on Fedora 29.
author: thraka
ms.author: adegeo
ms.date: 03/17/2020
---

# Fedora 29 Package Manager - Install .NET Core

[!INCLUDE [package-manager-switcher](./includes/package-manager-switcher.md)]

This article describes how to use a package manager to install .NET Core on Fedora 29. Install the SDK (includes the runtime) if you want to make apps with .NET Core. Or, install the runtime if you only need to run apps. If you're installing the runtime, we suggest you install the [ASP.NET Core runtime](#install-the-aspnet-core-runtime), as it includes both .NET Core and ASP.NET Core runtimes.

If you've already installed the SDK or runtime, use the `dotnet --list-sdks` and `dotnet --list-runtimes` commands to see which versions are installed. For more information, see [How to check that .NET Core is already installed](how-to-detect-installed-versions.md?pivots=os-linux).

## Register Microsoft key and feed

Before installing .NET, you'll need to:

- Register the Microsoft key.
- Register the product repository.
- Install required dependencies.

This only needs to be done once per machine.

Open a terminal and run the following commands.

```bash
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
sudo wget -q -O /etc/yum.repos.d/microsoft-prod.repo https://packages.microsoft.com/config/fedora/29/prod.repo
```

## Install the .NET Core SDK

Update the products available for installation, then install the .NET Core SDK. In your terminal, run the following command.

```bash
sudo dnf install dotnet-sdk-3.1
```

## Install the ASP.NET Core runtime

Update the products available for installation, then install the ASP.NET runtime. In your terminal, run the following command.

```bash
sudo dnf install aspnetcore-runtime-3.1
```

## Install the .NET Core runtime

Update the products available for installation, then install the .NET Core runtime. In your terminal, run the following command.

```bash
sudo dnf install dotnet-runtime-3.1
```

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET Core.

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-rpm](includes/package-manager-failed-to-fetch-rpm.md)]

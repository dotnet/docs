---
title: Install .NET Core on Ubuntu 19.04 package manager - .NET Core
description: Use a package manager to install .NET Core SDK and runtime on Ubuntu 19.04.
author: thraka
ms.author: adegeo
ms.date: 03/17/2020
---

# Ubuntu 19.04 Package Manager - Install .NET Core

[!INCLUDE [package-manager-switcher](./includes/package-manager-switcher.md)]

This article describes how to use a package manager to install .NET Core on Ubuntu 19.04.

[!INCLUDE [package-manager-intro-sdk-vs-runtime](includes/package-manager-intro-sdk-vs-runtime.md)]

## Add Microsoft repository key and feed

Before installing .NET, you'll need to:

- Add the Microsoft package signing key to the list of trusted keys.
- Add the repository to the package manager.
- Install required dependencies.

This only needs to be done once per machine.

Open a terminal and run the following commands.

```bash
wget https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

## Install the .NET Core SDK

Update the products available for installation, then install the .NET Core SDK. In your terminal, run the following commands.

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package dotnet-sdk-3.1**, see the [Troubleshoot the package manager](#troubleshoot-the-package-manager) section.

## Install the ASP.NET Core runtime

Update the products available for installation, then install the ASP.NET Core runtime. In your terminal, run the following commands.

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install aspnetcore-runtime-3.1
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package aspnetcore-runtime-3.1**, see the [Troubleshoot the package manager](#troubleshoot-the-package-manager) section.

## Install the .NET Core runtime

Update the products available for installation, then install the .NET Core runtime. In your terminal, run the following commands.

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-runtime-3.1
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package dotnet-runtime-3.1**, see the [Troubleshoot the package manager](#troubleshoot-the-package-manager) section.

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

## Troubleshoot the package manager

This section provides information on common errors you may get while using the package manager to install .NET Core.

### Unable to locate

If you receive an error message similar to **Unable to locate package {the .NET Core package}**, run the following commands.

```bash
sudo dpkg --purge packages-microsoft-prod && sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install {the .NET Core package}
```

If that doesn't work, you can run a manual install with the following commands.

```bash
sudo apt-get install -y gpg
wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
wget https://packages.microsoft.com/config/ubuntu/19.04/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install {the .NET Core package}
```

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-deb](includes/package-manager-failed-to-fetch-deb.md)]

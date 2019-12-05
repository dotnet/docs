---
title: Install .NET Core on SLES 12 - package manager - .NET Core
description: Use a package manager to install .NET Core SDK and runtime on SLES 12.
author: thraka
ms.author: adegeo
ms.date: 12/04/2019
---

# SLES 12 Package Manager - Install .NET Core

[!INCLUDE [package-manager-switcher](./includes/package-manager-switcher.md)]

This article describes how to use a package manager to install .NET Core on SLES 12. If you're installing the runtime, we suggest you install the [ASP.NET Core runtime](#install-the-aspnet-core-runtime), as it includes both .NET Core and ASP.NET Core runtimes.

## Register Microsoft key and feed

Before installing .NET, you'll need to:

- Register the Microsoft key
- register the product repository
- Install required dependencies

This only needs to be done once per machine.

Open a terminal and run the following command.

```bash
sudo rpm -Uvh https://packages.microsoft.com/config/sles/12/packages-microsoft-prod.rpm
```

## Install the .NET Core SDK

Update the products available for installation, then install the .NET Core SDK. In your terminal, run the following command.

```bash
sudo zypper install dotnet-sdk-3.1
```

## Install the ASP.NET Core runtime

Update the products available for installation, then install the ASP.NET runtime. In your terminal, run the following command.

```bash
sudo zypper install aspnetcore-runtime-3.1
```

## Install the .NET Core runtime

Update the products available for installation, then install the .NET Core runtime. In your terminal, run the following command.

```bash
sudo zypper install dotnet-runtime-3.1
```

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

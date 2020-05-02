---
title: Install .NET Core on Linux CentOS 8 package manager - .NET Core
description: Use a package manager to install .NET Core SDK and runtime on CentOS 8.
author: thraka
ms.author: adegeo
ms.date: 05/01/2020
---

# CentOS 8 Package Manager - Install .NET Core

[!INCLUDE [package-manager-switcher](includes/package-manager-switcher.md)]

This article describes how to use a package manager to install .NET Core on CentOS 8.

[!INCLUDE [package-manager-intro-sdk-vs-runtime](includes/package-manager-intro-sdk-vs-runtime.md)]

## Install the .NET Core SDK

In your terminal, run the following command.

```bash
sudo dnf install dotnet-sdk-3.1
```

## Install the ASP.NET Core Runtime

In your terminal, run the following command.

```bash
sudo dnf install aspnetcore-runtime-3.1
```

## Install the .NET Core Runtime

In your terminal, run the following command.

```bash
sudo dnf install dotnet-runtime-3.1
```

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

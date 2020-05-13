---
title: Install .NET Core on Fedora 32 - package manager - .NET Core
description: Use a package manager to install .NET Core SDK and runtime on Fedora 32.
author: thraka
ms.author: adegeo
ms.date: 04/28/2020
---

# Fedora 32 Package Manager - Install .NET Core

[!INCLUDE [package-manager-switcher](./includes/package-manager-switcher.md)]

This article describes how to use a package manager to install .NET Core on Fedora 32.

[!INCLUDE [package-manager-intro-sdk-vs-runtime](includes/package-manager-intro-sdk-vs-runtime.md)]

Starting with Fedora 32, .NET Core 3.1 is available in the default package repositories in Fedora.

## Install the .NET Core SDK

Install the .NET Core SDK. In your terminal, run the following command.

```bash
sudo dnf install dotnet-sdk-3.1
```

## Install the ASP.NET Core runtime

Install the ASP.NET runtime. In your terminal, run the following command.

```bash
sudo dnf install aspnetcore-runtime-3.1
```

## Install the .NET Core runtime

Install the .NET Core runtime. In your terminal, run the following command.

```bash
sudo dnf install dotnet-runtime-3.1
```

## How to install other versions

To install other versions of .NET Core, manually install [the .NET Core SDK](sdk.md?pivots=os-linux#download-and-manually-install) or [the .NET Core Runtime](runtime.md?pivots=os-linux#download-and-manually-install).

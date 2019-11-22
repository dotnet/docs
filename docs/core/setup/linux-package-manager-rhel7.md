---
title: Install .NET Core on Linux RHEL 7 package manager - .NET Core
description: Use a package manager to install .NET Core SDK and runtime on RHEL 7.
author: thraka
ms.author: adegeo
ms.date: 11/06/2019
---

# RHEL 7 Package Manager - Install .NET Core

[!INCLUDE [package-manager-switcher](includes/package-manager-switcher.md)]

This article describes how to use a package manager to install .NET Core on RHEL 7.

## Register your Red Hat subscription

To install .NET Core from Red Hat on RHEL, you first need to register using the Red Hat Subscription Manager. If this hasn't been done on your system, or if you're unsure, see the [Red Hat Product Documentation for .NET Core](https://access.redhat.com/documentation/net_core/).

## Install the .NET Core SDK

After registering with the Subscription Manager, you're ready to install and enable the .NET Core SDK. In your terminal, run the following commands.

```bash
yum install rh-dotnet30 -y
scl enable rh-dotnet30 bash
```

## Install the ASP.NET Core Runtime

After registering with the Subscription Manager, you're ready to install and enable the ASP.NET Core Runtime. In your terminal, run the following commands.

<!-- TODO: is this the correct value? Taken from the webpage but it doesn't have aspnet in the name -->
```bash
yum install rh-dotnet30-dotnet-runtime-3.0 -y
scl enable rh-dotnet30 bash
```

## Install the .NET Core Runtime

After registering with the Subscription Manager, you're ready to install and enable the .NET Core Runtime. In your terminal, run the following commands.

```bash
yum install rh-dotnet30-dotnet-runtime-3.0 -y
scl enable rh-dotnet30 bash
```

## How to install other versions

[!INCLUDE [package-manager-switcher](./includes/package-manager-heading-hack-pkgname.md)]

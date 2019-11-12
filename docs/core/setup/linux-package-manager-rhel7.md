---
title: Install .NET Core on Linux RHEL 7 package manager
description: Use a package manager to install .NET Core SDK and runtime on RHEL 7.
author: thraka
ms.author: adegeo
ms.date: 11/06/2019
---

# RHEL 7 Package Manager - Install .NET Core

> [!div class="op_single_selector"]
>
> - [RHEL 7 - x64](linux-package-manager-rhel7)
> - [Ubuntu 16.04 - x64](linux-package-manager-ubuntu-1604)
> - [Ubuntu 18.04 - x64](linux-package-manager-ubuntu-1804)
> - [Ubuntu 19.04 - x64](linux-package-manager-ubuntu-1904)
> - [Debian 9 - x64](linux-package-manager-debian9)
> - [Debian 10 - x64](linux-package-manager-debian10)
> - [Debian 10 - x64](linux-package-manager-debian10)
> - [Fedora 29 - x64](linux-package-manager-fedora29)
> - [Fedora 30 - x64](linux-package-manager-fedora30)
> - [CentOS 7 - x64](linux-package-manager-centos7)
> - [OpenSUSE 42.3 - x64](linux-package-manager-opensuse423)
> - [OpenSUSE 15 - x64](linux-package-manager-opensuse15)
> - [SLES 12 - x64](linux-package-manager-sles12)
> - [SLES 15 - x64](linux-package-manager-sles15)

This article describes how to use a package manager to install .NET Core on RHEL 7.

## Register your Red Hat subscription

In order to install .NET Core from Red Hat on RHEL, you first need to register using the Red Hat Subscription Manager. If this has not been done on your system, or if you are unsure, see the [Red Hat Product Documentation for .NET Core](https://access.redhat.com/documentation/net_core/).

## Install the .NET Core SDK

After registering with the Subscription Manager, you are ready to install and enable the .NET SDK.

In your terminal, run the following commands.

```bash
yum install rh-dotnet30 -y
scl enable rh-dotnet30 bash
```

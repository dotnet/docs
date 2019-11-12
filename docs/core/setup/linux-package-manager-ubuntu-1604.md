---
title: Install .NET Core on Ubuntu 16.04 with package manager
description: Use a package manager to install .NET Core SDK and runtime on Ubuntu 16.04.
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

This article describes how to use a package manager to install .NET Core on Ubuntu 16.04.

## Register Microsoft key and feed

Before installing .NET, you'll need to register the Microsoft key, register the product repository, and install required dependencies. This only needs to be done once per machine.

Open a terminal and run the following commands:

```bash
wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

## Install the .NET Core SDK

Update the products available for installation, then install the .NET SDK.

In your terminal, run the following commands:

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.0
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package dotnet-sdk-3.0**, run the following commands.
>
> ```bash
> sudo dpkg --purge packages-microsoft-prod && sudo dpkg -i packages-microsoft-prod.deb
> sudo apt-get update
> sudo apt-get install dotnet-sdk-3.0
> ```
>
> If that doesn't work, you can run a manual install with the following commands.
> 
> ```bash
> sudo apt-get install -y gpg
> wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
> sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
> wget -q https://packages.microsoft.com/config/ubuntu/16.04/prod.list
> sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
> sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
> sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
> sudo apt-get install -y apt-transport-https
> sudo apt-get update
> sudo apt-get install dotnet-sdk-3.0
> ```

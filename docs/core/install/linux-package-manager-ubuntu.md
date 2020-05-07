---
title: Install .NET Core on Ubuntu with APT - .NET Core
description: Install .NET Core SDK and .NET Core runtime on Ubuntu using a package manager.
author: thraka
ms.author: adegeo
ms.date: 05/04/2020
---

# Install .NET Core with a package manager on Ubuntu

.NET Core is supported on different Ubuntu versions. This article describes how to install .NET Core on Ubuntu with APT. When an Ubuntu version falls out of support, .NET Core is no longer supported with that version. However, these instructions may help you to get .NET Core running on those versions, even though it isn't supported.

## Supported distributions

The following is a list of currently supported .NET Core releases and the versions of Ubuntu they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Ubuntu reaches end-of-life](https://wiki.ubuntu.com/Releases).

For the best compatibility, choose a long-term release (LTS) version.

| .NET Core | Ubuntu Version (LTS) | Ubuntu non-LTS Version |
|-----------|----------------------|------------------------|
| 2.1 (LTS) | 16.04, 18.04, 20.04  | 19.10                  |
| 3.1 (LTS) | 16.04, 18.04, 20.04  | 19.10                  |

## APT (Advanced Package Tool)

Depending on which version of Ubuntu you're using, these commands are slightly different. The changes are usually to URI paths the command uses. You'll want to modify them to match your version of Ubuntu. These changes are called out with placeholders.

The version of .NET Core in this article is `3.1`. You can replace `3.1` with a different version, such as `2.1` or even an unsupported version like `3.0`. If the command fails, it generally means that version isn't available for your Ubuntu version. If you need an unsupported version, you can try other ways to install such as [Snap](#snap).

The version of Ubuntu used in this article is `19.10`. You can change the feed URIs used here to a supported version such as `16.04`, or `20.04`. You can try to use an unsupported version, such as `17.04` but you're not guaranteed that it will work. If you need an unsupported version, you can try other ways to install such as [Snap](#snap).

## Add Microsoft repository key and feed

Before installing .NET, you'll need to:

- Add the Microsoft package signing key to the list of trusted keys.
- Add the repository to the package manager.
- Install required dependencies.

> [!TIP]
> Registering the key only needs to be done once per machine.

Open a terminal and run the following commands.

```bash
wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

## Install the SDK

The .NET Core SDK allows you to develop apps with .NET Core. To install the .NET Core SDK, run the following commands.

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package dotnet-sdk-3.1**, see the [Troubleshoot APT](#troubleshoot-apt) section.

## Install the runtime

The .NET Core runtime allows you to run apps that were made with .NET Core but didn't include the runtime. The commands below install the ASP.NET Core runtime, which is the most compatible runtime for .NET Core. In your terminal, run the following commands.

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install aspnetcore-runtime-3.1
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package aspnetcore-runtime-3.1**, see the [Troubleshoot APT](#troubleshoot-apt) section.

As an alternative to the ASP.NET Core runtime, you can install the .NET Core runtime that doesn't include ASP.NET Core support: replace `aspnetcore-runtime-3.1` in the command above with `dotnet-runtime-3.1`.

```bash
sudo apt-get install dotnet-runtime-3.1
```

## Troubleshoot APT

This section provides information on common errors you may get while using [APT to install .NET Core](#apt-advanced-package-tool).

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
wget https://packages.microsoft.com/config/ubuntu/19.10/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install {the .NET Core package}
```

### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-deb](includes/package-manager-failed-to-fetch-deb.md)]

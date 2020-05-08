---
title: Install .NET Core on Ubuntu - .NET Core
description: Demonstrates the various ways to install .NET Core SDK and .NET Core Runtime on Ubuntu.
author: thraka
ms.author: adegeo
ms.date: 05/04/2020
---

# Install .NET Core SDK and .NET Core Runtime on Ubuntu

.NET Core is supported on different Ubuntu versions. This article describes how to install .NET Core on Ubuntu with APT. When an Ubuntu version falls out of support, .NET Core is no longer supported with that version. However, these instructions may help you to get .NET Core running on those versions, even though it isn't supported.

## Supported distributions

The following is a list of currently supported .NET Core releases and the versions of Ubuntu they're supported on. These versions remain supported until either the version of [.NET Core reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Ubuntu reaches end-of-life](https://wiki.ubuntu.com/Releases).

For the best compatibility, choose a long-term release (LTS) version.

| .NET Core | Ubuntu version (LTS) | Ubuntu version |
|-----------|----------------------|----------------|
| 2.1 (LTS) | 16.04, 18.04, 20.04  | 19.10          |
| 3.1 (LTS) | 16.04, 18.04, 20.04  | 19.10          |

.NET Core versions no longer supported and the Ubuntu LTS releases they were supported with:

| .NET Core | Ubuntu version (LTS) |
|-----------|----------------------|
| 3.0       | 16.04, 18.04         |
| 2.2       | 16.04, 18.04         |
| 2.0       | 14.04, 16.04, 18.04  |

## APT (Advanced Package Tool)

APT comes with Ubuntu and Microsoft publishes APT-compatable feeds that can be used to install .NET Core. While the examples in this section use Ubuntu version `20.04` and .NET Core version `3.1`, you may need to change the versions in the commands below to the correct versions suited for your environment.

### Add Microsoft repository key and feed

Before installing .NET, you'll need to:

- Add the Microsoft package signing key to the list of trusted keys.
- Add the repository to the package manager.
- Install required dependencies.

> [!TIP]
> Registering the key only needs to be done once per machine.

Open a terminal and run the following commands.

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

Use the following table for the correct URL based on the version of Ubuntu you're running:

| Ubuntu version | URL                                                                            |
|----------------|--------------------------------------------------------------------------------|
| 20.04          | https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb |
| 19.10          | https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb |
| 19.04          | https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb |
| 18.10          | https://packages.microsoft.com/config/ubuntu/18.10/packages-microsoft-prod.deb |
| 18.04          | https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb |
| 17.10          | https://packages.microsoft.com/config/ubuntu/17.10/packages-microsoft-prod.deb |
| 17.04          | https://packages.microsoft.com/config/ubuntu/17.04/packages-microsoft-prod.deb |
| 16.10          | https://packages.microsoft.com/config/ubuntu/16.10/packages-microsoft-prod.deb |
| 16.04          | https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb |

### Install the SDK

The .NET Core SDK allows you to develop apps with .NET Core. To install the .NET Core SDK, run the following commands.

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package dotnet-sdk-3.1**, see the [Troubleshoot APT](#troubleshoot-apt) section.

### Install the runtime

The .NET Core Runtime allows you to run apps that were made with .NET Core that didn't include the runtime. The commands below install the ASP.NET Core Runtime, which is the most compatible runtime for .NET Core. In your terminal, run the following commands.

```bash
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install aspnetcore-runtime-3.1
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package aspnetcore-runtime-3.1**, see the [Troubleshoot APT](#troubleshoot-apt) section.

As an alternative to the ASP.NET Core Runtime, you can install the .NET Core Runtime that doesn't include ASP.NET Core support: replace `aspnetcore-runtime-3.1` in the command above with `dotnet-runtime-3.1`.

```bash
sudo apt-get install dotnet-runtime-3.1
```

### Troubleshoot APT

This section provides information on common errors you may get while using [APT to install .NET Core](#apt-advanced-package-tool).

#### Unable to locate

If you receive an error message similar to **Unable to locate package {the .NET Core package}**, run the following commands.

```bash
sudo dpkg --purge packages-microsoft-prod && sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install {the .NET Core package}
```

If that doesn't work, you can run a manual install with the following commands:

```bash
sudo apt-get install -y gpg
wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install {the .NET Core package}
```

Use the following table for the correct URL based on the version of Ubuntu you're running:

| Ubuntu version | URL                                                          |
|----------------|--------------------------------------------------------------|
| 20.04          | https://packages.microsoft.com/config/ubuntu/20.04/prod.list |
| 19.10          | https://packages.microsoft.com/config/ubuntu/19.10/prod.list |
| 19.04          | https://packages.microsoft.com/config/ubuntu/19.04/prod.list |
| 18.10          | https://packages.microsoft.com/config/ubuntu/18.10/prod.list |
| 18.04          | https://packages.microsoft.com/config/ubuntu/18.04/prod.list |
| 17.10          | https://packages.microsoft.com/config/ubuntu/17.10/prod.list |
| 17.04          | https://packages.microsoft.com/config/ubuntu/17.04/prod.list |
| 16.10          | https://packages.microsoft.com/config/ubuntu/16.10/prod.list |
| 16.04          | https://packages.microsoft.com/config/ubuntu/16.04/prod.list |

#### Failed to fetch

[!INCLUDE [package-manager-failed-to-fetch-deb](includes/package-manager-failed-to-fetch-deb.md)]

## Snap

[.NET Core is available from the Snap Store.](https://snapcraft.io/dotnet-sdk)

A snap is a bundle of an app and its dependencies that works without modification across many different Linux distributions. Snaps are discoverable and installable from the Snap Store. For more information about Snap, see [Getting started with Snap](https://snapcraft.io/docs/getting-started).

Only supported versions of .NET Core are available through Snap. Use the following commands to install.

### Install the SDK

Snap packages for .NET Core SDK are all published under the same identifier: `dotnet-sdk`. A specific version of the SDK can be installed by specifying the channel. The SDK includes the coresponding runtime. The following table list the channels:

| .NET Core version | Snap package             |
|-------------------|--------------------------|
| 3.1 (LTS)         | `3.1` or `latest/stable` |
| 2.1 (LTS)         | `2.1`                    |
| .NET 5.0 preview  | `5.0/beta`               |

Use the `snap install` command to install a .NET Core SDK snap package. Use the `--channel` parameter to indicate which version to install. If this parameter is omitted, `latest/stable` is used. In this example, `3.1` is specified:

```bash
sudo snap install dotnet-sdk --classic --channel=3.1
```

Next, register the `dotnet` command for the system with the `snap alias` command:

```bash
sudo snap alias dotnet-sdk.dotnet dotnet
```

### Install the runtime

Snap packages for .NET Core Runtime are each published under their own package identifier. The following table lists the package identifiers:

| .NET Core version | Snap package        |
|-------------------|---------------------|
| 3.1 (LTS)         | `dotnet-runtime-31` |
| 3.0               | `dotnet-runtime-30` |
| 2.2               | `dotnet-runtime-22` |
| 2.1 (LTS)         | `dotnet-runtime-21` |

Use the `snap install` command to install a .NET Core Runtime snap package. In this example, .NET Core 3.1 is installed:

```bash
sudo snap install dotnet-runtime-31 --classic
```

Next, register the `dotnet` command for the system with the `snap alias` command:

```bash
sudo snap alias dotnet-runtime-31.dotnet dotnet
```

## Scripted install

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the **SDK**. You can download the script from <https://dot.net/v1/dotnet-install.sh>.

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. To install the current release, which may not be an (LTS) version, use the `-c Current` parameter.

```bash
./dotnet-install.sh -c Current
```

To install .NET Core Runtime instead of the SDK, use the `--runtime` parameter.

```bash
./dotnet-install.sh -c Current --runtime
```

You can install a specific version by altering the `-c` parameter to indicate the specific version. The following command installs .NET Core SDK 3.0.

```bash
./dotnet-install.sh -c 3.0
```

For more information, see [dotnet-install scripts reference](../tools/dotnet-install-script.md).

## Manual install

Both .NET Core SDK and .NET Core Runtime can be manually installed after they've been downloaded. First, download a binary release for either the SDK or the runtime from one of the following sites:

- [.NET 5.0 preview downloads](https://dotnet.microsoft.com/download/dotnet/5.0)
- [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [.NET Core 3.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.0)
- [.NET Core 2.2 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1)

Next, extract the downloaded file and use the `export` command to set variables used by .NET Core and then ensure .NET Core is in PATH.

To extract the runtime and make the .NET Core CLI commands available at the terminal, first [download](#all-net-core-downloads) a .NET Core binary release. Then, open a terminal and run the following commands from the directory where the file was saved.

```bash
mkdir -p $HOME/dotnet && tar zxf aspnetcore-runtime-3.1.0-linux-x64.tar.gz -C $HOME/dotnet
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

> [!TIP]
> The preceding `export` commands only make the .NET Core CLI commands available for the terminal session in which it was run.
>
> You can edit your shell profile to permanently add the commands. There are a number of different shells available for Linux and each has a different profile. For example:
>
> - **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
> - **Korn Shell**: *~/.kshrc* or *.profile*
> - **Z Shell**: *~/.zshrc* or *.zprofile*
>
> Edit the appropriate source file for your shell and add `:$HOME/dotnet` to the end of the existing `PATH` statement. If no `PATH` statement is included, add a new line with `export PATH=$PATH:$HOME/dotnet`.
>
> Also, add `export DOTNET_ROOT=$HOME/dotnet` to the end of the file.

This approach lets you install different versions into separate locations and choose explicitly which one to use by which application.

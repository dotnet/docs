---
title: Prerequisites for .NET Core on Linux
description: Supported Linux versions and .NET Core dependencies to develop, deploy, and run .NET Core applications on Linux machines.
keywords: .NET, .NET Core, Linux, debian, ubuntu, RHEL, centOS,
author: johalex
ms.author: johalex
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
---

# Prerequisites for .NET Core on Linux

This article shows the dependencies needed to develop .NET Core applications on Linux. The supported Linux distributions/versions, and dependencies that follow apply to the two ways of developing .NET Core apps on Linux:

* [Command line](tutorials/using-with-xplat-cli.md)
* [Visual Studio Code](https://code.visualstudio.com/)

## Supported Linux versions

.NET Core 2.x is supported on the following Linux distributions/versions:

 * Red Hat Enterprise Linux 7 x64
 * CentOS 7 x64
 * Oracle Linux 7 x64
 * Fedora 25, 26 x64
 * Debian 9, 8.7+ x64 
 * Ubuntu 17.04, 16.04, 14.04  x64
 * Linux Mint 18, 17 x64
 * openSUSE 42.2+ x64
 * SUSE Enterprise Linux (SLES) 12 SP2+ x64

.NET Core 1.x is supported on the following Linux distributions/versions:

* Red Hat Enterprise Linux / CentOS / Oracle Linux 7 x64
* Fedora 24 x64
* Debian 8.2+ x64
* Ubuntu / Linux Mint 14.04, 16.04, 16.10*, 17 x64
* openSUSE 42.1 (1.1) x64
> [!NOTE]
> Ubuntu / Linux 16.10 is supported by the latest patch release of .NET Core 1.1

See [.NET Core 2.x Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md) for the complete list of .NET Core 2.x supported operating systems, out of support OS versions, and lifecycle policy links.

See [.NET Core 1.x Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0-supported-os.md) for the complete list of .NET Core 1.x supported operating systems, out of support OS versions, and lifecycle policy links.
## Linux Distribution Dependencies
### Ubuntu
Ubuntu distributions require the following libraries installed:

* libunwind8
* libunwind8-dev
* gettext
* libicu-dev
* liblttng-ust-dev
* libcurl4-openssl-dev
* libssl-dev
* uuid-dev
* unzip

### CentOS
CentOS distributions require the following libraries installed:
* deltarpm
* epel-release
* unzip
* libunwind
* gettext
* libcurl-devel
* openssl-devel
* zlib
* libicu-devel

## Installing .NET Core Prerequisites With the Native Installers

.NET Core native installers are available for supported Linux distributions/ versions. The native installers require admin (sudo) access to the server. The advantage of using a native installer is that the all of the .NET Core native dependencies are installed. Native installers also install the .NET Core SDK system-wide.

On Linux, there are two installer package choices: 
* Using a feed-based package manager, such as apt-get for Ubuntu, or yum for CentOS. 
* Using the packages themselves, DEB or RPM. 

### Scripting Installs With the .NET Core Installer Script 

The `dotnet-install` scripts are used to perform a non-admin install of the CLI toolchain and the shared runtime. You can download the scripts from the [CLI GitHub repo](https://github.com/dotnet/cli/tree/rel/1.0.0/scripts/obtain). 

The installer bash script is used in automation scenarios and non-admin installations. This script also reads PowerShell switches, so they can be used with the script on Linux/OS X systems.

> [!IMPORTANT]
> Before running the script, install the required [dependencies](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md).

## Install .NET Core dependencies for Red Hat Enterprise Linux (RHEL) 7 Server

> [!Warning]
> Before you start, remove any previous versions of .NET Core from your system.

### Verify and Enable the .NET channel for RHEL 7 Server
To install .NET Core dependencies on RHEL Server:

1. Enable the Red Hat .NET channel, available under your RHEL 7 Server subscription. 
    * For Red Hat Enterprise 7 Server, use:
         ```bash
        subscription-manager repos --enable=rhel-7-server-dotnet-rpms
        ```
    * For Red Hat Enterprise 7 Workstation, use:
         ```bash
        subscription-manager repos --enable=rhel-7-workstation-dotnet-rpms
        ```
    * For Red Hat Enterprise 7 HPC Compute Node, use:
         ```bash
        subscription-manager repos --enable=rhel-7-hpc-node-dotnet-rpms
        ```

2. Install the scl tool.
    ```bash
    yum install scl-utils
    ```
3. Install .NET Core 1.1 (and all dependencies):
    ```bash
    yum install rh-dotnetcore11
    scl enable rh-dotnetcore11 bash
    ```
4. Run the `dotnet --help` command to prove the installation succeeded.

     ```bash
     dotnet --help
     ```
> [!NOTE]
> For Red Hat .NET channel access registration help, see [Chapter 1 of the .NET Core 1.1 Getting Started Guide](https://access.redhat.com/documentation/en/net-core/1.1/paged/getting-started-guide/) at Red Hat.


## Install .NET Core for Ubuntu 14.04, 16.04, 16.10 & Linux Mint 17, 18 (64 bit)

> [!Warning]
> Before you start, remove any previous versions of .NET Core from your system.

### Add the dotnet apt-get feed

1. Set up the desired version host package feed.

   **Ubuntu 14.04 / Linux Mint 17**
    ```bash
    sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list' 
    sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
    sudo apt-get update
    ```
    **Ubuntu 16.04 / Linux Mint 18**
    ```bash
    sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list' 
    sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
    sudo apt-get update
    ```
    **Ubuntu 16.10**
    ```bash
    sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ yakkety main" > /etc/apt/sources.list.d/dotnetdev.list' 
    sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
    sudo apt-get update
    ```
2. Install .NET Core.
# [.NET Core 2.x](#tab/netcore2x)

After host package feed setup, install .NET Core 2.0 on Ubuntu or Linux Mint:
```bash
sudo apt-get install dotnet-sdk-2.0.0
```
# [.NET Core 1.x](#tab/netcore1x)

After host package feed setup, install .NET Core 1.x on Ubuntu or Linux Mint:
```bash
sudo apt-get install dotnet-dev-1.0.4
```
---
3. Run the `dotnet --help` command to prove the installation succeeded.

 ```bash
     dotnet --help
 ```
## Install .NET Core for Debian 8 or 9 (64 bit).

> [!Warning]
> Before you start, remove any previous versions of .NET Core from your system.

To install .NET Core on Debian 8 or 9 (64 bit):
1. Get the prerequisites. 
    ```bash
    sudo apt-get install curl libunwind8 gettext
    ```
2. Download the .NET Core SDK binaries (tarball).

# [.NET Core 2.x](#tab/netcore2x)   

```bash
     curl -sSL -o dotnet.tar.gz https://aka.ms/dotnet-sdk-2.0.0-linux-x64
```

# [.NET Core 1.x](#tab/netcore1x)   

```bash
     curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848826
```
---
3. Extract the .NET Core SDK binaries.
    ```bash
    sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
    ```
4. Add dotnet to your PATH.
    ```bash
    sudo ln -s /opt/dotnet/dotnet /usr/local/bin
    ```
5. Run the `dotnet --help` command to prove the installation succeeded.

     ```bash
     dotnet --help
     ```

## Install .NET Core for Fedora 24, 25, or 26 (64 bit)

> [!Warning]
> Before you start, remove any previous versions of .NET Core from your system.

To Install .NET Core for Fedora 26,25(.NET Core 2.x) or 24 (.NET Core 1.x): 
1. Get the prerequisites. 
    ```bash
    sudo dnf install libunwind libicu
    ```
2. Download the .NET Core SDK binary  (tarball).

# [.NET Core 2.x](#tab/netcore2x)

**Fedora 26 or 25**

```bash
curl -sSL -o dotnet.tar.gz https://aka.ms/dotnet-sdk-2.0.0-linux-x64
```

# [.NET Core 1.x](#tab/netcore1x)

**Fedora 24**

```bash
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848833
```

---
3. Extract the .NET Core SDK binaries.
    ```bash
    sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
    ```
4. Add dotnet to your PATH.
    ```bash
    sudo ln -s /opt/dotnet/dotnet /usr/local/bin
    ```
5. Run the `dotnet --help` command to prove the installation succeeded.

     ```bash
     dotnet --help
     ```
## Install .NET Core for CentOS 7.1 (64 bit) & Oracle Linux 7.1 (64 bit)

> [!Warning]
> Before you start, remove any previous versions of .NET Core from your system.

To Install .NET Core for CentOS 7.1 (64 bit) & Oracle Linux 7.1 (64 bit):

1. Get the prerequisites.
    ```bash
    sudo dnf install libunwind libicu
    ```
2. Download the .NET Core SDK binary (tarball).

# [.NET Core 2.x](#tab/netcore2x)

```bash
curl -sSL -o dotnet.tar.gz https://aka.ms/dotnet-sdk-2.0.0-linux-x64
```

# [.NET Core 1.x](#tab/netcore1x)

```bash
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848821
```

---
3. Extract the .NET Core SDK binaries.
    ```bash
    sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
    ```
4. Add dotnet to your PATH.
    ```bash
    sudo ln -s /opt/dotnet/dotnet /usr/local/bin
    ```
5. Run the `dotnet --help` command to prove the installation succeeded.

     ```bash
     dotnet --help
     ```
## Install .NET Core for SUSE Linux Enterprise Server (64 bit) (.NET Core 2.x) and openSUSE (64 bit)

> [!Warning]
> Before you start, remove any previous versions of .NET Core from your system.

To Install .NET Core for SUSE Linux Enterprise Server (SLES) 12 SP2 (64 bit) and openSUSE 42.2 on NET Core 2.x, or openSUSE 42.1(64 bit) on .NET Core 1.x:

1. Get the prerequisites.
    ```bash
    sudo zypper install libunwind libicu
    ```
2. Download the .NET Core SDK binary (tarball).

# [.NET Core 2.x](#tab/netcore2x)

**SLES 12 SP2, openSUSE 42.2**

```bash
curl -sSL -o dotnet.tar.gz https://aka.ms/dotnet-sdk-2.0.0-linux-x64
```

# [.NET Core 1.x](#tab/netcore1x)

**openSUSE 42.1**

```bash
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848824
```

---
3. Extract the .NET Core SDK binaries.
    ```bash
    sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
    ```
4. Add dotnet to your PATH.
    ```bash
   sudo ln -s /opt/dotnet/dotnet /usr/local/bin
    ```
5. Run the `dotnet --help` command to prove the installation succeeded.

     ```bash
     dotnet --help
     ```

> [!IMPORTANT]
> If you have problems with the .NET Core 2.x installation on a supported Linux distribution/version, consult the [2.0 Known issues](https://github.com/dotnet/core/tree/master/release-notes/2.0) topic for your installed distributions/versions.
> [!IMPORTANT]
> If you have problems with the .NET Core 1.x installation on a supported Linux distribution/version, consult the [1.0.0 Known Issues](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0-known-issues.md) and [1.0.1 Known Issues](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.1-known-issues.md) topics for your installed distributions/versions.
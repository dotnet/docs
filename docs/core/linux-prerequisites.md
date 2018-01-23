---
title: Prerequisites for .NET Core on Linux
description: Supported Linux versions and .NET Core dependencies to develop, deploy, and run .NET Core applications on Linux machines.
keywords: .NET, .NET Core, Linux, debian, ubuntu, RHEL, centOS,
author: jralexander
ms.author: johalex
ms.date: 12/06/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c33b1241-ab66-4583-9eba-52cf51146f5a
ms.workload: 
  - dotnetcore
---

# Prerequisites for .NET Core on Linux

This article shows the dependencies needed to develop .NET Core applications on Linux. The supported Linux distributions/versions, and dependencies that follow apply to the two ways of developing .NET Core apps on Linux:

* [Command-line with your favorite editor](tutorials/using-with-xplat-cli.md)
* [Visual Studio Code](https://code.visualstudio.com/)

## Supported Linux versions

# [.NET Core 2.x](#tab/netcore2x)

.NET Core 2.0 treats Linux as a single operating system. There is a single Linux build (per chip architecture) for supported Linux distros.

NET Core 2.x is supported on the following Linux 64-bit (`x86_64` or `amd64`) distributions/versions:

 * Red Hat Enterprise Linux 7
 * CentOS 7
 * Oracle Linux 7
 * Fedora 25, Fedora 26
 * Debian 8.7 or later versions 
 * Ubuntu 17.04, Ubuntu 16.04, Ubuntu 14.04
 * Linux Mint 18, Linux Mint 17
 * openSUSE 42.2 or later versions
 * SUSE Enterprise Linux (SLES) 12 SP2 or later versions

See [.NET Core 2.x Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md) for the complete list of .NET Core 2.x supported operating systems, out of support OS versions, and lifecycle policy links.

# [.NET Core 1.x](#tab/netcore1x)

.NET Core 1.x is supported on the following Linux 64-bit (`x86_64` or `amd64`) distributions/versions:

* Red Hat Enterprise Linux 7
* CentOS 7
* Oracle Linux 7
* Fedora 24
* Debian 8.2 or later versions
* Ubuntu 14.04, Ubuntu 16.04, Ubuntu 16.10\*
 * Ubuntu 16.10 is supported by the latest patch release of .NET Core 1.1
* Linux Mint 17
* openSUSE 42.1 or later versions (.NET Core 1.1)

See [.NET Core 1.x Supported OS Versions](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0-supported-os.md) for the complete list of .NET Core 1.x supported operating systems, out of support OS versions, and lifecycle policy links.

---

## Linux distribution dependencies

The following are intended to be examples. The exact versions and names may vary slightly on your Linux distribution of choice.

### Ubuntu

Ubuntu distributions require the following libraries installed:

* libunwind8
* liblttng-ust0
* libcurl3
* libssl1.0.0
* libuuid1
* libkrb5-3
* zlib1g
* libicu52 (for 14.X)
* libicu55 (for 16.X)
* libicu57 (for 17.X)

### CentOS

CentOS distributions require the following libraries installed:

* libunwind
* lttng-ust
* libcurl
* openssl-libs
* libuuid
* krb5-libs
* libicu
* zlib

For more information about the dependencies, see [Self-contained Linux applications](https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md).

## Installing .NET Core dependencies with the native installers

.NET Core native installers are available for supported Linux distributions/versions. The native installers require admin (sudo) access to the server. The advantage of using a native installer is that all of the .NET Core native dependencies are installed. Native installers also install the .NET Core SDK system-wide.

On Linux, there are two installer package choices:

* Using a feed-based package manager, such as apt-get for Ubuntu, or yum for CentOS/RHEL.
* Using the packages themselves, DEB or RPM.

### Scripting Installs with the .NET Core installer script

The `dotnet-install` scripts are used to perform a non-admin install of the CLI toolchain and the shared runtime. You can download the script from: https://dot.net/v1/dotnet-install.sh

The installer bash script is used in automation scenarios and non-admin installations. This script also reads PowerShell switches, so they can be used with the script on Linux/OS X systems.

> [!IMPORTANT]
> Before running the script, install the required [dependencies](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md).

## Install .NET Core for Red Hat Enterprise Linux (RHEL) 7

To install .NET Core on RHEL 7:

1. Enable the Red Hat .NET channel, available under your RHEL 7 subscription.
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
    
3. Install .NET Core

# [.NET Core 2.x](#tab/netcore2x)

Install .NET Core 2.0 SDK and Runtime:

   ```bash
   yum install rh-dotnet20
   ```

Enable .NET Core 2.0 SDK/Runtime for your environment:

   ```bash
   scl enable rh-dotnet20 bash
   ```

# [.NET Core 1.x](#tab/netcore1x)

**.NET Core 1.1**

Install .NET Core 1.1 SDK and Runtime:

   ```bash
   yum install rh-dotnetcore11
   ```

Enable .NET Core 1.1 SDK and Runtime for your environment:

   ```bash
   scl enable rh-dotnetcore11 bash
   ```

**.NET Core 1.0**

Install .NET Core 1.0 SDK and Runtime:

   ```bash
   yum install rh-dotnetcore10
   ```

Enable .NET Core 1.0 SDK and Runtime for your environment:

   ```bash
   scl enable rh-dotnetcore10 bash
   ```

---
4. Run the `dotnet --version` command to prove the installation succeeded.

     ```bash
     dotnet --version
     ```

For Red Hat .NET channel access registration help, see [Chapter 1 of the .NET Core 1.1 Getting Started Guide](https://access.redhat.com/documentation/en/net-core/1.1/paged/getting-started-guide/) at Red Hat.

## Install .NET Core for Ubuntu 14.04, Ubuntu 16.04, Ubuntu 16.10 & Linux Mint 17, Linux Mint 18 (64 bit)

1. Remove any **previous preview** versions of .NET Core from your system.

# [.NET Core 2.x](#tab/netcore2x)

2. Register the Microsoft Product key as trusted.

   ```bash
   curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
   sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
   ```

3. Set up the desired version host package feed.

   **Ubuntu 17.10**

   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-artful-prod artful main" > /etc/apt/sources.list.d/dotnetdev.list'
   sudo apt-get update
   ```
   **Ubuntu 17.04**

   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-zesty-prod zesty main" > /etc/apt/sources.list.d/dotnetdev.list'
   sudo apt-get update
   ```

   **Ubuntu 16.04 / Linux Mint 18**

   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
   sudo apt-get update
   ```

   **Ubuntu 14.04 / Linux Mint 17**

   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-trusty-prod trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
   sudo apt-get update
   ```

4. Install .NET Core.

   ```bash
   sudo apt-get install dotnet-sdk-2.1.3
   ```

4. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```

# [.NET Core 1.x](#tab/netcore1x)

2. Set up the desired version host package feed.

   **Ubuntu 16.10**
   
   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ yakkety main" > /etc/apt/sources.list.d/dotnetdev.list'
   sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
   sudo apt-get update
   ```

  **Ubuntu 16.04 / Linux Mint 18**

   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
   sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
   sudo apt-get update
   ```
    
   **Ubuntu 14.04 / Linux Mint 17**

   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
   sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys B02C46DF417A0893
   sudo apt-get update
   ```

3. Install .NET Core 1.x on Ubuntu or Linux Mint:

   ```bash
   sudo apt-get install dotnet-dev-1.0.4
   ```

4. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```

---

 ## Install .NET Core for Debian 8 or Debian 9 (64 bit)

To install .NET Core on Debian 8 or Debian 9 (64 bit):

1. Remove any **previous preview** versions of .NET Core from your system.

> [!NOTE]
> A user-controlled directory is required for Linux system installs from tar.gz.

# [.NET Core 2.x](#tab/netcore2x)

2. Install system components.

   ```bash
   sudo apt-get update
   sudo apt-get install curl libunwind8 gettext apt-transport-https
   ```
   
3. Register the trusted Microsoft Product key.

   ```bash
   curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
   sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
   ```
   
4. Register the Microsoft Product feed.

   **Debian 9 (Stretch)**

   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-debian-stretch-prod stretch main" > /etc/apt/sources.list.d/dotnetdev.list'
   ```
   
   **Debian 8 (Jessie)**
   
   ```bash
   sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-debian-jessie-prod jessie main" > /etc/apt/sources.list.d/dotnetdev.list'
   ```
   
5. Install .NET Core SDK.

   ```bash
   sudo apt-get update
   sudo apt-get install dotnet-sdk-2.0.0
   ```

6. Add dotnet to your PATH.

   ```bash
   export PATH=$PATH:$HOME/dotnet
   ```
   
7. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```   
  

# [.NET Core 1.x](#tab/netcore1x)

2. Get the prerequisites.

   ```bash
   sudo apt-get install curl libunwind8 gettext
   ```

3. Download the .NET Core SDK binaries (tarball).

   ```bash
   curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848826
   ```

4. Extract the .NET Core SDK binaries.

   ```bash
   sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
   ```

5. Add dotnet to your PATH.

   ```bash
   sudo ln -s /opt/dotnet/dotnet /usr/local/bin
   ```

6. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```

---

## Install .NET Core for Fedora 24, Fedora 25, or Fedora 26 (64 bit)

To install .NET Core 2.x on Fedora 26 or Fedora 25, or .NET Core 1.x on Fedora 24:

1. Remove any **previous preview** versions of .NET Core from your system.

> [!NOTE]
> A user-controlled directory is required for Linux system installs from tar.gz.

# [.NET Core 2.x](#tab/netcore2x)

**Fedora 26 or Fedora 25**

2. Register the Microsoft signature key.

   ```bash
   sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
   ```

3. Add the dotnet product feed.

   ```bash
   sudo sh -c 'echo -e "[packages-microsoft-com-prod]\nname=packages-microsoft-com-prod \nbaseurl=https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/dotnetdev.repo'
   ```

4. Install the .NET Core SDK.

   ```bash
   sudo dnf update
   sudo dnf install libunwind libicu
   sudo dnf install dotnet-sdk-2.0.0
   ```

5. Add dotnet to your PATH.

   ```bash
   export PATH=$PATH:$HOME/dotnet
   ```

# [.NET Core 1.x](#tab/netcore1x)

**Fedora 24**

2. Get the prerequisites.

   ```bash
   sudo dnf install libunwind libicu
   ```

3. Download the .NET Core SDK binary  (tarball).

   ```bash
   curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848833
   ```

4. Extract the .NET Core SDK binaries.

   ```bash
   sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
   ```

5. Add dotnet to your PATH.

   ```bash
   sudo ln -s /opt/dotnet/dotnet /usr/local/bin
   ```
   
---

6. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```

## Install .NET Core for CentOS 7.1 (64 bit) & Oracle Linux 7.1 (64 bit)

To install .NET Core for CentOS 7.1 (64 bit) & Oracle Linux 7.1 (64 bit):

1. Remove any **previous preview** versions of .NET Core from your system.

> [!NOTE]
> A user-controlled directory is required for Linux system installs from tar.gz.

# [.NET Core 2.x](#tab/netcore2x)

2. Register the Microsoft signature key.

   ```bash
   sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
   ```

3. Add the Microsoft Product feed.

   ```bash
   sudo sh -c 'echo -e "[packages-microsoft-com-prod]\nname=packages-microsoft-com-prod \nbaseurl=https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/yum.repos.d/dotnetdev.repo'
   ```

4. Install the .NET Core SDK.

   ```bash
   sudo yum update
   sudo yum install libunwind libicu
   sudo yum install dotnet-sdk-2.0.0
   ```

5. Add dotnet to your PATH

   ```bash
   export PATH=$PATH:$HOME/dotnet
   ```

# [.NET Core 1.x](#tab/netcore1x)

2. Get the prerequisites.

   ```bash
   sudo yum install libunwind libicu
   ```
   
3. Download the .NET Core SDK binary (tarball).

   ```bash
   curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848821
   ```

4. Extract the .NET Core SDK binaries.

   ```bash
   sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
   ```

5. Add dotnet to your PATH.

   ```bash
   sudo ln -s /opt/dotnet/dotnet /usr/local/bin
   ```

---

6. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```

## Install .NET Core for SUSE Linux Enterprise Server (64 bit)

To install .NET Core 2.x for SUSE Linux Enterprise Server (SLES) 12 SP2 (64 bit):

1. Remove any **previous preview** versions of .NET Core from your system.

2. Add the dotnet product feed.

   ```bash
   sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
   sudo sh -c 'echo -e "[packages-microsoft-com-prod]\nname=packages-microsoft-com-prod \nbaseurl=https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/zypp/repos.d/dotnetdev.repo'
   ```

3. Install the .NET Core SDK.

   ```bash
   sudo zypper update
   sudo zypper install libunwind libicu
   sudo zypper install dotnet-sdk-2.0.0
   ```

4. Add dotnet to your PATH.

   ```bash
   export PATH=$PATH:$HOME/dotnet
   ```

5. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```
   
## Install .NET Core for openSUSE (64 bit)

To install .NET Core 2.x for openSUSE or .NET Core 1.x for openSUSE (64 bit):

1. Remove any **previous preview** versions of .NET Core from your system.

> [!NOTE]
> A user-controlled directory is required for Linux system installs from tar.gz.

# [.NET Core 2.x](#tab/netcore2x)

2. Register the Microsoft signature key.

   ```bash
   sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
   ```

3. Add the dotnet product feed.

   ```bash
   sudo sh -c 'echo -e "[packages-microsoft-com-prod]\nname=packages-microsoft-com-prod \nbaseurl=https://packages.microsoft.com/yumrepos/microsoft-rhel7.3-prod\nenabled=1\ngpgcheck=1\ngpgkey=https://packages.microsoft.com/keys/microsoft.asc" > /etc/zypp/repos.d/dotnetdev.repo'
   ``` 

4. Install the .NET Core SDK.

   ```bash
   sudo zypper update
   sudo zypper install libunwind libicu
   sudo zypper install dotnet-sdk-2.0.0
   ```

5. Add dotnet to your PATH.

   ```bash
   export PATH=$PATH:$HOME/dotnet
   ```

# [.NET Core 1.x](#tab/netcore1x)

2. Get the prerequisites.

   ```bash
   sudo zypper install libunwind libicu
   ```

3. Download the .NET Core SDK binary (tarball).

   ```bash
   curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?linkid=848824
   ```

4. Extract the .NET Core SDK binaries.
   
   ```bash
   sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
   ```

5. Add dotnet to your PATH.

   ```bash
   sudo ln -s /opt/dotnet/dotnet /usr/local/bin
   ```
   
---

6. Run the `dotnet --version` command to prove the installation succeeded.

   ```bash
   dotnet --version
   ```

> [!IMPORTANT]
> If you have problems with the .NET Core 2.x installation on a supported Linux distribution/version, consult the [2.0 Known issues](https://github.com/dotnet/core/tree/master/release-notes/2.0) topic for your installed distributions/versions. 
>
> If you have problems with the .NET Core 1.x installation on a supported Linux distribution/version, consult the [1.0.0 Known Issues](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0-known-issues.md) and [1.0.1 Known Issues](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.1-known-issues.md) topics for your installed distributions/versions.

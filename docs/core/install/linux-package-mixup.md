---
title: Troubleshoot .NET package mix ups on Linux
description: Learn about how to troubleshoot strange .NET package errors on Linux. These errors may occur when you run the dotnet command.
author: omajid
ms.date: 03/01/2023
no-loc: ['usr','lib64','share','dotnet','libhostfxr.so', 'fxr', 'FrameworkList.xml', 'System.IO.FileNotFoundException']
zone_pivot_groups: operating-systems-set-two
---

# Troubleshoot .NET errors related to missing files on Linux

When you try to use .NET on Linux, commands such as `dotnet new` and `dotnet run` may fail with a message related to a file not being found, such as _fxr_, _libhostfxr.so_, or _FrameworkList.xml_. Some of the error messages may be similar to the following items:

- **System.IO.FileNotFoundException**

  > System.IO.FileNotFoundException: Could not find file '/usr/share/dotnet/packs/Microsoft.NETCore.App.Ref/5.0.0/data/FrameworkList.xml'.

- **A fatal error occurred.**

  > A fatal error occurred. The required library _libhostfxr.so_ could not be found.

  or

  > A fatal error occurred. The folder \[/usr/share/dotnet/host/fxr] does not exist.

  or

  > A fatal error occurred, the folder \[/usr/share/dotnet/host/fxr] does not contain any version-numbered child folders.

- **Generic messages about dotnet not found**

  A general message may appear that indicates the SDK isn't found, or that the package has already been installed.

One symptom of these problems is that both the `/usr/lib64/dotnet` and `/usr/share/dotnet` folders are on your system.

> [!TIP]
> Use the `dotnet --info` command to list which SDKs and Runtimes are installed. For more information, see [How to check that .NET is already installed](how-to-detect-installed-versions.md?pivots=os-linux).

## What's going on

These errors usually occur when two Linux package repositories provide .NET packages. While Microsoft provides a Linux package repository to source .NET packages, some Linux distributions also provide .NET packages, such as:

- Alpine Linux
- Arch
- CentOS
- CentOS Stream
- Fedora
- RHEL
- Ubuntu 22.04+

Mixing .NET packages from two different sources will most likely lead to issues since the packages may place things at different paths, and may be compiled differently.

## Solutions

The solution to these problems is to use .NET from one package repository. Which repository to pick, and how to do it, varies by use-case and the Linux distribution.

### My Linux distribution provides .NET packages, and I want to use them

::: zone pivot="os-linux-redhat"

- **Do you use the Microsoft repository for other packages, such as PowerShell and MSSQL?**

  - **Yes**

    Configure your package manager to ignore the .NET packages from the Microsoft repository. It's possible that you've installed .NET from both repositories, so you want to choose one or the other.

    01. Remove the existing .NET packages from your distribution. You want to start over and ensure that you don't install them from the wrong repository.

        ```bash
        sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
        ```

    01. Configure the Microsoft repository to ignore .NET packages.

        ```bash
        echo 'excludepkgs=dotnet*,aspnet*,netstandard*' | sudo tee -a /etc/yum.repos.d/microsoft-prod.repo
        ```

    01. Reinstall .NET from the distribution's package feed. For more information, see [Install .NET on Linux](linux.md).

  - **No**

    01. Remove the existing .NET packages from your distribution. You want to start over and ensure that you don't install them from the wrong repository.

        ```bash
        sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
        ```

    01. Delete the Microsoft repository feed from your distribution.

        ```bash
        sudo dnf remove packages-microsoft-prod
        ```

    01. Reinstall .NET from the distribution's package feed. For more information, see [Install .NET on Linux](linux.md).

::: zone-end

::: zone pivot="os-linux-ubuntu, os-linux-other"

- **Do you use the Microsoft repository for other packages, such as PowerShell and MSSQL?**

  - **Yes**

    Configure your package manager to ignore the .NET packages from the Microsoft repository. It's possible that you've installed .NET from both repositories, so you want to choose one or the other.

    01. Remove the existing .NET packages from your distribution. You want to start over and ensure that you don't install them from the wrong repository.

        ```bash
        sudo apt remove 'dotnet*' 'aspnet*' 'netstandard*'
        ```

    01. Create `/etc/apt/preferences`, if it doesn't already exist.

        ```bash
        touch /etc/apt/preferences
        ```

    01. Open `/etc/apt/preferences` in an editor and add the following settings, which prevents packages that start with `dotnet`, `aspnetcore`, or `netstandard` from being sourced from the Microsoft repository:

        ```bash
        Package: dotnet* aspnet* netstandard*
        Pin: origin "packages.microsoft.com"
        Pin-Priority: -10
        ```

    01. Reinstall .NET from the distribution's package feed. For more information, see [Install .NET on Linux](linux.md).

  - **No**

    01. Remove the existing .NET packages from your distribution. You want to start over and ensure that you don't install them from the wrong repository.

        ```bash
        sudo apt remove 'dotnet*' 'aspnet*' 'netstandard*'
        ```

    01. Delete the Microsoft repository feed from your distribution.

        ```bash
        sudo rm -f /etc/apt/sources.list.d/microsoft-prod.list
        sudo apt update
        ```

    01. Reinstall .NET from the distribution's package feed. For more information, see [Install .NET on Linux](linux.md).

::: zone-end

### I need a version of .NET that isn't provided by my Linux distribution

::: zone pivot="os-linux-redhat"

Configure your package manager to ignore the .NET packages from the distribution's repository. It's possible that you've installed .NET from both repositories, so you want to choose one or the other.

01. Remove the existing .NET packages from your distribution. You want to start over and ensure that you don't install them from the wrong repository.

    ```bash
    sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
    ```

01. Configure the Microsoft repository to ignore .NET packages.

    ```bash
    echo 'excludepkgs=dotnet*,aspnet*,netstandard*' | sudo tee -a /etc/yum.repos.d/ <TODO>WHAT IS THE REPO NAME HERE??</TODO> 
    ```

01. Reinstall .NET from the distribution's package feed. For more information, see [Install .NET on Linux](linux.md).

::: zone-end

::: zone pivot="os-linux-ubuntu, os-linux-other"

Configure your package manager to ignore the .NET packages from the distribution's repository. It's possible that you've installed .NET from both repositories, so you want to choose one or the other.

01. Remove the existing .NET packages from your distribution. You want to start over and ensure that you don't install them from the wrong repository.

    ```bash
    sudo apt remove 'dotnet*' 'aspnet*' 'netstandard*'
    ```

01. Create `/etc/apt/preferences`, if it doesn't already exist.

    ```bash
    touch /etc/apt/preferences
    ```

01. Open `/etc/apt/preferences` in an editor and add the following settings, which prevents packages that start with `dotnet`, `aspnetcore`, or `netstandard` from being sourced from the distribution's repository. Make sure to replace `archive.ubuntu.com` with your distribution's package source.

    ```bash
    Package: dotnet* aspnet* netstandard*
    Pin: origin "archive.ubuntu.com"
    Pin-Priority: -10
    ```

01. Reinstall .NET from the Microsoft package feed. For more information, see [Install .NET on Linux](linux.md). If using Ubuntu, see [My Ubuntu distribution doesn't include the .NET version I want, or I need an out-of-support .NET version](linux-ubuntu.md#my-ubuntu-distribution-doesnt-include-the-net-version-i-want-or-i-need-an-out-of-support-net-version).

::: zone-end

## Online references

Many other users have reported these problems. The following is a list of those issues. You can read through them for insights on what may be happening:

- System.IO.FileNotFoundException and '/usr/share/dotnet/packs/Microsoft.NETCore.App.Ref/5.0.0/data/FrameworkList.xml'

  - [SDK #15785: unable to build brand new project after upgrading to 5.0.3](https://github.com/dotnet/sdk/issues/15785)
  - [SDK #15863: "MSB4018 ResolveTargetingPackAssets task failed unexpectedly" after updating to 5.0.103](https://github.com/dotnet/sdk/issues/15863)
  - [SDK #17411: dotnet build always throwing error](https://github.com/dotnet/sdk/issues/17411)
  - [SDK #12075: dotnet 3.1.301 on Fedora 32 unable to find FrameworkList.xml because it doesn't exist](https://github.com/dotnet/sdk/issues/12075)

- Fatal error: _libhostfxr.so_ couldn't be found

  - [SDK #17570: After updating Fedora 33 to 34 and dotnet 5.0.5 to 5.0.6 I get error regarding libhostfxr.so](https://github.com/dotnet/sdk/issues/17570):

- Fatal error: folder _/host/fxr_ doesn't exist

  - [Core #5746: The folder does not exist when installing 3.1 on CentOS 8 with packages.microsoft.com repo enabled](https://github.com/dotnet/core/issues/5746)
  - [SDK #15476: A fatal error occurred. The folder [/usr/share/dotnet/host/fxr] does not exist](https://github.com/dotnet/sdk/issues/15476):

- Fatal error: folder _/host/fxr_ doesn't contain any version-numbered child folders

  - [Installer #9254: Error when install dotnet/core/aspnet:3.1 on CentOS 8 - Folder does not contain any version-numbered child folders](https://github.com/dotnet/installer/issues/9254)
  - [StackOverflow: Error when install dotnet/core/aspnet:3.1 on CentOS 8 - Folder does not contain any version-numbered child folders](https://stackoverflow.com/questions/65422998/)

- Generic errors without clear messages

  - [Core #4605: cannot run "dotnet new console"](https://github.com/dotnet/core/issues/4605)
  - [Core #4644: Cannot install .NET Core SDK 2.1 on Fedora 32](https://github.com/dotnet/core/issues/4655)
  - [Runtime #49375: After updating to 5.0.200-1 using package manager, it appears that no sdks are installed](https://github.com/dotnet/runtime/issues/49375)

## See also

- [How to check that .NET is already installed](how-to-detect-installed-versions.md?pivots=os-linux)
- [Install .NET on Linux](linux.md)
- [How to remove the .NET Runtime and SDK](remove-runtime-sdk-versions.md?pivots=os-linux)

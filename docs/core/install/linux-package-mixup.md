---
title: Troubleshoot .NET package mix ups on Linux
description: Learn about how to troubleshoot strange .NET package errors on Linux. These errors may occur when you run the dotnet command.
author: omajid
ms.date: 12/21/2022
no-loc: ['usr','lib64','share','dotnet','libhostfxr.so', 'fxr', 'FrameworkList.xml', 'System.IO.FileNotFoundException']
---

# Troubleshoot .NET errors related to missing files on Linux

When you try to use .NET on Linux, commands such as `dotnet new` and `dotnet run` may fail with a message related to a file not being found, such as _fxr_, _libhostfxr.so_, or _FrameworkList.xml_. Some of the error messages may be similar to the following:

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

## What's going on

This generally happens when two Linux package repositories provide .NET packages. While Microsoft provides a Linux package repository to source .NET packages, some Linux distributions also provide .NET packages, such as:

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

If your distribution provides .NET packages, it's recommended that you use that package repository instead of Microsoft's.

01. **I only use .NET and no other packages from the Microsoft repository, and my distribution provides .NET packages.**

    If you only use the Microsoft repository for .NET packages and not for any other Microsoft package such as `mdatp`, `powershell`, or `mssql`, then:

    01. Remove the .NET related packages from your OS.
    01. Remove the Microsoft repository.
    01. Install the .NET packages from the distribution repository.

    For Fedora, CentOS 8+, RHEL 8+, use the following bash commands:

    ```bash
    sudo dnf remove packages-microsoft-prod
    sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
    sudo dnf install dotnet-sdk-7.0
    ```

    For Ubuntu (or any other apt-based distribution) use the following bash commands

    ```bash
    sudo apt remove 'dotnet*' 'aspnet*' 'netstandard*'
    sudo rm /etc/apt/sources.list.d/microsoft-prod.list
    sudo apt update
    sudo apt install dotnet-sdk-7.0
    ```

02. **I want to use the distribution provided .NET packages, but I also use the Microsoft repository for other packages.**

    If you use the Microsoft repository for Microsoft packages such as `mdatp`, `powershell`, or `mssql`, but you don't want to use the repository for .NET, then:

    01. Remove the .NET related packages from your OS.
    01. Configure the Microsoft repository to exclude any .NET package.
    01. Install the .NET packages from the distribution repository.

    For Fedora, CentOS 8+, RHEL 8+, use the following bash commands:

    ```bash
    echo 'excludepkgs=dotnet*,aspnet*,netstandard*' | sudo tee -a /etc/yum.repos.d/microsoft-prod.repo
    sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
    sudo dnf install dotnet-sdk-7.0
    ```

    For Ubuntu (or any other distribution that uses apt):

    01. Remove the .NET packages if you previously installed them. For more information, see scenario #1.
    01. Create `/etc/apt/preferences` if it doesn't already exist.
    01. Add the following config to the preferences file, which prevents packages that start with `dotnet` or `aspnetcore` from being sourced by the Microsoft feed:

        ```bash
        Package: dotnet* aspnet* netstandard*
        Pin: origin "packages.microsoft.com"
        Pin-Priority: -10
        ```

    01. Install .NET.

        ```bash
        sudo apt-get update && sudo apt-get install -y dotnet7
        ```

03. **I need a recent version of .NET that's not provided by the Linux distribution repositories.**<a name="pin_ms"></a>

    In this case, keep the Microsoft repository, but configure it so .NET packages from the Microsoft repository are considered a higher priority. Then, remove the already-installed .NET packages and then re-install the .NET packages from the Microsoft repository.
  
    For Fedora, CentOS 8+, RHEL 8+, use the following bash commands:

    ```bash
    echo 'priority=50' | sudo tee -a /etc/yum.repos.d/microsoft-prod.repo
    sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
    sudo dnf install dotnet-sdk-7.0
    ```

    For Ubuntu (or any other distribution that uses apt) make sure you've installed the Microsoft repository feeds and then install the package.

    01. Remove the .NET packages if you previously installed them. For more information, see scenario #1.
    01. Create `/etc/apt/preferences` if it doesn't already exist.
    01. Add the following config to the preferences file, adding the specific package you want to pin as a high priority, which will be sourced by the Microsoft Feed. For example, use the following example to pin .NET SDK 7.0:

        ```bash
        Package: dotnet-sdk-7.0
        Pin: origin "packages.microsoft.com"
        Pin-Priority: 999
        ```

    01. Install .NET.

        ```bash
        sudo apt-get update && sudo apt-get install -y dotnet-sdk-7.0
        ```

04. **I've encountered a bug in the Linux distribution version of .NET, I need the latest Microsoft version.**

    Use solution 3 to solve this problem.

## Online references

Many of these problems have been reported by users such as yourself. The following is a list of those issues. You can read through them for insights on what may be happening:

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

## Next steps

- [Install .NET on Linux](linux.md)
- [How to remove the .NET Runtime and SDK](remove-runtime-sdk-versions.md?pivots=os-linux)
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).

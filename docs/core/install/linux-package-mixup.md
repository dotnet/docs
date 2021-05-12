---
title: Troubleshoot Package Mixup
description: Learn about how to troubleshoot strange .NET packae errors on Linux.
author: omajid
ms.date: 05/12/2021
---

# Troubleshoot `fxr`, `libhostfxr.so` or `FrameworkList.xml` errors

Users trying to use .NET and .NET Core may run into .NET commands (`dotnet new`, `dotnet build`, `dotnet run`) failing. The exact error messages can vary. Some example error messages:

- [SDK #12075](https://github.com/dotnet/sdk/issues/12075), [SDK #15785](https://github.com/dotnet/sdk/issues/15785), [SDK #15863](https://github.com/dotnet/sdk/issues/15863) and [SDK #17411](https://github.com/dotnet/sdk/issues/17411):

  ```
  System.IO.FileNotFoundException: Could not find file '/usr/share/dotnet/packs/Microsoft.NETCore.App.Ref/5.0.0/data/FrameworkList.xml'.`
  ```

- [SDK #17570](https://github.com/dotnet/sdk/issues/17570):

  ```
  A fatal error occurred. The required library libhostfxr.so could not be found.
  ```

- [Core #5746](https://github.com/dotnet/core/issues/5746) and [SDK #15476](https://github.com/dotnet/sdk/issues/15476):

  ```
  A fatal error occurred. The folder [/usr/share/dotnet/host/fxr] does not exist
  ```

- [Installer #9254](https://github.com/dotnet/installer/issues/9254) and [StackOverflow](https://stackoverflow.com/questions/65422998/):

  ```
  A fatal error occurred, the folder [/usr/share/dotnet/host/fxr] does not contain any version-numbered child folders
  ```

And some symptoms without clear error messages:

- [Core #4605](https://github.com/dotnet/core/issues/4605), [Core #4644](https://github.com/dotnet/core/issues/4655) and [Runtime #49375](https://github.com/dotnet/runtime/issues/49375):

  SDK is installed, but `dotnet` complains it isn't.

Another common symptom of this problem is that you have both `/usr/lib64/dotnet` and `/usr/share/dotnet` on your machine.

## What's going on?

This generally happens when two Linux package repositories provide .NET packages. Often .NET packages are provided by the Linux distribution (eg, Arch, CentOS, Fedora, RHEL), in addition to Microsoft.

Mixing .NET packages from two different sources will most likely lead to issues since they packages may place things at different paths, and may be compiled differently.

## Some fixes

The fix is to use .NET from one package repository only. Which repository to pick and how to do it varies by use-case and the Linux distribution.

The first fix is probably the simplest (and best in the very long term) but there are some known issues that may lead to better outcomes for the user right now if they pick another option.

**Use case 1**: I only want to install/use .NET. I dont want to use any other packages - such as `mdatp`, `powershell` and `mssql` - from the Microsoft repository.

In this case, remove the Microsoft repository, the .NET packages and then re-install the .NET packages from the Linux distribution repository.

For Fedora, CentOS >= 8, and RHEL >=8:

```bash
sudo dnf remove package-microsoft-prod
sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
sudo dnf install dotnet-sdk-5.0
```

**Use case 2**: I want to install and use .NET but also need other packages from Microsoft's repository, such as `mdatp`, `powershell` or `mssql`.

In this case, keep the Microsoft repository, but configure it so that it doesn't provide any the .NET packages, remove the already-installed .NET packages and then re-install the .NET packages from the Linux distribution repository.

For Fedora, CentOS >= 8, and RHEL >=8:

```bash
echo 'excludepkgs=dotnet*,aspnet*,netstandard*' | sudo tee -a /etc/yum.repos.d/microsoft-prod.repo
sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
sudo dnf install dotnet-sdk-5.0
```

**Use case 3**: I need a recent version of .NET that's not available if I go with option 1 or 2.

In this case, keep the Microsoft repository, and configure it so .NET packages from the Microsoft repository are considered a higher priority. Then remove the already-installed .NET packages and then re-install the .NET packages from the Microsoft repository.

For Fedora, CentOS >= 8, and RHEL >=8:

```bash
echo 'priority=50' | sudo tee -a /etc/yum.repos.d/microsoft-prod.repo
sudo dnf remove 'dotnet*' 'aspnet*' 'netstandard*'
sudo dnf install dotnet-sdk-5.0
```

**Use case 4** I dont care about the vendor of .NET but the version of .NET from the Linux distribution has bugs that are showstoppers for me and those bugs are fixed in the Microsoft packages.

Follow the same steps as Use case 3.

## Next steps

- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).

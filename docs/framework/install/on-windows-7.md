---
title: Install the .NET Framework on Windows 7 SP1
description: Learn how to install the .NET Framework on Windows 7 SP1.
ms.date: 04/18/2019
---

# Install the .NET Framework on Windows 7 SP1 and Windows Server 2008 R2

The .NET Framework is required to run many applications on Windows. You can use the following instructions to install it. You may have arrived on this page after trying to run an application and seeing the following dialog on your machine.

![This application could not be started](./media/this-application-could-not-be-started.png)

These instructions will help you install the .NET Framework versions you need. [.NET Framework 4.8](https://github.com/Microsoft/dotnet/tree/master/releases/net48) is the latest version. It is supported on Windows 7 SP1 and Windows Server 2008 R2 and is included with [Windows 10 May 2019 Update](https://support.microsoft.com/help/4028685/windows-10-get-the-update) and later versions.

## .NET Framework 4.8

> [!div class="button"]
> [Download .NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)

[.NET Framework 4.8](https://github.com/Microsoft/dotnet/tree/master/releases/net48) can be used to run applications built for .NET Framework 4.0 or later.

### Offline installer

When doing an offline install for .NET Framework on Windows 7, you'll first need to make sure that the latest [Microsoft Root Certificate Authority 2011](https://www.microsoft.com/pkiops/Docs/Repository.htm) has been installed on the target machine.

The _certmgr.exe_ tool can automate installing a certificate and is obtained from Visual Studio or the Windows SDK. The following command is used to install the certificate before running the .NET Framework installer:

```console
certmgr.exe /add MicRooCerAut2011_2011_03_22.crt /s /r localMachine root
```

## .NET Framework 3.5

The [.NET Framework 3.5](https://dotnet.microsoft.com/download/dotnet-framework/net35-sp1) is included with Windows 7.

The .NET Framework 3.5 supports apps built for .NET Framework 1.0 through 3.5.

## Help

You can [contact Microsoft for help](mailto:dotnet-install-help@service.microsoft.com?subject=Install-Help) if you cannot get the correct version of the .NET Framework installed.

## See also

- [Download the .NET Framework](https://dotnet.microsoft.com/download)
- [Troubleshoot blocked .NET Framework installations and uninstallations](troubleshoot-blocked-installations-and-uninstallations.md)
- [Install the .NET Framework for developers](guide-for-developers.md)

---
title: Install the .NET Framework on Windows 10
description: Learn how to install the .NET Framework on Windows 10 or Windows Server 2016.
ms.date: 05/11/2021
---
# Install the .NET Framework on Windows 10 and Windows Server 2016 and later

The .NET Framework is required to run many applications on Windows. The instructions in this article should help you install the .NET Framework versions that you need. The [.NET Framework 4.8](https://github.com/Microsoft/dotnet/tree/master/releases/net48) is the latest available version.

You may have arrived on this page after trying to run an application and seeing a dialog on your machine similar to the following one:

![This application could not be started](./media/this-application-could-not-be-started.png)

## .NET Framework 4.8

.NET Framework 4.8 is included with:

- [Windows 10 October 2020 Update](/windows/whats-new/whats-new-windows-10-version-20h2)
- [Windows 10 May 2020 Update](/windows/whats-new/whats-new-windows-10-version-2004)
- [Windows 10 November 2019 Update](/windows/whats-new/whats-new-windows-10-version-1909)
- [Windows 10 May 2019 Update](/windows/whats-new/whats-new-windows-10-version-1903)

> [!div class="button"]
> [Download .NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)

[.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48) can be used to run applications built for the .NET Framework 4.0 through 4.7.2.

You can install [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48) on:

- Windows 10 October 2018 Update (version 1809)
- Windows 10 April 2018 Update (version 1803)
- Windows 10 Fall Creators Update (version 1709)
- Windows 10 Creators Update (version 1703)
- Windows 10 Anniversary Update (version 1607)
- Windows Server 2019
- Windows Server, version 1809
- Windows Server, version 1803
- Windows Server 2016

The .NET Framework 4.8 is not supported on:

- Windows 10 1507
- Windows 10 1511

If you're using Windows 10 1507 or 1511 and you want to install the .NET Framework 4.8, you first need to upgrade to a later Windows 10 version.

## .NET Framework 4.6.2

The [.NET Framework 4.6.2](https://dotnet.microsoft.com/download/dotnet-framework/net462) is the latest supported .NET Framework version on Windows 10 1507 and 1511.

The .NET Framework 4.6.2 supports apps built for the .NET Framework 4.0 through 4.6.2.

## .NET Framework 3.5

Follow the instructions to install the [.NET Framework 3.5 on Windows 10](dotnet-35-windows-10.md).

The .NET Framework 3.5 supports apps built for the .NET Framework 1.0 through 3.5.

## Additional information

.NET Framework 4.x versions are in-place updates to earlier versions. That means the following:

- You can only have one version of the .NET Framework 4.x installed on your machine.

- You cannot install an earlier version of the .NET Framework on your machine if a later version is already installed.

- 4.x versions of the .NET Framework can be used to run applications built for the .NET Framework 4.0 through that version. For example, .NET Framework 4.7 can be used to run applications built for the .NET Framework 4.0 through 4.7. The latest version (the .NET Framework 4.8) can be used to run applications built with all versions of the .NET Framework starting with 4.0.

For a list of all the versions of the .NET Framework available to download, see the [.NET Downloads](https://dotnet.microsoft.com/download) page.

## Help

If you cannot get the correct version of the .NET Framework installed, you can [contact Microsoft for help](mailto:dotnet-install-help@service.microsoft.com?subject=Install-Help).

## See also

- [.NET Downloads](https://dotnet.microsoft.com/download)
- [Troubleshoot blocked .NET Framework installations and uninstallations](troubleshoot-blocked-installations-and-uninstallations.md)
- [Install the .NET Framework for developers](guide-for-developers.md)
- [Determine which .NET Framework versions are installed](../migration-guide/how-to-determine-which-versions-are-installed.md)

---
title: Check installed .NET versions on Windows, Linux, and macOS
description: Learn how to list which versions of .NET are installed on your computer. This includes the .NET runtime and SDK.
author: adegeo
ms.author: adegeo
ms.date: 11/08/2022
ms.custom: "updateeachrelease"
zone_pivot_groups: operating-systems-set-one
---

# How to check that .NET is already installed

This article teaches you how to check which versions of the .NET runtime and SDK are installed on your computer. If you have an integrated development environment, such as Visual Studio, .NET may have already been installed.

Installing an SDK installs the corresponding runtime.

If any command in this article fails, you don't have the runtime or SDK installed. For more information, see the install articles for [Windows](windows.md), [macOS](macos.md), or [Linux](linux.md).

## Check SDK versions

You can see which versions of the .NET SDK are currently installed with a terminal. Open a terminal and run the following command.

```dotnetcli
dotnet --list-sdks
```

You get output similar to the following.

::: zone pivot="os-windows"

```console
3.1.424 [C:\program files\dotnet\sdk]
5.0.100 [C:\program files\dotnet\sdk]
6.0.402 [C:\program files\dotnet\sdk]
7.0.100 [C:\program files\dotnet\sdk]
```

::: zone-end

::: zone pivot="os-linux"

```bash
3.1.424 [/home/user/dotnet/sdk]
5.0.100 [/home/user/dotnet/sdk]
6.0.402 [/home/user/dotnet/sdk]
7.0.100 [/home/user/dotnet/sdk]
```

::: zone-end

::: zone pivot="os-macos"

```bash
3.1.424 [/usr/local/share/dotnet/sdk]
5.0.100 [/usr/local/share/dotnet/sdk]
6.0.402 [/usr/local/share/dotnet/sdk]
7.0.100 [/usr/local/share/dotnet/sdk]
```

::: zone-end

## Check runtime versions

You can see which versions of the .NET runtime are currently installed with the following command.

```dotnetcli
dotnet --list-runtimes
```

You get output similar to the following.

::: zone pivot="os-windows"

```console
Microsoft.AspNetCore.App 3.1.30 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 6.0.10 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 7.0.0 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
Microsoft.NETCore.App 3.1.30 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
Microsoft.NETCore.App 5.0.17 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
Microsoft.NETCore.App 6.0.10 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
Microsoft.NETCore.App 7.0.0 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
Microsoft.WindowsDesktop.App 3.1.30 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
Microsoft.WindowsDesktop.App 6.0.10 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
Microsoft.WindowsDesktop.App 7.0.0 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
```

::: zone-end

::: zone pivot="os-linux"

```bash
Microsoft.AspNetCore.All 2.1.7 [/home/user/dotnet/shared/Microsoft.AspNetCore.All]
Microsoft.AspNetCore.All 2.1.13 [/home/user/dotnet/shared/Microsoft.AspNetCore.All]
Microsoft.AspNetCore.App 2.1.7 [/home/user/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 2.1.13 [/home/user/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 3.1.0 [/home/user/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 5.0.0 [/home/user/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 6.0.0 [/home/user/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.NETCore.App 2.1.7 [/home/user/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 2.1.13 [/home/user/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 3.1.0 [/home/user/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 5.0.0 [/home/user/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 6.0.0 [/home/user/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 7.0.0 [/home/user/dotnet/shared/Microsoft.NETCore.App]
```

::: zone-end

::: zone pivot="os-macos"

```bash
Microsoft.AspNetCore.All 2.1.7 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.All]
Microsoft.AspNetCore.All 2.1.13 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.All]
Microsoft.AspNetCore.App 2.1.7 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 2.1.13 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 3.1.0 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 5.0.0 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 6.0.0 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.NETCore.App 2.1.7 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 2.1.13 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 3.1.0 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 5.0.0 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 6.0.0 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 7.0.0 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
```

::: zone-end

## Check for install folders

It's possible that .NET is installed but not added to the `PATH` variable for your operating system or user profile. In this case, the commands from the previous sections may not work. As an alternative, you can check that the .NET install folders exist.

When you install .NET from an installer or script, it's installed to a standard folder. Much of the time the installer or script you're using to install .NET gives you an option to install to a different folder. If you choose to install to a different folder, adjust the start of the folder path.

::: zone pivot="os-windows"

- **dotnet executable**\
_C:\\program files\\dotnet\\dotnet.exe_

- **.NET SDK**\
_C:\\program files\\dotnet\\sdk\\{version}\\_

- **.NET Runtime**\
_C:\\program files\\dotnet\\shared\\{runtime-type}\\{version}\\_

::: zone-end

::: zone pivot="os-linux"

- **dotnet executable**\
_/home/user/share/dotnet/dotnet_

- **.NET SDK**\
_/home/user/share/dotnet/sdk/{version}/_

- **.NET Runtime**\
_/home/user/share/dotnet/shared/{runtime-type}/{version}/_

::: zone-end

::: zone pivot="os-macos"

- **dotnet executable**\
_/usr/local/share/dotnet/dotnet_

- **.NET SDK**\
_/usr/local/share/dotnet/sdk/{version}/_

- **.NET Runtime**\
_/usr/local/share/dotnet/shared/{runtime-type}/{version}/_

::: zone-end

## More information

You can see both the SDK versions and runtime versions with the command `dotnet --info`. You'll also get other environmental related information, such as the operating system version and runtime identifier (RID).

## Next steps

- [Install the .NET Runtime and SDK for Windows](windows.md).
- [Install the .NET Runtime and SDK for macOS](macos.md).
- [Install the .NET Runtime and SDK for Linux](linux.md).

## See also

- [Determine which .NET Framework versions are installed](../../framework/migration-guide/how-to-determine-which-versions-are-installed.md)

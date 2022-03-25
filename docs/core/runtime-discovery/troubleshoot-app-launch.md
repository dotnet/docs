---
title: Troubleshoot app launch failures
description: Learn about common reasons for app launch failures and possible solutions.
ms.topic: troubleshooting
ms.date: 03/24/2022
zone_pivot_groups: operating-systems-set-one
---

# Troubleshoot app launch failures

This article describes some common reasons and possible solutions for application launch failures.

## Required framework not found

[Framework-dependent applications](../deploying/index.md#publish-framework-dependent) rely on a .NET installation on your machine. If a required framework is not found or is not compatible with the required version, the application will fail to launch with a message similar to:

::: zone pivot="os-windows"

```console
You must install or update .NET to run this application.

App: C:\repos\myapp\myapp.exe
Architecture: x64
Framework: 'Microsoft.NETCore.App', version '5.0.15' (x64)
.NET location: C:\Program Files\dotnet\

The following frameworks were found:
  6.0.2 at [c:\Program Files\dotnet\shared\Microsoft.NETCore.App]
```

::: zone-end

::: zone pivot="os-linux"

```bash
You must install or update .NET to run this application.

App: /home/user/repos/myapp/myapp
Architecture: x64
Framework: 'Microsoft.NETCore.App', version '5.0.15' (x64)
.NET location: /usr/share/dotnet/

The following frameworks were found:
  6.0.2 at [/usr/share/dotnet/shared/Microsoft.NETCore.App]
```

::: zone-end

::: zone pivot="os-macos"

```bash
You must install or update .NET to run this application.

App: /home/user/repos/myapp/myapp
Architecture: x64
Framework: 'Microsoft.NETCore.App', version '5.0.15' (x64)
.NET location: /usr/local/share/dotnet/

The following frameworks were found:
  6.0.2 at [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
```

::: zone-end

The error indicates the name, version, and architecture of the missing framework and the location at which it is expected to be installed. In order to run the application, you can [install a compatible framework](#install-a-compatible-framework) at the specified ".NET location". If the application is targeting a lower version than one you have installed and you would like to run it on a higher version, you can also [configure roll-forward behavior](#configure-roll-forward-behavior) for the application.

### Install a compatible framework

The error message includes a link to download the missing framework. You can follow this link to get the appropriate download page. Alternately, the [.NET downloads](https://dotnet.microsoft.com/download/dotnet) page offers all available versions of .NET. Select the version matching the one listed in the error message.

Every version of .NET offers three different runtime downloads. The table below shows the frameworks contained by each of them.

| Download name        | Included frameworks |
| -------------------- | ------------------- |
| ASP.NET Core Runtime | Microsoft.NETCore.App<br/>Microsoft.AspNetCore.App |
| .NET Desktop Runtime | Microsoft.NETCore.App<br/>Microsoft.WindowsDesktop.App |
| .NET Runtime         | Microsoft.NETCore.App |

To install a compatible framework, on the download page for the required .NET version, find a runtime download containing the missing framework. Once you have found the appropriate runtime download, you can then either install it using an [installer](#run-an-installer) or [download the binaries](#download-binaries) and extract them to the desired location.

#### Run an installer

If your existing installation of .NET was installed through an installer or package manager, then also installing the required framework through an installer or package manager is likely the simpler option. Otherwise, you can [download binaries](#download-binaries) instead of using an installer.

In most cases, when the application that failed to launch is using such an installation, the ".NET location" in the error message would point to:
::: zone pivot="os-windows"
`%ProgramFiles%\dotnet`
::: zone-end
::: zone pivot="os-linux"
`/usr/share/dotnet/`
::: zone-end
::: zone pivot="os-macos"
`/usr/local/share/dotnet/`
::: zone-end

::: zone pivot="os-windows,os-macos"
From the **Installers** column of the runtime download, download the installer matching the required architecture. Run the downloaded installer.
::: zone-end
::: zone pivot="os-linux"
Different Linux distributions provide .NET through different package managers. See [Install .NET on Linux](../install/linux.md) for details. Note that preview versions of .NET are not available through package managers.
::: zone-end

#### Download binaries

From the **Binaries** column of the runtime download, download the binary release matching the required architecture. Extract the downloaded archive to the ".NET location" specified in the error message.

::: zone pivot="os-windows"
For more details on manual installation, see [Install .NET on Windows](../install/windows.md#download-and-manually-install)
::: zone-end

::: zone pivot="os-linux"
For more details on manual installation, see [Install .NET on Linux](../install/linux.md#manual-installation)
::: zone-end

::: zone pivot="os-macos"
For more details on manual installation, see [Install .NET on macOS](../install/macos.md#download-and-manually-install)
::: zone-end

### Configure roll-forward behavior

If you already have a higher version of the required framework installed, you can make the application ron on that higher version by configuring its roll-forward behavior.

When running the application, you can specify the [`--roll-forward` command line option](../tools/dotnet.md#runtime-options) or setting the [`DOTNET_ROLL_FORWARD` environment variable](../tools/dotnet-environment-variables.md#dotnet_roll_forward).
By default, an application will require a framework matching the same major version that the application targets, but can use a higher minor or patch version. However, application developers may have specified a different behavior. For more details, see [Framework-dependent apps roll-forward](../versions/selection.md#framework-dependent-apps-roll-forward).

Note that, since using this option can let the application run on a different framework version than the one for which it was designed, it may result in unintended behavior in the application due to changes between versions of a framework.

::: zone pivot="os-windows"

## Breaking changes

### Multi-level lookup disabled for .NET 7.0 and later

On Windows, before .NET 7.0, the application could search for frameworks in multiple [install locations](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md).

1. Subdirectories relative to:

    - `dotnet` executable when running the application through `dotnet`
    - `DOTNET_ROOT` environment variable (if set) when running the application through its executable (`apphost`)

2. Globally registered install location (if set) in `HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\<arch>\InstallLocation`
3. Default install location of `%ProgramFiles%\dotnet` (or `%ProgramFiles(x86)%\dotnet` for 32-bit processes on 64-bit Windows)

This behavior&mdash;multi-level lookup&mdash;was enabled by default, but could be disabled by setting the environment variable `DOTNET_MULTILEVEL_LOOKUP=0`.

For applications targeting .NET 7.0 and later, multi-level lookup is completely disabled and only one location&mdash;the first location where a .NET installation is found&mdash;is searched. When running an application through `dotnet`, frameworks are only searched for in subdirectories relative to `dotnet`. When running an application through its executable (`apphost`), frameworks are only searched for in the first of the above locations where .NET is found.

For more details, see [Disable multi-level lookup by default](https://github.com/dotnet/designs/blob/main/accepted/2022/disable-multi-level-lookup-by-default.md).

::: zone-end

## See also

- [Install .NET](../install/index.yml)
- [.NET install locations](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md)
- [Check installed .NET versions](../install/how-to-detect-installed-versions.md)
- [Framework-dependent applications](../deploying/index.md#publish-framework-dependent)

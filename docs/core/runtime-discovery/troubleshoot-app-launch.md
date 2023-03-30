---
title: Troubleshoot app launch failures
description: Learn about common reasons for app launch failures and possible solutions.
ms.topic: troubleshooting
ms.date: 03/29/2023
zone_pivot_groups: operating-systems-set-one
---

# Troubleshoot app launch failures

This article describes some common reasons and possible solutions for application launch failures. It relates to [framework-dependent applications](../deploying/index.md#publish-framework-dependent), which rely on a .NET installation on your machine.

If you already know which .NET version you need, you can download it from [.NET downloads](https://dotnet.microsoft.com/download/dotnet).

## .NET installation not found

If a .NET installation isn't found, the application fails to launch with a message similar to:

::: zone pivot="os-windows"

```console
You must install .NET to run this application.

App: C:\repos\myapp\myapp.exe
Architecture: x64
Host version: 7.0.0
.NET location: Not found
```

::: zone-end

::: zone pivot="os-linux"

```bash
You must install .NET to run this application.

App: /home/user/repos/myapp/myapp
Architecture: x64
Host version: 7.0.0
.NET location: Not found
```

This may be due to a [package mix-up](../install/linux-package-mixup.md).

Global installs are registered in the following location: `/etc/dotnet/install_location`. For more information, see [install locations](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md).
::: zone-end

::: zone pivot="os-macos"

```bash
You must install .NET to run this application.

App: /home/user/repos/myapp/myapp
Architecture: x64
Host version: 7.0.0
.NET location: Not found
```

Global installs are registered in the following location: `/etc/dotnet/install_location`. For more information, see [install locations](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md).
::: zone-end

The error message includes a link to download .NET. You can follow that link to get to the appropriate download page. You can also pick the .NET version (specified by `Host version`) from [.NET downloads](https://dotnet.microsoft.com/download/dotnet).

::: zone pivot="os-windows,os-macos"
On the [download page](https://dotnet.microsoft.com/download/dotnet) for the required .NET version, find the **.NET Runtime** download that matches the architecture listed in the error message. You can then install it by downloading and running an **Installer**.
::: zone-end

::: zone pivot="os-linux"
.NET is available through various Linux package managers. For more information, see [Install .NET on Linux](../install/linux.md). (Preview versions of .NET aren't typically available through package managers.)

You need to install the .NET Runtime package for the appropriate version, like `dotnet-runtime6`.
::: zone-end

Alternatively, on the [download page](https://dotnet.microsoft.com/download/dotnet) for the required .NET version, you can download [**Binaries**](#download-binaries) for the specified architecture.

## Required framework not found

If a required framework or compatible version isn't found, the application fails to launch with a message similar to:

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

The error indicates the name, version, and architecture of the missing framework and the location at which it's expected to be installed. To run the application, you can [install a compatible runtime](#install-a-compatible-runtime) at the specified ".NET location". If the application targets a lower version than one you have installed and you'd like to run it on a higher version, you can also [configure roll-forward behavior](#configure-roll-forward-behavior) for the application.

### Install a compatible runtime

The error message includes a link to download the missing framework. You can follow this link to get to the appropriate download page.

Alternately, you can download a runtime from the [.NET downloads](https://dotnet.microsoft.com/download/dotnet) page. There are multiple .NET runtime downloads.

The following table shows the frameworks that each runtime contains.

::: zone pivot="os-windows"
| Runtime download     | Included frameworks                                    |
| -------------------- | ------------------------------------------------------ |
| ASP.NET Core Runtime | Microsoft.NETCore.App<br/>Microsoft.AspNetCore.App     |
| .NET Desktop Runtime | Microsoft.NETCore.App<br/>Microsoft.WindowsDesktop.App |
| .NET Runtime         | Microsoft.NETCore.App                                  |
::: zone-end

::: zone pivot="os-linux,os-macos"
| Runtime download     | Included frameworks                                |
| -------------------- | -------------------------------------------------- |
| ASP.NET Core Runtime | Microsoft.NETCore.App<br/>Microsoft.AspNetCore.App |
| .NET Runtime         | Microsoft.NETCore.App                              |
::: zone-end

Select a runtime download that contains the missing framework, and then install it.

::: zone pivot="os-windows,os-macos"
On the [download page](https://dotnet.microsoft.com/download/dotnet) for the required .NET version, find the runtime download that matches the architecture listed in the error message. You likely want to download an **Installer**.
::: zone-end

::: zone pivot="os-linux"
.NET is available through various Linux package managers. See [Install .NET on Linux](../install/linux.md) for details. (Preview versions of .NET typically aren't available through package managers.)

You need to install the .NET runtime package for the appropriate version, like `dotnet-runtime6` or `dotnet-aspnet6`.
::: zone-end

Alternatively, on the [download page](https://dotnet.microsoft.com/download/dotnet) for the required .NET version, you can download [**Binaries**](#download-binaries) for the specified architecture.

In most cases, when the application that failed to launch is using such an installation, the ".NET location" in the error message points to:
::: zone pivot="os-windows"
`%ProgramFiles%\dotnet`
::: zone-end
::: zone pivot="os-linux"
`/usr/share/dotnet/`
::: zone-end
::: zone pivot="os-macos"
`/usr/local/share/dotnet/`
::: zone-end

## Other options

There are other installation and workaround options to consider.

### Run the dotnet-install script

Download the [dotnet-install script](../tools/dotnet-install-script.md#recommended-version) for your operating system. Run the script with options based on the information in the error message. The [dotnet-install script reference page](../tools/dotnet-install-script.md) shows all available options.

::: zone pivot="os-windows"
Launch [PowerShell](/powershell) and run:

```powershell
dotnet-install.ps1 -Architecture <architecture> -InstallDir <directory> -Runtime <runtime> -Version <version>
```

For example, the error message in the previous section would correspond to:

```powershell
dotnet-install.ps1 -Architecture x64 -InstallDir "C:\Program Files\dotnet\" -Runtime dotnet -Version 5.0.15
```

If you encounter an error stating that running scripts is disabled, you may need to set the [execution policy](/powershell/module/microsoft.powershell.core/about/about_execution_policies) to allow the script to run:

```powershell
Set-ExecutionPolicy Bypass -Scope Process
```

For more information on installation using the script, see [Install with PowerShell automation](../install/windows.md#install-with-powershell-automation).
::: zone-end

::: zone pivot="os-linux"

```bash
./dotnet-install.sh --architecture <architecture> --install-dir <directory> --runtime <runtime> --version <version>
```

For example, the error message in the previous section would correspond to:

```bash
./dotnet-install.sh --architecture x64 --install-dir /usr/share/dotnet/ --runtime dotnet --version 5.0.15
```

For more information on installation using the script, see [Scripted install](../install/linux-scripted-manual.md#scripted-install).
::: zone-end

::: zone pivot="os-macos"

```bash
./dotnet-install.sh --architecture <architecture> --install-dir <directory> --runtime <runtime> --version <version>
```

For example, the error message in the previous section would correspond to:

```bash
./dotnet-install.sh --architecture x64 --install-dir /usr/local/share/dotnet/ --runtime dotnet --version 5.0.15
```

For more information on installation using the script, see [Install with bash automation](../install/macos.md#install-with-bash-automation).
::: zone-end

### Download binaries

You can download a binary archive of .NET from the [download page](https://dotnet.microsoft.com/download/dotnet). From the **Binaries** column of the runtime download, download the binary release matching the required architecture. Extract the downloaded archive to the ".NET location" specified in the error message.

::: zone pivot="os-windows"
For more details on manual installation, see [Install .NET on Windows](../install/windows.md#install-with-powershell-automation)
::: zone-end

::: zone pivot="os-linux"
For more details on manual installation, see [Install .NET on Linux](../install/linux.md#manual-installation)
::: zone-end

::: zone pivot="os-macos"
For more details on manual installation, see [Install .NET on macOS](../install/macos.md#download-and-manually-install)
::: zone-end

### Configure roll-forward behavior

If you already have a higher version of the required framework installed, you can make the application run on that higher version by configuring its roll-forward behavior.

When running the application, you can specify the [`--roll-forward` command line option](../tools/dotnet.md#rollforward) or set the [`DOTNET_ROLL_FORWARD` environment variable](../tools/dotnet-environment-variables.md#dotnet_roll_forward).
By default, an application requires a framework that matches the same major version that the application targets, but can use a higher minor or patch version. However, application developers may have specified a different behavior. For more information, see [Framework-dependent apps roll-forward](../versions/selection.md#framework-dependent-apps-roll-forward).

> [!NOTE]
> Since using this option lets the application run on a different framework version than the one for which it was designed, it may result in unintended behavior due to changes between versions of a framework.

::: zone pivot="os-windows"

## Breaking changes

### Multi-level lookup disabled for .NET 7 and later

On Windows, before .NET 7, the application could search for frameworks in multiple [install locations](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md).

1. Subdirectories relative to:

   - `dotnet` executable when running the application through `dotnet`.
   - `DOTNET_ROOT` environment variable (if set) when running the application through its executable (`apphost`).

2. Globally registered install location (if set) in `HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\<arch>\InstallLocation`.
3. Default install location of `%ProgramFiles%\dotnet` (or `%ProgramFiles(x86)%\dotnet` for 32-bit processes on 64-bit Windows).

This multi-level lookup behavior was enabled by default but could be disabled by setting the environment variable `DOTNET_MULTILEVEL_LOOKUP=0`.

For applications targeting .NET 7 and later, multi-level lookup is completely disabled and only one location&mdash;the first location where a .NET installation is found&mdash;is searched. When an application is run through `dotnet`, frameworks are only searched for in subdirectories relative to `dotnet`. When an application is run through its executable (`apphost`), frameworks are only searched for in the first of the previously listed locations where .NET is found.

For more information, see [Multi-level lookup is disabled](../compatibility/deployment/7.0/multilevel-lookup.md).

::: zone-end

## See also

- [Install .NET](../install/index.yml)
- [.NET install locations](https://github.com/dotnet/designs/blob/main/accepted/2020/install-locations.md)
- [Check installed .NET versions](../install/how-to-detect-installed-versions.md)
- [Framework-dependent applications](../deploying/index.md#publish-framework-dependent)

---
title: Install .NET Core runtime on Windows, Linux, and macOS
description: Learn how to install .NET Core on Windows, Linux, and macOS. Discover the dependencies required to run .NET Core apps.
author: thraka
ms.author: adegeo
ms.date: 11/06/2019
ms.custom: "updateeachrelease"
zone_pivot_groups: operating-systems-set-one
---

# Install the .NET Core Runtime

In this article you'll learn how to download and install the .NET Core runtime. The .NET Core runtime is used to run apps created with .NET Core.

You can download and install .NET Core directly with one of the following links:

- [.NET Core 3.0 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.0).
- [.NET Core 2.2 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.2).
- [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1).

You can also install .NET Core as part of an integrated development environment (IDE) detailed in the sections below.

## Install with an installer

Both Windows and macOS have standalone installers which can be used to install the .NET Core runtime.

- Windows [x64 CPUs](https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-3.0.0-windows-x64-installer) | [x32 CPUs](https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-3.0.0-windows-x86-installer)
- macOS [x64 CPUs](https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-3.0.0-macos-x64-installer)

::: zone pivot="os-linux"

## Install with a package manager

You can install .NET Core with many of the common linux package managers. For more information, see [Linux Package Manager - Install .NET Core](linux-package-manager-rhel7.md).

::: zone-end

::: zone pivot="os-windows"

## Install with PowerShell automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for a automation and non-admin installs of the runtime. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is currently .NET Core 2.1. To install the current release of .NET Core (3.0), run the script with the following switch:

```powershell
dotnet-install.ps1 -Channel 3.0
```

::: zone-end

::: zone pivot="os-linux,os-macos"

## Install with bash automation

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and non-admin installs of the runtime. You can download the script from the [dotnet-install script reference page](../tools/dotnet-install-script.md).

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is currently .NET Core 2.1. To install the current release of .NET Core (3.0), run the script with the following switch:

```bash
./dotnet-install.sh -c Current
```

::: zone-end

## Docker

TODO

## Next steps

TODO

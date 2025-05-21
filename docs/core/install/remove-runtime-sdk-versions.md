---
title: Remove the .NET runtime and SDK
description: This article describes how to uninstall .NET on Windows, macOS, and Linux. Uninstall .NET manually, through a package manager, or with the .NET Uninstall Tool.
author: adegeo
ms.author: adegeo
ms.date: 11/11/2024
ms.custom: linux-related-content
zone_pivot_groups: operating-systems-set-one
ms.topic: how-to
---

# How to remove the .NET Runtime and SDK

Over time, as you install updated versions of the .NET runtime and SDK, you may want to remove outdated versions of .NET from your machine. Uninstalling older versions of the runtime may change the runtime chosen to run shared framework applications, as detailed in the article on [.NET version selection](../versions/selection.md).

## Should I remove a version?

The [.NET version selection](../versions/selection.md) behaviors and the runtime compatibility of .NET across updates enables safe removal of previous versions. .NET runtime updates are compatible within a major version **band** such as 8.x and 7.x. Additionally, newer releases of the .NET SDK generally maintain the ability to build applications that target previous versions of the runtime in a compatible manner.

In general, you only need the latest SDK and latest patch version of the runtimes required for your application. Instances where you might want to keep older SDK or runtime versions include maintaining *project.json*-based applications. Unless your application has specific reasons for earlier SDKs or runtimes, you may safely remove older versions.

## Determine what is installed

The .NET CLI has options you can use to list the versions of the SDK and runtime that are installed on your computer. Use [`dotnet --list-sdks`](../tools/dotnet.md#options) to see the list of installed SDKs and [`dotnet --list-runtimes`](../tools/dotnet.md#options) for the list of runtimes. For more information, see [How to check that .NET is already installed](how-to-detect-installed-versions.md).

## Uninstall .NET

::: zone pivot="os-windows"

.NET uses the Windows **Apps & features** or **Apps > Installed Apps** settings page to remove versions of the .NET runtime and SDK. Use the Start Menu to search for **Add or Remove Programs** to open the settings page, as illustrated by the following image: figure shows the **Apps & features** dialog. You can search for **core** or **.net** to filter and show installed versions of .NET.

:::image type="content" source="media/remove-runtime-sdk-versions/add-or-remove.png" alt-text="The Windows Start Menu showing the text Add or Remove to filter the search results":::

In the settings page, search for **.net** to find the versions installed on your machine. Select **...** > **Uninstall** to uninstall the item. If you're using Windows 10, select the **Uninstall** button for the item you want to uninstall. The following image shows the **Installed Apps** settings page on Windows 11:

:::image type="content" source="media/remove-runtime-sdk-versions/search-net-filter.png" alt-text="The Windows Installed Apps dialog with the word '.net' in the search bar. The results show versions of .NET Framework and .NET that are installed.":::

> [!IMPORTANT]
> If the item you're uninstalling indicates that it's from Visual Studio, use the Visual Studio Installer to remove those versions of .NET.

::: zone-end

::: zone pivot="os-linux"

The best way for you to uninstall .NET is to mirror the action you used to install .NET. The specifics depend on your chosen Linux distribution and the installation method.

Preview releases are manually installed, and must be manually uninstalled. For more information, see the [Scripted or manual](#scripted-or-manual) section.

> [!IMPORTANT]
> For Red Hat installations, consult the [Red Hat Product Documentation for .NET](https://access.redhat.com/documentation/en-us/net/6.0/).

You can remove the following types if .NET installations:

- [Package manager](#package-manager)
- [Manually or scripted installs](#scripted-or-manual)

### Package manager

There's no need to first uninstall the .NET SDK when upgrading it using a package manager, unless you're upgrading from a preview version that was manually installed. The package manager `update` or `refresh` commands will automatically remove the older version upon the successful installation of a newer version. If you have a preview version installed, uninstall it.

If you installed .NET using a package manager, use that same package manager to uninstall the .NET SDK or runtime. .NET installations support most popular package managers. Consult the documentation for your distribution's package manager for the precise syntax in your environment:

- [apt-get(8)](https://linux.die.net/man/8/apt-get) is used by Debian based systems, including Ubuntu.
- [yum(8)](https://linux.die.net/man/8/yum) is used on Fedora, CentOS Stream, Oracle Linux, and RHEL.
- [zypper(8)](https://en.opensuse.org/SDB:Zypper_manual_(plain)) is used on openSUSE and SUSE Linux Enterprise System (SLES).
- [dnf(8)](https://dnf.readthedocs.io/en/latest/command_ref.html) is used on Fedora.

In almost all cases, the command to remove a package is `remove`.

The package name for the .NET SDK installation for most package managers is `dotnet-sdk`, followed by the version number. Only the major and minor version numbers are necessary: for example, the .NET SDK version 8.0.200 can be referenced as the package `dotnet-sdk-8.0`.

For machines that have installed only the runtime, and not the SDK, the package name is `dotnet-runtime-<version>` for the .NET runtime, and `aspnetcore-runtime-<version>` for the entire runtime stack.

### Scripted or manual

If you installed .NET using the [dotnet-install script](linux-scripted-manual.md#scripted-install), or by [extracting a tarball](linux-scripted-manual.md#manual-install), you must remove .NET using the manual method.

When you manually install .NET, it's generally installed to the `/usr/share/dotnet/`, `/usr/lib/dotnet/`, or the `$HOME/.dotnet` directory. The SDK, runtime, and .NET host, are installed into separate sub directories. These "component" directories contain a directory for each version of .NET. By removing the versioned directories, you remove that version of .NET from your system. These directories may vary depending on your Linux distribution.

There are three commands you can use to discover where .NET is installed: `dotnet --list-sdks` for SDKs, `dotnet --list-runtimes` for runtimes, and `dotnet --info` for everything. These commands don't list the .NET host. To determine which hosts are installed, check the `/usr/share/dotnet/host/fxr/` directory. The following list represents the directories of a specific version of .NET, where the `$version` variable represents the version of the .NET:

- **SDK**:

  `/usr/share/dotnet/sdk/$version/`

- **Runtime**:

  The runtime is based on specific .NET product runtimes, such as `Microsoft.AspNetCore.All` or `Microsoft.NETCore.App` (the .NET runtime specifically). These are installed to the `/usr/share/dotnet/shared/$product/$version` directory, where `$product` is the product runtime. For example, you may see the following directories:

  ```
  /usr/share/dotnet/shared/Microsoft.NETCore.App/$version/
  /usr/share/dotnet/shared/Microsoft.AspNetCore.App/$version/
  /usr/share/dotnet/shared/Microsoft.AspNetCore.All/$version/
  ```

- **.NET host**

  `/usr/share/dotnet/host/fxr/$version/`

Use the `rm -rf` command to remove a version of .NET. For example, to remove the 6.0.406 SDK, run the following command:

```bash
sudo rm -rf /usr/share/dotnet/sdk/6.0.406
```

> [!IMPORTANT]
> The version directories might not match the "version" you're uninstalling. The individual runtimes and SDKs that are installed with a single .NET release might have different versions. For example, you might have installed ASP.NET Core 8 Runtime, which installed the 8.0.2 ASP.NET Core runtime and the 8.0.8 .NET runtime. Each has a different versioned directory. For more information, see [Overview of how .NET is versioned](../versions/index.md).

::: zone-end

::: zone pivot="os-macos"

When you manually install .NET, it's generally installed to the `/usr/local/share/dotnet/` or the `$HOME/.dotnet` directory. The SDK, runtime, and .NET host are installed into separate sub directories. These "component" directories contain a directory for each version of .NET. By removing the versioned directories, you remove that version of .NET from your system. These directories may vary depending on your macOS version.

There are three commands you can use to discover where .NET is installed: `dotnet --list-sdks` for SDKs, `dotnet --list-runtimes` for runtimes, and `dotnet --info` for everything. These commands don't list the .NET host. To determine which hosts are installed, check the `/usr/local/share/dotnet/host/fxr/` directory. The following list represents the directories of a specific version of .NET, where the `$version` variable represents the version of the .NET:

- **SDK**:

  `/usr/local/share/dotnet/sdk/$version/`

- **Runtime**:

  The runtime is based on specific .NET product runtimes, such as `Microsoft.AspNetCore.All` or `Microsoft.NETCore.App` (the .NET runtime specifically). These are installed to the `/usr/local/share/dotnet/shared/$product/$version` directory, where `$product` is the product runtime. For example, you might see the following directories:

  ```
  /usr/local/share/dotnet/shared/Microsoft.NETCore.App/$version/dotnet --info
  /usr/local/share/dotnet/shared/Microsoft.AspNetCore.App/$version/
  /usr/local/share/dotnet/shared/Microsoft.AspNetCore.All/$version/
  ```

- **.NET host**

  `/usr/local/share/dotnet/host/fxr/$version/`

Use the `rm -rf` command to remove a version of .NET. For example, to remove the 6.0.406 SDK, run the following command:

```bash
sudo rm -rf /usr/local/share/dotnet/sdk/6.0.406
```

> [!IMPORTANT]
> The version directories might not match the "version" you're uninstalling. The individual runtimes and SDKs that are installed with a single .NET release might have different versions. For example, you might have installed ASP.NET Core 8 Runtime, which installed the 8.0.2 ASP.NET Core runtime and the 8.0.8 .NET runtime. Each has a different versioned directory. For more information, see [Overview of how .NET is versioned](../versions/index.md).

> [!IMPORTANT]
> If you're using an Arm-based Mac, such as one with an M1 chip, review the directory paths described in [Install .NET on Arm-based Macs](macos.md#arm-based-macs).

::: zone-end

## .NET Uninstall Tool

The .NET Uninstall Tool lets you remove .NET SDKs and runtimes from a system. A collection of options is available to specify which versions should be uninstalled. For more information, see [.NET uninstall tool overview](../additional-tools/uninstall-tool-overview.md).

## Remove the NuGet fallback directory

Before .NET Core 3.0 SDK, the .NET Core SDK installers used a directory named *NuGetFallbackFolder* to store a cache of NuGet packages. This cache was used during operations such as `dotnet restore` or `dotnet build /t:Restore`. The *NuGetFallbackFolder* was located under the *sdk* folder where .NET is installed. For example it could be at *C:\\Program Files\\dotnet\\sdk\\NuGetFallbackFolder* on Windows and at */usr/local/share/dotnet/sdk/NuGetFallbackFolder* on macOS.

You may want to remove this directory, if:

- You're only developing using .NET Core 3.0 SDK or .NET 5 or later versions.
- You're developing using .NET Core SDK versions earlier than 3.0, but you can work online.

If you want to remove the NuGet fallback directory, you can delete it, but you'll need administrative privileges to do so.

It's not recommended to delete the *dotnet* directory. Doing so would remove any global tools you've previously installed. Also, on Windows:

- You'll break Visual Studio 2019 version 16.3 and later versions. You can run **Repair** to recover.
- If there are .NET Core SDK entries in the **Apps & features** dialog, they'll be orphaned.

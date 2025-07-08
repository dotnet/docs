---
title: "Install .NET on Windows"
description: "Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Windows."
author: adegeo
ms.author: adegeo
ms.topic: install-set-up-deploy #Don't change
ms.date: 11/11/2024
no-loc: ["Program Files", "dotnet"]
#customer intent: As a developer or user, I want to decide the best way to install .NET on Windows.
---

# Install .NET on Windows

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

This article teaches you about which versions of .NET are supported on Windows, how to install .NET, and what the difference is between the SDK and runtime.

Unlike .NET Framework, .NET isn't tied to your version of Windows. You can only have a single version of .NET Framework installed on Windows. But .NET is standalone and can be installed anywhere on your computer. Some apps might include their own copy of .NET.

By default, .NET is installed to the _Program Files\\dotnet_ directory on your computer, unless the installation method chooses a different directory.

.NET is made up of the runtime and the SDK. The runtime runs .NET apps, and the SDK is used to create apps.

## Choose the correct runtime

There are three different runtimes for Windows, which enable different types of apps to run. The SDK includes all three runtimes, and an installer for a runtime might include an additional runtime. The following table describes which runtime is included with a particular .NET installer:

| Installer                | Includes .NET Runtime         | Includes .NET Desktop Runtime | Includes ASP.NET Core Runtime |
| ------------------------ | ----------------------------- | ----------------------------- | ----------------------------- |
| **.NET Runtime**         | Yes                           | No                            | No                            |
| **.NET Desktop Runtime** | Yes                           | Yes                           | No                            |
| **ASP.NET Core Runtime** | No                            | No                            | Yes                           |
| **.NET SDK**             | Yes                           | Yes                           | Yes                           |

To ensure that you can run all .NET apps on Windows, install both the ASP.NET Core Runtime and the .NET Desktop Runtime. The ASP.NET Core Runtime runs web-based apps, and the .NET Desktop Runtime runs desktop apps, such as a Windows Presentation Foundation (WPF) or Windows Forms app.

## Choose how to install .NET

There are different ways to install .NET, and some products might manage their own version of .NET. If you install .NET through software that manages its own version of .NET, it might not be enabled system-wide. Make sure you understand the implications of installing .NET through other software.

If you're unsure which method you should choose after reviewing the lists in the following sections, you probably want to use the [.NET Installer](#net-installer).

### Developers

- [Visual Studio](#install-with-visual-studio)

  Use **Visual Studio** to install .NET when you want to develop .NET apps using Visual Studio. Visual Studio manages its own copy of .NET. This method installs the SDK, Runtime, and Visual Studio templates.

- [Visual Studio Code - C# Dev Kit](#install-with-visual-studio-code)

  Install the **C# Dev Kit** extension for Visual Studio Code to develop .NET apps. The extension can use an SDK that's already installed or install one for you.

### Users and Developers

- [.NET Installer](#net-installer)

  Install .NET with a Windows Installer package, which is an executable that you run. This method can install the SDK and Runtime. Installs are performed system-wide.

- [Windows Package Manager (WinGet)](#install-with-windows-package-manager-winget)

  Use **WinGet** to install .NET when you want to manage .NET through the command line. This method can install the SDK and Runtime. Installs are performed system-wide.

- [PowerShell](#install-with-powershell)

  A PowerShell script that can automate the install of the SDK or Runtime. You can choose which version of .NET to install.

## Supported versions

The following table is a list of currently supported .NET releases and the versions of Windows they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of [Windows reaches end-of-life](https://support.microsoft.com/help/13853/windows-lifecycle-fact-sheet).

> [!TIP]
> As a reminder, this table applies to modern .NET (as opposed to .NET Framework). To install .NET Framework, see the [.NET Framework Installation guide](../../framework/install/index.md).

Windows 10 versions end-of-service dates are segmented by edition. Only **Home**, **Pro**, **Pro Education**, and **Pro for Workstations** editions are considered in the following table. Check the [Windows lifecycle fact sheet](https://support.microsoft.com/help/13853/windows-lifecycle-fact-sheet) for specific details.

| Operating System                      | .NET 9 (Architectures) | .NET 8 (Architectures) |
|---------------------------------------|------------------------|------------------------|
| Windows 11 (24H2, 23H2, 22H2 Ent/Edu) | ✔️ x64, x86, Arm64    | ✔️ x64, x86, Arm64    |
| Windows 10 (22H2+)                    | ✔️ x64, x86, Arm64    | ✔️ x64, x86, Arm64    |
| Windows Server 2025<br>Windows Server 2022<br>Windows Server 2019<br>Windows Server, Version 1903 or later<br>Windows Server 2016<br>Windows Server 2012 R2<br>Windows Server 2012 | ✔️ x64, x86           | ✔️ x64, x86           |
| Windows Server Core 2012 (and R2)     | ✔️ x64, x86           | ✔️ x64, x86           |
| Nano Server (2022, 2019)              | ✔️ x64                | ✔️ x64                |
| Windows 8.1                           | ❌                    | ❌                    |
| Windows 7 SP1 [ESU][esu]              | ❌                    | ❌                    |

> [!TIP]
> A `+` symbol represents the minimum version.

<a name="additional-deps"></a>

### Windows 7 / 8.1 / Server 2012

There is no longer a version of .NET that's supported on **Windows 7 and Windows 8.1**. The last supported releases was .NET 6 and support ended on November 12, 2024.

**Windows Server 2012** is still supported by any version of .NET that's still in support.

All three of these versions of Windows require further dependencies to be installed:

| Operating System         | Prerequisites                                                                    |
|--------------------------|----------------------------------------------------------------------------------|
| Windows 7 SP1 [ESU][esu] | - Microsoft Visual C++ 2015-2019 Redistributable [64-bit][vcc64] / [32-bit][vcc32] <br> - KB3063858 [64-bit][kb64] / [32-bit][kb32] <br> - [Microsoft Root Certificate Authority 2011](https://www.microsoft.com/pkiops/Docs/Repository.htm) (.NET Core 2.1 offline installer only) |
| Windows 8.1              | Microsoft Visual C++ 2015-2019 Redistributable [64-bit][vcc64] / [32-bit][vcc32] |
| Windows Server 2012      | Microsoft Visual C++ 2015-2019 Redistributable [64-bit][vcc64] / [32-bit][vcc32] |
| Windows Server 2012 R2   | Microsoft Visual C++ 2015-2019 Redistributable [64-bit][vcc64] / [32-bit][vcc32] |

The previous requirements are also required if you receive an error related to either of the following dlls:

- *api-ms-win-crt-runtime-l1-1-0.dll*
- *api-ms-win-cor-timezone-l1-1-0.dll*
- *hostfxr.dll*

## Arm-based Windows PCs

.NET is supported on Arm-based Windows PCs. The following sections describe things you should consider when installing .NET.

### Path differences

On an Arm-based Windows PC, all Arm64 versions of .NET are installed to the normal _C:\\Program Files\\dotnet\\_ folder. However, the **x64** version of the .NET SDK is installed to the _C:\\Program Files\\dotnet\\x64\\_ folder.

### Path variables

Environment variables that add .NET to system path, such as the `PATH` variable, might need to be changed if you have both the x64 and Arm64 versions of the .NET SDK installed. Additionally, some tools rely on the `DOTNET_ROOT` environment variable, which would also need to be updated to point to the appropriate .NET SDK installation folder.

## Install with Visual Studio

Visual Studio installs its own copy of .NET separate from other copies of .NET. Different versions of Visual Studio support different versions of .NET. The latest version of Visual Studio always supports the latest version of .NET.

> [!div class="button"]
> [Download Visual Studio Installer](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2022)

Visual Studio Installer installs and configures Visual Studio. Some Visual Studio workloads include .NET, such as **ASP.NET and web development** and **.NET Multi-platform App UI development**. Specific versions of .NET can be installed through the **Individual Components** tab.

The Visual Studio documentation provides instructions on how to:

- [Install Visual Studio](/visualstudio/install/install-visual-studio).
- [Configure Visual Studio workloads](/visualstudio/install/modify-visual-studio).

:::image type="content" source="media/windows/vs-workloads.png" alt-text="A screenshot that shows Visual Studio Installer with the .NET Desktop workload highlighted with a red box.":::

### .NET Versions and Visual Studio

If you're using Visual Studio to develop .NET apps, the following table describes the minimum required version of Visual Studio based on the target .NET SDK version.

| .NET SDK version      | Visual Studio version                       |
| --------------------- | ------------------------------------------- |
| 9                     | Visual Studio 2022 version 17.12 or higher. |
| 8                     | Visual Studio 2022 version 17.8 or higher.  |
| 7                     | Visual Studio 2022 version 17.4 or higher.  |
| 6                     | Visual Studio 2022 version 17.0 or higher.  |
| 5                     | Visual Studio 2019 version 16.8 or higher.  |
| 3.1                   | Visual Studio 2019 version 16.4 or higher.  |
| 3.0                   | Visual Studio 2019 version 16.3 or higher.  |
| 2.2                   | Visual Studio 2017 version 15.9 or higher.  |
| 2.1                   | Visual Studio 2017 version 15.7 or higher.  |

If you already have Visual Studio installed, you can check your version with the following steps.

01. Open Visual Studio.
01. Select **Help** > **About Microsoft Visual Studio**.
01. Read the version number from the **About** dialog.

For more information about, see [.NET SDK, MSBuild, and Visual Studio versioning](../porting/versioning-sdk-msbuild-vs.md).

## Install with Visual Studio Code

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. Visual Studio Code can use the SDK already installed on your system.

This [WinGet configuration file](https://builds.dotnet.microsoft.com/dotnet/install/dotnet_basic_config_docs.winget) installs the latest .NET SDK, Visual Studio Code and the C# DevKit. If you already have any of them installed, WinGet will skip that step.

01. Download the file and double-click to run it.
01. Read the license agreement, type <kbd>y</kbd>, and select <kbd>Enter</kbd> when prompted to accept.
01. If you get a flashing User Account Control (UAC) prompt in your Taskbar, allow the installation to continue.

Additionally, the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension will install .NET for you if it's not already installed.

For instructions on installing .NET through Visual Studio Code, see [Getting Started with C# in VS Code](https://code.visualstudio.com/docs/csharp/get-started).

## .NET Installer

The [download page](https://dotnet.microsoft.com/download/dotnet) for .NET provides Windows Installer executables.

1. Open a web browser and navigate to <https://dotnet.microsoft.com/download/dotnet>.
1. Select the version of .NET you want to download, such as 9.0.
1. Find the SDK or Runtime box that contains the links for downloading .NET.
1. Under the **Installers** column, find the **Windows** row and select the link for your CPU architecture. If you're unsure, select **x64** as it's the most common.

   The browser should automatically download the installer.

   > [!TIP]
   > The following image shows the SDK, but you can also download the Runtime.

   :::image type="content" source="media/windows/dotnet-download-page-small.png" alt-text="An image of the .NET download page, with the SDK download link highlighted." lightbox="media/windows/dotnet-download-page.png":::

1. Open Windows Explorer and navigate to where the file was downloaded, most likely your **Downloads** folder.
1. Double-click on the file to install .NET.

   The Windows Installer dialog is opened.

   :::image type="content" source="media/windows/msi-installer.png" alt-text="A screenshot of the .NET installer app window.":::

1. Select **Install** and follow the instructions to install .NET.

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

### Command-line options

Use the `/?` parameter to display a list of options.

If you want to install .NET silently, such as in a production environment or to support continuous integration, use the following options:

- `/install`\
Installs .NET.

- `/quiet`\
Prevents any UI and prompts from displaying.

- `/norestart`\
Suppresses any attempts to restart.

```console
dotnet-sdk-9.0.100-win-x64.exe /install /quiet /norestart
```

If you've already installed .NET, use the .NET Installer to manage the installation. Instead of `/install`, use one of the following options:

- `/uninstall`\
Remove this version of .NET.

- `/repair`\
Check if the installations key files or components are damaged and restore them.

> [!TIP]
> The installer returns an exit code of **0** for success and an exit code of **3010** to indicate that a restart is required. Any other value is most likely an error code.

### Microsoft Update

[!INCLUDE [microsoft-update](includes/microsoft-update.md)]

### Choose when previous versions are removed

The installer executables always install new content before removing the previous installation. Applications that are running might be interrupted or crash when older runtimes are removed. To minimize the impact of updating .NET, you can specify when a previous .NET installation should be removed using a registry key.

| .NET version | Registry key | Name | Type | Value |
| -------------- | :--------- | :---------- | :---------- | :---------- |
| All | HKLM\SOFTWARE\Microsoft\\.NET | RemovePreviousVersion | REG_SZ | `always`, `never`, or `nextSession` |
| .NET 9 | HKLM\SOFTWARE\Microsoft\\.NET\9.0 | RemovePreviousVersion | REG_SZ | `always`, `never`, or `nextSession` |
| .NET 8 | HKLM\SOFTWARE\Microsoft\\.NET\8.0 | RemovePreviousVersion | REG_SZ | `always`, `never`, or `nextSession` |

- `never` retains previous installations and requires manual intervention to remove previous .NET installations.
- `always` removes previous installations after the new version is installed. This is the default behavior in .NET.
- `nextSession` defers the removal until the next logon session from members in the Administrators group.
- Values are case-insensitive and invalid values default to `always`.

When the removal is deferred, the installer writes a command to the [RunOnce](/windows/win32/setupapi/run-and-runonce-registry-keys) registry key to uninstall the previous version. The command only executes if a user in the Administrators group logs on to the machine.

> [!NOTE]
> This feature is only available in .NET 8 (8.0.11), 9, and later versions of .NET. It only applies to the standalone installer executables and impacts distributions like WinGet that use them.

## Install with Windows Package Manager (WinGet)

You can install and manage .NET through the Windows Package Manager service, using the `winget.exe` tool. For more information about how to install and use **WinGet**, see [Use the winget tool to install and manage applications](/windows/package-manager/winget/).

If you're installing .NET system-wide, install with administrative privileges.

The .NET WinGet packages are:

- `Microsoft.DotNet.Runtime.9`&mdash;.NET Runtime 9.0
- `Microsoft.DotNet.AspNetCore.9`&mdash;ASP.NET Core Runtime 9.0
- `Microsoft.DotNet.DesktopRuntime.9`&mdash;.NET Desktop Runtime 9.0
- `Microsoft.DotNet.SDK.9`&mdash;.NET SDK 9.0
- `Microsoft.DotNet.Runtime.8`&mdash;.NET Runtime 8.0
- `Microsoft.DotNet.AspNetCore.8`&mdash;ASP.NET Core Runtime 8.0
- `Microsoft.DotNet.DesktopRuntime.8`&mdash;.NET Desktop Runtime 8.0
- `Microsoft.DotNet.SDK.8`&mdash;.NET SDK 8.0

### Install the SDK

If you install the SDK, you don't need to install the corresponding runtime.

01. [Install WinGet](/windows/package-manager/winget/#install-winget).
01. Open a terminal, such as PowerShell or Command Prompt.
01. Run the `winget install` command and pass the name of the SDK package:

    ```cmd
    winget install Microsoft.DotNet.SDK.9
    ```

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

### Install the runtime

There are different runtimes you can install. Refer to the [Choose the correct runtime](#choose-the-correct-runtime) section to understand what's included with each runtime.

01. [Install WinGet](/windows/package-manager/winget/#install-winget).
01. Open a terminal, such as **PowerShell** or **Command Prompt**.
01. Run the `winget install` command and pass the name of the SDK package:

    ```cmd
    winget install Microsoft.DotNet.DesktopRuntime.9
    winget install Microsoft.DotNet.AspNetCore.9
    ```

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

### Search for versions

Use the `winget search` command to search for different versions of the package you want to install. For example, the following command searches for all .NET SDKs available via WinGet:

```cmd
winget search Microsoft.DotNet.SDK
```

The search results are printed in a table with each package identifier.

```output
Name                           Id                           Version                    Source
----------------------------------------------------------------------------------------------
Microsoft .NET SDK 9.0         Microsoft.DotNet.SDK.9       9.0.100                    winget
Microsoft .NET SDK 8.0         Microsoft.DotNet.SDK.8       8.0.300                    winget
Microsoft .NET SDK 7.0         Microsoft.DotNet.SDK.7       7.0.409                    winget
Microsoft .NET SDK 6.0         Microsoft.DotNet.SDK.6       6.0.422                    winget
Microsoft .NET SDK 5.0         Microsoft.DotNet.SDK.5       5.0.408                    winget
Microsoft .NET SDK 3.1         Microsoft.DotNet.SDK.3_1     3.1.426                    winget
```

### Install preview versions

If a preview version is available, substitute the version number in the **Id** with the word `Preview`. The following example installs the preview release of the .NET Desktop Runtime:

```cmd
winget install Microsoft.DotNet.DesktopRuntime.Preview
```

## Install with PowerShell

Installing .NET through the `dotnet-install` PowerShell script is recommended for continuous integration and nonadmin installs. If you're installing .NET for normal use on your system, use either the [.NET Installer](#net-installer) or [Windows Package Manager](#install-with-windows-package-manager-winget) installation methods.

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET 8. You can choose a specific release by specifying the `-Channel` switch. Include the `-Runtime` switch to install a runtime. Otherwise, the script installs the SDK. The script is available at <https://dot.net/v1/dotnet-install.ps1> and the source code is hosted on [GitHub](https://github.com/dotnet/install-scripts).

> [!div class="button"]
> [Download the script](https://dot.net/v1/dotnet-install.ps1)

For more information about the script, see [dotnet-install script reference](../tools/dotnet-install-script.md).

### Install the runtime

The .NET Runtime is installed by providing the `-Runtime` switch.

01. Download the install script from <https://dot.net/v1/dotnet-install.ps1>
01. Open PowerShell and navigate to the folder containing the script.
01. Run the following commands to install both the Desktop runtime and ASP.NET Core runtime for maximum compatibility:

    ```powershell
    dotnet-install.ps1 -Runtime windowsdesktop
    dotnet-install.ps1 -Runtime aspnetcore
    ```

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

### Install the SDK

If you install the SDK, you don't need to install the runtimes.

01. Download the install script from <https://dot.net/v1/dotnet-install.ps1>
01. Open PowerShell and navigate to the folder containing the script.
01. Run the following command to install the .NET SDK.

    ```powershell
    dotnet-install.ps1
    ```

    > [!NOTE]
    > The SDK is installed by omitting the `-Runtime` switch.

To learn how to use the .NET CLI, see [.NET CLI overview](../tools/index.md).

## Validation

[!INCLUDE [verify-download-intro](includes/verify-download-intro.md)]

[!INCLUDE [verify-download-windows](includes/verify-download-windows.md)]

## Troubleshooting

After installing the .NET SDK, you might run into problems trying to run .NET CLI commands. This section collects those common problems and provides solutions.

- [No .NET SDK was found](#no-net-sdk-was-found)
- [Building apps is slower than expected](#building-apps-is-slower-than-expected)
- [`hostfxr.dll` / `api-ms-win-crt-runtime-l1-1-0.dll` / `api-ms-win-cor-timezone-l1-1-0.dll` is missing](#required-c-runtime-files-are-missing)

### No .NET SDK was found

Most likely you installed both the x86 (32-bit) and x64 (64-bit) versions of the .NET SDK. This is causing a conflict because when you run the `dotnet` command, it's resolving to the x86 version when it should resolve to the x64 version. This problem is fixed by adjusting the `%PATH%` variable to resolve the x64 version first.

01. Verify that you have both versions installed by running the `where.exe dotnet` command. If you do, you should see an entry for both the _Program Files\\_ and _Program Files (x86)\\_ folders. If the _Program Files (x86)\\_ folder is first, as demonstrated by the following example, it's incorrect and you should continue on to the next step.

    ```cmd
    > where.exe dotnet
    C:\Program Files (x86)\dotnet\dotnet.exe
    C:\Program Files\dotnet\dotnet.exe
    ```

    > [!TIP]
    > Even though _Program Files_ is used in this example, you may see other copies of _dotnet.exe_ listed. Adjust them so that the appropriate _dotnet.exe_ is resolved first.

    If it's correct and _Program Files\\_ is first, you don't have the problem this section is discussing and you should create a [.NET help request issue on GitHub](https://github.com/dotnet/core/issues/new?template=Blank+issue).

01. Press the Windows button and type "Edit the system environment variables" into search. Select **Edit the system environment variables**.

    :::image type="content" source="media/windows/start-menu.png" alt-text="Windows start menu with edit environment variable":::

01. The **System Properties** window opens up to the **Advanced Tab**. Select **Environment Variables**.

    :::image type="content" source="media/windows/system-props.png" alt-text="The Windows system properties panel open.":::

01. On the **Environment Variables** window, under the **System variables** group, select the *Path** row and then select the **Edit** button.

    :::image type="content" source="media/windows/list-vars.png" alt-text="The environment variables window with user and system variables.":::

01. Use the **Move Up** and **Move Down** buttons to move the **C:\\Program Files\\dotnet\\** entry above **C:\\Program Files (x86)\\dotnet\\**.

    :::image type="content" source="media/windows/edit-vars.png" alt-text="The environment variables list for the system.":::

### Building apps is slower than expected

Ensure that Smart App Control, a Windows feature, is off. Smart App Control isn't recommended to be enabled on machines used for development. Any setting other than "off" might negatively affect SDK performance.

<a name="required-c-runtime-files-are-missing"></a>

### `hostfxr.dll` / `api-ms-win-crt-runtime-l1-1-0.dll` / `api-ms-win-cor-timezone-l1-1-0.dll` is missing

Install the Microsoft Visual C++ 2015-2019 Redistributable ([64-bit][vcc64] or [32-bit][vcc32]).

## Related content

- [.NET CLI overview](../tools/index.md)
- [Upgrade to a new .NET version](upgrade.md).
- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-windows).
- [Tutorial: Hello World tutorial](../tutorials/with-visual-studio.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).

[esu]: /troubleshoot/windows-client/windows-7-eos-faq/windows-7-extended-security-updates-faq
[vcc64]: https://aka.ms/vs/16/release/vc_redist.x64.exe
[vcc32]: https://aka.ms/vs/16/release/vc_redist.x86.exe
[kb64]: https://www.microsoft.com/download/details.aspx?id=47442
[kb32]: https://www.microsoft.com/download/details.aspx?id=47409

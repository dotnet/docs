---
title: "Install .NET on Windows"
description: "Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on Windows."
author: adegeo
ms.author: adegeo
ms.topic: install-set-up-deploy #Don't change
ms.date: 05/15/2024
#customer intent: As a developer or user, I want to decide the best way to install .NET on Windows.
---

# Install .NET on Windows

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

There are many different ways to install .NET on Windows. This article helps you understand the difference between the SDK and Runtime, which runtime you should install, and the method you should use to install .NET.

.NET is made up of the runtime and the SDK. The runtime runs .NET apps, and the SDK is used to create apps.

Unlike .NET Framework, .NET isn't installed and tied to your version of Windows. You can only have a single version of .NET Framework installed on Windows. .NET can be installed anywhere on your computer and some apps might include their own copy of .NET.

By default, .NET is installed to the _Program Files\\dotnet_ directory on your computer, unless the install method chooses a different directory.

## Choose the correct runtime

There are three different runtimes for Windows, which enable different types of apps to run. The SDK includes all three runtimes. If you install a specific runtime, it might include other runtimes. The following table describes which runtime is included with a particular .NET installer:

|                          | Includes .NET Runtime         | Includes .NET Desktop Runtime | Includes ASP.NET Core Runtime |
| ------------------------ | ----------------------------- | ----------------------------- | ----------------------------- |
| **.NET Runtime**         | Yes                           | No                            | No                            |
| **.NET Desktop Runtime** | Yes                           | Yes                           | No                            |
| **ASP.NET Core Runtime** | No                            | No                            | Yes                           |
| **.NET SDK**             | Yes                           | Yes                           | Yes                           |


To ensure that you can run all .NET apps on Windows, install both the ASP.NET Core Runtime and the .NET Desktop Runtime. The ASP.NET Core Runtime runs any web apps, and the .NET Desktop Runtime runs any desktop app, such as a Windows Presentation Foundation (WPF) or Windows Forms (WinForms) app.

## Choose how to install .NET

There are different ways to install .NET, and some products, like Visual Studio, might manage their own version of .NET. If you install .NET through software that manages its own version of .NET, you should also install the .NET runtime separately so that you can run .NET apps.

If you're unsure which method you should choose after reviewing the lists in the following sections, you probably want to use the [.NET Installer](#net-installer).

### Developers

- [Visual Studio](#install-with-visual-studio)

  Use **Visual Studio** to install .NET when you want to develop .NET apps using Visual Studio. Visual Studio manages its own copy of .NET. This method installs the SDK, Runtime, and Visual Studio templates.

- [Visual Studio Code - C# Dev Kit](#install-with-visual-studio-code)

  Install the **C# Dev Kit** extension for Visual Studio Code to develop .NET apps. This method uses the SDKs you've previously installed.

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
> As a reminder, this table applies to modern .NET (as opposed to .NET Framework). .NET Framework downloads can be found [here](https://dotnet.microsoft.com/download/dotnet-framework).

Windows 10 versions end-of-service dates are segmented by edition. Only **Home**, **Pro**, **Pro Education**, and **Pro for Workstations** editions are considered in the following table. Check the [Windows lifecycle fact sheet](https://support.microsoft.com/help/13853/windows-lifecycle-fact-sheet) for specific details.

| Operating System                    | .NET 8 (Architectures) | .NET 6 (Architectures) |
|-------------------------------------|------------------------|------------------------|
| Windows 11                          | ✔️ x64, x86, Arm64    | ✔️ x64, Arm64          |
| Windows Server 2022                 | ✔️ x64, x86           | ✔️ x64, x86            |
| Windows 10, Version 1607 or later   | ✔️ x64, x86, Arm64    | ✔️ x64, x86, Arm64     |
| Windows 8.1                         | ❌                     | ✔️ x64, x86            |
| Windows 7 SP1 [ESU][esu]            | ❌                     | ✔️ x64, x86            |
| Windows Server 2022<br>Windows Server 2019<br>Windows Server, Version 1903 or later<br>Windows Server 2016<br>Windows Server 2012 R2<br>Windows Server 2012 | ✔️ x64, x86           | ✔️ x64, x86            |
| Windows Server Core 2012 (and R2)   | ✔️ x64, x86           | ✔️ x64, x86            |
| Nano Server, Version 1809+          | ✔️ x64                | ✔️ x64                 |
| Nano Server, Version 1803           | ❌                     | ❌                      |

> [!TIP]
> A `+` symbol represents the minimum version.

<a name="additional-deps"></a>

### Windows 7 / 8.1 / Server 2012

While Windows 2012 is still supported with the latest version of .NET, .NET 6 was the last version to support Windows 7 and Windows 8.1. All three of these versions of Windows require further dependencies to be installed:

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

The following sections describe things you should consider when installing .NET on an Arm-based Windows PC.

<!-- This section is mirrored in the macos.md file. Changes here should be applied there -->

### What is supported

The following table describes which versions of .NET are supported on an Arm-based Windows PC:

| .NET Version | Architecture | SDK | Runtime | [Path conflict](#path-conflicts) | Supported |
|--------------|--------------|-----|---------|----------------------------------| --------- |
| 8            | Arm64        | Yes | Yes     | No                               | ✔️       |
| 8            | x64          | Yes | Yes     | No                               | ✔️       |
| 7            | Arm64        | Yes | Yes     | No                               | ❌       |
| 7            | x64          | Yes | Yes     | No                               | ❌       |
| 6            | Arm64        | Yes | Yes     | No                               | ✔️       |
| 6            | x64          | Yes | Yes     | No                               | ✔️       |
| 5            | Arm64        | Yes | Yes     | [Yes](#path-conflicts)           | ❌       |
| 5            | x64          | No  | Yes     | [Yes](#path-conflicts)           | ❌       |

The x64 and Arm64 versions of the .NET SDK exist independently from each other. If a new version is released, each architecture install needs to be upgraded.

### Path differences

On an Arm-based Windows PC, all Arm64 versions of .NET are installed to the normal _C:\\Program Files\\dotnet\\_ folder. However, the **x64** version of the .NET SDK is installed to the _C:\\Program Files\\dotnet\\x64\\_ folder.

### Path conflicts

The **x64** .NET SDK installs to its own directory, as described in the previous section. This allows the Arm64 and x64 versions of the .NET SDK to exist on the same machine. However, any **x64** SDK older than 6.0, isn't supported and installs to the same location as the Arm64 version, the _C:\\Program Files\\dotnet\\_ folder. If you want to install an unsupported x64 SDK, you must uninstall the Arm64 version first. The opposite is also true. You must uninstall the unsupported x64 SDK to install the Arm64 version.

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

| .NET SDK version      | Visual Studio version                      |
| --------------------- | ------------------------------------------ |
| 8                     | Visual Studio 2022 version 17.8 or higher. |
| 7                     | Visual Studio 2022 version 17.4 or higher. |
| 6                     | Visual Studio 2022 version 17.0 or higher. |
| 5                     | Visual Studio 2019 version 16.8 or higher. |
| 3.1                   | Visual Studio 2019 version 16.4 or higher. |
| 3.0                   | Visual Studio 2019 version 16.3 or higher. |
| 2.2                   | Visual Studio 2017 version 15.9 or higher. |
| 2.1                   | Visual Studio 2017 version 15.7 or higher. |

If you already have Visual Studio installed, you can check your version with the following steps.

01. Open Visual Studio.
01. Select **Help** > **About Microsoft Visual Studio**.
01. Read the version number from the **About** dialog.

For more information about, see [.NET SDK, MSBuild, and Visual Studio versioning](../porting/versioning-sdk-msbuild-vs.md).

## Install with Visual Studio Code

Visual Studio Code uses the versions of .NET already installed on your system. Install .NET using either [.NET Installer](#net-installer) or [Windows Package Manager](#install-with-windows-package-manager-winget). Visual Studio installs its own copy of .NET that can't be used by Visual Studio Code.

.NET apps are created in Visual Studio Code with the C# Dev Kit extension.

1. First, install the .NET SDK by following the steps in one of the other sections, except for the section on Visual Studio.

   - [.NET Installer](#net-installer)
   - [Windows Package Manager (WinGet)](#install-with-windows-package-manager-winget)

1. Next, install Visual Studio Code, if you haven't already. For more information, see [Visual Studio Code on Windows](https://code.visualstudio.com/docs/setup/windows).
1. Lastly, install the C# Dev Kit extension. For more information, see [Getting Started with C# in VS Code](https://code.visualstudio.com/docs/csharp/get-started#_install).

## .NET Installer

The [download page](https://dotnet.microsoft.com/download/dotnet) for .NET provides Windows Installer executables.

1. Open a web browser and navigate to <https://dotnet.microsoft.com/download/dotnet>.
1. Select the version of .NET you want to download, such as 8.0.
1. Find the SDK or Runtime box that contains the links for downloading .NET.
1. Under the **Installers** column, find the **Windows** row and select the link for your CPU architecture. If you're unsure, select **x64** as it's the most common.

   The browser automatically downloads the MSI package.

   > [!TIP]
   > The following image shows the SDK, but you can also download the Runtime.

   :::image type="content" source="media/windows/dotnet-download-page-small.png" alt-text="An image of the .NET download page, with the SDK download link highlighted." lightbox="media/windows/dotnet-download-page.png":::

1. Open Windows Explorer and navigate to where the file was downloaded, most likely your **Downloads** folder.
1. Double-click on the file to install .NET.

   The Windows Installer dialog is opened.

   :::image type="content" source="media/windows/msi-installer.png" alt-text="A screenshot of the .NET MSI installer app window.":::

1. Select **Install** and follow the instructions to install .NET.

### Command-line options

If you want to install .NET silently, such as in a production environment or to support continuous integration, use the following Windows Installer options:

- `/install`\
Installs .NET.

- `/quiet`\
Prevents any UI and prompts from displaying.

- `/norestart`\
Suppresses any attempts to restart.

```console
dotnet-sdk-8.0.100-win-x64.exe /install /quiet /norestart
```

For more information, see [Standard Installer Command-Line Options](/windows/win32/msi/standard-installer-command-line-options).

> [!TIP]
> The installer returns an exit code of **0** for success and an exit code of **3010** to indicate that a restart is required. Any other value is most likely an error code.

## Install with Windows Package Manager (WinGet)

You can install and manage .NET through the Windows Package Manager service, using the `winget.exe` tool. For more information about how to install and use **WinGet**, see [Use the winget tool to install and manage applications](/windows/package-manager/winget/).

If you're installing .NET system-wide, install with administrative privileges.

The .NET WinGet packages are:

- `Microsoft.DotNet.Runtime.8`&mdash;.NET Runtime 8.0.
- `Microsoft.DotNet.AspNetCore.8`&mdash;ASP.NET Core Runtime 8.0
- `Microsoft.DotNet.DesktopRuntime.8`&mdash;.NET Desktop Runtime 8.0
- `Microsoft.DotNet.SDK.8`&mdash;.NET SDK 8.0

### Install the SDK

If you install the SDK, you don't need to install the corresponding runtime.

01. [Install WinGet](/windows/package-manager/winget/#install-winget).
01. Open a terminal, such as PowerShell or `cmd.exe`.
01. Run the `winget install` command and pass the name of the SDK package:

    ```cmd
    winget install Microsoft.DotNet.SDK.8
    ```

### Install the runtime

There are different runtimes you can install. Refer to the [Choose the correct runtime](#choose-the-correct-runtime) section to understand what's included with each runtime.

01. [Install WinGet](/windows/package-manager/winget/#install-winget).
01. Open a terminal, such as **PowerShell** or **Command Prompt**.
01. Run the `winget install` command and pass the name of the SDK package:

    ```cmd
    winget install Microsoft.DotNet.DesktopRuntime.8
    winget install Microsoft.DotNet.AspNetCore.8
    ```

### Search for versions

Use the `winget search` command to search for different versions of the package you want to install. For example, the following command searches for all .NET SDKs available via WinGet:

```cmd
winget search Microsoft.DotNet.SDK
```

The search results are printed in a table with each package identifier.

```output
Name                           Id                           Version                    Source
----------------------------------------------------------------------------------------------
Microsoft .NET SDK 9.0 Preview Microsoft.DotNet.SDK.Preview 9.0.100-preview.3.24204.13 winget
Microsoft .NET SDK 8.0         Microsoft.DotNet.SDK.8       8.0.300                    winget
Microsoft .NET SDK 7.0         Microsoft.DotNet.SDK.7       7.0.409                    winget
Microsoft .NET SDK 6.0         Microsoft.DotNet.SDK.6       6.0.422                    winget
Microsoft .NET SDK 5.0         Microsoft.DotNet.SDK.5       5.0.408                    winget
Microsoft .NET SDK 3.1         Microsoft.DotNet.SDK.3_1     3.1.426                    winget
```

### Install preview versions

You can install preview versions by substituting the version number, such as `8`, with the word `Preview`. The following example installs the preview release of the .NET Desktop Runtime:

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

    If it's correct and the _Program Files\\_ is first, you don't have the problem this section is discussing and you should create a [.NET help request issue on GitHub](https://github.com/dotnet/core/issues/new?assignees=&labels=&template=01_bug_report.md&title=)

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

- [Upgrade to a new .NET version](upgrade.md).
- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-windows).
- [Tutorial: Hello World tutorial](../tutorials/with-visual-studio.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).

[esu]: /troubleshoot/windows-client/windows-7-eos-faq/windows-7-extended-security-updates-faq
[vcc64]: https://aka.ms/vs/16/release/vc_redist.x64.exe
[vcc32]: https://aka.ms/vs/16/release/vc_redist.x86.exe
[kb64]: https://www.microsoft.com/download/details.aspx?id=47442
[kb32]: https://www.microsoft.com/download/details.aspx?id=47409

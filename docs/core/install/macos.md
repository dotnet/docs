---
title: Install .NET on macOS
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on macOS.
author: adegeo
ms.author: adegeo
ms.topic: install-set-up-deploy
ms.date: 10/14/2024
ms.custom: linux-related-content

#customer intent: As a user or developer, I want to know which versions of .NET are supported on macOS. I also need to know how to install .NET on macOS.

---

# Install .NET on macOS

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

In this article, you learn how to install .NET on macOS. .NET is made up of the runtime and the SDK. The runtime is used to run a .NET app and might or might not be included with the app. The SDK is used to create .NET apps and libraries. The .NET runtime is always installed with the SDK.

The latest version of .NET is 8.

> [!div class="button"]
> [Download .NET](https://dotnet.microsoft.com/download/dotnet)

## Supported versions

The following table is a list of currently supported .NET releases on macOS. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of macOS is no longer supported.

| macOS Version          | .NET     |
|------------------------|----------|
| macOS 15 "Sequoia"     | 8.0, 6.0 |
| macOS 14 "Sonoma"      | 8.0, 6.0 |
| macOS 13 "Ventura"     | 8.0, 6.0 |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Runtime or SDK

**The SDK** is used to build and publish .NET apps and libraries. Installing the SDK includes both the standard .NET and the ASP.NET Core runtimes. The latest SDK supports building apps for previous versions of .NET. For example, you can use .NET 8.0 SDK to build apps that target .NET 6.0.

**The runtime** is used to run apps created with .NET. When an app author publishes an app, they can include the runtime with their app. If they don't include the runtime, it's up to the user to install the correct runtime.

There are two runtimes you can install on macOS, and both are included with the SDK.

- _ASP.NET Core Runtime_\
  Runs ASP.NET Core apps. Includes the .NET runtime. **Not available as an installer.**

- _.NET Runtime_\
  This runs standard console-based .NET apps.

## Methods

Install .NET using one of the following methods:

- [Install .NET](#install-net)\
Use the standalone installer to install .NET. This method is the typical way to install .NET on your developer or user machine.

- [Install .NET for Visual Studio Code](#install-net-for-visual-studio-code)\
This section provides the requirements for using .NET with Visual Studio Code.

- [Install .NET manually](#install-net-manually)\
Use this installation method when you need to install .NET to a specific folder, and run it apart from other copies of .NET.

- [Install .NET with a script](#install-net-with-a-script)
This installation method automates the manual install process by using a Bash shells script. Typically for continuous integration scenarios.

## Install .NET

Installer packages are available for macOS, an easy way of installing .NET.

01. Open a browser and navigate to <https://dotnet.microsoft.com/download/dotnet>.
01. Select the link to the .NET version you want to install, such as **.NET 8.0**.

    :::image type="content" source="media/macos/download-page.png" alt-text="The .NET download website. Versions 6.0 through 9.0 are listed. A red box highlights those download links.":::

    This link brings you to the page with links to download that version of .NET

    If you're going to install the SDK, choose the latest .NET version. The SDK supports building apps for previous versions of .NET.

    > [!TIP]
    > If you're unsure which version to download, choose the version marked **latest**.

01. This page presents the download links for the SDK and the Runtime. Here you download the .NET SDK or .NET Runtime.

    :::image type="content" source="media/macos/sdk-runtime-download-page.png" alt-text="The .NET download website showing the SDK and Runtime download links. The SDK and Runtime headers are highlighted with a red box. Each box has an arrow pointing down to the macOS section.":::

    There are two sections highlighted in the previous image. If you're downloading the SDK, refer to section 1. For the .NET Runtime, refer to section 2.

    - Section 1 (SDK)

      This section is the SDK download area. Under the **Installers** column for the **macOS** row, two architectures are listed: **Arm64** and **x64**.

      - If you're running an Apple processor, such as an **M1** or an **M3 Pro**, select **Arm64**.
      - If you're running an Intel processor, select **x64**.

    - Section 2 (Runtime)

      This section contains the runtime downloads. Notice that links for the **Installers** column in the **macOS** row are empty! This section is empty because this particular Runtime, **ASP.NET Core**, is only provided in the SDK. Scroll further down to find the standard **.NET Runtime** for download.

      :::image type="content" source="media/macos/runtime-links.png" alt-text="A screenshot showing just the .NET Runtime download table from the .NET download website. The macOS row is highlighted with a red box.":::

      - If you're running an Apple processor, such as an **M1** or an **M3 Pro**, select **Arm64**.
      - If you're running an Intel processor, select **x64**.

01. Once the download completes, open it.
01. The macOS Installer is shown. Follow the steps in the Installer and use the default options.

    :::image type="content" source="media/macos/installer.png" alt-text="A screenshot showing just the .NET Runtime download table from the .NET download website. The macOS row is highlighted with a red box.":::

## Install .NET manually

As an alternative to the macOS installers, you can download and manually install the SDK and runtime. Manual installation is usually performed as part automation in a continuous integration scenario. Developers and users usually want to use the [installer](https://dotnet.microsoft.com/download/dotnet).

> [!TIP]
> Use the [install-dotnet.sh script](#install-net-with-a-script) to perform these steps automatically.

01. Open a browser and navigate to <https://dotnet.microsoft.com/download/dotnet>.
01. Select the link to the .NET version you want to install, such as **.NET 8.0**.

    This link brings you to the page with links to download that version of .NET

    If you're going to install the SDK, choose the latest .NET version. The SDK supports building apps for previous versions of .NET.

    > [!TIP]
    > If you're unsure which version to download, choose the version marked **latest**.

    :::image type="content" source="media/macos/download-page.png" alt-text="The .NET download website. Versions 6.0 through 9.0 are listed. A red box highlights those download links.":::

01. Select the link to the SDK or Runtime you want to install. Look for the **Binaries** column in the **macOS** row.

    :::image type="content" source="media/macos/download-page.png" alt-text="The .NET download website. Versions 6.0 through 9.0 are listed. A red box highlights those download links.":::

    - If you're running an Apple processor, such as an **M1** or an **M3 Pro**, select **Arm64**.
    - If you're running an Intel processor, select **x64**.

01. Open a terminal and navigate to where the .NET binary was downloaded.
01. Extract the tarball to where you want to .NET on your system. The following example uses the **HOME** directory `~/Applications/.dotnet`.

    ```bash
    mkdir -p ~/Applications/.dotnet
    tar -xf "dotnet-sdk-9.0.100-rc.2.24474.11-osx-arm64.tar" -C ~/Applications/.dotnet/
    ```

Test that .NET is working by changing the directory to where .NET was installed, and run the `dotnet --info` command:

```bash
chdir ~/Applications/.dotnet/
./dotnet --info
```

## Install .NET with a script

The [dotnet-install scripts](../tools/dotnet-install-script.md) are used for automation and unelevated installs of the runtime. You can download the script from <https://dot.net/v1/dotnet-install.sh>.

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET 8. You can choose a specific release by specifying the `channel` switch. Include the `runtime` switch to install a runtime. Otherwise, the script installs the SDK.

> [!TIP]
> These commands are provided a script snippet at the end of this procedure.

01. Open a terminal.
01. Navigate to a folder where the script will be downloaded, such as _~/Downloads_.
01. If you don't have the `wget` command, install it with **Brew**

    ```bash
    brew install wget
    ```

01. Run the following command to download the script:

    ```bash
    wget https://dot.net/v1/dotnet-install.sh
    ```

01. Give the script execute permissions

    ```bash
    chmod +x dotnet-install.sh
    ```

01. Run the script to install .NET.

    The script defaults to installing the latest SDK to the `~/.dotnet` directory.

    ```bash
    ./dotnet-install.sh
    ```

Here are all the commands as a single bash script:

```bash
chdir ~/Downloads
brew install wget
wget https://dot.net/v1/dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh
```

Test .NET by navigating to the `~/.dotnet` folder and running the `dotnet --info` command:

```bash
chdir ~/.dotnet
./dotnet --info
```

> [!IMPORTANT]
> Some programs might use environment variables to find .NET on your system, and using the `dotnet` command might not work when opening a new terminal. For help resolving this issue, see [Make .NET available system-wide](#make-net-available-system-wide) section.

## Install .NET for Visual Studio Code

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. While Visual Studio Code doesn't come with an automated .NET installer like Visual Studio does, adding .NET support is managed through the  [.NET Install Tool](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-runtime) extension. For more information, see [Using .NET in Visual Studio Code](https://code.visualstudio.com/docs/languages/dotnet).

## Notarization

Software created for macOS that's distributed with a Developer ID must be notarized, including apps made with .NET.

If you run a non-notarized app, an error window similar to the following image is displayed:

![macOS Catalina notarization alert](media/dependencies/macos-notarized-pkg-warning.png)

For more information about how enforced-notarization affects .NET (and your .NET apps), see [Working with macOS Catalina Notarization](macos-notarization-issues.md).

## Validation

[!INCLUDE [verify-download-intro](includes/verify-download-intro.md)]

[!INCLUDE [verify-download-macos-linux](includes/verify-download-macos-linux.md)]

## Troubleshooting

The following sections are available to help troubleshoot issues:

- [Arm-based Macs](#arm-based-macs)
- [System.Drawing.Common and libgdiplus](#systemdrawingcommon-and-libgdiplus)
- [Make .NET available system-wide](#make-net-available-system-wide)

### Make .NET available system-wide

Sometimes apps on your system, including the terminal, need to find where .NET is installed. The .NET [macOS Installer package](#install-net) should automatically configure your system. However, if you used the [manual installation method](#install-net-manually) or the [.NET install script](#install-net-with-a-script), you must add the directory where .NET was installed to the `PATH` variable.

Some apps might look for the `DOTNET_ROOT` variable when trying to determine where .NET is installed.

There are many different shells available for macOS and each has a different profile. For example:

- **Bash Shell**: _~/.profile_, _/etc/profile_
- **Korn Shell**: _~/.kshrc_ or _.profile_
- **Z Shell**: _~/.zshrc_ or _.zprofile_

Set the following two environment variables in your shell profile:

- `DOTNET_ROOT`

  This variable is set to the folder .NET was installed to, such as `$HOME/.dotnet`:

  ```bash
  export DOTNET_ROOT=$HOME/.dotnet
  ```

- `PATH`

  This variable should include both the `DOTNET_ROOT` folder and the `DOTNET_ROOT/tools` folder:

  ```bash
  export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
  ```

### Arm-based Macs

The following sections describe things you should consider when installing .NET on an Arm-based Mac.

<!-- This section is mirrored in the windows.md file. Changes here should be applied there -->

#### .NET Versions

The following table describes which versions of .NET are supported on an Arm-based Mac:

| .NET Version | SDK | Runtime | [Path conflict](#path-conflicts) |
|--------------|-----|---------|----------------------------------|
| 8            | Yes | Yes     | No                               |
| 8            | Yes | Yes     | No                               |
| 6            | Yes | Yes     | No                               |
| 6            | Yes | Yes     | No                               |

The x64 and Arm64 versions of the .NET SDK exist independently from each other. If a new version is released, each install needs to be upgraded.

#### Path differences

On an Arm-based Mac, all Arm64 versions of .NET are installed to the normal _/usr/local/share/dotnet/_ folder. However, when you install the **x64** version of .NET SDK, it's installed to the _/usr/local/share/dotnet/x64/dotnet/_ folder.

#### Path conflicts

The **x64** .NET SDK installs to its own directory, as described in the previous section. This allows the Arm64 and x64 versions of the .NET SDK to exist on the same machine. However, any **x64** SDK prior to .NET 6 isn't supported and installs to the same location as the Arm64 version, the _/usr/local/share/dotnet/_ folder. If you want to install an unsupported x64 SDK, you need to first uninstall the Arm64 version. The opposite is also true, you need to uninstall the unsupported x64 SDK to install the Arm64 version.

#### Path variables

Environment variables that add .NET to system path, such as the `PATH` variable, might need to be changed if you have both the x64 and Arm64 versions of the .NET 6 SDK installed. Additionally, some tools rely on the `DOTNET_ROOT` environment variable, which would also need to be updated to point to the appropriate .NET 6 SDK installation folder.

### System.Drawing.Common and libgdiplus

.NET applications that use the `System.Drawing.Common` assembly require `libgdiplus` to be installed.

An easy way to obtain `libgdiplus` is by using the [Homebrew ("brew")](https://brew.sh/) package manager for macOS. After installing *brew*, install `libgdiplus` by running the following commands in the terminal:

```console
brew update
brew install mono-libgdiplus
```

## Related content

- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-macos).
- [Working with macOS Catalina notarization](macos-notarization-issues.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).

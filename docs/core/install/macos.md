---
title: Install .NET on macOS
description: Learn about which versions of .NET SDK and .NET Runtime are supported, and how to install .NET on macOS.
author: adegeo
ms.author: adegeo
ms.topic: install-set-up-deploy
ms.date: 11/11/2024
ms.custom: linux-related-content

#customer intent: As a user or developer, I want to know which versions of .NET are supported on macOS. I also need to know how to install .NET on macOS.

---

# Install .NET on macOS

> [!div class="op_single_selector"]
>
> - [Install on Windows](windows.md)
> - [Install on macOS](macos.md)
> - [Install on Linux](linux.md)

This article teaches you about which versions of .NET are supported on macOS, how to install .NET, and what the difference is between the SDK and runtime.

The latest version of .NET is 9.

> [!div class="button"]
> [Download .NET](https://dotnet.microsoft.com/download/dotnet)

## Supported versions

The following table lists the supported .NET releases, and which macOS they're supported on. These versions remain supported until either the version of [.NET reaches end-of-support](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) or the version of macOS is no longer supported.

| macOS Version          | .NET     |
|------------------------|----------|
| macOS 15 "Sequoia"     | 9.0, 8.0 |
| macOS 14 "Sonoma"      | 9.0, 8.0 |
| macOS 13 "Ventura"     | 9.0, 8.0 |

[!INCLUDE [versions-not-supported](includes/versions-not-supported.md)]

## Runtime or SDK

The **runtime** is used to run apps created with .NET. When an app author publishes an app, they can include the runtime with their app. If they don't include the runtime, it's up to the user to install the correct runtime.

There are two runtimes you can install on macOS, and both are included with the SDK.

- _ASP.NET Core Runtime_\
  Runs ASP.NET Core apps. Includes the .NET runtime. **Not available as an installer.**

- _.NET Runtime_\
  This runs normal .NET apps, but not specialized apps, such as apps built on ASP.NET Core.

The **SDK** is used to build and publish .NET apps and libraries. The latest SDK supports building apps for previous versions of .NET. In normal circumstances, you would only need the latest SDK installed.

Installing the SDK includes both the standard .NET Runtime and the ASP.NET Core Runtime. For example, if you have .NET SDK 9.0 installed, then .NET Runtime 9.0 and ASP.NET Core 9.0 Runtime are both installed. However, any other runtime version wouldn't be installed with the SDK and would require you to install it separately.

## Choose how to install .NET

There are different ways to install .NET, and some products might manage their own version of .NET. If you install .NET through software that manages its own version of .NET, it might not be enabled system-wide. Make sure you understand the implications of installing .NET through other software.

If you're unsure which method you should choose after reviewing the lists in the following sections, you probably want to use the [.NET Installer package](#install-net).

### Developers

- [Visual Studio Code - C# Dev Kit](#install-net-for-visual-studio-code)

  Install the **C# Dev Kit** extension for Visual Studio Code to develop .NET apps. The extension can use an already installed SDK or install one for you.

### Users and Developers

- [.NET Installer](#install-net)

  Use the standalone installer to install .NET. This method is the typical way to install .NET on your developer or user machine.

- [Install .NET with a script](#install-net-with-a-script)

  A bash script that can automate the install of the SDK or Runtime. You can choose which version of .NET to install.

- [Install .NET manually](#install-net-manually)

  Use this installation method when you need to install .NET to a specific folder, and run it apart from other copies of .NET.

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

      This section contains the runtime downloads. Notice that links for the **Installers** column in the **macOS** row are empty! This section is empty because the **ASP.NET Core Runtime**, is only provided in the SDK, or through [binary installation](#install-net-manually).

      Scroll further down to find the standard **.NET Runtime** for download.

      :::image type="content" source="media/macos/runtime-links.png" alt-text="A screenshot showing just the .NET Runtime download table from the .NET download website. The macOS row is highlighted with a red box.":::

      - If you're running an Apple processor, such as an **M1** or an **M3 Pro**, select **Arm64**.
      - If you're running an Intel processor, select **x64**.

01. Once the download completes, open it.
01. Follow the steps in the Installer.

    :::image type="content" source="media/macos/installer.png" alt-text="A screenshot showing just the .NET installer running on macOS.":::

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

    :::image type="content" source="media/macos/manual-download-page.png" alt-text="The .NET download website showing the SDK download links. The SDK header is highlighted with a red box. The box has an arrow pointing down to the macOS section.":::

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
01. Navigate to a folder where you want to download the script, such as _~/Downloads_.
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

Visual Studio Code is a powerful and lightweight source code editor that runs on your desktop. Visual Studio Code can use the SDK already installed on your system. Additionally, the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension will install .NET for you if it's not already installed.

For instructions on installing .NET through Visual Studio Code, see [Getting Started with C# in VS Code](https://code.visualstudio.com/docs/csharp/get-started).

## Notarization

Software created for macOS that's distributed with a Developer ID must be notarized, including apps made with .NET.

If you run a non-notarized app, an error window similar to the following image is displayed:

![macOS Catalina notarization alert](media/dependencies/macos-notarized-pkg-warning.png)

For more information about how enforced-notarization affects .NET (and your .NET apps), see [Working with macOS Catalina Notarization](macos-notarization-issues.md).

## Validation

[!INCLUDE [verify-download-intro](includes/verify-download-intro.md)]

[!INCLUDE [verify-download-macos-linux](includes/verify-download-macos-linux.md)]

## Arm-based Macs

The following sections describe things you should consider when installing .NET on an Arm-based Mac.

<!-- This section is mirrored in the windows.md file. Changes here should be applied there -->

### Path differences

On an Arm-based Mac, all Arm64 versions of .NET are installed to the normal _/usr/local/share/dotnet/_ folder. However, when you install the **x64** version of .NET SDK, it's installed to the _/usr/local/share/dotnet/x64/dotnet/_ folder.

### Path variables

Environment variables that add .NET to system path, such as the `PATH` variable, might need to be changed if you have both the x64 and Arm64 versions of the .NET SDK installed. Additionally, some tools rely on the `DOTNET_ROOT` environment variable, which would also need to be updated to point to the appropriate .NET SDK installation folder.

## Troubleshooting

The following sections are available to help troubleshoot issues:

- [Arm-based Macs](#arm-based-macs)
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

## Related content

- [How to check if .NET is already installed](how-to-detect-installed-versions.md?pivots=os-macos).
- [Working with macOS Catalina notarization](macos-notarization-issues.md).
- [Tutorial: Create a new app with Visual Studio Code](../tutorials/with-visual-studio-code.md).
- [Tutorial: Containerize a .NET app](../docker/build-container.md).

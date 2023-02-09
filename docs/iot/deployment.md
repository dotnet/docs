---
title: Deploy .NET apps to Raspberry Pi
description: Learn how to deploy .NET apps to Raspberry Pi.
author: camsoper
ms.author: casoper
ms.date: 10/07/2022
ms.topic: how-to
ms.prod: dotnet
---

# Deploy .NET apps to Raspberry Pi

Deployment of .NET apps to Raspberry Pi is identical to that of any other platform. Your app can run as *self-contained* or *framework-dependent* deployment modes. There are advantages to each strategy. For more information, see [.NET application publishing overview](../core/deploying/index.md).

## Deploying a framework-dependent app

:::image type="content" source="media/framework-dependent-animation.gif" alt-text="Animated GIF showing a diagram of framework-dependent deployment. The SDK creates the assemblies, which require the .NET runtime on the target device.":::

To deploy your app as a framework-dependent app, complete the following steps:

1. [!INCLUDE [ensure-ssh](includes/ensure-ssh.md)]

1. Install .NET on the Raspberry Pi using the [dotnet-install scripts](../core/tools/dotnet-install-script.md). Complete the following steps from a Bash prompt on the Raspberry Pi (local or SSH):
    1. Run the following command to install .NET:

        ```bash
        curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel STS
        ```

        > [!NOTE]
        > This installs the latest version. If you need a specific version, replace the `--channel STS` parameter with `--version <VERSION>`, where `<VERSION>` is the specific build version.

    1. To simplify path resolution, add a `DOTNET_ROOT` environment variable and add the *.dotnet* directory to `$PATH` with the following commands:

        ```bash
        echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
        echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
        source ~/.bashrc
        ```

    1. Verify the .NET installation with the following command:

        ```dotnetcli
        dotnet --version
        ```

        Verify the displayed version matches the version you installed.

1. Publish the app on the development computer as follows, depending on development environment.
    - If using **Visual Studio**, [deploy the app to a local folder](/visualstudio/deployment/quickstart-deploy-to-local-folder). Before publishing, select **Edit** in the publish profile summary and select the **Settings** tab. Ensure that **Deployment mode** is set to *Framework-dependent* and **Target runtime** is set to *Portable*.
    - If using the **.NET CLI**, use the [dotnet publish](../core/tools/dotnet-publish.md) command. No additional arguments are required.

1. [!INCLUDE [sftp-client](includes/sftp-client.md)]

1. From a Bash prompt on the Raspberry Pi (local or SSH), run the app. To do this, set the deployment folder as the current directory and execute the following command (where *HelloWorld.dll* is the entry point of the app):

    ```dotnetcli
    dotnet HelloWorld.dll
    ```

## Deploying a self-contained app

:::image type="content" source="media/self-contained-animation.gif" alt-text="Animated GIF showing a diagram of self-contained deployment. The SDK creates the assemblies bundled with the .NET runtime. Consequently, there are no dependencies required on the target device.":::

To deploy your app as a self-contained app, complete the following steps:

1. [!INCLUDE [ensure-ssh](includes/ensure-ssh.md)]

1. Publish the app on the development computer as follows, depending on development environment.
    - If using **Visual Studio**, [deploy the app to a local folder](/visualstudio/deployment/quickstart-deploy-to-local-folder). Before publishing, select **Edit** in the publish profile summary and select the **Settings** tab. Ensure that **Deployment mode** is set to *Self-contained* and **Target runtime** is set to *linux-arm64*.
    - If using the **.NET CLI**, use the [dotnet publish](../core/tools/dotnet-publish.md) command with the `--runtime linux-arm64` and `--self-contained` arguments:

        ```dotnetcli
        dotnet publish --runtime linux-arm64 --self-contained
        ```

    > [!IMPORTANT]
    > If you're using a 32-bit OS, you need to target the `linux-arm` runtime.

1. [!INCLUDE [sftp-client](includes/sftp-client.md)]

1. From a Bash prompt on the Raspberry Pi (local or SSH), run the app. To do this, set the current directory to the deployment location and complete the following steps:
    1. Give the executable *execute* permission (where `HelloWorld` is the executable file name).

        ```bash
        chmod +x HelloWorld
        ```

    1. Run the executable.

        ```bash
        ./HelloWorld
        ```

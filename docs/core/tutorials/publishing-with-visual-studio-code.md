---
title: Publish a .NET console application using Visual Studio Code
description: Learn how to use Visual Studio Code and the .NET CLI to create the set of files that are needed to run a .NET application.
ms.date: 01/28/2026
zone_pivot_groups: code-editor-set-one
---
# Tutorial: Publish a .NET console application using Visual Studio Code

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run an application. To deploy the files, copy them to the target machine.

The .NET CLI is used to publish the app.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Publish the app

::: zone pivot="vscode"

1. Start Visual Studio Code.

1. Open the *HelloWorld* project folder that you created in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

1. Choose **View** > **Terminal** from the main menu.

   The terminal opens in the *HelloWorld* folder.

1. Run the following command:

   ```dotnetcli
   dotnet publish
   ```

   The default build configuration is *Release*, which is appropriate for a deployed site running in production. The output from the Release build configuration has minimal symbolic debug information and is fully optimized.

   The command output is similar to the following example:

   ```output
   Restore complete (1.1s)
     HelloWorld net10.0 succeeded (7.8s) → bin\Release\net10.0\publish\

   Build succeeded in 10.3s
   ```

::: zone-end

::: zone pivot="codespaces"

1. Open your GitHub Codespace that you created in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

1. Add the following line of code to the top of *HelloWorld.cs*:

    ```csharp
    #:property PublishAot=false
    ```

   This property directive, disables native ahead-of-time (AOT) compilation and the app will use the standard just-in-time (JIT) compiler at runtime. The published output will be framework-dependent.

1. In the terminal, make sure you're in the *tutorials* folder.

1. Run the following command:

   ```dotnetcli
   dotnet publish HelloWorld.cs
   ```

   The command creates an independent executable.

   The command output is similar to the following example:

   ```output
   Restore complete (0.5s)
     HelloWorld net10.0 succeeded (4.0s) → artifacts\HelloWorld\

   Build succeeded in 5.1s
   ```

::: zone-end

## Inspect the files

::: zone pivot="vscode"

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on a machine that has the .NET runtime installed. To run the published app you can use the executable file or run the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. Select the **Explorer** in the left navigation bar.

1. Expand *bin/Release/net10.0/publish*.

   :::image type="content" source="media/publishing-with-visual-studio-code/published-files-output.png" alt-text="Explorer showing published files":::

   As the image shows, the published output includes the following files:

   - *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/4af56f867f2f638b4562c3b8432d70f7b09577b3/Documentation/specs/runtime-configuration-file.md).

   - *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/index.md#cross-platform-dll-deployment) version of the application. To run this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   - *HelloWorld.exe* (*HelloWorld* on Linux or macOS.)

      This is the [framework-dependent executable](../deploying/index.md#framework-dependent-deployment) version of the application. The file is operating-system-specific.

   - *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   - *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../runtime-config/index.md#runtimeconfigjson).

::: zone-end

::: zone pivot="codespaces"

For a single-file application, the publishing process creates an artifacts directory with a compiled assembly file. The published application can be run using the `dotnet` command.

In the following steps, you'll look at the files created by the publish process.

1. Select the **Explorer** in the left navigation bar.

1. Expand *artifacts/HelloWorld*.

   :::image type="content" source="media/publishing-with-visual-studio-code/codespaces-published-files-output.png" alt-text="Explorer showing published files":::

   As the image shows, the published output includes the following files:

   - *HelloWorld*

      This is the [framework-dependent executable](../deploying/index.md#framework-dependent-deployment) version of the application. The file is operating-system-specific. Codespaces runs on Linux, so this a Linux executable.

   - *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/4af56f867f2f638b4562c3b8432d70f7b09577b3/Documentation/specs/runtime-configuration-file.md).

   - *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/index.md#cross-platform-dll-deployment) version of the application. To run this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   - *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   - *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../runtime-config/index.md#runtimeconfigjson).

   Right-click and select **Download...** to download files from Codespaces to your local computer.

::: zone-end

## Run the published app

::: zone pivot="vscode"

1. In **Explorer**, right-click the *publish* folder (<kbd>Ctrl</kbd>-click on macOS), and select **Open in Integrated Terminal**.

   :::image type="content" source="media/publishing-with-visual-studio-code/open-in-terminal.png" alt-text="Context menu showing Open in Terminal":::

1. On Windows or Linux, run the app by using the executable.

   1. On Windows, enter `.\HelloWorld.exe` and press <kbd>Enter</kbd>.

   1. On Linux, enter `./HelloWorld` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press <kbd>Enter</kbd> to exit.

1. On any platform, run the app by using the  [`dotnet`](../tools/dotnet.md) command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press <kbd>Enter</kbd> to exit.

::: zone-end

::: zone pivot="codespaces"

1. In **Explorer**, right-click the *artifacts/HelloWorld* folder and select **Open in Integrated Terminal**.

1. Run the app by using the executable. Enter `./HelloWorld` and then press <kbd>Enter</kbd>.

1. Enter a name in response to the prompt, and press <kbd>Enter</kbd> to exit.

::: zone-end

## Additional resources

- [.NET application publishing overview](../deploying/index.md)
- [`dotnet publish`](../tools/dotnet-publish.md)
- [Use the .NET SDK in continuous integration (CI) environments](../../devops/dotnet-cli-and-continuous-integration.md)

::: zone pivot="codespaces"

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to explore more tutorials in this series, you can leave your Codespace provisioned. If you're ready to visit the [.NET site](https://dotnet.microsoft.com/download/dotnet) to download the .NET SDK, you can delete your Codespace. To delete your Codespace, open a browser window and navigate to [your Codespaces](https://github.com/codespaces). You see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace. Then select "delete".

::: zone-end

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET class library using Visual Studio Code](library-with-visual-studio-code.md)

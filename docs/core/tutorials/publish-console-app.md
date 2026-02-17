---
title: Publish a .NET console application
description: Learn how to publish a .NET console application using Visual Studio, Visual Studio Code, or the .NET CLI.
ms.date: 02/12/2026
ai-usage: ai-assisted
zone_pivot_groups: code-editor-set-one
---
# Tutorial: Publish a .NET console application

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run an application. To deploy the files, copy them to the target machine.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application](console-app.md).

## Publish the app

::: zone pivot="visualstudio"

1. Start Visual Studio.

1. Open the *HelloWorld* project that you created in [Create a .NET console application](console-app.md).

1. Make sure that Visual Studio is using the Release build configuration. If necessary, change the build configuration setting on the toolbar from **Debug** to **Release**.

   :::image type="content" source="media/publishing-with-visual-studio/use-release-configuration.png" alt-text="Visual Studio toolbar with release build selected.":::

1. Right-click on the **HelloWorld** project (not the HelloWorld solution) and select **Publish** from the menu.

   :::image type="content" source="media/publishing-with-visual-studio/publish-context-menu.png" alt-text="Visual Studio Publish context menu.":::

1. On the **Target** tab of the **Publish** page, select **Folder**, and then select **Next**.

   :::image type="content" source="media/publishing-with-visual-studio/pick-publish-target.png" alt-text="Pick a publish target in Visual Studio.":::

1. On the **Specific Target** tab of the **Publish** page, select **Folder**, and then select **Next**.

   :::image type="content" source="media/publishing-with-visual-studio/pick-specific-publish-target.png" alt-text="Pick the specific publish target in Visual Studio.":::

1. On the **Location** tab of the **Publish** page, select **Finish**.

   :::image type="content" source="media/publishing-with-visual-studio/publish-page-loc-tab.png" alt-text="Visual Studio Publish page Location tab.":::

1. On the **Publish profile creation progress** page, select **Close**.

1. On the **Publish** tab of the **Publish** window, select **Publish**.

   :::image type="content" source="media/publishing-with-visual-studio/publish-page.png" alt-text="Visual Studio Publish window.":::

::: zone-end

::: zone pivot="vscode"

1. Start Visual Studio Code.

1. Open the *HelloWorld* project folder that you created in [Create a .NET console application](console-app.md).

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

1. Open your GitHub Codespace that you created in [Create a .NET console application](console-app.md).

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

::: zone pivot="visualstudio"

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on a machine that has the .NET runtime installed. Users can run the published app by double-clicking the executable or issuing the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. In **Solution Explorer**, select **Show All Files**.

   :::image type="content" source="media/publishing-with-visual-studio/show-all-files.png" alt-text="Solution Explorer option to Show All Files.":::

1. In the project folder, expand *bin/Release/{net}/publish*. (Where {net} is the target framework folder, such as _net10.0_.)

   :::image type="content" source="media/publishing-with-visual-studio/published-files-output.png" alt-text="Solution Explorer showing published files.":::

   As the image shows, the published output includes the following files:

   - *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/85ca206d84633d658d7363894c4ea9d59e515c1a/Documentation/specs/runtime-configuration-file.md).

   - *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/index.md#cross-platform-dll-deployment) version of the application. To execute this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   - *HelloWorld.exe*

      This is the [framework-dependent executable](../deploying/index.md#framework-dependent-deployment) version of the application. To run it, enter `HelloWorld.exe` at a command prompt. The file is operating-system-specific.

   - *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   - *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../runtime-config/index.md#runtimeconfigjson).

::: zone-end

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

::: zone pivot="visualstudio"

1. In **Solution Explorer**, right-click the *publish* folder, and select **Copy Full Path**.

1. Open a command prompt and navigate to the *publish* folder. To do that, enter `cd` and then paste the full path. For example:

   ```console
   cd C:\Projects\HelloWorld\bin\Release\net10.0\publish\
   ```

1. Run the app by using the executable:

   1. Enter `HelloWorld.exe` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

1. Run the app by using the `dotnet` command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

::: zone-end

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

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to explore more tutorials in this series, you can leave your Codespace provisioned. If you're ready to visit the [.NET site](https://dotnet.microsoft.com/download/dotnet) to download the .NET SDK, you can delete your Codespace. To delete your Codespace, open a browser window and navigate to [your Codespaces](https://github.com/codespaces). You see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace. Then select "Delete".

::: zone-end

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET class library](console-app-class-library.md)

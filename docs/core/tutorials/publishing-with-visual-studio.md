---
title: Publish a .NET console application using Visual Studio
description: Learn how to use Visual Studio to create the set of files that are needed to run a .NET application.
ms.date: 09/10/2021
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
  - "vb"
ms.custom: "vs-dotnet"
recommendations: false
---
# Tutorial: Publish a .NET console application using Visual Studio

::: zone pivot="dotnet-6-0"

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run your application. To deploy the files, copy them to the target machine.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio](with-visual-studio.md).

## Publish the app

1. Start Visual Studio.

1. Open the *HelloWorld* project that you created in [Create a .NET console application using Visual Studio](with-visual-studio.md).

1. Make sure that Visual Studio is using the Release build configuration. If necessary, change the build configuration setting on the toolbar from **Debug** to **Release**.

   :::image type="content" source="media/publishing-with-visual-studio/visual-studio-toolbar-release.png" alt-text="Visual Studio toolbar with release build selected":::

1. Right-click on the **HelloWorld** project (not the HelloWorld solution) and select **Publish** from the menu.

   :::image type="content" source="media/publishing-with-visual-studio/publish-context-menu.png" alt-text="Visual Studio Publish context menu":::

1. On the **Target** tab of the **Publish** page, select **Folder**, and then select **Next**.

   :::image type="content" source="media/publishing-with-visual-studio/pick-publish-target.png" alt-text="Pick a publish target in Visual Studio":::

1. On the **Specific Target** tab of the **Publish** page, select **Folder**, and then select **Next**.

   :::image type="content" source="media/publishing-with-visual-studio/pick-specific-publish-target.png" alt-text="Pick the specific publish target in Visual Studio":::

1. On the **Location** tab of the **Publish** page, select **Finish**.

   :::image type="content" source="media/publishing-with-visual-studio/publish-page-loc-tab-net6.png" alt-text="Visual Studio Publish page Location tab":::

1. On the **Publish** tab of the **Publish** window, select **Publish**.

   :::image type="content" source="media/publishing-with-visual-studio/publish-page-net6.png" alt-text="Visual Studio Publish window":::

## Inspect the files

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on machine that has the .NET runtime installed. Users can run the published app by double-clicking the executable or issuing the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. In **Solution Explorer**, select **Show all files**.

1. In the project folder, expand *bin/Release/net5.0/publish*.

   :::image type="content" source="media/publishing-with-visual-studio/published-files-output-net6.png" alt-text="Solution Explorer showing published files":::

   As the image shows, the published output includes the following files:

   * *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/85ca206d84633d658d7363894c4ea9d59e515c1a/Documentation/specs/runtime-configuration-file.md).

   * *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/deploy-with-cli.md#framework-dependent-deployment) version of the application. To execute this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   * *HelloWorld.exe*

      This is the [framework-dependent executable](../deploying/deploy-with-cli.md#framework-dependent-executable) version of the application. To run it, enter `HelloWorld.exe` at a command prompt. The file is operating-system-specific.

   * *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   * *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../run-time-config/index.md#runtimeconfigjson).

## Run the published app

1. In **Solution Explorer**, right-click the *publish* folder, and select **Copy Full Path**.

1. Open a command prompt and navigate to the *publish* folder. To do that, enter `cd` and then paste the full path. For example:

   ```console
   cd C:\Projects\HelloWorld\bin\Release\net6.0\publish\
   ```

1. Run the app by using the executable:

   1. Enter `HelloWorld.exe` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

1. Run the app by using the `dotnet` command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

## Additional resources

- [.NET application deployment](../deploying/index.md)

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET class library using Visual Studio](library-with-visual-studio.md)

::: zone-end

::: zone pivot="dotnet-5-0"

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run your application. To deploy the files, copy them to the target machine.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio](with-visual-studio.md).

## Publish the app

1. Start Visual Studio.

1. Open the *HelloWorld* project that you created in [Create a .NET console application using Visual Studio](with-visual-studio.md).

1. Make sure that Visual Studio is using the Release build configuration. If necessary, change the build configuration setting on the toolbar from **Debug** to **Release**.

   :::image type="content" source="media/publishing-with-visual-studio/visual-studio-toolbar-release.png" alt-text="Visual Studio toolbar with release build selected":::

1. Right-click on the **HelloWorld** project (not the HelloWorld solution) and select **Publish** from the menu.

   :::image type="content" source="media/publishing-with-visual-studio/publish-context-menu.png" alt-text="Visual Studio Publish context menu":::

1. On the **Target** tab of the **Publish** page, select **Folder**, and then select **Next**.

   :::image type="content" source="media/publishing-with-visual-studio/pick-publish-target.png" alt-text="Pick a publish target in Visual Studio":::

1. On the **Specific Target** tab of the **Publish** page, select **Folder**, and then select **Next**.

   :::image type="content" source="media/publishing-with-visual-studio/pick-specific-publish-target.png" alt-text="Pick the specific publish target in Visual Studio":::

1. On the **Location** tab of the **Publish** page, select **Finish**.

   :::image type="content" source="media/publishing-with-visual-studio/publish-page-loc-tab.png" alt-text="Visual Studio Publish page Location tab":::

1. On the **Publish** tab of the **Publish** window, select **Publish**.

   :::image type="content" source="media/publishing-with-visual-studio/publish-page.png" alt-text="Visual Studio Publish window":::

## Inspect the files

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on machine that has the .NET runtime installed. Users can run the published app by double-clicking the executable or issuing the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. In **Solution Explorer**, select **Show all files**.

1. In the project folder, expand *bin/Release/net5.0/publish*.

   :::image type="content" source="media/publishing-with-visual-studio/published-files-output.png" alt-text="Solution Explorer showing published files":::

   As the image shows, the published output includes the following files:

   * *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/85ca206d84633d658d7363894c4ea9d59e515c1a/Documentation/specs/runtime-configuration-file.md).

   * *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/deploy-with-cli.md#framework-dependent-deployment) version of the application. To execute this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   * *HelloWorld.exe*

      This is the [framework-dependent executable](../deploying/deploy-with-cli.md#framework-dependent-executable) version of the application. To run it, enter `HelloWorld.exe` at a command prompt. The file is operating-system-specific.

   * *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   * *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../run-time-config/index.md#runtimeconfigjson).

## Run the published app

1. In **Solution Explorer**, right-click the *publish* folder, and select **Copy Full Path**.

1. Open a command prompt and navigate to the *publish* folder. To do that, enter `cd` and then paste the full path. For example:

   ```console
   cd C:\Projects\HelloWorld\bin\Release\net5.0\publish\
   ```

1. Run the app by using the executable:

   1. Enter `HelloWorld.exe` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

1. Run the app by using the `dotnet` command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

## Additional resources

- [.NET application deployment](../deploying/index.md)

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET class library using Visual Studio](library-with-visual-studio.md)

::: zone-end

::: zone pivot="dotnet-core-3-1"

This tutorial is only available for .NET 5 and .NET 6. Select one of those options at the top of the page.

::: zone-end

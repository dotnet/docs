---
title: Publish a .NET console application using Visual Studio for Mac
description: Learn how to use Visual Studio for Mac to create the set of files that are needed to run a .NET application.
ms.date: 11/30/2020
recommendations: false
---
# Tutorial: Publish a .NET console application using Visual Studio for Mac

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run your application. To deploy the files, copy them to the target machine.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio for Mac](with-visual-studio-mac.md).

## Publish the app

1. Start Visual Studio for Mac.

1. Open the HelloWorld project that you created in [Create a .NET console application using Visual Studio for Mac](with-visual-studio-mac.md).

1. Make sure that Visual Studio is building the Release version of your application. If necessary, change the build configuration setting on the toolbar from **Debug** to **Release**.

   :::image type="content" source="media/publishing-with-visual-studio-mac/toolbar-release.png" alt-text="Visual Studio toolbar with release build selected":::

1. From the main menu, choose **Build** > **Publish to Folder...**.

   :::image type="content" source="media/publishing-with-visual-studio-mac/publish-context-menu.png" alt-text="Visual Studio Publish context menu":::

1. In the **Publish to Folder** dialog, select **Publish**.

   :::image type="content" source="media/publishing-with-visual-studio-mac/publish-to-folder-dialog.png" alt-text="Visual Studio Publish to Folder dialog":::

   The publish folder opens, showing the files that were created.

   :::image type="content" source="media/publishing-with-visual-studio-mac/publish-folder.png" alt-text="publish folder":::

1. Select the gear icon, and select **Copy "publish" as Pathname** from the context menu.

   :::image type="content" source="media/publishing-with-visual-studio-mac/copy-path.png" alt-text="Copy path to publish folder":::

## Inspect the files

The publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on a machine that has the .NET runtime installed. Users can run the published app by running the `dotnet HelloWorld.dll` command from a command prompt.

As the preceding image shows, the published output includes the following files:

* *HelloWorld.deps.json*

  This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/85ca206d84633d658d7363894c4ea9d59e515c1a/Documentation/specs/runtime-configuration-file.md).

* *HelloWorld.dll*

   This is the [framework-dependent deployment](../deploying/deploy-with-cli.md#framework-dependent-deployment) version of the application. To execute this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

* *HelloWorld.pdb* (optional for deployment)

   This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

* *HelloWorld.runtimeconfig.json*

   This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../run-time-config/index.md#runtimeconfigjson).

## Run the published app

1. Open a terminal and navigate to the *publish* folder. To do that, enter `cd` and then paste the path that you copied earlier. For example:

   ```console
   cd ~/Projects/HelloWorld/HelloWorld/bin/Release/net5.0/publish/
   ```

1. Run the app by using the `dotnet` command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

## Additional resources

- [.NET application deployment](../deploying/index.md)

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET library using Visual Studio for Mac](library-with-visual-studio-mac.md)

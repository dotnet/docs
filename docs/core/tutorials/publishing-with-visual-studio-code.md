---
title: Publish a .NET Core console application using Visual Studio Code
description: Publishing creates the set of files that are needed to run a .NET Core application.
ms.date: 07/04/2020
---
# Tutorial: Publish a .NET Core console application using Visual Studio Code

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run an application. To deploy the files, copy them to the target machine.

The .NET Core CLI is used to publish the app, so you can follow this tutorial with a code editor other than Visual Studio Code if you prefer.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET Core console application in Visual Studio Code](with-visual-studio-code.md).

## Publish the app

1. Start Visual Studio Code.

1. Open the *HelloWorld* project folder that you created in [Create a .NET Core console application in Visual Studio Code](with-visual-studio-code.md).

1. Choose **View** > **Terminal** from the main menu.

   The terminal opens in the *HelloWorld* folder.

1. Run the following command:

   ```dotnetcli
   dotnet publish --configuration Release
   ```

   The default build configuration is *Debug*, so this command specifies the *Release* build configuration. The output from the Release build configuration has minimal symbolic debug information and is fully optimized.

   The command output is similar to the following example:

   ```output
   Microsoft (R) Build Engine version 16.6.0+5ff7b0c9e for .NET Core
   Copyright (C) Microsoft Corporation. All rights reserved.

   Determining projects to restore...
   All projects are up-to-date for restore.
   HelloWorld -> C:\Projects\HelloWorld\bin\Release\netcoreapp3.1\HelloWorld.dll
   HelloWorld -> C:\Projects\HelloWorld\bin\Release\netcoreapp3.1\publish\
   ```

## Inspect the files

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on a machine that has the .NET Core runtime installed. To run the published app you can use the executable file or run the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. Select the **Explorer** in the left navigation bar.

1. Expand *bin/Release/netcoreapp3.1/publish*.

   :::image type="content" source="media/publishing-with-visual-studio-code/published-files-output.png" alt-text="Explorer showing published files":::

   As the image shows, the published output includes the following files:

   * *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET Core components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/85ca206d84633d658d7363894c4ea9d59e515c1a/Documentation/specs/runtime-configuration-file.md).

   * *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/deploy-with-cli.md#framework-dependent-deployment) version of the application. To execute this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET Core runtime installed.

   * *HelloWorld.exe* (*HelloWorld* on Linux, not created on macOS.)

      This is the [framework-dependent executable](../deploying/deploy-with-cli.md#framework-dependent-executable) version of the application. The file is operating-system-specific.

   * *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   * *HelloWorld.runtimeconfig.json*

      This is the application's run-time configuration file. It identifies the version of .NET Core that your application was built to run on. You can also add configuration options to it. For more information, see [.NET Core run-time configuration settings](../run-time-config/index.md#runtimeconfigjson).

## Run the published app

1. In **Explorer**, right-click the *publish* folder (<kbd>Ctrl</kbd>-click on macOS), and select **Open in Terminal**.

   :::image type="content" source="media/publishing-with-visual-studio-code/open-in-terminal.png" alt-text="Context menu showing Open in Terminal":::

1. On Windows or Linux, run the app by using the executable.

   1. On Windows, enter `.\HelloWorld.exe` and press <kbd>Enter</kbd>.

   1. On Linux, enter `./HelloWorld` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

1. On any platform, run the app by using the  [`dotnet`](../tools/dotnet.md) command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

## Additional resources

- [.NET Core application deployment](../deploying/index.md)

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET Standard library in Visual Studio Code](library-with-visual-studio-code.md)

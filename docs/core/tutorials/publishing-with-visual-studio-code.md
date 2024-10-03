---
title: Publish a .NET console application using Visual Studio Code
description: Learn how to use Visual Studio Code and the .NET CLI to create the set of files that are needed to run a .NET application.
ms.date: 09/12/2024
zone_pivot_groups: dotnet-version
---
# Tutorial: Publish a .NET console application using Visual Studio Code

::: zone pivot="dotnet-8-0"

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run an application. To deploy the files, copy them to the target machine.

The .NET CLI is used to publish the app, so you can follow this tutorial with a code editor other than Visual Studio Code if you prefer.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Publish the app

1. Start Visual Studio Code.

1. Open the *HelloWorld* project folder that you created in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

1. Choose **View** > **Terminal** from the main menu.

   The terminal opens in the *HelloWorld* folder.

1. Run the following command:

   ```dotnetcli
   dotnet publish
   ```

   The default build configuration is *Release*, which is appropriate for a deployed site running in producction. The output from the Release build configuration has minimal symbolic debug information and is fully optimized.

   The command output is similar to the following example:

   ```output
   Microsoft (R) Build Engine version 17.8.0+b89cb5fde for .NET
   Copyright (C) Microsoft Corporation. All rights reserved.
     Determining projects to restore...
     All projects are up-to-date for restore.
     HelloWorld -> C:\Projects\HelloWorld\bin\Release\net8.0\HelloWorld.dll
     HelloWorld -> C:\Projects\HelloWorld\bin\Release\net8.0\publish\
   ```

## Inspect the files

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on a machine that has the .NET runtime installed. To run the published app you can use the executable file or run the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. Select the **Explorer** in the left navigation bar.

1. Expand *bin/Release/net8.0/publish*.

   :::image type="content" source="media/publishing-with-visual-studio-code/published-files-output-net8.png" alt-text="Explorer showing published files":::

   As the image shows, the published output includes the following files:

   - *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/4af56f867f2f638b4562c3b8432d70f7b09577b3/Documentation/specs/runtime-configuration-file.md).

   - *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/deploy-with-cli.md#framework-dependent-deployment) version of the application. To run this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   - *HelloWorld.exe* (*HelloWorld* on Linux or macOS.)

      This is the [framework-dependent executable](../deploying/deploy-with-cli.md#framework-dependent-executable) version of the application. The file is operating-system-specific.

   - *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   - *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../runtime-config/index.md#runtimeconfigjson).

## Run the published app

1. In **Explorer**, right-click the *publish* folder (<kbd>Ctrl</kbd>-click on macOS), and select **Open in Integrated Terminal**.

   :::image type="content" source="media/publishing-with-visual-studio-code/open-in-terminal.png" alt-text="Context menu showing Open in Terminal":::

1. On Windows or Linux, run the app by using the executable.

   1. On Windows, enter `.\HelloWorld.exe` and press <kbd>Enter</kbd>.

   1. On Linux, enter `./HelloWorld` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press <kbd>Enter</kbd> to exit.

1. On any platform, run the app by using the  [`dotnet`](../tools/dotnet.md) command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press <kbd>Enter</kbd> to exit.

## Additional resources

- [.NET application deployment](../deploying/index.md)
- [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md)
- [`dotnet publish`](../tools/dotnet-publish.md)
- [Use the .NET SDK in continuous integration (CI) environments](../../devops/dotnet-cli-and-continuous-integration.md)

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET class library using Visual Studio Code](library-with-visual-studio-code.md)

::: zone-end

::: zone pivot="dotnet-7-0"

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run an application. To deploy the files, copy them to the target machine.

The .NET CLI is used to publish the app, so you can follow this tutorial with a code editor other than Visual Studio Code if you prefer.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Publish the app

1. Start Visual Studio Code.

1. Open the *HelloWorld* project folder that you created in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

1. Choose **View** > **Terminal** from the main menu.

   The terminal opens in the *HelloWorld* folder.

1. Run the following command:

   ```dotnetcli
   dotnet publish --configuration Release
   ```

   The default build configuration is *Debug*, so this command specifies the *Release* build configuration. The output from the Release build configuration has minimal symbolic debug information and is fully optimized.

   The command output is similar to the following example:

   ```output
   Microsoft (R) Build Engine version 16.7.4+b89cb5fde for .NET
   Copyright (C) Microsoft Corporation. All rights reserved.
     Determining projects to restore...
     All projects are up-to-date for restore.
     HelloWorld -> C:\Projects\HelloWorld\bin\Release\net7.0\HelloWorld.dll
     HelloWorld -> C:\Projects\HelloWorld\bin\Release\net7.0\publish\
   ```

## Inspect the files

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on a machine that has the .NET runtime installed. To run the published app you can use the executable file or run the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. Select the **Explorer** in the left navigation bar.

1. Expand *bin/Release/net7.0/publish*.

   :::image type="content" source="media/publishing-with-visual-studio-code/published-files-output-net7.png" alt-text="Explorer showing published files":::

   As the image shows, the published output includes the following files:

   - *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/4af56f867f2f638b4562c3b8432d70f7b09577b3/Documentation/specs/runtime-configuration-file.md).

   - *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/deploy-with-cli.md#framework-dependent-deployment) version of the application. To run this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   - *HelloWorld.exe* (*HelloWorld* on Linux, not created on macOS.)

      This is the [framework-dependent executable](../deploying/deploy-with-cli.md#framework-dependent-executable) version of the application. The file is operating-system-specific.

   - *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   - *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../runtime-config/index.md#runtimeconfigjson).

## Run the published app

1. In **Explorer**, right-click the *publish* folder (<kbd>Ctrl</kbd>-click on macOS), and select **Open in Terminal**.

   :::image type="content" source="media/publishing-with-visual-studio-code/open-in-terminal.png" alt-text="Context menu showing Open in Terminal":::

1. On Windows or Linux, run the app by using the executable.

   1. On Windows, enter `.\HelloWorld.exe` and press <kbd>Enter</kbd>. On Windows with the Bash terminal, enter `./HelloWorld.exe`.

   1. On Linux, enter `./HelloWorld` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

1. On any platform, run the app by using the  [`dotnet`](../tools/dotnet.md) command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

## Additional resources

- [.NET application deployment](../deploying/index.md)
- [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md)
- [`dotnet publish`](../tools/dotnet-publish.md)
- [Use the .NET SDK in continuous integration (CI) environments](../../devops/dotnet-cli-and-continuous-integration.md)

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET class library using Visual Studio Code](library-with-visual-studio-code.md)

::: zone-end

::: zone pivot="dotnet-6-0"

This tutorial shows how to publish a console app so that other users can run it. Publishing creates the set of files that are needed to run an application. To deploy the files, copy them to the target machine.

The .NET CLI is used to publish the app, so you can follow this tutorial with a code editor other than Visual Studio Code if you prefer.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Publish the app

1. Start Visual Studio Code.

1. Open the *HelloWorld* project folder that you created in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

1. Choose **View** > **Terminal** from the main menu.

   The terminal opens in the *HelloWorld* folder.

1. Run the following command:

   ```dotnetcli
   dotnet publish --configuration Release
   ```

   The default build configuration is *Debug*, so this command specifies the *Release* build configuration. The output from the Release build configuration has minimal symbolic debug information and is fully optimized.

   The command output is similar to the following example:

   ```output
   Microsoft (R) Build Engine version 16.7.0+b89cb5fde for .NET
   Copyright (C) Microsoft Corporation. All rights reserved.
     Determining projects to restore...
     All projects are up-to-date for restore.
     HelloWorld -> C:\Projects\HelloWorld\bin\Release\net6.0\HelloWorld.dll
     HelloWorld -> C:\Projects\HelloWorld\bin\Release\net6.0\publish\
   ```

## Inspect the files

By default, the publishing process creates a framework-dependent deployment, which is a type of deployment where the published application runs on a machine that has the .NET runtime installed. To run the published app you can use the executable file or run the `dotnet HelloWorld.dll` command from a command prompt.

In the following steps, you'll look at the files created by the publish process.

1. Select the **Explorer** in the left navigation bar.

1. Expand *bin/Release/net6.0/publish*.

   :::image type="content" source="media/publishing-with-visual-studio-code/published-files-output-net6.png" alt-text="Explorer showing published files":::

   As the image shows, the published output includes the following files:

   - *HelloWorld.deps.json*

      This is the application's runtime dependencies file. It defines the .NET components and the libraries (including the dynamic link library that contains your application) needed to run the app. For more information, see [Runtime configuration files](https://github.com/dotnet/cli/blob/4af56f867f2f638b4562c3b8432d70f7b09577b3/Documentation/specs/runtime-configuration-file.md).

   - *HelloWorld.dll*

      This is the [framework-dependent deployment](../deploying/deploy-with-cli.md#framework-dependent-deployment) version of the application. To run this dynamic link library, enter `dotnet HelloWorld.dll` at a command prompt. This method of running the app works on any platform that has the .NET runtime installed.

   - *HelloWorld.exe* (*HelloWorld* on Linux, not created on macOS.)

      This is the [framework-dependent executable](../deploying/deploy-with-cli.md#framework-dependent-executable) version of the application. The file is operating-system-specific.

   - *HelloWorld.pdb* (optional for deployment)

      This is the debug symbols file. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

   - *HelloWorld.runtimeconfig.json*

      This is the application's runtime configuration file. It identifies the version of .NET that your application was built to run on. You can also add configuration options to it. For more information, see [.NET runtime configuration settings](../runtime-config/index.md#runtimeconfigjson).

## Run the published app

1. In **Explorer**, right-click the *publish* folder (<kbd>Ctrl</kbd>-click on macOS), and select **Open in Terminal**.

   :::image type="content" source="media/publishing-with-visual-studio-code/open-in-terminal.png" alt-text="Context menu showing Open in Terminal":::

1. Run the app by using the executable.

   1. On Windows, enter `.\HelloWorld.exe` and press <kbd>Enter</kbd>.

   1. On Linux or macOS, enter `./HelloWorld` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

1. On any platform, run the app by using the  [`dotnet`](../tools/dotnet.md) command:

   1. Enter `dotnet HelloWorld.dll` and press <kbd>Enter</kbd>.

   1. Enter a name in response to the prompt, and press any key to exit.

## Additional resources

- [.NET application deployment](../deploying/index.md)
- [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md)
- [`dotnet publish`](../tools/dotnet-publish.md)
- [Use the .NET SDK in continuous integration (CI) environments](../../devops/dotnet-cli-and-continuous-integration.md)

## Next steps

In this tutorial, you published a console app. In the next tutorial, you create a class library.

> [!div class="nextstepaction"]
> [Create a .NET class library using Visual Studio Code](library-with-visual-studio-code.md)

::: zone-end

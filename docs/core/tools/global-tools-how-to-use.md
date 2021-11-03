---
title: "Tutorial: Install and use a .NET global tool"
description: Learn how to install and use a .NET tool as a global tool.
ms.topic: tutorial
ms.date: 02/12/2020
recommendations: false
---

# Tutorial: Install and use a .NET global tool using the .NET CLI

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

This tutorial teaches you how to install and use a global tool. You use a tool that you create in the [first tutorial of this series](global-tools-how-to-create.md).

## Prerequisites

* Complete the [first tutorial of this series](global-tools-how-to-create.md).

## Use the tool as a global tool

1. Install the tool from the package by running the [dotnet tool install](dotnet-tool-install.md) command in the *microsoft.botsay* project folder:

   ```dotnetcli
   dotnet tool install --global --add-source ./nupkg microsoft.botsay
   ```

   The `--global` parameter tells the .NET CLI to install the tool binaries in a default location that is automatically added to the PATH environment variable.

   The `--add-source` parameter tells the .NET CLI to temporarily use the *./nupkg* directory as an additional source feed for NuGet packages. You gave your package a unique name to make sure that it will only be found in the *./nupkg* directory, not on the Nuget.org site.

   The output shows the command used to call the tool and the version installed:

   ```console
   You can invoke the tool using the following command: botsay
   Tool 'microsoft.botsay' (version '1.0.0') was successfully installed.
   ```

1. Invoke the tool:

   ```console
   botsay hello from the bot
   ```

   > [!NOTE]
   > If this command fails, you may need to open a new terminal to refresh the PATH.

1. Remove the tool by running the [dotnet tool uninstall](dotnet-tool-uninstall.md) command:

   ```dotnetcli
   dotnet tool uninstall -g microsoft.botsay
   ```

## Use the tool as a global tool installed in a custom location

1. Install the tool from the package.

   On Windows:

   ```dotnetcli
   dotnet tool install --tool-path c:\dotnet-tools --add-source ./nupkg microsoft.botsay
   ```

   On Linux or macOS:

   ```dotnetcli
   dotnet tool install --tool-path ~/bin --add-source ./nupkg microsoft.botsay
   ```

   The `--tool-path` parameter tells the .NET CLI to install the tool binaries in the specified location. If the directory doesn't exist, it is created. This directory is not automatically added to the PATH environment variable.

   The output shows the command used to call the tool and the version installed:

   ```console
   You can invoke the tool using the following command: botsay
   Tool 'microsoft.botsay' (version '1.0.0') was successfully installed.
   ```

1. Invoke the tool:

   On Windows:

   ```console
   c:\dotnet-tools\botsay hello from the bot
   ```

   On Linux or macOS:

   ```console
   ~/bin/botsay hello from the bot
   ```

1. Remove the tool by running the [dotnet tool uninstall](dotnet-tool-uninstall.md) command:

   On Windows:

   ```dotnetcli
   dotnet tool uninstall --tool-path c:\dotnet-tools microsoft.botsay
   ```

   On Linux or macOS:

   ```dotnetcli
   dotnet tool uninstall --tool-path ~/bin microsoft.botsay
   ```

## Troubleshoot

If you get an error message while following the tutorial, see [Troubleshoot .NET tool usage issues](troubleshoot-usage-issues.md).

## Next steps

In this tutorial, you installed and used a tool as a global tool. For more information about how to install and use global tools, see [Managing global tools](global-tools.md). To install and use the same tool as a local tool, advance to the next tutorial.

> [!div class="nextstepaction"]
> [Install and use local tools](local-tools-how-to-use.md)

---
title: How to install and use .NET Core a global tool
description: Learn how to install and use a .NET tool as a global tool.
author: tdykstra
ms.author: tdykstra
ms.date: 02/12/2020
---

# Install and use a .NET Core global tool using the .NET Core CLI

**This article applies to:** ✔️ .NET Core 3.x SDK

This tutorial teaches you how to install and use a global tool. You use a tool that you create in the [first tutorial of this series](global-tools-how-to-create.md).

## Prerequisites

* Complete the [first tutorial of this series](global-tools-how-to-create.md).

## Use the tool as a global tool

1. Install the tool from the package by running the [dotnet tool install](dotnet-tool-install.md) command in the *botsay* project folder:

   ```dotnetcli
   dotnet tool install --global --add-source ./nupkg botsay
   ```

   The `--global` parameter tells the .NET Core CLI to install the tool binaries in a default location that is automatically added to the PATH environment variable.

   The `--add-source` parameter tells the .NET Core CLI to temporarily use the `./nupkg` directory as an additional source feed for NuGet packages.

   The output shows the command used to call the tool and the version installed:

   ```console
   You can invoke the tool using the following command: botsay
   Tool 'botsay' (version '1.0.0') was successfully installed.
   ```

   > [!NOTE]
   > If the following step fails, you may need to open a new terminal to refresh the PATH.

1. Invoke the tool:

   ```dotnetcli
   botsay hello from the bot
   ```

1. Remove the tool by running the [dotnet tool uninstall](dotnet-tool-uninstall.md) command:

   ```dotnetcli
   dotnet tool uninstall -g botsay
   ```

## Use the tool as a global tool installed in a custom location

1. Install the tool from the package.

   On Windows:

   ```dotnetcli
   dotnet tool install --tool-path c:\dotnet-tools --add-source ./nupkg botsay
   ```

   On Linux or macOS:

   ```dotnetcli
   dotnet tool install --tool-path ~/bin --add-source ./nupkg botsay
   ```

   The `--tool-path` parameter tells the .NET Core CLI to install the tool binaries in the specified location. If the directory doesn't exist, it is created. This directory is not automatically added to the PATH environment variable.

   The output shows the command used to call the tool and the version installed:

   ```output
   You can invoke the tool using the following command: botsay
   Tool 'botsay' (version '1.0.0') was successfully installed.
   ```

1. Invoke the tool:

   On Windows:

   ```dotnetcli
   c:\dotnet-tools\botsay hello from the bot
   ```

   On Linux or macOS:

   ```dotnetcli
   ~/bin/botsay hello from the bot
   ```

1. Remove the tool by running the [dotnet tool uninstall](dotnet-tool-uninstall.md) command:

   On Windows:

   ```dotnetcli
   dotnet tool uninstall --tool-path c:\dotnet-tools botsay --add-source ./nupkg botsay
   ```

   On Linux or macOS:

   ```dotnetcli
   dotnet tool uninstall --tool-path ~/bin botsay
   ```

## Troubleshooting

If you get an error message while following the tutorial, see [Troubleshoot .NET Core tool usage issues](troubleshoot-usage-issues.md)

## Next steps

In this tutorial, you installed and used a tool as a global tool. To install and use the same tool as a local tool, advance to the next tutorial.

> [!div class="nextstepaction"]
> [Install and use local tools](local-tools-how-to-use.md)

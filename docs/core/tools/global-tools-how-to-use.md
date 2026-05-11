---
title: "Tutorial: Install and use a .NET global tool"
description: Learn how to install and use a .NET tool as a global tool.
ms.topic: tutorial
ms.date: 04/24/2026
---

# Tutorial: Install and use a .NET global tool using the .NET CLI

**This article applies to:** ✔️ .NET 8 SDK and later versions

This tutorial shows you how to install and use a global tool. The tool you use is the one you create in the [first tutorial of this series](global-tools-how-to-create.md).

## Prerequisites

* Complete the [first tutorial of this series](global-tools-how-to-create.md).
* .NET 10.0.100 SDK or later (for `dnx`) - optional but recommended.

## Run the tool without installation (recommended)

Starting with .NET 10.0.100, you can run .NET tools without permanent installation using [`dnx`](dotnet-tool-exec.md):

1. Run the tool directly using dnx (simplified syntax):

   ```dotnetcli
   dnx dotnet-env --add-source ./nupkg
   ```

    The `--add-source` parameter tells the .NET CLI to use the *./nupkg* directory as an additional source feed for NuGet packages when the tool isn't available on NuGet.org.

## Use the tool as a global tool (traditional installation)

If you prefer permanent installation for frequent use:

1. Install the tool from the package by running the [dotnet tool install](dotnet-tool-install.md) command in the *dotnet-env* project folder:

   ```dotnetcli
   dotnet tool install --global --add-source ./nupkg dotnet-env
   ```

   The `--global` parameter tells the .NET CLI to install the tool binaries in a default location that's automatically added to the `PATH` environment variable.

   The `--add-source` parameter tells the .NET CLI to temporarily use the *./nupkg* directory as an additional source feed for NuGet packages. You gave your package a unique name to make sure it's only found in the *./nupkg* directory, not on NuGet.org.

   The output shows the command used to call the tool and the version installed:

   ```console
   You can invoke the tool using the following command: dotnet-env
   Tool 'dotnet-env' (version '1.0.0') was successfully installed.
   ```

   [!INCLUDE[](includes/dotnet-tool-install-arch-options.md)]

1. Invoke the tool:

   ```console
   dotnet-env
   ```

   > [!NOTE]
   > If the command fails, open a new terminal to refresh the `PATH` environment variable.

1. Remove the tool by running the [dotnet tool uninstall](dotnet-tool-uninstall.md) command:

   ```dotnetcli
   dotnet tool uninstall -g dotnet-env
   ```

## Use the tool as a global tool installed in a custom location

1. Install the tool from the package.

   On Windows:

   ```dotnetcli
   dotnet tool install --tool-path c:\dotnet-tools --add-source ./nupkg dotnet-env
   ```

   On Linux or macOS:

   ```dotnetcli
   dotnet tool install --tool-path ~/bin --add-source ./nupkg dotnet-env
   ```

   The `--tool-path` parameter tells the .NET CLI to install the tool binaries in the specified location. If the directory doesn't exist, it's created. The directory isn't automatically added to the `PATH` environment variable.

   The output shows the command used to call the tool and the version installed:

   ```console
   You can invoke the tool using the following command: dotnet-env
   Tool 'dotnet-env' (version '1.0.0') was successfully installed.
   ```

1. Invoke the tool:

   On Windows:

   ```console
   c:\dotnet-tools\dotnet-env
   ```

   On Linux or macOS:

   ```console
   ~/bin/dotnet-env
   ```

1. Remove the tool by running the [dotnet tool uninstall](dotnet-tool-uninstall.md) command:

   On Windows:

   ```dotnetcli
   dotnet tool uninstall --tool-path c:\dotnet-tools dotnet-env
   ```

   On Linux or macOS:

   ```dotnetcli
   dotnet tool uninstall --tool-path ~/bin dotnet-env
   ```

## Troubleshoot

If you get an error message while following the tutorial, see [Troubleshoot .NET tool usage issues](troubleshoot-usage-issues.md).

## Next steps

In this tutorial, you installed and used a tool as a global tool. For more information on installing and using global tools, see [Managing global tools](global-tools.md). To install and use the same tool as a local tool, advance to the next tutorial.

> [!div class="nextstepaction"]
> [Install and use local tools](local-tools-how-to-use.md)

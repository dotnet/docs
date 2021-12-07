---
title: How to install the ML.NET Command-Line Interface (CLI) tool
description: Learn how to install, upgrade, downgrade, and uninstall the ML.NET Command-Line Interface (CLI) tool.
ms.date: 07/13/2021
ms.custom: mlnet-tooling
ms.topic: how-to
---

# How to install the ML.NET Command-Line Interface (CLI) tool

Learn how to install the ML.NET CLI (command-line interface) on Windows, Mac, or Linux.

The ML.NET CLI generates good quality ML.NET models and source code using automated machine learning (AutoML) and a training dataset.

> [!NOTE]
> This topic refers to ML.NET CLI and ML.NET AutoML, which are currently in Preview, and material may be subject to change.

## Pre-requisites

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1)

- (Optional) [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)

You can run the generated C# code projects with Visual Studio by pressing the `F5` key or with `dotnet run` (.NET CLI).

Note: If after installing .NET SDK the `dotnet tool` command is not working, sign out from Windows and sign in again.

## Install

The ML.NET CLI is installed like any other dotnet Global Tool. You use the `dotnet tool install` .NET CLI command.

The following example shows how to install the ML.NET CLI in the default NuGet feed location:

```dotnetcli
dotnet tool install -g mlnet
```

If the tool can't be installed (that is, if it is not available at the default NuGet feed), error messages are displayed. Check that the feeds you expected are being checked.

If installation is successful, a message is displayed showing the command used to call the tool and the version installed, similar to the following example:

```console
You can invoke the tool using the following command: mlnet
Tool 'mlnet' (version 'X.X.X') was successfully installed.
```

You can confirm the installation was successful by typing the following command:

```console
mlnet
```

You should see the help for available commands for the mlnet tool such as the 'classification' command.

> [!IMPORTANT]
> If you are running Linux or macOS, note that if you're using a console other than Bash (for example, zsh, which is the new default for macOS), then you'll need to give `mlnet` executable permissions and include `mlnet` to the system path. Instructions on how to do this should appear in the terminal when you install `mlnet` (or any global tool).
>
> Alternatively, you can try using the following command to run the mlnet tool:
>
> ```console
> ~/.dotnet/tools/mlnet
> ```

## Install a specific release version

If you're trying to install a pre-release version or a specific version of the tool, you can specify the [framework](../../standard/frameworks.md) using the following format:

```dotnetcli
dotnet tool install -g mlnet --framework <FRAMEWORK>
```

You can also check if the package is properly installed by typing the following command:

```dotnetcli
dotnet tool list -g
```

## Uninstall the CLI package

Type the following command to uninstall the package from your local machine:

```dotnetcli
dotnet tool uninstall mlnet -g
```

## Update the CLI package

Type the following command to update the package from your local machine:

```dotnetcli
dotnet tool update -g mlnet
```

## Installation directory

The ML.NET CLI can be installed in the default directory or in a specific location. The default directories are:

| OS          | Path                          |
|-------------|-------------------------------|
| Linux/macOS | `$HOME/.dotnet/tools`         |
| Windows     | `%USERPROFILE%\.dotnet\tools` |

These locations are added to the user's path when the SDK is first run, so Global Tools installed there can be called directly.

Note: the Global Tools are user-specific, not machine global. Being user-specific means you cannot install a Global Tool that is available to all users of the machine. The tool is only available for each user profile where the tool was installed.

Global Tools can also be installed in a specific directory. When installed in a specific directory, the user must ensure the command is available, by including that directory in the path, by calling the command with the directory specified, or calling the tool from within the specified directory.
In this case, the .NET CLI doesn't add this location automatically to the PATH environment variable.

## See also

- [ML.NET CLI overview](../automate-training-with-cli.md)
- [Tutorial: Analyze sentiment with the ML.NET CLI](../tutorials/sentiment-analysis-cli.md)
- [ML.NET CLI auto-train command reference guide](../reference/ml-net-cli-reference.md)
- [Telemetry in ML.NET CLI](../resources/ml-net-cli-telemetry.md)

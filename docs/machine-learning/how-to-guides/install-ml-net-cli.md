---
title: How to install the ML.NET Command-Line Interface (CLI) tool
description: Learn how to install, upgrade, downgrade, and uninstall the ML.NET Command-Line Interface (CLI) tool.
ms.date: 03/08/2023
ms.custom: mlnet-tooling
ms.topic: how-to
---

# How to install the ML.NET Command-Line Interface (CLI) tool

Learn how to install the ML.NET CLI (command-line interface) on Windows, Mac, or Linux.

The ML.NET CLI generates good quality ML.NET models and source code using automated machine learning (AutoML) and a training dataset.

> [!NOTE]
> This article refers to ML.NET CLI and ML.NET AutoML, which are currently in preview, and material is subject to change.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

- (Optional) [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

You can run the generated C# code projects with Visual Studio by pressing the <kbd>F5</kbd> key or with `dotnet run` (.NET CLI).

Note: If after installing .NET SDK the `dotnet tool` command is not working, sign out from Windows and sign in again.

## Install

The ML.NET CLI is installed like any other dotnet Global Tool. You use the `dotnet tool install --global` .NET CLI command.

The ML.NET CLI is available for Windows, macOS, and Linux. Depending on your processor architecture, choose the x64 or ARM version.

> [!NOTE]
> ARM based versions of the ML.NET CLI don't support image classification scenarios.

### [Windows](#tab/windows)

#### x64

```dotnetcli
dotnet tool install --global mlnet-win-x64
```

#### ARM

```dotnetcli
dotnet tool install --global mlnet-win-arm64
```

### [Mac](#tab/mac)

#### x64

```dotnetcli
dotnet tool install --global mlnet-osx-x64
```

#### ARM

```dotnetcli
dotnet tool install --global mlnet-osx-arm64
```

### [Linux](#tab/linux)

#### x64

```dotnetcli
dotnet tool install --global mlnet-linux-x64
```

#### ARM

```dotnetcli
dotnet tool install --global mlnet-linux-arm64
```

---

If the tool can't be installed (that is, if it is not available at the default NuGet feed), error messages are displayed. Check that the feeds you expected are being checked.

If installation is successful, a message is displayed showing the command used to call the tool and the version installed, similar to the following example:

```console
You can invoke the tool using the following command: mlnet
Tool 'mlnet-<OS>-<ARCH>' (version 'X.X.X') was successfully installed.
```

The `OS` and `ARCH` in this case should match the values for the operating system and processor architecture you selected when installing the ML.NET CLI.

You can confirm the installation was successful by typing the following command:

```console
mlnet
```

You should see the help for available commands for the mlnet tool such as the 'classification' command.

> [!IMPORTANT]
> If you're running Linux or macOS and using a console other than Bash (for example, zsh, which is the new default for macOS), then you'll need to give `mlnet` executable permissions and include `mlnet` to the system path. In general, you can do so with the following command:
>
> ```console
> chmod +x <PATH-TO-MLNET-CLI-EXECUTABLE>
> ```
>
> More detailed instructions on how to do this should appear in the terminal when you install `mlnet` (or any global tool).
>
> Alternatively, you can try using the following command to run the mlnet tool:
>
> ```console
> ~/.dotnet/tools/mlnet
> ```

## Install a specific release version

If you're trying to install a prerelease version or a specific version of the tool, you can specify the OS, processor architecture, and [framework](../../standard/frameworks.md) using the following format:

```dotnetcli
dotnet tool install -g mlnet-<OS>-<ARCH> --framework <FRAMEWORK>
```

You can also check if the package is properly installed by typing the following command:

```dotnetcli
dotnet tool list -g
```

## Uninstall the CLI package

To uninstall the ML.NET CLI use the package ID you can get from running the `dotnet tool list --global` command. Then, use the `dotnet tool uninstall --global` command.

### [Windows](#tab/windows)

#### x64

```dotnetcli
dotnet tool uninstall --global mlnet-win-x64
```

#### ARM

```dotnetcli
dotnet tool uninstall --global mlnet-win-arm64
```

### [Mac](#tab/mac)

#### x64

```dotnetcli
dotnet tool uninstall --global mlnet-osx-x64
```

#### ARM

```dotnetcli
dotnet tool uninstall --global mlnet-osx-arm64
```

### [Linux](#tab/linux)

#### x64

```dotnetcli
dotnet tool uninstall --global mlnet-linux-x64
```

#### ARM

```dotnetcli
dotnet tool uninstall --global mlnet-linux-arm64
```

---

## Update the CLI package

To update the ML.NET CLI use the package ID you can get from running the `dotnet tool list --global` command. Then, use the `dotnet tool update --global` command.

### [Windows](#tab/windows)

#### x64

```dotnetcli
dotnet tool update --global mlnet-win-x64
```

#### ARM

```dotnetcli
dotnet tool update --global mlnet-win-arm64
```

### [Mac](#tab/mac)

#### x64

```dotnetcli
dotnet tool update --global mlnet-osx-x64
```

#### ARM

```dotnetcli
dotnet tool update --global mlnet-osx-arm64
```

### [Linux](#tab/linux)

#### x64

```dotnetcli
dotnet tool update --global mlnet-linux-x64
```

#### ARM

```dotnetcli
dotnet tool update --global mlnet-linux-arm64
```

---

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

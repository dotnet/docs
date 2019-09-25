---
title: Troubleshoot .NET Core tool usage issues
description: Discover the common issues when running .NET Core tools and possible solutions.
author: kdollard
ms.date: 09/23/2019
---

# Troubleshoot .NET Core tool usage issues

You might come across issues when trying to install or run a .NET Core tool, which can be a global tool or a local tool. This article describes the common root causes and some possible solutions.

## Installed .NET Core tool fails to run

When a .NET Core tool fails to run, most likely you ran into one of the following issues:

* The executable file for the tool wasn't found.
* The correct version of the .NET Core runtime wasn't found. 

### Executable file not found

If the executable file isn't found, you'll see a message similar to the following:

```
Could not execute because the specified command or file was not found.
Possible reasons for this include:
  * You misspelled a built-in dotnet command.
  * You intended to execute a .NET Core program, but dotnet-xyz does not exist.
  * You intended to run a global tool, but a dotnet-prefixed executable with this name could not be found on the PATH.
```

The name of the executable determines how you invoke the tool. The following table describes the format:

| Executable name format  | Invocation format   |
|-------------------------|---------------------|
| `dotnet-<toolName>.exe` | `dotnet <toolName>` |
| `<toolName>.exe`        | `<toolName>`        |

* Global tools

    Global tools can be installed in the default directory or in a specific location. The default directories are:

    | OS          | Path                          |
    |-------------|-------------------------------|
    | Linux/macOS | `$HOME/.dotnet/tools`         |
    | Windows     | `%USERPROFILE%\.dotnet\tools` |

    If you're trying to run a global tool, check that the `PATH` environment variable on your machine contains the path where you installed the global tool and that the executable is in that path.

    The .NET Core CLI tries to add the default locations to the PATH environment variable on its first usage. However, there are a couple of scenarios where the location might not be added to PATH automatically, such as:

  * If you've set the `DOTNET_SKIP_FIRST_TIME_EXPERIENCE` environment variable.
  * On macOS, if you've installed the .NET Core SDK using *.tar.gz* files and not *.pkg*.
  * On Linux, you need to edit the shell environment file to configure the PATH.

  For more information about global tools, see [.NET Core Global Tools overview](global-tools.md).
* Local tools

  If you're trying to run a local tool, verify that there's a manifest file called *dotnet-tools.json* in the current directory or any of its parent directories. This file can also live under a folder named *.config* anywhere in the project folder hierarchy, instead of the root folder. If *dotnet-tools.json* exists, open it and check for the tool you're trying to run. If the file doesn't contain an entry for `"isRoot": true`, then also check further up the file hierarchy for additional tool manifest files.

    If you're trying to run a .NET Core tool that was installed with a specified path, you need to include that path when using the tool. An example of using a tool-path installed tool is:

   ```console
   ..\<toolDirectory>\dotnet-<toolName>
    ```

### Runtime not found

.NET Core tools are [framework-dependent applications](../deploying/index.md#framework-dependent-deployments-fdd), which means they rely on a .NET Core runtime installed on your machine. If the expected runtime isn't found, they follow normal .NET Core runtime roll-forward rules such as:

* An application rolls forward to the highest patch release of the specified major and minor version.
* If there's no matching runtime with a matching major and minor version number, the next higher minor version is used.
* Roll forward doesn't occur between preview versions of the runtime or between preview versions and release versions. So, .NET Core tools created using preview versions must be rebuilt and republished by the author and reinstalled.

Roll-forward won't occur by default in two common scenarios:

* Only lower versions of the runtime are available. Roll-forward only selects later versions of the runtime.
* Only higher major versions of the runtime are available. Roll-forward doesn't cross major version boundaries.

If an application can't find an appropriate runtime, it fails to run and reports an error.

You can find out which .NET Core runtimes are installed on your machine using one of the following commands:

```dotnetcli
dotnet --list-runtimes
dotnet --info
```

If you think the tool should support the runtime version you currently have installed, you can contact the tool author and see if they can update the version number or multi-target. Once they've recompiled and republished their tool package to NuGet with an updated version number, you can update your copy. While that doesn't happen, the quickest solution for you is to install a version of the runtime that would work with the tool you're trying to run. To download a specific .NET Core runtime version, visit the [.NET Core download page](https://dotnet.microsoft.com/download/dotnet-core).

If you install the .NET Core SDK to a non-default location, you need to set the environment variable `DOTNET_ROOT` to the directory that contains the `dotnet` executable.

## .NET Core tool installation fails

There are a number of reasons the installation of a .NET Core global or local tool may fail. When the tool installation fails, you'll see a message similar to following one:

```
Tool '{0}' failed to install. This failure may have been caused by:

* You are attempting to install a preview release and did not use the --version option to specify the version.
* A package by this name was found, but it was not a .NET Core tool.
* The required NuGet feed cannot be accessed, perhaps because of an Internet connection problem.
* You mistyped the name of the tool.

For more reasons, including package naming enforcement, visit https://aka.ms/failure-installing-tool
```

To help diagnose these failures, NuGet messages are shown directly to the user, along with the previous message. The NuGet message may help you identify the problem.

### Package naming enforcement

Microsoft has changed its guidance on the Package ID for tools, resulting in a number of tools not being found with the predicted name. The new guidance is that all Microsoft tools be prefixed with "Microsoft." This prefix is reserved and can only be used for packages signed with a Microsoft authorized certificate.

During the transition, some Microsoft tools will have the old form of the package ID, while others will have the new form:

```dotnetcli
dotnet tool install -g Microsoft.<toolName>
dotnet tool install -g <toolName>
```

As package IDs are updated, you'll need to change to the new package ID to get the latest updates. Packages with the simplified tool name will be deprecated.

### Preview releases

* You're attempting to install a preview release and didn't use the `--version` option to specify the version.

.NET Core tools that are in preview must be specified with a portion of the name to indicate that they are in preview. You don't need to include the entire preview. Assuming the version numbers are in the expected format, you can use something like the following example:

```dotnetcli
dotnet tool install -g --version 1.1.0-pre <toolName>
```

> [!NOTE]
> The .NET Core CLI team is planning to add a `--preview` switch in a future release to make this easier.

### Package isn't a .NET Core tool

* A NuGet package by this name was found, but it wasn't a .NET Core tool.

If you try to install a NuGet package that is a regular NuGet package and not a .NET Core tool, you'll see an error similar to the following:

`NU1212: Invalid project-package combination for `<ToolName>`. DotnetToolReference project style can only contain references of the DotnetTool type.`

### NuGet feed can't be accessed

* The required NuGet feed can't be accessed, perhaps because of an Internet connection problem.

Tool installation requires access to the NuGet feed that contains the tool package. It fails if the feed isn't available. You can alter feeds with `nuget.config`, request a specific `nuget.config` file, or specify additional feeds with the `--add-source` switch. By default, NuGet throws an error for any feed that can't connect. The flag `--ignore-failed-sources` can skip these non-reachable sources.

### Package ID incorrect

* You mistyped the name of the tool.

A common reason for failure is that the tool name isn't correct. This can happen because of mistyping, or because the tool has moved or been deprecated. For tools on NuGet.org, one way to ensure you have the name correct is to search for the tool at NuGet.org and copy the installation command.
## See also
* [.NET Core Global Tools overview](global-tools.md)

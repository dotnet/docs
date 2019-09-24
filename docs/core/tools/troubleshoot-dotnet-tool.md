---
title: Troubleshooting .NET Core Tool Usage
description: .NET Core tools may come across issues during installation or when running the tool.
author: kdollard
ms.date: 09/23/2019
---

# Troubleshooting .NET Core Tool Usage

.NET Core tools may come across issues during installation or when running the tool.

## Installed .NET Core tool fails to run

The most likely issues when a .NET Core tool fails to run is that the executable for the tool cannot be found or that the correct version of the .NET Core Runtime can't be found. 

### Command or file was not found

If the executable file is not found, you will see a message similar to:

```
Could not execute because the specified command or file was not found.
Possible reasons for this include:
  * You misspelled a built-in dotnet command.
  * You intended to execute a .NET Core program, but dotnet-xyz does not exist.
  * You intended to run a global tool, but a dotnet-prefixed executable with this name could not be found on the PATH.
```

The executable for the tool may be named in the form `dotnet-<toolName>.exe`, in which case it can be called using `dotnet <toolName>`. It also may be in the form `<toolName>.exe`, in which case it is called using `<toolName>`. The executable may have been created by the tool author (for signed packaged shims) or when the tool is installed (not-signed).

If you are trying to run a .NET Core tool that was installed as a global tool, check that your PATH contains `%USERPROFILE%\.dotnet\tools` (Windows) `$HOME/.dotnet/tools` (mac/Linux) and that the executable is in that path.

If you are trying to run a .NET Core tool that was installed as a local tool, check that there is a manifest in the  current directory or parent directories with file named dotnet-tools.json or dotnet-tools.json under .config folder. If there is, open the file and check for the tool you are trying to run. If the file does not contain an entry for `"isRoot": true`, then also check further up the file hierarchy for additional tool manifest files.

If you are trying to run a .NET Core tool that was installed as a tool-path tool with a specified path, you will need to include that path when using the tool. An example of using a tool-path installed tool is:

```
..\<toolDirectory>\dotnet-<toolName>
```

### Runtime not found

.NET Core tools are normal [Framework Dependent Executables](https://docs.microsoft.com/dotnet/core/deploying/#framework-dependent-deployments-fdd). As such, they need a version of the .NET Core Runtime on your machine to run. In general, applications target a specific major/minor version of .NET Core and will run on that version if it is present. If it is not present on your machine, applications like .NET Core tools will roll forward to higher minor versions of the runtime within the same major version. Thus, tools targeting .NET Core 2.1 runtime will roll-forward to .NET Core 2.2 runtime.

Roll-forward will not occur by default in two common scenarios:

* Only lower versions of the runtime are available. Roll-forward only selects later versions of the runtime.
* Only higher major versions of the runtime are available. Roll-forward does not cross major version boundaries.

You can find out what .NET Core runtimes you have on your machine with either of the following: 

```
dotnet --list-runtimes
dotnet --info
```

You may request that the tool author multi-target to include the version of the runtime you have, particularly if you are on a higher major version like 3.0 and this would be helpful for many users of the tool. The quickest solution for you is to install an acceptable version of the runtime, such as the latest of .NET Core 2.1 or 2.2, which you can find at the [.NET Core download page](https://dotnet.microsoft.com/download).

If you install dotnet core SDK to a non-default location, for example installing via zip or tar.gz file. You need to set the environment variable `DOTNET_ROOT` to the directory contains dotnet executable.

## .NET Core tool installation fails

There are a number of reasons the installation of a .NET Core global or local tool may fail. When the tool fails, you will get a message similar to:

```
Tool '{0}' failed to install. This failure may have been caused by:

* You are attempting to install a preview release and did not use the --version option to specify the version.
* A package by this name was found, but it was not a .NET Core tool.
* The required NuGet feed cannot be accessed, perhaps because of an Internet connection problem.
* You mistyped the name of the tool.

For more reasons, including package naming enforcement, visit https://aka.ms/failure-installing-tool
```

In order to supply as much information as possible, NuGet messages are output directly to the user, along with the message above. This message may help you identify the problem. 

### Package naming enforcement

Microsoft has changed it's guidance on the Package Id for tools, resulting in a number of tools not being found with the predicted name. The new guidance is that all first party tools be prefixed by "Microsoft." This prefix is reserved and can only be used for packages signed with a Microsoft authorized certificate.

During the transition, some Microsoft tools will have the old form of the package Id, while others will have the new forms:

```
dotnet tool install -g Microsoft.<toolName>
dotnet tool install -g <toolName>
```

As package Ids are updated, you will need to change to the new package Id to get the latest updates. Packages with the simplified tool name will be deprecated.

### Preview releases

* You are attempting to install a preview release and did not use the --version option to specify the version.

.NET Core Tools that are in preview must be specified with a portion of the name to indicate that they are in preview. You do not need to include the entire preview. Assuming the version numbers are in the expected format you can use something like:

```
dotnet tool install -g --version 1.1.0-pre <toolName>
```

A --preview switch is in the backlog awaiting supporting infrastructure. 

### Package not a .NET Core tool

* A package by this name was found, but it was not a .NET Core tool.

If a package that needs to be a .NET Core tool. The error would contain message _NU1212: Invalid project-package combination for `<ToolName>`. DotnetToolReference project style can only contain references of the DotnetTool type_.


### NuGet feed cannot be accessed

* The required NuGet feed cannot be accessed, perhaps because of an Internet connection problem.

Tool installation requires access to the NuGet feed that contains the tool package. It will fail if the feed is not available. You can alter feeds with `nuget.config`, request a specific `nuget.config` file, or specify additional feeds with the `--add-source` switch. By default, nuget would error for any feed that cannot connect. The flag --ignore-failed-sources can skip these non-reachable sources.

### Package Id incorrect

* You mistyped the name of the tool.

A common reason for failure is that the tool name is not correct. This can happen because of mistyping, or because the tool has moved or been deprecated. For tools on NuGet.org, one way to ensure you have the name correct is to search for the tool at NuGet.org and copy the installation command.

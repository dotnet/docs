---
title: "Tutorial: Install and use .NET local tools"
description: Learn how to install and use a .NET tool as a local tool.
ms.topic: tutorial
ms.date: 05/06/2022
---

# Tutorial: Install and use a .NET local tool using the .NET CLI

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

This tutorial teaches you how to install and use a local tool. You use a tool that you create in the [first tutorial of this series](global-tools-how-to-create.md).

## Prerequisites

* Complete the [first tutorial of this series](global-tools-how-to-create.md).
* Install the .NET Core 2.1 runtime.

  For this tutorial you install and use a tool that targets .NET Core 2.1, so you need to have that runtime installed on your machine. To install the 2.1 runtime, go to the [.NET Core 2.1 download page](https://dotnet.microsoft.com/download/dotnet/2.1) and find the runtime installation link in the **Run apps - Runtime** column.

## Create a manifest file

To install a tool for local access only (for the current directory and subdirectories), it has to be added to a manifest file.

From the *microsoft.botsay* folder, navigate up one level to the *repository* folder:

```console
cd ..
```

Create a manifest file by running the [dotnet new](dotnet-new.md) command:

```dotnetcli
dotnet new tool-manifest
```

The output indicates successful creation of the file.

```console
The template "Dotnet local tool manifest file" was created successfully.
```

The *.config/dotnet-tools.json* file has no tools in it yet:

```json
{
  "version": 1,
  "isRoot": true,
  "tools": {}
}
```

The tools listed in a manifest file are available to the current directory and subdirectories. The current directory is the one that contains the *.config* directory with the manifest file.

When you use a CLI command that refers to a local tool, the SDK searches for a manifest file in the current directory and parent directories. If it finds a manifest file, but the file doesn't include the referenced tool, it continues the search up through parent directories. The search ends when it finds the referenced tool or it finds a manifest file with `isRoot` set to `true`.

## Install botsay as a local tool

Install the tool from the package that you created in the first tutorial:

```dotnetcli
dotnet tool install --add-source ./microsoft.botsay/nupkg microsoft.botsay
```

This command adds the tool to the manifest file that you created in the preceding step. The command output shows which manifest file the newly installed tool is in:

 ```console
 You can invoke the tool from this directory using the following command:
 'dotnet tool run botsay' or 'dotnet botsay'
 Tool 'microsoft.botsay' (version '1.0.0') was successfully installed.
 Entry is added to the manifest file /home/name/repository/.config/dotnet-tools.json
 ```

The *.config/dotnet-tools.json* file now has one tool:

```json
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "microsoft.botsay": {
      "version": "1.0.0",
      "commands": [
        "botsay"
      ]
    }
  }
}
```

## Use the tool

Invoke the tool by running the `dotnet tool run` command from the *repository* folder:

```dotnetcli
dotnet tool run botsay hello from the bot
```

## Restore a local tool installed by others

You typically install a local tool in the root directory of the repository. After you check in the manifest file to the repository, other developers can get the latest manifest file. To install all of the tools listed in the manifest file, they can run a single `dotnet tool restore` command.

1. Open the *.config/dotnet-tools.json* file, and replace the contents with the following JSON:

   ```json
   {
     "version": 1,
     "isRoot": true,
     "tools": {
       "microsoft.botsay": {
         "version": "1.0.0",
         "commands": [
           "botsay"
         ]
       },
       "dotnetsay": {
         "version": "2.1.3",
         "commands": [
           "dotnetsay"
         ]
       }
     }
   }
   ```

1. Save your changes.

   Making this change is the same as getting the latest version from the repository after someone else installed the package `dotnetsay` for the project directory.

1. Run the `dotnet tool restore` command.

   ```dotnetcli
   dotnet tool restore
   ```

   The command produces output like the following example:

   ```console
   Tool 'microsoft.botsay' (version '1.0.0') was restored. Available commands: botsay
   Tool 'dotnetsay' (version '2.1.3') was restored. Available commands: dotnetsay
   Restore was successful.
   ```

1. Verify that the tools are available:

   ```dotnetcli
   dotnet tool list
   ```

   The output is a list of packages and commands, similar to the following example:

   ```console
   Package Id      Version      Commands       Manifest
   --------------------------------------------------------------------------------------------
   microsoft.botsay 1.0.0        botsay         /home/name/repository/.config/dotnet-tools.json
   dotnetsay        2.1.3        dotnetsay      /home/name/repository/.config/dotnet-tools.json
   ```

1. Test the tools:

   ```dotnetcli
   dotnet tool run dotnetsay hello from dotnetsay
   dotnet tool run botsay hello from botsay
   ```

## Update a local tool

The installed version of local tool `dotnetsay` is 2.1.3.  Use the [dotnet tool update](dotnet-tool-update.md) command to update the tool to the latest version.

```dotnetcli
dotnet tool update dotnetsay
```

The output indicates the new version number:

```console
Tool 'dotnetsay' was successfully updated from version '2.1.3' to version '2.1.7'
(manifest file /home/name/repository/.config/dotnet-tools.json).
```

The update command finds the first manifest file that contains the package ID and updates it. If there is no such package ID in any manifest file that is in the scope of the search, the SDK adds a new entry to the closest manifest file. The search scope is up through parent directories until a manifest file with `isRoot = true` is found.

## Remove local tools

Remove the installed tools by running the [dotnet tool uninstall](dotnet-tool-uninstall.md) command:

```dotnetcli
dotnet tool uninstall microsoft.botsay
```

```dotnetcli
dotnet tool uninstall dotnetsay
```

## Troubleshoot

If you get an error message while following the tutorial, see [Troubleshoot .NET tool usage issues](troubleshoot-usage-issues.md).

## See also

For more information, see [.NET tools](global-tools.md)

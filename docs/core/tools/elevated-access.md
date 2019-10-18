---
title: Elevated access for dotnet commands
description: Learn the best practices for dotnet commands that require elevated access.
author: wli3
ms.date: 06/26/2019
---
# Elevated access for dotnet commands

Software development best practices guide developers to writing software that requires the least amount of privilege. However, some software, like performance monitoring tools, requires admin permission because of operating system rules. The following guidance describes supported scenarios for writing such software with .NET Core. 

The following commands can be run elevated:

- `dotnet tool` commands, such as [dotnet tool install](dotnet-tool-install.md).
- `dotnet run --no-build`

We don't recommend running other commands elevated. In particular, we don't recommend elevation with commands that use MSBuild, such as [dotnet restore](dotnet-restore.md), [dotnet build](dotnet-build.md), and [dotnet run](dotnet-run.md). The primary issue is permission management problems when a user transitions back and forth between root and a restricted account after issuing dotnet commands. You may find as a restricted user that you don't have access to the file built by a root user. There are ways to resolve this situation, but they're unnecessary to get into in the first place.

You can run commands as root as long as you don’t transition back and forth between root and a restricted account. For example, Docker containers run as root by default, so they have this characteristic.

## Global tool installation

The following instructions demonstrate the recommended way to install, run, and uninstall .NET Core tools that require elevated permissions to execute.

<!-- markdownlint-disable MD025 -->

# [Windows](#tab/windows)

### Install the global tool

If the folder `%ProgramFiles%\dotnet-tools` already exists, do the following to check whether the "Users" group has permission to write or modify that directory:

- Right-click the `%ProgramFiles%\dotnet-tools` folder and select **Properties**. The **Common Properties** dialog box opens. 
- Select the **Security** tab. Under **Group or user names**, check whether the “Users” group has permission to write or modify the directory. 
- If the "Users" group can write or modify the directory, use a different directory name when installing the tools rather than *dotnet-tools*.

To install tools, run the following command in elevated prompt. It will create the *dotnet-tools* folder during the installation.

```dotnetcli
dotnet tool install PACKAGEID --tool-path "%ProgramFiles%\dotnet-tools".
```

### Run the global tool

**Option 1** Use the full path with elevated prompt:

```cmd
"%ProgramFiles%\dotnet-tools\TOOLCOMMAND"
```

**Option 2** Add the newly created folder to `%Path%`. You only need to do this operation once.

```cmd
setx Path "%Path%;%ProgramFiles%\dotnet-tools\"
```

And run with:

```cmd
TOOLCOMMAND
```

### Uninstall the global tool

In an elevated prompt, type the following command:

```dotnetcli
dotnet tool uninstall PACKAGEID --tool-path "%ProgramFiles%\dotnet-tools"
```

# [Linux](#tab/linux)

[!INCLUDE [elevated-access-unix](../../../includes/elevated-access-unix.md)]

# [macOS](#tab/macos)

[!INCLUDE [elevated-access-unix](../../../includes/elevated-access-unix.md)]

---

## Local tools

Local tools are scoped per subdirectory tree, per user. When run elevated, local tools share a restricted user environment to the elevated environment. In Linux and macOS, this results in files being set with root user-only access. If the user switches back to a restricted account, the user can no longer access or write to the files. So installing tools that require elevation as local tools isn't recommended. Instead, use the `--tool-path` option and the previous guidelines for global tools.

## Elevation during development

During development, you may need elevated access to test your application. This scenario is common for IoT apps, for example. We recommend that you build the application without elevation and then run it with elevation. There are a few patterns, as follows:

- Using generated executable (it provides the best startup performance):

   ```bash
   dotnet build
   sudo ./bin/Debug/netcoreapp3.0/APPLICATIONNAME
   ```
    
- Using the [dotnet run](dotnet-run.md) command with the `—no-build` flag to avoid generating new binaries:

   ```bash
   dotnet build
   sudo dotnet run --no-build
   ```

## See also

- [.NET Core Global Tools overview](global-tools.md)

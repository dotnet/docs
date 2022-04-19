---
title: dotnet watch command
description: The dotnet watch command is a file watcher that restarts the specified application when changes in the source code are detected.
ms.date: 04/18/2022
---
# dotnet watch

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet watch` - Restarts the specified application when changes in the source code are detected.

## Synopsis

```dotnetcli
dotnet watch <forwarded arguments> [--list]
  [--no-hot-reload] [--non-interactive]
  [--project <PROJECT>] [-q|--quiet] [-v|--verbose]
  [--version]

dotnet watch -?|-h|--help
```

## Description

The `dotnet watch` command is a file watcher. It restarts the specified application when changes in the source code are detected. It's useful for fast iterative development from the command line.

## Environment variables

`dotnet watch` uses the following environment variables:

- **`DOTNET_USE_POLLING_FILE_WATCHER`**

  When set to `1` or `true`, `dotnet watch` uses a polling file watcher instead of <xref:System.IO.FileSystemWatcher?displayProperty=nameWithType>. Polling is required for some file systems, such as network shares, Docker mounted volumes, and other virtual file systems.

- **`DOTNET_WATCH`**

  `dotnet watch` sets this variable to `1` on all child processes launched.

- **`DOTNET_WATCH_ITERATION`**

  `dotnet watch` sets this variable to `1` and increments by one each time a file is changed and the command is restarted.

- **`DOTNET_WATCH_SUPPRESS_EMOJIS`**

  When set to `1` or `true`, `dotnet watch` will not show emojis in the console output.

## Arguments

<!-- markdownlint-disable MD012 -->

- **`forwarded arguments`**

  Arguments to pass to the child dotnet process.

## Options

- **`--`**

  The [double-dash option ('--')](../../standard/commandline/syntax.md#the----token) can be used to delimit `dotnet watch` options from arguments that will be passed to the child process. Its use is optional. When the double-dash option isn't used, `dotnet watch` considers the first unrecognized argument to be the beginning of arguments passed into the child dotnet process. For more information, see [the Examples section](#examples).<TODO> Can double-dash be used twice, once for watch and once for run?

- **`--list`**

  Lists all discovered files without starting the watcher.

- **`--no-hot-reload`**

  Suppress hot reload for supported apps. <todo> What does for supported apps mean?

- **`--non-interactive`**

  Runs `dotnet watch` in non-interactive mode. This option is only supported when running with Hot Reload enabled. Use this option to prevent console input from being captured.

- **`--project <PATH>`**

  Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.<todo>The readme says "The command must be executed in the directory that contains the project to be watched." only the command shows --project, not the readme

- **`-q|--quiet`**

  Suppresses all output except warnings and errors.

- **`-v|--verbose`**

  Show verbose output.

- **`--version`**

  Show version information. <todo>of what, the target project or the dotnet watch command?

## Examples

- Run `dotnet run` for the project in the current directory whenever source code changes:

  ```dotnetcli
  dotnet watch run
  ```

- Run `dotnet test` for the project in the current directory whenever source code changes:

  ```dotnetcli
  dotnet watch test
  ```

- Run `dotnet run --project ./HelloWorld.csproj` whenever source code changes:

  ```dotnetcli
  dotnet watch run -- --project  ./HelloWorld.csproj
  ```

  The use of '--' indicates that `project ./HelloWorld.csproj` should be treated as an argument for `dotnet run` rather than `dotnet watch`.

  

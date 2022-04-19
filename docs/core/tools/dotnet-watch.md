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

While running `dotnet watch`, you can force the app to rebuild and restart by pressing Ctrl+R in the command shell.<todo>check this out

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

  Suppress [hot reload](#hot-reload) for supported apps. <todo> What does for supported apps mean?

- **`--non-interactive`**

  Runs `dotnet watch` in non-interactive mode. This option is only supported when running with [hot reload](#hot-reload) enabled. Use this option to prevent console input from being captured.

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

## Environment variables

`dotnet watch` uses the following environment variables:

- **`DOTNET_USE_POLLING_FILE_WATCHER`**

  When set to `1` or `true`, `dotnet watch` uses a polling file watcher instead of <xref:System.IO.FileSystemWatcher?displayProperty=nameWithType>. Polling is required for some file systems, such as network shares, Docker mounted volumes, and other virtual file systems.

- **`DOTNET_WATCH`**

  `dotnet watch` sets this variable to `1` on all child processes launched.

- **`DOTNET_WATCH_ITERATION`**

  `dotnet watch` sets this variable to `1` and increments by one each time a file is changed and the command is restarted.

- **`DOTNET_WATCH_SUPPRESS_EMOJIS`**

  With the .NET SDK 6.0.300 and later, `dotnet watch` emits non-ASCII characters to the console during a hot reload session. On certain console hosts, these characters may appear garbled. To avoid garbled characters, set this variable to `1` or `true`.

- **`DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH`**<todo>asp.net core tutorial only

  When set to `1` or `true`, `dotnet watch` won't refresh browsers when it detects file changes.

- **`DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER`**<todo>readme only and asp.net core tutorial

  When set to `1` or `true`, `dotnet watch` won't launch or refresh browsers for web apps that have `launchBrowser` configured in *launchSettings.json*.

- **`DOTNET_WATCH_SUPPRESS_MSBUILD_INCREMENTALISM`**<todo>readme and asp.net core tutorial

  By default, `dotnet watch` optimizes the build by avoiding certain operations, such as running restore or re-evaluating the set of watched files on every file change. If this variable is set to `1` or `true`, these optimizations are disabled.

- **`DOTNET_WATCH_SUPPRESS_STATIC_FILE_HANDLING`**<todo>readme only

  When set to `1` or `true`, `dotnet watch` won't do special handling for static content files.

## Files watched by default

By default, `dotnet watch` tracks all files matching the following glob patterns:

* `**/*.cs`
* `*.csproj`
* `**/*.resx`
* Content files: `wwwroot/**`, `**/*.config`, `**/*.json`

`dotnet watch` watches all items in the `Watch` item group in the project file. By default, this group includes all items in the `Compile` and `EmbeddedResource` groups. `dotnet watch` also scans the entire graph of project references and watches all files within those projects.

More items can be added to the watch list by editing the project file. Items can be specified individually or by using glob patterns.

## Watch additional files

More items can be watched by adding items to the `Watch` group. For example, the following markup extends that group to include JavaScript files:

```xml
<ItemGroup>
  <Watch Include="**\*.js" Exclude="node_modules\**\*;**\*.js.map;obj\**\*;bin\**\*" />
</ItemGroup>
```

## Ignore specified items

`dotnet watch` will ignore `Compile` and `EmbeddedResource` items that have the `Watch="false"` attribute, as shown in the following example:

```xml
<ItemGroup>
  <Compile Update="Generated.cs" Watch="false" />
  <EmbeddedResource Update="Strings.resx" Watch="false" />
</ItemGroup>
```

`dotnet watch` will ignore project references that have the `Watch="false"` attribute, as shown in the following example:

```xml
<ItemGroup>
  <ProjectReference Include="..\ClassLibrary1\ClassLibrary1.csproj" Watch="false" />
</ItemGroup>
```

## Advanced configuration

`dotnet watch` performs a design-time build to find items to watch. When this build is run, `dotnet watch` sets the property `DotNetWatchBuild=true`. This property can be used as shown in the following example:<todo> what would you use this for?

```xml
<ItemGroup Condition="'$(DotNetWatchBuild)'=='true'">
  <!-- only included in the project when dotnet-watch is running -->
</ItemGroup>
```

## Hot Reload

Starting in .NET 6, `dotnet watch` adds support for *hot reload*. Hot reload is a feature that lets you apply changes to a running app without having to rebuild and restart it. The changes may be to code files or static assets, such as stylesheet files and JavaScript files. This feature enables a much faster development experience, as you receive immediate feedback when you modify your app during local development.

When a file is modified, `dotnet watch` determines if the app can be hot reloaded. If it can't be hot reloaded, the change is a *rude edit* and dotnet watch asks if you want to restart the app:

* **Yes**: Restarts the app.
* **No**: Leaves the app running without the changes applied.
* **Always**: Restarts the app and doesn't prompt anymore for rude edits.
* **Never**: Leaves the app running without the changes applied and doesn't prompt anymore for rude edits.


For information about what kinds of changes are considered rude edits, see [Edit code and continue debugging](/visualstudio/debugger/edit-and-continue) and [Unsupported edits](https://github.com/dotnet/roslyn/blob/main/docs/wiki/EnC-Supported-Edits.md#not-supported-edits).

To disable hot reload when you run `dotnet watch`, use the `--no-hot-reload` option, as shown in the following example:

```.NET CLI
dotnet watch --no-hot-reload 
```

## See also

* [Hot reload in Visual Studio](/visualstudio/debugger/hot-reload)
* [Test execution with hot reload](/visualstudio/test/test-execution-with-hot-reload)
* [Hot reload for ASP.NET Core](/aspnet/core/test/hot-reload?view=aspnetcore-6.0)
* [Develop ASP.NET Core apps using a file watcher](/aspnet/core/tutorials/dotnet-watch)

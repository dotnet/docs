---
title: dotnet watch command
description: The dotnet watch command is a file watcher that runs a dotnet command when changes in source code are detected.
ms.date: 08/19/2026
ai-usage: ai-assisted
---
# dotnet watch

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet watch` - Restarts or [hot reloads](#hot-reload) the specified application, or runs a specified dotnet command, when changes in source code are detected.

## Synopsis

```dotnetcli
dotnet watch [<command>]
  [-a|--arch <ARCH>] [--artifacts-path <ARTIFACTS_DIR>]
  [-c|--configuration <CONFIGURATION>] [--device <DEVICE_ID>]
  [--disable-build-servers] [-f|--framework <FRAMEWORK>]
  [--file <FILE_PATH>] [--interactive] [--list]
  [-lp|--launch-profile <LAUNCH_PROFILE>] [--no-hot-reload]
  [--no-launch-profile] [--no-restore] [--no-self-contained]
  [--non-interactive] [--os <OS>] [--project <PROJECT>]
  [-q|--quiet] [-r|--runtime <RUNTIME_IDENTIFIER>]
  [--sc|--self-contained] [-v|-verbosity <LEVEL>]
  [--verbose] [--version]
  [--] <forwarded arguments>

dotnet watch -?|-h|--help
```

## Description

The `dotnet watch` command is a file watcher. By default, it runs `dotnet run` and uses [Hot Reload](#hot-reload) to apply supported changes to the running app. Changes that can't be applied might require the app to restart. For other `dotnet` commands, `dotnet watch` reruns the command when a watched file changes.

When Hot Reload mode is active, press Ctrl+R in the command shell to force the current watch iteration to rebuild and restart. Ctrl+R isn't supported when you specify `--no-hot-reload`.

### Watch modes

The behavior after a file change depends on the command and whether Hot Reload is enabled:

| Invocation | Behavior |
| --- | --- |
| `dotnet watch` or `dotnet watch run` | Uses Hot Reload for supported changes. A change that requires a restart might prompt you before the app restarts. |
| `dotnet watch --no-hot-reload` | Disables managed Hot Reload and reruns `dotnet run` when a watched change requires a rebuild. For web apps, static web asset changes can still be handled without a rebuild. If browser refresh is available, `dotnet watch` can update or refresh the browser; otherwise, you might need to refresh it manually. |
| `dotnet watch <command>` where `<command>` isn't `run` | Reruns the command when a watched file changes. Hot Reload isn't enabled. |

The file set and change handling also differ between these modes. For more information, see [Files watched by default](#files-watched-by-default).

### Response compression

If `dotnet watch` runs for an app that uses [response compression](/aspnet/core/performance/response-compression), the tool can't inject the browser refresh script. The  .NET 7 and later version of the tool displays a warning message like the following:

> warn: Microsoft.AspNetCore.Watch.BrowserRefresh.BrowserRefreshMiddleware[4]
>
> Unable to configure browser refresh script injection on the response. This may have been caused by the response's Content-Encoding: 'br'. Consider disabling response compression.

As an alternative to disabling response compression, manually add the browser refresh JavaScript reference to the app's pages:

```javascript
@if (Environment.GetEnvironmentVariable("__ASPNETCORE_BROWSER_TOOLS") is not null)
{
    <script src="/_framework/aspnetcore-browser-refresh.js"></script>
}
```

## Arguments

- **`<command>`**

  In .NET 7 SDK and earlier, `dotnet watch` can run any command that is dispatched via the `dotnet` executable, such as built-in CLI commands and global tools. If you can run `dotnet <command>`, you can run `dotnet watch <command>`.

  In current SDK versions, `dotnet watch` recognizes built-in `dotnet` commands. Only `run` enables Hot Reload. Other commands use rerun-on-change behavior.

  If the child command isn't specified, the default is `run`.

- **`<forwarded arguments>`**

  Arguments provided after a double dash (` -- `) are passed to the child `dotnet` process. If you're running `dotnet watch run`, these arguments are options for [dotnet run](dotnet-run.md). If you're running `dotnet watch test`, these arguments are options for [dotnet test](dotnet-test.md).

## Options

- [!INCLUDE [artifacts-path](includes/cli-artifacts-path.md)]

- [!INCLUDE [arch](includes/cli-arch.md)]

- [!INCLUDE [configuration](includes/cli-configuration.md)]

- **`--device <DEVICE_ID>`**

  Specifies the device identifier to run on, such as an emulator, simulator, or physical device. If the project requires a device and you don't specify one, `dotnet watch` can prompt you to select one in interactive mode.

- [!INCLUDE [disable-build-servers](includes/cli-disable-build-servers.md)]

- **`-f|--framework <FRAMEWORK>`**

  Builds and runs the app using the specified [framework](../../standard/frameworks.md). The framework must be specified in the project file.

- **`--file <FILE_PATH>`**

  Specifies the path of a file-based app to run. You can also pass the file as the first argument if the current directory doesn't contain a project. File-based apps require Hot Reload mode, so `--no-hot-reload` and `--list` aren't supported. Available since .NET 10 SDK.

- [!INCLUDE [interactive](includes/cli-interactive.md)]

- **`--list`**

  Lists the files discovered by the MSBuild `Watch` item pipeline without starting the watcher. The default Hot Reload mode also watches inputs that aren't included in this list, such as some static web assets and scoped CSS inputs.

- **`-lp|--launch-profile <LAUNCH_PROFILE>`**

  Specifies the launch profile to use when the app starts. Launch profiles are defined in *launchSettings.json* or *[app].run.json*.

- [!INCLUDE [no-self-contained](includes/cli-no-self-contained.md)]

- **`--no-hot-reload`**

  Disables managed [Hot Reload](#hot-reload). For web apps, static web asset changes can still be handled without rerunning the child command. If browser refresh is available, `dotnet watch` can update or refresh the browser; otherwise, you might need to refresh it manually.

- **`--no-launch-profile`**

  Doesn't use *launchSettings.json* or *[app].run.json* to configure the application.

- **`--no-restore`**

  Doesn't execute an implicit restore before the project is built.

- **`--non-interactive`**

  Runs `dotnet watch` in non-interactive mode. This option disables all prompts owned by `dotnet watch`, including prompts for rude edits, target frameworks, and devices. When a rude edit requires a restart, `dotnet watch` restarts the app. This option only affects the Hot Reload watch path; other watch modes accept it but don't use it. Available since .NET 7 SDK.

- [!INCLUDE [os](includes/cli-os.md)]

- **`--project <PATH>`**

  Specifies the path of the project file to run (folder only or including the project file name). If not specified, it defaults to the current directory.

- **`-q|--quiet`**

  Suppresses all output that is generated by the `dotnet watch` command except warnings and errors. The option is not passed on to child commands. For example, output from `dotnet restore` and `dotnet run` continues to be output.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md).

- [!INCLUDE [self-contained](includes/cli-self-contained.md)]

- **`-v|-verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. The allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`.

- **`--verbose`**

  Shows verbose output for debugging.

- **`--version`**

  Shows the version of `dotnet watch`.

- **`--`**

  The [double-dash option ('--')](../../standard/commandline/syntax.md#the----token) can be used to delimit `dotnet watch` options from arguments that will be passed to the child process. Its use is optional. When the double-dash option isn't used, `dotnet watch` considers the first unrecognized argument to be the beginning of arguments that it should pass into the child `dotnet` process.

- [!INCLUDE [help](includes/cli-help.md)]

## Environment variables

`dotnet watch` uses the following environment variables:

- **`DOTNET_WATCH_HOTRELOAD_NAMEDPIPE_NAME`**

  This value is configured by `dotnet watch` when the app is launched, and it specifies the named pipe that the app uses to receive Hot Reload updates.

- **`DOTNET_USE_POLLING_FILE_WATCHER`**

  When set to `1` or `true`, `dotnet watch` uses a polling file watcher instead of <xref:System.IO.FileSystemWatcher?displayProperty=nameWithType>. Polling is required for some file systems, such as network shares, Docker mounted volumes, and other virtual file systems. The <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider> class uses `DOTNET_USE_POLLING_FILE_WATCHER` to determine whether the <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider.Watch*?displayProperty=nameWithType> method will rely on the <xref:Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken>.

- **`DOTNET_WATCH`**

  `dotnet watch` sets this variable to `1` on all child processes that it launches.

- **`DOTNET_WATCH_AUTO_RELOAD_WS_HOSTNAME`**

  As part of `dotnet watch`, the browser refresh server mechanism reads this value to determine the WebSocket host environment. The value `127.0.0.1` is replaced by `localhost`, and the `http://` and `https://` schemes are replaced with `ws://` and `wss://` respectively.

- **`DOTNET_WATCH_AUTO_RELOAD_WS_PORT`** and **`DOTNET_WATCH_AUTO_RELOAD_WSS_PORT`**

  Configure the HTTP and HTTPS WebSocket ports for browser refresh. If they aren't set, `dotnet watch` uses automatically assigned ports.

- **`DOTNET_WATCH_BROWSER_PATH`**

  Specifies the path of the browser executable that `dotnet watch` uses for automatic browser launch.

- **`DOTNET_WATCH_ITERATION`**

  `dotnet watch` sets this variable to the current launch iteration. The value changes when `dotnet watch` relaunches the child process, but not when it applies a Hot Reload update in place.

- **`DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH`**

  When set to `1` or `true`, `dotnet watch` won't automatically refresh browsers when it detects file changes. For app models that use browser refresh as the Hot Reload transport, updates that would use that transport require a restart instead.

- **`DOTNET_WATCH_SUPPRESS_EMOJIS`**

  With the .NET SDK 6.0.300 and later, `dotnet watch` emits non-ASCII characters to the console, as shown in the following example:

  ```output
  dotnet watch 🔥 Hot reload enabled. For a list of supported edits, see https://aka.ms/dotnet/hot-reload.
    💡 Press "Ctrl + R" to restart.
  dotnet watch 🔧 Building...
  dotnet watch 🚀 Started
  dotnet watch ⌚ Exited
  dotnet watch ⏳ Waiting for a file to change before restarting dotnet...
  ```

  On certain console hosts, these characters may appear garbled. To avoid seeing garbled characters, set this variable to `1` or `true`.

- **`DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER`**

  When set to `1` or `true`, `dotnet watch` won't automatically launch a browser for web apps that have `launchBrowser` configured in the selected launch profile, for example in *launchSettings.json* or *[app].run.json*. This setting doesn't disable updates or refreshes for a browser that's already connected.

- **`DOTNET_WATCH_SUPPRESS_MSBUILD_INCREMENTALISM`**

  In the non-Hot-Reload watch path, `dotnet watch` optimizes the build by avoiding certain operations, such as running restore or re-evaluating the set of watched files on every file change. If this variable is set to `1` or `true`, these optimizations are disabled.

- **`DOTNET_WATCH_SUPPRESS_STATIC_FILE_HANDLING`**

  When set to `1` or `true`, `dotnet watch` disables special handling for static web assets. In the MSBuild `Watch` item path, it sets the `DotNetWatchContentFiles` property to `false`. In the default Hot Reload path, it also suppresses static web asset and scoped CSS discovery during design-time evaluation.

- **`DOTNET_WATCH_RESTART_ON_RUDE_EDIT`**

  When set to `1` or `true`, `dotnet watch` will always restart on rude edits instead of asking.

- **`DOTNET_WATCH_HOTRELOAD_WEBSOCKET_ENDPOINT`** and **`DOTNET_WATCH_HOTRELOAD_WEBSOCKET_KEY`**

  `dotnet watch` sets these values on child processes that use the WebSocket-based Hot Reload transport. They specify the transport endpoint and authentication key.

- **`DOTNET_WATCH_AGENT_WEBSOCKET_PORT`** and **`DOTNET_WATCH_AGENT_WEBSOCKET_SECURE_PORT`**

  Configure the HTTP and HTTPS server ports for the WebSocket-based Hot Reload transport.

- **`DOTNET_WATCH_PROCESS_CLEANUP_TIMEOUT_MS`**

  Configures the child-process cleanup timeout in milliseconds. The default is 5,000 milliseconds.

## Files watched by default

The files that `dotnet watch` watches depend on the watch mode:

- In the default Hot Reload mode, `dotnet watch` computes inputs from a design-time build. These inputs include `Compile`, `AdditionalFiles`, and `Watch` items, imported build files, project references, and SDK-provided inputs. For web projects, the inputs can also include static web assets, Razor files, and scoped CSS files.
- With `--no-hot-reload`, with a child command other than `run`, or with `--list`, `dotnet watch` uses the MSBuild `Watch` item pipeline. By default, this pipeline includes `Compile` and `EmbeddedResource` items and traverses project references.

In the MSBuild `Watch` item modes, newly added matching files and imported build-file changes might not be noticed until the watch list is reevaluated.

The commonly watched files include:

- Source files such as `**/*.cs`.
- Project files in both modes. Imported build files are watched in the default Hot Reload mode, but not by the MSBuild `Watch` item pipeline.
- Resources such as `**/*.resx`.
- Razor files and scoped CSS files in Razor projects.
- Static web assets in web projects, such as files under `wwwroot`.

By default, *.config* and *.json* files don't cause `dotnet watch` to restart the app because the configuration system has its own mechanisms for handling configuration changes.

You can add files to the watch list or remove files from it by editing the project file. You can specify files individually or use glob patterns. The `Watch="false"` metadata described in [Ignore specified files and folders](#ignore-specified-files-and-folders) applies to the MSBuild `Watch` item pipeline. The default Hot Reload mode derives its own project and file set and doesn't apply all of the same metadata filters.

> [!NOTE]
> The `--list` option displays the MSBuild `Watch` item pipeline. It doesn't display every input that the default Hot Reload mode watches.

## Watch additional files

More files can be watched by adding items to the `Watch` group. For example, the following markup extends that group to include JavaScript files:

```xml
<ItemGroup>
  <Watch Include="**\*.js" Exclude="node_modules\**\*;**\*.js.map;obj\**\*;bin\**\*" />
</ItemGroup>
```

## Ignore specified files and folders

Use the `Watch="false"` attribute to ignore specified files. Use the `DefaultItemExcludes` property to ignore folders or files from being watched.

To prevent `dotnet watch` from watching files, use the `Compile` and `EmbeddedResource` items with the `Watch="false"` attribute, as shown in the following example:

```xml
<ItemGroup>
  <Compile Update="Generated.cs" Watch="false" />
  <EmbeddedResource Update="Strings.resx" Watch="false" />
</ItemGroup>
```

`dotnet watch` ignores project references that have the `Watch="false"` attribute, as shown in the following example:

```xml
<ItemGroup>
  <ProjectReference Include="..\ClassLibrary1\ClassLibrary1.csproj" Watch="false" />
</ItemGroup>
```

These `Watch="false"` settings apply to the MSBuild `Watch` item pipeline used by `--no-hot-reload`, non-`run` commands, and `--list`. The default Hot Reload mode computes its own project and file set.

Starting in .NET 10, use the `DefaultItemExcludes` property to exclude entire folders or file patterns from being watched by `dotnet watch`. This approach is useful when you want to exclude files that aren't relevant to compilation or files that trigger unwanted restarts or reloads.

For example, files in the `App_Data` folder of ASP.NET Core applications might change while the app runs, causing unnecessary page reloads. Exclude this folder from being watched:

```xml
<PropertyGroup>
  <DefaultItemExcludes>$(DefaultItemExcludes);**/App_Data/**</DefaultItemExcludes>
</PropertyGroup>
```

Exclude multiple patterns by separating them with semicolons:

```xml
<PropertyGroup>
  <DefaultItemExcludes>$(DefaultItemExcludes);**/App_Data/**;**/temp/**;**/*.log</DefaultItemExcludes>
</PropertyGroup>
```

The `DefaultItemExcludes` property affects all default item types, like `Compile` and `EmbeddedResource`. The `Watch="false"` attribute provides finer control over specific files or project references.

For more information, see the [DefaultItemExcludes reference](../project-sdk/msbuild-props.md#defaultitemexcludes).

## Advanced configuration

`dotnet watch` performs a design-time build to find items to watch. When this build is run, `dotnet watch` sets the property `DotNetWatchBuild=true`. This property can be used as shown in the following example:

```xml
<ItemGroup Condition="'$(DotNetWatchBuild)'=='true'">
  <!-- only included in the project when dotnet-watch is running -->
</ItemGroup>
```

## Hot Reload

Starting in .NET 6 SDK, `dotnet watch` includes support for *Hot Reload*. Hot Reload lets you apply supported managed-code changes to a running app without having to rebuild and restart it. For web apps, `dotnet watch` also handles static asset changes, such as stylesheet and JavaScript changes, and can refresh the browser. Static asset handling is separate from managed Hot Reload and can remain active when you specify `--no-hot-reload`.

For information about app types and .NET versions that support hot reload, see [Supported .NET app frameworks and scenarios](/visualstudio/debugger/hot-reload#supported-net-app-frameworks-and-scenarios).

### Rude edits

When a managed-code file is modified, `dotnet watch` determines whether it can apply the change with Hot Reload. A compile-time change that can't be applied is called a *rude edit*. In interactive mode, `dotnet watch` can ask whether you want to restart the app:

```dotnetcli
dotnet watch ⌚ Unable to apply hot reload because of a rude edit.
  ❔ Do you want to restart your app - Yes (y) / No (n) / Always (a) / Never (v)?
```

* **Yes**: Restarts the app.
* **No**: Leaves the app running without the changes applied and suspends Hot Reload until you restart the app, for example by pressing Ctrl+R.
* **Always**: Restarts the app and doesn't prompt anymore for rude edits.
* **Never**: Leaves the app running without the changes applied, doesn't prompt anymore for rude edits, and suspends Hot Reload until you restart the app.

Runtime rude edits restart the app automatically. In non-interactive mode, rude edits that require a restart also restart the app without a prompt.

For information about what kinds of changes are considered rude edits, see [Edit code and continue debugging](/visualstudio/debugger/edit-and-continue) and [Unsupported changes to code](/visualstudio/debugger/supported-code-changes-csharp#unsupported-changes-to-code).

To disable hot reload when you run `dotnet watch`, use the `--no-hot-reload` option, as shown in the following example:

```.NET CLI
dotnet watch --no-hot-reload
```

File-based programs require Hot Reload mode. The `--no-hot-reload` and `--list` options aren't supported for file-based programs.

## Examples

- Run `dotnet run` for the project in the current directory whenever source code changes:

  ```dotnetcli
  dotnet watch
  ```

  Or:

  ```dotnetcli
  dotnet watch run
  ```

- Run `dotnet test` for the project in the current directory whenever source code changes:

  ```dotnetcli
  dotnet watch test
  ```

- Run `dotnet run --project ./HelloWorld.csproj` whenever source code changes:

  ```dotnetcli
  dotnet watch run --project  ./HelloWorld.csproj
  ```

- Run `dotnet run -- arg0` for the project in the current directory whenever source code changes:

  ```dotnetcli
  dotnet watch run -- arg0
  ```

  Or:

  ```dotnetcli
  dotnet watch -- run arg0
  ```

## See also

* [Tutorial: Develop ASP.NET Core apps using a file watcher](/aspnet/core/tutorials/dotnet-watch)
* [Hot reload in Visual Studio](/visualstudio/debugger/hot-reload)
* [Hot reload supported apps](/visualstudio/debugger/hot-reload#supported-net-app-frameworks-and-scenarios)
* [Hot reload supported code changes](/visualstudio/debugger/supported-code-changes-csharp)
* [Hot reload test execution](/visualstudio/test/test-execution-with-hot-reload)
* [Hot reload support for ASP.NET Core](/aspnet/core/test/hot-reload)

---
title: File-based apps
description: Learn how to create, build, and run C# applications from a single file without a project file.
ms.date: 12/05/2025
ai-usage: ai-assisted
---
# File-based apps

**This article applies to:** ✔️ .NET 10 SDK and later versions

File-based apps let you build, run, and publish .NET applications from a single C# file without creating a traditional project file. They offer a lightweight alternative to traditional .NET projects. This approach simplifies development for scripts, utilities, and small applications. The .NET SDK automatically generates the necessary project configuration based on the directives in your source file.

Key benefits include:

- Reduced boilerplate for simple applications.
- Self-contained source files with embedded configuration.
- Native AOT publishing enabled by default.
- Automatic packaging as .NET tools.

In this article, learn how to create, configure, and work with file-based apps effectively.

## Supported directives

File-based apps use directives prefixed with `#:` to configure the build and run the application. Supported directives include: `#:package`, `#:project`, `#:property`, and `#:sdk`. Place these directives at the top of the C# file.

### `#:package`

Adds a NuGet package reference to your application.

```csharp
#:package Newtonsoft.Json
#:package Serilog@3.1.1
```

### `#:project`

References another project file or directory that contains a project file.

```csharp
#:project ../SharedLibrary/SharedLibrary.csproj
```

### `#:property`

Sets an MSBuild property value.

```csharp
#:property TargetFramework=net10.0
#:property PublishAot=false
```

### `#:sdk`

Specifies the SDK to use. Defaults to `Microsoft.NET.Sdk`.

```csharp
#:sdk Microsoft.NET.Sdk.Web
#:sdk Aspire.AppHost.Sdk@13.0.2
```

## CLI commands

The .NET CLI provides full support for file-based apps through familiar commands.

### Run applications

Run a file-based app by using the `dotnet run` command with the `--file` option:

```dotnetcli
dotnet run --file file.cs
```

Or use the `dotnet run` command:

```dotnetcli
dotnet run file.cs
```

Or use the shorthand syntax:

```dotnetcli
dotnet file.cs
```

#### Pass arguments

It's recommended to pass arguments to your application by placing them after `--`:

```dotnetcli
dotnet run file.cs -- arg1 arg2
```

Arguments after `--` are passed to your application. Without `--`, arguments go to the `dotnet run` command:

```dotnetcli
dotnet run file.cs arg1 arg2
```

### Build applications

Compile your file-based app by using the `dotnet build` command:

```dotnetcli
dotnet build file.cs
```

The SDK generates a virtual project and builds your application. The default path for the build output is `./bin/<configuration>/<framework>/`. Use the `--output` option to specify a different path.

### Clean build outputs

Remove build artifacts by using the `dotnet clean` command:

```dotnetcli
dotnet clean file.cs
```

Deletes cache for file-based apps in a directory:

```dotnetcli
dotnet clean file-based-apps
```

Use the `--days` option to specify how many days an artifact folder needs to be unused before removal:

```dotnetcli
dotnet clean file-based-apps --days 21
```

### Publish applications

File-based apps enable native AOT publishing by default, producing optimized, self-contained executables. Disable this feature by adding `#:property PublishAot=false` at the top of your file.

Use the `dotnet publish` command to create an independent executable:

```dotnetcli
dotnet publish file.cs
```

The default location of the executable is an `artifacts` directory next to the .cs file, with a subdirectory named after the application.

### Package as tool

Package your file-based app as a .NET tool by using the `dotnet pack` command:

```dotnetcli
dotnet pack file.cs
```

File-based apps set `PackAsTool=true` by default. Disable this setting by adding `#:property PackAsTool=false` at the top of your file.

### Convert to project

Convert your file-based app to a traditional project by using the `dotnet project convert` command:

```dotnetcli
dotnet project convert file.cs
```

This command creates a `.csproj` file with equivalent SDK and properties. The command removes all `#:` directives from the `.cs` file and turns them into elements in the corresponding `.csproj` file.

### Restore dependencies

Restore NuGet packages referenced in your file by using the `dotnet restore` command:

```dotnetcli
dotnet restore file.cs
```

By default, restore runs implicitly when you build or run your application. However, you can pass `--no-restore` to both the `dotnet build` and `dotnet run` commands to build or run without implicitly restoring.

## Default included items

File-based apps automatically include specific file types for compilation and packaging.

By default, the following items are included:

- The single C# file itself.
- ResX resource files in the same directory.

Different SDKs include other file types:

- `Microsoft.NET.Sdk.Web` includes `*.json` configuration files.
- Other specialized SDKs might include other patterns.

## Native AOT publishing

File-based apps enable native ahead-of-time (AOT) compilation by default. This feature produces optimized, self-contained executables with faster startup and a smaller memory footprint.

If you need to disable native AOT, use the following setting:

```csharp
#:property PublishAot=false
```

For more information about native AOT, see [Native AOT deployment](../deploying/native-aot/index.md).

## User secrets

File-based apps generate a stable user secrets ID based on a hash of the full file path. This ID lets you store sensitive configuration separately from your source code.

Access user secrets the same way as traditional projects:

```dotnetcli
dotnet user-secrets set "ApiKey" "your-secret-value" --file file.cs
```

List user secrets for file-based apps:

```dotnetcli
dotnet user-secrets list --file file.cs
```

For more information, see [Safe storage of app secrets in development](/aspnet/core/security/app-secrets).

## Launch profiles

File-based apps support launch profiles for configuring how the application runs during development. Instead of placing launch profiles in `Properties/launchSettings.json`, file-based apps can use a flat launch settings file named `[ApplicationName].run.json` in the same directory as the source file.

### Flat launch settings file

Create a launch settings file named after your application. For example, if your file-based app is `app.cs`, create `app.run.json` in the same directory:

```json
{
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

### Multiple file-based apps

When you have multiple file-based apps in the same directory, each app can have its own launch settings file:

```Directory
📁 myapps/
├── foo.cs
├── foo.run.json
├── bar.cs
└── bar.run.json
```

### Profile selection

The .NET CLI selects launch profiles using the following priority:

1. The profile specified by the `--launch-profile` option.
1. The profile specified by the `DOTNET_LAUNCH_PROFILE` environment variable.
1. The first profile defined in the launch settings file.

To run with a specific profile:

```dotnetcli
dotnet run app.cs --launch-profile https
```

### Traditional launch settings

File-based apps also support the traditional `Properties/launchSettings.json` file. If both files exist, the traditional location takes priority. If both files are present, the .NET CLI logs a warning to clarify which file is used.

## Shell execution

Enable direct execution of file-based apps on Unix-like systems by using a shebang line and executable permissions.

Add a shebang at the top of your file:

```csharp
#!/usr/bin/env dotnet
#:package Spectre.Console

using Spectre.Console;

AnsiConsole.MarkupLine("[green]Hello, World![/]");
```

Make the file executable:

```bash
chmod +x file.cs
```

Run directly:

```bash
./file.cs
```

> [!NOTE]
> Adding a shebang requires that you use `LF` line endings instead of `CRLF` and that the file doesn't contain a BOM.

## Implicit build files

File-based apps respect MSBuild and NuGet configuration files in the same directory or parent directories. These files affect how the SDK builds your application. Be mindful of these files when organizing your file-based apps.

### `Directory.Build.props`

Defines MSBuild properties that apply to all projects in a directory tree. File-based apps inherit these properties.

### `Directory.Build.targets`

Defines MSBuild targets and custom build logic. File-based apps execute these targets during build.

### `Directory.Packages.props`

Enables central package management for NuGet dependencies. File-based apps can use centrally managed package versions.

### `nuget.config`

Configures NuGet package sources and settings. File-based apps use these configurations when restoring packages.

### `global.json`

Specifies the .NET SDK version to use. File-based apps respect this version selection.

## Build caching

The .NET SDK caches build outputs to improve performance on subsequent builds. This caching system is unique to file-based apps.

### Cache behavior

The SDK caches build outputs based on:

- Source file content.
- Directive configuration.
- SDK version.- Implicit build files existence and content.

Caching improves build performance but can cause confusion when:

- Changes to implicit build files don't trigger rebuilds.
- Moving files to different directories doesn't invalidate cache.

### Workarounds

- Clear cache artifacts for file-based apps by using the following command:

```dotnetcli
dotnet clean file-based-apps
```

- Run a full build by using the `--no-cache` flag:

  ```dotnetcli
  dotnet build file.cs --no-cache
  ```

- Force a clean build to bypass cache:

  ```dotnetcli
  dotnet clean file.cs
  dotnet build file.cs
  ```

## Folder layout recommendations

Organize your file-based apps carefully to avoid conflicts with traditional projects and implicit build files.

### Avoid project file cones

Don't place file-based apps within the directory structure of a `.csproj` project. The project file's implicit build files and settings can interfere with your file-based app.

❌ **Not recommended:**

```Directory
📁 MyProject/
├── MyProject.csproj
├── Program.cs
└──📁 scripts/
    └── utility.cs  // File-based app - bad location
```

✅ **Recommended:**

```Directory
📁 MyProject/
├── MyProject.csproj
└── Program.cs
📁 scripts/
└── utility.cs  // File-based app - good location
```

### Be mindful of implicit files

Implicit build files in parent directories affect all file-based apps in subdirectories. Create isolated directories for file-based apps when you need different build configurations.

❌ **Not recommended:**

```Directory
📁 repo/
├── Directory.Build.props  // Affects everything below
├── app1.cs
└── app2.cs
```

✅ **Recommended:**

```Directory
📁 repo/
├── Directory.Build.props
├──📁 projects/
│   └── MyProject.csproj
└──📁 scripts/
    ├── Directory.Build.props  // Isolated configuration
    ├── app1.cs
    └── app2.cs
```

## See also

- [.NET SDK overview](../sdk.md)
- [dotnet run command](../tools/dotnet-run.md)
- [dotnet build command](../tools/dotnet-build.md)
- [Native AOT deployment](../deploying/native-aot/index.md)

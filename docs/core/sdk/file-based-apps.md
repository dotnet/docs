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

File-based apps use directives prefixed with `#:` to configure the build and run your application. Supported directives include: `#:package`, `#:project`, `#:property`, and `#:sdk`. Place these directives at the top of your C# file.

### `#:package`

Adds a NuGet package reference to your application.

```csharp
#:package Newtonsoft.Json
#:package Serilog version="3.1.1"
```

### `#:project`

References another project file.

```csharp
#:project ../SharedLibrary/SharedLibrary.csproj
```

### `#:property`

Sets a MSBuild property value.

```csharp
#:property TargetFramework=net10.0
#:property PublishAot=false
```

### `#:sdk`

Specifies the SDK to use. Defaults to `Microsoft.NET.Sdk`.

```csharp
#:sdk Microsoft.NET.Sdk.Web
```

## CLI commands

The .NET CLI provides full support for file-based apps through familiar commands.

### Run applications

Run a file-based app directly by using the `dotnet run` command:

```dotnetcli
dotnet run file.cs
```

Or use the shorthand syntax:

```dotnetcli
dotnet file.cs
```

#### Pass arguments

Pass arguments to your application in several ways:

```dotnetcli
dotnet run file.cs -- arg1 arg2
```

Arguments after `--` are passed to your application. Without `--`, arguments go to the `dotnet run` command:

```dotnetcli
dotnet run file.cs arg1 arg2
```

With the shorthand syntax, all arguments go to your application:

```dotnetcli
dotnet file.cs arg1 arg2
```

### Build applications

Compile your file-based app by using the `dotnet build` command:

```dotnetcli
dotnet build file.cs
```

The SDK generates a temporary project and builds your application.

### Clean build outputs

Remove build artifacts by using the `dotnet clean` command:

```dotnetcli
dotnet clean file.cs
```

Clean all file-based apps in a directory:

```dotnetcli
dotnet clean file-based-apps
```

### Publish applications

Create a deployment package by using the `dotnet publish` command:

```dotnetcli
dotnet publish file.cs
```

File-based apps enable native AOT publishing by default, producing optimized, self-contained executables.

### Package as tool

Package your file-based app as a .NET tool by using the `dotnet pack` command:

```dotnetcli
dotnet pack file.cs
```

File-based apps set `PackAsTool=true` by default.

### Convert to project

Convert your file-based app to a traditional project by using the `dotnet project convert` command:

```dotnetcli
dotnet project convert file.cs
```

This command creates a `.csproj` file with equivalent SDK and properties. All `#` directives are removed from the `.cs` files and turned into elements in the corresponding `.csproj` files.

### Restore dependencies

Restore NuGet packages referenced in your file by using the `dotnet restore` command:

```dotnetcli
dotnet restore file.cs
```

Restore runs implicitly when you build or run your application.

## Default included items

File-based apps automatically include specific file types for compilation and packaging.

By default, the following items are included:

- The single C# file itself.
- ResX resource files in the same directory.

Different SDKs include other file types:

- `Microsoft.NET.Sdk.Web` includes `*.json` configuration files.
- Other specialized SDKs might include other patterns.

## Native AOT publishing

File-based apps enable native ahead-of-time (AOT) compilation by default. This feature produces optimized, self-contained executables with faster startup, and a smaller memory footprint.

If you need to disable native AOT, use the following setting:

```csharp
#:property PublishAot=false
```

For more information about native AOT, see [Native AOT deployment](../deploying/native-aot/index.md).

## User secrets

File-based apps generate a stable user secrets ID based on a hash of the full file path. This ID lets you store sensitive configuration separately from your source code.

Access user secrets the same way as traditional projects:

```dotnetcli
dotnet user-secrets set "ApiKey" "your-secret-value" --project file.cs
```

For more information, see [Safe storage of app secrets in development](/aspnet/core/security/app-secrets).

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

The .NET SDK caches build outputs to improve performance on subsequent builds. File-based apps participate in this caching system.

### Cache behavior

The SDK caches build outputs based on:

- Source file content
- Directive configuration
- SDK version
- Implicit build files

Caching improves build performance but can cause confusion:

- Changes to implicit build files might not trigger rebuilds.
- Moving files to different directories might not invalidate cache.

### Workarounds

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

```
MyProject/
├── MyProject.csproj
├── Program.cs
└── scripts/
    └── utility.cs  // File-based app - bad location
```

✅ **Recommended:**

```
MyProject/
├── MyProject.csproj
└── Program.cs
scripts/
└── utility.cs  // File-based app - good location
```

### Be mindful of implicit files

Implicit build files in parent directories affect all file-based apps in subdirectories. Create isolated directories for file-based apps when you need different build configurations.

❌ **Not recommended:**

```
repo/
├── Directory.Build.props  // Affects everything below
├── app1.cs
└── app2.cs
```

✅ **Recommended:**

```
repo/
├── Directory.Build.props
├── projects/
│   └── MyProject.csproj
└── scripts/
    ├── Directory.Build.props  // Isolated configuration
    ├── app1.cs
    └── app2.cs
```

## See also

- [.NET SDK overview](../sdk.md)
- [dotnet run command](../tools/dotnet-run.md)
- [dotnet build command](../tools/dotnet-build.md)
- [Native AOT deployment](../deploying/native-aot/index.md)

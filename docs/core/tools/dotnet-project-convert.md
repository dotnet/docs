---
title: dotnet project convert command
description: The 'dotnet project convert' command converts a file-based program to a project-based program.
ms.date: 10/25/2025
ai-usage: ai-assisted
---
# dotnet project convert

**This article applies to:** ✔️ .NET 10 SDK and later versions

## Name

`dotnet project convert` - Converts a file-based program to a project-based program.

## Synopsis

```dotnetcli
dotnet project convert <FILE> [--dry-run] [--force] [--interactive]
    [-o|--output <OUTPUT_DIRECTORY>]

dotnet project convert -h|--help
```

## Description

The `dotnet project convert` command converts a file-based program to a project-based program. This command creates a new directory named for your file, scaffolds a *.csproj* file, moves your code into a file with the same name as the input file, and translates any `#:` directives into MSBuild properties and references.

This makes the transition seamless, from a single file to a fully functional, buildable, and extensible project. When your file-based app grows in complexity, or you simply want the extra capabilities afforded in project-based apps, you can convert it to a standard project.

### Conversion process

The command performs the following operations:

1. Creates a new directory named after the input file (without extension).
2. Generates a *.csproj* file with appropriate SDK and properties.
3. Moves the source code to a file with the same name as the input file.
4. Removes `#:` directives from the source code.
5. Translates `#:sdk` directives: the first `#:sdk` directive becomes the `<Project Sdk="Sdk.Id">` or `<Project Sdk="Sdk.Id/version">` attribute, and any additional `#:sdk` directives become `<Sdk Name="Sdk.Id" />` or `<Sdk Name="Sdk.Id" Version="version" />` elements.
6. Translates `#:package` directives to `<PackageReference>` elements in the project file.
7. Translates `#:property` directives to MSBuild properties in the project file.
8. Sets appropriate MSBuild properties based on the SDK and framework detected.

## Arguments

- `FILE`

  The path to the file-based program to convert. The file must be a C# source file (typically with a *.cs* extension).

## Options

- **`--dry-run`**

  Determines changes without actually modifying the file system. Shows what would be created or modified without performing the conversion.

- **`--force`**

  Forces conversion even if there are malformed directives. By default, the command fails if it encounters directives that cannot be properly parsed or converted.

- [!INCLUDE [interactive](includes/cli-interactive.md)]

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Specifies the output directory for the converted project. If not specified, a directory is created with the same name as the input file (without extension) in the current directory.

- [!INCLUDE [help](includes/cli-help.md)]

## Examples

- Convert a file-based program to a project:

  ```dotnetcli
  dotnet project convert app.cs
  ```

  Given a folder containing *app.cs* with the following content:

  ```csharp
  #:sdk Microsoft.NET.Sdk.Web
  #:package Microsoft.AspNetCore.OpenApi@10.*-*

  var builder = WebApplication.CreateBuilder();

  builder.Services.AddOpenApi();

  var app = builder.Build();

  app.MapGet("/", () => "Hello, world!");
  app.Run();
  ```

  Running `dotnet project convert app.cs` results in a folder called *app* containing:

  *app/app.cs*:

  ```csharp
  var builder = WebApplication.CreateBuilder();

  builder.Services.AddOpenApi();

  var app = builder.Build();

  app.MapGet("/", () => "Hello, world!");
  app.Run();
  ```

  *app/app.csproj*:

  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
      <OutputType>Exe</OutputType>
      <TargetFramework>net10.0</TargetFramework>
      <ImplicitUsings>enable</ImplicitUsings>
      <Nullable>enable</Nullable>
      <PublishAot>true</PublishAot>
      <PackAsTool>true</PackAsTool>
    </PropertyGroup>

    <ItemGroup>
      <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.*-*" />
    </ItemGroup>

  </Project>
  ```

- Convert a file-based program to a project in a specific output directory:

  ```dotnetcli
  dotnet project convert app.cs --output MyProject
  ```

## See also

- [dotnet build](dotnet-build.md)
- [dotnet run](dotnet-run.md)
- [dotnet publish](dotnet-publish.md)
- [Tutorial: Build file-based C# programs](../../csharp/fundamentals/tutorials/file-based-programs.md)

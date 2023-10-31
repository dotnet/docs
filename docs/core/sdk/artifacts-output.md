---
title: Artifacts output layout
description: Learn about a .NET SDK feature that centralizes and simplifies the layout of project outputs.
ms.date: 10/31/2023
---
# Artifacts output layout

In .NET 8 and later versions, there's an option to simplify the output path and folder structure for build outputs. All build outputs from all projects are gathered into a common location, separated by project. A common location makes it easy for tooling to anticipate where to find the outputs.

By default, the common location is a directory named *artifacts* next to the *Directory.build.props* file. The folder structure under the root *artifacts* folder is as follows:

```Directory
📁 artifacts
    └──📂 <Type of output>
        └──📂 <Project name>
            └──📂 <Pivot>
```

The following table shows the default values for each level in the folder structure. You can override the values, as well as the default location, using properties in the *Directory.build.props* file.

| Folder level | Description | Examples |
|--|--|--|
| Type of output | Categories of build outputs, such as binaries, intermediate/generated files, published applications, and NuGet packages. |`bin`, `obj`, `publish`, `package` |
| Project name | Separates output by each project. | `MyApp` |
| Pivot | Distinguishes between builds of a project for different configurations, target frameworks, and runtime identifiers. If multiple elements are needed, they're joined by an underscore (`_`). Can be customized using the `ArtifactsPivots` MSBuild property. | `debug`, `debug_net8.0`, `release`, `release_linux-x64` |

## Examples

The following table shows examples of paths that might be created.

| Path                                        | Description                                                                    |
|---------------------------------------------|--------------------------------------------------------------------------------|
| *artifacts\bin\MyApp\debug*                 | The build output path for a simple project when you run `dotnet build`.        |
| *artifacts\obj\MyApp\debug*                 | The intermediate output path for a simple project when you run `dotnet build`. |
| *artifacts\bin\MyApp\debug_net8.0*          | The build output path for the `net8.0` build of a multi-targeted project.      |
| *artifacts\publish\MyApp\release_linux-x64* | The publish path for a simple app when publishing for `linux-x64`.             |
| *artifacts\package\MyApp\release*           | The folder where the release *.nupkg* is created for a project.                |

## How to configure

To opt into the centralized output path format, add one of the following MSBuild properties to your *Directory.Build.props* file:

- To use the default output location, set the `UseArtifactsOutput` property to `true`.

  ```xml
  <PropertyGroup>
    <UseArtifactsOutput>true</UseArtifactsOutput>
  </PropertyGroup>
  ```

- To set a custom output location, add an `ArtifactsPath` property with a value of `$(MSBuildThisFileDirectory)artifacts` (or whatever you want the folder location to be). If you don't already have a *Directory.Build.props* file, you can run the following command to automatically generate a file that contains the `ArtifactsPath` property:

  ```dotnetcli
  dotnet new buildprops --use-artifacts
  ```

  The generated file looks similar to this:

  ```xml
  <Project>
    <PropertyGroup>
      <ArtifactsPath>$(MSBuildThisFileDirectory)artifacts</ArtifactsPath>
    </PropertyGroup>
  </Project>
  ```

The "pivot" folder name defaults to a combination of target framework moniker (TFM), configuration, and runtime identifier (RID). Any that aren't present are omitted. To customize how the "pivot" folder is named, set the `ArtifactsPivots` MSbuild property to your desired string.

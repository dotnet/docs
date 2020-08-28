---
title: .NET Core project SDK overview
titleSuffix: ""
description: Learn about the .NET Core project SDKs.
ms.date: 02/02/2020
ms.topic: conceptual
---
# .NET Core project SDKs

.NET Core projects are associated with a software development kit (SDK). Each *project SDK* is a set of MSBuild [targets](/visualstudio/msbuild/msbuild-targets) and associated [tasks](/visualstudio/msbuild/msbuild-tasks) that are responsible for compiling, packing, and publishing code. A project that references a project SDK is sometimes referred to as an *SDK-style project*.

## Available SDKs

The following SDKs are available for .NET Core:

| ID | Description | Repo|
| - | - | - |
| `Microsoft.NET.Sdk` | The .NET Core SDK | <https://github.com/dotnet/sdk> |
| `Microsoft.NET.Sdk.Web` | The .NET Core [Web SDK](/aspnet/core/razor-pages/web-sdk) | <https://github.com/dotnet/sdk> |
| `Microsoft.NET.Sdk.Razor` | The .NET Core [Razor SDK](/aspnet/core/razor-pages/sdk) |
| `Microsoft.NET.Sdk.Worker` | The .NET Core Worker Service SDK |
| `Microsoft.NET.Sdk.WindowsDesktop` | The .NET Core WinForms and WPF SDK |

The .NET Core SDK is the base SDK for .NET Core. The other SDKs reference the .NET Core SDK, and projects that are associated with the other SDKs have all the .NET Core SDK properties available to them. The Web SDK, for example, depends on both the .NET Core SDK and the Razor SDK.

You can also author your own SDK that can be distributed via NuGet.

## Project files

.NET Core projects are based on the [MSBuild](/visualstudio/msbuild/msbuild) format. Project files, which have extensions like *.csproj* for C# projects and *.fsproj* for F# projects, are in XML format. The root element of an MSBuild project file is the [Project](/visualstudio/msbuild/project-element-msbuild) element. The `Project` element has an optional `Sdk` attribute that specifies which SDK (and version) to use. To use the .NET Core tools and build your code, set the `Sdk` attribute to one of the IDs in the [Available SDKs](#available-sdks) table.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  ...
</Project>
```

To specify an SDK that comes from NuGet, include the version at the end of the name, or specify the name and version in the *global.json* file.

```xml
<Project Sdk="MSBuild.Sdk.Extras/2.0.54">
  ...
</Project>
```

Another way to specify the SDK is with the top-level [Sdk](/visualstudio/msbuild/sdk-element-msbuild) element:

```xml
<Project>
  <Sdk Name="Microsoft.NET.Sdk" />
  ...
</Project>
```

Referencing an SDK in one of these ways greatly simplifies project files for .NET Core. While evaluating the project, MSBuild adds implicit imports for `Sdk.props` at the top of the project file and `Sdk.targets` at the bottom.

```xml
<Project>
  <!-- Implicit top import -->
  <Import Project="Sdk.props" Sdk="Microsoft.NET.Sdk" />
  ...
  <!-- Implicit bottom import -->
  <Import Project="Sdk.targets" Sdk="Microsoft.NET.Sdk" />
</Project>
```

> [!TIP]
> On a Windows machine, the *Sdk.props* and *Sdk.targets* files can be found in the *%ProgramFiles%\dotnet\sdk\\[version]\Sdks\Microsoft.NET.Sdk\Sdk* folder.

### Preprocess the project file

You can see the fully expanded project as MSBuild sees it after the SDK and its targets are included by using the `dotnet msbuild -preprocess` command. The [preprocess](/visualstudio/msbuild/msbuild-command-line-reference#preprocess) switch of the [`dotnet msbuild`](../tools/dotnet-msbuild.md) command shows which files are imported, their sources, and their contributions to the build without actually building the project.

If the project has multiple target frameworks, focus the results of the command on only one framework by specifying it as an MSBuild property. For example:

`dotnet msbuild -property:TargetFramework=netcoreapp2.0 -preprocess:output.xml`

### Default compilation includes

The default includes and excludes for compile items, embedded resources, and `None` items are defined in the SDK. Unlike non-SDK .NET Framework projects, you don't need to specify these items in your project file, because the defaults cover most common use cases. This makes the project file smaller and easier to understand and edit by hand, if needed.

The following table shows which elements and which [globs](https://en.wikipedia.org/wiki/Glob_(programming)) are included and excluded in the .NET Core SDK:

| Element           | Include glob                              | Exclude glob                                                  | Remove glob              |
|-------------------|-------------------------------------------|---------------------------------------------------------------|--------------------------|
| Compile           | \*\*/\*.cs (or other language extensions) | \*\*/\*.user;  \*\*/\*.\*proj;  \*\*/\*.sln;  \*\*/\*.vssscc  | N/A                      |
| EmbeddedResource  | \*\*/\*.resx                              | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | N/A                      |
| None              | \*\*/\*                                   | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | \*\*/\*.cs; \*\*/\*.resx |

> [!NOTE]
> The `./bin` and `./obj` folders, which are represented by the `$(BaseOutputPath)` and `$(BaseIntermediateOutputPath)` MSBuild properties, are excluded from the globs by default. Excludes are represented by the property `$(DefaultItemExcludes)`.

#### Build errors

If you explicitly define any of these items in your project file, you're likely to get a "NETSDK1022" build error similar to the following:

  > Duplicate 'Compile' items were included. The .NET SDK includes 'Compile' items from your project directory by default. You can either remove these items from your project file, or set the 'EnableDefaultCompileItems' property to 'false' if you want to explicitly include them in your project file.

  > Duplicate 'EmbeddedResource' items were included. The .NET SDK includes 'EmbeddedResource' items from your project directory by default. You can either remove these items from your project file, or set the 'EnableDefaultEmbeddedResourceItems' property to 'false' if you want to explicitly include them in your project file.

To resolve the errors, do one of the following:

- Remove the explicit `Compile`, `EmbeddedResource`, or `None` items that match the implicit ones listed on the previous table.

- Set the `EnableDefaultItems` property to `false` to disable all implicit file inclusion:

  ```xml
  <PropertyGroup>
    <EnableDefaultItems>false</EnableDefaultItems>
  </PropertyGroup>
  ```

  If you want to specify files to be published with your app, you can still use the known MSBuild mechanisms for that, for example, the `Content` element.

- Selectively disable only `Compile`, `EmbeddedResource`, or `None` globs by setting the `EnableDefaultCompileItems`, `EnableDefaultEmbeddedResourceItems`, or `EnableDefaultNoneItems` property to `false`:

  ```xml
  <PropertyGroup>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
    <EnableDefaultEmbeddedResourceItems>false</EnableDefaultEmbeddedResourceItems>
    <EnableDefaultNoneItems>false</EnableDefaultNoneItems>
  </PropertyGroup>
  ```

  If you only disable `Compile` globs, Solution Explorer in Visual Studio still shows \*.cs items as part of the project, included as `None` items. To disable the implicit `None` glob, set `EnableDefaultNoneItems` to `false` too.

## Customize the build

There are various ways to [customize a build](/visualstudio/msbuild/customize-your-build). You may want to override a property by passing it as an argument to an [msbuild](/visualstudio/msbuild/msbuild-command-line-reference) or [dotnet](../tools/index.md) command. You can also add the property to the project file or to a *Directory.Build.props* file. For a list of useful properties for .NET Core projects, see [MSBuild reference for .NET Core SDK projects](msbuild-props.md).

### Custom targets

.NET Core projects can package custom MSBuild targets and properties for use by projects that consume the package. Use this type of extensibility when you want to:

- Extend the build process.
- Access artifacts of the build process, such as generated files.
- Inspect the configuration under which the build is invoked.

You add custom build targets or properties by placing files in the form `<package_id>.targets` or `<package_id>.props` (for example, `Contoso.Utility.UsefulStuff.targets`) in the *build* folder of the project.

The following XML is a snippet from a *.csproj* file that instructs the [`dotnet pack`](../tools/dotnet-pack.md) command what to package. The `<ItemGroup Label="dotnet pack instructions">` element places the targets files into the *build* folder inside the package. The `<Target Name="CollectRuntimeOutputs" BeforeTargets="_GetPackageFiles">` element places the assemblies and *.json* files into the *build* folder.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  ...
  <ItemGroup Label="dotnet pack instructions">
    <Content Include="build\*.targets">
      <Pack>true</Pack>
      <PackagePath>build\</PackagePath>
    </Content>
  </ItemGroup>
  <Target Name="CollectRuntimeOutputs" BeforeTargets="_GetPackageFiles">
    <!-- Collect these items inside a target that runs after build but before packaging. -->
    <ItemGroup>
      <Content Include="$(OutputPath)\*.dll;$(OutputPath)\*.json">
        <Pack>true</Pack>
        <PackagePath>build\</PackagePath>
      </Content>
    </ItemGroup>
  </Target>
  ...
  
</Project>
```

To consume a custom target in your project, add a `PackageReference` element that points to the package and its version. Unlike the tools, the custom targets package is included in the consuming project's dependency closure.

You can configure how to use the custom target. Since it's an MSBuild target, it can depend on a given target, run after another target, or be manually invoked by using the `dotnet msbuild -t:<target-name>` command. However, to provide a better user experience, you can combine per-project tools and custom targets. In this scenario, the per-project tool accepts whatever parameters are needed and translates that into the required [`dotnet msbuild`](../tools/dotnet-msbuild.md) invocation that executes the target. You can see a sample of this kind of synergy on the [MVP Summit 2016 Hackathon samples](https://github.com/dotnet/MVPSummitHackathon2016) repo in the [`dotnet-packer`](https://github.com/dotnet/MVPSummitHackathon2016/tree/master/dotnet-packer) project.

## See also

- [Install .NET Core](../install/index.yml)
- [How to use MSBuild project SDKs](/visualstudio/msbuild/how-to-use-project-sdk)
- [Package custom MSBuild targets and props with NuGet](/nuget/create-packages/creating-a-package#include-msbuild-props-and-targets-in-a-package)

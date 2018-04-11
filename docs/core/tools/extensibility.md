---
title: .NET Core CLI extensibility model
description: Learn how you can extend the Command-line Interface (CLI) tools.
keywords: CLI, extensibility, custom commands, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 04/12/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: fffc3400-aeb9-4c07-9fea-83bc8dbdcbf3
ms.workload: 
  - dotnetcore
---

# .NET Core CLI tools extensibility model

This document covers the different ways you can extend the .NET Core Command-line Interface (CLI) tools and explain the scenarios that drive each one of them.
You'll see how to consume the tools as well as how to build the different types of tools.

## How to extend CLI tools
The CLI tools can be extended in three main ways:

1. [Via NuGet packages on a per-project basis](#per-project-based-extensibility)

  Per-project tools are contained within the project's context, but they allow easy installation through restoration.

2. [Via NuGet packages with custom targets](#custom-targets)

  Custom targets allow you to easily extend the build process with custom tasks.

3. [Via the system's PATH](#path-based-extensibility)

  PATH-based tools are good for general, cross-project tools that are usable on a single machine.

The three extensibility mechanisms outlined above are not exclusive. You can use one, or all, or a combination of them. Which one to pick
depends largely on the goal you are trying to achieve with your extension.

## Per-project based extensibility
Per-project tools are [framework-dependent deployments](../deploying/index.md#framework-dependent-deployments-fdd) that are distributed as NuGet packages. Tools are only available in the context of the project that references them and for which they are restored. Invocation outside of the context of the project (for example, outside of the directory that contains the project) will fail because the command cannot be found.

These tools are perfect for build servers, since nothing outside of the project file is needed. The build process
runs restore for the project it builds and tools will be available. Language projects, such as F#, are also in this
category since each project can only be written in one specific language.

Finally, this extensibility model provides support for creation of tools that need access to the built output of the
project. For instance, various Razor view tools in [ASP.NET](https://www.asp.net/) MVC applications fall into this
category.

### Consuming per-project tools
Consuming these tools requires you to add a `<DotNetCliToolReference>` element to your project file for each tool you want to use. Inside the `<DotNetCliToolReference>` element, you reference the package in which the tool resides and specify the version you need. After running [`dotnet restore`](dotnet-restore.md), the tool and its dependencies are restored.

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

For tools that need to load the build output of the project for execution, there is usually another dependency which is
listed under the regular dependencies in the project file. Since CLI uses MSBuild as its build engine, we recommend that these parts of the tool be written as custom MSBuild [targets](/visualstudio/msbuild/msbuild-targets) and [tasks](/visualstudio/msbuild/msbuild-tasks), since they can then take part in the overall build process. Also, they can get any and all data easily that is produced via the build, such as the location of the output files, the current configuration being built, etc. All this information becomes a set of MSBuild properties that can be read from any target. You can see how to add a custom target using NuGet later in this document.

Let's review an example of adding a simple tools-only tool to a simple project. Given an example command called
`dotnet-api-search` that allows you to search through the NuGet packages for the specified
API, here is a console application's project file that uses that tool:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1</TargetFramework>
  </PropertyGroup>

  <!-- The tools reference -->
  <ItemGroup>
    <DotNetCliToolReference Include="dotnet-api-search" Version="1.0.0" />
  </ItemGroup>
</Project>
```

The `<DotNetCliToolReference>` element is structured in a similar way as the `<PackageReference>` element. It needs the package ID of the package containing the tool and its version to be able to restore.

### Building tools
As mentioned, tools are just portable console applications. You build tools as you would build any other console application.
After you build it, you use the [`dotnet pack`](dotnet-pack.md) command to create a NuGet package (.nupkg file) that contains
your code, information about its dependencies, and so on. You can give any name to the package, but the
application inside, the actual tool binary, has to conform to the convention of `dotnet-<command>` in order for `dotnet`
to be able to invoke it.

> [!NOTE]
> In pre-RC3 versions of the .NET Core command-line tools, the `dotnet pack` command had a bug that caused the `runtime.config.json` to not be packed with the tool. Lacking that file results in errors at runtime. If you encounter this behavior, be sure to update to the latest tooling and try the `dotnet pack` again.

Since tools are portable applications, the user consuming the tool must have the version of the .NET Core libraries
that the tool was built against in order to run the tool. Any other dependency that the tool uses and that is not
contained within the .NET Core libraries is restored and placed in the NuGet cache. The entire tool is, therefore, run
using the assemblies from the .NET Core libraries as well as assemblies from the NuGet cache.

These kinds of tools have a dependency graph that is completely separate from the dependency graph of the project that
uses them. The restore process first restores the project's dependencies and then restores each of the tools and
their dependencies.

You can find richer examples and different combinations of this in the [.NET Core CLI repo](https://github.com/dotnet/cli/tree/release/2.1/TestAssets/TestProjects).
You can also see the [implementation of tools used](https://github.com/dotnet/cli/tree/release/2.1/TestAssets/TestPackages) in the same repo.

### Custom targets
NuGet has the capability to [package custom MSBuild targets and props files](/nuget/create-packages/creating-a-package#including-msbuild-props-and-targets-in-a-package). With the move of the .NET Core CLI tools to use MSBuild, the same mechanism of extensibility now applies to .NET Core projects. You would use this type of extensibility when you want to extend the build process, or when you want to access any of the artifacts in the build process, such as generated files, or you want to inspect the configuration under which the build is invoked, etc.

In the following example, you can see the target's project file using the `csproj` syntax. This instructs the [`dotnet pack`](dotnet-pack.md) command what to package, placing the targets files as well as the assemblies into the *build* folder inside the package. Notice the `<ItemGroup>` element that has the `Label` property set to `dotnet pack instructions`, and the Target
defined beneath it.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Description>Sample Packer</Description>
    <VersionPrefix>0.1.0-preview</VersionPrefix>
    <TargetFramework>netstandard1.3</TargetFramework>
    <DebugType>portable</DebugType>
    <AssemblyName>SampleTargets.PackerTarget</AssemblyName>
  </PropertyGroup>
  <ItemGroup>
    <EmbeddedResource Include="Resources\Pkg\dist-template.xml;compiler\resources\**\*" Exclude="bin\**;obj\**;**\*.xproj;packages\**" />
    <None Include="build\SampleTargets.PackerTarget.targets" />
  </ItemGroup>
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
  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.DependencyModel" Version="1.0.1-beta-000933"/>
    <PackageReference Include="Microsoft.Build.Framework" Version="0.1.0-preview-00028-160627" />
    <PackageReference Include="Microsoft.Build.Utilities.Core" Version="0.1.0-preview-00028-160627" />
    <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
  </ItemGroup>
  <ItemGroup />
  <PropertyGroup Label="Globals">
    <ProjectGuid>463c66f0-921d-4d34-8bde-7c9d0bffaf7b</ProjectGuid>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(TargetFramework)' == 'netstandard1.3' ">
    <DefineConstants>$(DefineConstants);NETSTANDARD1_3</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)' == 'Release' ">
    <DefineConstants>$(DefineConstants);RELEASE</DefineConstants>
  </PropertyGroup>
</Project>
```

Consuming custom targets is done by providing a `<PackageReference>` that points to the package and its version inside the project that is being extended. Unlike the tools, the custom targets package does get included into the consuming project's dependency closure.

Using the custom target depends solely on how you configure it. Since it's an MSBuild target, it can depend on a given target, run after another target and can also be manually invoked using the `dotnet msbuild /t:<target-name>` command.

However, if you want to provide a better user experience to your users, you can combine per-project tools and custom targets. In this scenario, the per-project tool would essentially just accept whatever needed parameters and would translate that into the required [`dotnet msbuild`](dotnet-msbuild.md) invocation that would execute the target. You can see a sample of this kind of synergy on the [MVP Summit 2016 Hackathon samples](https://github.com/dotnet/MVPSummitHackathon2016) repo in the [`dotnet-packer`](https://github.com/dotnet/MVPSummitHackathon2016/tree/master/dotnet-packer) project.

### PATH-based extensibility
PATH-based extensibility is usually used for development machines where you need a tool that conceptually covers more
than a single project. The main drawback of this extension mechanism is that it's tied to the machine where the
tool exists. If you need it on another machine, you would have to deploy it.

This pattern of CLI toolset extensibility is very simple. As covered in the [.NET Core CLI overview](index.md), `dotnet` driver
can run any command that is named after the `dotnet-<command>` convention. The default resolution logic first
probes several locations and finally falls back to the system PATH. If the requested command exists in the system PATH
and is a binary that can be invoked, `dotnet` driver will invoke it.

The file must be executable. On Unix systems, this means anything that
has the execute bit set via `chmod +x`. On Windows, you can use *cmd* files.

Let's take a look at the very simple implementation of a "Hello World" tool. We will use both `bash` and `cmd` on Windows.
The following command will simply echo "Hello World" to the console.

```bash
#!/bin/bash

echo "Hello World!"
```

```cmd
echo "Hello World"
```

On macOS, we can save this script as `dotnet-hello` and set its executable bit with `chmod +x dotnet-hello`. We can then
create a symbolic link to it in `/usr/local/bin` using the command `ln -s <full_path>/dotnet-hello /usr/local/bin/`. This will make
it possible to invoke the command using the `dotnet hello` syntax.

On Windows, we can save this script as `dotnet-hello.cmd` and put it in a location that is in a system path (or you can
add it to a folder that is already in the path). After this, you can just use `dotnet hello` to run this example.

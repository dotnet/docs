---
title: .NET Core CLI extensibility model | Microsoft Docs
description: .NET Core CLI extensibility model 
keywords: CLI, extensibility, custom commands, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 02/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: fffc3400-aeb9-4c07-9fea-83bc8dbdcbf3
---

# .NET Core CLI extensibility model (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the .NET Core Tools Preview 2 version,
> see the [.NET Core CLI extensibility model](../../tools/dotnet-test.md) topic.

## Overview
This document will cover the main ways how to extend the CLI tools and explain the scenarios that drive each of them. 
It will the outline how to consume the tools as well as provide short notes on how to build both types of tools. 

## How to extend CLI tools
The RC4 CLI tools can be extended in three main ways:

1. Via NuGet packages on a per-project basis
2. Via NuGet packages with custom targets  
3. Via the system's PATH

The three extensibility mechanisms outlined above are not exclusive; you can use all or just one or combine them. Which one to pick 
depends largely on what is the goal you are trying to achieve with your extension.

## Per-project based extensibility
Per-project tools are [framework-dependented deployments](../deploying/index.md) that are distributed as NuGet packages. Tools are 
only available in the context of the project that references them and for which they are restored; invocation outside 
of the context of the project (for example, outside of the directory that contains the project) will fail as the command will 
not be able to be found.

These tools are perfect for build servers, since nothing outside of the project file is needed. The build process 
runs restore for the project it builds and tools will be available. Language projects, such as F#, are also in this 
category; after all, each project can only be written in one specific language. 

Finally, this extensibility model provides support for creation of tools that need access to the built output of the 
project. For instance, various Razor view tools in [ASP.NET](https://www.asp.net/) MVC applications fall into this 
category. 

### Consuming per-project tools
Consuming these tools requires you to add a `<DotNetCliToolReference>` element for each tool you want to use to your project file. Inside the `<DotNetCliToolReference>` element, you reference the package in which the tool resides and you specify the version you need. After running `dotnet restore`, the tool and its dependencies are restored. 

For tools that need to load the build output of the project for execution, there is usually another dependency which is 
listed under the regular dependencies in the project file. Since the RC4 version of the CLI uses MSBuild as its build engine, it is recommended that these parts of the tool be written as custom MSBuild targets and tasks since that way they can take part in the overall build process. Also, they can get any and all data easily that is produced via the build, for example the location of the output files, the current configuration being built etc. All of this information in RC4 becomes a set of MSBuild properties that can be read from any target. We will see how to add a custom target using NuGet later in this document. 

Let's review an example of adding a simple tools-only tool to a simple project. Given an example command called 
`dotnet-api-search` that allows you to search through the NuGet packages for the specified 
API, here is a console application's project file that uses that tool:


```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.1/TargetFramework>
  </PropertyGroup>

  <!-- The tools reference -->
  <ItemGroup>
    <DotNetCliToolReference Include="dotnet-api-search" Version="1.0.0" />
  </ItemGroup>
</Project>
```

The `<DotNetCliToolReference>` element is structured in a similar way as the `<PackageReference>` element. It needs the package ID of the package containing the tool and its version at the very least. 

### Building tools
As mentioned, tools are just portable console applications. You would build one as you would build any console application. 
After you build it, you would use [`dotnet pack`](dotnet-pack.md) command to create a NuGet package (nupkg) that contains 
your code, information about its dependencies and so on. The package name can be whatever the author wants, but the 
application inside, the actual tool binary, has to conform to the convention of `dotnet-<command>` in order for `dotnet` 
to be able to invoke it. 

> [!NOTE]
> In pre-RC3 versions of the .NET Core command-line tools, the `dotnet pack` command had a bug that caused the `runtime.config.json` to not be packed with the tool. Lacking that file results in errors at runtime. If you encounter this behavior, be sure to update to the latest tooling and try the `dotnet pack` again. 

Since tools are portable applications, the user consuming the tool has to have the version of the .NET Core libraries 
that the tool was built against in order to run the tool. Any other dependency that the tool uses and that is not 
contained within the .NET Core libraries is restored and placed in the NuGet cache. The entire tool is, therefore, run 
using the assemblies from the .NET Core libraries as well as assemblies from the NuGet cache. 

These kind of tools have a dependency graph that is completely separate from the dependency graph of the project that 
uses them. The restore process will first restore the project's dependencies, and will then restore each of the tools and 
their dependencies. 

You can find richer examples and different combinations of this in the [.NET Core CLI repo](https://github.com/dotnet/cli/tree/rel/1.0.0-preview2/TestAssets/TestProjects). 
You can also see the [implementation of tools used](https://github.com/dotnet/cli/tree/rel/1.0.0-preview2/TestAssets/TestPackages) in the same repo. 

### Custom targets
NuGet has had the capability to package custom MSBuild target and props files for a while now and you can find the official documentation on this on the [NuGet documentation site](https://docs.microsoft.com/nuget/create-packages/creating-a-package#including-msbuild-props-and-targets-in-a-package). With the move in the CLI to using MSBuild, the same mechanism of extensibility applies to .NET Core projects. You would use this type of extensiblity when you want to extend the build process or when you want to access any of the artifacts in the build process, such as generated files or inspect the configuration under which the build is invoked etc. 

The sample target's project file is included below for reference. It shows how to use the new `csproj` syntax for instructing `dotnet pack` command what to package to place the targets files as well as assemblies into the `build` folder inside the package. Take note of the `<ItemGroup>` below that has the `Label` property set to "dotnet pack instructions". 

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
    <Content Include="build\*.targets;$(OutputPath)\*.dll;$(OutputPath)\*.json">
      <Pack>true</Pack>
      <PackagePath>build\</PackagePath>
    </Content>
  </ItemGroup>
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

Using the custom target depends solely on how you configure it. Since it is the usual MSBuild target, it can depend on a given target, run after another target and can also be manually invoked using the `dotnet msbuild /t:<target-name>` command. 

However, if you wish to provide a better user experience to your users, you can combine per-project tools and custom targets. In this scenario, the per-project tool would essentially just accept whatever needed parameters and would translate that into the required `dotnet msbuild` invocation that would execute the target. You can see a sample of this kind of synergy on the [MVP Summit 2016 Hackathon samples](https://github.com/dotnet/MVPSummitHackathon2016) repo in the [`dotnet-packer`](https://github.com/dotnet/MVPSummitHackathon2016/tree/master/dotnet-packer) project. 

### PATH-based extensibility
PATH-based extensibility is usually used for development machines where you need a tool that conceptually covers more 
than a single project. The main drawback of this extensions mechanism is that it is tied to the machine where the 
tool exists. If you need it on another machine, you would have to deploy it.

This pattern of CLI toolset extensibility is very simple. As covered in the [.NET Core CLI overview](index.md), `dotnet` driver 
can run any command that is named after the `dotnet-<command>` convention. The default resolution logic will first 
probe several locations and will finally fall to the system PATH. If the requested command exists in the system PATH 
and is a binary that can be invoked, `dotnet` driver will invoke it. 

The binary can be pretty much anything that the operating system can execute. On Unix systems, this means anything that 
has the execute bit set via `chmod +x`. On Windows it means anything that Windows knows how to run. 

As an example, let's take a look at a very simple implementation of a `dotnet clean` command. We will use `bash` to 
implement this command. The command will simply delete the `bin/` and `obj/` directories in the current directory. If 
the `--lock` argument is passed to it, it will also delete `project.lock.json` file. The entirety of the command is 
given below. 

```bash
#!/bin/bash

# Delete the bin and obj dirs
rm -rf bin/ obj/

LOCK_FILE=$1
if [[ "$LOCK_FILE" = "--lock" ]]; then
    rm project.lock.json
fi


echo "Cleaning complete..."
```

On macOS, we can save this script as `dotnet-clean` and set its executable bit with `chmod +x dotnet-clean`. We can then 
create a symbolic link to it in `/usr/local/bin` using the command `ln -s dotnet-clean /usr/local/bin/`. This will make 
it possible to invoke the clean command using the `dotnet clean` syntax. You can test this by creating an app, running 
`dotnet build` on it and then running `dotnet clean`. 

## Conclusion
The .NET Core CLI tools allow three main extensibility points. The per-project tools are contained within the project's 
context, but they allow easy installation through restoration. Custom targets allow you to easily extend the build process with custom tasks. PATH-based tools are good for general, cross-project tools that are usable on a single machine. 


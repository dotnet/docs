---
title: Create a template package for dotnet new
description: Learn how to create a csproj file that will build a template package for the dotnet new command.
author: adegeo
ms.date: 03/26/2021
ms.topic: tutorial
ms.author: adegeo
---

# Tutorial: Create a template package

With .NET, you can create and deploy templates that generate projects, files, even resources. This tutorial is part three of a series that teaches you how to create, install, and uninstall templates for use with the `dotnet new` command.

In this part of the series you'll learn how to:

> [!div class="checklist"]
>
> * Create a \*.csproj project to build a template package
> * Configure the project file for packing
> * Install a template package from a NuGet package file
> * Uninstall a template package by package ID

## Prerequisites

* Complete [part 1](cli-templates-create-item-template.md) and [part 2](cli-templates-create-project-template.md) of this tutorial series.

  This tutorial uses the two templates created in the first two parts of this tutorial. You can use a different template as long as you copy the template, as a folder, into the _working\templates\\_ folder.

* Open a terminal and navigate to the _working\\_ folder.

## Create a template package project

A template package is one or more templates packaged into a NuGet package. When you install or uninstall a template package, all templates contained in the package are added or removed, respectively. The previous parts of this tutorial series only worked with individual templates. To share a non-packed template, you have to copy the template folder and install via that folder. Because a template package can have more than one template in it, and is a single file, sharing is easier.

Template packages are represented by a NuGet package (_.nupkg_) file. And, like any NuGet package, you can upload the template package to a NuGet feed. The `dotnet new --install` command supports installing template package from a NuGet package feed. Additionally, you can install a template package from a _.nupkg_ file directly.

Normally you use a C# project file to compile code and produce a binary. However, the project can also be used to generate a template package. By changing the settings of the _.csproj_, you can prevent it from compiling any code and instead include all the assets of your templates as resources. When this project is built, it produces a template package NuGet package.

The package you'll create will include the [item template](cli-templates-create-item-template.md) and [package template](cli-templates-create-project-template.md) previously created. Because we grouped the two templates into the _working\templates\\_ folder, we can use the _working_ folder for the _.csproj_ file.

In your terminal, navigate to the _working_ folder. Create a new project and set the name to `templatepack` and the output folder to the current folder.

```dotnetcli
dotnet new console -n templatepack -o .
```

The `-n` parameter sets the _.csproj_ filename to _templatepack.csproj_. The `-o` parameter creates the files in the current directory. You should see a result similar to the following output.

```console
The template "Console Application" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on .\templatepack.csproj...
  Restore completed in 52.38 ms for C:\working\templatepack.csproj.

Restore succeeded.
```

The new project template generates a _Program.cs_ file. You can safely delete this file as it's not used by the templates.

Next, open the _templatepack.csproj_ file in your favorite editor and replace the content with the following XML:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <PackageType>Template</PackageType>
    <PackageVersion>1.0</PackageVersion>
    <PackageId>AdatumCorporation.Utility.Templates</PackageId>
    <Title>AdatumCorporation Templates</Title>
    <Authors>Me</Authors>
    <Description>Templates to use when creating an application for Adatum Corporation.</Description>
    <PackageTags>dotnet-new;templates;contoso</PackageTags>

    <TargetFramework>netstandard2.0</TargetFramework>

    <IncludeContentInPack>true</IncludeContentInPack>
    <IncludeBuildOutput>false</IncludeBuildOutput>
    <ContentTargetFolders>content</ContentTargetFolders>
    <NoWarn>$(NoWarn);NU5128</NoWarn>
  </PropertyGroup>

  <ItemGroup>
    <Content Include="templates\**\*" Exclude="templates\**\bin\**;templates\**\obj\**" />
    <Compile Remove="**\*" />
  </ItemGroup>

</Project>
```

The `<PropertyGroup>` settings in the XML above is broken into three groups. The first group deals with properties required for a NuGet package. The three `<Package*>` settings have to do with the NuGet package properties to identify your package on a NuGet feed. Specifically the `<PackageId>` value is used to uninstall the template package with a single name instead of a directory path. It can also be used to install the template package from a NuGet feed. The remaining settings such as `<Title>` and `<PackageTags>` have to do with metadata displayed on the NuGet feed. For more information about NuGet settings, see [NuGet and MSBuild properties](/nuget/reference/msbuild-targets).

> [!NOTE]
> To ensure that the template package appears in `dotnet new --search` results, set `<PackageType>` to `Template`.

The `<TargetFramework>` setting must be set so that MSBuild will run properly when you run the pack command to compile and pack the project.

The next three settings have to do with configuring the project correctly to include the templates in the appropriate folder in the NuGet pack when it's created.

The last setting suppresses a warning message that doesn't apply to template package projects.

The `<ItemGroup>` contains two settings. First, the `<Content>` setting includes everything in the _templates_ folder as content. It's also set to exclude any _bin_ folder or _obj_ folder to prevent any compiled code (if you tested and compiled your templates) from being included. Second, the `<Compile>` setting excludes all code files from compiling no matter where they're located. This setting prevents the project being used to create a template package from trying to compile the code in the _templates_ folder hierarchy.

## Build and install

Save the project file. Before building the template package, verify that your folder structure is correct. Any template you want to pack should be placed in the _templates_ folder, in its own folder. The folder structure should look similar to the following:

```console
working
│   templatepack.csproj
└───templates
    ├───extensions
    │   └───.template.config
    │           template.json
    └───consoleasync
        └───.template.config
                template.json
```

The _templates_ folder has two folders: _extensions_ and _consoleasync_.

In your terminal, from the _working_ folder, run the `dotnet pack` command. This command builds your project and creates a NuGet package in the _working\bin\Debug_ folder, as indicated by the following output:

```console
C:\working> dotnet pack

Microsoft (R) Build Engine version 16.8.0+126527ff1 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 123.86 ms for C:\working\templatepack.csproj.

  templatepack -> C:\working\bin\Debug\netstandard2.0\templatepack.dll
  Successfully created package 'C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg'.
```

Next, install the template package with the `dotnet new --install PATH_TO_NUPKG_FILE` command.

```console
C:\working> dotnet new -i C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg
The following template packages will be installed:
   C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg

Success: AdatumCorporation.Utility.Templates::1.0.0 installed the following templates:
Templates                                         Short Name               Language          Tags
--------------------------------------------      -------------------      ------------      ----------------------
Example templates: string extensions              stringext                [C#]              Common/Code
Example templates: async project                  consoleasync             [C#]              Common/Console/C#9
```

If you uploaded the NuGet package to a NuGet feed, you can use the `dotnet new --install PACKAGEID` command where `PACKAGEID` is the same as the `<PackageId>` setting from the _.csproj_ file. This package ID is the same as the NuGet package identifier.

## Uninstall the template package

No matter how you installed the template package, either with the _.nupkg_ file directly or by NuGet feed, removing a template package is the same. Use the `<PackageId>` of the template you want to uninstall. You can get a list of templates that are installed by running the `dotnet new --uninstall` command.

```dotnetcli
C:\working> dotnet new --uninstall

Template Instantiation Commands for .NET CLI

Currently installed items:
  Microsoft.DotNet.Common.ProjectTemplates.2.2
    Details:
      NuGetPackageId: Microsoft.DotNet.Common.ProjectTemplates.2.2
      Version: 1.0.2-beta4
      Author: Microsoft
    Templates:
      Class library (classlib) C#
      Class library (classlib) F#
      Class library (classlib) VB
      Console Application (console) C#
      Console Application (console) F#
      Console Application (console) VB
    Uninstall Command:
      dotnet new --uninstall  Microsoft.DotNet.Common.ProjectTemplates.2.2

... cut to save space ...

  AdatumCorporation.Utility.Templates
    Details:
      NuGetPackageId: AdatumCorporation.Utility.Templates
      Version: 1.0.0
      Author: Me
    Templates:
      Example templates: async project (consoleasync) C#
      Example templates: string extensions (stringext) C#
    Uninstall Command:
      dotnet new --uninstall AdatumCorporation.Utility.Templates
```

Run `dotnet new --uninstall  AdatumCorporation.Utility.Templates` to uninstall the template package. The command will output information about what template packages were uninstalled.

Congratulations! you've installed and uninstalled a template package.

## Next steps

To learn more about templates, most of which you've already learned, see the [Custom templates for dotnet new](../tools/custom-templates.md) article.

* [dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)
* [dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)
* [*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)

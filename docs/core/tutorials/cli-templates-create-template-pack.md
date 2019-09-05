---
title: Create a template pack for dotnet new
description: Learn how to create a csproj file that will build a template pack for the dotnet new command.
author: thraka
ms.date: 06/25/2019
ms.topic: tutorial
ms.author: adegeo
---

# Tutorial: Create a template pack

With .NET Core, you can create and deploy templates that generate projects, files, even resources. This tutorial is part three of a series that teaches you how to create, install, and uninstall, templates for use with the `dotnet new` command.

In this part of the series you'll learn how to:

> [!div class="checklist"]
>
> * Create a _.csproj* project to build a template pack
> * Configure the project file for packing
> * Install a template from a NuGet package file
> * Uninstall a template by package ID

## Prerequisites

* Complete [part 1](cli-templates-create-item-template.md) and [part 2](cli-templates-create-project-template.md) of this tutorial series.

  This tutorial uses the two templates created in the first two parts of this tutorial. It's possible you can use a different template as long as you copy the template as a folder into the _working\templates\\_ folder.

* Open a terminal and navigate to the _working\templates\\_ folder.

## Create a template pack project

A template pack is one or more templates packaged into a file. When you install or uninstall a pack, all templates contained in the pack are added or removed, respectively. The previous parts of this tutorial series only worked with individual templates. To share a non-packed template, you have to copy the template folder and install via that folder. Because a template pack can have more than one template in it, and is a single file, sharing is easier.

Template packs are represented by a NuGet package (_.nupkg_) file. And, like any NuGet package, you can upload the template pack to a NuGet feed. The `dotnet new -i` command supports installing template pack from a NuGet package feed. Additionally, you can install a template pack from a _.nupkg_ file directly.

Normally you use a C# project file to compile code and produce a binary. However, the project can also be used to generate a template pack. By changing the settings of the _.csproj_, you can prevent it from compiling any code and instead include all the assets of your templates as resources. When this project is built, it produces a template pack NuGet package.

The pack you'll create will include the [item template](cli-templates-create-item-template.md) and [package template](cli-templates-create-project-template.md) previously created. Because we grouped the two templates into the _working\templates\\_ folder, we can use the _working_ folder for the _.csproj_ file.

In your terminal, navigate to the _working_ folder. Create a new project and set the name to `templatepack` and the output folder to the current folder.

```console
dotnet new console -n templatepack -o .
```

The `-n` parameter sets the _.csproj_ filename to _templatepack.csproj_ and the `-o` parameters creates the files in the current directory. You should see a result similar to the following output.

```console
C:\working> dotnet new console -n templatepack -o .
The template "Console Application" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on .\templatepack.csproj...
  Restore completed in 52.38 ms for C:\working\templatepack.csproj.

Restore succeeded.
```

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
  </PropertyGroup>

  <ItemGroup>
    <Content Include="templates\**\*" Exclude="templates\**\bin\**;templates\**\obj\**" />
    <Compile Remove="**\*" />
  </ItemGroup>

</Project>
```

The `<PropertyGroup>` settings in the XML above is broken into three groups. The first group deals with properties required for a NuGet package. The three `<Package` settings have to do with the NuGet package properties to identify your package on a NuGet feed. Specifically the `<PacakgeId>` value is used to uninstall the template pack with a single name instead of a directory path. It can also be used to install the template pack from a NuGet feed. The remaining settings such as `<Title>` and `<Tags>` have to do with metadata displayed on the NuGet feed. For more information about NuGet settings, see [NuGet and MSBuild properties](/nuget/reference/msbuild-targets).

The `<TargetFramework>` setting must be set so that MSBuild will run properly when you run the pack command to compile and pack the project.

The last three settings have to do with configuring the project correctly to include the templates in the appropriate folder in the NuGet pack when it's created.

The `<ItemGroup>` contains two settings. First, the `<Content>` setting includes everything in the _templates_ folder as content. It's also set to exclude any _bin_ folder or _obj_ folder to prevent any compiled code (if you tested and compiled your templates) from being included. Second, the `<Compile>` setting excludes all code files from compiling no matter where they're located. This setting prevents the project being used to create a template pack from trying to compile the code in the _templates_ folder hierarchy.

## Build and install

Save this file and then run the pack command

```console
dotnet pack
```

This command will build your project and create a NuGet package in This should be the _working\bin\Debug_ folder.

```console
C:\working> dotnet pack
Microsoft (R) Build Engine version 16.2.0-preview-19278-01+d635043bd for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 123.86 ms for C:\working\templatepack.csproj.

  templatepack -> C:\working\bin\Debug\netstandard2.0\templatepack.dll
  Successfully created package 'C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg'.
```

Next, install the template pack file with the `dotnet new -i PATH_TO_NUPKG_FILE` command.

```console
C:\working> dotnet new -i C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg
Usage: new [options]

Options:
  -h, --help          Displays help for this command.
  -l, --list          Lists templates containing the specified name. If no name is specified, lists all templates.

... cut to save space ...

Templates                                         Short Name            Language          Tags
-------------------------------------------------------------------------------------------------------------------------------
Example templates: string extensions              stringext             [C#]              Common/Code
Console Application                               console               [C#], F#, VB      Common/Console
Example templates: async project                  consoleasync          [C#]              Common/Console/C#8
Class library                                     classlib              [C#], F#, VB      Common/Library
```

If you uploaded the NuGet package to a NuGet feed, you can use the `dotnet new -i PACKAGEID` command where `PACKAGEID` is the same as the `<PackageId>` setting from the _.csproj_ file. This package ID is the same as the NuGet package identifier.

## Uninstall the template pack

No matter how you installed the template pack, either with the _.nupkg_ file directly or by NuGet feed, removing a template pack is the same. Use the `<PackageId>` of the template you want to uninstall. You can get a list of templates that are installed by running the `dotnet new -u` command.

```console
C:\working> dotnet new -u
Template Instantiation Commands for .NET Core CLI

Currently installed items:
  Microsoft.DotNet.Common.ItemTemplates
    Templates:
      dotnet gitignore file (gitignore)
      global.json file (globaljson)
      NuGet Config (nugetconfig)
      Solution File (sln)
      Dotnet local tool manifest file (tool-manifest)
      Web Config (webconfig)

... cut to save space ...

  NUnit3.DotNetNew.Template
    Templates:
      NUnit 3 Test Project (nunit) C#
      NUnit 3 Test Item (nunit-test) C#
      NUnit 3 Test Project (nunit) F#
      NUnit 3 Test Item (nunit-test) F#
      NUnit 3 Test Project (nunit) VB
      NUnit 3 Test Item (nunit-test) VB
  AdatumCorporation.Utility.Templates
    Templates:
      Example templates: async project (consoleasync) C#
      Example templates: string extensions (stringext) C#
```

Run `dotnet new -u AdatumCorporation.Utility.Templates` to uninstall the template. The `dotnet new` command will output help information that should omit the templates you previously installed.

Congratulations! you've installed and uninstalled a template pack. 

## Next steps

To learn more about templates, most of which you've already learned, see the [Custom templates for dotnet new](../tools/custom-templates.md) article.

* [dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)
* [dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)
* [*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)

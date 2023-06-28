---
title: Create a template package for dotnet new
description: Learn how to create a csproj file that will build a template package for the dotnet new command.
author: adegeo
ms.date: 02/03/2022
ms.topic: tutorial
ms.author: adegeo
---

# Tutorial: Create a template package

With .NET, you can create and deploy templates that generate projects, files, and even resources. This tutorial is part three of a series that teaches you how to create, install, and uninstall templates for use with the `dotnet new` command.

You can view the completed template in the [.NET Samples GitHub repository](https://github.com/dotnet/samples/tree/main/core/tutorials/cli-templates-create-item-template).

In this part of the series you'll learn how to:

> [!div class="checklist"]
>
> * Create template package using  [Microsoft.TemplateEngine.Authoring.Templates](https://www.nuget.org/packages/Microsoft.TemplateEngine.Authoring.Templates)
> * Install a template package from a NuGet package file
> * Uninstall a template package by package ID

## Prerequisites

* Complete [part 1](cli-templates-create-item-template.md) and [part 2](cli-templates-create-project-template.md) of this tutorial series.

  This tutorial uses the two templates created in the first two parts of this tutorial. You can use a different template as long as you copy the template, as a folder, into the _working\templates\\_ folder.

* Open a terminal.

[!INCLUDE [dotnet6-syntax-note](includes/dotnet6-syntax-note.md)]

## Create a template package project

A template package is one or more templates packed into a NuGet package. When you install or uninstall a template package, all templates contained in the package are added or removed, respectively.

Template packages are represented by a NuGet package (_.nupkg_) file. And, like any NuGet package, you can upload the template package to a NuGet feed. The `dotnet new install` command supports installing template package from a NuGet package feed. Additionally, you can install a template package from a _.nupkg_ file directly.

Normally you use a C# project file to compile code and produce a binary. However, the project can also be used to generate a template package. By changing the settings of the _.csproj_, you can prevent it from compiling any code and instead include all the assets of your templates as resources. When this project is built, it produces a template package NuGet package.

The package you are going to generate will include the [item template](cli-templates-create-item-template.md) and [package template](cli-templates-create-project-template.md) previously created.

In your terminal, run the command:
```dotnetcli
dotnet new install Microsoft.TemplateEngine.Authoring.Templates
```
This [template package](https://github.com/dotnet/templating/tree/main/template_feed/Microsoft.TemplateEngine.Authoring.Templates) contains templates useful for the template authoring.

Navigate to the _working_ folder and run:
```dotnetcli
dotnet new templatepack --name "templatepack"
```
The `--name` parameter sets the _.csproj_ filename to _templatepack.csproj_. You should see a result similar to the following output.

```console
The template "Template Package" was created successfully.

Processing post-creation actions...
Description: Manual actions required
Manual instructions: Open *.csproj in the editor and complete the package metadata configuration. Copy the templates to 'content' folder. Fill in README.md.
```
Next, open the _templatepack.csproj_ file in a code editor and populate it according to the hints in the template:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- The package metadata. Fill in the properties marked as TODO below -->
    <!-- Follow the instructions on https://learn.microsoft.com/en-us/nuget/create-packages/package-authoring-best-practices -->
    <PackageId>AdatumCorporation.Utility.Templates</PackageId>
    <PackageVersion>1.0</PackageVersion>
    <Title>AdatumCorporation Templates</Title>
    <Authors>Me</Authors>
    <Description>Templates to use when creating an application for Adatum Corporation.</Description>
    <PackageTags>dotnet-new;templates;contoso</PackageTags>
    <PackageProjectUrl>https://github.com/dotnet/samples/tree/main/core/tutorials/cli-templates-create-item-template</PackageProjectUrl>

    <!-- Keep package type as 'Template' to show the package as template package on nuget.org and make you template available in dotnet new search.-->
    <PackageType>Template</PackageType>
    <TargetFramework>net8.0</TargetFramework>
    <IncludeContentInPack>true</IncludeContentInPack>
    <IncludeBuildOutput>false</IncludeBuildOutput>
    <ContentTargetFolders>content</ContentTargetFolders>
    <NoWarn>$(NoWarn);NU5128</NoWarn>
    <NoDefaultExcludes>true</NoDefaultExcludes>
    <PackageReadmeFile>README.md</PackageReadmeFile>
  </PropertyGroup>

  <PropertyGroup>
    <LocalizeTemplates>false</LocalizeTemplates>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.TemplateEngine.Tasks" Version="*" PrivateAssets="all" IsImplicitlyDefined="true"/>
  </ItemGroup>

  <ItemGroup>
    <Content Include="content\**\*" Exclude="content\**\bin\**;content\**\obj\**" />
    <Compile Remove="**\*" />
  </ItemGroup>

  <ItemGroup>
    <None Include="README.md" Pack="true" PackagePath="" />
  </ItemGroup>

</Project>
```
For getting more information about content of _templatepack.csproj_ file, navigate to [Create a NuGet package using MSBuild](https://learn.microsoft.com/en-us/nuget/create-packages/creating-a-package-msbuild).

## Build and install

Save changes in _templatepack.csproj_ file. Before building the template package, verify that your folder structure is correct. Any custom template should be placed in the _content_ folder, in its own folder. The hierarchy should look similar to:

```console
working
│   templatepack.csproj
└───content
    ├───extensions
    │   └───.template.config
    │           template.json
    └───consoleasync
        └───.template.config
                template.json
```

The _content_ folder has two folders: _extensions_ and _consoleasync_. By default, _content_ also contains _SampleTemplate_, that can safely deleted as it was added to authoring template for demonstration purposes.

In your terminal, from the _working_ folder, run the `dotnet pack` command. This command builds your project and creates a NuGet package in the _working\bin\Debug_ folder, as indicated by the following output:

```console
C:\working> dotnet pack

Microsoft (R) Build Engine version 16.8.0+126527ff1 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 123.86 ms for C:\working\templatepack.csproj.

  templatepack -> C:\working\bin\Debug\net8.0\templatepack.dll
  Successfully created package 'C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg'.
```

Next, install the template package with the `dotnet new install` command.

```console
C:\working> dotnet new install C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg
The following template packages will be installed:
   C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg

Success: AdatumCorporation.Utility.Templates::1.0.0 installed the following templates:
Templates                                         Short Name               Language          Tags
--------------------------------------------      -------------------      ------------      ----------------------
Example templates: string extensions              stringext                [C#]              Common/Code
Example templates: async project                  consoleasync             [C#]              Common/Console/C#9
```
If you uploaded the NuGet package to a NuGet feed, you can use the `dotnet new install <PACKAGE_ID>` command where `<PACKAGE_ID>` is the same as the `<PackageId>` setting from the _.csproj_ file. This package ID is the same as the NuGet package identifier.

## Uninstall the template package

No matter how you installed the template package, either with the _.nupkg_ file directly or by NuGet feed, removing a template package is the same. Use the `<PackageId>` of the template you want to uninstall. You can get a list of templates that are installed by running the `dotnet new uninstall` command.

```dotnetcli
C:\working> dotnet new uninstall
Currently installed items:
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
      dotnet new uninstall AdatumCorporation.Utility.Templates
```

Run `dotnet new uninstall AdatumCorporation.Utility.Templates` to uninstall the template package. The command will output information about what template packages were uninstalled.

Congratulations! You've installed and uninstalled a template package.

## Next steps

To learn more about templates, most of which you've already learned, see the [Custom templates for dotnet new](../tools/custom-templates.md) article.
* [Template Authoring Tools](https://github.com/dotnet/templating/tree/main/tools)
* [dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)
* [dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)
* [*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)

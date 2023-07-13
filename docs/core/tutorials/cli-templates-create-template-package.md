---
title: Create a template package for dotnet new
description: Learn how to create a csproj file that will build a template package for the dotnet new command.
author: adegeo
ms.date: 02/03/2022
zone_pivot_groups: dotnet-preview-version
ms.topic: tutorial
ms.author: adegeo
---

# Tutorial: Create a template package

::: zone pivot="dotnet-8-0"

With .NET, you can create and deploy templates that generate projects, files, and even resources. This tutorial is part three of a series that teaches you how to create, install, and uninstall templates for use with the `dotnet new` command.

You can view the completed template in the [.NET Samples GitHub repository](https://github.com/dotnet/samples/tree/main/core/tutorials/cli-templates-create-item-template).

In this part of the series you'll learn how to:

> [!div class="checklist"]
>
> * Create a template package by using the [Microsoft.TemplateEngine.Authoring.Templates](https://www.nuget.org/packages/Microsoft.TemplateEngine.Authoring.Templates) NuGet package.
> * Install a template package from a NuGet package file
> * Uninstall a template package by package ID

## Prerequisites

* Complete [part 1](cli-templates-create-item-template.md) and [part 2](cli-templates-create-project-template.md) of this tutorial series.

  This tutorial uses the two templates created in the first two parts of this tutorial. You can use a different template as long as you copy the template, as a folder, into the _working\templates\\_ folder.

* Open a terminal.

## Create a template package project

A template package is one or more templates packed into a NuGet package. When you install or uninstall a template package, all templates contained in the package are added or removed, respectively.

Template packages are represented by a NuGet package (_.nupkg_) file. And, like any NuGet package, you can upload the template package to a NuGet feed. The [`dotnet new install`](../tools/dotnet-new-install.md) command supports installing template packages from a NuGet package feed. Additionally, you can install a template package from a _.nupkg_ file directly.

Normally you use a C# project file to compile code and produce a binary. However, the project can also be used to generate a template package. By changing the settings of the _.csproj_, you can prevent it from compiling any code and instead include all the assets of your templates as resources. When this project is built, it produces a template package NuGet package.

The package you are going to generate will include the [item template](cli-templates-create-item-template.md) and [package template](cli-templates-create-project-template.md) previously created.

In order to create the template package, you will use the template for the template package provided by [Microsoft.TemplateEngine.Authoring.Templates](https://www.nuget.org/packages/Microsoft.TemplateEngine.Authoring.Templates).
In your terminal, run the command:

```dotnetcli
dotnet new install Microsoft.TemplateEngine.Authoring.Templates
```

This [template package](https://www.nuget.org/packages/Microsoft.TemplateEngine.Authoring.Templates) contains templates useful for template authoring. To install this package, nuget.org should be available as NuGet feed in the working directory.

Navigate to the _working_ folder and run:

```dotnetcli
dotnet new templatepack --name "AdatumCorporation.Utility.Templates"
```

The `--name` parameter sets the _.csproj_ filename to _AdatumCorporation.Utility.Templates.csproj_. You should see a result similar to the following output.

```output
The template "Template Package" was created successfully.

Processing post-creation actions...
Description: Manual actions required
Manual instructions: Open *.csproj in the editor and complete the package metadata configuration. Copy the templates to 'content' folder. Fill in README.md.
```

Next, open the _AdatumCorporation.Utility.Templates.csproj_ file in a code editor and populate it according to the hints in the template:

```xml
 <PropertyGroup>
    <!-- The package metadata. Fill in the properties marked as TODO below -->
    <!-- Follow the instructions on https://learn.microsoft.com/nuget/create-packages/package-authoring-best-practices -->
    <PackageId>AdatumCorporation.Utility.Templates</PackageId>
    <PackageVersion>1.0</PackageVersion>
    <Title>AdatumCorporation Templates</Title>
    <Authors>Me</Authors>
    <Description>Templates to use when creating an application for Adatum Corporation.</Description>
    <PackageTags>dotnet-new;templates;contoso</PackageTags>
    <PackageProjectUrl>https://github.com/dotnet/samples/tree/main/core/tutorials/cli-templates-create-item-template</PackageProjectUrl>
  </PropertyGroup>
```

To get more information about NuGet package metadata available in the _AdatumCorporation.Utility.Templates.csproj_ file, navigate to [Pack a template into a NuGet package (nupkg file)](https://learn.microsoft.com/dotnet/core/tools/custom-templates#pack-a-template-into-a-nuget-package-nupkg-file).

By default, the created project file includes [template authoring MSBuild tasks](https://aka.ms/templating-authoring-tools).

```xml
  <PropertyGroup>
    <LocalizeTemplates>false</LocalizeTemplates>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.TemplateEngine.Tasks" Version="*" PrivateAssets="all" IsImplicitlyDefined="true"/>
  </ItemGroup>
```

These MSBuild tasks provide template validation and [localization of the templates](https://aka.ms/templating-localization) capabilities. Localization is disabled by default. To enable creation of localization files, set `LocalizeTemplates` to `true`.

## Build and install

Save changes in _AdatumCorporation.Utility.Templates.csproj_ file. Before building the template package, verify that your folder structure is correct. Any custom template should be placed in the _content_ folder, in its own folder. The hierarchy should look similar to:

```console
working
│   AdatumCorporation.Utility.Templates.csproj
└───content
    ├───extensions
    │   └───.template.config
    │           template.json
    └───consoleasync
        └───.template.config
                template.json
```

The _content_ folder has two folders: _extensions_ and _consoleasync_. By default, _content_ also contains _SampleTemplate_, which can safely be deleted. It was added to the authoring template for demonstration purposes.

In your terminal, from the _working_ folder, run the `dotnet pack` command. This command builds your project and creates a NuGet package in the _working\bin\Debug_ folder, as indicated by the following output:

```output
C:\working> dotnet pack

Microsoft (R) Build Engine version 16.8.0+126527ff1 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 123.86 ms for C:\working\AdatumCorporation.Utility.Templates.csproj.

  AdatumCorporation.Utility.Templates -> C:\working\bin\Debug\net8.0\AdatumCorporation.Utility.Templates.dll
  Successfully created package 'C:\working\bin\Debug\AdatumCorporation.Utility.Templates.1.0.0.nupkg'.
```

Next, install the template package with the `dotnet new install` command.

```output
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

```output
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

* [Template Authoring Tools](https://aka.ms/templating-authoring-tools)
* [dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)
* [Template samples](https://aka.ms/template-samples)
* [*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)

::: zone-end

::: zone pivot="dotnet-7-0,dotnet-6-0"

With .NET, you can create and deploy templates that generate projects, files, and even resources. This tutorial is part three of a series that teaches you how to create, install, and uninstall templates for use with the `dotnet new` command.

You can view the completed template in the [.NET Samples GitHub repository](https://github.com/dotnet/samples/tree/main/core/tutorials/cli-templates-create-item-template).

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

[!INCLUDE [dotnet6-syntax-note](includes/dotnet6-syntax-note.md)]

## Create a template package project

A template package is one or more templates packaged into a NuGet package. When you install or uninstall a template package, all templates contained in the package are added or removed, respectively. The previous parts of this tutorial series only worked with individual templates. To share a non-packed template, you have to copy the template folder and install via that folder. Because a template package can have more than one template in it, and is a single file, sharing is easier.

Template packages are represented by a NuGet package (_.nupkg_) file. And, like any NuGet package, you can upload the template package to a NuGet feed. The `dotnet new install` command supports installing template package from a NuGet package feed. Additionally, you can install a template package from a _.nupkg_ file directly.

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
    <NoDefaultExcludes>true</NoDefaultExcludes>
  </PropertyGroup>

  <ItemGroup>
    <Content Include="templates\**\*" Exclude="templates\**\bin\**;templates\**\obj\**" />
    <Compile Remove="**\*" />
  </ItemGroup>

</Project>
```

The settings under `<PropertyGroup>` in the XML snippet are broken into three groups.

The first group deals with properties required for a NuGet package. The three `<Package*>` settings have to do with the NuGet package properties to identify your package on a NuGet feed. Specifically the `<PackageId>` value is used to uninstall the template package with a single name instead of a directory path. It can also be used to install the template package from a NuGet feed. The remaining settings, such as `<Title>` and `<PackageTags>`, have to do with metadata displayed on the NuGet feed. For more information about NuGet settings, see [NuGet and MSBuild properties](/nuget/reference/msbuild-targets).

> [!NOTE]
> To ensure that the template package appears in `dotnet new search` results, set `<PackageType>` to `Template`.

In the second group, the `<TargetFramework>` setting ensures that MSBuild executes properly when you run the pack command to compile and pack the project.

The third group includes settings that have to do with configuring the project to include the templates in the appropriate folder in the NuGet pack when it's created:

* The `<NoWarn>` setting suppresses a warning message that doesn't apply to template package projects.

* The `<NoDefaultExcludes>` setting ensures that files and folders that start with a `.` (like `.gitignore`) are part of the template. The *default* behavior of NuGet packages is to ignore those files and folders.

`<ItemGroup>` contains two items. First, the `<Content>` item includes everything in the _templates_ folder as content. It's also set to exclude any _bin_ folder or _obj_ folder to prevent any compiled code (if you tested and compiled your templates) from being included. Second, the `<Compile>` item excludes all code files from compiling no matter where they're located. This setting prevents the project that's used to create the template package from trying to compile the code in the _templates_ folder hierarchy.

## Build and install

Save the project file. Before building the template package, verify that your folder structure is correct. Any template you want to pack should be placed in the _templates_ folder, in its own folder. The folder structure should look similar to the following hierarchy:

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

* [dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)
* [Template samples](https://aka.ms/template-samples)
* [*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)

::: zone-end

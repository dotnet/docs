---
title: Create custom templates for dotnet new (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: 
keywords: dotnet new, CLI, CLI command, .NET Core, template, templating
author: guardrex
ms.author: mairaw
ms.date: 06/24/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: c28eb59d-4d18-4aba-bcd1-88bd887abc08
---

# Create custom templates for dotnet new

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

When you run [`dotnet new <TEMPLATE>`](dotnet-new.md#arguments), the `dotnet new` template engine creates project files and folders on disk from the template you specify to the command. The [.NET Core SDK](https://www.microsoft.com/net/download/core) provides several useful templates, but you can create your own custom templates for any type of .NET project, such as a service, tool, class library, or even just one or more files, such as a configuration file.

Templates work with any Microsoft framework, including .NET Core, .NET Framework, and Xamarin. Users install your custom template from a NuGet package on any NuGet feed (or by referencing the *nupkg* file directly) or by specifying a file system directory that contains the template. The template engine offers features that allow you to replace values, include and exclude files and regions of files, and execute custom processing operations when your template is used.

The template engine is open source, and the online code repository is at [dotnet/templating](https://github.com/dotnet/templating/) on GitHub. You can open an issue if you run into a problem or start a discussion for a new feature, possibly a feature that you contribute. Visit the [dotnet/dotnet-template-samples](https://github.com/dotnet/dotnet-template-samples) repo for samples of templates. More templates, including templates from third parties, are found at [Available templates for dotnet new](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new) at GitHub. A detailed pre-release blog post that describes how to create and install custom templates written by [Sayed Ibrahim Hashimi](https://github.com/sayedihashimi) is at [How to create your own templates for dotnet new](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/).

## Configuration

A template is composed of the following components:

- Source files and folders
- Configuration file (*template.json*)

### Source files and folders

The source files and folders are composed of whatever files and folders you want the templating engine to use when the `dotnet new <TEMPLATE>` command is executed. The templating engine is designed to use *runnable projects* as source code to produce projects. This has several benefits:

- The templating engine doesn't require you to inject special tokens into your project's source code.
- The code files aren't special files or modified in any way to work with the template engine, so the tools you normally use when working with projects also work with template content.
- You build, run, and debug your template projects just like you do for any of your projects.
- You can create a template from an existing project quickly by merely adding a *template.json* configuration file to the project.

Files and folders stored in the template aren't limited to formal .NET project types, such as a .NET Core or .NET Framework solutions. Source files and folders may consist of any content you wish to create when the template is used, even if the template engine produces just one file for its output. For example, you can create a template that consists of a single *web.config* file. When the template is used, it creates a modified *web.config* file in a project based on logic and settings you've provided in *template.json* along with values provided by the user passed as options to the `dotnet new <TEMPLATE>` command.

### template.json

The *template.json* file is placed in a *.template.config* folder in the root directory of the template. The file provides configuration to the template engine when creating output from the source files and folders. The minimum configuration requires the members shown in the following table, which is sufficient to add to a .NET Core app to produce a functional template.

| Member            | Type          | Description |
| ----------------- | ------------- | ----------- |
| `author`          | string        | The author of the template. |
| `classifications` | array(string) | Zero or more characteristics of the template that a user might search for it by. |
| `identity`        | string        | A unique name for this template. |
| `name`            | string        | The name for the template that users should see. |
| `shortName`       | string        | A default shorthand for selecting the template (applies to environments where the template name is specified by the user - not selected via a GUI). |

**Example**

```json
{
  "author": "Catalina Garcia",
  "classifications": [ "Common", "Console" ],
  "identity": "GarciaSoftware.ConsoleTemplate.CSharp",
  "name": "Garcia Software .NET Core console app",
  "shortName": "garciaconsole"
}
```

The full schema for the *template.json* file is found at the [JSON Schema Store](http://json.schemastore.org/template).

## .NET default templates

When you install the [.NET Core SDK](https://www.microsoft.com/net/download/core), you receive over a dozen built-in templates for creating projects and files, including console apps, class libraries, unit test projects, ASP.NET Core apps (including [Angular](https://angular.io/) and [React](https://facebook.github.io/react/) projects), and configuration files. To list the built-in templates, execute the `dotnet new` command with the `-l|--list` option:

```console
dotnet new -l
```

## Packing a template into a NuGet package

Currently, a custom template is packed with [nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe) (not [dotnet pack](dotnet-pack.md)).

The contents of the project folder, together with its *.template.config\template.json* file, is placed into a folder named *content*. Next to the *content* folder, add a [*nuspec* file](https://docs.microsoft.com/nuget/create-packages/creating-a-package), which is an XML manifest file that describes a package's contents and drives the process of creating the NuGet package.

Include a **\<packageTypes>\<packageType>** element with a `name` attribute value of `Template` in the file. Both the *content* folder and the *nuspec* file should reside in the same directory. The table shows the minimum *nuspec* file elements required to produce a template as a NuGet package.

| Element            | Type   | Description |
| ------------------ | ------ | ----------- |
| **\<authors>**     | string | A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors. |
| **\<description>** | string | A long description of the package for UI display. |
| **\<id>**          | string | The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package will reside in. IDs may not contain spaces or characters that are not valid for a URL, and generally follow .NET namespace rules. See Choosing a unique package identifier for guidance. |
| **\<packageType>** | string | Place this element inside a **\<packageTypes>** element among the **\<metadata>** elements. Set the `name` attribute of the element to `Template`. |
| **\<version>**     | string | The version of the package, following the major.minor.patch pattern. Version numbers may include a pre-release suffix as described in [Prerelease Packages](https://docs.microsoft.com/nuget/create-packages/prerelease-packages#semantic-versioning). |

See the [.nuspec reference](https://docs.microsoft.com/nuget/schema/nuspec) for the complete *nuspec* file schema.

**Example**

```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd">
  <metadata>
    <id>GarciaSoftware.ConsoleTemplate.CSharp</id>
    <version>1.0.0</version>
    <description>
      The GarciaSoftware.ConsoleTemplate.CSharp project template creates a special .NET Core console app. Install the template with 'dotnet new -i GarciaSoftware.ConsoleTemplate.CSharp'. Create a project with the template by running 'dotnet new garciaconsole'.
    </description>
    <authors>Catalina Garcia</authors>
    <packageTypes>
      <packageType name="Template" />
    </packageTypes>
  </metadata>
</package>
```

[Create the package](https://docs.microsoft.com/nuget/create-packages/creating-a-package#creating-the-package) using the `nuget pack <your_nuspec_file>.nuspec` command.

**Example**

```console
nuget pack C:\Users\<USER>\Documents\Templates\GarciaSoftware.ConsoleTemplate.CSharp\GarciaSoftware.ConsoleTemplate.CSharp.nuspec
```

## Installing a template

You install a custom template from a NuGet package on any NuGet feed (or by referencing a *nupkg* file directly) or by specifying a file system directory that contains a templating configuration. Use the `-i|--install` install option with the `dotnet new` command.

### To install a template from a NuGet package stored at [nuget.org](https://www.nuget.org/):

```console
dotnet new -i <NUGET_PACKAGE_ID>
```

**Example**

```console
dotnet new -i GarciaSoftware.ConsoleTemplate.CSharp
```

> [!NOTE]
> The example is for demonstration purposes only. There isn't a `GarciaSoftware.ConsoleTemplate.CSharp` NuGet package at nuget.org. If you run the command, no template is installed. However, you can install a template that hasn't been published to nuget.org by referencing the *nupkg* file directly on your local file system as shown in the next section.

### To install a template from a local *nupkg* file:

```console
dotnet new -i <PATH_TO_NUPKG_FILE>
```

**Example**

```console
dotnet new -i C:/Users/Garcia/GarciaSoftware.ConsoleTemplate.CSharp.1.0.0.nupkg
```

### To install a template from a file system directory (the project folder containing the project and the *.template.config* folder):

```console
dotnet new -i <FILE_SYSTEM_DIRECTORY>
```

**Example**

```console
dotnet new -i C:/Users/Garcia/Documents/Templates/GarciaSoftware.ConsoleTemplate.CSharp/content
```

## Uninstalling a template

You uninstall a custom template by referencing a NuGet package by its `id` or by specifying a file system directory that contains a templating configuration. Use the `-u|--uninstall` install option with the `dotnet new` command.

### To uninstall a template from a NuGet package stored at [nuget.org](https://www.nuget.org/):

```console
dotnet new -u <NUGET_PACKAGE_ID>
```

**Example**

```console
dotnet new -u GarciaSoftware.ConsoleTemplate.CSharp
```

> [!NOTE]
> The example is for demonstration purposes only. There isn't a `GarciaSoftware.ConsoleTemplate.CSharp` NuGet package at nuget.org or installed with the .NET Core SDK. If you run the command, no package/template is uninstalled and you receive the following exception:
> 
> > Could not find something to uninstall called 'GarciaSoftware.ConsoleTemplate.CSharp'.

### To uninstall a template from a local *nupkg* file:

Although you can install a template from a *nupkg* file on your local file system by referecing the *nupkg* file directly with the `dotnet new -i <PATH_TO_NUPKG_FILE>` command; when you wish to uninstall the template, only reference it by it's `id` (for example, `dotnet new -u <NUGET_PACKAGE_ID>`). **Attempting to uninstall a template using `dotnet new -u <PATH_TO_NUPKG_FILE>` fails.**

```console
dotnet new -u <NUGET_PACKAGE_ID>
```

**Example**

```console
dotnet new -u GarciaSoftware.ConsoleTemplate.CSharp.1.0.0
```

### To uninstall a template from a file system directory (the project folder containing the project and the *.template.config* folder):

```console
dotnet new -u <FILE_SYSTEM_DIRECTORY>
```

**Example**

```console
dotnet new -u C:/Users/Garcia/Documents/Templates/content
```

## Creating a project from a template

After a template is installed, use the template by executing the `dotnet new <TEMPLATE>` command from the directory where you want to the template engine's output placed (unless you're using the `dotnet new` option `-o|--output` to specify a specific directory; see [`dotnet new` Options](dotnet-new.md#options) for more information). Supply the template's short name directly to the command:

```console
dotnet new <TEMPLATE>
```

**Example**

From a new project folder created at *C:/Users/Garcia/Documents/Projects/MyConsoleApp*, create a project from the `garciaconsole` template:

```console
dotnet new garciaconsole
```

## See also

[dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)   
[How to create your own templates for dotnet new](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/)   
[*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)   

---
title: Custom templates for dotnet new
description: Learn about custom templates for any type of .NET project or files.
keywords: dotnet new,CLI,CLI command,.NET Core,template,templating
author: guardrex
ms.author: mairaw
ms.date: 08/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.workload: 
  - dotnetcore
---

# Custom templates for dotnet new

The [.NET Core SDK](https://www.microsoft.com/net/download/core) comes with many templates pre-installed to use with the [`dotnet new` command](dotnet-new.md). Starting with .NET Core 2.0, you can create your own custom templates for any type of project, such as an app, service, tool, or class library. You can even create a template that outputs one or more independent files, such as a configuration file.

You can install custom templates from a NuGet package on any NuGet feed, by referencing a NuGet *nupkg* file directly, or by specifying a file system directory that contains the template. The template engine offers features that allow you to replace values, include and exclude files and regions of files, and execute custom processing operations when your template is used.

The template engine is open source, and the online code repository is at [dotnet/templating](https://github.com/dotnet/templating/) on GitHub. Visit the [dotnet/dotnet-template-samples](https://github.com/dotnet/dotnet-template-samples) repo for samples of templates. More templates, including templates from third parties, are found at [Available templates for dotnet new](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new) on GitHub. For more information about creating and using custom templates, see [How to create your own templates for dotnet new](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/) and the [dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki).

To follow a walkthrough and create a template, see the [Create a custom template for dotnet new](~/docs/core/tutorials/create-custom-template.md) tutorial.

## Configuration

A template is composed of the following components:

- Source files and folders
- A configuration file (*template.json*)

### Source files and folders

The source files and folders include whatever files and folders you want the template engine to use when the `dotnet new <TEMPLATE>` command is executed. The template engine is designed to use *runnable projects* as source code to produce projects. This has several benefits:

- The template engine doesn't require you to inject special tokens into your project's source code.
- The code files aren't special files or modified in any way to work with the template engine. So, the tools you normally use when working with projects also work with template content.
- You build, run, and debug your template projects just like you do for any of your other projects.
- You can quickly create a template from an existing project just by adding a *template.json* configuration file to the project.

Files and folders stored in the template aren't limited to formal .NET project types, such as .NET Core or .NET Framework solutions. Source files and folders may consist of any content that you wish to create when the template is used, even if the template engine produces just one file for its output, such as a configuration file or a solution file. For example, you can create a template that contains a *web.config* source file and creates a modified *web.config* file for projects where the template is used. The modifications to source files are based on logic and settings you've provided in the *template.json* configuration file along with values provided by the user passed as options to the `dotnet new <TEMPLATE>` command.

### template.json

The *template.json* file is placed in a *.template.config* folder in the root directory of the template. The file provides configuration information to the template engine. The minimum configuration requires the members shown in the following table, which is sufficient to create a functional template.

| Member            | Type          | Description |
| ----------------- | ------------- | ----------- |
| `$schema`         | URI           | The JSON schema for the *template.json* file. Editors that support JSON schemas enable JSON-editing features when the schema is specified. For example, [Visual Studio Code](https://code.visualstudio.com/) requires this member to enable IntelliSense. Use a value of `http://json.schemastore.org/template`. |
| `author`          | string        | The author of the template. |
| `classifications` | array(string) | Zero or more characteristics of the template that a user might use to find the template when searching for it. The classifications also appear in the *Tags* column when it appears in a list of templates produced by using the <code>dotnet new -l&#124;--list</code> command. |
| `identity`        | string        | A unique name for this template. |
| `name`            | string        | The name for the template that users should see. |
| `shortName`       | string        | A default shorthand for selecting the template that applies to environments where the template name is specified by the user, not selected via a GUI. For example, the short name is useful when using templates from a command prompt with CLI commands. |

#### Example:

```json
{
  "$schema": "http://json.schemastore.org/template",
  "author": "Catalina Garcia",
  "classifications": [ "Common", "Console" ],
  "identity": "GarciaSoftware.ConsoleTemplate.CSharp",
  "name": "Garcia Software Console Application",
  "shortName": "garciaconsole"
}
```

The full schema for the *template.json* file is found at the [JSON Schema Store](http://json.schemastore.org/template).

## .NET default templates

When you install the [.NET Core SDK](https://www.microsoft.com/net/download/core), you receive over a dozen built-in templates for creating projects and files, including console apps, class libraries, unit test projects, ASP.NET Core apps (including [Angular](https://angular.io/) and [React](https://facebook.github.io/react/) projects), and configuration files. To list the built-in templates, execute the `dotnet new` command with the `-l|--list` option:

```console
dotnet new -l
```

## Packing a template into a NuGet package (nupkg file)

Currently, a custom template is packed on Windows with [nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe) (not [dotnet pack](dotnet-pack.md)). For cross-platform packaging, consider using [NuGetizer 3000](https://github.com/NuGet/Home/wiki/NuGetizer-3000).

The contents of the project folder, together with its *.template.config/template.json* file, are placed into a folder named *content*. Next to the *content* folder, add a [*nuspec* file](/nuget/create-packages/creating-a-package), which is an XML manifest file that describes a package's contents and drives the process of creating the NuGet package. Inside of a **\<packageTypes>** element in the *nuspec* file, include a **\<packageType>** element with a `name` attribute value of `Template`. Both the *content* folder and the *nuspec* file should reside in the same directory. The table shows the minimum *nuspec* file elements required to produce a template as a NuGet package.

| Element            | Type   | Description |
| ------------------ | ------ | ----------- |
| **\<authors>**     | string | A comma-separated list of packages authors, matching the profile names on nuget.org. Authors are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors. |
| **\<description>** | string | A long description of the package for UI display. |
| **\<id>**          | string | The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package will reside in. IDs may not contain spaces or characters that are not valid for a URL and generally follow .NET namespace rules. See [Choosing a unique package identifier and setting the version number](/nuget/create-packages/creating-a-package#choosing-a-unique-package-identifier-and-setting-the-version-number) for guidance. |
| **\<packageType>** | string | Place this element inside a **\<packageTypes>** element among the **\<metadata>** elements. Set the `name` attribute of the **\<packageType>** element to `Template`. |
| **\<version>**     | string | The version of the package, following the major.minor.patch pattern. Version numbers may include a pre-release suffix as described in the [Pre-release versions](/nuget/create-packages/prerelease-packages#semantic-versioning) topic. |

See the [.nuspec reference](/nuget/schema/nuspec) for the complete *nuspec* file schema. An example *nuspec* file for a template appears in the [Create a custom template for dotnet new](~/docs/core/tutorials/create-custom-template.md) tutorial.

[Create a package](/nuget/create-packages/creating-a-package#creating-the-package) using the `nuget pack <PATH_TO_NUSPEC_FILE>` command.

## Installing a template

Install a custom template from a NuGet package on any NuGet feed by referencing a *nupkg* file directly or by specifying a file system directory that contains a templating configuration. Use the `-i|--install` option with the [dotnet new](dotnet-new.md) command.

### To install a template from a NuGet package stored at nuget.org

```console
dotnet new -i <NUGET_PACKAGE_ID>
```

### To install a template from a local nupkg file

```console
dotnet new -i <PATH_TO_NUPKG_FILE>
```

### To install a template from a file system directory

The `FILE_SYSTEM_DIRECTORY` is the project folder containing the project and the *.template.config* folder:

```console
dotnet new -i <FILE_SYSTEM_DIRECTORY>
```

## Uninstalling a template

Uninstall a custom template by referencing a NuGet package by its `id` or by specifying a file system directory that contains a templating configuration. Use the `-u|--uninstall` install option with the [dotnet new](dotnet-new.md) command.

### To uninstall a template from a NuGet package stored at nuget.org

```console
dotnet new -u <NUGET_PACKAGE_ID>
```

### To uninstall a template from a local nupkg file

When you wish to uninstall the template, don't attempt to use the path to the *nupkg* file. *Attempting to uninstall a template using `dotnet new -u <PATH_TO_NUPKG_FILE>` fails.* Reference the package by its `id`:

```console
dotnet new -u <NUGET_PACKAGE_ID>
```

### To uninstall a template from a file system directory

The `FILE_SYSTEM_DIRECTORY` is the project folder containing the project and the *.template.config* folder:

```console
dotnet new -u <FILE_SYSTEM_DIRECTORY>
```

## Create a project using a custom template

After a template is installed, use the template by executing the `dotnet new <TEMPLATE>` command as you would with any other pre-installed template. You can also specify [options](dotnet-new.md#options) to the `dotnet new` command, including template specific options you configured in the template settings. Supply the template's short name directly to the command:

```console
dotnet new <TEMPLATE>
```

## See also

[Create a custom template for dotnet new (tutorial)](../tutorials/create-custom-template.md)  
[dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)  
[dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)  
[How to create your own templates for dotnet new](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/)  
[*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)  

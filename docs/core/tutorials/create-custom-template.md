---
title: Create a custom template for dotnet new
description: Learn how to create a custom template for the dotnet new command in this fun tutorial.
keywords: .NET, .NET Core, template, templating, tutorial, dotnet new
author: guardrex
ms.author: mairaw
ms.date: 08/12/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 519b910a-6efe-4394-9b81-0546aa3e7462
ms.workload: 
  - dotnetcore
---

# Create a custom template for dotnet new

This tutorial shows you how to:

- Create a basic template from an existing project or a new console app project.
- Pack the template for distribution at nuget.org or from a local *nupkg* file.
- Install the template from nuget.org, a local *nupkg* file, or the local file system.
- Uninstall the template.

If you prefer to proceed through the tutorial with a complete sample, download the [sample project template](https://github.com/dotnet/dotnet-template-samples/tree/master/16-nuget-package). The sample template is configured for NuGet distribution.

If you wish to use the downloaded sample with file system distribution, do the following:

- Move the contents of the *content* folder of the sample up one level into the *GarciaSoftware.ConsoleTemplate.CSharp* folder.
- Delete the empty *content* folder.
- Delete the *nuspec* file.

## Prerequisites

- Install the [.NET Core 2.0 SDK](https://www.microsoft.com/net/core) or later versions.
- Read the reference topic [Custom templates for dotnet new](../tools/custom-templates.md).

## Create a template from a project

Use an existing project that you've confirmed compiles and runs, or create a new console app project in a folder on your hard drive. This tutorial assumes that the name of the project folder is *GarciaSoftware.ConsoleTemplate.CSharp* stored at *Documents\Templates* in the user's profile. The tutorial project template name is in the format *\<Company Name>.\<Template Type>.\<Programming Language>*, but you're free to name your project and template anything you wish.

1. Add a folder to the root of the project named *.template.config*.
1. Inside the *.template.config* folder, create a *template.json* file to configure your template. For more information and member definitions for the *template.json* file, see the [Custom templates for dotnet new](../tools/custom-templates.md#templatejson) topic and the [*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template).

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

The template is finished. At this point, you have two options for template distribution. To continue this tutorial, choose one path or the other:

1. [NuGet distribution](#use-nuget-distribution): install the template from NuGet or from the local *nupkg* file, and use the installed template.
2. [File system distribution](#use-file-system-distribution).

## Use NuGet Distribution

### Pack the template into a NuGet package

1. Create a folder for the NuGet package. For the tutorial, the folder name *GarciaSoftware.ConsoleTemplate.CSharp* is used, and the folder is created inside a *Documents\NuGetTemplates* folder in the user's profile. Create a folder named *content* inside of the new template folder to hold the project files.
1. Copy the contents of your project folder, together with its *.template.config/template.json* file, into the *content* folder you created.
1. Next to the *content* folder, add a [*nuspec* file](/nuget/create-packages/creating-a-package). The nuspec file is an XML manifest file that describes a package's contents and drives the process of creating the NuGet package.
   
   ![Directory structure showing the layout of the NuGet package](./media/create-custom-template/nugetdirectorylayout.png)

1. Inside of a **\<packageTypes>** element in the *nuspec* file, include a **\<packageType>** element with a `name` attribute value of `Template`. Both the *content* folder and the *nuspec* file should reside in the same directory. The table shows the minimum *nuspec* file elements required to produce a template as a NuGet package.

   | Element            | Type   | Description |
   | ------------------ | ------ | ----------- |
   | **\<authors>**     | string | A comma-separated list of packages authors, matching the profile names on nuget.org. Authors are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors. |
   | **\<description>** | string | A long description of the package for UI display. |
   | **\<id>**          | string | The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package will reside in. IDs may not contain spaces or characters that are not valid for a URL and generally follow .NET namespace rules. See [Choosing a unique package identifier and setting the version number](/nuget/create-packages/creating-a-package#choosing-a-unique-package-identifier-and-setting-the-version-number) for guidance. |
   | **\<packageType>** | string | Place this element inside a **\<packageTypes>** element among the **\<metadata>** elements. Set the `name` attribute of the **\<packageType>** element to `Template`. |
   | **\<version>**     | string | The version of the package, following the major.minor.patch pattern. Version numbers may include a pre-release suffix as described in [Pre-release versions](/nuget/create-packages/prerelease-packages#semantic-versioning). |

   See the [.nuspec reference](/nuget/schema/nuspec) for the complete *nuspec* file schema.

   The *nuspec* file for the tutorial is named *GarciaSoftware.ConsoleTemplate.CSharp.nuspec* and contains the following content:

   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <package xmlns="http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd">
     <metadata>
       <id>GarciaSoftware.ConsoleTemplate.CSharp</id>
       <version>1.0.0</version>
       <description>
         Creates the Garcia Software console app.
       </description>
       <authors>Catalina Garcia</authors>
       <packageTypes>
         <packageType name="Template" />
       </packageTypes>
     </metadata>
   </package>
   ```

1. [Create the package](/nuget/create-packages/creating-a-package#creating-the-package) using the `nuget pack <PATH_TO_NUSPEC_FILE>` command. The following command assumes that the folder that holds the NuGet assets is at *C:\Users\\\<USER>\Documents\Templates\GarciaSoftware.ConsoleTemplate.CSharp*. But wherever you place the folder on your system, the `nuget pack` command accepts the path to the *nuspec* file:

   ```console
   nuget pack C:\Users\<USER>\Documents\NuGetTemplates\GarciaSoftware.ConsoleTemplate.CSharp\GarciaSoftware.ConsoleTemplate.CSharp.nuspec
   ```

### Publishing the package to nuget.org

To publish a NuGet package, follow the instructions in the [Create and publish a package](/nuget/quickstart/create-and-publish-a-package#publish-the-package) topic. However, we recommend that you don't publish the tutorial template to NuGet as it can never be deleted once published, only delisted. Now that you have the NuGet package in the form of a *nupkg* file, we suggest that you follow the instructions below to install the template directly from the local *nupkg* file.

### Install the template from a NuGet package

#### Install the template from the local *nupkg* file

To install the template from the *nupkg* file that you produced, use the `dotnet new` command with the `-i|--install` option and provide the path to the *nupkg* file:

```console
dotnet new -i C:\Users\<USER>\GarciaSoftware.ConsoleTemplate.CSharp.1.0.0.nupkg
```

#### Install the template from a NuGet package stored at nuget.org

If you wish to install a template from a NuGet package stored at nuget.org, use the `dotnet new` command with the `-i|--install` option and supply the name of the NuGet package:

```console
dotnet new -i GarciaSoftware.ConsoleTemplate.CSharp
```

> [!NOTE]
> The example is for demonstration purposes only. There isn't a `GarciaSoftware.ConsoleTemplate.CSharp` NuGet package at nuget.org, and we don't recommend that you publish and consume test templates from NuGet. If you run the command, no template is installed. However, you can install a template that hasn't been published to nuget.org by referencing the *nupkg* file directly on your local file system as shown in the previous section [Install the template from the local nupkg file](#install-the-template-from-the-local-nupkg-file).

If you'd like a live example of how to install a template from a package at nuget.org, you can use the [NUnit 3 template for dotnet-new](https://www.nuget.org/packages/NUnit3.DotNetNew.Template/). This template sets up a project to use NUnit unit testing. Use the following command to install it:

```console
dotnet new -i NUnit3.DotNetNew.Template
```

When you list the templates with `dotnet new -l`, you see the *NUnit 3 Test Project* with a short name of *nunit* in the template list. You're ready to use the template in the next section.

![Console window showing the NUnit template listed with other installed templates](./media/create-custom-template/nunit1.png)

### Create a project from the template

After the template is installed from NuGet, use the template by executing the `dotnet new <TEMPLATE>` command from the directory where you want to the template engine's output placed (unless you're using the `-o|--output` option to specify a specific directory). For more information, see [`dotnet new` Options](~/docs/core/tools/dotnet-new.md#options). Supply the template's short name directly to the `dotnet new` command. To create a project from the NUnit template, run the following command:

```console
dotnet new nunit
```

The console shows that the project is created and that the project's packages are restored. After the command is run, the project is ready for use.

![Console window showing the output of the dotnet new command as it creates the NUnit project and restores the project dependencies](./media/create-custom-template/nunit2.png)

### To uninstall a template from a NuGet package stored at nuget.org

```console
dotnet new -u GarciaSoftware.ConsoleTemplate.CSharp
```

> [!NOTE]
> The example is for demonstration purposes only. There isn't a `GarciaSoftware.ConsoleTemplate.CSharp` NuGet package at nuget.org or installed with the .NET Core SDK. If you run the command, no package/template is uninstalled and you receive the following exception:
> 
> > Could not find something to uninstall called 'GarciaSoftware.ConsoleTemplate.CSharp'.

If you installed the [NUnit 3 template for dotnet-new](https://www.nuget.org/packages/NUnit3.DotNetNew.Template/) and wish to uninstall it, use the following command:

```console
dotnet new -u NUnit3.DotNetNew.Template
```

### Uninstall the template from a local nupkg file

When you wish to uninstall the template, don't attempt to use the path to the *nupkg* file. *Attempting to uninstall a template using `dotnet new -u <PATH_TO_NUPKG_FILE>` fails.* Reference the package by its `id`:

```console
dotnet new -u GarciaSoftware.ConsoleTemplate.CSharp.1.0.0
```

## Use file system distribution

To distribute the template, place the project template folder in a location accessible to users on your network. Use the `dotnet new` command with the `-i|--install` option and specify the path to the template folder (the project folder containing the project and the *.template.config* folder).

The tutorial assumes the project template is stored in the *Documents/Templates* folder of the user's profile. From that location, install the template with the following command replacing \<USER> with the user's profile name:

```console
dotnet new -i C:\Users\<USER>\Documents\Templates\GarciaSoftware.ConsoleTemplate.CSharp
```

### Create a project from the template

After the template is installed from the file system, use the template by executing the `dotnet new <TEMPLATE>` command from the directory where you want to the template engine's output placed (unless you're using the `-o|--output` option to specify a specific directory). For more information, see [`dotnet new` Options](~/docs/core/tools/dotnet-new.md#options). Supply the template's short name directly to the `dotnet new` command.

From a new project folder created at *C:\Users\\\<USER>\Documents\Projects\MyConsoleApp*, create a project from the `garciaconsole` template:

```console
dotnet new garciaconsole
```

### Uninstall the template

If you created the template on your local file system at *C:\Users\\\<USER>\Documents\Templates\GarciaSoftware.ConsoleTemplate.CSharp*, uninstall it with the `-u|--uninstall` switch and the path to the template folder:

```console
dotnet new -u C:\Users\<USER>\Documents\Templates\GarciaSoftware.ConsoleTemplate.CSharp
```

> [!NOTE]
> To uninstall the template from your local file system, you need to fully qualify the path. For example, *C:\Users\\\<USER>\Documents\Templates\GarciaSoftware.ConsoleTemplate.CSharp* will work, but *./GarciaSoftware.ConsoleTemplate.CSharp* from the containing folder will not.
> Additionally, do not include a final terminating directory slash on your template path.

## See also

[dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)  
[dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)  
[How to create your own templates for dotnet new](https://blogs.msdn.microsoft.com/dotnet/2017/04/02/how-to-create-your-own-templates-for-dotnet-new/)  
[*template.json* schema at the JSON Schema Store](http://json.schemastore.org/template)  

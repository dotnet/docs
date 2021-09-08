---
title: Create a project template for dotnet new
description: Learn how to create a project template for the dotnet new command.
author: adegeo
ms.date: 12/11/2020
ms.topic: tutorial
ms.author: adegeo
recommendations: false
---

# Tutorial: Create a project template

With .NET, you can create and deploy templates that generate projects, files, even resources. This tutorial is part two of a series that teaches you how to create, install, and uninstall, templates for use with the `dotnet new` command.

In this part of the series you'll learn how to:

> [!div class="checklist"]
>
> * Create the resources of a project template
> * Create the template config folder and file
> * Install a template from a file path
> * Test an item template
> * Uninstall an item template

## Prerequisites

* Complete [part 1](cli-templates-create-item-template.md) of this tutorial series.
* Open a terminal and navigate to the _working\templates_ folder.

## Create a project template

Project templates produce ready-to-run projects that make it easy for users to start with a working set of code. .NET includes a few project templates such as a console application or a class library. In this example, you'll create a new console project that enables C# 9.0 and produces an `async main` entry point.

In your terminal, navigate to the _working\templates_ folder and create a new subfolder named _consoleasync_. Enter the subfolder and run `dotnet new console` to generate the standard console application. You'll be editing the files produced by this template to create a new template.

```console
working
└───templates
    └───consoleasync
            consoleasync.csproj
            Program.cs
```

## Modify Program.cs

Open up the _program.cs_ file. The console project doesn't use an asynchronous entry point, so let's add that. Change your code to the following and save the file.

```csharp
using System;
using System.Threading.Tasks;

namespace consoleasync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Console.Out.WriteAsync("Hello World with C# 9.0!");
        }
    }
}
```

## Modify consoleasync.csproj

Let's update the C# language version the project uses to version 9.0. Edit the _consoleasync.csproj_ file and add the `<LangVersion>` setting to a `<PropertyGroup>` node.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>

    <LangVersion>9.0</LangVersion>

  </PropertyGroup>
  
</Project>
```

## Build the project

Before you complete a project template, you should test it to make sure it compiles and runs correctly.

In your terminal, run the following command.

```dotnetcli
dotnet run
```

You get the following output.

```console
Hello World with C# 9.0!
```

You can delete the _obj_ and _bin_ folders created by using `dotnet run`. Deleting these files ensures your template only includes the files related to your template and not any files that result from a build action.

Now that you have the content of the template created, you need to create the template config at the root folder of the template.

## Create the template config

Templates are recognized in .NET by a special folder and config file that exist at the root of your template. In this tutorial, your template folder is located at _working\templates\consoleasync_.

When you create a template, all files and folders in the template folder are included as part of the template except for the special config folder. This config folder is named _.template.config_.

First, create a new subfolder named _.template.config_, enter it. Then, create a new file named _template.json_. Your folder structure should look like this.

```console
working
└───templates
    └───consoleasync
        └───.template.config
                template.json
```

Open the _template.json_ with your favorite text editor and paste in the following json code and save it.

```json
{
  "$schema": "http://json.schemastore.org/template",
  "author": "Me",
  "classifications": [ "Common", "Console", "C#9" ],
  "identity": "ExampleTemplate.AsyncProject",
  "name": "Example templates: async project",
  "shortName": "consoleasync",
  "tags": {
    "language": "C#",
    "type": "project"
  }
}
```

This config file contains all of the settings for your template. You can see the basic settings such as `name` and `shortName` but also there's a `tags/type` value that's set to `project`. This designates your template as a project template. There's no restriction on the type of template you create. The `item` and `project` values are common names that .NET recommends so that users can easily filter the type of template they're searching for.

The `classifications` item represents the **tags** column you see when you run `dotnet new` and get a list of templates. Users can also search based on classification tags. Don't confuse the `tags` property in the json file with the `classifications` tags list. They're two different things unfortunately named similarly. The full schema for the *template.json* file is found at the [JSON Schema Store](http://json.schemastore.org/template). For more information about the *template.json* file, see the [dotnet templating wiki](https://github.com/dotnet/templating/wiki).

Now that you have a valid _.template.config/template.json_ file, your template is ready to be installed. Before you install the template, make sure that you delete any extra files folders and files you don't want included in your template, like the _bin_ or _obj_ folders. In your terminal, navigate to the _consoleasync_ folder and run `dotnet new -i .\` to install the template located at the current folder. If you're using a Linux or macOS operating system, use a forward slash: `dotnet new -i ./`.

This command outputs the list of templates installed, which should include yours.

```dotnetcli
dotnet new -i .\
```

You get output similar to the following.

```console
Usage: new [options]

Options:
  -h, --help          Displays help for this command.
  -l, --list          Lists templates containing the specified name. If no name is specified, lists all templates.

... cut to save space ...

Templates                                         Short Name               Language          Tags
--------------------------------------------      -------------------      ------------      ----------------------
Console Application                               console                  [C#], F#, VB      Common/Console
Example templates: async project                  consoleasync             [C#]              Common/Console/C#9
Class library                                     classlib                 [C#], F#, VB      Common/Library
WPF Application                                   wpf                      [C#], VB          Common/WPF
```

### Test the project template

Now that you have a project template installed, test it.

1. Navigate to the _test_ folder

1. Create a new console application with the following command which generates a working project you can easily test with the `dotnet run` command.

    ```dotnetcli
    dotnet new consoleasync
    ```

    You get the following output.

    ```console
    The template "Example templates: async project" was created successfully.
    ```

1. Run the project using the following command.

    ```dotnetcli
    dotnet run
    ```

    You get the following output.

    ```console
    Hello World with C# 9.0!
    ```

Congratulations! You created and deployed a project template with .NET. In preparation for the next part of this tutorial series, you must uninstall the template you created. Make sure to delete all files from the _test_ folder too. This will get you back to a clean state ready for the next major section of this tutorial.

### Uninstall the template

Because you installed the template by using a file path, you must uninstall it with the **absolute** file path. You can see a list of templates installed by running the `dotnet new -u` command. Your template should be listed last. Use the `Uninstall Command` listed to uninstall your template.

```dotnetcli
dotnet new -u
```

You get output similar to the following.

```console
Template Instantiation Commands for .NET Core CLI

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
      dotnet new -u Microsoft.DotNet.Common.ProjectTemplates.2.2

... cut to save space ...

  C:\Test\templatetutorial\working\templates\consoleasync
    Templates:
      Example templates: async project (consoleasync) C#
    Uninstall Command:
      dotnet new -u C:\working\templates\consoleasync
```

To uninstall the template that you created, run the `Uninstall Command` that is shown in the output.

```dotnetcli
dotnet new -u C:\working\templates\consoleasync
```

## Next steps

In this tutorial, you created a project template. To learn how to package both the item and project templates into an easy-to-use file, continue this tutorial series.

> [!div class="nextstepaction"]
> [Create a template pack](cli-templates-create-template-pack.md)

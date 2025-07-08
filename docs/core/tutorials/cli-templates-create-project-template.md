---
title: Create a project template for dotnet new
description: Learn how to create a project template for the dotnet new command.
author: adegeo
ms.date: 09/08/2023
ms.topic: tutorial
ms.author: adegeo
---

# Tutorial: Create a project template

With .NET, you can create and deploy templates that generate projects, files, even resources. This tutorial is part two of a series that teaches you how to create, install, and uninstall, templates for use with the `dotnet new` command.

> [!TIP]
> The official .NET templates that are shipped with the .NET SDK can be found in the following repositories:
>
> | Templates | Repository |
> |---|---|
> |Console, class library and common item templates|[dotnet/sdk](https://github.com/dotnet/sdk)|
> |ASP.NET and Blazor templates|[dotnet/aspnetcore](https://github.com/dotnet/aspnetcore)|
> |ASP.NET Single Page Application templates| [dotnet/spa-templates](https://github.com/dotnet/spa-templates)|
> |WPF templates|[dotnet/wpf](https://github.com/dotnet/wpf)|
> |Windows Forms templates|[dotnet/winforms](https://github.com/dotnet/winforms)|
> |Test templates|[dotnet/test-templates](https://github.com/dotnet/test-templates)|
> |MAUI templates|[dotnet/maui](https://github.com/dotnet/maui)|
>
> You can view the templates that are installed on your machine by running the `dotnet new list` command.

In this part of the series you'll learn how to:

> [!div class="checklist"]
>
> * Create the resources of a project template.
> * Create the template config folder and file.
> * Install a template from a file path.
> * Test an item template.
> * Uninstall an item template.

## Prerequisites

* Complete [part 1](cli-templates-create-item-template.md) of this tutorial series.
* Open a terminal and navigate to the _working\content_ folder.

[!INCLUDE [dotnet6-syntax-note](includes/dotnet6-syntax-note.md)]

## Create a project template

Project templates produce ready-to-run projects that make it easy for users to start with a working set of code. .NET includes a few project templates such as a console application or a class library. In this example, you create a new console application project that replaces the standard "Hello World" console output with one that runs asynchronously.

In your terminal, navigate to the _working\content_ folder and create a new subfolder named _consoleasync_. Enter the subfolder and run `dotnet new console` to generate the standard console application. You'll edit the files produced by this template to create a new template.

```console
working
└───content
    └───consoleasync
            consoleasync.csproj
            Program.cs
```

## Modify Program.cs

Open up the _Program.cs_ file. The standard console project doesn't asynchronously write to the console output, so let's add that. Change the code to the following and save the file:

```csharp
// See https://aka.ms/new-console-template for more information
await Console.Out.WriteAsync("Hello World with C#");
```

Now that you have the content of the template created, you need to create the template config at the root folder of the template.

## Create the template config

In this tutorial, your template folder is located at _working\content\consoleasync_.

Templates are recognized by .NET because they have a special folder and config file at the root of your template folder.

First, create a new subfolder named _.template.config_, and enter it. Then, create a new file named _template.json_. Your folder structure should look like this:

```console
working
└───content
    └───consoleasync
        └───.template.config
                template.json
```

Open the _template.json_ with your favorite text editor and paste in the following json code and save it.

```json
{
  "$schema": "http://json.schemastore.org/template",
  "author": "Me",
  "classifications": [ "Common", "Console" ],
  "identity": "ExampleTemplate.AsyncProject",
  "name": "Example templates: async project",
  "shortName": "consoleasync",
  "sourceName":"consoleasync",
  "tags": {
    "language": "C#",
    "type": "project"
  }
}
```

This config file contains all the settings for your template. You can see the basic settings, such as `name` and `shortName`, but there's also a `tags/type` value that's set to `project`. This categorizes your template as a "project" template. There's no restriction on the type of template you create. The `item` and `project` values are common names that .NET recommends so that users can easily filter the type of template they're searching for.

The `sourceName` item is what is replaced when the user uses the template. The value of `sourceName` in the config file is searched for in every file name and file content, and by default is replaced with the name of the current folder. When the `-n` or `--name` parameter is passed with the `dotnet new` command, the value provided is used instead of the current folder name. In the case of this template, `consoleasync` is replaced in the name of the _.csproj_ file.

The `classifications` item represents the **tags** column you see when you run `dotnet new` and get a list of templates. Users can also search based on classification tags. Don't confuse the `tags` property in the _template.json_ file with the `classifications` tags list. They're two different concepts that are unfortunately named the same. The full schema for the _template.json_ file is found at the [JSON Schema Store](http://json.schemastore.org/template) and is described at [Reference for template.json](https://github.com/dotnet/templating/wiki/Reference-for-template.json). For more information about the _template.json_ file, see the [dotnet templating wiki](https://github.com/dotnet/templating/wiki).

Now that you have a valid _.template.config/template.json_ file, your template is ready to be installed. Before you install the template, make sure that you delete any extra folders and files you don't want included in your template, like the _bin_ or _obj_ folders. In your terminal, navigate to the _consoleasync_ folder and run `dotnet new install .\` to install the template located at the current folder. If you're using a Linux or macOS operating system, use a forward slash: `dotnet new install ./`.

```dotnetcli
dotnet new install .\
```

This command outputs a list of the installed templates, which should include yours.

```console
The following template packages will be installed:
   <root path>\working\content\consoleasync

Success: <root path>\working\content\consoleasync installed the following templates:
Templates                                         Short Name               Language          Tags
--------------------------------------------      -------------------      ------------      ----------------------
Example templates: async project                  consoleasync             [C#]              Common/Console
```

## Test the project template

Now that you have a project template installed, test it.

01. Navigate to the _test_ folder.

01. Create a new console application with the following command, which generates a working project you can easily test with the `dotnet run` command.

    ```dotnetcli
    dotnet new consoleasync -n MyProject
    ```

    You get the following output.

    ```console
    The template "Example templates: async project" was created successfully.
    ```

01. Run the project using the following command.

    ```dotnetcli
    dotnet run
    ```

    You get the following output.

    ```console
    Hello World with C#
    ```

Congratulations! You created and deployed a project template with .NET. In preparation for the next part of this tutorial series, uninstall the template you created. Make sure to delete all files from the _test_ folder too. This gets you back to a clean state ready for the next part of this tutorial series.

## Uninstall the template

In your terminal, navigate to the  _consoleasync_ folder and run the following command to uninstall the template located in the current folder:

* **On Windows**: `dotnet new uninstall .\`
* **On Linux or macOS**: `dotnet new uninstall ./`

This command outputs a list of the templates that were uninstalled, which should include yours.

```console
Success: <root path>\working\content\consoleasync was uninstalled.
```

At any time, you can use `dotnet new uninstall` to see a list of installed template packages, including for each template package the command to uninstall it.

## Next steps

In this tutorial, you created a project template. To learn how to package both the item and project templates into an easy-to-use file, continue this tutorial series.

> [!div class="nextstepaction"]
> [Create a template package](cli-templates-create-template-package.md)

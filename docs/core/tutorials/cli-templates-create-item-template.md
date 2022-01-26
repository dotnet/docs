---
title: Create an item template for dotnet new - .NET CLI
titleSuffix: ""
description: Learn how to create an item template for the dotnet new command. Item templates can contain any number of files.
author: adegeo
ms.date: 12/11/2020
ms.topic: tutorial
ms.author: adegeo
recommendations: false
---

# Tutorial: Create an item template

With .NET, you can create and deploy templates that generate projects, files, even resources. This tutorial is part one of a series that teaches you how to create, install, and uninstall templates for use with the `dotnet new` command.

In this part of the series, you'll learn how to:

> [!div class="checklist"]
>
> * Create a class for an item template
> * Create the template config folder and file
> * Install a template from a file path
> * Test an item template
> * Uninstall an item template

## Prerequisites

* [.NET 5.0 SDK](https://dotnet.microsoft.com/download) or a later version.
* Read the reference article [Custom templates for dotnet new](../tools/custom-templates.md).

  The reference article explains the basics about templates and how they're put together. Some of this information will be reiterated here.

* Open a terminal and navigate to the _working\templates_ folder.

## Create the required folders

This series uses a "working folder" where your template source is contained and a "testing folder" used to test your templates. The working folder and testing folder should be under the same parent folder.

First, create the parent folder, the name does not matter. Then, create a subfolder named _working_. Inside of the _working_ folder, create a subfolder named _templates_.

Next, create a folder under the parent folder named _test_. The folder structure should look like the following.

```console
parent_folder
├───test
└───working
    └───templates
```

## Create an item template

An item template is a specific type of template that contains one or more files. These types of templates are useful when you want to generate something like a config, code, or solution file. In this example, you'll create a class that adds an extension method to the string type.

In your terminal, navigate to the _working\templates_ folder and create a new subfolder named _extensions_. Enter the folder.

```console
working
└───templates
    └───extensions
```

Create a new file named _CommonExtensions.cs_ and open it with your favorite text editor. This class will provide an extension method named `Reverse` that reverses the contents of a string. Paste in the following code and save the file:

```csharp
using System;

namespace System
{
    public static class StringExtensions
    {
        public static string Reverse(this string value)
        {
            var tempArray = value.ToCharArray();
            Array.Reverse(tempArray);
            return new string(tempArray);
        }
    }
}
```

Now that you have the content of the template created, you need to create the template config at the root folder of the template.

## Create the template config

Templates are recognized by a special folder and config file that exist at the root of your template. In this tutorial, your template folder is located at _working\templates\extensions_.

When you create a template, all files and folders in the template folder are included as part of the template except for the special config folder. This config folder is named _.template.config_.

First, create a new subfolder named _.template.config_, enter it. Then, create a new file named _template.json_. Your folder structure should look like this:

```console
working
└───templates
    └───extensions
        └───.template.config
                template.json
```

Open the _template.json_ with your favorite text editor and paste in the following JSON code and save it.

```json
{
  "$schema": "http://json.schemastore.org/template",
  "author": "Me",
  "classifications": [ "Common", "Code" ],
  "identity": "ExampleTemplate.StringExtensions",
  "name": "Example templates: string extensions",
  "shortName": "stringext",
  "tags": {
    "language": "C#",
    "type": "item"
  }
}
```

This config file contains all the settings for your template. You can see the basic settings, such as `name` and `shortName`, but there's also a `tags/type` value that is set to `item`. This categorizes your template as an item template. There's no restriction on the type of template you create. The `item` and `project` values are common names that .NET recommends so that users can easily filter the type of template they're searching for.

The `classifications` item represents the **tags** column you see when you run `dotnet new` and get a list of templates. Users can also search based on classification tags. Don't confuse the `tags` property in the \*.json file with the `classifications` tags list. They're two different things unfortunately named similarly. The full schema for the *template.json* file is found at the [JSON Schema Store](http://json.schemastore.org/template). For more information about the *template.json* file, see the [dotnet templating wiki](https://github.com/dotnet/templating/wiki).

Now that you have a valid _.template.config/template.json_ file, your template is ready to be installed. In your terminal, navigate to the  _extensions_ folder and run the following command to install the template located at the current folder:

* **On Windows**: `dotnet new --install .\`
* **On Linux or macOS**: `dotnet new --install ./`

This command outputs the list of templates installed, which should include yours.

```console
The following template packages will be installed:
   <root path>\working\templates\extensions

Success: <root path>\working\templates\extensions installed the following templates:
Templates                                         Short Name               Language          Tags
--------------------------------------------      -------------------      ------------      ----------------------
Example templates: string extensions              stringext                [C#]              Common/Code
```

## Test the item template

Now that you have an item template installed, test it. Navigate to the _test/_ folder and create a new console application with `dotnet new console`. This generates a working project you can easily test with the `dotnet run` command.

```dotnetcli
dotnet new console
```

You get output similar to the following.

```console
The template "Console Application" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\test\test.csproj...
  Restore completed in 54.82 ms for C:\test\test.csproj.

Restore succeeded.
```

Run the project with.

```dotnetcli
dotnet run
```

You get the following output.

```console
Hello World!
```

Next, run `dotnet new stringext` to generate the _CommonExtensions.cs_ from the template.

```dotnetcli
dotnet new stringext
```

You get the following output.

```console
The template "Example templates: string extensions" was created successfully.
```

Change the code in _Program.cs_ to reverse the `"Hello World"` string with the extension method provided by the template.

```csharp
Console.WriteLine("Hello World!".Reverse());
```

Run the program again and you'll see that the result is reversed.

```dotnetcli
dotnet run
```

You get the following output.

```console
!dlroW olleH
```

Congratulations! You created and deployed an item template with .NET. In preparation for the next part of this tutorial series, you must uninstall the template you created. Make sure to delete all files from the _test_ folder too. This will get you back to a clean state ready for the next major section of this tutorial.

## Uninstall the template

In your terminal, navigate to the  _extensions_ folder and run the following command to uninstall the template located at the current folder:

* **On Windows**: `dotnet new --uninstall .\`
* **On Linux or macOS**: `dotnet new --uninstall ./`

This command outputs a list of the templates that were uninstalled, which should include yours.

```console
Success: <root path>\working\templates\extensions was uninstalled.
```

At any time, you can use `dotnet new --uninstall` to see a list of installed template packages, including for each template package the command to uninstall it.

## Next steps

In this tutorial, you created an item template. To learn how to create a project template, continue this tutorial series.

> [!div class="nextstepaction"]
> [Create a project template](cli-templates-create-project-template.md)

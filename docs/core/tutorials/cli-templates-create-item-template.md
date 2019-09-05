---
title: Create an item template for dotnet new - .NET Core CLI
description: Learn how to create an item template for the dotnet new command. Item templates can contain any number of files.
author: thraka
ms.date: 06/25/2019
ms.topic: tutorial
ms.author: adegeo
---

# Tutorial: Create an item template

With .NET Core, you can create and deploy templates that generate projects, files, even resources. This tutorial is part one of a series that teaches you how to create, install, and uninstall, templates for use with the `dotnet new` command.

In this part of the series, you'll learn how to:

> [!div class="checklist"]
>
> * Create a class for an item template
> * Create the template config folder and file
> * Install a template from a file path
> * Test an item template
> * Uninstall an item template

## Prerequisites

* [.NET Core 2.2 SDK](https://www.microsoft.com/net/core) or later versions.
* Read the reference article [Custom templates for dotnet new](../tools/custom-templates.md).

  The reference article explains the basics about templates and how they're put together. Some of this information will be reiterated here.

* Open a terminal and navigate to the _working\templates\\_ folder.

## Create the required folders

This series uses a "working folder" where your template source is contained and a "testing folder" used to test your templates. The working folder and testing folder should be under the same parent folder.

First, create the parent folder, the name does not matter. Then, create a subfolder named _working_. Inside of the _working_ folder, create a subfolder named _templates_.

Next, create a folder under the parent folder named _test_. The folder structure should look like the following:

```console
parent_folder
├───test
└───working
    └───templates
```

## Create an item template

An item template is a specific type of template that contains one or more files. These types of templates are useful when you want to generate something like a config, code, or solution file. In this example, you'll create a class that adds an extension method to the string type.

In your terminal, navigate to the _working\templates\\_ folder and create a new subfolder named _extensions_. Enter the folder.

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

Templates are recognized in .NET Core by a special folder and config file that exist at the root of your template. In this tutorial, your template folder is located at _working\templates\extensions\\_.

When you create a template, all files and folders in the template folder are included as part of the template except for the special config folder. This config folder is named _.template.config_.

First, create a new subfolder named _.template.config_, enter it. Then, create a new file named _template.json_. Your folder structure should look like this:

```console
working
└───templates
    └───extensions
        └───.template.config
                template.json
```

Open the _template.json_ with your favorite text editor and paste in the following JSON code and save it:

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

This config file contains all the settings for your template. You can see the basic settings, such as `name` and `shortName`, but there's also a `tags/type` value that is set to `item`. This categorizes your template as an item template. There's no restriction on the type of template you create. The `item` and `project` values are common names that .NET Core recommends so that users can easily filter the type of template they're searching for.

The `classifications` item represents the **tags** column you see when you run `dotnet new` and get a list of templates. Users can also search based on classification tags. Don't confuse the `tags` property in the \*.json file with the `classifications` tags list. They're two different things unfortunately named similarly. The full schema for the *template.json* file is found at the [JSON Schema Store](http://json.schemastore.org/template). For more information about the *template.json* file, see the [dotnet templating wiki](https://github.com/dotnet/templating/wiki).

Now that you have a valid _.template.config/template.json_ file, your template is ready to be installed. In your terminal, navigate to the  _extensions_ folder and run the following command to install the template located at the current folder:

* **On Windows**: `dotnet new -i .\`
* **On Linux or macOS**: `dotnet new -i ./`

This command outputs the list of templates installed, which should include yours.

```console
C:\working\templates\extensions> dotnet new -i .\
Usage: new [options]

Options:
  -h, --help          Displays help for this command.
  -l, --list          Lists templates containing the specified name. If no name is specified, lists all templates.

... cut to save space ...

Templates                                         Short Name            Language          Tags
-------------------------------------------------------------------------------------------------------------------------------
Example templates: string extensions              stringext             [C#]              Common/Code
Console Application                               console               [C#], F#, VB      Common/Console
Class library                                     classlib              [C#], F#, VB      Common/Library
WPF Application                                   wpf                   [C#], VB          Common/WPF
Windows Forms (WinForms) Application              winforms              [C#], VB          Common/WinForms
Worker Service                                    worker                [C#]              Common/Worker/Web
```

## Test the item template

Now that you have an item template installed, test it. Navigate to the _test/_ folder and create a new console application with `dotnet new console`. This generates a working project you can easily test with the `dotnet run` command.

```console
C:\test> dotnet new console
The template "Console Application" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on C:\test\test.csproj...
  Restore completed in 54.82 ms for C:\test\test.csproj.

Restore succeeded.
```

```console
C:\test> dotnet run
Hello World!
```

Next, run `dotnet new stringext` to generate the _CommonExtensions.cs_ from the template.

```console
C:\test> dotnet new stringext
The template "Example templates: string extensions" was created successfully.
```

Change the code in _Program.cs_ to reverse the `"Hello World"` string with the extension method provided by the template.

```csharp
Console.WriteLine("Hello World!".Reverse());
```

Run the program again and you'll see that the result is reversed.

```console
C:\test> dotnet run
!dlroW olleH
```

Congratulations! You created and deployed an item template with .NET Core. In preparation for the next part of this tutorial series, you must uninstall the template you created. Make sure to delete all files from the _test_ folder too. This will get you back to a clean state ready for the next major section of this tutorial.

## Uninstall the template

Because you installed the template by file path, you must uninstall it with the **absolute** file path. You can see a list of templates installed by running the `dotnet new -u` command. Your template should be listed last. Use the path listed to uninstall your template with the `dotnet new -u <ABSOLUTE PATH TO TEMPLATE DIRECTORY>` command.

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
  C:\working\templates\extensions
    Templates:
      Example templates: string extensions (stringext) C#
```

```console
C:\working> dotnet new -u C:\working\templates\extensions
```

## Next steps

In this tutorial, you created an item template. To learn how to create a project template, continue this tutorial series.

> [!div class="nextstepaction"]
> [Create a project template](cli-templates-create-project-template.md)

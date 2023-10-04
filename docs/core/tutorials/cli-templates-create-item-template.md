---
title: Create an item template for dotnet new - .NET CLI
titleSuffix: ""
description: Learn how to create an item template for the dotnet new command. Item templates can contain any number of files.
author: adegeo
ms.date: 09/08/2023
ms.topic: tutorial
ms.author: adegeo
recommendations: false
---

# Tutorial: Create an item template

With .NET, you can create and deploy templates that generate projects, files, and resources. This tutorial is part one of a series that teaches you how to create, install, and uninstall templates for use with the `dotnet new` command.

You can view the completed template in the [.NET Samples GitHub repository](https://github.com/dotnet/samples/tree/main/core/tutorials/cli-templates-create-item-template).

> [!TIP]
> **Item** templates aren't shown in the **Add** > **New Item** dialog of Visual Studio.

In this part of the series, you'll learn how to:

> [!div class="checklist"]
>
> * Create a class for an item template.
> * Create the template config folder and file.
> * Install a template from a file path.
> * Test an item template.
> * Uninstall an item template.

## Prerequisites

* [.NET SDK 7.0.100](https://dotnet.microsoft.com/download) or a later version.

  The reference article explains the basics about templates and how they're put together. Some of this information is reiterated here.

* Open a terminal and navigate to a folder where you'll store and test the templates.

[!INCLUDE [dotnet6-syntax-note](includes/dotnet6-syntax-note.md)]

## Create the required folders

This series uses a "working folder" where your template source is contained and a "testing folder" used to test your templates. The working folder and testing folder should be under the same parent folder.

First, create the parent folder, the name doesn't matter. Then, create two subfolders named _working_ and _test_. Inside of the _working_ folder, create a subfolder named _content_.

The folder structure should look like the following.

```console
parent_folder
├───test
└───working
    └───content
```

## Create an item template

An item template is a specific type of template that contains one or more files. These types of templates are useful when you already have a project and you want to generate another file, like a config file or code file. In this example, you'll create a class that adds an extension method to the string type.

In your terminal, navigate to the _working\content_ folder and create a new subfolder named _extensions_.

```console
working
└───content
    └───extensions
```

Navigate to the _extensions_ folder and create a new file named _StringExtensions.cs_. Open the file in a text editor. This class will provide an extension method named `Reverse` that reverses the contents of a string. Paste in the following code and save the file:

```csharp
namespace System;

public static class StringExtensions
{
    public static string Reverse(this string value)
    {
        char[] tempArray = value.ToCharArray();
        Array.Reverse(tempArray);
        return new string(tempArray);
    }
}
```

Now that the content of the template is finished, the next step is to create the template config.

## Create the template config

In this part of the tutorial, your template folder is located at _working\content\extensions_.

Templates are recognized by .NET because they have a special folder and config file that exist at the root of your template folder.

First, create a new subfolder named _.template.config_, and enter it. Then, create a new file named _template.json_. Your folder structure should look like this:

```console
working
└───content
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
    },
    "symbols": {
      "ClassName":{
        "type": "parameter",
        "description": "The name of the code file and class.",
        "datatype": "text",
        "replaces": "StringExtensions",
        "fileRename": "StringExtensions",
        "defaultValue": "StringExtensions"
      }
    }
  }
```

This config file contains all the settings for your template. You can see the basic settings, such as `name` and `shortName`, but there's also a `tags/type` value that's set to `item`. This categorizes your template as an "item" template. There's no restriction on the type of template you create. The `item` and `project` values are common names that .NET recommends so that users can easily filter the type of template they're searching for.

The `classifications` item represents the **tags** column you see when you run `dotnet new` and get a list of templates. Users can also search based on classification tags. Don't confuse the `tags` property in the _template.json_ file with the `classifications` tags list. They're two different concepts that are unfortunately named the same. The full schema for the _template.json_ file is found at the [JSON Schema Store](http://json.schemastore.org/template) and is described at [Reference for template.json](https://github.com/dotnet/templating/wiki/Reference-for-template.json). For more information about the _template.json_ file, see the [dotnet templating wiki](https://github.com/dotnet/templating/wiki).

The `symbols` part of this JSON object is used to define the parameters that can be used in the template. In this case, there's one parameter defined, `ClassName`. The defined parameter contains the following settings:

- `type` - This is a mandatory setting and must be set to `parameter`.
- `description` - The description of the parameter, which is printed in the template help.
- `datatype` - The type of data of the parameter value when the parameter is used.
- `replaces` - Specifies a text value that should be replaced in all template files by the value of the parameter.
- `fileRename` - Similar to `replaces`, this specifies a text value that is replaced in the names of all of the template files by the value of the parameter.
- `defaultValue` - The default value of this parameter when the parameter isn't specified by the user.

When the template is used, the user can provide a value for the `ClassName` parameter, and this value replaces all occurrences of `StringExtensions`. If a value isn't provided, the `defaultValue` is used. For this template, there are two occurrences of `StringExtensions`: the file _StringExtensions.cs_ and the class _StringExtensions_. Because the `defaultValue` of the parameter is `StringExtensions`, the file name and class name remain unchanged if the parameter isn't specified when using the template. When a value is specified, for example `dotnet new stringext -ClassName MyExts`, the file is renamed _MyExts.cs_ and the class is renamed to _MyExts_.

To see what parameters are available for a template, use the `-?` parameter with the template name:

```dotnetcli
dotnet new stringext -?
```

Which produces the following output:

```console
Example templates: string extensions (C#)
Author: Me

Usage:
  dotnet new stringext [options] [template options]

Options:
  -n, --name <name>       The name for the output being created. If no name is specified, the name of the output directory is used.
  -o, --output <output>   Location to place the generated output.
  --dry-run               Displays a summary of what would happen if the given command line were run if it would result in a template creation.
  --force                 Forces content to be generated even if it would change existing files.
  --no-update-check       Disables checking for the template package updates when instantiating a template.
  --project <project>     The project that should be used for context evaluation.
  -lang, --language <C#>  Specifies the template language to instantiate.
  --type <item>           Specifies the template type to instantiate.

Template options:
  -C, --ClassName <ClassName>  The name of the code file and class.
                               Type: text
                               Default: StringExtensions
```

Now that you have a valid _.template.config/template.json_ file, your template is ready to be installed. In your terminal, navigate to the  _extensions_ folder and run the following command to install the template located at the current folder:

* **On Windows**: `dotnet new install .\`
* **On Linux or macOS**: `dotnet new install ./`

This command outputs the list of templates installed, which should include yours.

```console
The following template packages will be installed:
   <root path>\working\content\extensions

Success: <root path>\working\content\extensions installed the following templates:
Templates                                         Short Name               Language          Tags
--------------------------------------------      -------------------      ------------      ----------------------
Example templates: string extensions              stringext                [C#]              Common/Code
```

## Test the item template

Now that you have an item template installed, test it.

01. Navigate to the _test_ folder.
01. Create a new console application with `dotnet new console`, which generates a working project you can easily test with the `dotnet run` command.

    ```dotnetcli
    dotnet new console
    ```

    You get output similar to the following.

    ```output
    The template "Console Application" was created successfully.
    
    Processing post-creation actions...
    Running 'dotnet restore' on C:\test\test.csproj...
      Restore completed in 54.82 ms for C:\test\test.csproj.
    
    Restore succeeded.
    ```

01. Run the project using the following command.

    ```dotnetcli
    dotnet run
    ```

    You get the following output.

    ```output
    Hello, World!
    ```

01. Run `dotnet new stringext` to generate the _StringExtensions.cs_ file from the template.

    ```dotnetcli
    dotnet new stringext
    ```

    You get the following output.

    ```output
    The template "Example templates: string extensions" was created successfully.
    ```

01. Change the code in _Program.cs_ to reverse the `"Hello, World!"` string with the extension method provided by the template.

    ```csharp
    Console.WriteLine("Hello, World!".Reverse());
    ```

    Run the program again and see that the result is reversed.

    ```dotnetcli
    dotnet run
    ```

    You get the following output.

    ```output
    !dlroW ,olleH
    ```

Congratulations! You created and deployed an item template with .NET. In preparation for the next part of this tutorial series, uninstall the template you created. Make sure to delete all files and folders in the _test_ folder too. This gets you back to a clean state ready for the next part of this tutorial series.

## Uninstall the template

In your terminal, navigate to the  _extensions_ folder and run the following command to uninstall the templates located at the current folder:

* **On Windows**: `dotnet new uninstall .\`
* **On Linux or macOS**: `dotnet new uninstall ./`

This command outputs a list of the templates that were uninstalled, which should include yours.

```console
Success: <root path>\working\content\extensions was uninstalled.
```

At any time, you can use `dotnet new uninstall` to see a list of installed template packages, including for each template package the command to uninstall it.

## Next steps

In this tutorial, you created an item template. To learn how to create a project template, continue this tutorial series.

> [!div class="nextstepaction"]
> [Create a project template](cli-templates-create-project-template.md)

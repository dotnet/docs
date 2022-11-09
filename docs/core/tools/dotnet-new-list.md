---
title: dotnet new list
description: The dotnet new list command lists available templates.
ms.date: 04/29/2021
---
# dotnet new list

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet new list` -  Lists available templates to be run using `dotnet new`.

## Synopsis

```dotnetcli
dotnet new list [<TEMPLATE_NAME>] [--author <AUTHOR>] [-lang|--language {"C#"|"F#"|VB}]
    [--tag <TAG>] [--type <TYPE>] [--columns <COLUMNS>] [--columns-all]
    [-o|--output <output>] [--project <project>] [--ignore-constraints]
    [-d|--diagnostics] [--verbosity <LEVEL>] [-h|--help]
```

## Description

The `dotnet new list` command lists available templates to use with `dotnet new`. If the <TEMPLATE_NAME> is specified, lists templates containing the specified name. This option lists only default and installed templates. To find templates in NuGet that you can install locally, use the [`search`](dotnet-new-search.md) command.

Starting with .NET SDK 7.0.100, the `list` command might not show all the templates installed on the machine. It takes the result of template constraints into account, and the templates that can't be used won't be shown. To force show all the templates, use the `--ignore-constraints` option.

> [!NOTE]
> [!INCLUDE [new syntax](../../../includes/dotnet-new-7-0-syntax.md)]
>
> Examples of the old syntax:
>
> - List all Single Page Application (SPA) templates:
>   - since .NET SDK 6.0.100
>
>   ```dotnetcli
>   dotnet new --list spa
>   ```
>
>   - before .NET SDK 6.0.100
>
>   ```dotnetcli
>   dotnet new spa --list
>   ```

## Arguments

- **`TEMPLATE_NAME`**

  If the argument is specified, only the templates containing `<TEMPLATE_NAME>` in template name or short name will be shown.

## Options

- **`--author <AUTHOR>`**

  Filters templates based on template author. Partial match is supported. Available since .NET SDK 5.0.300.

- **`--columns <COLUMNS>`**

  Comma-separated list of columns to display in the output. The supported columns are:
  - `language` - A comma-separated list of languages supported by the template.
  - `tags` - The list of template tags.
  - `author` - The template author.
  - `type` - The template type: project or item.
  
  The template name and short name are always shown. The default list of columns is template name, short name, language, and tags. This list is equivalent to specifying `--columns=language,tags`.
  Available since .NET SDK 5.0.300.

- **`--columns-all`**

  Displays all columns in the output. Available since .NET SDK 5.0.300.

- **`-d|--diagnostics`**

  Enables diagnostic output. Available since .NET SDK 7.0.100.

- **`-h|--help`**

  Prints out help for the list command. Available since .NET SDK 7.0.100.

- **`--ignore-constraints`**

  Disables checking if the template meets the constraints to be run. Available since .NET SDK 7.0.100.

- **`-lang|--language {C#|F#|VB}`**

  Filters templates based on language supported by the template. The language accepted varies by the template. Not valid for some templates.

  > [!NOTE]
  > Some shells interpret `#` as a special character. In those cases, enclose the language parameter value in quotes. For example, `dotnet new --list --language "F#"`.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Location to place the generated output. The default is the current directory. For the list command, it might be necessary to specify the output directory to correctly evaluate constraints for the template. Available since .NET SDK 7.0.100.

- **`--project <PROJECT_PATH>`**

  The project that the template is added to. For the list command, it might be needed to specify the project the template is being added to to correctly evaluate constraints for the template. Available since .NET SDK 7.0.100.

- **`--tag <TAG>`**

  Filters templates based on template tags. To be selected, a template must have at least one tag that exactly matches the criteria. Available since .NET SDK 5.0.300.

- **`--type <TYPE>`**

  Filters templates based on template type. Predefined values are `project`, `item`, and `solution`.
  
- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, and `diag[nostic]`. Available since .NET SDK 7.0.100.

## Examples

- List all templates

  ```dotnetcli
  dotnet new list
  ```

- List all Single Page Application (SPA) templates:

  ```dotnetcli
  dotnet new list spa
  ```

- List all templates matching the *we* substring.

  ```dotnetcli
  dotnet new list we
  ```

- List all templates matching the *we* substring that support the F# language.

  ```dotnetcli
  dotnet new list we --language "F#"
  ```

- List all item templates.

  ```dotnetcli
  dotnet new list --type item
  ```

- List all C# templates, showing the author and the type in the output.

  ```dotnetcli
  dotnet new list --language "C#" --columns "author,type"
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new search command](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)

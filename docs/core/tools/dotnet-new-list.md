---
title: dotnet new --list option
description: The dotnet new --list option lists available templates.
ms.date: 04/29/2021
---
# dotnet new --list option

**This article applies to:** ✔️ .NET Core 2.0 SDK and later versions

## Name

`dotnet new --list` -  Lists available templates to be run using `dotnet new`.

## Synopsis

```dotnetcli
dotnet new [<TEMPLATE_NAME>] -l|--list [--author <AUTHOR>] [-lang|--language {"C#"|"F#"|VB}]
    [--tag <TAG>] [--type <TYPE>] [--columns <COLUMNS>] [--columns-all]
```

## Description

The `dotnet new --list` option lists available templates to use with `dotnet new`. If the <TEMPLATE_NAME> is specified, lists templates containing the specified name. This option lists only default and installed templates. To find templates in NuGet that you can install locally, use the [`--search`](dotnet-new-search.md) option.

## Arguments

- **`TEMPLATE_NAME`**

  If the argument is specified, only the templates containing `<TEMPLATE_NAME>` in template name or short name will be shown.

  > [!NOTE]
  > Starting with .NET SDK 6.0.100, you can put the `<TEMPLATE_NAME>` argument after the `--list` option. For example, `dotnet new --list web` provides the same result as `dotnet new web --list`.
  > Using more than one argument is not allowed.

## Options

- **`--author <AUTHOR>`**

  Filters templates based on template author. Partial match is supported. Available since .NET Core 5.0.300 SDK.

- **`--columns <COLUMNS>`**

  Comma-separated list of columns to display in the output. The supported columns are:
  - `language` - A comma-separated list of languages supported by the template.
  - `tags` - The list of template tags.
  - `author` - The template author.
  - `type` - The template type: project or item.
  
  The template name and short name are always shown. The default list of columns is template name, short name, language, and tags. This list is equivalent to specifying `--columns=language,tags`.
  Available since .NET Core 5.0.300 SDK.

- **`--columns-all`**

  Displays all columns in the output. Available since .NET Core 5.0.300 SDK.

- **`-lang|--language {C#|F#|VB}`**

  Filters templates based on language supported by the template. The language accepted varies by the template. Not valid for some templates.

  > [!NOTE]
  > Some shells interpret `#` as a special character. In those cases, enclose the language parameter value in quotes. For example, `dotnet new --list --language "F#"`.

- **`--tag <TAG>`**

  Filters templates based on template tags. To be selected, a template must have at least one tag that exactly matches the criteria. Available since .NET Core 5.0.300 SDK.

- **`--type <TYPE>`**

  Filters templates based on template type. Predefined values are `project`, `item`, and `solution`.

## Examples

- List all templates

  ```dotnetcli
  dotnet new --list
  ```

- List all Single Page Application (SPA) templates:
  - since .NET SDK 6.0.100

  ```dotnetcli
  dotnet new --list spa
  ```

  - before .NET SDK 6.0.100

  ```dotnetcli
  dotnet new spa --list
  ```

- List all templates matching the *we* substring.
  - since .NET SDK 6.0.100

  ```dotnetcli
  dotnet new --list we
  ```

  - before .NET SDK 6.0.100
  
  ```dotnetcli
  dotnet new we --list
  ```

- List all templates matching the *we* substring that support the F# language.

  ```dotnetcli
  dotnet new --list we --language "F#"
  ```

- List all item templates.

  ```dotnetcli
  dotnet new --list --type item
  ```

- List all C# templates, showing the author and the type in the output.

  ```dotnetcli
  dotnet new --list --language "C#" --columns "author,type"
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new --search option](dotnet-new-search.md)
- [Custom templates for dotnet new](custom-templates.md)

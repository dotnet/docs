---
title: dotnet new --search option
description: The dotnet new --search option searches for templates on NuGet.org.
ms.date: 04/29/2021
---
# dotnet new --search option

**This article applies to:** ✔️ .NET Core 5.0.300 SDK and later versions

## Name

`dotnet new --search` - searches for the templates supported by `dotnet new` on NuGet.org.

## Synopsis

```dotnetcli
dotnet new <TEMPLATE_NAME> --search

dotnet new [<TEMPLATE_NAME>] --search [--author <AUTHOR>] [-lang|--language {"C#"|"F#"|VB}]
    [--package <PACKAGE>] [--tag <TAG>] [--type <TYPE>]
    [--columns <COLUMNS>] [--columns-all]
```

## Description

The `dotnet new --search` option searches for templates supported by `dotnet new` on NuGet.org. When the <TEMPLATE_NAME> is specified, searches for templates containing the specified name.

## Arguments

- **`TEMPLATE_NAME`**

  If the argument is specified, only templates containing `<TEMPLATE_NAME>` in the template name or short name will be shown.
  The argument is mandatory when `--author`, `--language`, `--package`, `--tag` or `--type` options are not specified.

  > [!NOTE]
  > Starting with .NET SDK 6.0.100, you can put the `<TEMPLATE_NAME>` argument after the `--search` option. For example, `dotnet new --search web` provides the same result as `dotnet new web --search`.
  > Using more than one argument is not allowed.

## Options

- **`--author <AUTHOR>`**

  Filters templates based on template author. Partial match is supported.

- **`--columns <COLUMNS>`**

  Comma-separated list of columns to display in the output. The supported columns are:
  - `language` - A comma-separated list of languages supported by the template.
  - `tags` - The list of template tags.
  - `author` - The template author.
  - `type` - The template type: project or item.
  
  The template name, short name, package name and total downloads count are always shown. The default list of columns is template name, short name, author, language, package, and total downloads. This list is equivalent to specifying `--columns=author,language`.

- **`--columns-all`**

  Displays all columns in the output.

- **`-lang|--language {C#|F#|VB}`**

  Filters templates based on language supported by the template. The language accepted varies by the template. Not valid for some templates.

  > [!NOTE]
  > Some shells interpret `#` as a special character. In those cases, enclose the language parameter value in quotes. For example, `dotnet new --search --language "F#"`.

- **`--package <PACKAGE>`**

  Filters templates based on NuGet package ID. Partial match is supported.

- **`--tag <TAG>`**

  Filters templates based on template tags. To be selected, a template must have at least one tag that exactly matches the criteria.

- **`--type <TYPE>`**

  Filters templates based on template type. Predefined values are `project`, `item`, and `solution`.

  > [!NOTE]
  > To ensure that the template package appears in `dotnet new --search` result, set [the NuGet package type](/nuget/create-packages/set-package-type) to `Template`.

## Examples

- Search for all templates available on NuGet.org matching the *spa* substring.
  - since .NET SDK 6.0.100

  ```dotnetcli
  dotnet new --search spa
  ```

  - before .NET SDK 6.0.100

  ```dotnetcli
  dotnet new spa --search
  ```

- Search for all templates available on NuGet.org matching the *we* substring and supporting the F# language.
  - since .NET SDK 6.0.100

  ```dotnetcli
  dotnet new --search we --language "F#"
  ```

  - before .NET SDK 6.0.100
  
  ```dotnetcli
  dotnet new we --search --language "F#"
  ```

- Search for item templates.

  ```dotnetcli
  dotnet new --search --type item
  ```

- Search for all C# templates, showing the type and tags in the output.

  ```dotnetcli
  dotnet new --search --language "C#" --columns "type,tags"
  ```

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new --list option](dotnet-new-list.md)
- [Custom templates for dotnet new](custom-templates.md)

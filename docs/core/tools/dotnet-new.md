---
title: dotnet new <TEMPLATE>
description: The dotnet new command creates new .NET projects based on the specified template.
no-loc: [Blazor, WebAssembly]
ms.date: 02/15/2024
---
# dotnet new &lt;TEMPLATE&gt;

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet new` - Creates a new project, configuration file, or solution based on the specified template.

## Synopsis

```dotnetcli
dotnet new <TEMPLATE> [--dry-run] [--force] [-lang|--language {"C#"|"F#"|VB}]
    [-n|--name <OUTPUT_NAME>] [-f|--framework <FRAMEWORK>] [--no-update-check]
    [-o|--output <OUTPUT_DIRECTORY>] [--project <PROJECT_PATH>]
    [-d|--diagnostics] [--verbosity <LEVEL>] [Template options]

dotnet new -h|--help
```

## Description

The `dotnet new` command creates a .NET project or other artifacts based on a template.

The command calls the [template engine](https://github.com/dotnet/templating) to create the artifacts on disk based on the specified template and options.

> [!NOTE]
> [!INCLUDE [new syntax](../../../includes/dotnet-new-7-0-syntax.md)]

### Tab completion

Starting with .NET SDK 7.0.100, tab completion is available for `dotnet new`. It supports completion for installed template names, as well as completion for the options a selected template provides.
To activate tab completion for the .NET SDK, see [Enable tab completion](enable-tab-autocomplete.md).

### Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

## Arguments

- **`TEMPLATE`**

  The template to instantiate when the command is invoked. Each template might have specific options you can pass. For more information, see [Template options](#template-options).

  You can run [`dotnet new list`](dotnet-new-list.md) to see a list of all installed templates.

  Starting with .NET Core 3.0 SDK and ending with .NET SDK 5.0.300, the CLI searches for templates in NuGet.org when you invoke the `dotnet new` command in the following conditions:

  - If the CLI can't find a template match when invoking `dotnet new`, not even partial.
  - If there's a newer version of the template available. In this case, the project or artifact is created but the CLI warns you about an updated version of the template.

  Starting with .NET SDK 5.0.300, the [`search` command](dotnet-new-search.md) should be used to search for templates in NuGet.org.

[!INCLUDE [templates](../../../includes/templates.md)]

## Options

- **`--dry-run`**

  Displays a summary of what would happen if the given command were run if it would result in a template creation. Available since .NET Core 2.2 SDK.

- **`--force`**

  Forces content to be generated even if it would change existing files. This is required when the template chosen would override existing files in the output directory.

- **`-?|-h|--help`**

  Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template. For example, `dotnet new mvc --help`.

- **`-lang|--language {C#|F#|VB}`**

  The language of the template to create. The language accepted varies by the template (see defaults in the [arguments](#arguments) section). Not valid for some templates.

  > [!NOTE]
  > Some shells interpret `#` as a special character. In those cases, enclose the language parameter value in quotes. For example, `dotnet new console -lang "F#"`.

- **`-n|--name <OUTPUT_NAME>`**

  The name for the created output. If no name is specified, the name of the current directory is used.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [target framework](../../standard/frameworks.md). It expects a target framework moniker (TFM). Examples: "net6.0", "net7.0-macos". This value will be reflected in the project file.

- **`-no-update-check`**

  Disables checking for template package updates when instantiating a template. Available since .NET SDK 6.0.100.
  When instantiating the template from a template package that was installed by using `dotnet new --install`, `dotnet new` checks if there is an update for the template.
  Starting with .NET 6, no update checks are done for .NET default templates. To update .NET default templates, install the patch version of the .NET SDK.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Location to place the generated output. The default is the current directory.

- **`--project <PROJECT_PATH>`**

  The project that the template is added to. This project is used for context evaluation. If not specified, the project in the current or parent directories will be used. Available since .NET SDK 7.0.100.

- **`-d|--diagnostics`**

  Enables diagnostic output. Available since .NET SDK 7.0.100.

- **`-v|--verbosity <LEVEL>`**

  Sets the verbosity level of the command. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, and `diag[nostic]`. Available since .NET SDK 7.0.100.

## Template options

Each template may have additional options defined. For more information, see [.NET default templates for `dotnet new`](dotnet-new-sdk-templates.md).

## Examples

- Create a C# console application project:

  ```dotnetcli
  dotnet new console
  ```

- Create an F# console application project in the current directory:

  ```dotnetcli
  dotnet new console --language "F#"
  ```

- Create a .NET Standard 2.0 class library project in the specified directory:

  ```dotnetcli
  dotnet new classlib --framework "netstandard2.0" -o MyLibrary
  ```

- Create a new ASP.NET Core C# MVC project in the current directory with no authentication:

  ```dotnetcli
  dotnet new mvc -au None
  ```

- Create a new xUnit project:

  ```dotnetcli
  dotnet new xunit
  ```

- Create a *global.json* in the current directory setting the SDK version to 8.0.101:

  ```dotnetcli
  dotnet new globaljson --sdk-version 8.0.101 --roll-forward latestFeature
  ```

- Show help for the C# console application template:

  ```dotnetcli
  dotnet new console -h
  ```

- Show help for the F# console application template:

  ```dotnetcli
  dotnet new console --language "F#" -h
  ```

## See also

- [dotnet new list command](dotnet-new-list.md)
- [dotnet new search command](dotnet-new-search.md)
- [dotnet new install command](dotnet-new-install.md)
- [.NET default templates for dotnet new](dotnet-new-sdk-templates.md)
- [Custom templates for dotnet new](custom-templates.md)
- [Create a custom template for dotnet new](../tutorials/cli-templates-create-item-template.md)

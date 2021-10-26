---
title: dotnet new command
description: The dotnet new command creates new .NET projects based on the specified template.
no-loc: [Blazor, WebAssembly]
ms.date: 09/04/2020
---
# dotnet new

**This article applies to:** ✔️ .NET Core 2.0 SDK and later versions

## Name

`dotnet new` - Creates a new project, configuration file, or solution based on the specified template.

## Synopsis

```dotnetcli
dotnet new <TEMPLATE> [--dry-run] [--force] [-lang|--language {"C#"|"F#"|VB}]
    [-n|--name <OUTPUT_NAME>] [--no-update-check] [-o|--output <OUTPUT_DIRECTORY>] [Template options]

dotnet new -h|--help
```

## Description

The `dotnet new` command creates a .NET project or other artifacts based on a template.

The command calls the [template engine](https://github.com/dotnet/templating) to create the artifacts on disk based on the specified template and options.

### Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

## Arguments

- **`TEMPLATE`**

  The template to instantiate when the command is invoked. Each template might have specific options you can pass. For more information, see [Template options](#template-options).

  You can run [`dotnet new --list`](dotnet-new-list.md) to see a list of all installed templates.

  Starting with .NET Core 3.0 SDK and ending with .NET Core 5.0.300 SDK, the CLI searches for templates in NuGet.org when you invoke the `dotnet new` command in the following conditions:

  - If the CLI can't find a template match when invoking `dotnet new`, not even partial.
  - If there's a newer version of the template available. In this case, the project or artifact is created but the CLI warns you about an updated version of the template.

  Starting with .NET Core 5.0.300 SDK, the [`--search` option](dotnet-new-search.md) should be used to search for templates in NuGet.org..

  The following table shows the templates that come pre-installed with the .NET SDK. The default language for the template is shown inside the brackets. Click on the short name link to see the specific template options.

| Templates                                    | Short name                                                   | Language     | Tags                                  | Introduced |
|----------------------------------------------|--------------------------------------------------------------|--------------|---------------------------------------|------------|
| Console Application                          | [`console`](dotnet-new-sdk-templates.md#console)             | [C#], F#, VB | Common/Console                        | 1.0        |
| Class library                                | [`classlib`](dotnet-new-sdk-templates.md#classlib)           | [C#], F#, VB | Common/Library                        | 1.0        |
| WPF Application                              | [`wpf`](dotnet-new-sdk-templates.md#wpf)                     | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF Class library                            | [`wpflib`](dotnet-new-sdk-templates.md#wpf)                  | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF Custom Control Library                   | [`wpfcustomcontrollib`](dotnet-new-sdk-templates.md#wpf)     | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF User Control Library                     | [`wpfusercontrollib`](dotnet-new-sdk-templates.md#wpf)       | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| Windows Forms (WinForms) Application         | [`winforms`](dotnet-new-sdk-templates.md#winforms)           | [C#], VB     | Common/WinForms                       | 3.0 (5.0 for VB)|
| Windows Forms (WinForms) Class library       | [`winformslib`](dotnet-new-sdk-templates.md#winforms)        | [C#], VB     | Common/WinForms                       | 3.0 (5.0 for VB)|
| Worker Service                               | [`worker`](dotnet-new-sdk-templates.md#web-others)           | [C#]         | Common/Worker/Web                     | 3.0        |
| Unit Test Project                            | [`mstest`](dotnet-new-sdk-templates.md#test)                 | [C#], F#, VB | Test/MSTest                           | 1.0        |
| NUnit 3 Test Project                         | [`nunit`](dotnet-new-sdk-templates.md#nunit)                 | [C#], F#, VB | Test/NUnit                            | 2.1.400    |
| NUnit 3 Test Item                            | `nunit-test`                                                 | [C#], F#, VB | Test/NUnit                            | 2.2        |
| xUnit Test Project                           | [`xunit`](dotnet-new-sdk-templates.md#test)                  | [C#], F#, VB | Test/xUnit                            | 1.0        |
| Razor Component                              | `razorcomponent`                                             | [C#]         | Web/ASP.NET                           | 3.0        |
| Razor Page                                   | [`page`](dotnet-new-sdk-templates.md#page)                   | [C#]         | Web/ASP.NET                           | 2.0        |
| MVC ViewImports                              | [`viewimports`](dotnet-new-sdk-templates.md#namespace)       | [C#]         | Web/ASP.NET                           | 2.0        |
| MVC ViewStart                                | `viewstart`                                                  | [C#]         | Web/ASP.NET                           | 2.0        |
| Blazor Server App                            | [`blazorserver`](dotnet-new-sdk-templates.md#blazorserver)   | [C#]         | Web/Blazor                            | 3.0        |
| Blazor WebAssembly App                       | [`blazorwasm`](dotnet-new-sdk-templates.md#blazorwasm)       | [C#]         | Web/Blazor/WebAssembly                | 3.1.300    |
| ASP.NET Core Empty                           | [`web`](dotnet-new-sdk-templates.md#web)                     | [C#], F#     | Web/Empty                             | 1.0        |
| ASP.NET Core Web App (Model-View-Controller) | [`mvc`](dotnet-new-sdk-templates.md#web-options)             | [C#], F#     | Web/MVC                               | 1.0        |
| ASP.NET Core Web App                         | [`webapp, razor`](dotnet-new-sdk-templates.md#web-options)   | [C#]         | Web/MVC/Razor Pages                   | 2.2, 2.0   |
| ASP.NET Core with Angular                    | [`angular`](dotnet-new-sdk-templates.md#spa)                 | [C#]         | Web/MVC/SPA                           | 2.0        |
| ASP.NET Core with React.js                   | [`react`](dotnet-new-sdk-templates.md#spa)                   | [C#]         | Web/MVC/SPA                           | 2.0        |
| ASP.NET Core with React.js and Redux         | [`reactredux`](dotnet-new-sdk-templates.md#reactredux)       | [C#]         | Web/MVC/SPA                           | 2.0        |
| Razor Class Library                          | [`razorclasslib`](dotnet-new-sdk-templates.md#razorclasslib) | [C#]         | Web/Razor/Library/Razor Class Library | 2.1        |
| ASP.NET Core Web API                         | [`webapi`](dotnet-new-sdk-templates.md#webapi)               | [C#], F#     | Web/WebAPI                            | 1.0        |
| ASP.NET Core gRPC Service                    | [`grpc`](dotnet-new-sdk-templates.md#web-others)             | [C#]         | Web/gRPC                              | 3.0        |
| dotnet gitignore file                        | `gitignore`                                                  |              | Config                                | 3.0        |
| global.json file                             | [`globaljson`](dotnet-new-sdk-templates.md#globaljson)       |              | Config                                | 2.0        |
| NuGet Config                                 | `nugetconfig`                                                |              | Config                                | 1.0        |
| Dotnet local tool manifest file              | `tool-manifest`                                              |              | Config                                | 3.0        |
| Web Config                                   | `webconfig`                                                  |              | Config                                | 1.0        |
| Solution File                                | `sln`                                                        |              | Solution                              | 1.0        |
| Protocol Buffer File                         | [`proto`](dotnet-new-sdk-templates.md#namespace)             |              | Web/gRPC                              | 3.0        |
| EditorConfig file                            | `editorconfig`(dotnet-new-sdk-templates.md#editorconfig)     |              | Config                                | 6.0        |

## Options

<!-- markdownlint-disable MD012 -->

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

- **`-no-update-check`**

  Disables checking for template package updates when instantiating a template. Available since .NET 6.0.100 SDK.
  When instantiating the template from a template package that was installed by using `dotnet new --install`, `dotnet new` checks if there is an update for the template.
  Starting with .NET 6, no update checks are done for .NET default templates. To update .NET default templates, install the patch version of the .NET SDK.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Location to place the generated output. The default is the current directory.

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

- Create a *global.json* in the current directory setting the SDK version to 3.1.101:

  ```dotnetcli
  dotnet new globaljson --sdk-version 3.1.101
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

- [dotnet new --list option](dotnet-new-list.md)
- [dotnet new --search option](dotnet-new-search.md)
- [dotnet new --install option](dotnet-new-install.md)
- [.NET default templates for dotnet new](dotnet-new-sdk-templates.md)
- [Custom templates for dotnet new](custom-templates.md)
- [Create a custom template for dotnet new](../tutorials/cli-templates-create-item-template.md)
- [dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)

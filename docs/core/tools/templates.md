---
title: .NET templates for authors
description: Learn how to author .NET templates, including how they're structured, configured, and distributed using the dotnet new command and Visual Studio.
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 07/29/2026
ai-usage: ai-assisted

#customer intent: As a .NET template author, I want to understand how .NET templates are structured and configured so that I can create and distribute my own templates for projects and files.

---

# .NET templates for authors

As a template author, you create .NET templates—blueprints that generate projects, files, or other resources from a predefined structure. When users run `dotnet new <shortName>`, the .NET template engine reads the template and produces the output in the current directory. Visual Studio's **Create a new project** dialog also uses the .NET template engine for .NET project templates, so templates you author for the CLI work in Visual Studio too.

The .NET SDK ships with built-in templates for common starting points like console apps, class libraries, and ASP.NET projects. Beyond those built-in templates, you can author your own templates and distribute them as NuGet packages.

This article is a reference for template authors. It covers how templates are structured, configured, and distributed. For step-by-step instructions to create and package templates, see the [Related content](#related-content) section.

## Template types

The .NET template engine supports three types of templates: item templates, project templates, and solution templates.

- **Item templates** generate one or more files, such as a code file, configuration file, or other resource, without generating an entire project around them. For example, an item template might produce a class file that adds a set of extension methods, or a JSON configuration file that follows a standard layout your team uses. To learn how to build an item template, see [Tutorial: Create an item template](../tutorials/cli-templates-create-item-template.md).

- **Project templates** generate a complete project structure. The built-in console project template, for example, produces a `.csproj` file, a `Program.cs` file, and any other files that make up the project. Author a project template when you want to give users a full project starting point rather than individual files. To learn how to build a project template, see [Tutorial: Create a project template](../tutorials/cli-templates-create-project-template.md).

- **Solution templates** generate a solution with one or more projects. For example, a solution template can create an API project paired with a test project in a single step.

When you create your own template, you declare its type using the `tags.type` field in the `template.json` configuration file. The valid values are `"project"`, `"item"`, and `"solution"`. These values let users filter results when they search for templates with `dotnet new search` or `dotnet new list`.

> [!TIP]
> Project and solution templates appear in the Visual Studio **Create a new project** dialog, but item templates don't appear in the **Add** > **New Item** dialog. Users can access item templates from the `dotnet new` CLI.

## Template structure

A template is a folder on disk that contains two things: the template source files and a special `.template.config` subfolder. When a user runs `dotnet new <shortName>`, the template engine copies the source files to the output location and applies any configuration you've defined for the template.

```text
mytemplate/
├── console.cs
├── readme.txt
└── .template.config/
    ├── template.json
    └── icon.png
```

The source files can be any type of file. The template engine doesn't require you to inject special tokens or markers into the source code. It uses the files as-is, which means you can build, run, and debug a template's source project exactly like a normal .NET project. To turn an existing project into a template, add a `.template.config/template.json` file to the project root.

You can optionally inject substitution tokens tied to template parameters (symbols) directly into template source files and file names. If the tokens aren't valid source code, you can't build, run, or debug the source project before you deploy it as a template. The tokens don't affect projects that users create from the deployed template because the template engine replaces them during project creation.

The only required file inside `.template.config` is `template.json`. That file tells the template engine everything it needs: the template's name, short name, author, classifications, and any parameters users can pass when they create from the template. You can also place an `icon.png` file in the `.template.config` folder. The terminal doesn't display icons, but Visual Studio shows the icon next to the template in the **Create a new project** dialog. A 128×128 PNG works well.

### The template.json file

The `template.json` file is the only required piece of configuration in a template. It lives inside the `.template.config` folder and tells the template engine how to present and process your template. The following table describes common required and optional fields:

| Field                 | Type          | Required | Description |
|-----------------------|---------------|----------|-------------|
| `$schema`             | URI           | No       | The JSON schema for `template.json`. Set to `https://json.schemastore.org/template` to enable IntelliSense in editors like Visual Studio Code. |
| `author`              | string        | No       | The author of the template. |
| `classifications`     | array(string) | No       | Tags users can use to find the template with `dotnet new search` or `dotnet new list`. These values appear in the **Tags** column of the template list. |
| `description`         | string        | No       | A description of what the template creates. |
| `identity`            | string        | Yes      | A unique identifier for the template. |
| `name`                | string        | Yes      | The display name of the template shown to users. |
| `shortName`           | string        | Yes      | The short name users pass to `dotnet new` to create from the template, such as `console` or `classlib`. |
| `sourceName`          | string        | No       | A string in your source files and file names that the template engine replaces with the name the user provides via `-n` or `--name`. If the user doesn't provide a name, the engine uses the current directory name. |
| `preferNameDirectory` | boolean       | No       | When `true` and the user provides a name but no output directory, the template engine creates a new directory with that name instead of writing files into the current directory. The default is `false`. |
| `tags`                | object        | No       | Metadata that identifies properties such as the template language and type. Use `tags.language` for the language and `tags.type` for `project`, `item`, or `solution`. |

Two fields deserve extra attention. The `sourceName` field is how templates handle naming: set it to a string that appears in your file names and source code (such as `MyTemplate`), and the template engine replaces every occurrence with whatever name the user passes when creating the template. The `classifications` field controls discoverability; choose tags that accurately describe your template's purpose so users can find it when searching.

Here's a minimal `template.json` for a console template:

```json
{
  "$schema": "https://json.schemastore.org/template",
  "author": "Your Name",
  "classifications": [ "Common", "Console" ],
  "description": "Creates a console application.",
  "identity": "MyCompany.ConsoleTemplate.CSharp",
  "name": "My Console App",
  "shortName": "myconsole",
  "sourceName": "MyConsoleApp",
  "tags": {
    "language": "C#",
    "type": "project"
  }
}
```

The full schema is available at [JSON Schema Store](https://www.schemastore.org/template.json). For advanced configuration options such as conditional file inclusion, post-creation actions, and multi-project templates, see the [dotnet/templating GitHub wiki](https://github.com/dotnet/templating/wiki).

### Template parameters (symbols)

The `symbols` section in `template.json` defines the parameters users can pass when creating from your template. Each symbol becomes a CLI option on `dotnet new <shortName>`, so a symbol named `ClassName` becomes `--ClassName` (or `-C` if you define a short name).

Each symbol entry supports the following common settings:

| Setting | Description |
|---|---|
| `type` | Must be `"parameter"` for user-facing parameters. |
| `description` | Shown in the template help output when users run `dotnet new <shortName> -?`. |
| `datatype` | The expected data type, such as `"text"`, `"bool"`, or `"choice"`. |
| `replaces` | A string in your source file contents that the template engine replaces with the parameter value. |
| `fileRename` | A string in your source file names that the template engine replaces with the parameter value. |
| `defaultValue` | The value used when the user doesn't supply the parameter. |

The `replaces` and `fileRename` settings are how symbols drive substitution. When a user provides a value, the template engine replaces every occurrence of the `replaces` string inside file contents and every occurrence of the `fileRename` string in file names. If the user doesn't provide a value, the `defaultValue` is used instead.

For example, the following symbol lets users set the class name when they create from the template. The file is renamed and the class inside it is updated to match:

```json
"symbols": {
  "ClassName": {
    "type": "parameter",
    "description": "The name of the code file and class.",
    "datatype": "text",
    "replaces": "StringExtensions",
    "fileRename": "StringExtensions",
    "defaultValue": "StringExtensions"
  }
}
```

With this symbol defined, a user can run `dotnet new <shortName> --ClassName MyHelpers` to produce a file named `MyHelpers.cs` containing a class named `MyHelpers`. Without the flag, the file and class keep the default name `StringExtensions`.

To verify the parameters your template exposes, pass `-?` to its short name after you install it:

```dotnetcli
dotnet new <shortName> -?
```

## Template packages

A template package is a NuGet (`.nupkg`) file that bundles one or more of your templates together. When a user installs your template package, the .NET template engine registers every template inside it at once. Packages are the standard way to distribute templates. Publish a single package to NuGet.org or a private NuGet feed, or share a local `.nupkg` file, and users get the whole collection with one command.

To build a template package, use a C# project file (`.csproj`) configured to act as a **packaging project** rather than a compilation project. The key settings that make this work are:

| Setting                | Value      | Purpose                                                      |
|------------------------|------------|--------------------------------------------------------------|
| `PackageType`          | `Template` | Marks the package as a template package so it appears in `dotnet new search` results. |
| `IncludeContentInPack` | `true`     | Includes content files in the NuGet package.                 |
| `IncludeBuildOutput`   | `false`    | Prevents compiled binaries from being added to the package.  |
| `ContentTargetFolders` | `content`  | Places your template folders inside the `content` folder of the NuGet package, which is where the template engine expects to find them. |

The `templatepack` project template provides the easiest way to create a packaging project:

1. Install the [Microsoft.TemplateEngine.Authoring.Templates](https://www.nuget.org/packages/Microsoft.TemplateEngine.Authoring.Templates) NuGet package:

   ```dotnetcli
   dotnet new install Microsoft.TemplateEngine.Authoring.Templates
   ```

1. Create the packaging project:

   ```dotnetcli
   dotnet new templatepack -n <PackageName>
   ```

The generated project includes the correct `.csproj` settings, a `content` folder for your templates, and MSBuild tasks for template validation and optional localization.

For a full walkthrough of creating, packing, and publishing a template package, see [Tutorial: Create a template package](../tutorials/cli-templates-create-template-package.md).

## Test your template locally

During template development, install your template directly from its folder to test it without building a package first. Pass the path to the directory that contains the `.template.config` folder:

```dotnetcli
dotnet new install ./mytemplate/
```

To see all installed template packages and the exact command to uninstall each one, run `dotnet new uninstall` with no arguments:

```dotnetcli
dotnet new uninstall
```

To uninstall a template installed from a directory, pass the same directory path you used to install it:

```dotnetcli
dotnet new uninstall ./mytemplate/
```

Once you're ready to share your template, pack it as a NuGet package (see [Template packages](#template-packages)) and distribute it. Users install your published template with `dotnet new install` and one of the following source arguments:

- A NuGet package ID, which installs the latest stable version from the NuGet sources configured for the current directory:

  ```dotnetcli
  dotnet new install AdatumCorporation.ConsoleTemplate.CSharp
  ```

- A NuGet package ID with a custom feed URL. The `--nuget-source` option uses the specified feed, in addition to the configured NuGet sources, for that installation only:

  ```dotnetcli
  dotnet new install AdatumCorporation.ConsoleTemplate.CSharp --nuget-source https://mynugetfeed.example.com/v3/index.json
  ```

- A path to a local `.nupkg` file:

  ```dotnetcli
  dotnet new install ./AdatumCorporation.ConsoleTemplate.CSharp.1.0.0.nupkg
  ```

> [!WARNING]
> Templates can run MSBuild tasks and arbitrary code during project creation. Only install templates from sources you trust.

To uninstall a package installed from a NuGet source or a local `.nupkg` file, use the NuGet package ID:

```dotnetcli
dotnet new uninstall AdatumCorporation.ConsoleTemplate.CSharp
```

The built-in SDK templates don't appear in the uninstall list and can't be removed with `dotnet new uninstall`.

## Template localization

The .NET template engine supports optional localization of template metadata. When you provide localization files, hosts such as `dotnet new` and the Visual Studio **New Project** dialog display the template's name, description, and symbol information in the user's language instead of the original authored language.

The following template fields support localization:

- `name`
- `author`
- `description`
- Symbol `description` and `displayName`
- Description and display name for each choice in a choice parameter
- Post action `description` and `manualInstructions`

To add localization, create a `localize` subfolder inside `.template.config` and add one JSON file per language. Name each file `templatestrings.<lang-code>.json`, where `<lang-code>` matches a valid <xref:System.Globalization.CultureInfo> name, such as `pt-BR`, `zh-Hans`, or `de`. Each file contains key-value pairs where the key is a path to the element in `template.json`, using `/` as a delimiter for nested fields.

For example, given a `template.json` with the following content:

```json
{
  "$schema": "https://json.schemastore.org/template",
  "author": "Microsoft",
  "classifications": [ "Config" ],
  "name": "EditorConfig file",
  "description": "Creates an .editorconfig file for configuring code style preferences.",
  "symbols": {
    "Empty": {
      "type": "parameter",
      "datatype": "bool",
      "defaultValue": "false",
      "displayName": "Empty",
      "description": "Creates empty .editorconfig instead of the defaults for .NET."
    }
  }
}
```

A Brazilian Portuguese localization file named `templatestrings.pt-BR.json` would look like this:

```json
{
  "author": "Microsoft",
  "name": "Arquivo EditorConfig",
  "description": "Cria um arquivo .editorconfig para configurar as preferências de estilo de código.",
  "symbols/Empty/displayName": "Vazio",
  "symbols/Empty/description": "Cria .editorconfig vazio em vez dos padrões para .NET."
}
```

The template engine parses these files when it loads template information, and it returns localized values automatically based on the current UI culture—no extra steps are required from the user.

Localization is optional. If you don't include localization files, the template works normally and always displays the values from `template.json`. For more information, see the [dotnet/templating wiki localization page](https://github.com/dotnet/templating/wiki/Localization).

## Visual Studio integration

Visual Studio's **Create a new project** dialog uses the .NET template engine for .NET project templates. Templates you author for `dotnet new` work in Visual Studio too, without any extra configuration. When a user installs your template package with `dotnet new install`, Visual Studio automatically detects and surfaces those templates in the dialog.

**Project and solution templates** appear in the **Create a new project** dialog alongside the built-in SDK templates. Users can find templates by name, language, or the tags from the `classifications` field in the template's `template.json` file. Accurate classifications help your template surface in the right filter categories, so choose them carefully. To give your template a polished appearance in the dialog, add an `icon.png` to the `.template.config` folder — Visual Studio displays it next to your template's name.

**Item templates** don't currently appear in the **Add** > **New Item** dialog. Users can still use item templates with the `dotnet new` command in the terminal.

To make your template discoverable to Visual Studio users who haven't installed it yet, publish your template package to nuget.org. The **Create a new project** dialog includes an **Install more templates from the online search** option that searches nuget.org for template packages. When a user installs your package through that option, Visual Studio uses the same install mechanism as `dotnet new install`.

For deeper guidance on Visual Studio-specific integration—such as controlling template sort order and configuring additional IDE-specific options—see [Sayed Hashimi's template-sample repository](https://github.com/sayedihashimi/template-sample).

## Related content

- [Tutorial: Create an item template](../tutorials/cli-templates-create-item-template.md)
- [Tutorial: Create a project template](../tutorials/cli-templates-create-project-template.md)
- [Tutorial: Create a template package](../tutorials/cli-templates-create-template-package.md)
- [dotnet new command](dotnet-new.md)
- [dotnet/templating GitHub repo wiki](https://github.com/dotnet/templating/wiki)
- [Template samples](https://github.com/dotnet/templating/tree/main/dotnet-template-samples)

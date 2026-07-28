---
title: .NET templates overview
description: Learn how .NET templates work, how they're structured, and what you can do with them using the dotnet new command and Visual Studio.
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 07/28/2026
ai-usage: ai-assisted

#customer intent: As a .NET developer, I want to understand how .NET templates work so that I can use, create, and distribute templates for projects and files.

---

<!-- REFERENCE MATERIAL AND RULES

## Key Content Requirements

### Audience Focus

- Primary audience: beginner .NET developers who want to understand the template system
- Secondary audience: intermediate developers who want to create or distribute their own templates
- The article should explain HOW templates work conceptually, not just list commands

### Goal of This Article

This is a replacement for `custom-templates.md`. The old article focused on "custom" templates only. This new overview should:
- Cover templates broadly (built-in AND custom)
- Explain the template engine and how it works
- Explain what a template IS (source files + template.json)
- Cover types of templates (item, project)
- Cover how to install, use, and uninstall templates
- Cover how to create and package templates (high-level, with links to tutorials for details)
- Mention Visual Studio integration

### Terminology

- Say "the .NET template engine" or "template engine" for the underlying system
- Say "template package" for a NuGet package containing one or more templates
- Use "dotnet new" when referring to the CLI command
- Don't use "custom templates" as the main framing — all templates (built-in and third-party) are just "templates"

### Do NOT

- Go into deep tutorial detail — link to the tutorial series for that
- Reproduce the full tutorial steps
- Focus only on CLI — mention Visual Studio integration

## Reference Material

The following files were used as source material:

- Existing article being replaced: docs/core/tools/custom-templates.md
- Tutorial 1 (item template): docs/core/tutorials/cli-templates-create-item-template.md
- Tutorial 2 (project template): docs/core/tutorials/cli-templates-create-project-template.md
- Tutorial 3 (template package): docs/core/tutorials/cli-templates-create-template-package.md
- template.json schema: https://www.schemastore.org/template.json

When linking to these tutorials, use relative paths from docs/core/tools/.
When linking to learn.microsoft.com content, use the /dotnet/... URL path.

-->

# What are .NET templates?

[Introduce the .NET template system: what templates are, what they produce (projects, files, resources), and why they exist. Mention that both the `dotnet new` CLI command and Visual Studio use the same template engine. Briefly mention built-in templates that ship with the SDK and the ability to install community or custom templates.]

<!--
- Define what a template is: a blueprint that generates projects, files, or resources.
- Explain that the .NET SDK ships with built-in templates (console apps, class libraries, ASP.NET, etc.).
- Mention that developers can install additional templates from NuGet or create their own.
- State that both `dotnet new` and Visual Studio use the same underlying template engine.
- Link to the `dotnet new` command reference for how to use templates from the CLI.
- Mention `dotnet new list` to see currently installed templates.
-->

## Template types

<!--
- Item templates: generate one or more files added to an existing project (code files, config files, etc.).
- Project templates: generate an entire project structure.
- Solution templates: generate a solution with one or more projects.
- Explain the `tags/type` field in template.json that categorizes a template as "item", "project", or "solution."
- Note that "item", "project", and "solution" are the only valid values, enforced by the schema.
- Mention that item templates don't appear in the Visual Studio "Add > New Item" dialog (current limitation).
- Reference: custom-templates.md existing content, tutorial articles.
-->

The .NET template engine supports three types of templates: item templates, project templates, and solution templates.

- **Item templates** generate one or more files, such as a code file, configuration file, or other resource, without generating an entire project around them. For example, an item template might produce a class file that adds a set of extension methods, or a JSON configuration file that follows a standard layout your team uses. To learn how to build an item template, see [Tutorial: Create an item template](../tutorials/cli-templates-create-item-template.md).

- **Project templates** generate a complete project structure. When you run `dotnet new console`, for example, the console project template produces a `.csproj` file, a `Program.cs` file, and any other files that make up the project. Use a project template when you want to give users a full project starting point rather than individual files. To learn how to build a project template, see [Tutorial: Create a project template](../tutorials/cli-templates-create-project-template.md).

- **Solution templates** generate a solution with one or more projects. Use a solution template when you want to scaffold an entire multi-project structure — for example, an API project paired with a test project — in a single step.

When you create your own template, you declare its type using the `tags.type` field in the `template.json` configuration file. The valid values are `"project"`, `"item"`, and `"solution"`. These values let users filter results when they search for templates with `dotnet new search` or `dotnet new list`.

> [!TIP]
> Project templates appear in the Visual Studio **Create a new project** dialog, but item templates don't appear in the **Add** > **New Item** dialog. You can use item templates from the `dotnet new` CLI.

## Template structure

<!--
- A template is a folder containing source files/folders and a `.template.config` subfolder.
- The `.template.config` folder must contain a `template.json` file.
- Source files can be any type of file — not limited to .NET project types.
- The template engine uses source files as-is; no special tokens need to be injected into the source code.
- Because of this, template source files can be compiled, run, and debugged normally during development.
- Explain that an existing project can be turned into a template by just adding `.template.config/template.json`.
- Show a simple folder structure example:
  ```
  mytemplate/
  ├── console.cs
  ├── readme.txt
  └── .template.config/
        template.json
  ```
-->

A template is a folder on disk that contains two things: your source files and a special `.template.config` subfolder. When you run `dotnet new <shortName>`, the template engine copies your source files to the output location and applies any configuration you've defined.

```text
mytemplate/
├── console.cs
├── readme.txt
└── .template.config/
    └── template.json
```

The source files can be any type of file. The template engine doesn't require you to inject special tokens or markers into your source code. It uses your files as-is, which means you can build, run, and debug a template's source project exactly like a normal .NET project. To turn an existing project into a template, add a `.template.config/template.json` file to the project root.

You can optionally inject substitution tokens tied to template parameters (symbols) directly into your source files and file names, but doing so means those files are no longer runnable as a normal .NET project.

The only required file inside `.template.config` is `template.json`. That file tells the template engine everything it needs: the template's name, short name, author, classifications, and any parameters users can pass when they create from the template.

### The template.json file

<!--
- Describe the purpose of template.json: provides configuration to the template engine.
- Cover required/common fields with a table (matching existing custom-templates.md table):
  - $schema, author, classifications, identity, name, shortName, sourceName, preferNameDirectory
- Explain `sourceName`: the template engine replaces occurrences of this value in file names and file contents with the name the user provides (via -n or --name), or defaults to the current folder name.
- Explain `classifications`: appear as tags in `dotnet new list`; searchable by users.
- Mention the full schema is at JSON Schema Store.
- Link to dotnet templating wiki for advanced configuration.
- Show a minimal template.json example.
-->

The `template.json` file is the only required piece of configuration in a template. It lives inside the `.template.config` folder and tells the template engine how to present and process your template. The following table describes the common fields:

| Field | Type | Description |
|---|---|---|
| `$schema` | URI | The JSON schema for `template.json`. Set to `https://json.schemastore.org/template` to enable IntelliSense in editors like Visual Studio Code. |
| `author` | string | The author of the template. |
| `classifications` | array(string) | Tags users can use to find the template with `dotnet new search` or `dotnet new list`. These appear in the **Tags** column of the template list. |
| `identity` | string | A unique identifier for this template. |
| `name` | string | The display name of the template shown to users. |
| `shortName` | string | The short name users pass to `dotnet new` to create from this template, such as `console` or `classlib`. |
| `sourceName` | string | A string in your source files and file names that the template engine replaces with the name the user provides via `-n` or `--name`. If the user doesn't provide a name, the current directory name is used. |
| `preferNameDirectory` | boolean | When `true` and the user provides a name but no output directory, the template engine creates a new directory with that name instead of writing files into the current directory. Defaults to `false`. |

Two fields deserve extra attention. The `sourceName` field is how templates handle naming: set it to a string that appears in your file names and source code (such as `MyTemplate`), and the template engine replaces every occurrence with whatever name the user passes when creating the template. The `classifications` field controls discoverability — choose tags that accurately describe your template's purpose so users can find it when searching.

Here's a minimal `template.json` for a console template:

```json
{
  "$schema": "https://json.schemastore.org/template",
  "author": "Your Name",
  "classifications": [ "Common", "Console" ],
  "identity": "MyCompany.ConsoleTemplate.CSharp",
  "name": "My Console App",
  "shortName": "myconsole",
  "sourceName": "MyConsoleApp"
}
```

The full schema is available at [JSON Schema Store](https://www.schemastore.org/template.json). For advanced configuration options such as conditional file inclusion, post-creation actions, and multi-project templates, see the [dotnet/templating GitHub wiki](https://github.com/dotnet/templating/wiki).

### Template parameters (symbols)

<!--
- The `symbols` section defines custom parameters for the template.
- Each symbol maps to a CLI option the user can pass to `dotnet new <shortName>`.
- Describe common symbol settings: type, description, datatype, replaces, fileRename, defaultValue.
- Explain how `replaces` and `fileRename` work: text substitution in file contents and file names respectively.
- Show a simple example: a `ClassName` symbol that renames both the file and the class.
- Show how to discover a template's available parameters with `dotnet new <shortName> -?`.
-->

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

To see all available parameters for any installed template, pass `-?` to the template's short name:

```dotnetcli
dotnet new <shortName> -?
```

## Template packages

[Explain what a template package is: a NuGet package containing one or more templates. Describe how packages enable distribution of templates.]

<!--
- A template package is a NuGet (.nupkg) file that bundles one or more templates.
- Installing a template package installs all templates it contains at once.
- Template packages can be distributed via nuget.org, a private NuGet feed, or a local file.
- Mention that a C# project file (.csproj) with special settings is used to pack templates into a NuGet package.
- Key .csproj settings: PackageType=Template, IncludeContentInPack=true, IncludeBuildOutput=false, ContentTargetFolders=content.
- Reference: cli-templates-create-template-package.md for the full walkthrough.
- Mention the Microsoft.TemplateEngine.Authoring.Templates NuGet package that provides a `templatepack` project template for authoring.
-->

## Install and uninstall templates

[Describe how to install templates from the various sources and how to list and uninstall them.]

<!--
- Use `dotnet new install <source>` where source can be:
  - A NuGet package ID (from nuget.org)
  - A NuGet package ID with a custom source (--nuget-source)
  - A path to a local .nupkg file
  - A file system directory that contains a template (the folder with .template.config inside)
- Use `dotnet new uninstall` (no args) to list all installed template packages and their uninstall commands.
- Use `dotnet new uninstall <PACKAGE_ID_or_PATH>` to uninstall by ID (NuGet) or path (file system).
- Warn that templates can execute MSBuild and arbitrary code — only install trusted templates.
- Note that built-in SDK templates are not shown in the uninstall list.
- Show a few example commands.
-->

## Template localization

[Explain that templates support localization so template metadata appears in the user's language.]

<!--
- The template engine supports optional localization of template metadata (name, description, symbols, etc.).
- Localization files are JSON files placed in `.template.config/localize/`.
- File naming convention: `templatestrings.<lang-code>.json`.
- Localization keys reference elements in template.json using `/` as a path delimiter.
- Localization is optional when creating templates.
- Link to the dotnet templating wiki localization page for more detail.
- Show a brief example of a templatestrings.pt-BR.json file.
-->

## Visual Studio integration

[Explain how templates created with the .NET template engine also appear and work in Visual Studio.]

<!--
- Visual Studio uses the same .NET template engine as `dotnet new`.
- Project templates appear in the Visual Studio "Create a new project" dialog.
- Item templates do NOT currently appear in the "Add > New Item" dialog.
- When published to nuget.org as a template package, templates become discoverable in Visual Studio's template search.
- Link to relevant Visual Studio docs or Sayed Hashimi's template-sample repo for deeper VS integration guidance.
-->

## Related content

- [Tutorial: Create an item template](../tutorials/cli-templates-create-item-template.md)
- [Tutorial: Create a project template](../tutorials/cli-templates-create-project-template.md)
- [Tutorial: Create a template package](../tutorials/cli-templates-create-template-package.md)
- [dotnet new command](dotnet-new.md)
- [dotnet/templating GitHub repo wiki](https://github.com/dotnet/templating/wiki)
- [Template samples](https://aka.ms/template-samples)

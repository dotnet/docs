---
title: Configuration files for code analysis rules
description: Learn about different configuration files to configure code analysis rules.
ms.date: 09/24/2020
ms.topic: conceptual
no-loc: ["EditorConfig"]
---
# Configuration files for code analysis rules

Code analysis rules have various [configuration options](configuration-options.md). You specify these options as key-value pairs in one of the following analyzer configuration files:

- [EditorConfig](#editorconfig) file: File-based or folder-based configuration options.
- [Global AnalyzerConfig](#global-analyzerconfig) file: Project-level configuration options. Useful when some project files reside outside the project folder.

## EditorConfig

[EditorConfig](/visualstudio/ide/create-portable-custom-editor-options) files are used to provide **options that apply to specific source files or folders**. Options are placed under section headers to identify the applicable files and folders. Add an entry for each rule you want to configure, and place it under the corresponding file extension section, for example, `[*.cs]`.

```ini
[*.cs]
<option_name> = <option_value>
```

In the above example, `[*.cs]` is an editorconfig section header to select all C# files with `.cs` file extension within the current folder, including subfolders. The subsequent entry, `<option_name> = <option_value>`, is an analyzer option that will be applied to all the C# files.

You can apply EditorConfig file conventions to a folder, a project, or an entire repo by placing the file in the corresponding directory. These options are applied when executing the analysis at build time and while you edit code in Visual Studio.

If you have an existing *.editorconfig* file for editor settings such as indent size or whether to trim trailing whitespace, you can place your code analysis configuration options in the same file.

> [!TIP]
> Visual Studio provides an *.editorconfig* item template that makes is easy to add one of these files to your project. For more information, see [Add an EditorConfig file to a project](/visualstudio/ide/create-portable-custom-editor-options#add-an-editorconfig-file-to-a-project).

### Example

Following is an example EditorConfig file to configure options and rule severity:

```ini
# Remove the line below if you want to inherit .editorconfig settings from higher directories
root = true

# C# files
[*.cs]

#### Core EditorConfig Options ####

# Indentation and spacing
indent_size = 4
indent_style = space
tab_width = 4

#### .NET Coding Conventions ####

# this. and Me. preferences
dotnet_style_qualification_for_method = true

#### Diagnostic configuration ####

# CA1000: Do not declare static members on generic types
dotnet_diagnostic.CA1000.severity = warning
```

## Global AnalyzerConfig

Starting with the .NET 5 SDK (which is supported in Visual Studio 2019 version 16.8 and later), you can also configure analyzer options with global _AnalyzerConfig_ files. These files are used to provide **options that apply to all the source files in a project**, regardless of their file names or file paths.

Unlike [EditorConfig](#editorconfig) files, global config files can't be used to configure editor style settings for IDEs, such as indent size or whether to trim trailing whitespace. Instead, they are designed purely for specifying project-level analyzer configuration options.

### Format

Unlike EditorConfig files, which must have section headers, such as `[*.cs]`, to identify the applicable files and folders, global AnalyzerConfig files don't have section headers. Instead, they require a top level entry of the form `is_global = true` to differentiate them from regular EditorConfig files. This indicates that all the options in the file apply to the entire project. For example:

```ini
is_global = true
<option_name> = <option_value>
```

### Naming

Unlike EditorConfig files, which must be named `.editorconfig`, global config files do not need to have a specific name or extension. However, if you name these files as `.globalconfig` then they will be implicitly applied to all the C# and Visual Basic projects within the current folder, including subfolders. Otherwise, you must explicitly add the `GlobalAnalyzerConfigFiles` item to your MSBuild project file:

```xml
<ItemGroup>
  <GlobalAnalyzerConfigFiles Include="<path_to_global_analyzer_config>" />
</ItemGroup>
```

> [!NOTE]
> The top-level entry `is_global = true` is required even when the file is named `.globalconfig`.

### Example

Following is an example global AnalyzerConfig file to configure options and rule severity at the project level:

```ini
# Top level entry required to mark this as a global AnalyzerConfig file
is_global = true

# NOTE: No section headers for configuration entries

#### .NET Coding Conventions ####

# this. and Me. preferences
dotnet_style_qualification_for_method = true:warning

#### Diagnostic configuration ####

# CA1000: Do not declare static members on generic types
dotnet_diagnostic.CA1000.severity = warning
```

## Precedence

Both EditorConfig files and global AnalyzerConfig files specify a key-value pair for each option. Conflicts arise when there are multiple entries with the same key but different values.

### General options

When conflicts arise between options, the following precedence rules are used to resolve the conflicts:

- Conflicting entries in the same configuration file: The entry that appears later in the file wins. This is true for conflicting entries within a single EditorConfig file and also within a single global AnalyzerConfig file.

- Conflicting entries in two EditorConfig files: The entry in the EditorConfig file that's deeper in the file system, and hence has a longer file path, wins.

- Conflicting entries in two global AnalyzerConfig files: A compiler warning is reported and both entries are ignored.

- Conflicting entries in an EditorConfig file and a Global AnalyzerConfig file: The entry in the EditorConfig file wins.

### Severity options

The previous [general precedence rules](#general-options) apply for all options specified in configuration files. For [severity configuration](configuration-options.md#severity-level) options, the following additional precedence rules apply:

- Severity options specified at the command line as compiler options (`/nowarn` or `/warnaserror`) always override [severity configuration](configuration-options.md#severity-level) options specified in EditorConfig and global AnalyzerConfig files.

- Severity options can also be specified with a [Ruleset](/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules) file. However, rulesets files are deprecated in favor of EditorConfig and global AnalyzerConfig files. It's recommended that you [convert ruleset files to an equivalent EditorConfig file](/visualstudio/code-quality/use-roslyn-analyzers#convert-an-existing-ruleset-file-to-editorconfig-file). Precedence for conflicting severity entries from a ruleset file and EditorConfig or global AnalyzerConfig files is _undefined_.

- For information about precedence rules for related severity options with different keys, for example, when different severities are specified for a single rule and for the category that rule falls under, see [Configuration options for code analysis](configuration-options.md#precedence).

## See also

- [EditorConfig vs global AnalyzerConfig design issue](https://github.com/dotnet/roslyn/issues/47707)

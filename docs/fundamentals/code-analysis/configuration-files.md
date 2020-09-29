---
title: Configuration files for code analysis rules
description: Learn about different configuration files to configure code analysis rules.
ms.date: 09/24/2020
ms.topic: conceptual
no-loc: ["EditorConfig"]
---
# Configuration files for code analysis rules

Code analysis rules have various [configuration options](configuration-options.md). These options are specified as key-value pairs in an analyzer configuration file. Following configuration files can be used to specify these options:

- [EditorConfig](#editorconfig) file: File or folder specific configuration options
- [Global AnalyzerConfig](#globalanalyzerconfig) file: Project level configuration options

## EditorConfig

You specify analyzer configuration options in an [EditorConfig](/visualstudio/ide/create-portable-custom-editor-options) file. EditorConfig files are used to provide **options that apply to specific source files or folders**. Options are placed under section headers to identify the applicable files and folders. Add an entry for each rule you want to configure, and place it under the corresponding file extension section, for example, `[*.cs]`.

```ini
[*.cs]
<%option_name%> = <%option_value%>
```

In the above example, `[*.cs]` is an editorconfig section header to select all C# files with `.cs` file extension within the current folder, including sub-folders. The subsequent entry `<%option_name%> = <%option_value%>` is an analyzer option that will be applied to all these C# files.

You can apply EditorConfig file conventions to a folder, a project, or an entire repo by placing the file in the corresponding directory. These options will be applied when executing the analysis at build time as well as inside Visual Studio.

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
dotnet_style_qualification_for_method = true:warning

#### Diagnostic configuration ####

# CA1000: Do not declare static members on generic types
dotnet_diagnostic.CA1000.severity = warning
```

## Global AnalyzerConfig

Starting with .NET5 SDK (and Visual Studio 2019 16.7), you can also configure analyzer options with Global AnalyzerConfig files. These files are used to provide **options that apply to all the source files in the project**, regardless of the actual file names or file paths of these source files.

Unlike [EditorConfig](#editorconfig) files, global config files are not designed to configure editor style settings for IDEs, such as indent size or whether to trim trailing whitespace. Instead, they are designed purely for specifying project level analyzer configuration options.

### Naming

Unlike EditorConfig files, which must be named `.editorconfig`, global config files do not need to have a specific name or extension. However, if you name these files as `.globalconfig` then they will be implicitly applied to all the C# and Visual Basic projects within the current folder, including subfolders. Otherwise, you will need to explicitly add the following MSBuild item group to your MSBuild project file:

```xml
<ItemGroup>
  <GlobalAnalyzerConfigFiles Include="<%path_to_global_analyzer_config%>" />
</ItemGroup>
```

### Format

Unlike EditorConfig files, which must have section headers, such as `[*.cs]`, to identify the applicable files and folders, Global AnalyzerConfig do not have section headers. Instead, they require a top level entry of the form `is_global = true`. This indicates that all the options in the file apply globally to the entire project. For example,

```ini
is_global = true
<%option_name%> = <%option_value%>
```

### Example
Following is an example Global AnalyzerConfig file to configure options and rule severity at project level:

```ini
# Top level entry required to mark this as a Global AnalyzerConfig file
is_global = true

# NOTE: No section headers for configuration entries

#### .NET Coding Conventions ####

# this. and Me. preferences
dotnet_style_qualification_for_method = true:warning

#### Diagnostic configuration ####

# CA1000: Do not declare static members on generic types
dotnet_diagnostic.CA1000.severity = warning
```

## Precedence rules for entries in Editorconfig and Global AnalyzerConfig

Both EditorConfig files and Global AnalyzerConfig files specify key-value pair of options. Conflicts arise when there are multiple entries with the same key, but different value. Following precedence rules are used for resolving these conflicts:

1. Conflicting entries in same configuration file: Entry which appears later in the file wins. This is true for conflicting entries within a single EditorConfig file and also within a single Global AnalyzerConfig file.
2. Conflicting entries in two EditorConfig files: Entry in the EditorConfig file which is deeper in the file system, and hence has a longer file path, wins.
3. Conflicting entries in two Global AnalyzerConfig files: A compiler warning is reported and both entries are ignored.
4. Conflicting entries in an EditorConfig file and a Global AnalyzerConfig file: Entry in the EditorConfig file wins.

> [!NOTE]
>
> - Diagnostic severity options specified from the compiler command line (`/nowarn` or `/warnaserror`) always override the diagnostic [severity configuration](configuration-options#severity-level) options specified in EditorConfig and Global AnalyzerConfig files.
>
> - Diagnostic severity options can also be specified with a [Ruleset](/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules) file. However, rulesets files are deprecated in favor of EditorConfig and Global AnalyzerConfig files. It is recommended that you [convert a ruleset file to an equivalent EditorConfig file](/visualstudio/code-quality/use-roslyn-analyzers?view=vs-2019#convert-an-existing-ruleset-file-to-editorconfig-file). Precedence for conflicting diagnostic severity entries from a ruleset file and EditorConfig/Global AnalyzerConfig files is _undefined_.

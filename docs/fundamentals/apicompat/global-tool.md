---
title: Microsoft.DotNet.ApiCompat.Tool global tool
description: Learn about the Microsoft.DotNet.ApiCompat.Tool global tool, which performs API compatibility checks on assemblies and packages.
ms.date: 11/27/2023
---

# Microsoft.DotNet.ApiCompat.Tool global tool

The Microsoft.DotNet.ApiCompat.Tool tool performs API compatibility checks on assemblies and packages.

## Install

To install the tool, run the following command.

```dotnetcli
dotnet tool install --global Microsoft.DotNet.ApiCompat.Tool
```

For more information about installing global tools, see [Install a global tool](../../core/tools/global-tools.md#install-a-global-tool).

## Usage

```dotnetcli
Microsoft.DotNet.ApiCompat.Tool [command] [options]
```

-or-

```dotnetcli
apicompat [command] [options]
```

## Commands

- **`package | --package`**

  Validates the compatibility of package assets.

## Options

- **`--version`**

  Shows version information.

- **`--generate-suppression-file`**

  Generates a compatibility suppression file.

- **`--preserve-unnecessary-suppressions`**

  Preserves unnecessary suppressions when regenerating the suppression file.

- **`--permit-unnecessary-suppressions`**

  Permits unnecessary suppressions in the suppression file.

- **`--suppression-file <FILE>`**

  Specifies the path to one or more suppression files to read from.

- **`--suppression-output-file <FILE>`**

  Specifies the path to a suppression file to write to when `--generate-suppression-file` is specified.

- **`--noWarn <NOWARN_STRING>`**

  Specifies the specific diagnostic IDs to suppress. For example, `"$(NoWarn);PKV0001"`.

- **`--respect-internals`**

  Checks both `internal` and `public` APIs.

- **`--roslyn-assemblies-path <FILE>`**

  Specifies the path to the directory that contains the Microsoft.CodeAnalysis assemblies.

- **`-v, --verbosity [high|low|normal]`**

  Controls the log level verbosity. Allowable values are `high`, `normal`, and `low`. The default is `normal`.

- **`--enable-rule-attributes-must-match`**

  Enables the rule that checks if attributes match.

- **`--exclude-attributes-file <FILE>`**

  Specifies the path to one or more attribute exclusion files. These files contains types in [DocId](../../csharp/language-reference/xmldoc/index.md#id-strings) format.

- **`--enable-rule-cannot-change-parameter-name`**

  Enables the rule that checks whether parameter names have changed in public methods.

- **`-l, --left, --left-assembly <PATH>`**

  (REQUIRED) Specifies the path to one or more assemblies that serve as the *left side* to compare.

- **`-r, --right, --right-assembly`**

  (REQUIRED) Specifies the path to one or more assemblies that serve as the *right side* to compare.

- **`--strict-mode`**

  Performs API compatibility checks in strict mode.

- **`--left-assembly-references, --lref <FILE1,FILE2,...>`**

  Specifies the paths to assembly references or the underlying directories for the *left side*. Separate multiple values with a comma.

- **`--right-assembly-references, --rref <FILE1,FILE2,...>`**

  Specifies the paths to assembly references or the underlying directories for the *right side*. Separate multiple values with a comma.

- **`--create-work-item-per-assembly`**

  Enqueues a work item for the specified *left* and *right* assemblies.

- **`--left-assemblies-transformation-pattern <PATTERN>`**

  Specifies a transformation pattern for the *left side* assemblies.

- **`--right-assemblies-transformation-pattern <PATTERN>`**

  Specifies a transformation pattern for the *right side* assemblies.

## Example

The following command compares the .NET 7 and .NET 8 versions of an assembly.

```dotnetcli
apicompat -l "C:\artifacts\bin\LibApp5\release_net7.0\LibApp5.dll" -r "c:\artifacts\bin\LibApp5\release_net8.0\LibApp5.dll"
```

---
title: Microsoft.DotNet.ApiCompat.Tool global tool
description: Learn about the Microsoft.DotNet.ApiCompat.Tool global tool, which performs API compatibility checks on assemblies and packages.
ms.date: 11/29/2023
ms.topic: article
---

# Microsoft.DotNet.ApiCompat.Tool global tool

The Microsoft.DotNet.ApiCompat.Tool tool lets you perform API compatibility checks outside of MSBuild. The tool has two modes:

- Compare a package against a baseline package.
- Compare an assembly against a baseline assembly.

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

- **`package | --package <PACKAGE_FILE>`**

  Validates the compatibility of package assets. If unspecified, the tool compares assemblies. `<PACKAGE_FILE>` specifies the path to the package file.

## Options

Some options apply to both assembly and package validation. Others apply to [assemblies only](#assembly-specific-options) or [packages only](#package-specific-options).

### General options

- **`--version`**

  Shows version information.

- **`--generate-suppression-file`**

  Generates a compatibility suppression file.

- **`--preserve-unnecessary-suppressions`**

  Preserves unnecessary suppressions when regenerating the suppression file.

  When an existing suppression file is regenerated, its content is read, deserialized into a set of suppressions, and then stored in a list. Some of the suppressions might no longer be necessary if the incompatibility has been fixed. When the suppressions are serialized back to disk, you can choose to keep *all* the existing (deserialized) expressions by specifying this option.

- **`--permit-unnecessary-suppressions`**

  Permits unnecessary suppressions in the suppression file.

- **`--suppression-file <FILE>`**

  Specifies the path to one or more suppression files to read from.

- **`--suppression-output-file <FILE>`**

  Specifies the path to a suppression file to write to when `--generate-suppression-file` is specified. If unspecified, the first `--suppression-file` path is used.

- **`--noWarn <NOWARN_STRING>`**

  Specifies the diagnostic IDs to suppress. For example, `"$(NoWarn);PKV0001"`.

- **`--respect-internals`**

  Checks both `internal` and `public` APIs.

- **`--roslyn-assemblies-path <FILE>`**

  Specifies the path to the directory that contains the Microsoft.CodeAnalysis assemblies you want to use. You only need to set this property if you want to test with a newer compiler than what's in the SDK.

- **`-v, --verbosity [high|low|normal]`**

  Controls the log level verbosity. Allowable values are `high`, `normal`, and `low`. The default is `normal`.

- **`--enable-rule-cannot-change-parameter-name`**

  Enables the rule that checks whether parameter names have changed in public methods.

- **`--enable-rule-attributes-must-match`**

  Enables the rule that checks if attributes match.

- **`--exclude-attributes-file <FILE>`**

  Specifies the path to one or more files that contain attributes to exclude in [DocId](../../csharp/language-reference/xmldoc/index.md#id-strings) format.

### Assembly-specific options

These options are only applicable when assemblies are compared.

- **`-l, --left, --left-assembly <PATH>`**

  Specifies the path to one or more assemblies that serve as the *left side* to compare. This option is required when comparing assemblies.

- **`-r, --right, --right-assembly <PATH>`**

  Specifies the path to one or more assemblies that serve as the *right side* to compare. This option is required when comparing assemblies.

- **`--strict-mode`**

  Performs API compatibility checks in [strict mode](overview.md#strict-mode).

### Package-specific options

These options are only applicable when packages are compared.

- **`--baseline-package`**

  Specifies the path to a baseline package to validate the current package against.

- **`--enable-strict-mode-for-compatible-tfms`**

  Validates API compatibility in [strict mode](overview.md#strict-mode) for contract and implementation assemblies for all compatible target frameworks. The default is `true`.

- **`--enable-strict-mode-for-compatible-frameworks-in-package`**

  Validates API compatibility in [strict mode](overview.md#strict-mode) for assemblies that are compatible based on their target framework.

- **`--enable-strict-mode-for-baseline-validation`**

  Validates API compatibility in [strict mode](overview.md#strict-mode) for package baseline checks.

- **`--package-assembly-references`**

  Specifies the paths to assembly references or their underlying directories for a specific target framework in the package. Separate multiple values with a comma.

- **`--baseline-package-assembly-references`**

  Specifies the paths to assembly references or their underlying directories for a specific target framework in the *baseline* package. Separate multiple values with a comma.

- **`--baseline-package-frameworks-to-ignore`**

  Specifies the set of target frameworks to ignore from the baseline package. The framework string must exactly match the folder name in the baseline package.

## Examples

The following command compares the current and baseline versions of an assembly.

```dotnetcli
apicompat --left bin\Release\net8.0\LibApp5.dll --right bin\Release\net8.0\LibApp5-baseline.dll
```

The following command compares the current and baseline versions of a package.

```dotnetcli
apicompat package "bin\Release\LibApp5.1.0.0.nupkg" --baseline-package "bin\Release\LibApp5.2.0.0.nupkg"
```

The following example shows the command to compare the current and baseline versions of an assembly, including the check for parameter name changes. The example also shows what the output might look like if a parameter name has changed.

```dotnetcli
>apicompat -l LibApp5-baseline.dll -r LibApp5.dll --enable-rule-cannot-change-parameter-name
API compatibility errors between 'LibApp5-baseline.dll' (left) and 'LibApp5.dll' (right):
CP0017: Parameter name on member 'KitchenHelpers.ToastBreadAsync(int, int)'
changed from 'slices' to 'numSlices'.
API breaking changes found. If those are intentional, the APICompat
suppression file can be updated by specifying the '--generate-suppression-file' parameter.
```

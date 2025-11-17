---
title: dotnet package update command
description: Update PackageReferences in a project.
author: zivkan
ms.date: 10/03/2025
---
# dotnet package update

**This article applies to:** ✔️ .NET 10 SDK and later versions

## Name

`dotnet package update` - Update referenced packages in a project.

## Synopsis

```dotnetcli
dotnet package update [<packages>...]
    [--interactive] [--project <path>]
    [--verbosity <level>] [--vulnerable]

dotnet package update -h|--help
```

## Description

The `dotnet package update` command updates packages used by projects.
If [NuGetAudit](/nuget/concepts/auditing-packages) is enabled, it can also attempt to automatically update update packages with known vulnerabilities to fixed versions.

### Warnings as Errors

`dotnet package update` does implicit restores to check if the resulting package graph is free of errors.
Using `--vulnerable` also does an implicit restore to find NuGetAudit warnings.
However, if your project uses `WarningsAsErrors` or `TreatWarningsAsErrors`, NuGet's restore warnings can cause restore to fail, preventing the update from completing.

We recommend taking advantage of MSBuild conditions and environment variables as a workaround until [this feature request](https://github.com/NuGet/Home/issues/14311) is implemented.
For example, set `<TreatWarningsAsErrors Condition=" '$(CustomCondition)' == ''>true</TreatWarningsAsErrors>` in your project, and then on most Linux and Mac shells you can run `CustomCondition=true dotnet package update`.
On Windows Command Prompt and PowerShell, you will need to set the environment variable, run dotnet package update, then unset the environment variable as three separate commands.

## Arguments

- **`packages`**

  An optional list of packages to update.
  When no packages are provided, the command will attempt to update all packages referenced by the project.
  Packages can be a package name optionally followed by an `@` and a version number.
  For example, `dotnet package update Contoso.Utilities` or `dotnet package update Contoso.Utilities@3.2.1`.
  When no version is provided, it will find the highest version available on the configured package sources.

## Options

- **`--interactive`**

    Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--project <path>`**

    The project which packages should be updated in.
    If a directory is provided, it searches for project and solution files in the directory.
    Defaults to the current working directory.

- **`--verbosity`**

    Display this amount of details in the output: `[n]ormal`, `[m]inimal`, `[q]uiet`, `[d]etailed`, or `[diag]nostic`. The default is `normal`.

- **`--vulnerable`**

    If restore reports any packages as having known vulnerabilities, this command will upgrade those packages.
    Using this option will upgrade packages to the lowest version that is higher than the currently referenced version, that does not have any known vulnerabilities.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Update all packages in the project to the highest version available

    ```dotnetcli
    dotnet package update
    ```

    ```output
    Updating outdated packages in S:\src\test\update\ConsoleApp1.
      ConsoleApp1:
        Updated Microsoft.Extensions.Configuration 9.0.0 to 9.0.9.
        Updated Microsoft.Extensions.DependencyInjection 9.0.0 to 9.0.9.

    Updated 2 packages in 7 scanned packages.
    ```

- Update Contoso.Utilities to the highest version available, and Fabrikam.WebApi to version 1.2.3

    ```dotnetcli
    dotnet package update Contoso.Utilities Fabrikam.WebApi@1.2.3
    ```

    ```output
    Updating outdated packages in S:\src\test\update\ConsoleApp1.
      ConsoleApp1:
        Updated Contoso.Utilities 2.3.1 to 2.4.6.
        Updated Fabrikam.WebApi 1.0.2 to 1.2.3.

    Updated 2 packages in 2 scanned packages.
    ```

- Update packages with known vulnerabilities

    ```dotnetcli
    dotnet package update --vulnerable
    ```

    ```output
    Updating packages with security advisories in S:\src\test\update\ConsoleApp1
      ConsoleApp1:
        Updating System.Text.Json 8.0.0 to 8.0.5.

    Updated 1 packages in 31 scanned packages.
    ```

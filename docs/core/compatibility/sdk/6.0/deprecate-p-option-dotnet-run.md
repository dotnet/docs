---
title: "Breaking change: Option -p for 'dotnet run' deprecated"
description: Learn about the breaking change in .NET 6 where the '-p' option is deprecated for 'dotnet run'.
ms.date: 07/13/2021
---
# `-p` option for `dotnet run` is deprecated

`-p` is deprecated as an abbreviation for `--project`, and using `-p` generates a warning.

This warning comes from the CLI parser, so it won't generally cause failures when warnings are treated as errors. However, if your process wraps MSBuild or CI and checks for the text "Warning", the warning will appear in that check.

## Version introduced

.NET SDK 6.0.100

## Old behavior

In previous .NET versions, `-p` indicated `--project`.

## New behavior

Starting in .NET 6, passing `-p` to `dotnet run` results in a warning that it is deprecated and to use the full `--project` option instead. Despite the warning, `-p` is still a valid abbreviation for `--project`.

## Reason for change

We are deprecating `-p` because of the close relationship `dotnet run` has with `dotnet build` and `dotnet publish`. This breaking change is the first step in aligning abbreviations for these commands. For more information, see [Spec for resolving '-p' in 'dotnet run'](https://github.com/dotnet/designs/pull/229/files).

## Recommended action

If you encounter the new warning, use `--project`. If you have a project argument that includes an `=` and you use the `-p` abbreviation, the option will be interpreted as `--property`.

Review any scripts that use `dotnet run` where you might overlook the warning if `-p` is used.

If you have any scripts that are using `dotnet run` and process the output, you could encounter a break. `dotnet run` typically doesn't output anything of its own if there are no errors, so you only get the output of the program that's being run. If you have a script or other program that wraps `dotnet run` and parses the output, the warning would be unexpected text and may cause a failure.

## Affected APIs

N/A

## See also

- [Spec for resolving '-p' in 'dotnet run'](https://github.com/dotnet/designs/pull/229/files)

<!--

### Affected APIs

Not detectable via API analysis.

-->

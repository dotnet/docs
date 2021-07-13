---
title: "Breaking change: Option -p for 'dotnet run' deprecated"
description: Learn about the breaking change in .NET 6 where the '-p' option is deprecated for 'dotnet run'.
ms.date: 07/13/2021
---
# `-p` option for `dotnet run` is deprecated

`-p` is deprecated as an abbreviation for `--project`, and using `-p` generates a warning.

This warning comes from the CLI parser, so it won't generally cause failures when warnings are treated as errors. However, if your process wraps MSBuild or CI and checks for the text "Warning", the warning will appear in that check.

Also, if you pass `--property` as an option to the application being run, the `--` syntax separator must be used.

## Version introduced

.NET SDK 6.0.100 Preview 6

## Old behavior

In previous .NET versions:

- `-p` indicated `--project`.
- `--property` was not a valid option on `dotnet run`. This option was passed through to the underlying application, even if you omitted the `--` syntax separator.

## New behavior

Starting in .NET 6:

- Passing `-p` to `dotnet run` results in a warning that it is deprecated and to use the full `--project` option instead. Despite the warning, `-p` is still a valid abbreviation for `--project`, unless the argument includes an equals `=` character (in which case the option is interpreted as `--property`).
- `--property` is now a valid option on `dotnet run`. This option is not passed through to the underlying application, unless you use the `--` syntax separator.

## Reason for change

`-p` was deprecated because of the close relationship `dotnet run` has with `dotnet build` and `dotnet publish`. This breaking change is the first step in aligning abbreviations for these commands.

To embrace Xamarin (MAUI), we need to pass MSBuild properties to MSBuild during the build portion of `dotnet run`. The option that specifies passing properties should be the same for `dotnet run`, `dotnet build`, and `dotnet publish`.

## Recommended action

If you encounter the new warning, use `--project`. If you have a project argument that includes an `=` and you use the `-p` abbreviation, the option will be interpreted as `--property` and passed to MSBuild. In this case, use `--project` to pass the argument to your application in all cases.

If your application has an option called `--property`, you'll need to use the syntax separator `--` to pass the the value to your application:

```cmd
dotnet run -- --property myPropertyValue
```

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

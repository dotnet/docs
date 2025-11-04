---
title: "Breaking change - Double quotes in file-level directives are disallowed"
description: "Learn about the breaking change in .NET 10 where double quotes in file-level directives are disallowed."
ms.date: 11/04/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/496360
---

# Double quotes in file-level directives are disallowed

Usage of double quotes `"` inside `#:` file-level directives is now a build-time error when running file-based apps (`dotnet run app.cs`).

## Version introduced

.NET 10 GA

## Previous behavior

In .NET 10 RC2 and older .NET 10 previews, quotes in directives weren't blocked but they didn't work as expected. They were only escaped as any other special character and passed to MSBuild. For example, `#:property Prop="my test"` resulted in `<Prop>&quot;my test&quot;</Prop>`.

## New behavior

An error is reported if a double quote `"` is encountered in any file-level directive. The error message is:

```output
Directives currently cannot contain double quotes (").
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-incompatible).

## Reason for change

This change was made so we can later add support for quoted directives (https://github.com/dotnet/sdk/issues/49367) without introducing a breaking change. This also improves the error recovery experience if users try to use quotes now thinking that's supported syntax.

## Recommended action

Don't use quotes in `#:` directives. If you really need to use a double quote (or another special character that currently isn't supported, like trailing whitespace), move the corresponding project metadata entry into a `Directory.Build.props` file instead (it will be picked up by the file-based app), or convert the file-based app to a full project via `dotnet project convert`.

## Affected APIs

None.

## See also

- [Preprocessor directives - File-based apps](../../../csharp/language-reference/preprocessor-directives.md)

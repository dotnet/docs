---
title: "Breaking change: EditorConfig files implicitly included"
description: Learn about the breaking change in .NET 6 where .editorconfig files can no longer be AdditionalFiles items.
ms.date: 11/17/2021
---
# EditorConfig files implicitly included

Roslyn analyzers added support for parsing and respecting *.editorconfig* file options before the compiler added support for these files. To work around this limitation, *.editorconfig* files had to be included as `AdditionalFiles` project items. Now that the compiler implicitly includes *.editorconfig* files in a project, you'll get an error if you include them as *AdditionalFiles* project items.

## Version introduced

.NET 6

## Previous behavior

*.editorconfig* files could be included as `AdditionalFiles` project items.

## New behavior

Starting with the .NET 6 SDK, you'll get the following error at compile time if you include an *.editorconfig* file as an `AdditionalFiles` project item:

**error AD0001: Analyzer [...] threw an exception of type 'System.InvalidOperationException' with message 'Passing '.editorconfig' files as additional files is no longer needed. It will be implicitly discovered (if the file is in the project's directory or any ancestor directory), or it should be converted into a 'globalconfig'.**

## Change category

This change may affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The compiler now supports *.editorconfig* files, and they're implicitly included in a project if the file is in the project directory or an ancestor directory.

## Recommended action

- If the *.editorconfig* file is in the project directory or an ancestor directory, remove the `<AdditionalFiles>` item for the *.editorconfig* file from your project file.
- Otherwise, convert the *.editorconfig* file to a [Global AnalyzerConfig](../../../../fundamentals/code-analysis/configuration-files.md#global-analyzerconfig) file, and change the `AdditionalFiles` item to a `GlobalAnalyzerConfigFiles` item in your project file.

## Affected APIs

N/A

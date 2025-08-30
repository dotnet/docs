---
title: "Breaking change - `dotnet new sln` defaults to SLNX file format"
description: "Learn about the breaking change in .NET 10 where `dotnet new sln` creates SLNX-format solution files instead of SLN-format files."
ms.date: 08/30/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48192
---

# `dotnet new sln` defaults to SLNX file format

In .NET 10, `dotnet new sln` generates an [SLNX-format](https://devblogs.microsoft.com/visualstudio/new-simpler-solution-file-format/) solution file instead of an SLN-formatted solution file.

## Version introduced

.NET 10 RC 1

## Previous behavior

Previously, `dotnet new sln` created a SLN-format solution file similar to:

```sln
# Visual Studio Version 17
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Global
        GlobalSection(SolutionConfigurationPlatforms) = preSolution
                Debug|Any CPU = Debug|Any CPU
                Release|Any CPU = Release|Any CPU
        EndGlobalSection
        GlobalSection(SolutionProperties) = preSolution
                HideSolutionNode = FALSE
        EndGlobalSection
EndGlobal
```

## New behavior

Starting in .NET 10, `dotnet new sln` creates a SLNX-format solution file similar to:

```xml
<Solution>
</Solution>
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The .NET SDK [added support for SLNX files](https://devblogs.microsoft.com/dotnet/introducing-slnx-support-dotnet-cli/) in version 9.0.200, and it's proven to be a stable, understandable format for developers. It's well-supported by all major .NET tooling and is much easier for developers to maintain. This breaking change aims to encourage the use of the SLNX format.

## Recommended action

If you desire an SLN-formatted solution file, pass the `--format sln` option to the command:

`dotnet new sln --format sln`

## Affected APIs

None.

## See also

- [.NET default templates for dotnet new](../../../tools/dotnet-new-sdk-templates.md)

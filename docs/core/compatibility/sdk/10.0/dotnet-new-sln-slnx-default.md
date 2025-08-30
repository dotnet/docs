---
title: "Breaking change - `dotnet new sln` defaults to SLNX file format"
description: "Learn about the breaking change in .NET 10 where dotnet new sln creates SLNX-format solution files instead of SLN-format files."
ms.date: 08/30/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48192
---

# `dotnet new sln` defaults to SLNX file format

In .NET 10, `dotnet new sln` generates a [SLNX-format](https://devblogs.microsoft.com/visualstudio/new-simpler-solution-file-format/) solution file instead of a SLN-formatted solution file.

## Version introduced

.NET 10 RC 1

## Previous behavior

`dotnet new sln` created a SLN-format solution file similar to:

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

`dotnet new sln` creates a SLNX-format solution file similar to:

```xml
<Solution>
</Solution>
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Support for SLNX was [added in 9.0.200](https://devblogs.microsoft.com/dotnet/introducing-slnx-support-dotnet-cli/), and it's proven to be a stable, understandable format for developers. It's well-supported by all major .NET tooling and is much easier for developers to maintain. We want to encourage the usage of the format to make everyone's lives simpler.

## Recommended action

If a SLN-formatted solution is needed, use `dotnet new sln --format sln` to get a SLN-formatted solution file.

## Affected APIs

None.
---
title: "Breaking change: MSBuild custom derived build events deprecated"
description: Learn about the breaking change in MSBuild where custom derived build events have been deprecated.
ms.date: 09/05/2023
---
# MSBuild custom derived build events deprecated

Custom derived build events of any subclass of <xref:Microsoft.Build.Framework.BuildEventArgs> by any build extensibility (mainly custom tasks) have been deprecated.

## Previous behavior

Previously, you could derive from any subclass of <xref:Microsoft.Build.Framework.BuildEventArgs> and use those types freely in custom tasks and other build extensibility points.

## New behavior

Starting in .NET 8, a build error is issued if your code uses any type derived from <xref:Microsoft.Build.Framework.BuildEventArgs> and you build using the .NET 8 version of MSBuild, that is, from the command line:

> Usage of unsecure BinaryFormatter during serialization of custom event type 'MyCustomBuildEventArgs'. This will be deprecated soon. Please use Extended*EventArgs instead. More info: https://aka.ms/msbuild/eventargs

If you build from Visual Studio, there is no change in behavior unless you opt in by setting the `MSBUILDCUSTOMBUILDEVENTWARNING` environment variable to 1 (available in Visual Studio version 17.8 and later).

## Version introduced

.NET 8 RC 1

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

<xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> serialization is obsolete in .NET 8 and later versions. Any use of <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> throws an exception at run time. Since MSBuild custom derived build events use <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, your build would crash if you use these events in your build. The new build error provides a more graceful failure.

## Recommended action

Use one of the following newly introduced, built-in events for extensibility instead of your custom derived build event:

- `Microsoft.Build.Framework.ExtendedCustomBuildEventArgs`
- `Microsoft.Build.Framework.ExtendedBuildErrorEventArgs`
- `Microsoft.Build.Framework.ExtendedBuildMessageEventArgs`
- `Microsoft.Build.Framework.ExtendedBuildWarningEventArgs`

Alternatively, you can temporarily disable the check by explicitly setting the environment variable `MSBUILDCUSTOMBUILDEVENTWARNING` to something other than 1.

## Affected APIs

- <xref:Microsoft.Build.Framework.CustomBuildEventArgs?displayProperty=fullName>

---
title: "Breaking change: Write reference assemblies to IntermediateOutputPath"
description: Learn about the breaking change in .NET 6 where reference assemblies are written to the IntermediateOutputPath by default.
ms.date: 07/13/2021
---
# Write reference assemblies to intermediate output

The .NET SDK now writes [reference assemblies](../../../../standard/assembly/reference-assemblies.md) to the `IntermediateOutputPath` instead of the `OutDir` by default. This change removes these build-time-only artifacts from outputs that you require at run time.

## Version **introduced**

.NET SDK 6.0.200

## Old behavior

Since reference assemblies were added, the .NET SDK has written reference assemblies to the `ref` directory in the `OutDir` directory of the compilation.

## New behavior

Now, reference assemblies are written to the `refint` directory of the `IntermediateOutputPath` directory by default, like many other intermediate artifacts.

## Reason for change

Reference assemblies are generally not run-time assets, and so don't belong in the `OutDir` directory by default.

## Recommended action

If you have custom build logic and you need to manipulate the reference assemblies, use the `TargetRefPath` property to get the correct path.

If an external system requires the reference assembly in `OutDir`, set the MSBuild property [ProduceReferenceAssemblyInOutDir](../../../project-sdk/msbuild-props.md#producereferenceassemblyinoutdir) to `true` in your project file.

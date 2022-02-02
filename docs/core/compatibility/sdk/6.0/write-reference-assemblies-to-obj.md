---
title: "Breaking change: Write reference assemblies to IntermediateOutputPath"
description: Learn about the breaking change in .NET 6 where reference assemblies are written to the IntermediateOutputPath by default.
ms.date: 07/13/2021
---
# Write reference assemblies to intermediate output

The .NET SDK now writes [reference assemblies](https://docs.microsoft.com/dotnet/standard/assembly/reference-assemblies) to the `IntermediateOutputPath` instead of the `OutDir` by default. This removes these build-time-only artifacts from your runtime-required outputs.

## Version **introduced**

.NET SDK 6.0.200

## Old behavior

Since reference assemblies were added, the .NET SDK has written reference assemblies to the `ref` directory in the `OutDir` of the compilation.

## New behavior

Now, reference assemblies will be written to the `refint` directory of the `IntermediateOutputPath` by default, like many other intermediate artifacts.

## Reason for change

Reference assemblies are not runtime assets, and so don't belong in the `OutDir` directory by default.

## Recommended action

If you have custom build logic and you need to manipulate the reference assemblies, use the `TargetRefPath` property to get the correct path.

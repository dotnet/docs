---
title: "Breaking change: Setting DebugSymbols to false disables PDB generation"
description: Learn about the breaking change in the .NET SDK where setting DebugSymbols to false disables PDB generation.
no-loc: [DebugSymbols]
ms.date: 07/30/2024
ms.topic: concept-article
---
# Setting DebugSymbols to false disables PDB generation

The existing [MSBuild documentation](/visualstudio/msbuild/common-msbuild-project-properties) says that specifying `DebugSymbols=false` on the command line means that program database (*.pdb*) files aren't generated. However, that wasn't true before .NET 8. The behavior has been updated such that setting `DebugSymbols` to `false` now suppresses PDB generation by changing `DebugType` to `None`.

If you currently have a script where you expect PDBs to be created, and the behavior changes when you upgrade to .NET 8 or a later version, check if the script includes `-p:DebugSymbols=false`.

## Previous behavior

`-p:DebugSymbols=false` did not suppress PDB generation.

## New behavior

`-p:DebugSymbols=false` suppresses PDB generation.

## Version introduced

.NET 8

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change aligns with the existing documentation and user expectations. The previous behavior often led to confusion.

## Recommended action

If you want to generate PDBs, don't specify `-p:DebugSymbols=false` on the command line. Simply remove that property and the PDB files will be generated again.

## Affected APIs

N/A

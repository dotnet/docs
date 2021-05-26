---
title: "Breaking change: Duplicate files removed from publish output"
description: Learn about the breaking change in .NET 6 where MSBuild tries to remove duplicate files from the publish output.
ms.date: 05/19/2021
---
# Duplicate files removed from publish output

Duplicate files in the publish output can cause build breaks or unpredictable behavior. The single-file bundler checks for duplicate files and errors if duplicates are found. With this change, MSBuild tries to remove duplicate files that are copied to the publish output folder. If MSBuild can't determine the correct duplicate to remove, it generates error NETSDK1148.

## Version introduced

.NET SDK 6.0.100 Preview 1

## Old behavior

MSBuild copied all files, including duplicates, which caused the single-file bundler to error.

## New behavior

Starting in .NET 6, MSBuild removes duplicates when it detects identical files. Or, if it can't determine which files to remove, MSBuild generates an error earlier in the process with a friendlier message that tells you which files are duplicated.

## Reason for change

In previous versions, the publish errors weren't helpful because they didn't point to which files were duplicates. For actual duplicates, .NET can remove them automatically.

## Recommended action

If you don't want the NETSDK1148 error to be generated, you can set the [ErrorOnDuplicatePublishOutputFiles](../../../project-sdk/msbuild-props.md#erroronduplicatepublishoutputfiles) property to `false`.

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

MSBuild

-->

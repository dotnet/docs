---
title: "Breaking change: Generate error for duplicate files in publish output"
description: Learn about the breaking change in .NET 6 where the .NET SDK generates an error when files from different source paths would be copied to the same location in the publish output.
ms.date: 07/07/2021
---
# Generate error for duplicate files in publish output

The .NET SDK generates a new error (`NETSDK1152`) in cases where files from different source paths would be copied to the same file path in the publish output. This can happen when a project and its project references include a file with the same name that's included in the publish output.

## Version introduced

.NET SDK 6.0.100 Preview 1

## Old behavior

Both files were copied to the same destination. The second file to be copied overwrote the first file, and which file "won" was mostly arbitrary.

In some cases, the build failed. For example, when trying to create a single-file app, the bundler failed with an <xref:System.ArgumentException>, as shown in the following build output:

```shell
C:\Program Files\dotnet\sdk\5.0.100-preview.5.20258.6\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Publish.targets(962,5): error MSB4018: The "GenerateBundle" task failed unexpectedly. [C:\repro\repro.csproj]
C:\Program Files\dotnet\sdk\5.0.100-preview.5.20258.6\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Publish.targets(962,5): error MSB4018: System.ArgumentException: Invalid input specification: Found multiple entries with the same BundleRelativePath [C:\repro\repro.csproj]
C:\Program Files\dotnet\sdk\5.0.100-preview.5.20258.6\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Publish.targets(962,5): error MSB4018: at Microsoft.NET.HostModel.Bundle.Bundler.GenerateBundle(IReadOnlyList`1 fileSpecs) [C:\repro\repro.csproj]
```

## New behavior

Starting in .NET 6, MSBuild removes duplicate files that are copied to the publish folder if both the source and destination are the same. If there are any remaining duplicates, a `NETSDK1152` error is generated and lists the files that are duplicated.

## Reason for change

Duplicate files in the publish output sometimes caused build breaks or unpredictable behavior.

## Recommended action

Ideally, you should updated your project to avoid situations where multiple files with the same name are copied to the publish output.

Alternatively, you can set the [ErrorOnDuplicatePublishOutputFiles](../../../project-sdk/msbuild-props.md#erroronduplicatepublishoutputfiles) property to `false`.

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

MSBuild

-->

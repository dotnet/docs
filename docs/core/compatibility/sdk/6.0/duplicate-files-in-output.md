---
title: "Breaking change: Generate error for duplicate files in publish output"
description: Learn about the breaking change in .NET 6 where the .NET SDK generates an error when files from different source paths would be copied to the same location in the publish output.
ms.date: 11/15/2021
---
# Generate error for duplicate files in publish output

The .NET SDK generates a new error (`NETSDK1152`) in cases where files from different source paths would be copied to the same file path in the publish output. This can happen when a project and its project references include a file with the same name that's included in the publish output.

## Version introduced

.NET SDK 6.0.100

## Old behavior

Both files were copied to the same destination. The second file to be copied overwrote the first file, and which file "won" was mostly arbitrary.

In some cases, the build failed. For example, when trying to create a single-file app, the bundler failed with an <xref:System.ArgumentException>, as shown in the following build output:

```shell
C:\Program Files\dotnet\sdk\5.0.403\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Publish.targets(962,5): error MSB4018: The "GenerateBundle" task failed unexpectedly. [C:\repro\repro.csproj]
C:\Program Files\dotnet\sdk\5.0.403\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Publish.targets(962,5): error MSB4018: System.ArgumentException: Invalid input specification: Found multiple entries with the same BundleRelativePath [C:\repro\repro.csproj]
C:\Program Files\dotnet\sdk\5.0.403\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Publish.targets(962,5): error MSB4018: at Microsoft.NET.HostModel.Bundle.Bundler.GenerateBundle(IReadOnlyList`1 fileSpecs) [C:\repro\repro.csproj]
```

## New behavior

Starting in .NET 6, MSBuild removes duplicate files that are copied to the publish folder if both the source and destination are the same. If there are any remaining duplicates, a `NETSDK1152` error is generated and lists the files that are duplicated.

## Reason for change

Duplicate files in the publish output sometimes caused build breaks or unpredictable behavior.

## Recommended action

- Ideally, you should update your project to avoid situations where multiple files with the same name are copied to the publish output. The error message includes the name of the duplicate file. Some causes for duplicate files include:

  - An ASP.NET Core project that references an ASP.NET Core web service, and each has its own *appsettings.json* file.
  - A project item where `CopyToOutputDirectory` is unnecessarily set to `Always`.
  
  [Binary log files](https://github.com/dotnet/msbuild/blob/main/documentation/wiki/Providing-Binary-Logs.md) can be useful for finding the cause of the duplicated files.

- Alternatively, you can set the [ErrorOnDuplicatePublishOutputFiles](../../../project-sdk/msbuild-props.md#erroronduplicatepublishoutputfiles) property to `false`.

## Affected APIs

N/A

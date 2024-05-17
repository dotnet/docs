---
title: "Breaking change: FileConfigurationProvider.Load throws InvalidDataException"
description: Learn about the .NET 6 breaking change in .NET extensions where Load can throw an InvalidDataException with the file path that failed to load.
ms.date: 11/05/2021
---
# FileConfigurationProvider.Load throws InvalidDataException

When <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider.Load> fails to load a file, it throws an <xref:System.IO.InvalidDataException>. If the file or directory doesn't exist, it throws a <xref:System.IO.DirectoryNotFoundException> or <xref:System.IO.FileNotFoundException>.

## Version introduced

6.0 RC 1

## Previous behavior

When loading failed, <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider.Load> did not throw an <xref:System.IO.InvalidDataException>.

## New behavior

Starting in .NET 6, <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider.Load> throws an <xref:System.IO.InvalidDataException> if a file fails to load. In addition, the exception message includes the file path that failed to load.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change improves the debugging experience. When a file fails to load, it's helpful to know which file failed to load.

## Recommended action

If you are catching specific exceptions when calling <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider.Load>, make sure to also catch <xref:System.IO.InvalidDataException>.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.FileConfigurationProvider.Load?displayProperty=fullName>

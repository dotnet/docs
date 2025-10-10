---
title: April 2025 cumulative update preview
description: Learn about the improvements in the .NET Framework April 2025 cumulative update preview.
ms.date: 04/22/2025
---
# April 2025 cumulative update preview

_Released April 22, 2025_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

#### .NET Libraries

Addresses an issue with concurrency in TypeDescriptor.GetConverter()issue in TypeDescriptor GetProperties() and GetConverter(). (*Applies to: .NET Framework 4.8, 4.8.1*)

#### .NET Runtime

Addresses an issue where interactions between .NET Framework DLL loads and OS code integrity enforcement policy trigger error reporting dialog boxes. (*Applies to: .NET Framework 4.8, 4.8.1*)

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5056579](https://support.microsoft.com/kb/5056579) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5056580](https://support.microsoft.com/kb/5056580) |
| **Windows 10, version 22H2** | **[5057056](https://support.microsoft.com/kb/5057056)** |
| .NET Framework 3.5, 4.8 | [5056577](https://support.microsoft.com/kb/5056577) |
| .NET Framework 3.5, 4.8.1 | [5056578](https://support.microsoft.com/kb/5056578) |

The operating system row lists a KB that's used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework update(s) installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that is already present on the device. Because of this, the operating system KB is not expected to be listed as installed updates on the device. The expected updates installed are the .NET Framework-specific version updates listed in the previous table.

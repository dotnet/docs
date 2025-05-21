---
title: July 2024 cumulative update preview
description: Learn about the improvements in the .NET Framework July 2024 cumulative update preview.
ms.date: 07/25/2024
ms.topic: article
---
# July 2024 cumulative update preview

_Released July 25, 2024_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

#### .NET fundamentals

Addresses an issue to render UI automation ListView sub items

Addresses an issue with bypass serialization binder with binary formatter mutations

Addresses an issue to remove meta tags information referencing "Recreational Software Advisory Council" and the content-rating schema from ASP.NET WebForms SmartNavigation feature

Addresses an issue with .NET Framework interaction with Visual Studio. The fix avoids conflicts between design-time and debug or run-time compilation of some .NET Framework ASP.NET projects that could result in slowed developer experience for large projects.

#### .NET libraries

Addresses an issue to update zlib file to latest version

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5041169](https://support.microsoft.com/kb/5041169) |
| **Windows 10, version 22H2** | **[5041355](https://support.microsoft.com/kb/5041355)** |
| .NET Framework 3.5, 4.8 | [5041167](https://support.microsoft.com/kb/5041167) |
| .NET Framework 3.5, 4.8.1 | [5041168](https://support.microsoft.com/kb/5041168) |

The operating system row lists a KB that's used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework update(s) that will be installed. Updates for individual .NET Framework versions will be installed based on the version of .NET Framework that is already present on the device. Because of this, the operating system KB is not expected to be listed as installed updates on the device. The expected update to be installed are the .NET Framework&ndash;specific version updates listed in the previous table.

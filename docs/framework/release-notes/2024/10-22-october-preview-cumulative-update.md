---
title: October 2024 cumulative update preview
description: Learn about the improvements in the .NET Framework October 2024 cumulative update preview.
ms.date: 10/22/2024
---
# October 2024 cumulative update preview

_Released October 22, 2024_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

#### ASP.NET

Addresses the "The type initializer for 'System.Web.UI.Util' threw an exception." error with design-time compilation in Visual Studio for .NET Framework ASP.NET projects. (*Applies to: .NET Framework 4.8, 4.8.1.*)

#### CLR

Address an issue where in rare cases, an infinite loop could occur when a thread enters CLR for the first time. (*Applies to: .NET Framework 4.8, 4.8.1.*)

Addresses an issue where incorrect interface call devirtualization could occur when JIT optimizations are enabled. (*Applies to: .NET Framework 4.8, 4.8.1.*)

Addresses an issue with out-of-memory exceptions during garbage collection while running applications under job limits. (*Applies to: .NET Framework 4.8, 4.8.1.*)

#### .NET fundamentals

Addresses an issue with the `UserPrincipal.GetAuthorizationGroups` API to retrieve the membership of a particular user. (*Applies to: .NET Framework 4.8, 4.8.1.*)

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5045934](https://support.microsoft.com/kb/5045934) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5045935](https://support.microsoft.com/kb/5045935) |
| **Windows 10, version 22H2** | **[5045991](https://support.microsoft.com/kb/5045991)** |
| .NET Framework 3.5, 4.8 | [5045936](https://support.microsoft.com/kb/5045936) |
| .NET Framework 3.5, 4.8.1 | [5045933](https://support.microsoft.com/kb/5045933) |

The operating system row lists a KB that's used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework update(s) that will be installed. Updates for individual .NET Framework versions will be installed based on the version of .NET Framework that is already present on the device. Because of this, the operating system KB is not expected to be listed as installed updates on the device. The expected update to be installed are the .NET Framework-specific version updates listed in the previous table.

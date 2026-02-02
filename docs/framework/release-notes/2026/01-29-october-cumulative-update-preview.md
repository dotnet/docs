---
title: January 2026 cumulative update preview
description: Learn about the improvements in the .NET Framework January 2026 cumulative update preview.
ms.date: 01/29/2026
---
# January 2026 cumulative update preview

_Released January 29, 2026_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

#### .NET Runtime

Addresses an issue to add verification logic for ClickOnce to support SHA384 and SHA512. (*Applies to: .NET Framework 4.8.1*)

Addresses an issue in cases where the Arm64 CLR could crash when code generates and catches a NullReferenceException within the same function. (*Applies to: .NET Framework 4.8.1*)

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 25H2** | |
| .NET Framework 3.5, 4.8.1 | [5074828](https://support.microsoft.com/kb/5074828) |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5074831](https://support.microsoft.com/kb/5074831) |

The operating system row lists a KB that's used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework update(s) installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that is already present on the device. Because of this, the operating system KB is not expected to be listed as installed updates on the device. The expected updates installed are the .NET Framework-specific version updates listed in the previous table.

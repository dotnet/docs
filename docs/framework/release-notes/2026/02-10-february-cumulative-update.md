---
title: February 2026 cumulative update
description: Learn about the improvements in the .NET Framework February 2026 cumulative update.
ms.date: 02/10/2026
---
# February 2026 cumulative update

_Released February 10, 2026_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

#### CVE-2025-55248 – Information Disclosure vulnerability

This security update addresses an information disclosure vulnerability detailed in [CVE 2025-55248](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2025-55248).

### Quality and reliability improvements

#### .NET Runtime

Addresses an issue to update operating system calls for compliance with current standards. (*Applies to: .NET Framework 4.8.1*)

Addresses an issue to add verification logic for ClickOnce to support SHA384 and SHA512. (*Applies to: .NET Framework 4.8.1*)

Addresses an issue in cases where the Arm64 CLR could crash when code generates and catches a NullReferenceException within the same function. (*Applies to: .NET Framework 4.8.1*)

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 26H1** | |
| .NET Framework 4.8.1 | [5074837][kbLink] |

The operating system row lists a KB that's used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework update(s) installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that is already present on the device. Because of this, the operating system KB is not expected to be listed as installed updates on the device. The expected updates installed are the .NET Framework-specific version updates listed in the previous table.

[kbLink]: https://support.microsoft.com/kb/5074837

---
title: May 2026 cumulative update preview
description: Learn about the improvements in the .NET Framework May 2026 cumulative update preview.
ms.date: 05/26/2026
---
# May 2026 cumulative update preview

_Released May 26, 2026_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

#### .NET libraries

Addresses an issue with synchronous `HttpWebRequest` connections where requests could hang in specific secure connection scenarios with certain server configurations.

#### .NET Runtime

- Addresses an issue in the Visual Studio x86 native debugger where certain floating-point values could be reported incorrectly during step operations in mixed-code applications.

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 26H1** | |
| .NET Framework 4.8.1 | [5092431](https://support.microsoft.com/kb/5092431) |
| **Windows 11, version 25H2** | |
| .NET Framework 3.5, 4.8.1 | [5092427](https://support.microsoft.com/kb/5092427) |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5092430](https://support.microsoft.com/kb/5092430) |

The operating system row lists a KB that's used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework update(s) installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that is already present on the device. Because of this, the operating system KB is not expected to be listed as installed updates on the device. The expected updates installed are the .NET Framework-specific version updates listed in the previous table.

---
title: January 2025 cumulative update preview
description: Learn about the improvements in the .NET Framework January 2025 cumulative update preview.
ms.date: 01/28/2025
ms.topic: article
---
# January 2025 cumulative update preview

_Released January 28, 2025_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

#### CLR

Addresses an issue with printing large number of pages due to an OutOfMemory exception. To apply this improvement, you must set the following AppContextSwitch. (*Applies to: .NET Framework 4.8, 4.8.1*)

```
<runtime>
  <AppContextSwitchOverrides value="Switch.System.Windows.Controls.ReleaseDiscardableFontResources=true"/>
</runtime>
```

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5050577](https://support.microsoft.com/kb/5050577) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5050578](https://support.microsoft.com/kb/5050578) |
| **Windows 10, version 22H2** | **[5050593](https://support.microsoft.com/kb/5050593)** |
| .NET Framework 3.5, 4.8 | [5050579](https://support.microsoft.com/kb/5050579) |
| .NET Framework 3.5, 4.8.1 | [5050576](https://support.microsoft.com/kb/5050576) |

The operating system row lists a KB that's used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework update(s) installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that is already present on the device. Because of this, the operating system KB is not expected to be listed as installed updates on the device. The expected updates installed are the .NET Framework-specific version updates listed in the previous table.

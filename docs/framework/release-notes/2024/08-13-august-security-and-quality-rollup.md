---
title: August 2024 security and quality rollup
description: Learn about the improvements in the .NET Framework August 2024 security and quality rollup.
ms.date: 08/13/2024
---
# August 2024 security and quality rollup

_Released August 13, 2024_

## Summary of what is new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

#### CVE-2024-29187 - Elevation of privilege vulnerability

This security update addresses an elevation of privilege vulnerability detailed in [CVE 2024-29187](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2024-29187).

### Quality and reliability improvements

This release contains the following quality and reliability improvements.

#### .NET fundamentals

Addresses an issue to render ListView sub items. (*Applies to: .NET Framework 4.8, 4.8.1.*)
Addresses an issue with bypass serialization binder with binary formatter mutations. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)
Addresses an issue to remove meta tags information referencing "Recreational Software Advisory Council" and the content-rating schema from ASP.NET WebForms SmartNavigation feature. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)
Addresses an issue with .NET Framework interaction with Visual Studio.  The fix avoids conflicts between design-time compilation of some .NET Framework ASP.NET projects that could result in slowed developer experience for large projects. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

#### .NET libraries

Addresses an issue to update zlib file to latest version (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

## Known issues

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update |
| --- | --- |
| **Microsoft server operating system, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5041969](https://support.microsoft.com/kb/5041969) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5042099](https://support.microsoft.com/kb/5042099) |
| **Microsoft server operating system, version 22H2** | **[5042485](https://support.microsoft.com/kb/5042485)** |
| .NET Framework 3.5, 4.8 | [5041948](https://support.microsoft.com/kb/5041948) |
| .NET Framework 3.5, 4.8.1 | [5041964](https://support.microsoft.com/kb/5041964) |
| **Windows 11, version 21H2** | **[5042353](https://support.microsoft.com/kb/5042353)** |
| .NET Framework 3.5, 4.8 | [5041976](https://support.microsoft.com/kb/5041976) |
| .NET Framework 3.5, 4.8.1 | [5041967](https://support.microsoft.com/kb/5041967) |
| **Microsoft server operating system, version 21H2** | **[5042349](https://support.microsoft.com/kb/5042349)** |
| .NET Framework 3.5, 4.8 | [5041948](https://support.microsoft.com/kb/5041948) |
| .NET Framework 3.5, 4.8.1 | [5041964](https://support.microsoft.com/kb/5041964) |
| **Windows 10, version 22H2** | **[5042352](https://support.microsoft.com/kb/5042352)** |
| .NET Framework 3.5, 4.8 | [5042056](https://support.microsoft.com/kb/5042056) |
| .NET Framework 3.5, 4.8.1 | [5042097](https://support.microsoft.com/kb/5042097) |
| **Windows 10, version 21H2** | **[5042351](https://support.microsoft.com/kb/5042351)** |
| .NET Framework 3.5, 4.8 | [5042056](https://support.microsoft.com/kb/5042056) |
| .NET Framework 3.5, 4.8.1 | [5042097](https://support.microsoft.com/kb/5042097) |
| **Windows 10 1809 and Windows Server 2019** | **[5042350](https://support.microsoft.com/kb/5042350)** |
| .NET Framework 3.5, 4.7.2 | [5041913](https://support.microsoft.com/kb/5041913) |
| .NET Framework 3.5, 4.8 | [5041974](https://support.microsoft.com/kb/5041974) |
| **Windows 10 1607 and Windows Server 2016** | |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5041773](https://support.microsoft.com/kb/5041773) |
| .NET Framework 4.8 | [5041951](https://support.microsoft.com/kb/5041951) |
| **Windows 10 1507** | |
| .NET Framework 3.5, 4.6, 4.6.2 | [5041782](https://support.microsoft.com/kb/5041782) |

The following table is for earlier Windows and Windows Server versions for Security and Quality Rollup updates.  

| Product version | Security and quality rollup |
| --- | --- |
| **Windows Server 2012 R2** | **[5042356](https://support.microsoft.com/kb/5042356)** |
| .NET Framework 3.5 | [5041945](https://support.microsoft.com/kb/5041945) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5041923](https://support.microsoft.com/kb/5041923) |
| .NET Framework 4.8 | [5041960](https://support.microsoft.com/kb/5041960) |
| **Windows Server 2012** | **[5042355](https://support.microsoft.com/kb/5042355)** |
| .NET Framework 3.5 | [5041936](https://support.microsoft.com/kb/5041936) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5041919](https://support.microsoft.com/kb/5041919) |
| .NET Framework 4.8 | [5041957](https://support.microsoft.com/kb/5041957) |
| **Windows Server 2008 R2** | **[5042354](https://support.microsoft.com/kb/5042354)** |
| .NET Framework 3.5.1 | [5041942](https://support.microsoft.com/kb/5041942) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5041926](https://support.microsoft.com/kb/5041926)|
| .NET Framework 4.8 | 5041929 |
| **Windows Server 2008** | **[5042357](https://support.microsoft.com/kb/5042357)** |
| .NET Framework 2.0, 3.0 | [5041939](https://support.microsoft.com/kb/5041939) |
| .NET Framework 3.5 SP1 | [5040673](https://support.microsoft.com/kb/5040673) |
| .NET Framework 4.6.2 | [5041926](https://support.microsoft.com/kb/5041926) |

The operating system rows list a KB that's used for update-offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework updates that will be installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that's already present on the device. Because of this, the operating system KB is not expected to be listed as an installed update on the device. The expected updates to be installed are the .NET Framework specific version updates listed in the preceding table.

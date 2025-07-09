---
title: July 2025 security and quality rollup
description: Learn about the improvements in the .NET Framework July 2025 security and quality rollup.
ms.date: 07/08/2025
---
# July 2025 security and quality rollup

_Released July 8, 2025_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

This release contains the following quality and reliability improvements.

#### .NET Libraries

Addresses an issue with concurrency in <xref:System.ComponentModel.TypeDescriptor.GetConverter*?displayProperty=nameWithType> and <xref:System.ComponentModel.TypeDescriptor.GetProperties*?displayProperty=nameWithType> (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

#### .NET Runtime

Addresses an issue where interactions between .NET Framework DLL loads and OS code integrity enforcement policy trigger error reporting dialog boxes. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

## Known issues

This release contains no known issues.  

## Summary tables

| Product version | Cumulative update |
| --- | --- |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5056579](https://support.microsoft.com/kb/5056579) |
| **Microsoft server operating system, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5056579](https://support.microsoft.com/kb/5056579) |
| **Microsoft server operating system, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5062062](https://support.microsoft.com/kb/5062062) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5056580](https://support.microsoft.com/kb/5056580) |
| **Microsoft server operating system, version 22H2** | **[5062159](https://support.microsoft.com/kb/5062159)** |
| .NET Framework 3.5, 4.8 | [5055169](https://support.microsoft.com/kb/5055169) |
| .NET Framework 3.5, 4.8.1 | [5054693](https://support.microsoft.com/kb/5054693) |
| **Microsoft server operating system, version 21H2** | **[5062159](https://support.microsoft.com/kb/5062159)** |
| .NET Framework 3.5, 4.8 | [5062063](https://support.microsoft.com/kb/5062063) |
| .NET Framework 3.5, 4.8.1 | [5054693](https://support.microsoft.com/kb/5054693) |
| **Windows 10, version 22H2** | **[5062154](https://support.microsoft.com/kb/5062154)** |
| .NET Framework 3.5, 4.8 | [5056577](https://support.microsoft.com/kb/5056577) |
| .NET Framework 3.5, 4.8.1 | [5056578](https://support.microsoft.com/kb/5056578) |
| **Windows 10, version 21H2** | **[5062154](https://support.microsoft.com/kb/5062154)** |
| .NET Framework 3.5, 4.8 | [5056577](https://support.microsoft.com/kb/5056577) |
| .NET Framework 3.5, 4.8.1 | [5056578](https://support.microsoft.com/kb/5056578) |
| **Windows 10 1809 and Windows Server 2019** | **[5062152](https://support.microsoft.com/kb/5062152)** |
| .NET Framework 3.5, 4.7.2 | [5062070](https://support.microsoft.com/kb/5062070) |
| .NET Framework 3.5, 4.8 | [5062068](https://support.microsoft.com/kb/5062068) |
| **Windows 10 1607 and Windows Server 2016** | |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5062560](https://support.microsoft.com/kb/5062560) |
| .NET Framework 4.8 | [5062064](https://support.microsoft.com/kb/5062064) |

The following table is for earlier Windows and Windows Server versions for Security and Quality Rollup updates.  

| Product version | Security and quality rollup |
| --- | --- |
| **Windows Server 2012 R2** | **[5062157](https://support.microsoft.com/kb/5062157)** |
| .NET Framework 3.5 | [5044012](https://support.microsoft.com/kb/5044012) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5062073](https://support.microsoft.com/kb/5062073) |
| .NET Framework 4.8 | [5062067](https://support.microsoft.com/kb/5062067) |
| **Windows Server 2012** | **[5062156](https://support.microsoft.com/kb/5062156)** |
| .NET Framework 3.5 | [5044009](https://support.microsoft.com/kb/5044009) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5062072](https://support.microsoft.com/kb/5062072) |
| .NET Framework 4.8 | [5062066](https://support.microsoft.com/kb/5062066) |
| **Windows Server 2008 R2** | **[5062155](https://support.microsoft.com/kb/5062155)** |
| .NET Framework 3.5.1 | [5044011](https://support.microsoft.com/kb/5044011) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5062071](https://support.microsoft.com/kb/5062071) |
| .NET Framework 4.8 |[5062065](https://support.microsoft.com/kb/5062065) |
| **Windows Server 2008** | **[5055687](https://support.microsoft.com/kb/5055687)** |
| .NET Framework 2.0, 3.0 | [5044010](https://support.microsoft.com/kb/5044010) |
| .NET Framework 3.5 SP1 | [5040673](https://support.microsoft.com/kb/5040673) |
| .NET Framework 4.6.2 | [5062071](https://support.microsoft.com/kb/5062071) |

The operating system row lists a KB that is used for update offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework updates to install. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that's already present on the device. Because of this, the operating system KB isn't expected to be listed as **installed updates** on the device. The expected updates to be installed are the .NET Framework-specific version updates listed in the table above.

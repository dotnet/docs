---
title: November 2024 security and quality rollup
description: Learn about the improvements in the .NET Framework November 2024 security and quality rollup.
ms.date: 11/12/2024
ms.topic: article
---
# November 2024 security and quality rollup

_Released November 12, 2024_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

#### Security Feature Bypass vulnerability

This security update addresses a security feature bypass vulnerability when using SecUtility.RandomByte (*Applies to: .NET Framework 4.8, 4.8.1.*)

#### Information Disclosure vulnerability

This security update addresses an information disclosure vulnerability with the performance counter (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

### Quality and reliability improvements

#### ASP.NET

Addresses an issue where  "The type initializer for 'System.Web.UI.Util' threw an exception." error with design-time compilation in Visual Studio for .NET Framework ASP.NET projects. (*Applies to: .NET Framework 4.8, 4.8.1.*)

#### CLR

Addresses an issue where, in rare cases, an infinite loop could occur when a thread enters CLR for the first time. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

Addresses an issue where incorrect interface call devirtualization could occur when JIT optimizations are enabled. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

Addresses an issue with out of memory exceptions during garbage collection while running applications running under job limits (*Applies to: .NET Framework 4.8, 4.8.1.*)

#### .NET fundamentals

Addresses an issue with .NET API UserPrincipal.GetAuthorizationGroups to retrieve the  Membership of a particular user (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

## Known issues

This release contains no known issues.  

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update |
| --- | --- |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5045934](https://support.microsoft.com/kb/5045934) |
| **Microsoft server operating system, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5045934](https://support.microsoft.com/kb/5045934) |
| **Microsoft server operating system, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5046270](https://support.microsoft.com/kb/5046270) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5045935](https://support.microsoft.com/kb/5045935) |
| **Microsoft server operating system, version 22H2** | **[5046539](https://support.microsoft.com/kb/5046539)** |
| .NET Framework 3.5, 4.8 | [5046265](https://support.microsoft.com/kb/5046265) |
| .NET Framework 3.5, 4.8.1 | [5046264](https://support.microsoft.com/kb/5046264) |
| **Microsoft server operating system, version 21H2** | **[5046547](https://support.microsoft.com/kb/5046547)** |
| .NET Framework 3.5, 4.8 | [5046265](https://support.microsoft.com/kb/5046265) |
| .NET Framework 3.5, 4.8.1 | [5046264](https://support.microsoft.com/kb/5046264) |
| **Windows 10, version 22H2** | **[5046542](https://support.microsoft.com/kb/5046542)** |
| .NET Framework 3.5, 4.8 | [5045936](https://support.microsoft.com/kb/5045936) |
| .NET Framework 3.5, 4.8.1 | [5045933](https://support.microsoft.com/kb/5045933) |
| **Windows 10, version 21H2** | **[5046541](https://support.microsoft.com/kb/5046541)** |
| .NET Framework 3.5, 4.8 | [5045936](https://support.microsoft.com/kb/5045936) |
| .NET Framework 3.5, 4.8.1 | [5045933](https://support.microsoft.com/kb/5045933) |
| **Windows 10 1809 and Windows Server 2019** | **[5046540](https://support.microsoft.com/kb/5046540)** |
| .NET Framework 3.5, 4.7.2 | [5046268](https://support.microsoft.com/kb/5046268) |
| .NET Framework 3.5, 4.8 | [5046269](https://support.microsoft.com/kb/5046269) |
| **Windows 10 1607 and Windows Server 2016** | |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5046612](https://support.microsoft.com/kb/5046612) |
| .NET Framework 4.8 | [5046266](https://support.microsoft.com/kb/5046266) |

The following table is for earlier Windows and Windows Server versions for Security and Quality Rollup updates.  

| Product version | Security and quality rollup |
| --- | --- |
| **Windows Server 2012 R2** | **[5046545](https://support.microsoft.com/kb/5046545)** |
| .NET Framework 3.5 | [5044012](https://support.microsoft.com/kb/5044012) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5046263](https://support.microsoft.com/kb/5046263) |
| .NET Framework 4.8 | [5046260](https://support.microsoft.com/kb/5046260) |
| **Windows Server 2012** | **[5046544](https://support.microsoft.com/kb/5046544)** |
| .NET Framework 3.5 | [5044009](https://support.microsoft.com/kb/5044009) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5046262](https://support.microsoft.com/kb/5046262) |
| .NET Framework 4.8 | [5046259](https://support.microsoft.com/kb/5046259) |
| **Windows Server 2008 R2** | **[5046543](https://support.microsoft.com/kb/5046543)** |
| .NET Framework 3.5.1 | [5044011](https://support.microsoft.com/kb/5044011) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5046261](https://support.microsoft.com/kb/5046261)|
| .NET Framework 4.8 |[5046258](https://support.microsoft.com/kb/5046258) |
| **Windows Server 2008** | **[5046546](https://support.microsoft.com/kb/5046546)** |
| .NET Framework 2.0, 3.0 | [5044010](https://support.microsoft.com/kb/5044010) |
| .NET Framework 3.5 SP1 | [5040673](https://support.microsoft.com/kb/5040673) |
| .NET Framework 4.6.2 | [5046261](https://support.microsoft.com/kb/5046261) |

The operating system rows list a KB that's used for update-offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework updates that will be installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that's already present on the device. Because of this, the operating system KB is not expected to be listed as an installed update on the device. The expected updates to be installed are the .NET Framework specific version updates listed in the preceding table.

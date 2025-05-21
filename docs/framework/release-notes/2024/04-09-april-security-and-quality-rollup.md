---
title: April 2024 security and quality rollup
description: Learn about the improvements in the .NET Framework April 2024 security and quality rollup.
ms.date: 04/17/2024
ms.topic: article
---
# April 2024 security and quality rollup

_Released April 9, 2024_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

#### CVE-2024-21409 – Remote code execution vulnerability

This security update addresses a remote code execution vulnerability detailed in [CVE 2024-21409](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2024-21409).

#### Defense in depth vulnerability

This security update addresses an issue where version of the OSS zlib library is out of date.

#### Defense in depth vulnerability

This security update addresses an issue in AIA fetching process.

### Quality and reliability improvements

This release contains the following quality and reliability improvements.

#### ASP.NET

Addresses an issue with `JavaScriptSerializer` where after installing the January Security and Quality update, there is a performance degradation. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

#### CLR

Addressed an issue with thread pool recycled lists becoming unresponsive on multi-CPU-group computers. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

Addressed an issue where Interlocked.Read from 32-bit apps are much slower on some computers. (*Applies to: .NET Framework 4.8.1.*)

#### Compilers

Addresses an issue when the native C# compiler (csc.exe) is used to compile code making calls to COM interop assemblies. (*Applies to: .NET Framework 4.8.1.*)

## Known issues

This release contains no known issues.  

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update |
| --- | --- |
| **Microsoft server operating system, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5036617](https://support.microsoft.com/kb/5036617) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5036620](https://support.microsoft.com/kb/5036620) |
| **Windows 11, version 21H2** | **[5037037](https://support.microsoft.com/kb/5037037)** |
| .NET Framework 3.5, 4.8 | [5036611](https://support.microsoft.com/kb/5036611) |
| .NET Framework 3.5, 4.8.1 | [5036619](https://support.microsoft.com/kb/5036619) |
| **Microsoft server operating system, version 22H2 and version 21H2** | **[5037033](https://support.microsoft.com/kb/5037033)** |
| .NET Framework 3.5, 4.8 | [5036613](https://support.microsoft.com/kb/5036613) |
| .NET Framework 3.5, 4.8.1 | [5036621](https://support.microsoft.com/kb/5036621) |
| **Windows 10, version 22H2** | **[5037036](https://support.microsoft.com/kb/5037036)** |
| .NET Framework 3.5, 4.8 | [5036608](https://support.microsoft.com/kb/5036608) |
| .NET Framework 3.5, 4.8.1 | [5036618](https://support.microsoft.com/kb/5036618) |
| **Windows 10, version 21H2** | **[5037035](https://support.microsoft.com/kb/5037035)** |
| .NET Framework 3.5, 4.8 | [5036608](https://support.microsoft.com/kb/5036608) |
| .NET Framework 3.5, 4.8.1 | [5036618](https://support.microsoft.com/kb/5036618) |
| **Windows 10 1809 and Windows Server 2019** | **[5037034](https://support.microsoft.com/kb/5037034)** |
| .NET Framework 3.5, 4.7.2 | [5036604](https://support.microsoft.com/kb/5036604) |
| .NET Framework 3.5, 4.8 | [5036610](https://support.microsoft.com/kb/5036610) |
| **Windows 10 1607 and Windows Server 2016** | |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5032197](https://support.microsoft.com/kb/5032197) |
| .NET Framework 4.8 | [5036609](https://support.microsoft.com/kb/5036609) |
| **Windows 10 1507** | |
| .NET Framework 3.5, 4.6, 4.6.2 | [5032199](https://support.microsoft.com/kb/5032199) |

The following table is for earlier Windows and Windows Server versions for Security and Quality Rollup updates.  

| Product version | Security and quality rollup |
| --- | --- |
| **Windows Server 2012 R2** | **[5037040](https://support.microsoft.com/kb/5037040)** |
| .NET Framework 3.5 | [5036627](https://support.microsoft.com/kb/5036627) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5036606](https://support.microsoft.com/kb/5036606) |
| .NET Framework 4.8 | [5036614](https://support.microsoft.com/kb/5036614) |
| **Windows Server 2012** | **[5037039](https://support.microsoft.com/kb/5037039)** |
| .NET Framework 3.5 | [5036624](https://support.microsoft.com/kb/5036624) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5036605](https://support.microsoft.com/kb/5036605) |
| .NET Framework 4.8 | [5036612](https://support.microsoft.com/kb/5036612) |
| **Windows Server 2008 R2** | **[5037038](https://support.microsoft.com/kb/5037038)** |
| .NET Framework 3.5.1 | [5036626](https://support.microsoft.com/kb/5036626) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5036607](https://support.microsoft.com/kb/5036607) |
| .NET Framework 4.8 |[5036615](https://support.microsoft.com/kb/5036615) |
| **Windows Server 2008** | **[5037041](https://support.microsoft.com/kb/5037041)** |
| .NET Framework 2.0, 3.0 | [5036625](https://support.microsoft.com/kb/5036625) |
| .NET Framework 3.5 SP1 | [5036637](https://support.microsoft.com/kb/5036637) |
| .NET Framework 4.6.2 | [5036607](https://support.microsoft.com/kb/5036607) |

The following table is for earlier Windows and Windows Server versions for Security Only updates, which aren't cumulative.

| Product version | Security only update |
| --- | --- |
| **Windows Server 2008 R2** | **[5037127](https://support.microsoft.com/kb/5037127)** |
| .NET Framework 3.5.1 | [5036634](https://support.microsoft.com/kb/5036634) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5036631](https://support.microsoft.com/kb/5036631) |
| .NET Framework 4.8 |[5036632](https://support.microsoft.com/kb/5036632) |
| **Windows Server 2008** | **[5037128](https://support.microsoft.com/kb/5037128)** |
| .NET Framework 2.0, 3.0 | [5036633](https://support.microsoft.com/kb/5036633) |
| .NET Framework 3.5 SP1 | [5036636](https://support.microsoft.com/kb/5036636) |
| .NET Framework 4.6.2 | [5036631](https://support.microsoft.com/kb/5036631) |

The operating system row lists a KB which will be used for update offering purposes. When the operating system KB is offered, the applicability logic will determine the specific .NET Framework update(s) will be installed. Updates for individual .NET Framework versions will be installed based on the version of .NET Framework that is already present on the device. Because of this the operating system KB is not expected to be listed as installed updates on the device. The expected update to be installed are the .NET Framework specific version updates listed in the preceding table.

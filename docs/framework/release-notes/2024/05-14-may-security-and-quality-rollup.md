---
title: May 2024 security and quality rollup
description: Learn about the improvements in the .NET Framework May 2024 security and quality rollup.
ms.date: 05/14/2024
---
# May 2024 security and quality rollup

_Released May 14, 2024_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

This release contains the following quality and reliability improvements.

#### CLR

Addresses an issue where crashes can occur if several threads all concurrently query the `ITypeInfo` implementation of the same managed type. (*Applies to: .NET Framework 4.8, 4.8.1.*)

Addresses an issue where `ISymUnmanagedReader::GetMethodsFromDocumentPosition` and `ISymUnmanagedReader2::GetMethodsInDocument` might return incorrect results under certain circumstances. (*Applies to: .NET Framework 4.8.1.*)

#### .NET libraries

Addresses an issue that can be triggered in the fbx file parser. (*Applies to: .NET Framework 4.8, 4.8.1.*)

Addresses an issue to use NIST-validated implementations of FIPS algorithms. (*Applies to: .NET Framework 4.8, 4.8.1.*)

#### .NET fundamentals

Addresses an issue with wildcard format changes introduced in IIS 10. (*Applies to: .NET Framework 4.8, 4.8.1.*)

#### WPF

Addresses an issue where apps crash when calling the `GetWindowText` and `GetWindowTextLength` methods. (*Applies to: .NET Framework 4.8, 4.8.1.*)

## Known issues

This release contains no known issues.  

## Summary tables

| Product version | Cumulative update |
| --- | --- |
| **Microsoft server operating system, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5038075](https://support.microsoft.com/kb/5038075) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5037591](https://support.microsoft.com/kb/5037591) |
| **Windows 11, version 21H2** | **[5038286](https://support.microsoft.com/kb/5038286)** |
| .NET Framework 3.5, 4.8 | [5037934](https://support.microsoft.com/kb/5037934) |
| .NET Framework 3.5, 4.8.1 | [5037931](https://support.microsoft.com/kb/5037931) |
| **Microsoft server operating system, version 22H2 and version 21H2** | **[5038282](https://support.microsoft.com/kb/5038282)** |
| .NET Framework 3.5, 4.8 | [5037930](https://support.microsoft.com/kb/5037930) |
| .NET Framework 3.5, 4.8.1 | [5037929](https://support.microsoft.com/kb/5037929) |
| **Windows 10, version 22H2** | **[5038285](https://support.microsoft.com/kb/5038285)** |
| .NET Framework 3.5, 4.8 | [5037592](https://support.microsoft.com/kb/5037592) |
| .NET Framework 3.5, 4.8.1 | [5037587](https://support.microsoft.com/kb/5037587) |
| **Windows 10, version 21H2** | **[5038284](https://support.microsoft.com/kb/5038284)** |
| .NET Framework 3.5, 4.8 | [5037592](https://support.microsoft.com/kb/5037592) |
| .NET Framework 3.5, 4.8.1 | [5037587](https://support.microsoft.com/kb/5037587) |
| **Windows 10 1809 and Windows Server 2019** | **[5038283](https://support.microsoft.com/kb/5038283)** |
| .NET Framework 3.5, 4.7.2 | [5037932](https://support.microsoft.com/kb/5037932) |
| .NET Framework 3.5, 4.8 | [5037933](https://support.microsoft.com/kb/5037933) |
| **Windows 10 1607 and Windows Server 2016** | |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5037763](https://support.microsoft.com/kb/5037763) |
| .NET Framework 4.8 | [5037926](https://support.microsoft.com/kb/5037926) |

The following table is for earlier Windows and Windows Server versions for Security and Quality Rollup updates.  

| Product version | Security and quality rollup |
| --- | --- |
| **Windows Server 2012 R2** | **[5037040](https://support.microsoft.com/kb/5037040)** |
| .NET Framework 3.5 | [5036627](https://support.microsoft.com/kb/5036627) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5037925](https://support.microsoft.com/kb/5037925) |
| .NET Framework 4.8 | [5037923](https://support.microsoft.com/kb/5037923) |
| **Windows Server 2012** | **[5037039](https://support.microsoft.com/kb/5037039)** |
| .NET Framework 3.5 | [5036624](https://support.microsoft.com/kb/5036624) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5037924](https://support.microsoft.com/kb/5037924) |
| .NET Framework 4.8 | [5037922](https://support.microsoft.com/kb/5037922) |
| **Windows Server 2008 R2** | **[5037038](https://support.microsoft.com/kb/5037038)** |
| .NET Framework 3.5.1 | [5036626](https://support.microsoft.com/kb/5036626) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5037917](https://support.microsoft.com/kb/5037917) |
| .NET Framework 4.8 |[5037916](https://support.microsoft.com/kb/5037916) |
| **Windows Server 2008** | **[5038291](https://support.microsoft.com/kb/5038291)** |
| .NET Framework 2.0, 3.0 | [5036625](https://support.microsoft.com/kb/5036625) |
| .NET Framework 3.5 SP1 | [5036637](https://support.microsoft.com/kb/5036637) |
| .NET Framework 4.6.2 | [5037917](https://support.microsoft.com/kb/5037917) |

The operating system row lists a KB which will be used for update offering purposes. When the operating system KB is offered, the applicability logic will determine the specific .NET Framework update(s) will be installed. Updates for individual .NET Framework versions will be installed based on the version of .NET Framework that is already present on the device. Because of this the operating system KB is not expected to be listed as installed updates on the device. The expected update to be installed are the .NET Framework specific version updates listed in the table above.

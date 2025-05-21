---
title: April 2024 cumulative update preview
description: Learn about the improvements in the .NET Framework April 2024 cumulative update preview.
ms.date: 04/23/2024
ms.topic: article
---
# April 2024 cumulative update preview

_Released April 23, 2024_

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

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5037591](https://support.microsoft.com/kb/5037591) |
| **Windows 10, version 22H2** | **[5037724](https://support.microsoft.com/kb/5037724)** |
| .NET Framework 3.5, 4.8 | [5037592](https://support.microsoft.com/kb/5037592) |
| .NET Framework 3.5, 4.8.1 | [5037587](https://support.microsoft.com/kb/5037587) |

The operating system row lists a KB which will be used for update offering purposes. When the operating system KB is offered, the applicability logic will determine the specific .NET Framework update(s) will be installed. Updates for individual .NET Framework versions will be installed based on the version of .NET Framework that is already present on the device. Because of this the operating system KB is not expected to be listed as installed updates on the device. The expected update to be installed are the .NET Framework specific version updates listed in the table above.

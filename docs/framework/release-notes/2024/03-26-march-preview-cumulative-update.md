---
title: March 2024 cumulative update preview
description: Learn about the improvements in the .NET Framework March 2024 cumulative update preview.
ms.date: 03/26/2024
ms.topic: article
---
# March 2024 cumulative update preview

_Released March 26, 2024_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

There are no new security improvements in this release. This update is cumulative and contains all previously released security improvements.

### Quality and reliability improvements

This release contains the following quality and reliability improvements.

#### .NET libraries

Addresses a performance issue in ASP.NET applications after installing the January 2024 .NET Framework update. (*Applies to: .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1.*)

#### .NET runtime

Addresses an issue when thread pool recycled lists become unresponsive on multi-CPU-group computers. (*Applies to: .NET Framework 4.8, 4.8.1.*)

Addresses an issue where Interlocked.Read from 32-bit apps are much slower on some computers. (*Applies to: .NET Framework 4.8.1.*)

#### .NET compilers

Addresses an issue when using the native C# compiler (csc.exe) to compile code making calls to COM interop assemblies. (*Applies to: .NET Framework 4.8.1.*)

## Known issues

This release contains no known issues.  

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update preview |
| --- | --- |
| **Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5036035](https://support.microsoft.com/kb/5036035) |
| **Windows 11, version 22H2** | |
| .NET Framework 3.5, 4.8.1 | [5036581](https://support.microsoft.com/kb/5036581) |
| **Windows 10, version 22H2** | **[5036580](https://support.microsoft.com/kb/5036580)** |
| .NET Framework 3.5, 4.8 | [5036036](https://support.microsoft.com/kb/5036036) |
| .NET Framework 3.5, 4.8.1 | [5036034](https://support.microsoft.com/kb/5036034) |

The operating system row lists a KB which will be used for update offering purposes. When the operating system KB is offered, the applicability logic will determine the specific .NET Framework update(s) will be installed. Updates for individual .NET Framework versions will be installed based on the version of .NET Framework that is already present on the device. Because of this the operating system KB is not expected to be listed as installed updates on the device. The expected update to be installed are the .NET Framework specific version updates listed in the table above.

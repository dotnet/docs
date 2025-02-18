---
title: January 2025 cumulative update
description: Learn about the improvements in the .NET Framework January 2025 cumulative update.
ms.date: 01/14/2025
---
# January 2025 cumulative update

_Released January 14, 2025_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

#### CVE-2025-21176 – Remote Code Execution vulnerability

This security update addresses a remote code execution vulnerability detailed in [CVE 2025-21146](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2025-21176).

### Quality and reliability improvements

#### CLR

Address crashes that can occur due to certain interactions between multi-module assembly native image usage and OS code integrity enforcement policy updates. (*Applies to: .NET Framework 4.8, 4.8.1*)

## Known issues in this release

This release contains no known issues.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update |
| --- | --- |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5049622](https://support.microsoft.com/kb/5049622) |
| **Microsoft server operating system, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5049622](https://support.microsoft.com/kb/5049622) |
| **Microsoft server operating system, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5049620](https://support.microsoft.com/kb/5049620) |
| **Windows 11, version 22H2 and Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5049624](https://support.microsoft.com/kb/5049624) |
| **Microsoft server operating system, version 22H2** | **[5050190](https://support.microsoft.com/kb/5050190)** |
| .NET Framework 3.5, 4.8 | [5049617](https://support.microsoft.com/kb/5049617) |
| .NET Framework 3.5, 4.8.1 | [5049625](https://support.microsoft.com/kb/5049625) |
| **Microsoft server operating system, version 21H2** | **[5050187](https://support.microsoft.com/kb/5050187)** |
| .NET Framework 3.5, 4.8 | [5049617](https://support.microsoft.com/kb/5049617) |
| .NET Framework 3.5, 4.8.1 | [5049625](https://support.microsoft.com/kb/5049625) |
| **Windows 10, version 22H2** | **[5050188](https://support.microsoft.com/kb/5050188)** |
| .NET Framework 3.5, 4.8 | [5049613](https://support.microsoft.com/kb/5049613) |
| .NET Framework 3.5, 4.8.1 | [5049621](https://support.microsoft.com/kb/5049621) |
| **Windows 10, version 21H2** | **[5050416](https://support.microsoft.com/kb/5050416)** |
| .NET Framework 3.5, 4.8 | [5049613](https://support.microsoft.com/kb/5049613) |
| .NET Framework 3.5, 4.8.1 | [5049621](https://support.microsoft.com/kb/5049621) |
| **Windows 10 1809 and Windows Server 2019** | **[5050182](https://support.microsoft.com/kb/5050182)** |
| .NET Framework 3.5, 4.7.2 | [5049608](https://support.microsoft.com/kb/5049608) |
| .NET Framework 3.5, 4.8 | [5049615](https://support.microsoft.com/kb/5049615) |
| **Windows 10 1607 and Windows Server 2016** | |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5049993](https://support.microsoft.com/kb/5049993) |
| .NET Framework 4.8 | [5049614](https://support.microsoft.com/kb/5049614) |

The following table is for earlier Windows and Windows Server versions for Security and Quality Rollup updates.  

| Product version | Security and quality rollup |
| --- | --- |
| **Windows Server 2012 R2** | **[5050185](https://support.microsoft.com/kb/5050185)** |
| .NET Framework 3.5 | [5044012](https://support.microsoft.com/kb/5044012) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5049610](https://support.microsoft.com/kb/5049610) |
| .NET Framework 4.8 | [5049614](https://support.microsoft.com/kb/5049614) |
| **Windows Server 2012** | **[5050184](https://support.microsoft.com/kb/5050184)** |
| .NET Framework 3.5 | [5044009](https://support.microsoft.com/kb/5044009) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [55049609](https://support.microsoft.com/kb/5049610) |
| .NET Framework 4.8 | [5049618](https://support.microsoft.com/kb/5049618) |
| **Windows Server 2008 R2** | **[5046543](https://support.microsoft.com/kb/5046543)** |
| .NET Framework 3.5.1 | [5044011](https://support.microsoft.com/kb/5044011) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5049611](https://support.microsoft.com/kb/5049611)|
| .NET Framework 4.8 |[5049619](https://support.microsoft.com/kb/5049619) |
| **Windows Server 2008** | **[5050186](https://support.microsoft.com/kb/5050186)** |
| .NET Framework 2.0, 3.0 | [5044010](https://support.microsoft.com/kb/5044010) |
| .NET Framework 3.5 SP1 | [5040673](https://support.microsoft.com/kb/5040673) |
| .NET Framework 4.6.2 | [5049611](https://support.microsoft.com/kb/5049611) |

| Product version | Security Only Update |
| --- | --- |
| **Windows Server 2008 R2** | **[5050180](https://support.microsoft.com/kb/5050180)** |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5049627](https://support.microsoft.com/kb/5049627)|
| .NET Framework 4.8 |[5049628](https://support.microsoft.com/kb/5049628) |
| **Windows Server 2008** | **[5050181](https://support.microsoft.com/kb/5050181)** |
| .NET Framework 4.6.2 | [5049627](https://support.microsoft.com/kb/5049627) |

The operating system rows list a KB that's used for update-offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework updates that will be installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that's already present on the device. Because of this, the operating system KB is not expected to be listed as an installed update on the device. The expected updates to be installed are the .NET Framework specific version updates listed in the preceding table.

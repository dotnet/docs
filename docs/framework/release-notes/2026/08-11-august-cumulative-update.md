---
title: August 2026 cumulative update
description: Learn about the improvements in the .NET Framework August 2026 cumulative update.
ms.date: 09/02/2026
ai-usage: ai-generated
---
# .NET Framework August 2026 cumulative update

_Released August 11, 2026_
_Updated Septemner 2, 2026 to include known issues_

## Summary of what's new in this release

- [Security improvements](#security-improvements)
- [Quality and reliability improvements](#quality-and-reliability-improvements)

### Security improvements

#### CVE-2026-65810 – Elevation of Privilege vulnerability

This security update addresses an elevation of privilege vulnerability detailed in [CVE-2026-65810](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2026-65810).

#### CVE-2026-62872 – Elevation of Privilege vulnerability

This security update addresses an elevation of privilege vulnerability detailed in [CVE-2026-62872](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2026-62872).

#### CVE-2026-62886 – Remote Code Execution vulnerability

This security update addresses a remote code execution vulnerability detailed in [CVE-2026-62886](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2026-62886).

#### CVE-2026-62897 – Remote Code Execution vulnerability

This security update addresses a remote code execution vulnerability detailed in [CVE-2026-62897](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2026-62897).

#### CVE-2026-62902 – Information Disclosure vulnerability

This security update addresses an information disclosure vulnerability detailed in [CVE-2026-62902](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2026-62902).

#### CVE-2026-70354 – Remote Code Execution vulnerability

This security update addresses a remote code execution vulnerability detailed in [CVE-2026-70354](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2026-70354).

### Quality and reliability improvements

There are no new quality and reliability improvements in this release.

## Known issues in this release

#### Known Issue

After installing the August 2026 .NET Framework cumulative update, some Windows Presentation Foundation (WPF) applications may fail with a `System.IO.FileFormatException` when printing or generating PDF/XPS content that uses certain fonts, including Calibri.

#### Workaround

Applications may mitigate this issue by enabling the `Switch.MS.Internal.TtfDelta.DisableCmapAndSbitOverflowProtection` AppContext switch in the application configuration file:

```xml
<configuration>
<runtime>
<AppContextSwitchOverrides
value="Switch.MS.Internal.TtfDelta.DisableCmapAndSbitOverflowProtection=true"/>
</runtime>
</configuration>
```

This switch disables security protections introduced in the August 2026 update and may increase exposure to the vulnerabilities addressed by that update. Microsoft recommends using this workaround only as a temporary measure and only when required to address this issue.

#### Status

Investigating.

#### Known Issue

After installing the August 2026 .NET Framework cumulative update, WPF applications that print—or display print preview—from an in-memory XPS document registered with `System.IO.Packaging.PackageStore` may fail with a `System.IO.FileFormatException` while the document is loading. This occurs when the package identity used as both the `PackageStore` key and the `XpsDocument` package identity is an absolute URI that uses the `pack` scheme—for example, `pack://<guid>.xps`. Images and fonts contained within the same XPS package are then incorrectly rejected as being outside the package. Application code and XPS content do not need to have changed for this failure to occur.

#### Workaround

Applications that can be rebuilt should use an absolute package identity that does not use the `pack` scheme—for example, `xpspack://<guid>.xps`. This resolves the failure while keeping the protections introduced in the August 2026 update enabled. For applications that cannot be rebuilt, enable the `Switch.System.Windows.DisableXpsPackageBoundaryRestriction` AppContext switch in the application configuration file:

```xml
<configuration>
<runtime>
<AppContextSwitchOverrides
value="Switch.System.Windows.DisableXpsPackageBoundaryRestriction=true"/>
</runtime>
</configuration>
```

This switch disables security protections introduced in the August 2026 update and may increase exposure to the vulnerabilities addressed by that update. Microsoft recommends using this workaround only as a temporary measure and only when required to address this issue.

#### Status

Investigating.

## Summary tables

The following table outlines the updates in this release.

| Product version | Cumulative update |
| --- | --- |
| **Windows 11, version 26H1** | |
| .NET Framework 4.8.1 | [5120711](https://support.microsoft.com/kb/5120711) |
| **Windows 11, version 25H2** | |
| .NET Framework 3.5, 4.8.1 | [5120708](https://support.microsoft.com/kb/5120708) |
| **Windows 11, version 24H2** | |
| .NET Framework 3.5, 4.8.1 | [5120710](https://support.microsoft.com/kb/5120710) |
| **Windows 11, version 23H2** | |
| .NET Framework 3.5, 4.8.1 | [5120713](https://support.microsoft.com/kb/5120713) |
| **Windows Server 2025** | |
| .NET Framework 3.5, 4.8.1 | [5120708](https://support.microsoft.com/kb/5120708) |
| **Windows Server 2022** | |
| .NET Framework 3.5, 4.8 | [5120705](https://support.microsoft.com/kb/5120705) |
| .NET Framework 3.5, 4.8.1 | [5120714](https://support.microsoft.com/kb/5120714) |
| **Windows 10, version 22H2** | |
| .NET Framework 3.5, 4.8 | [5120701](https://support.microsoft.com/kb/5120701) |
| .NET Framework 3.5, 4.8.1 | [5120709](https://support.microsoft.com/kb/5120709) |
| **Windows 10, version 21H2** | |
| .NET Framework 3.5, 4.8 | [5120701](https://support.microsoft.com/kb/5120701) |
| .NET Framework 3.5, 4.8.1 | [5120709](https://support.microsoft.com/kb/5120709) |
| **Windows 10 1809 and Windows Server 2019** | |
| .NET Framework 3.5, 4.7.2 | [5120698](https://support.microsoft.com/kb/5120698) |
| .NET Framework 3.5, 4.8 | [5120703](https://support.microsoft.com/kb/5120703) |
| **Windows 10 1607 and Windows Server 2016** | |
| .NET Framework 3.5, 4.6.2, 4.7, 4.7.1, 4.7.2 | [5120418](https://support.microsoft.com/kb/5120418) |
| .NET Framework 4.8 | [5120702](https://support.microsoft.com/kb/5120702) |

The following table is for earlier Windows Server versions for Security and Quality Rollup updates.

| Product version | Security and quality rollup |
| --- | --- |
| **Windows Server 2012 R2** | |
| .NET Framework 3.5 | [5120695](https://support.microsoft.com/kb/5120695) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5120700](https://support.microsoft.com/kb/5120700) |
| .NET Framework 4.8 | [5120706](https://support.microsoft.com/kb/5120706) |
| **Windows Server 2012** | |
| .NET Framework 3.5 | [5120716](https://support.microsoft.com/kb/5120716) |
| .NET Framework 4.6.2, 4.7, 4.7.1, 4.7.2 | [5120699](https://support.microsoft.com/kb/5120699) |
| .NET Framework 4.8 | [5120704](https://support.microsoft.com/kb/5120704) |

The operating system rows list a KB that's used for update-offering purposes. When the operating system KB is offered, the applicability logic determines the specific .NET Framework updates that will be installed. Updates for individual .NET Framework versions are installed based on the version of .NET Framework that's already present on the device. Because of this, the operating system KB is not expected to be listed as an installed update on the device. The expected updates to be installed are the .NET Framework specific version updates listed in the preceding table.

This update installs the complete .NET Framework 3.5 product for Windows 11, version 26H1 (build version 28000) and newer. Unlike traditional cumulative updates that patch individual components, this update delivers the full .NET Framework 3.5 product as a standalone installer. It replaces any previously installed version.

| Product version | .NET Framework 3.5 product update |
| --- | --- |
| .NET Framework 3.5 | [5120747](https://support.microsoft.com/kb/5120747) |

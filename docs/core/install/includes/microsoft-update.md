---
author: joeloff
ms.author: joeloff
ms.date: 11/12/2024
ms.topic: include
---

.NET is an independent product that can be serviced using Microsoft Update (MU) on Windows. This is different from Windows Update (WU) that is used to service operating system components like .NET Framework. 

Both security and non-security fixes for supported versions of .NET are provided through MU using multiple distribution channels. Automatic Updates (AU) is relevant to end-users and consumers while Window Server Update Services (WSUS) and Windows Update Catalog are relevant to IT administrators.

The .NET installer executables support side-by-side (SxS) installations across major/minor releases for different architectures and components (runtime, SDK, etc.). For example, users can install both the 6.0.15 (x64) and 6.0.17 (x86) runtime. When MU triggers, it will offer the latest installer for both installations.

### Blocking Updates

While most users prefer to be kept up to date, it is possible to block .NET updates using the registry keys in the table below.  

| .NET Version | Registry Key | Name | Type | Value |
| -------------- | :--------- | :---------- | :---------- | :---------- |
| All | HKLM\SOFWARE\Microsoft\\.NET | BlockMU | REG_DWORD | 0x00000001 |
| .NET 9 | HKLM\SOFWARE\Microsoft\\.NET\9.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 8 | HKLM\SOFWARE\Microsoft\\.NET\8.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 7 | HKLM\SOFWARE\Microsoft\\.NET\7.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 6 | HKLM\SOFWARE\Microsoft\\.NET\6.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 5 | HKLM\SOFWARE\Microsoft\\.NET\5.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET Core 3.1 | HKLM\SOFWARE\Microsoft\\.NET\3.1 | BlockMU | REG_DWORD | 0x00000001 |
| .NET Core 2.1 | HKLM\SOFWARE\Microsoft\\.NET\2.1 | BlockMU | REG_DWORD | 0x00000001 |

### Automatic Updates for Server OS

Updates for server operating systems are supported by WSUS and Microsoft Update Catalog, but not AU. Server operating systems can opt in to receive updates through AU using the following registry keys.

| .NET Version | Registry Key | Name | Type | Value |
| -------------- | :--------- | :---------- | :---------- | :---------- |
| All | HKLM\SOFWARE\Microsoft\\.NET | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 9 | HKLM\SOFWARE\Microsoft\\.NET\9.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 8 | HKLM\SOFWARE\Microsoft\\.NET\8.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 7 | HKLM\SOFWARE\Microsoft\\.NET\7.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 6 | HKLM\SOFWARE\Microsoft\\.NET\6.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 5 | HKLM\SOFWARE\Microsoft\\.NET\5.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET Core 3.1 | HKLM\SOFWARE\Microsoft\\.NET\3.1 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |

### Framework-Dependent Deployed Applications

**NOTE:** This feature is only available in .NET 8 (8.0.36 and later), .NET 9 and later versions.

Because updates provided through MU execute quietly, users will not be prompted to close running applications. The Restart Manager service is responsible for closing and restarting applications and depends on a number of factors:

- The type (UI or console) of the application or service.
- The security identifiers (SID) associated with the installation and application processes.
- Windows Installer machine policies.
- Whether or not an application was registered with Restart Manager.

Since MU executes the local system account (NT Authority\SYSTEM), framework-dependent deployed (FDD) user applications may continue to run. The update process will first install the new .NET version before removing previous installations. When the running application tries to load additional assemblies it will crash because the previous runtime no longer exists. To mitigate this, users can defer the removal of the previous .NET version until a member in the Administrators group log on after a reboot using the registry keys below.

| .NET Version | Registry Key | Name | Type | Value |
| -------------- | :--------- | :---------- | :---------- | :---------- |
| All | HKLM\SOFWARE\Microsoft\.NET | RemovePreviousVersion | REG_SZ | *always*, *never*, or *nextSession* |
| .NET 9 | HKLM\SOFWARE\Microsoft\.NET\9.0 | RemovePreviousVersion | REG_SZ | *always*, *never*, or *nextSession* |
| .NET 8 | HKLM\SOFWARE\Microsoft\.NET\8.0 | RemovePreviousVersion | REG_SZ | *always*, *never*, or *nextSession* |

- *never* retains previous installations and requires manual intervention to remove previous .NET installations.
- *always* removes previous installations after the new version is installed. This is the default behavior in .NET.
- *nextSession* defers the removal until the next logon session from members in the Administrators group.
- Values are case-insensitive and invalid values default to *always*.

When the removal is deferred, the installer writes a command to the [RunOnce](/windows/win32/setupapi/run-and-runonce-registry-keys) registry key to uninstall the previous version. The command only executes if users in the Administrators group logs on to the machine.

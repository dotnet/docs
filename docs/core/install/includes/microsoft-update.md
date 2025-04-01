---
author: joeloff
ms.author: joeloff
ms.date: 11/12/2024
ms.topic: include
---

The .NET installer executables are independent products that can be serviced using Microsoft Update (MU) on Windows. MU is different to Windows Update (WU), which is used to service operating system components like .NET Framework.

Both security and non-security fixes for supported versions of .NET are provided through MU using multiple distribution channels. Automatic Updates (AU) is relevant to end users and consumers, while Window Server Update Services (WSUS) and Windows Update Catalog are relevant to IT administrators.

The .NET installer executables support side-by-side (SxS) installations across major and minor releases for different architectures and components, such as the runtime and SDK. For example, you can install both the 6.0.15 (x64) and 6.0.17 (x86) runtime. When MU triggers, it will offer the latest installer for both installations.

#### Block updates

While most users prefer to be kept up to date, it is possible to block .NET updates using the registry keys in the following table.

| .NET version | Registry key | Name | Type | Value |
| -------------- | :--------- | :---------- | :---------- | :---------- |
| All | HKLM\SOFTWARE\Microsoft\\.NET | BlockMU | REG_DWORD | 0x00000001 |
| .NET 9 | HKLM\SOFTWARE\Microsoft\\.NET\9.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 8 | HKLM\SOFTWARE\Microsoft\\.NET\8.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 7 | HKLM\SOFTWARE\Microsoft\\.NET\7.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 6 | HKLM\SOFTWARE\Microsoft\\.NET\6.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET 5 | HKLM\SOFTWARE\Microsoft\\.NET\5.0 | BlockMU | REG_DWORD | 0x00000001 |
| .NET Core 3.1 | HKLM\SOFTWARE\Microsoft\\.NET\3.1 | BlockMU | REG_DWORD | 0x00000001 |
| .NET Core 2.1 | HKLM\SOFTWARE\Microsoft\\.NET\2.1 | BlockMU | REG_DWORD | 0x00000001 |

#### Automatic updates for Server OS

Updates for server operating systems are supported by WSUS and Microsoft Update Catalog, but not AU. Server operating systems can opt in to receive updates through AU using the following registry keys.

| .NET version | Registry key | Name | Type | Value |
| -------------- | :--------- | :---------- | :---------- | :---------- |
| All | HKLM\SOFTWARE\Microsoft\\.NET | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 9 | HKLM\SOFTWARE\Microsoft\\.NET\9.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 8 | HKLM\SOFTWARE\Microsoft\\.NET\8.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 7 | HKLM\SOFTWARE\Microsoft\\.NET\7.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 6 | HKLM\SOFTWARE\Microsoft\\.NET\6.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET 5 | HKLM\SOFTWARE\Microsoft\\.NET\5.0 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |
| .NET Core 3.1 | HKLM\SOFTWARE\Microsoft\\.NET\3.1 | AllowAUOnServerOS | REG_DWORD | 0x00000001 |

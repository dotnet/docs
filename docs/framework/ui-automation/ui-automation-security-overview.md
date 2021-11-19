---
title: "UI Automation Security Overview"
description: Read an overview of the security model for Microsoft UI Automation. Understand user account control, tasks that require higher privileges, and manifest files.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, security model"
  - "security model, UI Automation"
ms.assetid: 1d853695-973c-48ae-b382-4132ae702805
---
# UI Automation Security Overview

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

This overview describes the security model for Microsoft UI Automation in Windows Vista.

<a name="User_Account_Control"></a>

## User Account Control

Security is a major focus of Windows Vista and among the innovations is the ability for users to run as standard (non-administrator) users without necessarily being blocked from running applications and services that require higher privileges.

In Windows Vista, most applications are supplied with either a standard or an administrative token. If an application cannot be identified as an administrative application, it is launched as a standard application by default. Before an application identified as administrative can be launched, Windows Vista prompts the user for consent to run the application as elevated. The consent prompt is displayed by default, even if the user is a member of the local Administrators group, because administrators run as standard users until an application or system component that requires administrative credentials requests permission to run.

<a name="Tasks_Requiring_Higher_Privileges"></a>

## Tasks Requiring Higher Privileges

When a user attempts to perform a task that requires administrative privileges, Windows Vista presents a dialog box asking the user for consent to continue. This dialog box is protected from cross-process communication, so that malicious software cannot simulate user input. Similarly, the desktop logon screen cannot normally be accessed by other processes.

UI Automation clients must communicate with other processes, some of them perhaps running at a higher privilege level. Clients also might need access to the system dialog boxes that are not normally visible to other processes. Therefore, UI Automation clients must be trusted by the system, and must run with special privileges.

To be trusted to communicate with applications running at a higher privilege level, applications must be signed.

<a name="Manifest_Files"></a>

## Manifest Files

To gain access to the protected system UI, applications must be built with a manifest file that includes the `uiAccess` attribute in the `requestedExecutionLevel` tag, as follows:

```xml
<trustInfo xmlns="urn:schemas-microsoft-com:asm.v3">
  <security>
    <requestedPrivileges>
      <requestedExecutionLevel
        level="highestAvailable"
        uiAccess="true" />
    </requestedPrivileges>
  </security>
</trustInfo>
```

The value of the `level` attribute in this code is an example only.

`uiAccess` is "false" by default; that is, if the attribute is omitted, or if there is no manifest for the assembly, the application will not be able to gain access to protected UI.

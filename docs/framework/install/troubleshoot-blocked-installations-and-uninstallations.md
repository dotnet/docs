---
title: "Troubleshoot blocked .NET Framework installations and uninstallations"
description: "Troubleshoot issues you encounter that prevent installation of the .NET Framework. Consult status messages for information to resolve issues."
ms.date: "04/18/2019"
helpviewer_keywords: 
  - ".NET Framework, troubleshooting blocked installations"
  - "blocked .NET Framework installations, troubleshooting"
ms.assetid: c3fdfbc1-ed99-4202-a2b0-8c4f1646385d
---

# Troubleshoot blocked .NET Framework installations and uninstallations

When you run the [web or offline installer](guide-for-developers.md) for the .NET Framework 4.5 or later versions, you might encounter an issue that prevents or blocks the installation of the .NET Framework. The following table lists possible blocking issues and provides links to troubleshooting information.

In Windows 8 and above, the .NET Framework is an operating system component and cannot be independently uninstalled. Updates to the .NET Framework appear in the **Installed Updates** tab of the Control Panel **Programs and Features** app. For operating systems on which the .NET Framework is not preinstalled, the .NET Framework appears in the **Uninstall or change a program** tab (or the **Add/Remove programs** tab) of the **Program and Features** app in Control Panel. For information on the Windows versions on which the .NET Framework is preinstalled, see [System Requirements](../get-started/system-requirements.md).

> [!IMPORTANT]
> Because the 4.x versions of the .NET Framework are in-place updates, you cannot install an earlier version of the .NET Framework 4.x on a system  that already has a later version installed. For example, on a system with Windows 10 Fall Creators Update, you cannot install the .NET Framework 4.6.2, since the .NET Framework 4.7.1 is preinstalled with the operating system.

You can determine which versions of the .NET Framework are installed on a system. See [How to: Determine Which .NET Framework Versions Are Installed](../migration-guide/how-to-determine-which-versions-are-installed.md) for more information.

In this table, 4.5.x refers to the .NET Framework 4.5 and its point releases, 4.5.1, and 4.5.2, 4.6.x refers to the .NET Framework 4.6 and its point releases, 4.6.1 and 4.6.2, 4.7.x refers to the .NET Framework 4.7 and its point releases, 4.7.1 and 4.7.2, and 4.8 refers to .NET Framework 4.8.

|Blocking message|For more information or to resolve the issue|  
|----------------------|--------------------------------------------------|  
|Uninstalling the Microsoft .NET Framework may cause some applications to cease to function.|In general, you should not uninstall any versions of the .NET Framework that are installed on your computer, because an application you use may depend on a specific version of the .NET Framework. For more information, see [The .NET Framework for users](../get-started/index.md#ForUsers) in the *Getting Started* guide.|  
|.NET Framework 4.5.x/4.6.x/4.7.x (ENU) or a later version is already installed on this computer.|No action necessary.<br /><br /> To determine which versions of the .NET Framework are installed on a system, see [How to: Determine Which .NET Framework Versions Are Installed](../migration-guide/how-to-determine-which-versions-are-installed.md).|  
|The .NET Framework 4.5.x/4.6.x/4.7.x/4.8 (*language*) requires the .NET Framework 4.5.x/4.6.x/4.7.x/4.8. Please install the .NET Framework 4.5.x/4.6.x/4.7.x/4.8 from the Download Center and rerun Setup.|You must install the English version of the specified .NET Framework release before installing a language pack. For more information, see the section on [To install language packs](guide-for-developers.md#to-install-language-packs) in the installation guide.|  
|Cannot install the .NET Framework 4.5.x/4.6.x/4.7.x/4.8. Other applications on your computer are not compatible with this program.<br /><br /> -or-<br /><br /> Other applications on your computer are not compatible with this program.|The most likely cause of this message is that a preview or RC version of the .NET Framework was installed. Uninstall the preview or RC version and rerun Setup.|  
|.NET Framework 4.5.x/4.6.x/4.7.x/4.8 cannot be uninstalled using this package. To uninstall .NET Framework 4.5.x/4.6.x/4.7.x/4.8 from your computer, go to **Control Panel**, choose **Programs and Features**, choose **View installed updates**, select Update for Microsoft Windows (KB2828152) and then choose **Uninstall**.|The package you are installing doesn't uninstall preview or RC releases of the .NET Framework.<br /><br /> Uninstall the preview or RC release from Control Panel.|  
|Cannot uninstall the .NET Framework 4.5.x/4.6.x/4.7.x/4.8. Other applications on your computer are dependent on this program.|In general, you shouldn't uninstall any versions of the .NET Framework from your computer, because an application you use may depend on a specific version of the .NET Framework. For more information, see [The .NET Framework for users](../get-started/index.md#ForUsers) in the *Getting Started* guide.|  
|The .NET Framework 4.5.x/4.6.x/4.7.x/4.8 redistributable does not apply to this operating system. Please download the .NET Framework 4.5.x/4.6.x/4.7.x/4.8 for your operating system from the .NET Framework download page.|You may be trying to install .NET Framework 4.5.1, 4.5.2, 4.6, 4.6.1, 4.6.2, 4.7, 4.7.1, 4.7.2, or 4.8 on a platform that isn't supported, or you have chosen the installation package that does not include the components for all supported operating systems. Run the installation again by using the offline installer ([for 4.5.1](https://go.microsoft.com/fwlink/p/?LinkId=309493), [for 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452), [for 4.6](https://dotnet.microsoft.com/download/dotnet-framework/net46),  [for 4.6.1](https://dotnet.microsoft.com/download/dotnet-framework/net461), for [4.6.2](https://go.microsoft.com/fwlink/p/?LinkId=780604), for [4.7](https://go.microsoft.com/fwlink/p/?LinkId=825306)), for [4.7.1](https://go.microsoft.com/fwlink/p/?LinkId=852090), for [4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472), or for [4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48). For more information, see the [installation guide](guide-for-developers.md) and [system requirements](../get-started/system-requirements.md) for supported operating systems.|  
|The update corresponding to KB\<*number*> needs to be installed before you can install this product.|Installation of the .NET Framework requires that a KB update be installed before installing the .NET Framework. Install the update, and then begin the .NET Framework installation again.<br /><br /> For example, installation of updated versions of the .NET Framework on Windows 8.1, Windows RT 8.1, and Windows Server 2012 R2 requires that the update corresponding to [KB 2919355](https://support.microsoft.com/kb/2919355) be installed.|  
|Your computer is currently running a Server Core installation of the Windows Server 2008 operating system. The .NET Framework 4.5.x requires a later release of the operating system. Please install Windows Server 2008 R2 SP1 or higher and rerun .NET Framework 4.5.x setup.|The .NET Framework 4.5.1 and 4.5.2 are supported in the Server Core role with Windows Server 2008 R2 SP1 or later. See [System Requirements](../get-started/system-requirements.md).|  
|You do not have sufficient privileges to complete this operation for all users of this computer. Log on as an administrator and rerun **Setup**.|You must be an administrator on the computer to install the .NET Framework.|  
|Setup cannot continue because a previous installation requires your computer to be restarted. Please restart your computer and rerun Setup.|A restart is sometimes required to fully complete an installation. Follow the instructions to restart your computer and rerun Setup.<br /><br /> In rare cases, you may be asked to restart your system more than once if Windows has detected a number of missing updates and is restarting to install the next update in the queue.|  
|.NET Framework Setup cannot be run in Program Compatibility Mode.|See the [Program Compatibility Issues](#compat) section later in this article.|  
|.NET Framework 4.5.x/4.6.x/4.7.x/4.8 has not been installed because the component store has been corrupted.|See [Fix Windows Update errors by using the DISM or System Update Readiness tool](https://support.microsoft.com/kb/947821) for more information.|  
|Setup cannot run because the Windows Installer Service is not available on this computer.|See ["The Windows Installer Service Could Not Be Accessed" error when you try to install a program in Windows 7 or Windows Vista](https://support.microsoft.com/help/2642495/the-windows-installer-service-could-not-be-accessed-error-when-you-try) on the Microsoft Support website.|  
|Setup may not run properly because the Windows Update Service is not available on this computer.|The computer may be configured to use Windows Server Update Services (WSUS) instead of Microsoft Windows Update. For more information, see the section for error code 0x800F0906 in [.NET Framework 3.5 installation error: 0x800F0906, 0x800F081F, 0x800F0907](https://support.microsoft.com/help/2734782/net-framework-3-5-installation-error-0x800f0906-0x800f081f-0x800f0907).<br /><br /> Also see [How to update the Windows Update Agent to the latest version](https://support.microsoft.com/help/949104/how-to-update-the-windows-update-agent-to-the-latest-version) on the Microsoft Support website.|  
|Setup may not run properly because the Background Intelligent Transfer Service (BITS) is not available on this computer.|See [An update is available to fix a Background Intelligent Transfer Service (BITS) crash on a Windows Vista-based computer](https://support.microsoft.com/help/940520/an-update-is-available-to-fix-a-background-intelligent-transfer-servic) on the Microsoft Support website.|  
|Setup may not run properly because Windows update encountered an error and displayed error code 0x80070643 or 0x643.|See [.NET Framework update installation error: "0x80070643" or "0x643"](https://support.microsoft.com/kb/976982) on the Microsoft Support website.|  
|The .NET Framework 4.5.x/4.6.x/4.7.x/4.8 is already a part of this operating system. You do not need to install the .NET Framework 4.5.x/4.6.x/4.7.x/4.8 redistributable.|No action.<br /><br /> To determine which versions of the .NET Framework are installed on a system, see [How to: Determine Which .NET Framework Versions Are Installed](../migration-guide/how-to-determine-which-versions-are-installed.md). See [System Requirements](../get-started/system-requirements.md) for supported operating systems.|  
|The .NET Framework 4.5.x/4.6.x/4.7.x/4.8 is not supported on this operating system.|See [System Requirements](../get-started/system-requirements.md) for supported operating systems.<br /><br /> For failed installations of the .NET Framework on Windows 7, this message  typically indicates that Windows 7 SP1 is not installed. On Windows 7 systems, the .NET Framework requires Windows 7 SP1. If you are on Windows 7 and have not yet installed Service Pack 1, you will need to do so before installing the .NET Framework. For information on installing Windows 7 SP1, see [Learn how to install Windows 7 Service Pack 1 (SP1)](https://windows.microsoft.com/windows7/install-windows-7-service-pack-1).|  
|Your computer is currently running a Server Core installation of Windows Server 2008 operating system. The .NET Framework 4.5.x requires a full release of the operating system or Server Core 2008 R2 SP1. Please install the full version of Windows Server 2008 SP2 or Windows Server 2008 R2 SP1 or Server Core 2008 R2 SP1 and rerun .NET Framework 4.5.x Setup.|The .NET Framework is supported in the Server Core role with Windows Server 2008 R2 SP1 or later. See [System Requirements](../get-started/system-requirements.md).|  
|The .NET Framework 4.5.x is already a part of this operating system but is currently turned off (Windows Server 2012 only).| Use **Turn Windows features on or off** in the **Control Panel** to turn on .NET Framework 4.5.x. |  
|This setup program requires an x86 computer. It cannot be installed on x64 or IA64 computers.|See [System Requirements](../get-started/system-requirements.md).|  
|This setup program requires x64 or x86 computer. It cannot be installed on IA64 computers.|See [System Requirements](../get-started/system-requirements.md).|  

<a name="compat"></a>
### Program compatibility issues

The installation of the .NET Framework 4.5 or its point releases fails with a 1603 error code or blocks when it's running in Windows Program Compatibility mode. The **Program Compatibility Assistant** indicates that the .NET Framework might not have been installed correctly and prompts you to reinstall it by using the recommended setting (Program Compatibility mode). Program Compatibility mode could also have been set by the Program Compatibility Assistant on earlier failed or canceled attempts to run the .NET Framework Setup.

The .NET Framework installer cannot run in Program Compatibility mode. To resolve this blocking issue, you must use Registry Editor to ensure that the compatibility mode setting is not enabled system-wide:

1. Choose the **Start** button, and then choose **Run**.

1. In the **Run** dialog box, type "regedit", and then choose **OK**.

1. In Registry Editor, browse to the following subkeys:

   - HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Persisted

   - HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers

1. In the Name column, look for the .NET Framework 4.5, 4.5.1, 4.5.2, 4.6, 4.6.1, 4.6.2, 4.7, 4.7.1, or 4.7.2 download names, depending on which version you are installing, and delete these entries. For download names, see [Install the .NET Framework for developers](guide-for-developers.md) article.

1. Rerun the .NET Framework installer for version 4.5, 4.5.1, 4.5.2, or 4.6, 4.6.1, 4.6.2, 4.7, 4.7.1, or 4.7.2.

## See also

- [Install the .NET Framework for developers](guide-for-developers.md)
- [How to: Determine Which .NET Framework Versions Are Installed](../migration-guide/how-to-determine-which-versions-are-installed.md)
- [Versions and Dependencies](../migration-guide/versions-and-dependencies.md)

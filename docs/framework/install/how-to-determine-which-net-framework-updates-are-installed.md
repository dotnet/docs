---
title: See installed .NET Framework security updates and hotfixes
description: Learn how to determine which .NET Framework security updates and hotfixes are installed on a computer.
ms.date: 04/03/2024
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "updates, determining for .NET Framework"
  - ".NET Framework, determining updates"
ms.assetid: 53c7b5f7-d47a-402a-b194-7244a696a88b
---
# How to determine which .NET Framework security updates and hotfixes are installed

This article shows you how to find out which .NET Framework security updates and hotfixes are installed on a computer.

## Update history

To see which .NET Framework updates are installed on your own computer, in **Settings**, navigate to **Windows Update** > **Update history**. Look under the **Quality Updates** section for .NET Framework updates. For example, you might see an update similar to "2023-11 Cumulative Update for .NET Framework 3.5 and 4.8.1 for Windows 11, version 22H2 for x64 (KB5032007)".

## Registry

You can query the registry using [Registry Editor](#use-registry-editor), [code](#query-using-code), or [PowerShell](#query-using-powershell).

> [!NOTE]
> All the registry techniques require an account with administrative privileges.

### Use Registry Editor

The installed security updates and hotfixes for each version of the .NET Framework installed on a computer are listed in the Windows registry. You can use the Registry Editor (*regedit.exe*) program to view this information.

1. Open the program **regedit.exe**. In Windows 8 and later versions, right-click **Start** ![Screenshot of the Windows key logo.](./media/how-to-determine-which-net-framework-updates-are-installed/windows-keyboard-logo.png "Windowskeyboardlogo"), then select **Run**. In the **Open** box, enter **regedit** and select **OK**.

2. In the Registry Editor, open the following subkey:

     **HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Updates**

     The installed updates are listed under subkeys that identify the .NET Framework version they apply to. Each update is identified by a Knowledge Base (KB) number.

In the Registry Editor, the .NET Framework versions and installed updates for each version are stored in different subkeys. For information about detecting the installed version numbers, see [How to: Determine which .NET Framework versions are installed](how-to-determine-which-versions-are-installed.md).

### Query using code

The following example programmatically determines the .NET Framework security updates and hotfixes that are installed on a computer:

[!code-csharp[ListUpdates](../../../samples/snippets/csharp/VS_Snippets_CLR/listupdates/cs/program.cs)]
[!code-vb[ListUpdates](../../../samples/snippets/visualbasic/VS_Snippets_CLR/listupdates/vb/program.vb)]

The example produces an output that's similar to the following one:

```console
Microsoft .NET Framework 4 Client Profile
  KB2468871
  KB2468871v2
  KB2478063
  KB2533523
  KB2544514
  KB2600211
  KB2600217
Microsoft .NET Framework 4 Extended
  KB2468871
  KB2468871v2
  KB2478063
  KB2533523
  KB2544514
  KB2600211
  KB2600217
```

### Query using PowerShell

The following example shows how to determine the .NET Framework security updates and hotfixes that are installed on a computer using PowerShell:

```powershell
$DotNetVersions = Get-ChildItem HKLM:\SOFTWARE\WOW6432Node\Microsoft\Updates | Where-Object {$_.name -like
 "*.NET Framework*"}

ForEach($Version in $DotNetVersions){

   $Updates = Get-ChildItem $Version.PSPath
    $Version.PSChildName
    ForEach ($Update in $Updates){
       $Update.PSChildName
       }
}
```

The example produces an output that's similar to the following one:

```console
Microsoft .NET Framework 4 Client Profile
KB2468871
KB2468871v2
KB2478063
KB2533523
KB2544514
KB2600211
KB2600217
Microsoft .NET Framework 4 Extended
KB2468871
KB2468871v2
KB2478063
KB2533523
KB2544514
KB2600211
KB2600217
```

## See also

- [How to: Determine which .NET Framework versions are installed](how-to-determine-which-versions-are-installed.md)
- [Install the .NET Framework for developers](../install/guide-for-developers.md)
- [Versions and dependencies](versions-and-dependencies.md)

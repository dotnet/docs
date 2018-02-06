---
title: "How to: Determine which .NET Framework security updates and hotfixes are installed"
description: "Learn how to determine which .NET Framework security updates and hotfixes are installed on a computer."
ms.date: "11/27/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "updates, determining for .NET Framework"
  - ".NET Framework, determining updates"
ms.assetid: 53c7b5f7-d47a-402a-b194-7244a696a88b
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Determine which .NET Framework security updates and hotfixes are installed

This article shows you how to find out which .NET Framework security updates and hotfixes are installed on a computer.

> [!NOTE]
> All the techniques shown in this article require an account with administrative privileges.

## To find installed updates using the registry

The installed security updates and hotfixes for each version of the .NET Framework installed on a computer are listed in the Windows registry. You can use the Registry Editor (*regedit.exe*) program to view this information.

1. Open the program **regedit.exe**. In Windows 8 and later versions, right-click **Start** ![Windows logo](../get-started/media/windowskeyboardlogo.png "Windowskeyboardlogo"), then select **Run**. In the **Open** box, enter **regedit** and select **OK**.

2. In the Registry Editor, open the following subkey:

     `HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Updates`

     The installed updates are listed under subkeys that identify the .NET Framework version they apply to. Each update is identified by a Knowledge Base (KB) number.

In the Registry Editor, the .NET Framework versions and installed updates for each version are stored in different subkeys. For information about detecting the installed version numbers, see [How to: Determine which .NET Framework versions are installed](../../../docs/framework/migration-guide/how-to-determine-which-versions-are-installed.md).

## To find installed updates by querying the registry in code

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

## To find installed updates by querying the registry in PowerShell

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

[How to: Determine which .NET Framework versions are installed](../../../docs/framework/migration-guide/how-to-determine-which-versions-are-installed.md)  
[Install the .NET Framework for developers](../../../docs/framework/install/guide-for-developers.md)  
[Versions and dependencies](../../../docs/framework/migration-guide/versions-and-dependencies.md)

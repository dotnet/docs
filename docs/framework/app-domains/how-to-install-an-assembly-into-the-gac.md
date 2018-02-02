---
title: "How to: Install an Assembly into the Global Assembly Cache"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "assemblies [.NET Framework], global assembly cache"
  - "Gacutil.exe"
  - "strong-named assemblies, global assembly cache"
  - "global assembly cache, installing assemblies"
  - "Global Assembly Cache tool"
ms.assetid: a7e6f091-d02c-49ba-b736-7295cb0eb743
caps.latest.revision: 24
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Install an Assembly into the Global Assembly Cache
There are two ways to install a strong-named assembly into the global assembly cache (GAC):  
  
> [!IMPORTANT]
>  Only strong-named assemblies can be installed into the GAC. For information about how to create a strong-named assembly, see [How to: Sign an Assembly with a Strong Name](../../../docs/framework/app-domains/how-to-sign-an-assembly-with-a-strong-name.md).  
  
-   Using [Windows Installer](http://msdn.microsoft.com/library/windows/desktop/cc185688.aspx).  
  
     You do this in Visual Studio 2012 and Visual Studio 2013 by creating an InstallShield Limited Edition Project.  
  
     This is the recommended and most common way to add assemblies to the global assembly cache. The installer provides reference counting of assemblies in the global assembly cache, plus other benefits.  
  
-   Using the [Global Assembly Cache tool (Gacutil.exe)](../../../docs/framework/tools/gacutil-exe-gac-tool.md).  
  
     You can use Gacutil.exe to add strong-named assemblies to the global assembly cache and to view the contents of the global assembly cache.  
  
    > [!NOTE]
    >  Gacutil.exe is only for development purposes and should not be used to install production assemblies into the global assembly cache.  
  
> [!NOTE]
>  In earlier versions of the .NET Framework, the Shfusion.dll Windows shell extension enabled you to install assemblies by dragging them in File Explorer. Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], Shfusion.dll is obsolete.  
  
### To use the Global Assembly Cache tool (Gacutil.exe)  
  
1.  At the command prompt, type the following command:  
  
     **gacutil -i** \<*assembly name*>  
  
     In this command, *assembly name* is the name of the assembly to install in the global assembly cache.  
  
 The following example installs an assembly with the file name `hello.dll` into the global assembly cache.  
  
```  
gacutil -i hello.dll  
```  
  
 For more information, see [Global Assembly Cache tool (Gacutil.exe)](../../../docs/framework/tools/gacutil-exe-gac-tool.md).  
  
### To use an InstallShield Limited Edition Project  
  
1.  Add a setup and deployment package to your solution by opening the shortcut menu for your solution, and then choosing **Add**, **New Project**.  
  
2.  In the **Add New Project** dialog box, in the **Installed** folder, choose **Other Project Types**,  **Setup and Deployment**, **InstallShield Limited Edition**, and give your project a name. (If prompted, download, install, and activate InstallShield.)  
  
3.  Perform the general configuration of your setup and deployment project either by using the Project Assistant in **Solution Explorer**, or by choosing the substeps of the numbered steps in the **Solution Explorer**.Configure your setup as you would if you were not adding assemblies to the GAC.  
  
4.  To begin the process of adding an assembly to the GAC, choose **Files**, which is under the **Specify Application Data** step in **Solution Explorer**.  
  
5.  In the **Destination computer's folders** pane, open the shortcut menu for **Destination Computer**, and then choose **Show Predefined Folder**, **[GlobalAssemblyCache]**.  
  
6.  For each project in the solution that contains an assembly that you want to install in the global assembly cache:  
  
    1.  In the **Source computer's folders** pane, choose the project.  
  
    2.  In the **Destination computer's folders** pane, choose **[GlobalAssemblyCache]**.  
  
    3.  In the **Source computer's files** pane, choose **Primary output from** *<project_name>*.  
  
    4.  Drag the file in step c to the **Destination computer's files** pane (or use the **Copy** and **Paste** commands from the file's shortcut menu).  
  
## See Also  
 [Working with Assemblies and the Global Assembly Cache](../../../docs/framework/app-domains/working-with-assemblies-and-the-gac.md)  
 [How to: Remove an Assembly from the Global Assembly Cache](../../../docs/framework/app-domains/how-to-remove-an-assembly-from-the-gac.md)  
 [Gacutil.exe (Global Assembly Cache Tool)](../../../docs/framework/tools/gacutil-exe-gac-tool.md)  
 [How to: Sign an Assembly with a Strong Name](../../../docs/framework/app-domains/how-to-sign-an-assembly-with-a-strong-name.md)  
 [Windows Installer Deployment](http://msdn.microsoft.com/library/121be21b-b916-43e2-8f10-8b080516d2a0)

---
title: "How to: View the Contents of the Global Assembly Cache"
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
  - "global assembly cache, viewing contents"
  - "viewing assemblies in global assembly cache"
  - "Gacutil.exe"
  - "strong-named assemblies, global assembly cache"
  - "GAC (global assembly cache), viewing contents"
  - "list of assemblies in global assembly cache"
  - "Global Assembly Cache tool"
ms.assetid: c5f786a0-969b-4f14-9f02-e77c3384d9af
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: View the Contents of the Global Assembly Cache
Use the [Global Assembly Cache tool (Gacutil.exe)](../../../docs/framework/tools/gacutil-exe-gac-tool.md) to view the contents of the global assembly cache.  
  
### To view a list of the assemblies in the global assembly cache  
  
1.  At the [Visual Studio command prompt](../../../docs/framework/tools/developer-command-prompt-for-vs.md), type the following command:  
  
     **gacutil -l**   
     -or-  
    **gacutil /l**  
  
 In earlier versions of the .NET Framework, the [Shfusion.dll](http://msdn.microsoft.com/library/0d9464cf-ddba-4ca9-bbec-f678fb58f380) Windows shell extension enabled you to view the global assembly cache in File Explorer. Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], Shfusion.dll is obsolete.  
  
## See Also  
 [Working with Assemblies and the Global Assembly Cache](../../../docs/framework/app-domains/working-with-assemblies-and-the-gac.md)  
 [Gacutil.exe (Global Assembly Cache Tool)](../../../docs/framework/tools/gacutil-exe-gac-tool.md)

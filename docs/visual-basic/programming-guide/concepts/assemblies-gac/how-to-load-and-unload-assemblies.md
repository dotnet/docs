---
title: "How to: Load and Unload Assemblies (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
ms.assetid: bbc84236-04b6-4c1b-9672-52773f65a5dc
caps.latest.revision: 3
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Load and Unload Assemblies (Visual Basic)
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

The assemblies referenced by your program will automatically be loaded at build time, but it is also possible to load specific assemblies into the current application domain at runtime. For more information, see [How to: Load Assemblies into an Application Domain](../Topic/How%20to:%20Load%20Assemblies%20into%20an%20Application%20Domain.md).  
  
 There is no way to unload an individual assembly without unloading all of the application domains that contain it. Even if the assembly goes out of scope, the actual assembly file will remain loaded until all application domains that contain it are unloaded.  
  
 If you want to unload some assemblies but not others, consider creating a new application domain, executing the code inside that domain, and then unloading that application domain. For more information, see [How to: Unload an Application Domain](../Topic/How%20to:%20Unload%20an%20Application%20Domain.md).  
  
### To load an assembly into an application domain  
  
1.  Use one of the several load methods contained in the classes <xref:System.AppDomain> and <xref:System.Reflection>. For more information, see [How to: Load Assemblies into an Application Domain](../Topic/How%20to:%20Load%20Assemblies%20into%20an%20Application%20Domain.md).  
  
### To unload an application domain  
  
1.  There is no way to unload an individual assembly without unloading all of the application domains that contain it. Use the `Unload` method from <xref:System.AppDomain> to unload the application domains. For more information, see [How to: Unload an Application Domain](../Topic/How%20to:%20Unload%20an%20Application%20Domain.md).  
  
## See Also  
 [Visual Basic Programming Guide](../../../../visual-basic/programming-guide/index.md)   
 [Assemblies and the Global Assembly Cache (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/assemblies-and-the-global-assembly-cache-visual-basic.md)   
 [How to: Load Assemblies into an Application Domain](../Topic/How%20to:%20Load%20Assemblies%20into%20an%20Application%20Domain.md)
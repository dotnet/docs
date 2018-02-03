---
title: "How to: Load and Unload Assemblies (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bbc84236-04b6-4c1b-9672-52773f65a5dc
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Load and Unload Assemblies (Visual Basic)
The assemblies referenced by your program will automatically be loaded at build time, but it is also possible to load specific assemblies into the current application domain at runtime. For more information, see [How to: Load Assemblies into an Application Domain](../../../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md).  
  
 There is no way to unload an individual assembly without unloading all of the application domains that contain it. Even if the assembly goes out of scope, the actual assembly file will remain loaded until all application domains that contain it are unloaded.  
  
 If you want to unload some assemblies but not others, consider creating a new application domain, executing the code inside that domain, and then unloading that application domain. For more information, see [How to: Unload an Application Domain](../../../../framework/app-domains/how-to-unload-an-application-domain.md).  
  
### To load an assembly into an application domain  
  
1.  Use one of the several load methods contained in the classes <xref:System.AppDomain> and <xref:System.Reflection>. For more information, see [How to: Load Assemblies into an Application Domain](../../../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md).  
  
### To unload an application domain  
  
1.  There is no way to unload an individual assembly without unloading all of the application domains that contain it. Use the `Unload` method from <xref:System.AppDomain> to unload the application domains. For more information, see [How to: Unload an Application Domain](../../../../framework/app-domains/how-to-unload-an-application-domain.md).  
  
## See Also  
 [Programming Concepts](../../../../visual-basic/programming-guide/concepts/index.md)  
 [Assemblies and the Global Assembly Cache (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md)  
 [How to: Load Assemblies into an Application Domain](../../../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md)

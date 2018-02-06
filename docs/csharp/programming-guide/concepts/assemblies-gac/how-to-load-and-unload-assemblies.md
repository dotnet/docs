---
title: "How to: Load and Unload Assemblies (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 6a4f490f-3576-471f-9533-003737cad4a3
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Load and Unload Assemblies (C#)
The assemblies referenced by your program will automatically be loaded at build time, but it is also possible to load specific assemblies into the current application domain at runtime. For more information, see [How to: Load Assemblies into an Application Domain](../../../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md).  
  
 There is no way to unload an individual assembly without unloading all of the application domains that contain it. Even if the assembly goes out of scope, the actual assembly file will remain loaded until all application domains that contain it are unloaded.  
  
 If you want to unload some assemblies but not others, consider creating a new application domain, executing the code inside that domain, and then unloading that application domain. For more information, see [How to: Unload an Application Domain](../../../../framework/app-domains/how-to-unload-an-application-domain.md).  
  
### To load an assembly into an application domain  
  
1.  Use one of the several load methods contained in the classes <xref:System.AppDomain> and <xref:System.Reflection>. For more information, see [How to: Load Assemblies into an Application Domain](../../../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md).  
  
### To unload an application domain  
  
1.  There is no way to unload an individual assembly without unloading all of the application domains that contain it. Use the `Unload` method from <xref:System.AppDomain> to unload the application domains. For more information, see [How to: Unload an Application Domain](../../../../framework/app-domains/how-to-unload-an-application-domain.md).  
  
## See Also  
 [C# Programming Guide](../../../../csharp/programming-guide/index.md)  
 [Assemblies and the Global Assembly Cache (C#)](../../../../csharp/programming-guide/concepts/assemblies-gac/index.md)  
 [How to: Load Assemblies into an Application Domain](../../../../framework/app-domains/how-to-load-assemblies-into-an-application-domain.md)

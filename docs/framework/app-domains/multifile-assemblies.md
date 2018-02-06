---
title: "Multifile Assemblies"
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
  - "assemblies [.NET Framework], multifile"
  - "entry point for assembly"
  - "compiling assemblies"
  - "command-line compilers"
  - "assembly manifest, multifile assemblies"
  - "code modules"
  - "multifile assemblies"
ms.assetid: 13509e73-db77-4645-8165-aad8dfaedff6
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Multifile Assemblies
You can create multifile assemblies using command-line compilers or [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] with Visual C++. One file in the assembly must contain the assembly manifest. An assembly that starts an application must also contain an entry point, such as a Main or WinMain method.  
  
 For example, suppose you have an application that contains two code modules, Client.cs and Stringer.cs. Stringer.cs creates the `myStringer` namespace that is referenced by the code in Client.cs. Client.cs contains the `Main` method, which is the application's entry point. In this example, you compile the two code modules, and then create a third file that contains the assembly manifest, which launches the application. The assembly manifest references both the `Client` and `Stringer` modules.  
  
> [!NOTE]
>  Multifile assemblies can have only one entry point, even if the assembly has multiple code modules.  
  
 There are several reasons you might want to create a multifile assembly:  
  
-   To combine modules written in different languages. This is the most common reason for creating a multifile assembly.  
  
-   To optimize downloading an application by putting seldom-used types in a module that is downloaded only when needed.  
  
    > [!NOTE]
    >  If you are creating applications that will be downloaded using the `<object>` tag with Microsoft Internet Explorer, it is important that you create multifile assemblies. In this scenario, you create a file separate from your code modules that contains only the assembly manifest. Internet Explorer downloads the assembly manifest first, and then creates worker threads to download any additional modules or assemblies required. While the file containing the assembly manifest is being downloaded, Internet Explorer will be unresponsive to user input. The smaller the file containing the assembly manifest, the less time Internet Explorer will be unresponsive.  
  
-   To combine code modules written by several developers. Although each developer can compile each code module into an assembly, this can force some types to be exposed publicly that are not exposed if all modules are put into a multifile assembly.  
  
 Once you create the assembly, you can sign the file that contains the assembly manifest (and hence the assembly), or you can give the file (and the assembly) a strong name and put it in the global assembly cache.  
  
## See Also  
 [How to: Build a Multifile Assembly](../../../docs/framework/app-domains/how-to-build-a-multifile-assembly.md)  
 [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md)

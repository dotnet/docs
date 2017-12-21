---
title: "How to: Reference a Strong-Named Assembly"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "strong-named assemblies, compile-time references"
  - "compile-time assembly referencing"
  - "assemblies [.NET Framework], strong-named"
  - "assembly binding, strong-named"
ms.assetid: 4c6a406a-b5eb-44fa-b4ed-4e95bb95a813
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Reference a Strong-Named Assembly
The process for referencing types or resources in a strong-named assembly is usually transparent. You can make the reference either at compile time (early binding) or at run time.  
  
 A compile-time reference occurs when you indicate to the compiler that your assembly explicitly references another assembly. When you use compile-time referencing, the compiler automatically gets the public key of the targeted strong-named assembly and places it in the assembly reference of the assembly being compiled.  
  
> [!NOTE]
>  A strong-named assembly can only use types from other strong-named assemblies. Otherwise, the security of the strong-named assembly would be compromised.  
  
### To make a compile-time reference to a strong-named assembly  
  
1.  At the command prompt, type the following command:  
  
     \<*compiler command*> **/reference:**\<*assembly name*>  
  
     In this command, *compiler command* is the compiler command for the language you are using, and *assembly name* is the name of the strong-named assembly being referenced. You can also use other compiler options, such as the **/t:library** option for creating a library assembly.  
  
 The following example creates an assembly called `myAssembly.dll` that references a strong-named assembly called `myLibAssembly.dll` from a code module called `myAssembly.cs`.  
  
```  
csc /t:library myAssembly.cs /reference:myLibAssembly.dll  
```  
  
### To make a run-time reference to a strong-named assembly  
  
1.  When you make a run-time reference to a strong-named assembly (for example, by using the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType> method), you must use the display name of the referenced strong-named assembly. The syntax of a display name is as follows:  
  
     \<*assembly name*>**,** \<*version number*>**,** \<*culture*>**,** \<*public key token*>  
  
     For example:  
  
    ```  
    myDll, Version=1.1.0.0, Culture=en, PublicKeyToken=03689116d3a4ae33   
    ```  
  
     In this example, `PublicKeyToken` is the hexadecimal form of the public key token. If there is no culture value, use `Culture=neutral`.  
  
 The following code example shows how to use this information with the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method.  
  
 [!code-cpp[Assembly.Load1#3](../../../samples/snippets/cpp/VS_Snippets_CLR/Assembly.Load1/CPP/load2.cpp#3)]
 [!code-csharp[Assembly.Load1#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Assembly.Load1/CS/load2.cs#3)]
 [!code-vb[Assembly.Load1#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Assembly.Load1/VB/load2.vb#3)]  
  
 You can print the hexadecimal format of the public key and public key token for a specific assembly by using the following [Strong Name (Sn.exe)](../../../docs/framework/tools/sn-exe-strong-name-tool.md) command:  
  
 **sn -Tp \<** *assembly* **>**  
  
 If you have a public key file, you can use the following command instead (note the difference in case on the command-line option):  
  
 **sn -tp \<** *assembly* **>**  
  
## See Also  
 [Creating and Using Strong-Named Assemblies](../../../docs/framework/app-domains/create-and-use-strong-named-assemblies.md)

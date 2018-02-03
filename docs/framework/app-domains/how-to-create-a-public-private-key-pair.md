---
title: "How to: Create a Public-Private Key Pair"
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
  - "key pairs for strong-named assemblies"
  - "signing assemblies"
  - "assemblies [.NET Framework], signing"
  - "cryptographic key pairs"
  - "snk files (key pair files)"
  - "public-private key pairs"
  - ".snk files"
  - "strong-named assemblies, key pairs"
ms.assetid: 05026813-f3bd-4d7c-9e0b-fc588eb3d114
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Public-Private Key Pair
To sign an assembly with a strong name, you must have a public/private key pair. This public and private cryptographic key pair is used during compilation to create a strong-named assembly. You can create a key pair using the [Strong Name tool (Sn.exe)](../../../docs/framework/tools/sn-exe-strong-name-tool.md). Key pair files usually have an .snk extension.  
  
> [!NOTE]
>  In [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], the C# and Visual Basic project property pages include a **Signing** tab that enables you to select existing key files or to generate new key files without using Sn.exe. In Visual C++, you can specify the location of an existing key file in the **Advanced** property page in the **Linker** section of the **Configuration Properties** section of the **Property Pages** window. The use of the <xref:System.Reflection.AssemblyKeyFileAttribute> attribute to identify key file pairs has been made obsolete beginning with [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)].  
  
### To create a key pair  
  
1.  At the command prompt, type the following command:  
  
     **sn –k** \<*file name*>  
  
     In this command, *file name* is the name of the output file containing the key pair.  
  
 The following example creates a key pair called `sgKey.snk`.  
  
```  
sn -k sgKey.snk  
```  
  
 If you intend to delay sign an assembly and you control the whole key pair (which is unlikely outside test scenarios), you can use the following commands to generate a key pair and then extract the public key from it into a separate file. First, create the key pair:  
  
```  
sn -k keypair.snk  
```  
  
 Next, extract the public key from the key pair and copy it to a separate file:  
  
```  
sn -p keypair.snk public.snk  
```  
  
 Once you create the key pair, you must put the file where the strong name signing tools can find it.  
  
 When signing an assembly with a strong name, the [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md) looks for the key file relative to the current directory and to the output directory. When using command-line compilers, you can simply copy the key to the current directory containing your code modules.  
  
 If you are using an earlier version of [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] that does not have a **Signing** tab in the project properties, the recommended key file location is the project directory with the file attribute specified as follows:  
  
 [!code-cpp[AssemblyName_KeyPair#21](../../../samples/snippets/cpp/VS_Snippets_CLR/AssemblyName_KeyPair/CPP/keyfileattrib.cpp#21)]
 [!code-csharp[AssemblyName_KeyPair#21](../../../samples/snippets/csharp/VS_Snippets_CLR/AssemblyName_KeyPair/CS/keyfileattrib.cs#21)]
 [!code-vb[AssemblyName_KeyPair#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AssemblyName_KeyPair/VB/keyfileattrib.vb#21)]  
  
## See Also  
 [Creating and Using Strong-Named Assemblies](../../../docs/framework/app-domains/create-and-use-strong-named-assemblies.md)

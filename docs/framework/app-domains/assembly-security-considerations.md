---
title: "Assembly Security Considerations"
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
  - "assemblies [.NET Framework], security"
  - "signcodes"
  - "names [.NET Framework], assemblies"
  - "strong-named assemblies, security considerations"
  - "signing assemblies"
  - "assemblies [.NET Framework], signing"
  - "granting permissions, assemblies"
  - "assemblies [.NET Framework], strong-named"
  - "names [.NET Framework], strong names"
  - "permissions [.NET Framework], assemblies"
  - "security [.NET Framework], assemblies"
  - "integrity with assemblies"
ms.assetid: 1b5439c1-f3d5-4529-bd69-01814703d067
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Assembly Security Considerations
<a name="top"></a> When you build an assembly, you can specify a set of permissions that the assembly requires to run. Whether certain permissions are granted or not granted to an assembly is based on evidence.  
  
 There are two distinct ways evidence is used:  
  
-   The input evidence is merged with the evidence gathered by the loader to create a final set of evidence used for policy resolution. The methods that use this semantic include **Assembly.Load**, **Assembly.LoadFrom**, and **Activator.CreateInstance**.  
  
-   The input evidence is used unaltered as the final set of evidence used for policy resolution. The methods that use this semantic include **Assembly.Load(byte[])** and **AppDomain.DefineDynamicAssembly()**.  
  
 Optional permissions can be granted by the [security policy](../../../docs/framework/misc/code-access-security-basics.md) set on the computer where the assembly will run. If you want your code to handle all potential security exceptions, you can do one of the following:  
  
-   Insert a permission request for all the permissions your code must have, and handle up front the load-time failure that occurs if the permissions are not granted.  
  
-   Do not use a permission request to obtain permissions your code might need, but be prepared to handle security exceptions if permissions are not granted.  
  
    > [!NOTE]
    >  Security is a complex area, and you have many options to choose from. For more information, see [Key Security Concepts](../../../docs/standard/security/key-security-concepts.md).  
  
 At load time, the assembly's evidence is used as input to security policy. Security policy is established by the enterprise and the computer's administrator as well as by user policy settings, and determines the set of permissions that is granted to all managed code when executed. Security policy can be established for the publisher of the assembly (if it has a signing tool generated signature), for the Web site and zone (in Internet Explorer terms) the assembly was downloaded from, or for the assembly's strong name. For example, a computer's administrator can establish security policy that allows all code downloaded from a Web site and signed by a given software company to access a database on a computer, but does not grant access to write to the computer's disk.  
  
## Strong-Named Assemblies and Signing Tools  
 You can sign an assembly in two different but complementary ways: with a strong name or by using  [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md). Signing an assembly with a strong name adds public key encryption to the file containing the assembly manifest. Strong name signing helps to verify name uniqueness, prevent name spoofing, and provide callers with some identity when a reference is resolved.  
  
 However, no level of trust is associated with a strong name, which makes [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md) important. The two signing tools require a publisher to prove its identity to a third-party authority and obtain a certificate. This certificate is then embedded in your file and can be used by an administrator to decide whether to trust the code's authenticity.  
  
 You can give both a strong name and a digital signature created using [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md) to an assembly, or you can use either alone. The two signing tools can sign only one file at a time; for a multifile assembly, you sign the file that contains the assembly manifest. A strong name is stored in the file containing the assembly manifest, but a signature created using [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md) is stored in a reserved slot in the portable executable (PE) file containing the assembly manifest. Signing of an assembly using [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md) can be used (with or without a strong name) when you already have a trust hierarchy that relies on[SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md) generated signatures, or when your policy uses only the key portion and does not check a chain of trust.  
  
> [!NOTE]
>  When using both a strong name and a signing tool signature on an assembly, the strong name must be assigned first.  
  
 The common language runtime also performs a hash verification; the assembly manifest contains a list of all files that make up the assembly, including a hash of each file as it existed when the manifest was built. As each file is loaded, its contents are hashed and compared with the hash value stored in the manifest. If the two hashes do not match, the assembly fails to load.  
  
 Because strong naming and signing using [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md) guarantee integrity, you can base code access security policy on these two forms of assembly evidence. Strong naming and signing using [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md) guarantee integrity through digital signatures and certificates. All the technologies mentioned—hash verification, strong naming, and signing using [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md)—work together to ensure that the assembly has not been altered in any way.  
  
## See Also  
 [Strong-Named Assemblies](../../../docs/framework/app-domains/strong-named-assemblies.md)  
 [Assemblies in the Common Language Runtime](../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)  
 [SignTool.exe (Sign Tool)](../../../docs/framework/tools/signtool-exe.md)

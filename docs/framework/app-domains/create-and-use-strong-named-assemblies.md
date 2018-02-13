---
title: "Creating and Using Strong-Named Assemblies"
ms.date: "08/01/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-bcl"
ms.topic: "article"
helpviewer_keywords: 
  - "strong-name bypass feature"
  - "strong-named assemblies, about strong-named assemblies"
  - "strong-named assemblies"
  - "signing assemblies"
  - "assemblies [.NET Framework], signing"
  - "strong-named assemblies, scenarios"
  - "assemblies [.NET Framework], strong-named"
  - "strong-named assemblies, loading into trusted application domains"
  - "assembly binding, strong-named"
ms.assetid: ffbf6d9e-4a88-4a8a-9645-4ce0ee1ee5f9
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating and Using Strong-Named Assemblies
<a name="top"></a> A strong name consists of the assembly's identity—its simple text name, version number, and culture information (if provided)—plus a public key and a digital signature. It is generated from an assembly file using the corresponding private key. (The assembly file contains the assembly manifest, which contains the names and hashes of all the files that make up the assembly.)  
  
 A strong-named assembly can only use types from other strong-named assemblies. Otherwise, the integrity of the strong-named assembly would be compromised.  
  
 This overview contains the following sections:  
  
-   [Strong Name Scenario](#strong_name_scenario)  
  
-   [Bypassing Signature Verification of Trusted Assemblies](#bypassing_signature_verification)  
  
-   [Related Topics](#related_topics)  
  
<a name="strong_name_scenario"></a>   
## Strong Name Scenario  
 The following scenario outlines the process of signing an assembly with a strong name and later referencing it by that name.  
  
1.  Assembly A is created with a strong name using one of the following methods:  
  
    -   Using a development environment that supports creating strong names, such as [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)].  
  
    -   Creating a cryptographic key pair using the [Strong Name tool (Sn.exe)](../../../docs/framework/tools/sn-exe-strong-name-tool.md) and assigning that key pair to the assembly using either a command-line compiler or the [Assembly Linker (Al.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md). The Windows Software Development Kit (SDK) provides both Sn.exe and Al.exe.  
  
2.  The development environment or tool signs the hash of the file containing the assembly's manifest with the developer's private key. This digital signature is stored in the portable executable (PE) file that contains Assembly A's manifest.  
  
3.  Assembly B is a consumer of Assembly A. The reference section of Assembly B's manifest includes a token that represents Assembly A's public key. A token is a portion of the full public key and is used rather than the key itself to save space.  
  
4.  The common language runtime verifies the strong name signature when the assembly is placed in the global assembly cache. When binding by strong name at run time, the common language runtime compares the key stored in Assembly B's manifest with the key used to generate the strong name for Assembly A. If the .NET Framework security checks pass and the bind succeeds, Assembly B has a guarantee that Assembly A's bits have not been tampered with and that these bits actually come from the developers of Assembly A.  
  
> [!NOTE]
>  This scenario doesn't address trust issues. Assemblies can carry full Microsoft Authenticode signatures in addition to a strong name. Authenticode signatures include a certificate that establishes trust. It's important to note that strong names don't require code to be signed in this way. Strong names only provide a unique identity.  
  
 [Back to top](#top)  
  
<a name="bypassing_signature_verification"></a>   
## Bypassing Signature Verification of Trusted Assemblies  
 Starting with the [!INCLUDE[net_v35SP1_long](../../../includes/net-v35sp1-long-md.md)], strong-name signatures are not validated when an assembly is loaded into a full-trust application domain, such as the default application domain for the `MyComputer` zone. This is referred to as the strong-name bypass feature. In a full-trust environment, demands for <xref:System.Security.Permissions.StrongNameIdentityPermission> always succeed for signed, full-trust assemblies, regardless of their signature. The strong-name bypass feature avoids the unnecessary overhead of strong-name signature verification of full-trust assemblies in this situation, allowing the assemblies to load faster.  
  
 The bypass feature applies to any assembly that is signed with a strong name and that has the following characteristics:  
  
-   Fully trusted without <xref:System.Security.Policy.StrongName> evidence (for example, has `MyComputer` zone evidence).  
  
-   Loaded into a fully trusted <xref:System.AppDomain>.  
  
-   Loaded from a location under the <xref:System.AppDomainSetup.ApplicationBase%2A> property of that <xref:System.AppDomain>.  
  
-   Not delay-signed.  
  
 This feature can be disabled for individual applications or for a computer. See [How to: Disable the Strong-Name Bypass Feature](../../../docs/framework/app-domains/how-to-disable-the-strong-name-bypass-feature.md).  
  
 [Back to top](#top)  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How to: Create a Public-Private Key Pair](../../../docs/framework/app-domains/how-to-create-a-public-private-key-pair.md)|Describes how to create a cryptographic key pair for signing an assembly.|  
|[How to: Sign an Assembly with a Strong Name](../../../docs/framework/app-domains/how-to-sign-an-assembly-with-a-strong-name.md)|Describes how to create a strong-named assembly.|  
|[Enhanced Strong Naming](../../../docs/framework/app-domains/enhanced-strong-naming.md)|Describes enhancements to strong-names in the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)].|  
|[How to: Reference a Strong-Named Assembly](../../../docs/framework/app-domains/how-to-reference-a-strong-named-assembly.md)|Describes how to reference types or resources in a strong-named assembly at compile time or run time.|  
|[How to: Disable the Strong-Name Bypass Feature](../../../docs/framework/app-domains/how-to-disable-the-strong-name-bypass-feature.md)|Describes how to disable the feature that bypasses the validation of strong-name signatures. This feature can be disabled for all or for specific applications.|  
|[Creating Assemblies](../../../docs/framework/app-domains/create-assemblies.md)|Provides an overview of single-file and multifile assemblies.|  
|[How to Delay Sign an Assembly in Visual Studio](/visualstudio/ide/managing-assembly-and-manifest-signing#how-to-sign-an-assembly-in-visual-studio)|Explains how to sign an assembly with a strong name after the assembly has been created.|  
|[Sn.exe (Strong Name Tool)](../../../docs/framework/tools/sn-exe-strong-name-tool.md)|Describes the tool included in the .NET Framework that helps create assemblies with strong names. This tool provides options for key management, signature generation, and signature verification.|  
|[Al.exe (Assembly Linker)](../../../docs/framework/tools/al-exe-assembly-linker.md)|Describes the tool included in the .NET Framework that generates a file that has an assembly manifest from modules or resource files.|

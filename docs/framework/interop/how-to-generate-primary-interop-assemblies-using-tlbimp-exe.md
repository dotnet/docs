---
title: "How to: Generate Primary Interop Assemblies Using Tlbimp.exe"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "primary interop assemblies, generating"
  - "Tlbimp.exe"
  - "Type Library Importer"
ms.assetid: 5419011c-6e57-40f6-8c65-386db8f7a651
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Generate Primary Interop Assemblies Using Tlbimp.exe
There are two ways to generate a primary interop assembly:  
  
-   Using the [Type Library Importer (Tlbimp.exe)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md) provided by the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)].  
  
     The most straightforward way to produce primary interop assemblies is to use the [Tlbimp.exe (Type Library Importer)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md). Tlbimp.exe provides the following safeguards:  
  
    -   Checks for other registered primary interop assemblies before creating new interop assemblies for any nested type library references.  
  
    -   Fails to emit the primary interop assembly if you do not specify either the container or file name to give the primary interop assembly a strong name.  
  
    -   Fails to emit a primary interop assembly if you omit references to dependent assemblies.  
  
    -   Fails to emit a primary interop assembly if you add references to dependent assemblies that are not primary interop assemblies.  
  
-   Creating primary interop assemblies manually in source code by using a language that is compliant with the Common Language Specification (CLS), such as C#. This approach is useful when a type library is unavailable.  
  
 You must have a cryptographic key pair to sign the assembly with a strong name. For details, see [Creating A Key Pair](../../../docs/framework/app-domains/how-to-create-a-public-private-key-pair.md).  
  
### To generate a primary interop assembly using Tlbimp.exe  
  
1.  At the command prompt, type:  
  
     **tlbimp** *tlbfile*  **/primary /keyfile:** *filename* **/out:** *assemblyname*  
  
     In this command, *tlbfile* is the file containing the COM type library, *filename* is the name of the container or file that contains the key pair, and *assemblyname* is the name of the assembly to sign with a strong name.  
  
 Primary interop assemblies can reference only other primary interop assemblies. If your assembly references types from a third-party COM type library, you must obtain a primary interop assembly from the publisher before you can generate your primary interop assembly. If you are the publisher, you must generate a primary interop assembly for the dependent type library before generating the referencing primary interop assembly.  
  
 A dependent primary interop assembly with a version number that differs from that of the original type library is not discoverable when installed in the current directory. You must either register the dependent primary interop assembly in the Windows registry or use the **/reference** option to be sure that Tlbimp.exe finds the dependent DLL.  
  
 You can also wrap multiple versions of a type library. For instructions, see [How to: Wrap Multiple Versions of Type Libraries](https://msdn.microsoft.com/library/79eefe04-a770-4bc3-8ea2-e90ddb8ec31f(v=vs.100)).  
  
## Example  
 The following example imports the COM type library `LibUtil.tlb` and signs the assembly `LibUtil.dll` with a strong name using the key file `CompanyA.snk`. By omitting a specific namespace name, this example produces the default namespace, `LibUtil`.  
  
```  
tlbimp LibUtil.tlb /primary /keyfile:CompanyA.snk /out:LibUtil.dll  
```  
  
 For a more descriptive name (using the *VendorName*.*LibraryName* naming guideline), the following example overrides the default assembly file name and namespace name.  
  
```  
tlbimp LibUtil.tlb /primary /keyfile:CompanyA.snk /namespace:CompanyA.LibUtil /out:CompanyA.LibUtil.dll  
```  
  
 The following example imports `MyLib.tlb`, which references `CompanyA.LibUtil.dll`, and signs the assembly `CompanyB.MyLib.dll` with a strong name using the key file `CompanyB.snk`. The namespace, `CompanyB.MyLib`, overrides the default namespace name.  
  
```  
tlbimp MyLib.tlb /primary /keyfile:CompanyB.snk /namespace:CompanyB.MyLib /reference:CompanyA.LibUtil.dll /out:CompanyB.MyLib.dll  
```  
  
## See Also  
 [How to: Register Primary Interop Assemblies](../../../docs/framework/interop/how-to-register-primary-interop-assemblies.md)

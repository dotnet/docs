---
title: "How to: Generate Interop Assemblies from Type Libraries"
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
  - "importing type library"
  - "interop assemblies, generating"
  - "Type Library Importer"
  - "type libraries"
  - "COM interop, importing type library"
ms.assetid: 4afd40c3-68f2-41c5-8ec1-4951bc148b9c
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Generate Interop Assemblies from Type Libraries
The [Type Library Importer (Tlbimp.exe)](../../../docs/framework/tools/tlbimp-exe-type-library-importer.md) is a command-line tool that converts the coclasses and interfaces contained in a COM type library to metadata. This tool creates an interop assembly and namespace for the type information automatically. After the metadata of a class is available, managed clients can create instances of the COM type and call its methods, just as if it were a .NET instance. Tlbimp.exe converts an entire type library to metadata at once and cannot generate type information for a subset of the types defined in a type library.  
  
### To generate an interop assembly from a type library  
  
1.  Use the following command:  
  
     **tlbimp** \<*type-library-file*>  
  
     Adding the **/out:** switch produces an interop assembly with an altered name, such as LOANLib.dll. Altering the interop assembly name can help distinguish it from the original COM DLL and prevent problems that can occur from having duplicate names.  
  
## Example  
 The following command produces the Loanlib.dll assembly in the `Loanlib` namespace.  
  
```  
tlbimp Loanlib.dll  
```  
  
 The following command produces an interop assembly with an altered name (LOANLib.dll).  
  
```  
tlbimp LoanLib.dll /out: LOANLib.dll  
```  
  
## See Also  
 [Importing a Type Library as an Assembly](../../../docs/framework/interop/importing-a-type-library-as-an-assembly.md)  
 [Exposing COM Components to the .NET Framework](../../../docs/framework/interop/exposing-com-components.md)

---
title: "How to: Generate Interop Assemblies from Type Libraries"
description: Generate interop assemblies from type libraries. Use Type Library Importer (Tlbimp.exe) to convert coclasses and interfaces from a COM type library to metadata.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "importing type library"
  - "interop assemblies, generating"
  - "Type Library Importer"
  - "type libraries"
  - "COM interop, importing type library"
ms.assetid: 4afd40c3-68f2-41c5-8ec1-4951bc148b9c
---
# How to: Generate Interop Assemblies from Type Libraries

The [Type Library Importer (Tlbimp.exe)](../tools/tlbimp-exe-type-library-importer.md) is a command-line tool that converts the coclasses and interfaces contained in a COM type library to metadata. This tool creates an interop assembly and namespace for the type information automatically. After the metadata of a class is available, managed clients can create instances of the COM type and call its methods, just as if it were a .NET instance. Tlbimp.exe converts an entire type library to metadata at once and cannot generate type information for a subset of the types defined in a type library.  
  
### To generate an interop assembly from a type library  
  
1. Use the following command:  
  
     **tlbimp** \<*type-library-file*>  
  
     Adding the **/out:** switch produces an interop assembly with an altered name, such as LOANLib.dll. Altering the interop assembly name can help distinguish it from the original COM DLL and prevent problems that can occur from having duplicate names.  
  
## Example  

 The following command produces the Loanlib.dll assembly in the `Loanlib` namespace.  
  
```console  
tlbimp Loanlib.tlb  
```  
  
 The following command produces an interop assembly with an altered name (LOANLib.dll).  
  
```console  
tlbimp LoanLib.tlb /out: LOANLib.dll  
```  
  
## See also

- [Importing a Type Library as an Assembly](importing-a-type-library-as-an-assembly.md)
- [Exposing COM Components to the .NET Framework](exposing-com-components.md)

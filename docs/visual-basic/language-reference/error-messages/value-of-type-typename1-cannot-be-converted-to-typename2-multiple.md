---
title: "Value of type '<typename1>' cannot be converted to '<typename2>' (Multiple file references)"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc30961"
  - "bc30961"
helpviewer_keywords: 
  - "BC30961"
ms.assetid: 8be5aa0d-d236-4ac3-aa9c-5044f9f6562b
---
# Value of type '\<typename1>' cannot be converted to '\<typename2>' (Multiple file references)
Value of type '\<typename1>' cannot be converted to '\<typename2>'. Type mismatch could be due to mixing a file reference to '\<filepath1>' in project '\<projectname1>' with a file reference to '\<filepath2>' in project '\<projectname2>'. If both assemblies are identical, try replacing these references so both references are from the same location.  
  
 In a situation where a project makes more than one file reference to an assembly, the compiler cannot guarantee that one type can be converted to another.  
  
 Each file reference specifies a file path and name for the output file of a project (typically a DLL file). The compiler cannot guarantee that the output files come from the same source, or that they represent the same version of the same assembly. Therefore, it cannot guarantee that the types in the different references are the same type, or even that one can be converted to the other.  
  
 You can use a single file reference if you know that the referenced assemblies have the same assembly identity. The *assembly identity* includes the assembly's name, version, public key if any, and culture. This information uniquely identifies the assembly.  
  
 **Error ID:** BC30961  
  
## To correct this error  
  
-   If the referenced assemblies have the same assembly identity, then remove or replace one of the file references so that there is only a single file reference.  
  
-   If the referenced assemblies do not have the same assembly identity, then change your code so that it does not attempt to convert a type in one to a type in the other.  
  
## See also
- [Type Conversions in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)
- [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)


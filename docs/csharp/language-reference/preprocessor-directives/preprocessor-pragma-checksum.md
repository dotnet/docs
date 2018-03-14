---
title: "#pragma checksum (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "#pragma checksum"
helpviewer_keywords: 
  - "#pragma checksum [C#]"
ms.assetid: 3673e4ca-6098-4ec1-890f-8fceb2a794a2
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
---
# #pragma checksum (C# Reference)
Generates checksums for source files to aid with debugging [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] pages.  
  
## Syntax  
  
```csharp
#pragma checksum "filename" "{guid}" "checksum bytes"  
```  
  
#### Parameters  
 `"filename"`  
 The name of the file that requires monitoring for changes or updates.  
  
 `"{guid}"`  
 The Globally Unique Identifier (GUID) for the file.  
  
 `"checksum_bytes"`  
 The string of hexadecimal digits representing the bytes of the checksum. Must be an even number of hexadecimal digits. An odd number of digits results in a compile-time warning, and the directive are  ignored.  
  
## Remarks  
 The Visual Studio debugger uses a checksum to make sure  that it always finds the right source. The compiler computes the checksum for a source file, and then emits the output to the program database (PDB) file. The debugger then uses the PDB to compare against the checksum that it computes for the source file.  
  
 This solution does not work for [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] projects, because the computed checksum is for the generated source file, rather than the .aspx file. To address this problem, `#pragma checksum` provides checksum support for [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] pages.  
  
 When you create an [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] project in [!INCLUDE[csprcs](~/includes/csprcs-md.md)], the generated source file contains a checksum for the .aspx file, from which the source is generated. The compiler then writes this information into the PDB file.  
  
 If the compiler encounters no `#pragma checksum` directive in the file, it computes the checksum and writes the value to the PDB file.  
  
## Example  
  
```csharp
class TestClass  
{  
    static int Main()  
    {  
        #pragma checksum "file.cs" "{3673e4ca-6098-4ec1-890f-8fceb2a794a2}" "{012345678AB}" // New checksum  
    }  
}  
```  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)

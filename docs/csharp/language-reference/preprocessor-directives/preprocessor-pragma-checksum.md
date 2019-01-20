---
title: "#pragma checksum - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "#pragma checksum"
helpviewer_keywords: 
  - "#pragma checksum [C#]"
ms.assetid: 3673e4ca-6098-4ec1-890f-8fceb2a794a2
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
 The Globally Unique Identifier (GUID) for the hash algorithm.  
  
 `"checksum_bytes"`  
 The string of hexadecimal digits representing the bytes of the checksum. Must be an even number of hexadecimal digits. An odd number of digits results in a compile-time warning, and the directive are ignored.  
  
## Remarks  
 The Visual Studio debugger uses a checksum to make sure  that it always finds the right source. The compiler computes the checksum for a source file, and then emits the output to the program database (PDB) file. The debugger then uses the PDB to compare against the checksum that it computes for the source file.  
  
 This solution does not work for [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] projects, because the computed checksum is for the generated source file, rather than the .aspx file. To address this problem, `#pragma checksum` provides checksum support for [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] pages.  
  
 When you create an [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] project in Visual C#, the generated source file contains a checksum for the .aspx file, from which the source is generated. The compiler then writes this information into the PDB file.  
  
 If the compiler encounters no `#pragma checksum` directive in the file, it computes the checksum and writes the value to the PDB file.  
  
## Example  
  
```csharp
class TestClass  
{  
    static int Main()  
    {  
        #pragma checksum "file.cs" "{406EA660-64CF-4C82-B6F0-42D48172A799}" "ab007f1d23d9" // New checksum  
    }  
}  
```  
  
## See also

- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../../csharp/programming-guide/index.md)  
- [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)

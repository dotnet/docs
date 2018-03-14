---
title: "How to: Determine If a File Is an Assembly (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: de26f410-9bd1-4b55-a343-cc82f81684be
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Determine If a File Is an Assembly (Visual Basic)
A file is an assembly if and only if it is managed, and contains an assembly entry in its metadata. For more information on assemblies and metadata, see the topic [Assembly Manifest](../../../../framework/app-domains/assembly-manifest.md).  
  
## How to manually determine if a file is an assembly  
  
1.  Start the [Ildasm.exe (IL Disassembler)](https://msdn.microsoft.com/library/f7dy01k1).  
  
2.  Load the file you wish to test.  
  
3.  If **ILDASM** reports that the file is not a portable executable (PE) file, then it is not an assembly. For more information, see the topic [How to: View Assembly Contents](../../../../framework/app-domains/how-to-view-assembly-contents.md).  
  
## How to programmatically determine if a file is an assembly  
  
1.  Call the <xref:System.Reflection.AssemblyName.GetAssemblyName%2A> method, passing the full file path and name of the file you are testing.  
  
2.  If a <xref:System.BadImageFormatException> exception is thrown, the file is not an assembly.  
  
## Example  
 This example tests a DLL to see if it is an assembly.  
  
```vb  
Module Module1  
    Sub Main()  
        Try  
            Dim testAssembly As Reflection.AssemblyName =  
                                Reflection.AssemblyName.GetAssemblyName("C:\Windows\Microsoft.NET\Framework\v3.5\System.Net.dll")  
            Console.WriteLine("Yes, the file is an Assembly.")  
        Catch ex As System.IO.FileNotFoundException  
            Console.WriteLine("The file cannot be found.")  
        Catch ex As System.BadImageFormatException  
            Console.WriteLine("The file is not an Assembly.")  
        Catch ex As System.IO.FileLoadException  
            Console.WriteLine("The Assembly has already been loaded.")  
        End Try  
        Console.ReadLine()  
    End Sub  
End Module  
' Output (with .NET Framework 3.5 installed):  
'        Yes, the file is an Assembly.  
```
  
 The <xref:System.Reflection.AssemblyName.GetAssemblyName%2A> method loads the test file, and then releases it once the information is read.  
  
## See Also  
 <xref:System.Reflection.AssemblyName>  
 [Programming Concepts](../../../../visual-basic/programming-guide/concepts/index.md)  
 [Assemblies and the Global Assembly Cache (Visual Basic)](index.md)

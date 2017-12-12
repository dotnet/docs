---
title: "How to: Determine If a File Is an Assembly (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: ea5186bb-5bff-4dcb-bde9-d6ba4e2edd00
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Determine If a File Is an Assembly (C#)
A file is an assembly if and only if it is managed, and contains an assembly entry in its metadata. For more information on assemblies and metadata, see the topic [Assembly Manifest](../../../../../docs/framework/app-domains/assembly-manifest.md).  
  
### How to manually determine if a file is an assembly  
  
1.  Start the [Ildasm.exe (IL Disassembler)](https://msdn.microsoft.com/library/f7dy01k1).  
  
2.  Load the file you wish to test.  
  
3.  If **ILDASM** reports that the file is not a portable executable (PE) file, then it is not an assembly. For more information, see the topic [How to: View Assembly Contents](../../../../framework/app-domains/how-to-view-assembly-contents.md).  
  
### How to programmatically determine if a file is an assembly  
  
1.  Call the <xref:System.Reflection.AssemblyName.GetAssemblyName%2A> method, passing the full file path and name of the file you are testing.  
  
2.  If a <xref:System.BadImageFormatException> exception is thrown, the file is not an assembly.  
  
## Example  
 This example tests a DLL to see if it is an assembly.  
  
```  
class TestAssembly  
{  
    static void Main()  
    {  
  
        try  
        {  
            System.Reflection.AssemblyName testAssembly =  
                System.Reflection.AssemblyName.GetAssemblyName(@"C:\Windows\Microsoft.NET\Framework\v3.5\System.Net.dll");  
  
            System.Console.WriteLine("Yes, the file is an assembly.");  
        }  
  
        catch (System.IO.FileNotFoundException)  
        {  
            System.Console.WriteLine("The file cannot be found.");  
        }  
  
        catch (System.BadImageFormatException)  
        {  
            System.Console.WriteLine("The file is not an assembly.");  
        }  
  
        catch (System.IO.FileLoadException)  
        {  
            System.Console.WriteLine("The assembly has already been loaded.");  
        }  
    }  
}  
/* Output (with .NET Framework 3.5 installed):  
    Yes, the file is an assembly.  
*/  
```  
  
 The <xref:System.Reflection.AssemblyName.GetAssemblyName%2A> method loads the test file, and then releases it once the information is read.  
  
## See Also  
 <xref:System.Reflection.AssemblyName>  
 [C# Programming Guide](../../../../csharp/programming-guide/index.md)  
 [Assemblies and the Global Assembly Cache (C#)](../../../../csharp/programming-guide/concepts/assemblies-gac/index.md)

---
title: "How to: View Assembly Contents"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "assembly manifest, viewing information"
  - "Ildasm.exe"
  - "MSIL Disassembler"
  - "assemblies [.NET Framework], viewing contents"
  - "viewing assembly information"
  - "MSIL"
  - "viewing MSIL information"
ms.assetid: fb7baaab-4c0d-47ad-8fd3-4591cf834709
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: View Assembly Contents
You can use the [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md) to view Microsoft intermediate language (MSIL) information in a file. If the file being examined is an assembly, this information can include the assembly's attributes, as well as references to other modules and assemblies. This information can be helpful in determining whether a file is an assembly or part of an assembly, and whether the file has references to other modules or assemblies.  
  
### To display the contents of an assembly using Ildasm.exe  
  
1.  Type **ildasm** \<*assembly name*> at the command prompt. For example, the following command disassembles the `Hello.exe` assembly.  
  
    ```  
    ildasm Hello.exe  
    ```  
  
### To view assembly manifest information  
  
1.  Double-click the MANIFEST icon in the MSIL Disassembler window.  
  
## Example  
 The following example starts with a basic "Hello, World" program. After compiling the program, use Ildasm.exe to disassemble the Hello.exe assembly and view the assembly manifest.  
  
 [!code-cpp[Conceptual.Assembly.Contents#1](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.assembly.contents/cpp/source.cpp#1)]
 [!code-csharp[Conceptual.Assembly.Contents#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.assembly.contents/cs/source.cs#1)]
 [!code-vb[Conceptual.Assembly.Contents#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.assembly.contents/vb/source.vb#1)]  
  
 Running the command ildasm.exe on the Hello.exe assembly and double-clicking the MANIFEST icon in the IL DASM window produces the following output:  
  
```  
// Metadata version: v4.0.30319  
.assembly extern mscorlib  
{  
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..  
  .ver 4:0:0:0  
}  
.assembly Hello  
{  
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 )   
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx  
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.  
  .hash algorithm 0x00008004  
  .ver 0:0:0:0  
}  
.module Hello.exe  
// MVID: {7C2770DB-1594-438D-BAE5-98764C39CCCA}  
.imagebase 0x00400000  
.file alignment 0x00000200  
.stackreserve 0x00100000  
.subsystem 0x0003       // WINDOWS_CUI  
.corflags 0x00000001    //  ILONLY  
// Image base: 0x00600000  
```  
  
 The following table describes each directive in the assembly manifest of the Hello.exe assembly used in the example.  
  
|Directive|Description|  
|---------------|-----------------|  
|**.assembly extern \<** *assembly name* **>**|Specifies another assembly that contains items referenced by the current module (in this example, `mscorlib`).|  
|**.publickeytoken \<** *token* **>**|Specifies the token of the actual key of the referenced assembly.|  
|**.ver \<** *version number* **>**|Specifies the version number of the referenced assembly.|  
|**.assembly \<** *assembly name* **>**|Specifies the assembly name.|  
|**.hash algorithm \<** *int32 value* **>**|Specifies the hash algorithm used.|  
|**.ver \<** *version number* **>**|Specifies the version number of the assembly.|  
|**.module \<** *file name* **>**|Specifies the name of the modules that make up the assembly. In this example, the assembly consists of only one file.|  
|**.subsystem \<** *value* **>**|Specifies the application environment required for the program. In this example, the value 3 indicates that this executable is run from a console.|  
|**.corflags**|Currently a reserved field in the metadata.|  
  
 An assembly manifest can contain a number of different directives, depending on the contents of the assembly. For an extensive list of the directives in the assembly manifest, see the ECMA documentation, especially "Partition II: Metadata Definition and Semantics" and "Partition III: CIL Instruction Set". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](http://go.microsoft.com/fwlink/?LinkID=99212) on MSDN and [Standard ECMA-335 - Common Language Infrastructure (CLI)](http://go.microsoft.com/fwlink/?LinkID=65552) on the Ecma International Web site.  
  
## See Also  
 [Application Domains and Assemblies](http://msdn.microsoft.com/library/433b04ae-4ba8-4849-9dbd-79194f240346)  
 [Application Domains and Assemblies How-to Topics](../../../docs/framework/app-domains/application-domains-and-assemblies-how-to-topics.md)  
 [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md)

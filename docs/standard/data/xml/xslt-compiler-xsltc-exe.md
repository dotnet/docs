---
title: "XSLT Compiler (xsltc.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 672a5ac8-8305-4d28-ba10-11089c2c0924
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XSLT Compiler (xsltc.exe)
The XSLT compiler (xsltc.exe) compiles XSLT style sheets and generates an assembly. The compiled style sheet can then be passed directly into the <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Type%29?displayProperty=nameWithType> method. You cannot generate signed assemblies with xsltc.exe.  
  
 The xsltc.exe tool is included with Visual Studio. For more information, see the [Visual Studio Downloads](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs).  
  
## Syntax  
  
```  
xsltc [options] [/class:<name>] <sourceFile> [[/class:<name>] <sourceFile>...]  
```  
  
## Argument  
  
|Argument|Description|  
|--------------|-----------------|  
|`sourceFile`|Specifies the name of the style sheet. The style sheet must be a local file or be located on the intranet.|  
  
## Options  
  
|Option|Description|  
|------------|-----------------|  
|`/c[lass]:` `name`|Specifies the name of the class for the following style sheet. The class name can be fully qualified.<br /><br /> The class name defaults to the name of the style sheet. For example, if the style sheet customers.xsl is compiled, the default class name is customers.|  
|`/debug[`+&#124;-`]`|Specifies whether to generate debugging information.<br /><br /> Specifying `+` or `/debug`, causes the compiler to generate debugging information and put it in a program database (PDB) file. The name of the generated PDB file is `assemblyName`.pdb.<br /><br /> Specifying `-`, which is in effect if you do not specify `/debug`, causes no debug information to be created. A retail assembly is generated. **Note:**  Compiling in debug mode can affect XSLT performance significantly.|  
|`/help`|Displays command syntax and options for the tool.|  
|`/nologo`|Suppresses the compiler copyright message from displaying.|  
|`/platform:` `string`|Specifies the platforms that the assembly can be run on. The following describes the valid platform values:<br /><br /> `x86` compiles your assembly to be run by the 32-bit, x86-compatible common language runtime<br /><br /> `x64` compiles your assembly to be run by the 64-bit common language runtime on a computer that supports the AMD64 or EM64T instruction set.<br /><br /> [!INCLUDE[vcpritanium](../../../../includes/vcpritanium-md.md)] compiles your assembly to be run by the 64-bit common language runtime on a computer that has an [!INCLUDE[vcpritanium](../../../../includes/vcpritanium-md.md)] processor.<br /><br /> `anycpu` compiles your assembly to run on any platform. This is the default.|  
|`/out:` `assemblyName`|Specifies the name of the assembly that is output. The assembly name defaults to the name of the main style sheet or the first style sheet if multiple style sheets are present.<br /><br /> If the style sheet contains scripts, the scripts are saved to a separate assembly. Script assembly names are generated from the main assembly name. For example, if you specified CustOrders.dll for your assembly name, the first script assembly is named CustOrders_Script1.dll.|  
|`/settings:` `document+-, script+-, DTD+-,`|Specifies whether to allow `document()` functions, XSLT script, or document type definition (DTD) in the style sheet.<br /><br /> The default behavior disables support for DTD, the `document()` function and scripting.|  
|`@` `file`|Lets you specify a file that contains the compiler options.|  
|`?`|Displays command syntax and options for the tool.|  
  
## Remarks  
 XSLT solutions can consist of multiple style sheet modules. The xsltc.exe tool generates assemblies from style sheets. The assemblies can then be passed into the <xref:System.Xml.Xsl.XslCompiledTransform.Load%28System.Type%29?displayProperty=nameWithType> method. This can help decrease performance costs in some XSLT deployment scenarios.  
  
> [!NOTE]
>  You must also include the compiled assembly as a reference in your application.  
  
 The xsltc.exe tool does not validate the class (`/class:``name`) or assembly (`/out:``assemblyName`) names. Errors are thrown by the common language runtime if the names are not valid.  
  
## Examples  
 The following command compiles the style sheet and creates an assembly named booksort.dll.  
  
```  
xsltc booksort.xsl  
```  
  
 The following command compiles the style sheet and creates an assembly and PDB file that are named booksort.dll and booksort.pdb respectively.  
  
```  
xsltc booksort.xsl /debug  
```  
  
 The following command compiles a style sheet that contains an msxsl:script element and creates two assemblies named calc.dll and calc_Script1.dll.  
  
```  
xsltc /settings:script+ calc.xsl  
```  
  
 The following command enables DTD processing and script support and creates two assemblies named myTest.dll and myTest_Script1.dll.  
  
```  
xsltc /settings:DTD+,script+ /out:myTest calc.xsl  
```  
  
 The following command compiles two style sheet modules and creates a single assembly named booksort.dll.  
  
```  
xsltc booksort.xsl output.xsl  
```  
  
## See Also  
 <xref:System.Xml.Xsl.XslCompiledTransform>  
 [How to: Perform an XSLT Transformation by Using an Assembly](../../../../docs/standard/data/xml/how-to-perform-an-xslt-transformation-by-using-an-assembly.md)  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)

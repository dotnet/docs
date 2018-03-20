---
title: "-link (Visual Basic)"
ms.date: 03/10/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "l compiler option [Visual Basic]"
  - "EmbedInteropTypes"
  - "embed interop types [COM Interop]"
  - "-link compiler option [Visual Basic]"
  - "/link compiler option [Visual Basic]"
  - "link compiler option [Visual Basic]"
  - "-l compiler option [Visual Basic]"
  - "/l compiler option [Visual Basic]"
ms.assetid: 1885f24a-86f5-486c-a064-9fb7e455ccec
author: dotnet-bot
ms.author: dotnetcontent
---
# -link (Visual Basic)
Causes the compiler to make COM type information in the specified assemblies available to the project that you are currently compiling.  
  
## Syntax  
  
```  
-link:fileList  
' -or-  
-l:fileList  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`fileList`|Required. Comma-delimited list of assembly file names. If the file name contains a space, enclose the name in quotation marks.|  
  
## Remarks  
 The `-link` option enables you to deploy an application that has embedded type information. The application can then use types in a runtime assembly that implement the embedded type information without requiring a reference to the runtime assembly. If various versions of the runtime assembly are published, the application that contains the embedded type information can work with the various versions without having to be recompiled. For an example, see [Walkthrough: Embedding Types from Managed Assemblies](http://msdn.microsoft.com/library/b28ec92c-1867-4847-95c0-61adfe095e21).  
  
 Using the `-link` option is especially useful when you are working with COM interop. You can embed COM types so that your application no longer requires a primary interop assembly (PIA) on the target computer. The `-link` option instructs the compiler to embed the COM type information from the referenced interop assembly into the resulting compiled code. The COM type is identified by the CLSID (GUID) value. As a result, your application can run on a target computer that has installed the same COM types with the same CLSID values. Applications that automate Microsoft Office are a good example. Because applications like Office usually keep the same CLSID value across different versions, your application can use the referenced COM types as long as .NET Framework 4 or later is installed on the target computer and your application uses methods, properties, or events that are included in the referenced COM types.  
  
 The `-link` option embeds only interfaces, structures, and delegates. Embedding COM classes is not supported.  
  
> [!NOTE]
>  When you create an instance of an embedded COM type in your code, you must create the instance by using the appropriate interface. Attempting to create an instance of an embedded COM type by using the CoClass causes an error.  
  
 To set the `-link` option in [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)], add an assembly reference and set the `Embed Interop Types` property to **true**. The default for the `Embed Interop Types` property is **false**.  
  
 If you link to a COM assembly (Assembly A) which itself references another COM assembly (Assembly B), you also have to link to Assembly B if either of the following is true:  
  
-   A type from Assembly A inherits from a type or implements an interface from Assembly B.  
  
-   A field, property, event, or method that has a return type or parameter type from Assembly B is invoked.  
  
 Use [-libpath](../../../visual-basic/reference/command-line-compiler/libpath.md) to specify the directory in which one or more of your assembly references is located.  
  
 Like the [/reference](../../../visual-basic/reference/command-line-compiler/reference.md) compiler option, the `-link` compiler option uses the Vbc.rsp response file, which references frequently used [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assemblies. Use the [-noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md) compiler option if you do not want the compiler to use the Vbc.rsp file.  
  
 The short form of `-link` is `-l`.  
  
## Generics and Embedded Types  
 The following sections describe the limitations on using generic types in applications that embed interop types.  
  
### Generic Interfaces  
 Generic interfaces that are embedded from an interop assembly cannot be used. This is shown in the following example.  
  
 [!code-vb[VbLinkCompiler#1](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/link_1.vb)]  
  
### Types That Have Generic Parameters  
 Types that have a generic parameter whose type is embedded from an interop assembly cannot be used if that type is from an external assembly. This restriction does not apply to interfaces. For example, consider the <xref:Microsoft.Office.Interop.Excel.Range> interface that is defined in the <xref:Microsoft.Office.Interop.Excel> assembly. If a library embeds interop types from the <xref:Microsoft.Office.Interop.Excel> assembly and exposes a method that returns a generic type that has a parameter whose type is the <xref:Microsoft.Office.Interop.Excel.Range> interface, that method must return a generic interface, as shown in the following code example.  
  
 [!code-vb[VbLinkCompiler#2](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/link_2.vb)]  
[!code-vb[VbLinkCompiler#3](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/link_3.vb)]  
[!code-vb[VbLinkCompiler#4](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/link_4.vb)]  
  
 In the following example, client code can call the method that returns the <xref:System.Collections.IList> generic interface without error.  
  
 [!code-vb[VbLinkCompiler#5](../../../visual-basic/reference/command-line-compiler/codesnippet/VisualBasic/link_5.vb)]  
  
## Example  
 The following command line compiles source file `OfficeApp.vb` and reference assemblies from `COMData1.dll` and `COMData2.dll` to produce `OfficeApp.exe`.  
  
```console  
vbc -link:COMData1.dll,COMData2.dll /out:OfficeApp.exe OfficeApp.vb  
```  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [Walkthrough: Embedding Types from Managed Assemblies](http://msdn.microsoft.com/library/b28ec92c-1867-4847-95c0-61adfe095e21)  
 [-reference (Visual Basic)](../../../visual-basic/reference/command-line-compiler/reference.md)  
 [-noconfig](../../../visual-basic/reference/command-line-compiler/noconfig.md)  
 [-libpath](../../../visual-basic/reference/command-line-compiler/libpath.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Introduction to COM Interop](../../../visual-basic/programming-guide/com-interop/introduction-to-com-interop.md)

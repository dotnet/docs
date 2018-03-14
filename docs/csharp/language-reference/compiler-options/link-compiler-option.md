---
title: "-link (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "/l compiler option [C#]"
  - "/link compiler option [C#]"
  - "-l compiler option [C#]"
  - "EmbedInteropTypes"
  - "l compiler option [C#]"
  - "embed interop types [COM Interop]"
  - "-link compiler option [C#]"
  - "link compiler option [C#]"
ms.assetid: 00da70c6-9ea1-43c2-86f2-aa7f26c03475
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
---
# -link (C# Compiler Options)
Causes the compiler to make COM type information in the specified assemblies available to the project that you are currently compiling.  
  
## Syntax  
  
```console  
-link:fileList  
// -or-  
-l:fileList  
```  
  
## Arguments  
 `fileList`  
 Required. Comma-delimited list of assembly file names. If the file name contains a space, enclose the name in quotation marks.  
  
## Remarks  
 The `-link` option enables you to deploy an application that has embedded type information. The application can then use types in a runtime assembly that implement the embedded type information without requiring a reference to the runtime assembly. If various versions of the runtime assembly are published, the application that contains the embedded type information can work with the various versions without having to be recompiled. For an example, see [Walkthrough: Embedding Types from Managed Assemblies](../../programming-guide/concepts/assemblies-gac/walkthrough-embedding-types-from-managed-assemblies-in-visual-studio.md).  
  
 Using the `-link` option is especially useful when you are working with COM interop. You can embed COM types so that your application no longer requires a primary interop assembly (PIA) on the target computer. The `-link` option instructs the compiler to embed the COM type information from the referenced interop assembly into the resulting compiled code. The COM type is identified by the CLSID (GUID) value. As a result, your application can run on a target computer that has installed the same COM types with the same CLSID values. Applications that automate Microsoft Office are a good example. Because applications like Office usually keep the same CLSID value across different versions, your application can use the referenced COM types as long as .NET Framework 4 or later is installed on the target computer and your application uses methods, properties, or events that are included in the referenced COM types.  
  
 The `-link` option embeds only interfaces, structures, and delegates. Embedding COM classes is not supported.  
  
> [!NOTE]
>  When you create an instance of an embedded COM type in your code, you must create the instance by using the appropriate interface. Attempting to create an instance of an embedded COM type by using the CoClass causes an error.  
  
 To set the `-link` option in [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)], add an assembly reference and set the `Embed Interop Types` property to **true**. The default for the `Embed Interop Types` property is **false**.  
  
 If you link to a COM assembly (Assembly A) which itself references another COM assembly (Assembly B), you also have to link to Assembly B if either of the following is true:  
  
-   A type from Assembly A inherits from a type or implements an interface from Assembly B.  
  
-   A field, property, event, or method that has a return type or parameter type from Assembly B is invoked.  
  
 Like the [-reference](../../../csharp/language-reference/compiler-options/reference-compiler-option.md) compiler option, the `-link` compiler option uses the Csc.rsp response file, which references frequently used [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] assemblies. Use the [-noconfig](../../../csharp/language-reference/compiler-options/noconfig-compiler-option.md) compiler option if you do not want the compiler to use the Csc.rsp file.  
  
 The short form of `-link` is `-l`.  
  
## Generics and Embedded Types  
 The following sections describe the limitations on using generic types in applications that embed interop types.  
  
### Generic Interfaces  
 Generic interfaces that are embedded from an interop assembly cannot be used. This is shown in the following example.  
  
 [!code-csharp[VbLinkCompilerCS#1](../../../csharp/language-reference/compiler-options/codesnippet/CSharp/link-compiler-option_1.cs)]  
  
### Types That Have Generic Parameters  
 Types that have a generic parameter whose type is embedded from an interop assembly cannot be used if that type is from an external assembly. This restriction does not apply to interfaces. For example, consider the <xref:Microsoft.Office.Interop.Excel.Range> interface that is defined in the <xref:Microsoft.Office.Interop.Excel> assembly. If a library embeds interop types from the <xref:Microsoft.Office.Interop.Excel> assembly and exposes a method that returns a generic type that has a parameter whose type is the <xref:Microsoft.Office.Interop.Excel.Range> interface, that method must return a generic interface, as shown in the following code example.  
  
 [!code-csharp[VbLinkCompilerCS#2](../../../csharp/language-reference/compiler-options/codesnippet/CSharp/link-compiler-option_2.cs)]  
[!code-csharp[VbLinkCompilerCS#3](../../../csharp/language-reference/compiler-options/codesnippet/CSharp/link-compiler-option_3.cs)]  
[!code-csharp[VbLinkCompilerCS#4](../../../csharp/language-reference/compiler-options/codesnippet/CSharp/link-compiler-option_4.cs)]  
  
 In the following example, client code can call the method that returns the <xref:System.Collections.IList> generic interface without error.  
  
 [!code-csharp[VbLinkCompilerCS#5](../../../csharp/language-reference/compiler-options/codesnippet/CSharp/link-compiler-option_5.cs)]  
  
## Example  
 The following code compiles source file `OfficeApp.cs` and reference assemblies from `COMData1.dll` and `COMData2.dll` to produce `OfficeApp.exe`.  
  
```csharp  
csc -link:COMData1.dll,COMData2.dll -out:OfficeApp.exe OfficeApp.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Walkthrough: Embedding Types from Managed Assemblies](../../programming-guide/concepts/assemblies-gac/walkthrough-embedding-types-from-managed-assemblies-in-visual-studio.md)  
 [-reference (C# Compiler Options)](../../../csharp/language-reference/compiler-options/reference-compiler-option.md)  
 [-noconfig (C# Compiler Options)](../../../csharp/language-reference/compiler-options/noconfig-compiler-option.md)  
 [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md)  
 [Interoperability Overview](../../../csharp/programming-guide/interop/interoperability-overview.md)

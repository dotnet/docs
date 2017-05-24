---
title: "-linkresource (C# Compiler Options) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/linkresource"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/linkresource compiler option [C#]"
  - "linkres compiler option [C#]"
  - "/linkres compiler option [C#]"
  - "-linkres compiler option [C#]"
  - "-linkresource compiler option [C#]"
  - "linkresource compiler option [C#]"
ms.assetid: 440c26c2-77c1-4811-a0a3-57cce3f5fc96
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# /linkresource (C# Compiler Options)
Creates a link to a .NET Framework resource in the output file. The resource file is not added to the output file. This differs from the [/resource](../../../csharp/language-reference/compiler-options/resource-compiler-option.md) option which does embed a resource file in the output file.  
  
## Syntax  
  
```  
/linkresource:filename[,identifier[,accessibility-modifier]]  
```  
  
## Arguments  
 `filename`  
 The .NET Framework resource file to which you want to link from the assembly.  
  
 `identifier` (optional)  
 The logical name for the resource; the name that is used to load the resource. The default is the name of the file.  
  
 `accessibility-modifier` (optional)  
 The accessibility of the resource: public or private. The default is public.  
  
## Remarks  
 By default, linked resources are public in the assembly when they are created with the C# compiler. To make the resources private, specify `private` as the accessibility modifier. No other modifier other than `public` or `private` is allowed.  
  
 **/linkresource** requires one of the [/target](../../../csharp/language-reference/compiler-options/target-compiler-option.md) options other than **/target:module**.  
  
 If `filename` is a .NET Framework resource file created, for example, by [Resgen.exe](http://msdn.microsoft.com/library/8ef159de-b660-4bec-9213-c3fbc4d1c6f4) or in the development environment, it can be accessed with members in the <xref:System.Resources> namespace. For more information, see <xref:System.Resources.ResourceManager?displayProperty=fullName>. For all other resources, use the `GetManifestResource`* methods in the <xref:System.Reflection.Assembly> class to access the resource at run time.  
  
 The file specified in `filename` can be any format. For example, you may want to make a native DLL part of the assembly, so that it can be installed into the global assembly cache and accessed from managed code in the assembly. The second of the following examples shows how to do this. You can do the same thing in the Assembly Linker. The third of the following examples shows how to do this. For more information, see [Al.exe (Assembly Linker)](https://msdn.microsoft.com/library/c405shex) and [Working with Assemblies and the Global Assembly Cache](../../../framework/app-domains/working-with-assemblies-and-the-gac.md).  
  
 **/linkres** is the short form of **/linkresource**.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## Example  
 Compile `in.cs` and link to resource file `rf.resource`:  
  
```  
csc /linkresource:rf.resource in.cs  
```  
  
## Example  
 Compile `A.cs` into a DLL, link to a native DLL N.dll, and put the output in the Global Assembly Cache (GAC). In this example, both A.dll and N.dll will reside in the GAC.  
  
```  
csc /linkresource:N.dll /t:library A.cs  
gacutil -i A.dll  
```  
  
## Example  
 This example does the same thing as the previous one, but by using Assembly Linker options.  
  
```  
csc /t:module A.cs  
al /out:A.dll A.netmodule /link:N.dll   
gacutil -i A.dll  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [Al.exe (Assembly Linker)](https://msdn.microsoft.com/library/c405shex)   
 [Working with Assemblies and the Global Assembly Cache](../../../framework/app-domains/working-with-assemblies-and-the-gac.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)
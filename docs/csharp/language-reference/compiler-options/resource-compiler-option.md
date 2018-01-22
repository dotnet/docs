---
title: "-resource (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/resource"
helpviewer_keywords: 
  - "-resource compiler option [C#]"
  - "/resource compiler option [C#]"
  - "-res compiler option [C#]"
  - "/res compiler option [C#]"
  - "res compiler option [C#]"
  - "resource compiler option [C#]"
ms.assetid: 5212666e-98ab-47e4-a497-b5545ab15c7f
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# -resource (C# Compiler Options)
Embeds the specified resource into the output file.  
  
## Syntax  
  
```console  
-resource:filename[,identifier[,accessibility-modifier]]  
```  
  
## Arguments  
 `filename`  
 The .NET Framework resource file that you want to embed in the output file.  
  
 `identifier` (optional)  
 The logical name for the resource; the name that is used to load the resource. The default is the name of the file name.  
  
 `accessibility-modifier` (optional)  
 The accessibility of the resource: public or private. The default is public.  
  
## Remarks  
 Use [-linkresource](../../../csharp/language-reference/compiler-options/linkresource-compiler-option.md) to link a resource to an assembly and not add the resource file to the output file.  
  
 By default, resources are public in the assembly when they are created by using the C# compiler. To make the resources private, specify `private` as the accessibility modifier. No other accessibility other than `public` or `private` is allowed.  
  
 If `filename` is a .NET Framework resource file created, for example, by [Resgen.exe](../../../framework/tools/resgen-exe-resource-file-generator.md) or in the development environment, it can be accessed with members in the <xref:System.Resources> namespace. For more information, see <xref:System.Resources.ResourceManager?displayProperty=nameWithType>. For all other resources, use the `GetManifestResource` methods in the <xref:System.Reflection.Assembly> class to access the resource at run time.  
  
 **-res** is the short form of **-resource**.  
  
 The order of the resources in the output file is determined from the order specified on the command line.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Add a resource file to your project.  
  
2.  Select the file that you want to embed in **Solution Explorer**.  
  
3.  Select **Build Action** for the file in the **Properties** window.  
  
4.  Set **Build Action** to **Embedded Resource**.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.FileProperties2.BuildAction%2A>.  
  
## Example  
 Compile `in.cs` and attach resource file `rf.resource`:  
  
```console  
csc -resource:rf.resource in.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

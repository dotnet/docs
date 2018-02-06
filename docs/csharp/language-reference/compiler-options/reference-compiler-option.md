---
title: "-reference (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/reference"
helpviewer_keywords: 
  - "/r compiler option [C#]"
  - "reference compiler option [C#]"
  - "r compiler option [C#]"
  - "/reference compiler option [C#]"
  - "-r compiler option [C#]"
  - "metadata import [C#]"
  - "public type information [C#]"
  - "-reference compiler option [C#]"
ms.assetid: 8d13e5b0-abf6-4c46-bf71-2daf2cd0a6c4
caps.latest.revision: 28
author: "BillWagner"
ms.author: "wiwagn"
---
# -reference (C# Compiler Options)
The **-reference** option causes the compiler to import [public](../../../csharp/language-reference/keywords/public.md) type information in the specified file into the current project, thus enabling you to reference metadata from the specified assembly files.  
  
## Syntax  
  
```console  
-reference:[alias=]filename  
-reference:filename  
```  
  
## Arguments  
 `filename`  
 The name of a file that contains an assembly manifest. To import more than one file, include a separate **-reference** option for each file.  
  
 `alias`  
 A valid C# identifier that will represent a root namespace that will contain all namespaces in the assembly.  
  
## Remarks  
 To import from more than one file, include a **-reference** option for each file.  
  
 The files you import must contain a manifest; the output file must have been compiled with one of the [-target](../../../csharp/language-reference/compiler-options/target-compiler-option.md) options other than [-target:module](../../../csharp/language-reference/compiler-options/target-module-compiler-option.md).  
  
 **-r** is the short form of **-reference**.  
  
 Use [-addmodule](../../../csharp/language-reference/compiler-options/addmodule-compiler-option.md) to import metadata from an output file that does not contain an assembly manifest.  
  
 If you reference an assembly (Assembly A) that references another assembly (Assembly B), you will need to reference Assembly B if:  
  
-   A type you use from Assembly A inherits from a type or implements an interface from Assembly B.  
  
-   You invoke a field, property, event, or method that has a return type or parameter type from Assembly B.  
  
 Use [-lib](../../../csharp/language-reference/compiler-options/lib-compiler-option.md) to specify the directory in which one or more of your assembly references is located. The **-lib** topic also discusses the directories in which the compiler searches for assemblies.  
  
 In order for the compiler to recognize a type in an assembly, and not in a module, it needs to be forced to resolve the type, which you can do by defining an instance of the type. There are other ways to resolve type names in an assembly for the compiler: for example, if you inherit from a type in an assembly, the type name will then be recognized by the compiler.  
  
 Sometimes it is necessary to reference two different versions of the same component from within one assembly. To do this, use the alias suboption on the **-reference** switch for each file to distinguish between the two files. This alias will be used as a qualifier for the component name, and will resolve to the component in one of the files.  
  
 The csc response (.rsp) file, which references commonly used .NET Framework assemblies, is used by default. Use [-noconfig](../../../csharp/language-reference/compiler-options/noconfig-compiler-option.md) if you do not want the compiler to use csc.rsp.  
  
> [!NOTE]
> In Visual Studio, use the **Add Reference** dialog box. For more information, see [How to: Add or Remove References By Using the Reference Manager](/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager). To ensure equivalent behavior between adding references by using `-reference` and adding references by using the **Add Reference** dialog box, set the **Embed Interop Types** property to **False** for the assembly that you're adding. **True** is the default value for the property.  
  
## Example  
 This example shows how to use the [extern alias](../../../csharp/language-reference/keywords/extern-alias.md) feature.  
  
 You compile the source file and import metadata from `grid.dll` and `grid20.dll`,which have been compiled previously. The two DLLs contain separate versions of the same component, and you use two **-reference** with alias options to compile the source file. The options look like this:  
  
 -reference:GridV1=grid.dll and -reference:GridV2=grid20.dll  
  
 This sets up the external aliases "GridV1" and "GridV2," which you use in your program by means of an extern statement:  
  
```csharp  
extern alias GridV1;  
extern alias GridV2;  
// Using statements go here.  
```  
  
 Once this is done, you can refer to the grid control from grid.dll by prefixing the control name with GridV1, like this:  
  
```csharp  
GridV1::Grid  
```  
  
 In addition, you can refer to the grid control from grid20.dll by prefixing the control name with GridV2 like this:  
  
```csharp  
GridV2::Grid   
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

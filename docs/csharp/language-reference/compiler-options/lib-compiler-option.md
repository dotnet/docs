---
title: "-lib (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/lib"
helpviewer_keywords: 
  - "lib compiler option [C#]"
  - "-lib compiler option [C#]"
  - "/lib compiler option [C#]"
ms.assetid: b0efcc88-e8aa-4df4-a00b-8bdef70b7673
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# -lib (C# Compiler Options)
The **-lib** option specifies the location of assemblies referenced by means of the [-reference (C# Compiler Options)](../../../csharp/language-reference/compiler-options/reference-compiler-option.md) option.  
  
## Syntax  
  
```console  
-lib:dir1[,dir2]  
```  
  
## Arguments  
 `dir1`  
 A directory for the compiler to look in if a referenced assembly is not found in the current working directory (the directory from which you are invoking the compiler) or in the common language runtime's system directory.  
  
 `dir2`  
 One or more additional directories to search in for assembly references. Separate additional directory names with a comma, and without white space between them.  
  
## Remarks  
 The compiler searches for assembly references that are not fully qualified in the following order:  
  
1.  Current working directory. This is the directory from which the compiler is invoked.  
  
2.  The common language runtime system directory.  
  
3.  Directories specified by **-lib**.  
  
4.  Directories specified by the LIB environment variable.  
  
 Use **-reference** to specify an assembly reference.  
  
 **-lib** is additive; specifying it more than once appends to any prior values.  
  
 An alternative to using **-lib** is to copy into the working directory any required assemblies; this will allow you to simply pass the assembly name to **-reference**. You can then delete the assemblies from the working directory. Since the path to the dependent assembly is not specified in the assembly manifest, the application can be started on the target computer and will find and use the assembly in the global assembly cache.  
  
 Because the compiler can reference the assembly does not imply the common language runtime will be able to find and load the assembly at runtime. See [How the Runtime Locates Assemblies](../../../framework/deployment/how-the-runtime-locates-assemblies.md) for details on how the runtime searches for referenced assemblies.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Property Pages** dialog box.  
  
2.  Click the **References Path** property page.  
  
3.  Modify the contents of the list box.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.ReferencePath%2A>.  
  
## Example  
 Compile t2.cs to create an .exe file. The compiler will look in the working directory and in the root directory of the C drive for assembly references.  
  
```console  
csc -lib:c:\ -reference:t2.dll t2.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

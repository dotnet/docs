---
title: "-win32res (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/win32res"
helpviewer_keywords: 
  - "win32res compiler option"
  - "/win32res compiler option [C#]"
  - "-win32res compiler option [C#]"
  - "win32res compiler option [C#]"
ms.assetid: 3c33f750-6948-4c7e-a27e-bef98f77255b
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# -win32res (C# Compiler Options)
The **-win32res** option inserts a Win32 resource in the output file.  
  
## Syntax  
  
```console  
-win32res:filename  
```  
  
## Arguments  
 `filename`  
 The resource file that you want to add to your output file.  
  
## Remarks  
 A Win32 resource file can be created with the [Resource Compiler](../../language-reference/compiler-options/resource-compiler-option.md). The Resource Compiler is invoked when you compile a Visual C++ program; a .res file is created from the .rc file.  
  
 A Win32 resource can contain version or bitmap (icon) information that would help identify your application in the File Explorer. If you do not specify **-win32res**, the compiler will generate version information based on the assembly version.  
  
 See [-linkresource](../../../csharp/language-reference/compiler-options/linkresource-compiler-option.md) (to reference) or [-resource](../../../csharp/language-reference/compiler-options/resource-compiler-option.md) (to attach) a .NET Framework resource file.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Click on the **Resource File** button and choose a file by using the combo box.  
  
## Example  
 Compile `in.cs` and attach a Win32 resource file `rf.res` to produce `in.exe`:  
  
```console  
csc -win32res:rf.res in.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

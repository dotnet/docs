---
title: "-main (C# Compiler Options)"
ms.date: 07/20/2015
f1_keywords: 
  - "/main"
helpviewer_keywords: 
  - "-main compiler option [C#]"
  - "main compiler option [C#]"
  - "/main compiler option [C#]"
ms.assetid: 975cf4d5-36ac-4530-826c-4aad0c7f2049
---
# -main (C# Compiler Options)
This option specifies the class that contains the entry point to the program, if more than one class contains a **Main** method.  
  
## Syntax  
  
```console  
-main:class  
```  
  
## Arguments  
 `class`  
 The type that contains the **Main** method.  
 The provided class name must be fully qualified; it must include the full namespace containing the class, followed by the class name. For example, when the `Main` method is located inside the `Program` class in the `MyApplication.Core` namespace, the compiler option has to be `-main:MyApplication.Core.Program`.
  
## Remarks  
 If your compilation includes more than one type with a [Main](../../../csharp/programming-guide/main-and-command-args/index.md) method, you can specify which type contains the **Main** method that you want to use as the entry point into the program.  
  
 This option is for use when compiling an .exe file.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Modify the **Startup object** property.  
  
     To set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.StartupObject%2A>.  
  
## Example  
 Compile `t2.cs` and `t3.cs`, specifying that the **Main** method will be found in `Test2`:  
  
```console  
csc t2.cs t3.cs -main:Test2  
```  
  
## See also

- [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

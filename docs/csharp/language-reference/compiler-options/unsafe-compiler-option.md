---
title: "-unsafe (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/unsafe"
helpviewer_keywords: 
  - "-unsafe compiler option [C#]"
  - "unsafe compiler option [C#]"
  - "/unsafe compiler option [C#]"
ms.assetid: fdb77ed9-da03-45bd-bb7f-250704da1bcc
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# -unsafe (C# Compiler Options)
The **-unsafe** compiler option allows code that uses the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword to compile.  
  
## Syntax  
  
```console  
-unsafe  
```  
  
## Remarks  
 For more information about unsafe code, see [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md).  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Build** property page.  
  
3.  Select the **Allow Unsafe Code** check box.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.AllowUnsafeBlocks%2A>.  
  
## Example  
 Compile `in.cs` for unsafe mode:  
  
```console  
csc -unsafe in.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

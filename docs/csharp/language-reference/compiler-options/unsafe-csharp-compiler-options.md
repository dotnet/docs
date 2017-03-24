---
title: "-unsafe (C# Compiler Options) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "/unsafe"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "-unsafe compiler option [C#]"
  - "unsafe compiler option [C#]"
  - "/unsafe compiler option [C#]"
ms.assetid: fdb77ed9-da03-45bd-bb7f-250704da1bcc
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /unsafe (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The **/unsafe** compiler option allows code that uses the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword to compile.  
  
## Syntax  
  
```  
/unsafe  
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
  
```  
csc /unsafe in.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)
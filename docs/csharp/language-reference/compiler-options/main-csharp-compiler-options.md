---
title: "-main (C# Compiler Options) | Microsoft Docs"
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
  - "/main"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "-main compiler option [C#]"
  - "main compiler option [C#]"
  - "/main compiler option [C#]"
ms.assetid: 975cf4d5-36ac-4530-826c-4aad0c7f2049
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /main (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This option specifies the class that contains the entry point to the program, if more than one class contains a **Main** method.  
  
## Syntax  
  
```  
/main:class  
```  
  
## Arguments  
 `class`  
 The type that contains the **Main** method.  
  
## Remarks  
 If your compilation includes more than one type with a [Main](../../../csharp/programming-guide/main-and-command-args/main-and-command-line-arguments.md) method, you can specify which type contains the **Main** method that you want to use as the entry point into the program.  
  
 This option is for use when compiling an .exe file.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Modify the **Startup object** property.  
  
     To set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.StartupObject%2A>.  
  
## Example  
 Compile `t2.cs` and `t3.cs`, specifying that the **Main** method will be found in `Test2`:  
  
```  
csc t2.cs t3.cs /main:Test2  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)
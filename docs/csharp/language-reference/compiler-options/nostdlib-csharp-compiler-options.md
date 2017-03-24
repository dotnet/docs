---
title: "-nostdlib (C# Compiler Options) | Microsoft Docs"
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
  - "/nostdlib"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "nostdlib compiler option [C#]"
  - "-nostdlib compiler option [C#]"
  - "/nostdlib compiler option [C#]"
ms.assetid: ec197989-fa49-4725-a455-e06b551eb65f
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /nostdlib (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

**/nostdlib** prevents the import of mscorlib.dll, which defines the entire System namespace.  
  
## Syntax  
  
```  
/nostdlib[+ | -]  
```  
  
## Remarks  
 Use this option if you want to define or create your own System namespace and objects.  
  
 If you do not specify **/nostdlib**, mscorlib.dll will be imported into your program (same as specifying **/nostdlib-**). Specifying **/nostdlib** is the same as specifying **/nostdlib+**.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the **Properties** page for the project.  
  
2.  Click the **Build** properties page.  
  
3.  Click the **Advanced** button.  
  
4.  Modify the **Do not reference mscorlib.dll** property.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.NoStdLib%2A>.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
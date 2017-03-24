---
title: "-utf8output (C# Compiler Options) | Microsoft Docs"
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
  - "/utf8output"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "utf8output compiler option [C#]"
  - "/utf8output compiler option [C#]"
  - "-utf8output compiler option [C#]"
ms.assetid: 27ff7381-c281-45d7-b2eb-1ad644b1354e
caps.latest.revision: 10
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /utf8output (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The **/utf8output** option displays compiler output using UTF-8 encoding.  
  
## Syntax  
  
```  
/utf8output  
```  
  
## Remarks  
 In some international configurations, compiler output cannot correctly be displayed in the console. In these configurations, use **/utf8output** and redirect compiler output to a file.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
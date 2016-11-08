---
title: "Compiler Error CS1107 | Microsoft Docs"
ms.custom: ""
ms.date: "11/04/2016"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "CS1107"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1107"
ms.assetid: 1b6f6790-53af-4261-a14f-bf2db9790f0b
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Compiler Error CS1107
A parameter can only have one 'modifier name' modifier.  
  
 It is an error for parameter modifiers such as `this`, `ref`, and `out` to appear more than one time in a parameter definition.  
  
## Example  
 The following example generates CS1107:  
  
```  
// cs1107.cs  
public static class Test  
{  
    // Extension methods.  
        public static void TestMethod(this this t) {} // CS1107  
  
    // Regular Instance Method  
        public void TestMethod(ref ref int i) {} // CS1107  
  
}  
```
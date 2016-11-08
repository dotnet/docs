---
title: "Compiler Warning (level 1) CS1707 | Microsoft Docs"
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
  - "CS1707"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1707"
ms.assetid: 47b6096e-4e4b-4057-b9d7-4a096139267a
caps.latest.revision: 9
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
# Compiler Warning (level 1) CS1707
Delegate 'DelegateName' bound to 'MethodName1' instead of 'MethodName2' because of new language rules  
  
 C# 2.0 implements new rules for binding a delegate to a method. Additional information is considered that was not looked at in the past. This warning indicates that the delegate is now bound to a different overload of the method than it was previously bound to. You may wish to verify that the delegate really should be bound to 'MethodName1' instead of 'MethodName2'.  
  
 For a description of how the compiler determines which method to bind a delegate to, see [Using Variance in Delegates](../Topic/Using%20Variance%20in%20Delegates%20\(C%23%20and%20Visual%20Basic\).md).
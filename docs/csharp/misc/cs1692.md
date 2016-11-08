---
title: "Compiler Warning (level 1) CS1692 | Microsoft Docs"
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
  - "CS1692"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1692"
ms.assetid: 1a6d52e1-0ebb-4990-ac0b-36b05a884a19
caps.latest.revision: 10
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
# Compiler Warning (level 1) CS1692
Invalid number  
  
 A number of preprocessor directives, such as `#pragma` and `#line`, use numbers as parameters. One of these numbers is invalid because it is too big, in the wrong format, contains illegal characters, and so on. To correct this error, correct the number.  
  
## Example  
 The following example generates CS1692.  
  
```  
// CS1692.cs  
  
#pragma warning disable a  // CS1692  
// Try this instad:  
// #pragma warning disable 1691  
  
class A  
{  
    static void Main()  
    {  
    }  
}  
```
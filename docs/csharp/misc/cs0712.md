---
title: "Compiler Error CS0712 | Microsoft Docs"
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
  - "CS0712"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0712"
ms.assetid: cde64c0c-3953-4563-8c24-8b646230bbb8
caps.latest.revision: 7
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
# Compiler Error CS0712
Cannot create an instance of the static class 'static class'  
  
 It is not possible to create instances of static classes. Static classes are designed to contain static fields and methods, but may not be instantiated.  
  
## Example  
 The following sample generates CS0712:  
  
```  
// CS0712.cs  
public static class SC  
{  
}  
  
public class CMain  
{  
    public static void Main()  
    {  
        SC sc = new SC();  // CS0712  
    }  
}  
```
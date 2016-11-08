---
title: "Compiler Error CS0641 | Microsoft Docs"
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
  - "CS0641"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0641"
ms.assetid: 5bcdb11a-fefd-4c71-9b31-4c4f719633f3
caps.latest.revision: 6
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
# Compiler Error CS0641
'attribute' : attribute is only valid on classes derived from System.Attribute  
  
 An attribute was used that can only be used on a class that derives from **System.Attribute**.  
  
 The following sample generates CS0641:  
  
```  
// CS0641.cs  
using System;  
  
[AttributeUsage(AttributeTargets.All)]  
public class NonAttrClass   // CS0641  
// try the following line instead  
// public class NonAttrClass : Attribute  
{  
}  
  
class MyClass  
{  
   public static void Main()  
   {  
   }  
}  
```
---
title: "Compiler Error CS1706 | Microsoft Docs"
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
  - "CS1706"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1706"
ms.assetid: 8c589a49-3959-422e-ac18-65a2eaae3da0
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
# Compiler Error CS1706
Expression cannot contain anonymous methods  or lambda expressions  
  
 You cannot insert an anonymous method inside an expression.  
  
### To correct this error  
  
1.  Use a regular `delegate` in the expression.  
  
## Example  
 The following example generates CS1706.  
  
```  
// CS1706.cs  
using System;  
  
delegate void MyDelegate();  
class MyAttribute : Attribute  
{  
    public MyAttribute(MyDelegate d) { }  
}  
  
// Anonymous Method in Attribute declaration is not allowed.  
[MyAttribute(delegate{/* anonymous Method in Attribute declaration */})]  // CS1706  
class Program  
{  
}  
```
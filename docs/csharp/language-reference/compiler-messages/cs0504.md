---
title: "Compiler Error CS0504 | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "error-reference"
f1_keywords: 
  - "CS0504"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0504"
ms.assetid: f2486ffd-aa85-4b40-a89c-a32530b85d1f
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Compiler Error CS0504
The constant 'variable' cannot be marked static  
  
 If a variable is [const](../../../csharp/language-reference/keywords/const.md), it is also [static](../../../csharp/language-reference/keywords/static.md). If you want a **const** and **static** variable, just declare that variable as **const**; if all you want is a **static** variable, just mark it **static**.  
  
 The following sample generates CS0504:  
  
```  
// CS0504.cs  
namespace x  
{  
   abstract public class clx  
   {  
      static const int i = 0;   // CS0504, cannot be both static and const  
      abstract public void f();  
   }  
}  
```
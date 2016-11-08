---
title: "Compiler Error CS0283 | Microsoft Docs"
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
  - "CS0283"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0283"
ms.assetid: f94a5b84-92c5-4602-894d-6f856d57e0e6
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
# Compiler Error CS0283
The type 'type' cannot be declared const  
  
 The type specified in a constant declaration must be `byte`, `char`, `short`, `int`, `long`, `float`, `double`, `decimal`, `bool`, `string`, an enum-type, or a reference type that is assigned a value of null. Each constant-expression must yield a value of the target type or of a type that can be converted to the target type by implicit conversion.  
  
## Example  
 The following example generates CS0283.  
  
```  
// CS0283.cs  
struct MyTest  
{  
}  
class MyClass   
{  
    // To resolve the error but retain the "const-ness",  
    // change const to readonly.  
    const MyTest test = new MyTest();   // CS0283  
  
    public static int Main() {  
        return 1;  
    }  
}  
```
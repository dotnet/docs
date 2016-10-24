---
title: "Compiler Error CS0115"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "error-reference"
f1_keywords: 
  - "CS0115"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0115"
ms.assetid: a0e4bd8a-a6c2-4568-8ea5-8bb1d2ad0e95
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# Compiler Error CS0115
'function' : no suitable method found to override  
  
 A method was marked as an override, but the compiler found no method to override. For more information, see [override](../keywords/override--csharp-reference-.md), and [Knowing When to Use Override and New Keywords](../classes-and-structs/knowing-when-to-use-override-and-new-keywords--csharp-programming-guide-.md).  
  
## Example  
 The following sample generates CS0115. You can resolve CS0115 in one of two ways:  
  
-   Remove the `override` keyword from the method in `MyClass2`.  
  
-   Use `MyClass1` as a base class for `MyClass2`.  
  
```  
// CS0115.cs  
namespace MyNamespace  
{  
    abstract public class MyClass1  
    {  
        public abstract int f();  
    }  
  
    abstract public class MyClass2  
    {  
        public override int f()   // CS0115  
        {  
            return 0;  
        }  
  
        public static void Main()  
        {  
        }  
    }  
}  
```
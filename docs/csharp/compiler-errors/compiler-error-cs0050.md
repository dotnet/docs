---
title: "Compiler Error CS0050"
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
  - "CS0050"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0050"
ms.assetid: dead2d28-f4db-4afe-b8dd-38968625f7c3
caps.latest.revision: 10
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
# Compiler Error CS0050
Inconsistent accessibility: return type 'type' is less accessible than method 'method'  
  
 The return type and each of the types referenced in the formal parameter list of a method must be at least as accessible as the method itself. For more information, see [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md).  
  
## Example  
 The following sample generates CS0050 because no accessiblity modifier is supplied for `MyClass` and its accessibility therefore defaults to `private`.  
  
```  
// CS0050.cs  
class MyClass //accessibility defaults to private  
// try the following line instead  
// public class MyClass   
{  
}  
  
public class MyClass2  
{  
    public static MyClass MyMethod()   // CS0050  
    {  
        return new MyClass();  
    }  
  
    public static void Main() { }  
}  
```
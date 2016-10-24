---
title: "Compiler Error CS0038"
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
  - "CS0038"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0038"
ms.assetid: ed378c79-c31b-4373-adfa-ee5dd2dccc9e
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
# Compiler Error CS0038
Cannot access a nonstatic member of outer type 'type1' via nested type 'type2'  
  
 A field in a class is not automatically available to a nested class. To be available to a nested class, the field must be [static](../keywords/static--csharp-reference-.md). Otherwise, you must create an instance of the outer class. For more information, see [Nested Types](../classes-and-structs/nested-types--csharp-programming-guide-.md).  
  
 The following sample generates CS0038:  
  
```  
// CS0038.cs  
class OuterClass  
{  
   public int count;  
   // try the following line instead  
   // public static int count;  
  
   class InnerClass  
   {  
      void func()  
      {  
         // or, create an instance  
         // OuterClass class_inst = new OuterClass();  
         // int count2 = class_inst.count;  
         int count2 = count;   // CS0038  
      }  
   }  
  
   public static void Main()  
   {  
   }  
}  
```
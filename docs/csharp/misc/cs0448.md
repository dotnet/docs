---
title: "Compiler Error CS0448 | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "CS0448"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0448"
ms.assetid: f577ab4c-1c8c-4a10-80a8-9ba9f66c3d25
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"

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
# Compiler Error CS0448
The return type for ++ or -- operator must be the containing type or derived from the containing type  
  
 When you override the `++` or `--` operators, they must return the same type as the containing type, or return a type that is derived from the containing type.  
  
## Example  
 The following sample generates CS0448.  
  
```  
// CS0448.cs  
class C5  
{  
   public static int operator ++(C5 c) { return null; }   // CS0448  
   public static C5 operator --(C5 c) { return null; }   // OK  
   public static void Main() {}  
}  
```  
  
## Example  
 The following sample generates CS0448.  
  
```  
// CS0448_b.cs  
public struct S  
{  
   public static S? operator ++(S s) { return new S(); }   // CS0448  
   public static S? operator --(S s) { return new S(); }   // CS0448  
}  
  
public struct T  
{  
// OK  
   public static T operator --(T t) { return new T(); }  
   public static T operator ++(T t) { return new T(); }  
  
   public static T? operator --(T? t) { return new T(); }  
   public static T? operator ++(T? t) { return new T(); }  
  
   public static void Main() {}  
}  
```
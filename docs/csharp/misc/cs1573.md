---
title: "Compiler Warning (level 4) CS1573 | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "CS1573"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1573"
ms.assetid: 1b68cb1a-9bfd-4343-b9b6-8ce195af5e23
caps.latest.revision: 8
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
# Compiler Warning (level 4) CS1573
Parameter 'parameter' has no matching param tag in the XML comment for 'parameter' (but other parameters do)  
  
 When using the [/doc](../../csharp/language-reference/compiler-options/doc-compiler-option.md) compiler option, a comment was specified for some but not all parameters in a method. You may have forgotten to enter a comment for these parameters.  
  
 The following sample generates CS1573:  
  
```  
// CS1573.cs  
// compile with: /W:4  
public class MyClass  
{  
   /// <param name='Int1'>Used to indicate status.</param>  
   // enter a comment for Char1?  
   public static void MyMethod(int Int1, char Char1)  
   {  
   }  
  
   public static void Main ()  
   {  
   }  
}  
```
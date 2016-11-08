---
title: "Compiler Error CS0619 | Microsoft Docs"
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
  - "CS0619"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0619"
ms.assetid: a2060eb1-cda5-493c-b049-9b1792f88207
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
# Compiler Error CS0619
'member' is obsolete: 'text'  
  
 A class member was marked with the [Obsolete](http://msdn.microsoft.com/en-us/05e99cd0-bda6-4f79-a890-1ca093b4b488) attribute, such that an error will be issued when the class member is referenced.  
  
 The following sample generates CS0619:  
  
```  
// CS0619.cs  
using System;  
  
public class C  
{  
   [Obsolete("Use newMethod instead", true)]   // generates an error on use  
   public static void m()  
   {  
   }  
  
   // this is the method you should be using  
   public static void newMethod()  
   {  
   }  
}  
  
class MyClass  
{  
   public static void Main()  
   {  
      C.m();   // CS0619  
   }  
}  
```
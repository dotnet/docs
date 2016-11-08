---
title: "Compiler Error CS0406 | Microsoft Docs"
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
  - "CS0406"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0406"
ms.assetid: 9d69681c-e261-4e5e-9361-ea566de12f2e
caps.latest.revision: 9
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
# Compiler Error CS0406
The class type constraint 'constraint' must come before any other constraints  
  
 When a generic type or method has a class type constraint, that constraint must be listed first. To avoid this error, move the class type constraint to the beginning of the constraint list.  
  
## Example  
 The following sample generates CS0406.  
  
```  
// CS0406.cs  
// compile with: /target:library  
interface I {}  
class C {}  
class D<T> where T : I, C {}   // CS0406  
class D2<T> where T : C, I {}   // OK  
```
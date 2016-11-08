---
title: "Compiler Warning (level 1) CS0684 | Microsoft Docs"
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
  - "CS0684"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0684"
ms.assetid: d6c8aaf6-c1cf-4c0e-b367-4c3e418d8bc4
caps.latest.revision: 6
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
# Compiler Warning (level 1) CS0684
'interface' interface marked with 'CoClassAttribute' not marked with 'ComImportAttribute'  
  
 If you specify **CoClassAttribute** on an interface, you must also specify **ComImportAttribute**.  
  
 The following sample generates CS0684:  
  
```  
// CS0684.cs  
// compile with: /W:1  
using System;  
using System.Runtime.InteropServices;  
  
[CoClass(typeof(C))] // CS0684  
// try the following line instead  
// [CoClass(typeof(C)), ComImport]  
interface I  
{  
}  
  
class C  
{  
   static void Main() {}  
}  
```
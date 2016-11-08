---
title: "Compiler Error CS0625 | Microsoft Docs"
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
  - "CS0625"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0625"
ms.assetid: 44091813-9988-436c-b35e-e24094793782
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
# Compiler Error CS0625
'field': instance field types marked with StructLayout(LayoutKind.Explicit) must have a FieldOffset attribute  
  
 When a struct is marked with an explicit **StructLayout** attribute, all fields in the struct must have the [FieldOffset](frlrfsystemruntimeinteropservicesfieldoffsetattributeclasstopic) attribute. For more information, see [StructLayoutAttribute Class](frlrfSystemRuntimeInteropServicesStructLayoutAttributeClassTopic).  
  
 The following sample generates CS0625:  
  
```  
// CS0625.cs  
// compile with: /target:library  
using System;  
using System.Runtime.InteropServices;  
  
[StructLayout(LayoutKind.Explicit)]  
struct A  
{  
   public int i;   // CS0625 not static; an instance field  
}  
  
// OK  
[StructLayout(LayoutKind.Explicit)]  
struct B  
{  
   [FieldOffset(5)]  
   public int i;  
}  
```
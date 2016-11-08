---
title: "Compiler Error CS0453 | Microsoft Docs"
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
  - "CS0453"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0453"
ms.assetid: a1bbd09e-6313-4bfd-84bf-bc15a8d214a6
caps.latest.revision: 13
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
# Compiler Error CS0453
The type 'Type Name' must be a non-nullable value type in order to use it as parameter 'Parameter Name' in the generic type or method 'Generic Identifier'  
  
 This error occurs when you use a non-value type argument in instantiating a generic type or method which has the **value** constraint on it. It can also occur when you use a nullable value type argument. See the last two lines of code in the following example.  
  
## Example  
 The following code generates this error.  
  
```  
// CS0453.cs  
using System;  
public class HV<S> where S : struct { }  
public class H1 : HV<string> { }                   // CS0453  
public class H2 : HV<H1> { }                       // CS0453  
public class H3<S> : HV<S> where S : class { }     // CS0453  
public class H4 : HV<int?> { }                     // CS0453  
public class H5 : HV<Nullable<Nullable<int>>> { }  // CS0453  
```
---
title: "Compiler Warning (level 3) CS1700"
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
  - "CS1700"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1700"
ms.assetid: fcd38d68-e34b-4f87-8290-444e66886597
caps.latest.revision: 11
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
# Compiler Warning (level 3) CS1700
Assembly reference Assembly Name is invalid and cannot be resolved  
  
 This warning indicates that an attribute, such as <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>, was not specified correctly.  
  
 For more information, see [Friend Assemblies](../Topic/Friend%20Assemblies%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Example  
 The following sample generates CS1700.  
  
```  
// CS1700.cs  
// compile with: /target:library  
using System.Runtime.CompilerServices;  
[assembly:InternalsVisibleTo("app2, Retargetable=f")]   // CS1700  
[assembly:InternalsVisibleTo("app2")]   // OK  
```
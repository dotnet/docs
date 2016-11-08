---
title: "Compiler Error CS1730 | Microsoft Docs"
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
  - "CS1730"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1730"
ms.assetid: 20900ca0-702f-4f35-9a60-2dee9cb11902
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
# Compiler Error CS1730
Assembly and module attributes must precede all other elements defined in a file except using clauses and extern alias declarations.  
  
 An attribute applied at the assembly level cannot appear after any type definitions.  
  
### To correct this error  
  
1.  Move the attribute to the top of the file, but below the `using` directives and `extern` alias declarations.  
  
## Example  
 The following code generates CS1730:  
  
```  
// cs1730.cs  
class Test  
{  
}  
[assembly: System.Attribute] // CS1730  
```  
  
## See Also  
 [Attributes](../Topic/Attributes%20\(C%23%20and%20Visual%20Basic\).md)
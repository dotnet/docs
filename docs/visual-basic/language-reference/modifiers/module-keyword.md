---
title: "Module &lt;keyword&gt; (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vb.ModuleAttribute"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Module keyword"
  - "Module modifier"
  - "attribute blocks, Module keyword"
ms.assetid: d971b940-05ab-4d56-8485-e3b8a661906b
caps.latest.revision: 13
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Module &lt;keyword&gt; (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Specifies that an attribute at the beginning of a source file applies to the current assembly module.  
  
## Remarks  
 Many attributes pertain to an individual programming element, such as a class or property. You apply such an attribute by attaching the attribute block, within angle brackets (`< >`), directly to the declaration statement.  
  
 If an attribute pertains not only to the following element but to the current assembly module, you place the attribute block at the beginning of the source file and identify the attribute with the `Module` keyword. If it applies to the entire assembly, you use the [Assembly](../../../visual-basic/language-reference/modifiers/assembly.md) keyword.  
  
 The `Module` modifier is not the same as the [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md).  
  
## See Also  
 [Assembly](../../../visual-basic/language-reference/modifiers/assembly.md)   
 [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)   
 [Attributes](../Topic/Attributes%20\(C%23%20and%20Visual%20Basic\).md)
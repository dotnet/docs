---
title: "#Region Directive | Microsoft Docs"
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
  - "vb.Region"
  - "vb.#Region"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Visual Basic compiler, compiler directives"
  - "#region directive"
  - "region directive (#region)"
  - "#Region keyword"
ms.assetid: 90a6a104-3cbf-47d0-bdc4-b585d0921b87
caps.latest.revision: 14
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# #Region Directive
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Collapses and hides sections of code in Visual Basic files.  
  
## Syntax  
  
```  
  
      #Region "identifier_string"  
#End Region  
```  
  
## Parts  
  
|||  
|-|-|  
|Term|Definition|  
|`identifier_string`|Required. String that acts as the title of a region when it is collapsed. Regions are collapsed by default.|  
|`#End Region`|Terminates the `#Region` block.|  
  
## Remarks  
 Use the `#Region` directive to specify a block of code to expand or collapse when using the outlining feature of the Visual Studio Code Editor. You can place, or *nest*, regions within other regions to group similar regions together.  
  
## Example  
 This example uses the `#Region` directive.  
  
 [!code-vb[VbVbalrConditionalComp#4](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrConditionalComp/VB/Class1.vb#4)]  
  
## See Also  
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)   
 [Outlining](/visual-studio/ide/outlining)   
 [How to: Collapse and Hide Sections of Code](../../../visual-basic/programming-guide/program-structure/how-to-collapse-and-hide-sections-of-code.md)
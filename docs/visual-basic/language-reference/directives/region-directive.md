---
title: "#Region Directive"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Region"
  - "vb.#Region"
helpviewer_keywords: 
  - "Visual Basic compiler, compiler directives"
  - "#region directive"
  - "region directive (#region)"
  - "#Region keyword [Visual Basic]"
ms.assetid: 90a6a104-3cbf-47d0-bdc4-b585d0921b87
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# #Region Directive
Collapses and hides sections of code in Visual Basic files.  
  
## Syntax  
  
```  
      #Region "identifier_string"  
#End Region  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`identifier_string`|Required. String that acts as the title of a region when it is collapsed. Regions are collapsed by default.|  
|`#End Region`|Terminates the `#Region` block.|  
  
## Remarks  
 Use the `#Region` directive to specify a block of code to expand or collapse when using the outlining feature of the Visual Studio Code Editor. You can place, or *nest*, regions within other regions to group similar regions together.  
  
## Example  
 This example uses the `#Region` directive.  
  
 [!code-vb[VbVbalrConditionalComp#4](../../../visual-basic/language-reference/directives/codesnippet/VisualBasic/region-directive_1.vb)]  
  
## See Also  
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)  
 [Outlining](/visualstudio/ide/outlining)  
 [How to: Collapse and Hide Sections of Code](../../../visual-basic/programming-guide/program-structure/how-to-collapse-and-hide-sections-of-code.md)

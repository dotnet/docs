---
title: "#Region Directive (Visual Basic)"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Region"
  - "vb.#Region"
helpviewer_keywords: 
  - "Visual Basic compiler, compiler directives"
  - "#region directive"
  - "region directive (#region)"
  - "#Region keyword [Visual Basic]"
ms.assetid: 90a6a104-3cbf-47d0-bdc4-b585d0921b87
---
# #Region Directive

Collapses and hides sections of code in Visual Basic files.  
  
## Syntax  

```vb
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
  
 [!code-vb[VbVbalrConditionalComp#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrConditionalComp/VB/Class1.vb#4)]  
  
## See also

- [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)
- [Outlining](/visualstudio/ide/outlining)
- [How to: Collapse and Hide Sections of Code](../../../visual-basic/programming-guide/program-structure/how-to-collapse-and-hide-sections-of-code.md)

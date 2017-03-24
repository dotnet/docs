---
title: "&lt;proceduresignature1&gt; is not CLS-compliant because it overloads &lt;proceduresignature2&gt; which differs from it only by array of array parameter types or by the rank of the array parameter types | Microsoft Docs"
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
  - "vbc40035"
  - "bc40035"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC40035"
ms.assetid: 50a66dbe-2c1e-41bf-96bc-369301c891ac
caps.latest.revision: 11
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# &lt;proceduresignature1&gt; is not CLS-compliant because it overloads &lt;proceduresignature2&gt; which differs from it only by array of array parameter types or by the rank of the array parameter types
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

A procedure or property is marked as `<CLSCompliant(True)>` when it overrides another procedure or property and the only difference between their parameter lists is the nesting level of a jagged array or the rank of an array.  
  
 In the following declarations, the second and third declarations generate this error.  
  
 `Overloads Sub processArray(ByVal arrayParam() As Integer)`  
  
 `Overloads Sub processArray(ByVal arrayParam()() As Integer)`  
  
 `Overloads Sub processArray(ByVal arrayParam(,) As Integer)`  
  
 The second declaration changes the original one-dimensional parameter `arrayParam` to an array of arrays. The third declaration changes `arrayParam` to a two-dimensional array (rank 2). While Visual Basic allows overloads to differ only by one of these changes, such overloading is not compliant with the [Language Independence and Language-Independent Components](../Topic/Language%20Independence%20and%20Language-Independent%20Components.md) (CLS).  
  
 When you apply the <xref:System.CLSCompliantAttribute> to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.  
  
 If you do not apply the <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.  
  
 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visual-studio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC40035  
  
### To correct this error  
  
-   If you require CLS compliance, define your overloads to differ from each other in more ways than only the changes cited on this Help page.  
  
-   If you require that the overloads differ only by the changes cited on this Help page, remove the <xref:System.CLSCompliantAttribute> from their definitions or mark them as `<CLSCompliant(False)>`.  
  
## See Also  
 [\<PAVE OVER> Writing CLS-Compliant Code](http://msdn.microsoft.com/en-us/4c705105-69a2-4e5e-b24e-0633bc32c7f3)   
 [Procedure Overloading](../../../visual-basic/programming-guide/language-features/procedures/procedure-overloading.md)   
 [Overloads](../../../visual-basic/language-reference/modifiers/overloads.md)
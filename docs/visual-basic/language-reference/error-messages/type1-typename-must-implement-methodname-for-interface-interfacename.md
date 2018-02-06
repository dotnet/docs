---
title: "&lt;type1&gt;&#39;&lt;typename&gt;&#39; must implement &#39;&lt;methodname&gt;&#39; for interface &#39;&lt;interfacename&gt;&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30149"
  - "bc30149"
helpviewer_keywords: 
  - "BC30149"
ms.assetid: 29d1b7f4-dca7-478c-bbe7-c657f342c183
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# &lt;type1&gt;&#39;&lt;typename&gt;&#39; must implement &#39;&lt;methodname&gt;&#39; for interface &#39;&lt;interfacename&gt;&#39;
A class or structure claims to implement an interface but does not implement a procedure defined by the interface. Every member of the interface must be implemented.  
  
 **Error ID:** BC30149  
  
## To correct this error  
  
1.  Declare a procedure with the same name and signature as defined in the interface. Be sure to include at least the `End Function` or `End Sub` statement.  
  
2.  Add an `Implements` clause to the end of the `Function` or `Sub` statement. For example:  
  
    ```  
    Public Sub DoSomething() Implements IBaseInterface.DoSomething  
    ```  
  
## See Also  
 [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md)  
 [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md)

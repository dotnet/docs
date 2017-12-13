---
title: "How to: Determine Whether Two Objects Are Related (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "inheritance [Visual Basic], Visual Basic objects"
  - "objects [Visual Basic], inheritance"
  - "object variables [Visual Basic], determining relation"
ms.assetid: da002e3f-6616-4bad-a229-f842d06652bb
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Determine Whether Two Objects Are Related (Visual Basic)
You can compare two objects to determine the relationship, if any, between the classes from which they are created. The <xref:System.Type.IsInstanceOfType%2A> method of the <xref:System.Type?displayProperty=nameWithType> class returns `True` if the specified class inherits from the current class, or if the current type is an interface supported by the specified class.  
  
### To determine if one object inherits from another object's class or interface  
  
1.  On the object you think might be of the base type, invoke the <xref:System.Object.GetType%2A> method.  
  
2.  On the <xref:System.Type?displayProperty=nameWithType> object returned by <xref:System.Object.GetType%2A>, invoke the <xref:System.Type.IsInstanceOfType%2A> method.  
  
3.  In the argument list for <xref:System.Type.IsInstanceOfType%2A>, specify the object you think might be of the derived type.  
  
     <xref:System.Type.IsInstanceOfType%2A> returns `True` if its argument type inherits from the <xref:System.Type?displayProperty=nameWithType> object type.  
  
## Example  
 The following example determines whether one object represents a class derived from another object's class.  
  
```  
Public Class baseClass  
End Class  
Public Class derivedClass : Inherits baseClass  
End Class  
Public Class testTheseClasses  
    Public Sub seeIfRelated()  
        Dim baseObj As Object = New baseClass()  
        Dim derivedObj As Object = New derivedClass()  
        Dim related As Boolean  
        related = baseObj.GetType().IsInstanceOfType(derivedObj)  
        MsgBox(CStr(related))  
    End Sub  
End Class  
```  
  
 Note the unexpected placement of the two object variables in the call to <xref:System.Type.IsInstanceOfType%2A>. The supposed base type is used to generate the <xref:System.Type?displayProperty=nameWithType> class, and the supposed derived type is passed as an argument to the <xref:System.Type.IsInstanceOfType%2A> method.  
  
## See Also  
 <xref:System.Object.GetType%2A>  
 <xref:System.Type?displayProperty=nameWithType>  
 <xref:System.Type.IsInstanceOfType%2A>  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Values](../../../../visual-basic/programming-guide/language-features/variables/object-variable-values.md)  
 [How to: Determine Whether Two Objects Are Identical](../../../../visual-basic/programming-guide/language-features/variables/how-to-determine-whether-two-objects-are-identical.md)

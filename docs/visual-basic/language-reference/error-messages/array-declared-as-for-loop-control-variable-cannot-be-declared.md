---
title: "Array declared as for loop control variable cannot be declared with an initial size"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc32039"
  - "bc32039"
helpviewer_keywords: 
  - "BC32039"
ms.assetid: 1d8b6560-c9eb-4b71-a038-24c6f5a5ce46
---
# Array declared as for loop control variable cannot be declared with an initial size
A `For Each` loop uses an array as its *element* iteration variable but initializes that array.  
  
 The following statements show how this error can be generated.  
  
```  
Dim arrayList As New List(Of Integer())  
For Each listElement() As Integer In arrayList  
For Each listElement(1) As Integer In arrayList  
```  
  
 The first `For Each` statement is the correct way to access elements of `arrayList`. The second `For Each` statement generates this error.  
  
 **Error ID:** BC32039  
  
## To correct this error  
  
-   Remove the initialization from the declaration of the *element* iteration variable.  
  
## See also
- [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md)
- [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)
- [Collections](../../../standard/collections/index.md)

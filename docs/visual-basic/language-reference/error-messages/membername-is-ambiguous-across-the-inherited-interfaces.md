---
title: "'<membername>' is ambiguous across the inherited interfaces '<interfacename1>' and '<interfacename2>'"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc30685"
  - "bc30685"
helpviewer_keywords: 
  - "BC30685"
ms.assetid: 756add7a-23d5-4b4f-a48d-8297d6459c73
---
# '\<membername>' is ambiguous across the inherited interfaces '\<interfacename1>' and '\<interfacename2>'
The interface inherits two or more members with the same name from multiple interfaces.  
  
 **Error ID:** BC30685  
  
## To correct this error  
  
- Cast the value to the base interface that you want to use; for example:  
  
    ```vb  
    Interface Left  
        Sub MySub()  
    End Interface  
  
    Interface Right  
        Sub MySub()  
    End Interface  
  
    Interface LeftRight  
        Inherits Left, Right  
    End Interface  
  
    Module test  
        Sub Main()  
            Dim x As LeftRight  
            ' x.MySub()  'x is ambiguous.  
            CType(x, Left).MySub() ' Cast to base type.  
            CType(x, Right).MySub() ' Call the other base type.  
        End Sub  
    End Module  
    ```  
  
## See also

- [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md)

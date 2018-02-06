---
title: "Methods of &#39;System.Nullable(Of T)&#39; cannot be used as operands of the &#39;AddressOf&#39; operator"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc32126"
  - "bc32126"
helpviewer_keywords: 
  - "BC32126"
ms.assetid: 2325668b-e2ad-40ee-a1ec-30450236c20d
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
---
# Methods of &#39;System.Nullable(Of T)&#39; cannot be used as operands of the &#39;AddressOf&#39; operator
A statement uses the `AddressOf` operator with an operand that represents a procedure of the <xref:System.Nullable%601> structure.  
  
 **Error ID:** BC32126  
  
## To correct this error  
  
-   Replace the procedure name in the `AddressOf` clause with an operand that is not a member of <xref:System.Nullable%601>.  
  
-   Write a class that wraps the method of <xref:System.Nullable%601> that you want to use. In the following example, the `NullableWrapper` class defines a new method named `GetValueOrDefault`. Because this new method is not a member of <xref:System.Nullable%601>, it can be applied to `nullInstance`, an instance of a nullable type, to form an argument for `AddressOf`.  
  
```vb  
Module Module1  
  
    Delegate Function Deleg() As Integer  
  
    Sub Main()  
        Dim nullInstance As New Nullable(Of Integer)(1)  
  
        Dim del As Deleg  
  
        ' GetValueOrDefault is a method of the Nullable generic  
        ' type. It cannot be used as an operand of AddressOf.  
        ' del = AddressOf nullInstance.GetValueOrDefault  
  
        ' The following line uses the GetValueOrDefault method  
        ' defined in the NullableWrapper class.  
        del = AddressOf (New NullableWrapper(  
            Of Integer)(nullInstance)).GetValueOrDefault  
  
        Console.WriteLine(del.Invoke())  
    End Sub  
  
    Class NullableWrapper(Of T As Structure)  
        Private m_Value As Nullable(Of T)  
  
        Sub New(ByVal Value As Nullable(Of T))  
            m_Value = Value  
        End Sub  
  
        Public Function GetValueOrDefault() As T  
            Return m_Value.Value  
        End Function  
    End Class  
End Module  
```  
  
## See Also  
 <xref:System.Nullable%601>  
 [AddressOf Operator](../../../visual-basic/language-reference/operators/addressof-operator.md)  
 [Nullable Value Types](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)  
 [Generic Types in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)

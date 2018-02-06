---
title: "How to: Determine What Type an Object Variable Refers To (Visual Basic)"
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
  - "TypeOf operator [Visual Basic], determining object variable type"
  - "variables [Visual Basic], object"
  - "object variables [Visual Basic], determining type"
ms.assetid: 6f6a138d-58a4-40d1-9f4e-0a3c598eaf81
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Determine What Type an Object Variable Refers To (Visual Basic)
An object variable contains a pointer to data that is stored elsewhere. The type of that data can change during run time. At any moment, you can use the <xref:System.Type.GetTypeCode%2A> method to determine the current run-time type, or the [TypeOf Operator](../../../../visual-basic/language-reference/operators/typeof-operator.md) to find out if the current run-time type is compatible with a specified type.  
  
### To determine the exact type an object variable currently refers to  
  
1.  On the object variable, call the <xref:System.Object.GetType%2A> method to retrieve a <xref:System.Type?displayProperty=nameWithType> object.  
  
    ```  
    Dim myObject As Object  
    myObject.GetType()  
    ```  
  
2.  On the <xref:System.Type?displayProperty=nameWithType> class, call the shared method <xref:System.Type.GetTypeCode%2A> to retrieve the <xref:System.TypeCode> enumeration value for the object's type.  
  
    ```  
    Dim myObject As Object  
    Dim datTyp As Integer = Type.GetTypeCode(myObject.GetType())  
    MsgBox("myObject currently has type code " & CStr(datTyp))  
    ```  
  
     You can test the <xref:System.TypeCode> enumeration value against whichever enumeration members are of interest, such as `Double`.  
  
### To determine whether an object variable's type is compatible with a specified type  
  
-   Use the `TypeOf` operator in combination with the [Is Operator](../../../../visual-basic/language-reference/operators/is-operator.md) to test the object with a `TypeOf`...`Is` expression.  
  
    ```  
    If TypeOf objA Is System.Windows.Forms.Control Then  
        MsgBox("objA is compatible with the Control class")  
    End If  
    ```  
  
     The `TypeOf`...`Is` expression returns `True` if the object's run-time type is compatible with the specified type.  
  
     The criterion for compatibility depends on whether the specified type is a class, structure, or interface. In general, the types are compatible if the object is of the same type as, inherits from, or implements the specified type. For more information, see [TypeOf Operator](../../../../visual-basic/language-reference/operators/typeof-operator.md).  
  
## Compiling the Code  
 Note that the specified type cannot be a variable or expression. It must be the name of a defined type, such as a class, structure, or interface. This includes intrinsic types such as `Integer` and `String`.  
  
## See Also  
 <xref:System.Object.GetType%2A>  
 <xref:System.Type?displayProperty=nameWithType>  
 <xref:System.Type.GetTypeCode%2A>  
 <xref:System.TypeCode>  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Values](../../../../visual-basic/programming-guide/language-features/variables/object-variable-values.md)  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)

---
title: "Data type(s) of the type parameter(s) cannot be inferred from these arguments"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc36644"
  - "bc36647"
  - "vbc36647"
  - "vbc36644"
helpviewer_keywords: 
  - "BC36644"
  - "BC36647"
ms.assetid: 0e0050f2-2039-4311-b260-f0ebfde84189
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
---
# Data type(s) of the type parameter(s) cannot be inferred from these arguments
Data type(s) of the type parameter(s) cannot be inferred from these arguments. Specifying the data type(s) explicitly might correct this error.  
  
 This error occurs when overload resolution has failed. It occurs as a subordinate message that states why a particular overload candidate has been eliminated. The error message explains that the compiler cannot use type inference to find data types for the type parameters.  
  
> [!NOTE]
>  When specifying arguments is not an option (for example, for query operators in query expressions), the error message appears without the second sentence.  
  
 The following code demonstrates the error.  
  
```vb  
Module Module1  
  
    Sub Main()  
  
        '' Not Valid.  
        'OverloadedGenericMethod("Hello", "World")  
  
    End Sub  
  
    Sub OverloadedGenericMethod(Of T)(ByVal x As String,   
                                      ByVal y As InterfaceExample(Of T))  
    End Sub  
  
    Sub OverloadedGenericMethod(Of T, R)(ByVal x As T,   
                                         ByVal y As InterfaceExample(Of R))  
    End Sub  
  
End Module  
  
Interface InterfaceExample(Of T)  
End Interface  
```  
  
 **Error ID:** BC36647 and BC36644  
  
## To correct this error  
  
-   You may be able to specify a data type for the type parameter or parameters instead of relying on type inference.  
  
## See Also  
 [Relaxed Delegate Conversion](../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md)  
 [Generic Procedures in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-procedures.md)  
 [Type Conversions in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)

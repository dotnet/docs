---
title: "Creating Custom Attributes (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5c9ef584-6c7c-496b-92a9-6e42f8d9ca28
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Creating Custom Attributes (Visual Basic)
You can create your own custom attributes by defining an attribute class, a class that derives directly or indirectly from <xref:System.Attribute>, which makes identifying attribute definitions in metadata fast and easy. Suppose you want to tag types with the name of the programmer who wrote the type. You might define a custom `Author` attribute class:  
  
```vb  
<System.AttributeUsage(System.AttributeTargets.Class Or   
                       System.AttributeTargets.Struct)>   
Public Class Author  
    Inherits System.Attribute  
    Private name As String  
    Public version As Double  
    Sub New(ByVal authorName As String)  
        name = authorName  
        version = 1.0  
    End Sub  
End Class  
```  
  
 The class name is the attribute's name, `Author`. It is derived from `System.Attribute`, so it is a custom attribute class. The constructor's parameters are the custom attribute's positional parameters. In this example, `name` is a positional parameter. Any public read-write fields or properties are named parameters. In this case, `version` is the only named parameter. Note the use of the `AttributeUsage` attribute to make the `Author` attribute valid only on class and `Structure` declarations.  
  
 You could use this new attribute as follows:  
  
```vb  
<Author("P. Ackerman", Version:=1.1)>   
Class SampleClass  
    ' P. Ackerman's code goes here...  
End Class  
```  
  
 `AttributeUsage` has a named parameter, `AllowMultiple`, with which you can make a custom attribute single-use or multiuse. In the following code example, a multiuse attribute is created.  
  
```vb  
' multiuse attribute  
<System.AttributeUsage(System.AttributeTargets.Class Or   
                       System.AttributeTargets.Struct,   
                       AllowMultiple:=True)>   
Public Class Author  
    Inherits System.Attribute  
```  
  
 In the following code example, multiple attributes of the same type are applied to a class.  
  
```vb  
<Author("P. Ackerman", Version:=1.1),   
Author("R. Koch", Version:=1.2)>   
Class SampleClass  
    ' P. Ackerman's code goes here...  
    ' R. Koch's code goes here...  
End Class  
```  
  
> [!NOTE]
>  If your attribute class contains a property, that property must be read-write.  
  
## See Also  
 <xref:System.Reflection>  
 [Visual Basic Programming Guide](../../../../visual-basic/programming-guide/index.md)  
 [Writing Custom Attributes](../../../../standard/attributes/writing-custom-attributes.md)  
 [Reflection (Visual Basic)](../../../../visual-basic/programming-guide/concepts/reflection.md)  
 [Attributes (Visual Basic)](../../../../visual-basic/language-reference/attributes.md)  
 [Accessing Attributes by Using Reflection (Visual Basic)](../../../../visual-basic/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection.md)  
 [AttributeUsage (Visual Basic)](../../../../visual-basic/programming-guide/concepts/attributes/attributeusage.md)

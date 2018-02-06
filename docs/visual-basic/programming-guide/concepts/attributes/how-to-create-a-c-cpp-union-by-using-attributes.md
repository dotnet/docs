---
title: "How to: Create a C-C++ Union by Using Attributes (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9352a7e4-c0da-4d07-aa14-55ed43736fcb
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a C/C++ Union by Using Attributes (Visual Basic)
By using attributes you can customize how structs are laid out in memory. For example, you can create what is known as a union in C/C++ by using the `StructLayout(LayoutKind.Explicit)` and `FieldOffset` attributes.  
  
## Example  
 In this code segment, all of the fields of `TestUnion` start at the same location in memory.  
  
```vb  
' Add an Imports statement for System.Runtime.InteropServices.  
  
<System.Runtime.InteropServices.StructLayout(   
      System.Runtime.InteropServices.LayoutKind.Explicit)>   
Structure TestUnion  
    <System.Runtime.InteropServices.FieldOffset(0)>   
    Public i As Integer  
  
    <System.Runtime.InteropServices.FieldOffset(0)>   
    Public d As Double  
  
    <System.Runtime.InteropServices.FieldOffset(0)>   
    Public c As Char  
  
    <System.Runtime.InteropServices.FieldOffset(0)>   
    Public b As Byte  
End Structure  
```  
  
## Example  
 The following is another example where fields start at different explicitly set locations.  
  
```vb  
' Add an Imports statement for System.Runtime.InteropServices.  
  
 <System.Runtime.InteropServices.StructLayout(  
      System.Runtime.InteropServices.LayoutKind.Explicit)>   
Structure TestExplicit  
     <System.Runtime.InteropServices.FieldOffset(0)>   
     Public lg As Long  
  
     <System.Runtime.InteropServices.FieldOffset(0)>   
     Public i1 As Integer  
  
     <System.Runtime.InteropServices.FieldOffset(4)>   
     Public i2 As Integer  
  
     <System.Runtime.InteropServices.FieldOffset(8)>   
     Public d As Double  
  
     <System.Runtime.InteropServices.FieldOffset(12)>   
     Public c As Char  
  
     <System.Runtime.InteropServices.FieldOffset(14)>   
     Public b As Byte  
 End Structure  
```  
  
 The two integer fields, `i1` and `i2`, share the same memory locations as `lg`. This sort of control over struct layout is useful when using platform invocation.  
  
## See Also  
 <xref:System.Reflection>  
 <xref:System.Attribute>  
 [Visual Basic Programming Guide](../../../../visual-basic/programming-guide/index.md)  
 [Attributes](../../../../standard/attributes/index.md)  
 [Reflection (Visual Basic)](../../../../visual-basic/programming-guide/concepts/reflection.md)  
 [Attributes (Visual Basic)](../../../../visual-basic/language-reference/attributes.md)  
 [Creating Custom Attributes (Visual Basic)](../../../../visual-basic/programming-guide/concepts/attributes/creating-custom-attributes.md)  
 [Accessing Attributes by Using Reflection (Visual Basic)](../../../../visual-basic/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection.md)

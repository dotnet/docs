---
title: "How to: Retrieve the Value of an Attribute (LINQ to XML) (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5f4b3790-c83f-4eb3-a889-e3587edf3ca1
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# How to: Retrieve the Value of an Attribute (LINQ to XML) (Visual Basic)
This topic shows how to obtain the value of attributes. There are two main ways: You can cast an <xref:System.Xml.Linq.XAttribute> to the desired type; the explicit conversion operator then converts the contents of the element or attribute to the specified type. Alternatively, you can use the <xref:System.Xml.Linq.XAttribute.Value%2A> property. However, casting is generally the better approach. If you cast the attribute to a nullable type, the code is simpler to write when retrieving the value of an attribute that might or might not exist. For examples of this technique, see [How to: Retrieve the Value of an Element (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-the-value-of-an-element-linq-to-xml.md).  
  
## Example  
 In Visual Basic, you can use the integrated attribute property to retrieve the value of an attribute.  
  
```vb  
Dim root As XElement = <Root Attr="abcde"/>  
Console.WriteLine(root)  
Dim str As String = root.@Attr  
Console.WriteLine(str)  
```  
  
 This example produces the following output:  
  
```xml  
<Root Attr="abcde" />  
abcde  
```  
  
## Example  
 In Visual Basic, you can use the integrated attribute property to set the value of an attribute. Further, if you use the integrated attribute property to set the value of an attribute that does not exist, the attribute will be created.  
  
```vb  
Dim root As XElement = <Root Att1="content"/>  
root.@Att1 = "new content"  
root.@Att2 = "new attribute"  
Console.WriteLine(root)  
```  
  
 This example produces the following output:  
  
```xml  
<Root Att1="new content" Att2="new attribute" />  
```  
  
## Example  
 The following example shows how to retrieve the value of an attribute where the attribute is in a namespace. For more information, see [Working with XML Namespaces (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/working-with-xml-namespaces.md).  
  
```vb  
Imports <xmlns:aw="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = <aw:Root aw:Attr="abcde"/>  
        Dim str As String = root.@aw:Attr  
        Console.WriteLine(str)  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```  
abcde  
```  
  
## See Also  
 [LINQ to XML Axes (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-axes.md)

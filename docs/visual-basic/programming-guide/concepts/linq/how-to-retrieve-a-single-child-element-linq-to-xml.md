---
title: "How to: Retrieve a Single Child Element (LINQ to XML) (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0033e258-d9c4-4569-86f6-79b7c06d1204
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# How to: Retrieve a Single Child Element (LINQ to XML) (Visual Basic)
This topic explains how to retrieve a single child element, given the name of the child element. When you know the name of the child element and that there is only one element that has this name, it can be convenient to retrieve just one element, instead of a collection.  
  
 The <xref:System.Xml.Linq.XContainer.Element%2A> method returns the first child <xref:System.Xml.Linq.XElement> with the specified <xref:System.Xml.Linq.XName>.  
  
 If you want to retrieve a single child element in Visual Basic, a common approach is to use the XML property, and then retrieve the first element using array indexer notation.  
  
## Example  
 The following example demonstrates the use of the <xref:System.Xml.Linq.XContainer.Element%2A> method. This example takes the XML tree named `po` and finds the first element named `Comment`.  
  
 The Visual Basic example shows using array indexer notation to retrieve a single element.  
  
 This example uses the following XML document: [Sample XML File: Typical Purchase Order (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/sample-xml-file-typical-purchase-order-linq-to-xml.md).  
  
```vb  
Dim po As XElement = XElement.Load("PurchaseOrder.xml")  
Dim e As XElement = po.<DeliveryNotes>(0)  
Console.WriteLine(e)  
```  
  
 This example produces the following output:  
  
```xml  
<DeliveryNotes>Please leave packages in shed by driveway.</DeliveryNotes>  
```  
  
## Example  
 The following example shows the same code for XML that is in a namespace. For more information, see [Working with XML Namespaces (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/working-with-xml-namespaces.md).  
  
 This example uses the following XML document: [Sample XML File: Typical Purchase Order in a Namespace](../../../../visual-basic/programming-guide/concepts/linq/sample-xml-file-typical-purchase-order-in-a-namespace.md).  
  
```vb  
Imports <xmlns:aw="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim po As XElement = XElement.Load("PurchaseOrderInNamespace.xml")  
        Dim e As XElement = po.<aw:DeliveryNotes>(0)  
        Console.WriteLine(e)  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```xml  
<aw:DeliveryNotes xmlns:aw="http://www.adventure-works.com">Please leave packages in shed by driveway.</aw:DeliveryNotes>  
```  
  
## See Also  
 [LINQ to XML Axes (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-axes.md)

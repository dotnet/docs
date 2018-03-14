---
title: "How to: Find Attributes of Siblings with a Specific Name (XPath-LINQ to XML) (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 83b3ddca-830a-4b71-9756-9e4bdf907302
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# How to: Find Attributes of Siblings with a Specific Name (XPath-LINQ to XML) (Visual Basic)
This topic shows how to find all attributes of the siblings of the context node. Only attributes with a specific name are returned in the collection.  
  
 The XPath expression is:  
  
 `../Book/@id`  
  
## Example  
 This example first finds a `Book` element, and then finds all sibling elements named `Book`, and then finds all attributes named `id`. The result is a collection of attributes.  
  
 This example uses the following XML document: [Sample XML File: Books (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/sample-xml-file-books-linq-to-xml.md).  
  
```vb  
Dim books as XDocument = XDocument.Load("Books.xml")  
Dim book As XElement = books.Root.<Book>(0)  
  
' LINQ to XML query  
Dim list1 As IEnumerable(Of XAttribute) = _  
    From el In book.Parent.<Book> _  
    Select el.Attribute("id")  
  
' XPath expression  
Dim list2 As IEnumerable(Of XAttribute) = DirectCast(book. _  
    XPathEvaluate("../Book/@id"), IEnumerable).Cast(Of XAttribute)()  
  
If list1.Count() = list2.Count() And _  
        (list1.Intersect(list2)).Count() = list1.Count() Then  
    Console.WriteLine("Results are identical")  
Else  
    Console.WriteLine("Results differ")  
End If  
  
For Each el As XAttribute In list1  
    Console.WriteLine(el)  
Next  
```  
  
 This example produces the following output:  
  
```  
Results are identical  
id="bk101"  
id="bk102"  
```  
  
## See Also  
 [LINQ to XML for XPath Users (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-for-xpath-users.md)

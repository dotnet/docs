---
title: "Statically Compiled Queries (LINQ to XML) (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3f4825c7-c3b0-48da-ba4e-8e97fb2a2f34
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# Statically Compiled Queries (LINQ to XML) (Visual Basic)
One of the most important performance benefits LINQ to XML, as opposed to <xref:System.Xml.XmlDocument>, is that queries in LINQ to XML are statically compiled, whereas XPath queries must be interpreted at run time. This feature is built in to LINQ to XML, so you do not have to perform extra steps to take advantage of it, but it is helpful to understand the distinction when choosing between the two technologies. This topic explains the difference.  
  
## Statically Compiled Queries vs. XPath  
 The following example shows how to get the descendant elements with a specified name, and with an attribute with a specified value.  
  
 The following is the equivalent XPath expression:  
  
```  
//Address[@Type='Shipping']  
```  
  
```vb  
Dim po = XDocument.Load("PurchaseOrders.xml")  
  
Dim list1 = From el In po.Descendants("Address")  
            Where el.@Type = "Shipping"  
  
For Each el In list1  
    Console.WriteLine(el)  
Next  
```  
  
 The query expression in this example is re-written by the compiler to method-based query syntax. The following example, which is written in method-based query syntax, produces the same results as the previous one:  
  
```vb  
Dim po = XDocument.Load("PurchaseOrders.xml")  
  
Dim list1 As IEnumerable(Of XElement) = po.Descendants("Address").Where(Function(el) el.@Type = "Shipping")  
  
For Each el In list1  
    Console.WriteLine(el)  
Next   
```  
  
 The <xref:System.Linq.Enumerable.Where%2A> method is an extension method. For more information, see [Extension Methods](../../../../csharp/programming-guide/classes-and-structs/extension-methods.md). Because <xref:System.Linq.Enumerable.Where%2A> is an extension method, the query above is compiled as though it were written as follows:  
  
```vb  
Dim po = XDocument.Load("PurchaseOrders.xml")  
  
Dim list1 = Enumerable.Where(po.Descendants("Address"), Function(el) el.@Type = "Shipping")  
  
For Each el In list1  
    Console.WriteLine(el)  
Next  
```  
  
 This example produces exactly the same results as the previous two examples. This illustrates the fact that queries are effectively compiled into statically linked method calls. This, combined with the deferred execution semantics of iterators, improves performance. For more information about the deferred execution semantics of iterators, see [Deferred Execution and Lazy Evaluation in LINQ to XML (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/deferred-execution-and-lazy-evaluation-in-linq-to-xml.md).  
  
> [!NOTE]
>  These examples are representative of the code that the compiler might write. The actual implementation might differ slightly from these examples, but the performance will be the same or similar to these examples.  
  
## Executing XPath Expressions with XmlDocument  
 The following example uses <xref:System.Xml.XmlDocument> to accomplish the same results as the previous examples:  
  
```vb  
Dim reader = Xml.XmlReader.Create("PurchaseOrders.xml")  
Dim doc As New Xml.XmlDocument()  
doc.Load(reader)  
Dim nl As Xml.XmlNodeList = doc.SelectNodes(".//Address[@Type='Shipping']")  
For Each n As Xml.XmlNode In nl  
    Console.WriteLine(n.OuterXml)  
Next  
reader.Close()  
```  
  
 This query returns the same output as the examples that use LINQ to XML; the only difference is that LINQ to XML indents the printed XML, whereas <xref:System.Xml.XmlDocument> does not.  
  
 However, the <xref:System.Xml.XmlDocument> approach generally does not perform as well as LINQ to XML, because the <xref:System.Xml.XmlNode.SelectNodes%2A> method must do the following internally every time it is called:  
  
-   It parses the string that contains the XPath expression, breaking the string into tokens.  
  
-   It validates the tokens to make sure that the XPath expression is valid.  
  
-   It translates the expression into an internal expression tree.  
  
-   It iterates through the nodes, appropriately selecting the nodes for the result set based on the evaluation of the expression.  
  
 This is significantly more than the work done by the corresponding LINQ to XML query. The specific performance difference varies for different types of queries, but in general LINQ to XML queries do less work, and therefore perform better, than evaluating XPath expressions using <xref:System.Xml.XmlDocument>.  
  
## See Also  
 [Performance (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/performance-linq-to-xml.md)

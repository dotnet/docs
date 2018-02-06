---
title: "LINQ to XML for XPath Users (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: 0e64911c-a7cc-4c20-b927-ca99078b5656
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ to XML for XPath Users (Visual Basic)

This set of topics show a number of XPath expressions and their [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] equivalents.  
  
 All of the examples use the XPath functionality in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] that is made available by the extension methods in <xref:System.Xml.XPath.Extensions?displayProperty=nameWithType>. The examples execute both the XPath expression and the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] expression. Each example then compares the results of both queries, validating that the XPath expression is functionally equivalent to the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] query. As both types of queries return nodes from the same XML tree, the query result comparison is made using referential identity.  
  
## In This Section  
  
|Topic|Description|  
|-----------|-----------------|  
|[Comparison of XPath and LINQ to XML](../../../../visual-basic/programming-guide/concepts/linq/comparison-of-xpath-and-linq-to-xml.md)|Provides an overview of the similarities and differences between XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].|  
|[How to: Find a Child Element (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-a-child-element-xpath-linq-to-xml.md)|Compares the XPath child element axis to the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] <xref:System.Xml.Linq.XContainer.Element%2A> method.<br /><br /> The associated XPath expression is:`"DeliveryNotes"`.|  
|[How to: Find a List of Child Elements (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-a-list-of-child-elements-xpath-linq-to-xml.md)|Compares the XPath child elements axis to the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] <xref:System.Xml.Linq.XContainer.Elements%2A> axis.<br /><br /> The associated XPath expression is:`"./*"`|  
|[How to: Find the Root Element (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-the-root-element-xpath-linq-to-xml.md)|Compares how to get the root element with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"/PurchaseOrders"`|  
|[How to: Find Descendant Elements (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-descendant-elements-xpath-linq-to-xml.md)|Compares how to get the descendant elements with a particular name with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"//Name"`|  
|[How to: Filter on an Attribute (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-filter-on-an-attribute-xpath-linq-to-xml.md)|Compares how to get the descendant elements with a specified name, and with an attribute with a specified value with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`".//Address[@Type='Shipping']"`|  
|[How to: Find Related Elements (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-related-elements-xpath-linq-to-xml.md)|Compares how to get an element selecting on an attribute that is referred to by the value of another element with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`".//Customer[@CustomerID=/Root/Orders/Order[12]/CustomerID]"`|  
|[How to: Find Elements in a Namespace (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-elements-in-a-namespace.md)|Compares the use of the XPath <xref:System.Xml.XmlNamespaceManager> class with the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] <xref:System.Xml.Linq.XName.Namespace%2A> property of the <xref:System.Xml.Linq.XName> class for working with XML namespaces.<br /><br /> The associated XPath expression is:`"./aw:*"`|  
|[How to: Find Preceding Siblings (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-preceding-siblings-xpath-linq-to-xml.md)|Compares the XPath `preceding-sibling` axis to the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] child <xref:System.Xml.Linq.XNode.ElementsBeforeSelf%2A?displayProperty=nameWithType> axis.<br /><br /> The associated XPath expression is:`"preceding-sibling::*"`|  
|[How to: Find Descendants of a Child Element (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-descendants-of-a-child-element-xpath-linq-to-xml.md)|Compares how to get the descendant elements of a child element with a particular name with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"./Paragraph//Text/text()"`|  
|[How to: Find a Union of Two Location Paths (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-a-union-of-two-location-paths-xpath.md)|Compares the use of the union operator, <code>&#124;</code>, in XPath with the <xref:System.Linq.Enumerable.Concat%2A> standard query operator in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:<code>"//Category&#124;//Price"</code>|  
|[How to: Find Sibling Nodes (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-sibling-nodes-xpath-linq-to-xml.md)|Compares how to find all siblings of a node that have a specific name with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"../Book"`|  
|[How to: Find an Attribute of the Parent (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-an-attribute-of-the-parent-xpath-linq-to-xml.md)|Compares how to navigate to the parent element and find an associated attribute using XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"../@id"`|  
|[How to: Find Attributes of Siblings with a Specific Name (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-attributes-of-siblings-with-a-specific-name.md)|Compares how to find specific attributes of the siblings of the context node with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"``../Book/@id``"`|  
|[How to: Find Elements with a Specific Attribute (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-elements-with-a-specific-attribute.md)|Compares how to find al elements containing a specific attribute using XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"./*[@Select]"`|  
|[How to: Find Child Elements Based on Position (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-child-elements-based-on-position.md)|Compares how to find an element based on its relative position using XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"Test[position() >= 2 and position() <= 4]"`|  
|[How to: Find the Immediate Preceding Sibling (XPath-LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-find-the-immediate-preceding-sibling-xpath-linq-to-xml.md)|Compares how to find the immediate preceding sibling of a node using XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].<br /><br /> The associated XPath expression is:`"preceding-sibling::*[1]"`|  
  
## See Also  
 <xref:System.Xml.XPath?displayProperty=nameWithType>  
 [Querying XML Trees (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/querying-xml-trees.md)  
 [Process XML Data Using the XPath Data Model](../../../../standard/data/xml/process-xml-data-using-the-xpath-data-model.md)

---
title: "LINQ to XML Axes (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ecd3bd00-28e5-4517-a59f-53bff39fd478
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ to XML Axes (Visual Basic)
After you have created an XML tree or loaded an XML document into an XML tree, you can query it to find elements and attributes and retrieve their values.  
  
 Before you can write any queries, you must understand the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] axes. There are two kinds of axis methods: First, there are the methods that you call on a single <xref:System.Xml.Linq.XElement> object, <xref:System.Xml.Linq.XDocument> object, or <xref:System.Xml.Linq.XNode> object. These methods operate on a single object and return a collection of <xref:System.Xml.Linq.XElement>, <xref:System.Xml.Linq.XAttribute>, or <xref:System.Xml.Linq.XNode> objects. Second, there are extension methods that operate on collections and return collections. The extension methods enumerate the source collection, call the appropriate axis method on each item in the collection, and concatenate the results.  
  
## In This Section  
  
|Topic|Description|  
|-----------|-----------------|  
|[LINQ to XML Axes Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-axes-overview.md)|Defines axes, and explains how they are used in the context of [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] queries.|  
|[How to: Retrieve a Collection of Elements (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-a-collection-of-elements-linq-to-xml.md)|Introduces the <xref:System.Xml.Linq.XContainer.Elements%2A> method. This method retrieves a collection of the child elements of an element.|  
|[How to: Retrieve the Value of an Element (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-the-value-of-an-element-linq-to-xml.md)|Shows how to get the values of elements.|  
|[How to: Filter on Element Names (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-filter-on-element-names-linq-to-xml.md)|Shows how to filter on element names when using axes.|  
|[How to: Chain Axis Method Calls (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-chain-axis-method-calls-linq-to-xml.md)|Shows how to chain calls to axes methods.|  
|[How to: Retrieve a Single Child Element (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-a-single-child-element-linq-to-xml.md)|Shows how to retrieve a single child element of an element, given the tag name of the child element.|  
|[How to: Retrieve a Collection of Attributes (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-a-collection-of-attributes-linq-to-xml.md)|Introduces the <xref:System.Xml.Linq.XElement.Attributes%2A> method. This method retrieves the attributes of an element.|  
|[How to: Retrieve a Single Attribute (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-a-single-attribute-linq-to-xml.md)|Shows how to retrieve a single attribute of an element, given the attribute name.|  
|[How to: Retrieve the Value of an Attribute (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-the-value-of-an-attribute-linq-to-xml.md)|Shows how to get the values of attributes.|  
|[How to: Retrieve the Shallow Value of an Element (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-retrieve-the-shallow-value-of-an-element.md)|Shows how to retrieve the shallow value of an element.|  
|[Language-Integrated Axes in Visual Basic (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/language-integrated-axes.md)|Summarizes the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] integrated axes.|  
  
## See Also  
 [Programming Guide (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/programming-guide-linq-to-xml.md)

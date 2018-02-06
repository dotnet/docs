---
title: "LINQ to XML Overview (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 716b94d3-0091-4de1-8e05-41bc069fa9dd
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# LINQ to XML Overview (C#)
XML has been widely adopted as a way to format data in many contexts. For example, you can find XML on the Web, in configuration files, in Microsoft Office Word files, and in databases.  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is an up-to-date, redesigned approach to programming with XML. It provides the in-memory document modification capabilities of the Document Object Model (DOM), and supports [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expressions. Although these query expressions are syntactically different from XPath, they provide similar functionality.  
  
## LINQ to XML Developers  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] targets a variety of developers. For an average developer who just wants to get something done, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] makes XML easier by providing a query experience that is similar to SQL. With just a bit of study, programmers can learn to write succinct and powerful queries in their programming language of choice.  
  
 Professional developers can use [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] to greatly increase their productivity. With [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], they can write less code that is more expressive, more compact, and more powerful. They can use query expressions from multiple data domains at the same time.  
  
## What Is LINQ to XML?  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is a LINQ-enabled, in-memory XML programming interface that enables you to work with XML from within the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] programming languages.  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is like the Document Object Model (DOM) in that it brings the XML document into memory. You can query and modify the document, and after you modify it you can save it to a file or serialize it and send it over the Internet. However, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] differs from DOM: It provides a new object model that is lighter weight and easier to work with, and that takes advantage of language features in C#.  
  
 The most important advantage of [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is its integration with [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)]. This integration enables you to write queries on the in-memory XML document to retrieve collections of elements and attributes. The query capability of [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is comparable in functionality (although not in syntax) to XPath and XQuery. The integration of [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] in C# provides stronger typing, compile-time checking, and improved debugger support.  
  
 Another advantage of [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is the ability to use query results as parameters to <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XAttribute> object constructors enables a powerful approach to creating XML trees. This approach, called *functional construction*, enables developers to easily transform XML trees from one shape to another.  
  
 For example, you might have a typical XML purchase order as described in [Sample XML File: Typical Purchase Order (LINQ to XML)](http://msdn.microsoft.com/library/0606c09f-6e43-4f8d-95c8-e8e2e08d2348). By using [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], you could run the following query to obtain the part number attribute value for every item element in the purchase order:  
  
```csharp  
IEnumerable<string> partNos =  
from item in purchaseOrder.Descendants("Item")  
select (string) item.Attribute("PartNumber");  
```  
  
 As another example, you might want a list, sorted by part number, of the items with a value greater than $100. To obtain this information, you could run the following query:  
  
```csharp  
IEnumerable<XElement> partNos =  
from item in purchaseOrder.Descendants("Item")  
where (int) item.Element("Quantity") *  
    (decimal) item.Element("USPrice") > 100  
orderby (string)item.Element("PartNumber")  
select item;  
```  
  
 In addition to these [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] capabilities, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] provides an improved XML programming interface. Using [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], you can:  
  
-   Load XML from files or streams.  
  
-   Serialize XML to files or streams.  
  
-   Create XML from scratch by using functional construction.  
  
-   Query XML using XPath-like axes.  
  
-   Manipulate the in-memory XML tree by using methods such as <xref:System.Xml.Linq.XContainer.Add%2A>, <xref:System.Xml.Linq.XNode.Remove%2A>, <xref:System.Xml.Linq.XNode.ReplaceWith%2A>, and <xref:System.Xml.Linq.XElement.SetValue%2A>.  
  
-   Validate XML trees using XSD.  
  
-   Use a combination of these features to transform XML trees from one shape into another.  
  
## Creating XML Trees  
 One of the most significant advantages of programming with [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is that it is easy to create XML trees. For example, to create a small XML tree, you can write code as follows:  
  
```csharp  
XElement contacts =  
new XElement("Contacts",  
    new XElement("Contact",  
        new XElement("Name", "Patrick Hines"),  
        new XElement("Phone", "206-555-0144",   
            new XAttribute("Type", "Home")),  
        new XElement("phone", "425-555-0145",  
            new XAttribute("Type", "Work")),  
        new XElement("Address",  
            new XElement("Street1", "123 Main St"),  
            new XElement("City", "Mercer Island"),  
            new XElement("State", "WA"),  
            new XElement("Postal", "68042")  
        )  
    )  
);  
```  
  
 For more information, see [Creating XML Trees (C#)](../../../../csharp/programming-guide/concepts/linq/creating-xml-trees.md).  
  
## See Also  
 <xref:System.Xml.Linq>  
 [Getting Started (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/getting-started-linq-to-xml.md)

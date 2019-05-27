---
title: "Processing XML Data In-Memory"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
ms.assetid: 1bbb4d05-ead7-4bda-8ece-f86d35c57ad4
author: "mairaw"
ms.author: "mairaw"
---
# Processing XML Data In-Memory
The Microsoft .NET Framework includes three models for processing XML data: the <xref:System.Xml.XmlDocument> class, the <xref:System.Xml.XPath.XPathDocument> class, and [LINQ to XML (C#)](../../../csharp/programming-guide/concepts/linq/linq-to-xml.md) and [LINQ to XML (Visual Basic)](../../../visual-basic/programming-guide/concepts/linq/linq-to-xml.md).  
  
 The <xref:System.Xml.XmlDocument> class implements the W3C document object model (DOM) level 1 core and the core DOM level 2 recommendations. The DOM is an in-memory (cache) tree representation of an XML document. With the <xref:System.Xml.XmlDocument> and its related classes, you can construct XML documents, load and access data, modify data, and save changes.  
  
 The <xref:System.Xml.XPath.XPathDocument> class is a read-only, in-memory data store that is based on the XPath data model. The <xref:System.Xml.XPath.XPathNavigator> class offers several editing options and navigation capabilities using a cursor model over XML documents contained in the read-only <xref:System.Xml.XPath.XPathDocument> class as well as the <xref:System.Xml.XmlDocument> class.  
  
 [LINQ to XML](../../../csharp/programming-guide/concepts/linq/linq-to-xml.md) is a model introduced in the .NET Framework version 3.5 for processing XML data. It's an in-memory model that leverages [Language-Integrated Query (LINQ)](../../../csharp/programming-guide/concepts/linq/index.md). LINQ extends the language syntax of C# and Visual Basic to provide new query capabilities.  
  
## In This Section  
 [Process XML Data Using the DOM Model](../../../../docs/standard/data/xml/process-xml-data-using-the-dom-model.md)  
 Discusses using the <xref:System.Xml.XmlDocument>, and its related classes to process XML data.  
  
 [Process XML Data Using the XPath Data Model](../../../../docs/standard/data/xml/process-xml-data-using-the-xpath-data-model.md)  
 Discusses using the <xref:System.Xml.XPath.XPathDocument>, <xref:System.Xml.XmlDocument>, and <xref:System.Xml.XPath.XPathNavigator> classes to process XML data.  
  
 [Process XML Data Using LINQ to XML](../../../../docs/standard/data/xml/process-xml-data-using-linq-to-xml.md)  
 Provides a brief overview of LINQ to XML and provides links to the LINQ to XML documentation.  
  
## Related Sections  
 [XML Documents and Data](../../../../docs/standard/data/xml/index.md)

---
title: "XML Processing Options"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 33ced8ee-1745-4e71-8dee-ebe70ec067c7
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XML Processing Options
See the following tables for a list of Microsoft technologies you can use to process XML data.  
  
## .NET Framework Options  
  
|**Option**|**Processing type**|**Description**|  
|----------------|-------------------------|---------------------|  
|[LINQ to XML](https://msdn.microsoft.com/library/f0fe21e9-ee43-4a55-b91a-0800e5782c13) <br />(<xref:System.Xml.Linq> namespace)|In-memory|-   Based on the .NET Framework Language-Integrated Query (LINQ) technology.<br />-   Provides query experience that is similar to SQL for objects, relational data, and XML data.<br />-   Provides inituive document creation and transformation capabilities.<br />-   Use this option if you're writing new code.|  
|<xref:System.Xml.XmlReader?displayProperty=nameWithType>|Stream-based|-   Provides a fast, non-cached, forward-only way to access XML data.<br />-   You can create objects by using the <xref:System.Xml.XmlReader.Create%2A?displayProperty=nameWithType> method, and specify the set of features to enable on the object by using the <xref:System.Xml.XmlReaderSettings> class.|  
|<xref:System.Xml.XmlWriter?displayProperty=nameWithType>|Stream-based|-   Provides a fast, non-cached, forward-only way to generate XML data.<br />-   You can create objects by using the <xref:System.Xml.XmlWriter.Create%2A?displayProperty=nameWithType> method, and specify the set of features to enable on the object by using the <xref:System.Xml.XmlWriterSettings> class.|  
|<xref:System.Xml.XmlDocument?displayProperty=nameWithType>|In-memory|-   Implements the [W3C Document Object Model (DOM) Level 1 Core](https://www.w3.org/TR/REC-DOM-Level-1/level-one-core.html) and [DOM Level 2 Core](https://www.w3.org/TR/DOM-Level-2-Core/) recommendations.<br />-   You can create, insert, remove, and modify nodes by using methods and properties based on the familiar DOM model.<br />-   Use this option if you're modifying existing code that utilizes the W3C DOM.|  
|<xref:System.Xml.XPath.XPathNavigator?displayProperty=nameWithType>|In-memory|-   Offers several editing options and navigation capabilities using a cursor model.<br />-   XML documents can be contained in an <xref:System.Xml.XPath.XPathDocument> or <xref:System.Xml.XmlDocument> object.<br />-   Provides excellent performance for read-only processing of XML.<br />-   Use this option if you're modifying existing code with XPath queries or XSLT transformations.|  
|<xref:System.Xml.Xsl.XslCompiledTransform>|In-memory|-   Provides options for transforming XML data using XSL transformations.<br />-   The [XSLT Compiler (xsltc.exe)](../../../../docs/standard/data/xml/xslt-compiler-xsltc-exe.md) lets you reference pre-compiled transformations in your app.|  
  
## Win32 and COM-based Options  
  
|**Option**|**Description**|  
|----------------|---------------------|  
|[XmlLite](https://msdn.microsoft.com/library/ms752872.aspx)|-   A fast, secure, non-caching, forward-only XML parser that helps you build high-performance XML apps.<br />-   Works with any language that can use dynamic link libraries (DLLs); we recommend using C++.|  
|[MSXML](https://msdn.microsoft.com/library/ms763742.aspx)|-   COM-based technology for processing XML that is included with the Windows operating system.<br />-   Provides a native implementation of the DOM with support for XPath and XSLT.<br />-   Contains the SAX2 event-based parser.|  
  
## See Also  
 [Process XML Data Using the DOM Model](../../../../docs/standard/data/xml/process-xml-data-using-the-dom-model.md)  
 [Process XML Data Using the XPath Data Model](../../../../docs/standard/data/xml/process-xml-data-using-the-xpath-data-model.md)  
 [XSLT Compiler (xsltc.exe)](../../../../docs/standard/data/xml/xslt-compiler-xsltc-exe.md)

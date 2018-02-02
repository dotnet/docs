---
title: "XSLT Transformations Over Different Stores"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 369850e9-004a-45d2-b5c3-5060d9135adb
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XSLT Transformations Over Different Stores
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslTransform> class is obsolete in the [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]. You can perform Extensible Stylesheet Language for Transformations (XSLT) transformations using the <xref:System.Xml.Xsl.XslCompiledTransform> class. See [Using the XslCompiledTransform Class](../../../../docs/standard/data/xml/using-the-xslcompiledtransform-class.md) and [Migrating From the XslTransform Class](../../../../docs/standard/data/xml/migrating-from-the-xsltransform-class.md) for more information.  
  
 The ADO.NET and the XML classes in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] provide a unified programming model to access data. That data is represented as both XML data, which is text delimited by tags, and relational data, which is tables consisting of rows and columns. The XML in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] reads XML data from any data stream into XML Document Object Model (DOM) node trees, where data can be accessed programmatically, while ADO.NET provides the means to access and manipulate relational data within a <xref:System.Data.DataSet> object.  
  
 The XML DOM provides access to data in XML documents and additional classes to read, write, and navigate in XML documents. These classes are supported in the <xref:System.Xml> namespace, which also unifies the XML DOM with the data access services provided by ADO.NET. The <xref:System.Xml.XmlDataDocument> provides relational access to data. The <xref:System.Xml.XmlDataDocument> maps XML to relational data in an ADO.NET <xref:System.Data.DataSet>. Any [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]-based application can use the classes in the <xref:System.Xml> namespace to access and manipulate both XML documents and relational data in the <xref:System.Xml.XmlDataDocument>. This implementation supports n-tiered architectures for collecting and distributing data. For more information, see [XML Integration with Relational Data and ADO.NET](../../../../docs/standard/data/xml/xml-integration-with-relational-data-and-adonet.md).  
  
## See Also  
 [XslTransform Class Implements the XSLT Processor](../../../../docs/standard/data/xml/xsltransform-class-implements-the-xslt-processor.md)

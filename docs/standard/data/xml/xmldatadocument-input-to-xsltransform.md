---
title: "XmlDataDocument Input to XslTransform"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a0b536b6-cdb3-4a44-86c2-3b2ebc7bd4c9
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XmlDataDocument Input to XslTransform
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslTransform> class is obsolete in the [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]. You can perform Extensible Stylesheet Language for Transformations (XSLT) transformations using the <xref:System.Xml.Xsl.XslCompiledTransform> class. See [Using the XslCompiledTransform Class](../../../../docs/standard/data/xml/using-the-xslcompiledtransform-class.md) and [Migrating From the XslTransform Class](../../../../docs/standard/data/xml/migrating-from-the-xsltransform-class.md) for more information.  
  
 The Microsoft [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] implements the XML Document Object Model (DOM) to provide access to data in XML documents and additional classes to read, write, and navigate in XML documents. The <xref:System.Xml.XmlDataDocument>, found in the <xref:System.Xml> namespace, provides relational access to data with its ability to synchronize with the relational data in the <xref:System.Data.DataSet>. You can simultaneously view and manipulate structured XML through the relational representation of the <xref:System.Data.DataSet> or manipulate the semi-structured XML through the DOM representation of the <xref:System.Xml.XmlDataDocument>. The <xref:System.Xml.XmlDataDocument> therefore crosses the boundaries of the XML and the relational worlds.  
  
 If data is stored in a relational structure and you want it to be input to an XSLT transformation, you can load the relational data into a <xref:System.Data.DataSet> and associate it with the <xref:System.Xml.XmlDataDocument>. The <xref:System.Xml.XPath.XPathNavigator>, the input to the <xref:System.Xml.Xsl.XslTransform>, is implemented on the <xref:System.Xml.XmlDataDocument> through the <xref:System.Xml.XPath.IXPathNavigable> interface. By taking relational data, loading it into a <xref:System.Data.DataSet>, and using the synchronizing within the <xref:System.Xml.XmlDataDocument>, the relational data can now have XSLT transformations performed on it.  
  
 For more information on applying a transform to relational data, see [Applying an XSLT Transform to a DataSet](../../../../docs/framework/data/adonet/dataset-datatable-dataview/applying-an-xslt-transform-to-a-dataset.md).  
  
## See Also  
 <xref:System.Xml.XmlDataDocument>  
 [DataSet and XmlDataDocument Synchronization](../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataset-and-xmldatadocument-synchronization.md)  
 [XSLT Transformations with the XslTransform Class](../../../../docs/standard/data/xml/xslt-transformations-with-the-xsltransform-class.md)  
 [XslTransform Class Implements the XSLT Processor](../../../../docs/standard/data/xml/xsltransform-class-implements-the-xslt-processor.md)  
 [XPathNavigator in Transformations](../../../../docs/standard/data/xml/xpathnavigator-in-transformations.md)  
 [XPathNodeIterator in Transformations](../../../../docs/standard/data/xml/xpathnodeiterator-in-transformations.md)  
 [XPathDocument Input to XslTransform](../../../../docs/standard/data/xml/xpathdocument-input-to-xsltransform.md)  
 [XmlDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldocument-input-to-xsltransform.md)

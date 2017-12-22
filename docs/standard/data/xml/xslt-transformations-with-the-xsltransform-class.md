---
title: "XSLT Transformations with the XslTransform Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 500335af-f9b5-413b-968a-e6d9a824478c
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XSLT Transformations with the XslTransform Class
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslTransform> class is obsolete in the [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]. You can perform Extensible Stylesheet Language for Transformations (XSLT) transformations using the <xref:System.Xml.Xsl.XslCompiledTransform> class. See [Using the XslCompiledTransform Class](../../../../docs/standard/data/xml/using-the-xslcompiledtransform-class.md) and [Migrating From the XslTransform Class](../../../../docs/standard/data/xml/migrating-from-the-xsltransform-class.md) for more information.  
  
 The goal of the XSLT is to transform the content of a source XML document into another document that is different in format or structure (for example, to transform XML into HTML for use on a Web site or to transform it into a document that contains only the fields required by an application). This transformation process is specified by the World Wide Web Consortium (W3C) XSLT version 1.0 recommendation located at www.w3.org/TR/xslt. In the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], the <xref:System.Xml.Xsl.XslTransform> class, found in the <xref:System.Xml.Xsl> namespace, is the XSLT processor that implements the functionality of this specification. There are a small number of features that have not been implemented from the W3C XSLT 1.0 recommendation, listed in [Outputs from an XslTransform](../../../../docs/standard/data/xml/outputs-from-an-xsltransform.md). The following figure shows the transformation architecture of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)].  
  
## Overview  
 ![XSLT Transformation Architecture](../../../../docs/standard/data/xml/media/xslttransformationswithxsltransformclass.gif "xsltTransformationsWithXslTransformClass")  
Transformation Architecture  
  
 The XSLT recommendation uses XML Path Language (XPath) to select parts of an XML document, where XPath is a query language used to navigate nodes of a document tree. As shown in the diagram, the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] implementation of XPath is used to select parts of XML stored in several classes, such as an <xref:System.Xml.XmlDocument>, an <xref:System.Xml.XmlDataDocument>, and an <xref:System.Xml.XPath.XPathDocument>. An <xref:System.Xml.XPath.XPathDocument> is an optimized XSLT data store, and when used with <xref:System.Xml.Xsl.XslTransform>, it provides XSLT transformations with good performance.  
  
 The following table list commonly uses classes when working with <xref:System.Xml.Xsl.XslTransform> and XPath and their function.  
  
|Class or Interface|Function|  
|------------------------|--------------|  
|<xref:System.Xml.XPath.XPathNavigator>|It is an API that provides a cursor style model for navigating over a store, along with XPath query support. It does not provide editing of the underlying store. For editing, use the <xref:System.Xml.XmlDocument> class.|  
|<xref:System.Xml.XPath.IXPathNavigable>|It is an interface that provides a `CreateNavigator` method to an <xref:System.Xml.XPath.XPathNavigator> for the store.|  
|<xref:System.Xml.XmlDocument>|It enables editing of this document. It implements <xref:System.Xml.XPath.IXPathNavigable>, allowing document-editing scenarios where XSLT transformations are subsequently required. For more information, see [XmlDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldocument-input-to-xsltransform.md).|  
|<xref:System.Xml.XmlDataDocument>|It is derived from the <xref:System.Xml.XmlDocument>. It bridges the relational and XML worlds by using a <xref:System.Data.DataSet> to optimize storage of structured data within the XML document according to specified mappings on the <xref:System.Data.DataSet>. It implements <xref:System.Xml.XPath.IXPathNavigable>, allowing scenarios where XSLT transformations can be performed over relational data retrieved from a database. For more information, see [XML Integration with Relational Data and ADO.NET](../../../../docs/standard/data/xml/xml-integration-with-relational-data-and-adonet.md).|  
|<xref:System.Xml.XPath.XPathDocument>|This class is optimized for <xref:System.Xml.Xsl.XslTransform> processing and XPath queries, and it provides a read-only high performance cache. It implements <xref:System.Xml.XPath.IXPathNavigable> and is the preferred store to use for XSLT transformations.|  
|<xref:System.Xml.XPath.XPathNodeIterator>|It provides navigation over XPath node sets. All XPath selection methods on the <xref:System.Xml.XPath.XPathNavigator> return an <xref:System.Xml.XPath.XPathNodeIterator>. Multiple <xref:System.Xml.XPath.XPathNodeIterator> objects can be created over the same store, each representing a selected set of nodes.|  
  
## MSXML XSLT Extensions  
 The `msxsl:script` and `msxsl:node-set` functions are the only Microsoft XML Core Services (MSXML) XSLT extensions supported by the <xref:System.Xml.Xsl.XslTransform> class.  
  
## Example  
 The following code example loads an XSLT style sheet, reads a file called mydata.xml into an <xref:System.Xml.XPath.XPathDocument>, and performs a transformation on the data on a fictitious file called myStyleSheet.xsl, sending the formatted output to the console.  
  
```vb  
Imports System  
Imports System.IO  
Imports System.Xml  
Imports System.Xml.XPath  
Imports System.Xml.Xsl  
  
Public Class Sample  
    Private filename As [String] = "mydata.xml"  
    Private stylesheet As [String] = "myStyleSheet.xsl"  
  
    Public Shared Sub Main()  
        Dim xslt As New XslTransform()  
        xslt.Load(stylesheet)  
        Dim xpathdocument As New XPathDocument(filename)  
        Dim writer As New XmlTextWriter(Console.Out)  
        writer.Formatting = Formatting.Indented  
  
        xslt.Transform(xpathdocument, Nothing, writer, Nothing)  
    End Sub 'Main  
End Class 'Sample  
```  
  
```csharp  
using System;  
using System.IO;  
using System.Xml;  
using System.Xml.XPath;  
using System.Xml.Xsl;  
  
public class Sample   
{  
    private const String filename = "mydata.xml";  
    private const String stylesheet = "myStyleSheet.xsl";  
  
    public static void Main()   
    {  
    XslTransform xslt = new XslTransform();  
    xslt.Load(stylesheet);  
    XPathDocument xpathdocument = new  
    XPathDocument(filename);  
    XmlTextWriter writer = new XmlTextWriter(Console.Out);  
    writer.Formatting=Formatting.Indented;  
  
    xslt.Transform(xpathdocument, null, writer, null);      
    }  
}  
```  
  
## See Also  
 <xref:System.Xml.Xsl.XslTransform>  
 [XslTransform Class Implements the XSLT Processor](../../../../docs/standard/data/xml/xsltransform-class-implements-the-xslt-processor.md)  
 [Implementation of Discretionary Behaviors in the XslTransform Class](../../../../docs/standard/data/xml/implementation-of-discretionary-behaviors-in-the-xsltransform-class.md)  
 [XPathNavigator in Transformations](../../../../docs/standard/data/xml/xpathnavigator-in-transformations.md)  
 [XPathNodeIterator in Transformations](../../../../docs/standard/data/xml/xpathnodeiterator-in-transformations.md)  
 [XPathDocument Input to XslTransform](../../../../docs/standard/data/xml/xpathdocument-input-to-xsltransform.md)  
 [XmlDataDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldatadocument-input-to-xsltransform.md)  
 [XmlDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldocument-input-to-xsltransform.md)

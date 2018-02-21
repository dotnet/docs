---
title: "Inputs to the XslCompiledTransform Class"
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
ms.assetid: 834049f1-ab41-449e-9f10-4a1d0701bc48
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Inputs to the XslCompiledTransform Class
The <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method accepts three input types for the source document: an object that implements the <xref:System.Xml.XPath.IXPathNavigable> interface, an <xref:System.Xml.XmlReader> object that reads the source document, or a string URI.  
  
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslCompiledTransform> class preserves white space by default. This is in accordance with section 3.4 of the W3C XSLT 1.0 recommendation (section 3.4, http://www.w3.org/TR/xslt.html#strip).  
  
## IXPathNavigable Interface  
 The <xref:System.Xml.XPath.IXPathNavigable> interface is implemented in the <xref:System.Xml.XmlNode> and <xref:System.Xml.XPath.XPathDocument> classes. These classes represent an in-memory cache of XML data.  
  
-   The <xref:System.Xml.XmlNode> class is based on the W3C Document Object Model (DOM) and includes editing capabilities.  
  
-   The <xref:System.Xml.XPath.XPathDocument> class is a read-only data store based on the XPath data model. <xref:System.Xml.XPath.XPathDocument> is the recommended class for XSLT processing. It provides faster performance when compared to the <xref:System.Xml.XmlNode> class.  
  
> [!NOTE]
>  Transformations apply to the document as a whole. In other words, if you pass in a node other than the document root node, this does not prevent the transformation process from accessing all nodes in the loaded document. To transform a node fragment, you must create an object containing just the node fragment, and pass that object to the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method. For more information, see [How to: Transform a Node Fragment](../../../../docs/standard/data/xml/how-to-transform-a-node-fragment.md).  
  
 The following example uses the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A?displayProperty=nameWithType> method to transform the books.xml file to the books.html file using the transform.xsl style sheet. The books.xml and transform.xsl files can be found in this topic: [How to: Perform an XSLT Transformation by Using an Assembly](../../../../docs/standard/data/xml/how-to-perform-an-xslt-transformation-by-using-an-assembly.md).  
  
 [!code-csharp[XslCompiledTransform.Transform2#1](../../../../samples/snippets/csharp/VS_Snippets_Data/XslCompiledTransform.Transform2/CS/Program.cs#1)]
 [!code-vb[XslCompiledTransform.Transform2#1](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XslCompiledTransform.Transform2/VB/Module1.vb#1)]  
  
## XmlReader Object  
 The <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method loads from the current node of the <xref:System.Xml.XmlReader> through all its children. This enables you to use a portion of a document as the context document. After the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method returns, the <xref:System.Xml.XmlReader> is positioned on the next node after the end of the context document. If the end of the document is reached, the <xref:System.Xml.XmlReader> is positioned at the end of file (EOF).  
  
 The following example uses the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A?displayProperty=nameWithType> method to transform the books.xml file to the books.html file using the transform.xsl style sheet. The books.xml and transform.xsl files can be found in this topic: [How to: Perform an XSLT Transformation by Using an Assembly](../../../../docs/standard/data/xml/how-to-perform-an-xslt-transformation-by-using-an-assembly.md).  
  
 [!code-csharp[XslCompiledTransform.Transform2#2](../../../../samples/snippets/csharp/VS_Snippets_Data/XslCompiledTransform.Transform2/CS/Program.cs#2)]
 [!code-vb[XslCompiledTransform.Transform2#2](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XslCompiledTransform.Transform2/VB/Module1.vb#2)]  
  
## String URI  
 You can also specify the source document URI as your XSLT input. An <xref:System.Xml.XmlResolver> is used to resolve the URI. You can specify the <xref:System.Xml.XmlResolver> to use by passing it to the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method. If an <xref:System.Xml.XmlResolver> is not specified, the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method uses a default <xref:System.Xml.XmlUrlResolver> with no credentials.  
  
 The following example uses the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A?displayProperty=nameWithType> method to transform the books.xml file to the books.html file using the transform.xsl style sheet. The books.xml and transform.xsl files can be found in this topic: [How to: Perform an XSLT Transformation by Using an Assembly](../../../../docs/standard/data/xml/how-to-perform-an-xslt-transformation-by-using-an-assembly.md).  
  
 [!code-csharp[XslCompiledTransform.Transform2#3](../../../../samples/snippets/csharp/VS_Snippets_Data/XslCompiledTransform.Transform2/CS/Program.cs#3)]
 [!code-vb[XslCompiledTransform.Transform2#3](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XslCompiledTransform.Transform2/VB/Module1.vb#3)]  
  
 For more information, see [Resolving External Resources During XSLT Processing](../../../../docs/standard/data/xml/resolving-external-resources-during-xslt-processing.md).  
  
## See Also  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)

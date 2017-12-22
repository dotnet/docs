---
title: "Implementation of Discretionary Behaviors in the XslTransform Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d2758ea1-03f6-47bd-88d2-0fb7ccdb2fab
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Implementation of Discretionary Behaviors in the XslTransform Class
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslTransform> class is obsolete in the [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]. You can perform Extensible Stylesheet Language for Transformations (XSLT) transformations using the <xref:System.Xml.Xsl.XslCompiledTransform> class. See [Using the XslCompiledTransform Class](../../../../docs/standard/data/xml/using-the-xslcompiledtransform-class.md) and [Migrating From the XslTransform Class](../../../../docs/standard/data/xml/migrating-from-the-xsltransform-class.md) for more information.  
  
 Discretionary behaviors are described as behaviors listed in the World Wide Web Consortium (W3C) XSL Transformations (XSLT) Version 1.0 Recommendation (www.w3.org/TR/xslt), in which the implementation provider chooses one of several possible options as a way to handle a situation. For example, in section 7.3 Creating Processing Instructions, the W3C Recommendation says that it is an error if instantiating the content of `xsl:processing-instruction` creates nodes other than text nodes. For some problems, the W3C tells what decision should be made if the processor decides to recover from the error. For the problem given in section 7.3, the W3C says that the implementation can recover from this error by ignoring the nodes and their content.  
  
 Therefore, for each of the discretionary behaviors allowed by the W3C, the table below lists the discretionary behaviors implemented for the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] implementation of the <xref:System.Xml.Xsl.XslTransform> class, and what section in the W3C XSLT 1.0 Recommendation that this problem is discussed.  
  
|Problem|Behavior|Section|  
|-------------|--------------|-------------|  
|A text node matches both `xsl:strip-space` and `xsl:preserve-space`.|Recover|3.4|  
|A source node matches more than one template rule.|Recover|5.5|  
|A namespace Uniform Resource Identifier (URI) is declared to be an alias for multiple namespace URIs, all having the same import precedence.|Recover|7.1.1|  
|The name attribute in `xsl:attribute` and `xsl:element` generated from an attribute value template is not a valid qualified name (QName).|Exception thrown|7.1.2 and 7.1.3|  
|Adding an attribute to an element after child nodes have already been added to the element node.|Recover|7.1.3|  
|Adding an attribute to anything other than an element node.|Recover|7.1.3|  
|Instantiation of the content of the `xsl:attribute` element is not a text node.|Recover|7.1.3|  
|Two attribute sets have the same import precedence and expanded name. Both have the same attribute, and there is no other attribute set containing the common attribute with the same name with higher importance.|Recover|7.1.4|  
|`xsl:processing-instruction` name attribute does not yield both a no-colon name (NCName) and a Processing Instruction target.|Recover|7.3|  
|Instantiating the content of `xsl:processing-instruction` creates nodes other than text nodes.|Recover|7.3|  
|Results of instantiating the content of the `xsl:processing-instruction` contains the string "`?>`".|Recover|7.3|  
|Results of instantiating the content of the `xsl:comment` contains the string "--", or ends with "-".|Recover|7.4|  
|Results of instantiating the content of the `xsl:comment` creates nodes other than text nodes.|Recover|7.4|  
|The template within a variable-binding element returns an attribute node or a namespace node.|Recover|11.2|  
|There is an error retrieving the resource from the URI passed into the document function.|Exception thrown|12.1|  
|The URI reference in the document function contains a fragment identifier, and there is an error processing the fragment identifier.|Exception thrown|12.1|  
|There are multiple attributes with the same name that are not named `cdata-section-elements` in `xls:output`, and these attributes have the same import precedence.|Recover|16|  
|The processor does not support the character encoding value given in the `encoding` attribute of the `xsl:output` element.|Recover|16.1|  
|`disable-output-escaping` is used for a text node, and that text node is used to create something other than a text node in the result tree.|`disable-output-escaping` attribute is ignored|16.4|  
|Converting a result tree fragment to a number or string if the result tree fragment contains a text node with output escaping enabled.|Ignored|16.4|  
|Output escaping is disabled for characters that cannot be represented in the encoding that the XSLT processor is using for output.|Ignored|16.4|  
|Adding a namespace node to an element after children have been added to it or after attributes have been added to it|Recover|Errata e25|  
|`xsl:number` is NaN, infinite, or less than 0.5.|Recover|Errata e24|  
|The second argument node-set to the document function is empty and the URI reference is relative|Recover|Errata e14|  
  
 Sections from the errata can be found in the World Wide Web Consortium (W3C) XSL Transformations (XSLT) Version 1.0 Specification Errata, located at www.w3.org/1999/11/REC-xslt-19991116-errata.  
  
## Custom-Defined Implementation Behaviors  
 There are behaviors unique to the <xref:System.Xml.Xsl.XslTransform> class implementation. This section discusses the provider-specific implementation of the `xsl:sort` and optional features that are supported by the <xref:System.Xml.Xsl.XslTransform> class.  
  
## xsl:sort  
 When using a transformation to sort, the W3C XSLT 1.0 Recommendation makes some observations. They are:  
  
-   Two XSLT processors may be conforming processors, but still may sort differently.  
  
-   Not all XSLT processors support the same languages.  
  
-   With regard to languages, different processors may vary on their sorting on a particular language not specified on the `xsl:sort.`  
  
 The following table shows the sorting behavior implemented for each data type in the .NET Framework implementation of a transformation using <xref:System.Xml.Xsl.XslTransform>.  
  
|Data type|Sorting behavior|  
|---------------|----------------------|  
|Text|Data is sorted using the common language runtime (CLR) String.Compare method, and the cultural locale. When the data type equals "text", sorting in the <xref:System.Xml.Xsl.XslTransform> class behaves identically to the string comparison behaviors of the CLR.|  
|Number|Numeric values are treated as XML Path Language (XPath) numbers and are sorted according to the details outlined in the W3C XML Path Language (XPath) Version 1.0 Recommendation, Section 3.5 (www.w3.org/TR/xpath.html#numbers).|  
  
## Optional Features Supported  
 The following table shows the features that are optional for an XSLT processor to implement and are implemented in the <xref:System.Xml.Xsl.XslTransform> class.  
  
|Feature|Reference location|Notes|  
|-------------|------------------------|-----------|  
|`disable-output-escaping` attribute on `<xsl:text...>` and `<xsl:value-of...>` tags.|W3C XSLT 1.0 Recommendation,<br /><br /> Section 16.4|The `disable-output-escaping` attribute is ignored when the `xsl:text` or `xsl:value-of` elements are used in an `xsl:comment`, `xsl:processing-instruction`, or `xsl:attribute` element.<br /><br /> Result tree fragments that contain text and the text output that has been escaped are not supported.<br /><br /> The disable-output-escaping attribute is ignored when transforming to an <xref:System.Xml.XmlReader> or <xref:System.Xml.XmlWriter> object.|  
  
## See Also  
 <xref:System.Xml.Xsl.XslTransform>  
 [XslTransform Class Implements the XSLT Processor](../../../../docs/standard/data/xml/xsltransform-class-implements-the-xslt-processor.md)  
 [XSLT Transformations with the XslTransform Class](../../../../docs/standard/data/xml/xslt-transformations-with-the-xsltransform-class.md)  
 [XPathNavigator in Transformations](../../../../docs/standard/data/xml/xpathnavigator-in-transformations.md)  
 [XPathNodeIterator in Transformations](../../../../docs/standard/data/xml/xpathnodeiterator-in-transformations.md)  
 [XPathDocument Input to XslTransform](../../../../docs/standard/data/xml/xpathdocument-input-to-xsltransform.md)  
 [XmlDataDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldatadocument-input-to-xsltransform.md)  
 [XmlDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldocument-input-to-xsltransform.md)

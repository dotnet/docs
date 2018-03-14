---
title: "Resolving External XSLT Style Sheets and Documents"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 920cfe3b-d525-4bb2-abf6-9431651f9cf9
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Resolving External XSLT Style Sheets and Documents
There are several times during a transformation when you may need to resolve external resources.  
  
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslTransform> class is obsolete in the [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]. You can perform Extensible Stylesheet Language for Transformations (XSLT) transformations using the <xref:System.Xml.Xsl.XslCompiledTransform> class.  
  
 There are several times during a transformation when you may need to resolve external resources:  
  
-   During the <xref:System.Xml.Xsl.XslTransform.Load%2A> to locate an external style sheet.  
  
-   During <xref:System.Xml.Xsl.XslTransform.Load%2A> to resolve any `<xsl:include>` or `<xsl:import>` elements found in the style sheet.  
  
-   During <xref:System.Xml.Xsl.XslTransform.Transform%2A> to resolve any `document()` functions.  
  
## Using the XmlResolver Class  
 If authentication is required to access a network resource, use the <xref:System.Xml.Xsl.XslTransform.Load%2A> methods that have an <xref:System.Xml.XmlResolver> parameter to pass the <xref:System.Xml.XmlResolver> object, which has the necessary credential properties set.  
  
 If you have a custom <xref:System.Xml.XmlResolver> that you want to use, or if you need to specify different credentials, the following table lists the task required, depending on when the external resource needs resolution.  
  
|What process requires resolution|Task required|  
|--------------------------------------|-------------------|  
|During <xref:System.Xml.Xsl.XslTransform.Load%2A> to locate the style sheet.|Specify the overloaded <xref:System.Xml.Xsl.XslTransform.Load%2A> method that takes, as a parameter, an <xref:System.Xml.XmlResolver> if the style sheet is on a resource that requires credentials.|  
|During <xref:System.Xml.Xsl.XslTransform.Load%2A> to resolve `<xsl:include>` or `<xsl:import>`.|Specify the overloaded <xref:System.Xml.Xsl.XslTransform.Load%2A> method that takes, as a parameter, an <xref:System.Xml.XmlResolver>. The <xref:System.Xml.XmlResolver> is used to load the style sheets referenced by the `import` or `include` statements. If you pass in `null`, the external resources are not resolved.|  
|During a transformation to resolve any `document()` functions.|Specify the <xref:System.Xml.XmlResolver> during the transformation by using the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method that takes an <xref:System.Xml.XmlResolver> argument.|  
  
 The `document()` function retrieves other XML resources from a style sheet, in addition to the initial XML data provided by the input stream. Since this function allows the inclusion of XML data that can be located elsewhere, an <xref:System.Xml.XmlResolver> with a `null` value supplied to the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method prevents the `document()` function from executing. If you want to use the `document()` function, use the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method that takes an <xref:System.Xml.XmlResolver> as a parameter, in addition to having the appropriate permission set.  
  
 For more information on the <xref:System.Xml.Xsl.XslTransform.Load%2A> method and its use of the <xref:System.Xml.XmlResolver>, see <xref:System.Xml.Xsl.XslTransform.Load%28System.String%2CSystem.Xml.XmlResolver%29?displayProperty=nameWithType>.  
  
 When the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method is called, permissions are calculated against the evidence provided at load time, and that permission set is assigned to the entire transformation process. If the `document()` function attempts to initiate an action that requires permissions not found in the set, an exception is thrown.  
  
## See Also  
 [XSLT Transformations with the XslTransform Class](../../../../docs/standard/data/xml/xslt-transformations-with-the-xsltransform-class.md)  
 [XslTransform Class Implements the XSLT Processor](../../../../docs/standard/data/xml/xsltransform-class-implements-the-xslt-processor.md)  
 [Outputs from an XslTransform](../../../../docs/standard/data/xml/outputs-from-an-xsltransform.md)  
 [XSLT Transformations Over Different Stores](../../../../docs/standard/data/xml/xslt-transformations-over-different-stores.md)  
 [XsltArgumentList for Style Sheet Parameters and Extension Objects](../../../../docs/standard/data/xml/xsltargumentlist-for-style-sheet-parameters-and-extension-objects.md)  
 [XSLT Stylesheet Scripting Using \<msxsl:script>](../../../../docs/standard/data/xml/xslt-stylesheet-scripting-using-msxsl-script.md)  
 [Support for the msxsl:node-set() Function](../../../../docs/standard/data/xml/support-for-the-msxsl-node-set-function.md)  
 [XPathNavigator in Transformations](../../../../docs/standard/data/xml/xpathnavigator-in-transformations.md)  
 [XPathNodeIterator in Transformations](../../../../docs/standard/data/xml/xpathnodeiterator-in-transformations.md)  
 [XPathDocument Input to XslTransform](../../../../docs/standard/data/xml/xpathdocument-input-to-xsltransform.md)  
 [XmlDataDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldatadocument-input-to-xsltransform.md)  
 [XmlDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldocument-input-to-xsltransform.md)

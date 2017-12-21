---
title: "XslTransform Class Implements the XSLT Processor"
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
ms.assetid: 88373fe2-4a6b-44f9-8a62-8a3e348e3a46
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XslTransform Class Implements the XSLT Processor
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslTransform> class is obsolete in the [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]. You can perform Extensible Stylesheet Language for Transformations (XSLT) transformations using the <xref:System.Xml.Xsl.XslCompiledTransform> class. See [Using the XslCompiledTransform Class](../../../../docs/standard/data/xml/using-the-xslcompiledtransform-class.md) and [Migrating From the XslTransform Class](../../../../docs/standard/data/xml/migrating-from-the-xsltransform-class.md) for more information.  
  
 The <xref:System.Xml.Xsl.XslTransform> class is an XSLT processor implementing the XSL Transformations (XSLT) Version 1.0 recommendation. The <xref:System.Xml.Xsl.XslTransform.Load%2A> method locates and reads style sheets, and the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method transforms the given source document. Any store that implements the <xref:System.Xml.XPath.IXPathNavigable> interface can be used as the source document for the <xref:System.Xml.Xsl.XslTransform>. The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] currently implements the <xref:System.Xml.XPath.IXPathNavigable> interface on the <xref:System.Xml.XmlDocument>, the <xref:System.Xml.XmlDataDocument>, and the <xref:System.Xml.XPath.XPathDocument>, so all of these can be used as the input source document to a transformation.  
  
 The <xref:System.Xml.Xsl.XslTransform> object in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] only supports the XSLT 1.0 specification, defined with the following namespace:  
  
```xml  
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">    
```  
  
 The style sheet can be loaded, using the <xref:System.Xml.Xsl.XslTransform.Load%2A> method, from one of the following classes:  
  
-   XPathNavigator  
  
-   XmlReader  
  
-   A string representing a URL  
  
 There is a different <xref:System.Xml.Xsl.XslTransform.Load%2A> method for each of the above input classes. Some methods take in a combination of one of these classes and the <xref:System.Xml.XmlResolver> class as arguments. The <xref:System.Xml.XmlResolver> locates resources referenced by `<xsl:import>` or `<xsl:include>` found in the style sheet. The following methods take a string, <xref:System.Xml.XmlReader>, or <xref:System.Xml.XPath.XPathNavigator> as input.  
  
```vb  
Overloads Public Sub Load(String)  
```  
  
```csharp  
public void Load(string);  
```  
  
```vb  
Overloads Public Sub Load(String, XmlResolver)  
```  
  
```csharp  
public void Load(string, XmlResolver);  
```  
  
```vb  
Overloads Public Sub Load(XmlReader, XmlResolver, Evidence)  
```  
  
```csharp  
public void Load(XmlReader, XmlResolver, Evidence);  
```  
  
```vb  
Overloads Public Sub Load(XPathNavigator, XmlResolver, Evidence)  
```  
  
```csharp  
public void Load(XPathNavigator, XmlResolver, Evidence);  
```  
  
 Most of the <xref:System.Xml.Xsl.XslTransform.Load%2A> methods shown above take an <xref:System.Xml.XmlResolver> as a parameter. The <xref:System.Xml.XmlResolver> is used to load the style sheet and any style sheet(s) referenced in xsl:import and xsl:include elements.  
  
 Most of the <xref:System.Xml.Xsl.XslTransform.Load%2A> methods also take evidence as a parameter. The evidence parameter is the <xref:System.Security.Policy.Evidence> that is associated with the style sheet. The security level of the style sheet affects the security level of any subsequent resources it references, such as the script it contains, any `document()` functions it uses, and any extension objects used by the <xref:System.Xml.Xsl.XsltArgumentList>.  
  
 If the style sheet is loaded using a <xref:System.Xml.Xsl.XslTransform.Load%2A> method that contains a URL parameter and no evidence is provided, the evidence of the style sheet is calculated by combining the given URL with its site and zone.  
  
 If no URI or evidence is provided, then the evidence set for the style sheet is fully trusted. Do not load style sheets from untrusted sources, or add untrusted extension objects into the <xref:System.Xml.Xsl.XsltArgumentList>.  
  
 For more information about security levels and evidence and how it affects scripting, see [XSLT Stylesheet Scripting Using \<msxsl:script>](../../../../docs/standard/data/xml/xslt-stylesheet-scripting-using-msxsl-script.md). For information about security levels and evidence and how it affects extension objects, see [XsltArgumentList for Style Sheet Parameters and Extension Objects](../../../../docs/standard/data/xml/xsltargumentlist-for-style-sheet-parameters-and-extension-objects.md).  
  
 For information about security levels and evidence and how it affects the `document()` function, see [Resolving External XSLT Style Sheets and Documents](../../../../docs/standard/data/xml/resolving-external-xslt-style-sheets-and-documents.md).  
  
 A style sheet can be supplied with a number of input parameters. The style sheet can also call functions on extension objects. Both parameters and extension objects are supplied to the style sheet using the <xref:System.Xml.Xsl.XsltArgumentList> class. For more information about the <xref:System.Xml.Xsl.XsltArgumentList>, see <xref:System.Xml.Xsl.XsltArgumentList>.  
  
## Recommended Secure Use of XslTransform Class  
 The security privileges of the style sheet depend on the evidence provided. The following table summarizes the location of the style sheet and gives an explanation of what type of evidence to give.  
  
-   The XSLT style sheet has no external references, or the style sheet comes from a code base that you trust.  
  
    -   Provide the evidence from your assembly:  
  
         `Dim xslt = New XslTransform() xslt.Load(stylesheet, resolver, Me.GetType().Assembly.Evidence)`  
  
         `XsltTransform xslt = new XslTransform();  xslt.Load(stylesheet, resolver, this.GetType().Assembly.Evidence);`  
  
-   The XSLT style sheet comes from an outside source. The origin of the source is known and there is a verifiable URI.  
  
    -   Create evidence using the URI.  
  
         `Dim xslt As New XslTransform() Dim ev As Evidence = XmlSecureResolver.CreateEvidenceForUrl(stylesheetUri) xslt.Load(stylesheet, resolver, evidence)`  
  
         `XslTransform xslt = new XslTransform(); Evidence ev = XmlSecureResolver.CreateEvidenceForUrl(stylesheetUri); xslt.Load(stylesheet, resolver, evidence);`  
  
-   The XSLT style sheet comes from an outside source. The origin of the source is not known.  
  
    -   Set evidence to `null`. Script blocks are not processed, the XSLT `document()` function is not supported, and privileged extension objects are disallowed.  
  
         Additionally, you can also set the `resolver` parameter to `null` This ensures that `xsl:import` and `xsl:include` elements are not processed.  
  
-   The XSLT style sheet comes from an outside source. The origin of the source is not known, but you require script support.  
  
    -   Request evidence from the caller.  
  
## Transformation of XML Data  
 Once a style sheet is loaded, the transformation starts by calling one of the <xref:System.Xml.Xsl.XslTransform.Transform%2A> methods and supplying an input source document. The <xref:System.Xml.Xsl.XslTransform.Transform%2A> method is overloaded to provide different transformation outputs. The transformation can result in the following output formats:  
  
-   <xref:System.Xml.XmlReader>  
  
-   <xref:System.Xml.XmlWriter>  
  
-   <xref:System.IO.TextWriter>  
  
-   <xref:System.IO.Stream>  
  
-   String URL of file  
  
 This last format, the string URL, provides for a commonly used scenario in transforming an input document located in a URL and writing the document to the output URL. This <xref:System.Xml.Xsl.XslTransform.Transform%2A> method is a convenience method to load an XML document from a file, perform the XSLT transformation, and write the output to a file. This prevents you from having to create and load the input source document, and then write to a file stream. The following code sample shows this use of the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method using the string URL as input and output:  
  
```vb  
Dim xsltransform As XslTransform = New XslTransform()  
xsltransform.Load("favorite.xsl")  
xsltransform.Transform("MyDocument.Xml", "TransformResult.xml", Nothing)  
```  
  
```csharp  
XslTransform xsltransform = new XslTransform();  
xsltransform.Load("favorite.xsl");  
xsltransform.Transform("MyDocument.xml", "TransformResult.xml", null);  
```  
  
## Transforming a Section of an XML Document  
 Transformations apply to the document as a whole. In other words, if you pass in a node other than the document root node, this does not prevent the transformation process from accessing all nodes in the loaded document. To transform a result tree fragment, you must create an <xref:System.Xml.XmlDocument> containing just the result tree fragment and pass that <xref:System.Xml.XmlDocument> to the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method. The following example performs a transformation on a result tree fragment.  
  
```vb  
Dim xslt As New XslTransform()  
xslt.Load("print_root.xsl")  
Dim doc As New XmlDocument()  
doc.Load("library.xml")  
' Create a new document containing just the result tree fragment.  
Dim testNode As XmlNode = doc.DocumentElement.FirstChild  
Dim tmpDoc As New XmlDocument()  
tmpDoc.LoadXml(testNode.OuterXml)  
' Pass the document containing the result tree fragment   
' to the Transform method.  
Console.WriteLine(("Passing " + tmpDoc.OuterXml + " to print_root.xsl"))  
xslt.Transform(tmpDoc, Nothing, Console.Out, Nothing)  
```  
  
```csharp  
XslTransform xslt = new XslTransform();       
xslt.Load("print_root.xsl");  
XmlDocument doc = new XmlDocument();  
doc.Load("library.xml");  
// Create a new document containing just the result tree fragment.  
XmlNode testNode = doc.DocumentElement.FirstChild;   
XmlDocument tmpDoc = new XmlDocument();   
tmpDoc.LoadXml(testNode.OuterXml);  
// Pass the document containing the result tree fragment   
// to the Transform method.  
Console.WriteLine("Passing " + tmpDoc.OuterXml + " to print_root.xsl");  
xslt.Transform(tmpDoc, null, Console.Out, null);  
```  
  
 The example uses the library.xml and print_root.xsl files as input and outputs the following to the console.  
  
```  
Passing <book genre="novel" ISBN="1-861001-57-5"><title>Pride And Prejudice</title></book> to print_root.xsl   
Root node is book.  
```  
  
 library.xml  
  
```xml  
<library>  
  <book genre='novel' ISBN='1-861001-57-5'>  
     <title>Pride And Prejudice</title>  
  </book>  
  <book genre='novel' ISBN='1-81920-21-2'>  
     <title>Hook</title>  
  </book>  
</library>  
```  
  
 print_root.xsl  
  
```xml  
<stylesheet version="1.0" xmlns="http://www.w3.org/1999/XSL/Transform" >  
  <output method="text" />   
  <template match="/">  
     Root node is  <value-of select="local-name(//*[position() = 1])" />   
  </template>  
</stylesheet>  
```  
  
## Migration of XSLT from .NET Framework version 1.0 to .NET Framework version 1.1  
 The following table shows the obsolete [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] version 1.0 methods and new [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] version 1.1 methods for the <xref:System.Xml.Xsl.XslTransform.Load%2A> method. The new methods enable you to limit the permissions of the style sheet by specifying evidence.  
  
|Obsolete .NET Framework version 1.0 Load Methods|Replacement .NET Framework version 1.1 Load Methods|  
|------------------------------------------------------|---------------------------------------------------------|  
|Load(XPathNavigator input);<br /><br /> Load(XPathNavigator input, XmlResolver resolver);|Load(XPathNavigator stylesheet, XmlResolver resolver, Evidence evidence);|  
|Load(IXPathNavigable stylesheet);<br /><br /> Load(IXPathNavigable stylesheet, XmlResolver resolver);|Load(IXPathNavigable stylesheet, XmlResolver resolver, Evidence evidence);|  
|Load(XmlReader stylesheet);<br /><br /> Load(XmlReader stylesheet, XmlResolver resolver);|Load(XmlReader stylesheet, XmlResolver resolver, Evidence evidence);|  
  
 The following table shows the obsolete and new methods for the <xref:System.Xml.Xsl.XslTransform.Transform%2A> method. The new methods take an <xref:System.Xml.XmlResolver> object.  
  
|Obsolete .NET Framework version 1.0 Transform Methods|Replacement .NET Framework version Transform 1.1 Methods|  
|-----------------------------------------------------------|--------------------------------------------------------------|  
|XmlReader Transform(XPathNavigator input, XsltArgumentList args)|XmlReader Transform(XPathNavigator  input, XsltArgumentList args, XmlResolver resolver)|  
|XmlReader Transform(IXPathNavigable input, XsltArgumentList args)|XmlReader Transform(IXPathNavigable input, XsltArgumentList args, XmlResolver resolver)|  
|Void Transform(XPathNavigator input, XsltArgumentList args, XmlWriter output)|Void Transform(XPathNavigator input, XsltArgumentList args, XmlWriter output, XmlResolver resolver)|  
|Void Transform(IXPathNavigable input, XsltArgumentList args, XmlWriter output)|Void Transform(IXpathNavigable input, XsltArgumentList args, XmlWriter output, XmlResolver resolver)|  
|Void Transform(XPathNavigator input, XsltArgumentList args, TextWriter output)|Void Transform(XPathNavigator input, XsltArgumentList args, TextWriter output, XmlResolver resolver)|  
|Void Transform(IXPathNavigable input, XsltArgumentList args, TextWriter output)|Void Transform(IXPathNavigable input, XsltArgumentList args, TextWriter output, XmlResolver resolver)|  
|Void Transform(XPathNavigator input, XsltArgumentList args, Stream output)|Void Transform(XPathNavigator input, XsltArgumentList args, Stream output, XmlResolver resolver)|  
|Void Transform(IXPathNavigable input, XsltArgumentList args, Stream output)|Void Transform(IXPathNavigable input, XsltArgumentList args, Stream output, XmlResolver resolver)|  
|Void Transform(String input, String output);|Void Transform(String input, String output, XmlResolver resolver);|  
  
 The <xref:System.Xml.Xsl.XslTransform.XmlResolver%2A?displayProperty=nameWithType> property is obsolete in [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] version 1.1. Instead, use the new <xref:System.Xml.Xsl.XslTransform.Transform%2A> overloads which take an <xref:System.Xml.XmlResolver> object.  
  
## See Also  
 <xref:System.Xml.Xsl.XslTransform>  
 [XSLT Transformations with the XslTransform Class](../../../../docs/standard/data/xml/xslt-transformations-with-the-xsltransform-class.md)  
 [XPathNavigator in Transformations](../../../../docs/standard/data/xml/xpathnavigator-in-transformations.md)  
 [XPathNodeIterator in Transformations](../../../../docs/standard/data/xml/xpathnodeiterator-in-transformations.md)  
 [XPathDocument Input to XslTransform](../../../../docs/standard/data/xml/xpathdocument-input-to-xsltransform.md)  
 [XmlDataDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldatadocument-input-to-xsltransform.md)  
 [XmlDocument Input to XslTransform](../../../../docs/standard/data/xml/xmldocument-input-to-xsltransform.md)

---
description: "Learn more about: Using the XslCompiledTransform Class"
title: "Using the XslCompiledTransform Class"
ms.date: "03/30/2017"
ms.assetid: f9b074f6-d6f4-49dd-a093-df510bf0cf7b
---
# Using the XslCompiledTransform Class

The <xref:System.Xml.Xsl.XslCompiledTransform> class is the Microsoft .NET Framework XSLT processor. This class is used to compile style sheets and execute XSLT transformations.  
  
> [!NOTE]
> Although the overall performance of the <xref:System.Xml.Xsl.XslCompiledTransform> class is better than the <xref:System.Xml.Xsl.XslTransform> class, the <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> method of the <xref:System.Xml.Xsl.XslCompiledTransform> class might perform more slowly than the <xref:System.Xml.Xsl.XslTransform.Load%2A> method of the <xref:System.Xml.Xsl.XslTransform> class the first time it is called on a transformation. This is because the XSLT file must be compiled before it is loaded. For more information, see the following blog post: [XslCompiledTransform Slower than XslTransform?](/archive/blogs/antosha/xslcompiledtransform-slower-than-xsltransform)  
  
## In This Section  

 [Inputs to the XslCompiledTransform Class](inputs-to-the-xslcompiledtransform-class.md)  
 Describes the available XSLT input options.  
  
 [Output Options on the XslCompiledTransform Class](output-options-on-the-xslcompiledtransform-class.md)  
 Describes the available XSLT output options.  
  
 [Resolving External Resources During XSLT Processing](resolving-external-resources-during-xslt-processing.md)  
 Discusses using the <xref:System.Xml.XmlResolver> class to resolve external resources.  
  
 [Extending XSLT Style Sheets](extending-xslt-style-sheets.md)  
 Discusses how XSLT extensions are supported.  
  
| Article | Description |  
|-|-|  
|[Recoverable XSLT Errors](recoverable-xslt-errors.md)|Lists discretionary behaviors allowed by the World Wide Web Consortium (W3C) XSLT 1.0 recommendation and describes how these behaviors are handled by the <xref:System.Xml.Xsl.XslCompiledTransform> class.|  
|[How to: Transform a Node Fragment](how-to-transform-a-node-fragment.md)|Describes how to transform a node fragment.|  
  
## Related Sections  

 [Migrating From the XslTransform Class](migrating-from-the-xsltransform-class.md)  
 Discusses how to migrate code from the <xref:System.Xml.Xsl.XslTransform> class  
  
## See also

- <xref:System.Xml.Xsl.XsltSettings>
- <xref:System.Xml.Xsl.XsltMessageEncounteredEventArgs>

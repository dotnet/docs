---
title: "XSLT Security Considerations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fea695be-617c-4977-9567-140e820436fc
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XSLT Security Considerations
The XSLT language has a rich set of features that give you a great deal of power and flexibility. It includes many features that, while useful, could also be exploited by outside sources. In order to use XSLT safely, you must understand the types of security issues that arise when using XSLT, and the basic strategies that you can employ to mitigate these risks.  
  
## XSLT Extensions  
 Two popular XSLT extensions are style sheet scripting and extension objects. These extensions allow the XSLT processor to execute code.  
  
-   Extension objects add programming capabilities to XSL transformations.  
  
-   Scripts can be embedded in the style sheet using the `msxsl:script` extension element.  
  
### Extension Objects  
 Extension objects are added using the <xref:System.Xml.Xsl.XsltArgumentList.AddExtensionObject%2A> method. The FullTrust permission set is required to support extension objects. This ensures that elevation of permissions does not happen when extension object code is executed. Attempting to call the <xref:System.Xml.Xsl.XsltArgumentList.AddExtensionObject%2A> method without FullTrust permissions results in a security exception being thrown.  
  
### Style Sheet Scripts  
 Scripts can be embedded in a style sheet using the `msxsl:script` extension element. Script support is an optional feature on the <xref:System.Xml.Xsl.XslCompiledTransform> class that is disabled by default. Scripting can be enabled by setting the <xref:System.Xml.Xsl.XsltSettings.EnableScript%2A?displayProperty=nameWithType> property to `true` and passing the <xref:System.Xml.Xsl.XsltSettings> object to the <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> method.  
  
#### Guidelines  
 Enable scripting only when the style sheet comes from a trusted source. If you cannot verify the source of the style sheet, or if the style sheet does not come from a trusted source, pass in `null` for the XSLT settings argument.  
  
## External Resources  
 The XSLT language has features such as `xsl:import`, `xsl:include`, or the `document()` function, where the processor needs to resolve URI references. The <xref:System.Xml.XmlResolver> class is used to resolve external resources. External resources may need to be resolved in the following two cases:  
  
-   When compiling a style sheet, the <xref:System.Xml.XmlResolver> is used for `xsl:import` and `xsl:include` resolution.  
  
-   When executing the transformation, the <xref:System.Xml.XmlResolver> is used to resolve the `document()` function.  
  
    > [!NOTE]
    >  The `document()` function is disabled by default on the <xref:System.Xml.Xsl.XslCompiledTransform> class. This feature can be enabled by setting the <xref:System.Xml.Xsl.XsltSettings.EnableDocumentFunction%2A?displayProperty=nameWithType> property to `true` and passing the <xref:System.Xml.Xsl.XsltSettings> object to the <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> method.  
  
 The <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> and <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> methods each include overloads that accept an <xref:System.Xml.XmlResolver> as one of its arguments. If an <xref:System.Xml.XmlResolver> is not specified, a default <xref:System.Xml.XmlUrlResolver> with no credentials is used.  
  
#### Guidelines  
 Enable the `document()` function only when the style sheet comes from a trusted source.  
  
 The following list describes when you may want to specify an <xref:System.Xml.XmlResolver> object:  
  
-   If the XSLT process needs to access a network resource that requires authentication, you can use an <xref:System.Xml.XmlResolver> with the necessary credentials.  
  
-   If you want to restrict the resources that the XSLT process can access, you can use an <xref:System.Xml.XmlSecureResolver> with the correct permission set. Use the <xref:System.Xml.XmlSecureResolver> class if you need to open a resource that you do not control, or that is untrusted.  
  
-   If you want to customize behavior, you can implement your own <xref:System.Xml.XmlResolver> class and use it to resolve resources.  
  
-   If you want to ensure that no external resources are accessed, you can specify `null` for the <xref:System.Xml.XmlResolver> argument.  
  
## See Also  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)  
 [Resolving External Resources During XSLT Processing](../../../../docs/standard/data/xml/resolving-external-resources-during-xslt-processing.md)  
 [Code Access Security](http://msdn.microsoft.com/library/23a20143-241d-4fe5-9d9f-3933fd594c03)

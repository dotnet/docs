---
title: "Resolving External Resources During XSLT Processing"
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
ms.assetid: 3a59d31c-0ec5-4de6-a2a9-558531c8116e
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Resolving External Resources During XSLT Processing
There are several times during an XSLT transformation when you may need to resolve external resources.  
  
## Using the XmlResolver Class  
 The <xref:System.Xml.XmlResolver> class is used to resolve external resources. The following table describes when the <xref:System.Xml.XmlResolver> becomes involved during XSLT processing.  
  
|XSLT task|What the XmlResolver is used for|  
|---------------|--------------------------------------|  
|Compile the style sheet.|Resolve the URI of the style sheet.<br /><br /> -and-<br /><br /> Resolve URI references in any `xsl:import` or `xsl:include` elements.|  
|Execute the style sheet.|Resolve the URI of the context document.<br /><br /> -and-<br /><br /> Resolve URI references in any XSLT `document()` functions.|  
  
 The <xref:System.Xml.Xsl.XslCompiledTransform.Load%2A> and <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> methods include overloads that take an <xref:System.Xml.XmlResolver> object as one of its arguments. If an <xref:System.Xml.XmlResolver> is not specified, a default <xref:System.Xml.XmlUrlResolver> with no credentials is used.  
  
 The following list describes when you may want to specify an <xref:System.Xml.XmlResolver> object:  
  
-   If the XSLT process needs to access a network resource that requires authentication, you can use an <xref:System.Xml.XmlResolver> with the necessary credentials.  
  
-   If you want to restrict the resources that the XSLT process can access, you can use an <xref:System.Xml.XmlSecureResolver> with the correct permission set. Use the <xref:System.Xml.XmlSecureResolver> class if you need to open a resource that you do not control, or that is untrusted.  
  
-   If you want to customize behavior, you can implement your own <xref:System.Xml.XmlResolver> class and use it to resolve resources.  
  
-   If you want to ensure that no external resources are accessed, you can specify `null` for the <xref:System.Xml.XmlResolver> argument.  
  
## Example  
 The following example compiles a style sheet that is stored on a network resource. An <xref:System.Xml.XmlUrlResolver> object specifies the credentials necessary to access the style sheet.  
  
 [!code-csharp[XslCompiledTransform.Load#11](../../../../samples/snippets/csharp/VS_Snippets_Data/XslCompiledTransform.Load/CS/Xslt_Load_v2.cs#11)]
 [!code-vb[XslCompiledTransform.Load#11](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XslCompiledTransform.Load/VB/Xslt_Load_v2.vb#11)]  
  
## See Also  
 <xref:System.Xml.Xsl.XslCompiledTransform>  
 <xref:System.Xml.Xsl.XsltSettings>  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)

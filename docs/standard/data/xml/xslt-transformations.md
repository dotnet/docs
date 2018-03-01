---
title: "XSLT Transformations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 202f8820-224c-494f-b61e-cd127eac6e03
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XSLT Transformations
The Extensible Stylesheet Language Transformation (XSLT) lets you transform the content of a source XML document into another document that is different in format or structure. For example, you can use XSLT to transform XML into HTML for use on a Web site or to transform it into a document that contains only the fields required by an application. This transformation process is specified by the [W3C XSL Transformations (XSLT) Version 1.0 recommendation](https://www.w3.org/TR/xslt-10/).  
  
 The <xref:System.Xml.Xsl.XslCompiledTransform> class is the XSLT processor in .NET. The <xref:System.Xml.Xsl.XslCompiledTransform> class supports the [W3C XSLT 1.0 recommendation](https://www.w3.org/TR/xslt-10/).  
  
> [!NOTE]
>  The <xref:System.Xml.Xsl.XslTransform> class is obsolete in .NET Framework version 2.0. The <xref:System.Xml.Xsl.XslCompiledTransform> class is a new implementation of the XSLT engine. It includes performance improvements and new security features. The recommended practice is to create XSLT applications using the <xref:System.Xml.Xsl.XslCompiledTransform> class.  
  
## In This Section  
 [Using the XslCompiledTransform Class](../../../../docs/standard/data/xml/using-the-xslcompiledtransform-class.md)  
 Provides information on using the <xref:System.Xml.Xsl.XslCompiledTransform> class.  
  
 [Migrating From the XslTransform Class](../../../../docs/standard/data/xml/migrating-from-the-xsltransform-class.md)  
 Discusses how to migrate code from the <xref:System.Xml.Xsl.XslTransform> class.  
  
 [XSLT Compiler (xsltc.exe)](../../../../docs/standard/data/xml/xslt-compiler-xsltc-exe.md)  
 Provides information on using the XSLT compiler.  
  
 [XSLT Transformations with the XslTransform Class](../../../../docs/standard/data/xml/xslt-transformations-with-the-xsltransform-class.md)  
 Provides information on using the <xref:System.Xml.Xsl.XslTransform> class.  
  
## Reference  
 <xref:System.Xml.Xsl.XslCompiledTransform>  
 <xref:System.Xml.Xsl.XsltArgumentList>  
 <xref:System.Xml.Xsl.XsltSettings>  
  
## Related Sections  
 [XML Documents and Data](../../../../docs/standard/data/xml/index.md)

---
title: "Output Options on the XslCompiledTransform Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 91ce8cba-386c-411e-bb38-0891a0393c0a
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Output Options on the XslCompiledTransform Class
This topic discusses the available XSLT output options. You can specify output options in the style sheet, or on the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method.  
  
## xsl:output Element  
 The `xsl:output` element specifies options for the output. The output type specified by the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method determines the behavior of the `xsl:output` options.  
  
 The following table describes the behavior for each of the attributes available on the `xsl:output` element when the output type is a stream or a <xref:System.IO.TextWriter>.  
  
|Attribute name|Behavior|  
|--------------------|--------------|  
|method|Supported.|  
|version|Ignored. The version is always 1.0 for XML and 4.0 for HTML.|  
|encoding|Ignored when outputting to a <xref:System.IO.TextWriter>. The <xref:System.IO.TextWriter.Encoding%2A?displayProperty=nameWithType> property is used instead.|  
|omit-xml-declaration|Supported.|  
|standalone|Supported.|  
|doctype-public|Supported.|  
|doctype-system|Supported.|  
|cdata-section-elements|Supported.|  
|indent|Supported.|  
|media-type|Supported.|  
  
#### Sending Output to an XmlWriter  
 If your style sheet uses the `xsl:output` element and the output type is an <xref:System.Xml.XmlWriter> object, you should use the <xref:System.Xml.Xsl.XslCompiledTransform.OutputSettings%2A?displayProperty=nameWithType> property when you create the <xref:System.Xml.XmlWriter> object. The <xref:System.Xml.Xsl.XslCompiledTransform.OutputSettings%2A?displayProperty=nameWithType> property returns an <xref:System.Xml.XmlWriterSettings> object that contains information derived from the `xsl:output` element of a compiled style sheet. This <xref:System.Xml.XmlWriterSettings> object can be passed to the <xref:System.Xml.XmlWriter.Create%2A?displayProperty=nameWithType> method to create an <xref:System.Xml.XmlWriter> object with the correct settings.  
  
## Output Types  
 The following list describes the output types available on the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> command.  
  
#### XmlWriter  
 The <xref:System.Xml.XmlWriter> class writes out XML streams or files. You can specify the features to support on the <xref:System.Xml.XmlWriter> object, including output options, by using the <xref:System.Xml.XmlWriterSettings> class. The <xref:System.Xml.XmlWriter> class is an integral part of the <xref:System.Xml> framework. Use this output type to pipeline the output results into another XML process.  
  
#### String  
 Use this output type to specify the URI of the output file.  
  
#### Stream  
 A stream is an abstraction of a sequence of bytes, such as a file, an input/output device, an inter-process communication pipe, or a TCP/IP socket. The <xref:System.IO.Stream> class and its derived classes provide a generic view of these different types of input and output, isolating the programmer from the specific details of the operating system and the underlying devices.  
  
 Use this output type to send data to a <xref:System.IO.FileStream>, <xref:System.IO.MemoryStream>, or an output stream (`Response.OutputStream`).  
  
#### TextWriter  
 The <xref:System.IO.TextWriter> writes sequential characters. It is implemented in the <xref:System.IO.StringWriter> and <xref:System.IO.StreamWriter> classes, which write characters to strings or streams, respectively. Use this output type when you want to output to a string.  
  
## Notes  
  
-   When writing out empty tags, a space is written between the last character of the element name and the backslash, `<myElement />` for example. This lets older browsers display the generated HTML pages correctly.  
  
## See Also  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)

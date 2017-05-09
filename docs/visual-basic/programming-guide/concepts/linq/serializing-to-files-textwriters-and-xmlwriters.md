---
title: "Serializing to Files, TextWriters, and XmlWriters3 | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
ms.assetid: 7a0c24df-79ef-41a0-87f5-e6cf79382da9
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Serializing to Files, TextWriters, and XmlWriters
You can serialize XML trees to a <xref:System.IO.File>, a <xref:System.IO.TextWriter>, or an <xref:System.Xml.XmlWriter>.  
  
 You can serialize any XML component, including <xref:System.Xml.Linq.XDocument> and <xref:System.Xml.Linq.XElement>, to a string by using the `ToString` method.  
  
 If you want to suppress formatting when serializing to a string, you can use the <xref:System.Xml.Linq.XNode.ToString%2A?displayProperty=fullName> method.  
  
 Thedefault behavior when serializing to a file is to format (indent) the resulting XML document. When you indent, the insignificant white space in the XML tree is not preserved. To serialize with formatting, use one of the overloads of the following methods that do not take <xref:System.Xml.Linq.SaveOptions> as an argument:  
  
-   <xref:System.Xml.Linq.XDocument.Save%2A?displayProperty=fullName>  
  
-   <xref:System.Xml.Linq.XElement.Save%2A?displayProperty=fullName>  
  
 If you want the option not to indent and to preserve the insignificant white space in the XML tree, use one of the overloads of the following methods that takes <xref:System.Xml.Linq.SaveOptions> as an argument:  
  
-   <xref:System.Xml.Linq.XDocument.Save%2A?displayProperty=fullName>  
  
-   <xref:System.Xml.Linq.XElement.Save%2A?displayProperty=fullName>  
  
 For examples, see the appropriate reference topic.  
  
## See Also  
 [Serializing XML Trees (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/serializing-xml-trees.md)
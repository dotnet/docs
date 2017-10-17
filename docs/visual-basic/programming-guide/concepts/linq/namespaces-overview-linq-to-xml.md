---
title: "Namespaces Overview (LINQ to XML)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b8eb31fa-4b26-4acf-8050-6e705687f458
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Namespaces Overview (LINQ to XML)
This topic introduces namespaces, the <xref:System.Xml.Linq.XName> class, and the <xref:System.Xml.Linq.XNamespace> class.  
  
## XML Names  
 XML names are often a source of complexity in XML programming. An XML name consists of an XML namespace (also called an XML namespace URI) and a local name. An XML namespace is similar to a namespace in a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)]-based program. It enables you to uniquely qualify the names of elements and attributes. This helps avoid name conflicts between various parts of an XML document. When you have declared an XML namespace, you can select a local name that only has to be unique within that namespace.  
  
 Another aspect of XML names is XML *namespace prefixes*. XML prefixes cause most of the complexity of XML names. These prefixes enable you to create a shortcut for an XML namespace, which makes the XML document more concise and understandable. However, XML prefixes depend on their context to have meaning, which adds complexity. For example, the XML prefix `aw` could be associated with one XML namespace in one part of an XML tree, and with a different XML namespace in a different part of the XML tree.  
  
 When using [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] with Visual Basic and XML literals, you must use namespace prefixes when working with documents in namespaces.  
  
 In [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], the class that represents XML names is <xref:System.Xml.Linq.XName>. XML names appear frequently throughout the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] API, and wherever an XML name is required, you will find an <xref:System.Xml.Linq.XName> parameter. However, you rarely work directly with an <xref:System.Xml.Linq.XName>. <xref:System.Xml.Linq.XName> contains an implicit conversion from string.  
  
 For more information, see <xref:System.Xml.Linq.XNamespace> and <xref:System.Xml.Linq.XName>.  
  
## See Also  
 [Working with XML Namespaces (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/working-with-xml-namespaces.md)

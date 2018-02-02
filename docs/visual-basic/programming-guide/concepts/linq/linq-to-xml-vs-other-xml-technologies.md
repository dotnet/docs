---
title: "LINQ to XML vs. Other XML Technologies2"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 72ce3a82-ffc6-488c-98e7-b9b40f3591ec
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ to XML vs. Other XML Technologies
This topic compares [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] to the following XML technologies: <xref:System.Xml.XmlReader>, XSLT, MSXML, and XmlLite. This information can help you decide which technology to use.  
  
 For a comparison of [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] to the Document Object Model (DOM), see [LINQ to XML vs. DOM (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-vs-dom.md).  
  
## LINQ to XML vs. XmlReader  
 <xref:System.Xml.XmlReader> is a fast, forward-only, non-caching parser.  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is implemented on top of <xref:System.Xml.XmlReader>, and they are tightly integrated. However, you can also use <xref:System.Xml.XmlReader> by itself.  
  
 For example, suppose you are building a Web service that will parse hundreds of XML documents per second, and the documents have the same structure, meaning that you only have to write one implementation of the code to parse the XML. In this case, you would probably want to use <xref:System.Xml.XmlReader> by itself.  
  
 In contrast, if you are building a system that parses many smaller XML documents, and each one is different, you would want to take advantage of the productivity improvements that [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] provides.  
  
## LINQ to XML vs. XSLT  
 Both [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] and XSLT provide extensive XML document transformation capabilities. XSLT is a rule-based, declarative approach. Advanced XSLT programmers write XSLT in a functional programming style that emphasizes a stateless approach. Transformations can be written using pure functions that are implemented without side effects. This rule-based or functional approach is unfamiliar to many developers, and can be difficult and time-consuming to learn.  
  
 XSLT can be a very productive system that yields high-performance applications. For example, some big Web companies use XSLT as a way to generate HTML from XML that has been pulled from a variety of data stores. The managed XSLT engine compiles XSLT to CLR code, and performs even better in some scenarios than the native XSLT engine.  
  
 However, XSLT does not take advantage of the C# and Visual Basic knowledge that many developers have. It requires developers to write code in a different and complex programming language. Using two non-integrated development systems such as C# (or Visual Basic) and XSLT results in software systems that are more difficult to develop and maintain.  
  
 After you have mastered [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] query expressions, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] transformations are a powerful technology that is easy to use. Basically, you form your XML document by using functional construction, pulling in data from various sources, constructing <xref:System.Xml.Linq.XElement> objects dynamically, and assembling the whole into a new XML tree. The transformation can generate a completely new document. Constructing transformations in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is relatively easy and intuitive, and the resulting code is readable. This reduces development and maintenance costs.  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is not intended to replace XSLT. XSLT is still the tool of choice for complicated and document-centric XML transformations, especially if the structure of the document is not well defined.  
  
 XSLT has the advantage of being a World Wide Web Consortium (W3C) standard. If you have a requirement that you use only technologies that are standards, XSLT might be more appropriate.  
  
 XSLT is XML, and therefore can be programmatically manipulated.  
  
## LINQ to XML vs. MSXML  
 MSXML is the COM-based technology for processing XML that is included with Microsoft Windows. MSXML provides a native implementation of the DOM with support for XPath and XSLT. It also contains the SAX2 non-caching, event-based parser.  
  
 MSXML performs well, is secure by default in most scenarios, and can be accessed in Internet Explorer for performing client-side XML processing in AJAX-style applications. MSXML can be used from any programming language that supports COM, including C++, JavaScript, and [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] 6.0.  
  
 MSXML is not recommended for use in managed code based on the common language runtime (CLR).  
  
## LINQ to XML vs. XmlLite  
 XmlLite is a non-caching, forward only, pull parser. Developers primarily use XmlLite with C++. It is not recommended for developers to use XmlLite with managed code.  
  
 The main advantage of XmlLite is that it is a lightweight, fast XML parser that is secure in most scenarios. Its threat surface area is very small. If you have to parse untrusted documents and you want to protect against attacks such as denial of service or exposure of data, XmlLite might be a good option.  
  
 XmlLite is not integrated with [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)]. It does not yield the programmer productivity improvements that are the motivating force behind [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)].  
  
## See Also  
 [Getting Started (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/getting-started-linq-to-xml.md)

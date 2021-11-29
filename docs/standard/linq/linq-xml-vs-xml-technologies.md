---
title: LINQ to XML vs. other XML technologies
description: Learn how LINQ to XML compares to XSLT, MSXML, and XmlLite, to make better technology choices.
ms.date: 07/20/2015
ms.assetid: 01b8e746-12d3-471d-b811-7539e4547784
---

# LINQ to XML vs. other XML technologies

This article compares LINQ to XML to the following XML technologies: <xref:System.Xml.XmlReader>, XSLT, MSXML, and XmlLite. This information can help you decide which technologies to use.

For a comparison of LINQ to XML to the Document Object Model (DOM), see [LINQ to XML vs. DOM](linq-xml-vs-dom.md).

## LINQ to XML vs. XmlReader

<xref:System.Xml.XmlReader> is a fast, forward-only, non-caching parser.

LINQ to XML is implemented on top of <xref:System.Xml.XmlReader>, and they're tightly integrated. However, you can also use <xref:System.Xml.XmlReader> directly.

For example, suppose you're building a Web service that will parse hundreds of XML documents per second, and the documents have the same structure, meaning that you only have to write one implementation of the code to parse the XML. In this case, you'd probably want to use <xref:System.Xml.XmlReader> directly.

In contrast, if you're building a system that parses many smaller XML documents, and each one is different, you'd want to take advantage of the productivity improvements that LINQ to XML provides.

## LINQ to XML vs. XSLT

Both LINQ to XML and XSLT provide extensive XML document transformation capabilities. XSLT is a rule-based, declarative approach. Advanced XSLT programmers write XSLT in a functional programming style that emphasizes a stateless approach. Transformations can be written using pure functions that are implemented without side effects. This rule-based or functional approach is unfamiliar to many developers, and can be difficult and time-consuming to learn.

XSLT can be a productive system that yields high-performance applications. For example, some large Web companies use XSLT as a way to generate HTML from XML that has been pulled from different kinds of data stores. The managed XSLT engine compiles XSLT to common language runtime (CLR) code, and performs even better in some scenarios than the native XSLT engine.

However, XSLT doesn't take advantage of the C# and Visual Basic knowledge that many developers have. It requires developers to write code in a different and complex programming language. Using two non-integrated development systems such as C# (or Visual Basic) and XSLT results in software systems that are more difficult to develop and maintain.

After you've become proficient in using LINQ to XML query expressions, LINQ to XML transformations are a powerful technology that's easy to use. Basically, you form your XML document by using functional construction, pulling in data from various sources, constructing <xref:System.Xml.Linq.XElement> objects dynamically, and assembling the whole into a new XML tree. The transformation can generate a completely new document. Constructing transformations in LINQ to XML is relatively easy and intuitive, and the resulting code is readable. This reduces development and maintenance costs.

LINQ to XML isn't intended to replace XSLT. XSLT is still the tool of choice for complicated and document-centric XML transformations, especially if the structure of the document isn't well defined.

XSLT has the advantage of being a World Wide Web Consortium (W3C) standard. If you have a requirement that you use only technologies that are standards, XSLT might be more appropriate.

XSLT is XML, and that's why it can be programmatically manipulated.

## LINQ to XML vs. MSXML

MSXML is the COM-based technology for processing XML that's included with Microsoft Windows. MSXML provides a native implementation of the DOM with support for XPath and XSLT. It also contains the SAX2 non-caching, event-based parser.

MSXML performs well, is secure by default in most scenarios, and can be accessed in Internet Explorer for doing client-side XML processing in AJAX-style applications. MSXML can be used from any programming language that supports COM, including C++, JavaScript, and Visual Basic 6.0.

MSXML isn't recommended for use in managed code based on the CLR.

## LINQ to XML vs. XmlLite

XmlLite is a non-caching, forward only, pull parser. Developers primarily use XmlLite with C++. It's not recommended for developers to use XmlLite with managed code.

The main advantage of XmlLite is that it's a lightweight, fast XML parser that's secure in most scenarios. Its threat surface area is small. If you have to parse untrusted documents and you want to protect against attacks such as denial of service or exposure of data, XmlLite might be a good option.

XmlLite isn't integrated with Language-Integrated Query (LINQ). It doesn't yield the programmer productivity improvements that are the motivating force behind LINQ.

## See also

- [LINQ to XML overview](linq-xml-overview.md)

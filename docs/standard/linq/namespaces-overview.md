---
title: Namespaces overview - LINQ to XML
description: Learn about XML names, XML namespaces, and XML namespace prefixes, and about the XName and XNamespace classes.
ms.date: 07/20/2015
ms.assetid: 16283322-8238-4918-ab11-802ac6748eb7
ms.topic: concept-article
---

# Namespaces overview (LINQ to XML)

This article introduces *XML names*, *XML namespaces*, *XML namespace prefixes*, and the <xref:System.Xml.Linq.XName> and <xref:System.Xml.Linq.XNamespace> classes.

XML names are often a source of complexity in XML programming. An XML name consists of an XML namespace (also called an XML namespace URI) and a local name. An XML namespace is similar to a namespace in a .NET program. It enables you to uniquely qualify the names of elements and attributes to avoid name conflicts between various parts of an XML document. When you've declared an XML namespace, you can select a local name that only has to be unique within that namespace.

Another aspect of XML names is XML namespace prefixes, which cause most of the complexity of XML names. These prefixes enable you to create a shortcut for an XML namespace, which makes the XML document more concise and understandable. However, the meaning of an XML prefix depends on context, which adds complexity. For example, the XML prefix `aw` could be associated with one XML namespace in part of an XML tree, and with a different namespace in another part.

One of the advantages of using LINQ to XML with C# is that you don't have to use XML prefixes. When LINQ to XML loads or parses an XML document, each XML prefix is resolved to its corresponding XML namespace. After that, when you work with a document that uses namespaces, you almost always access the namespaces through the namespace URI, and not through the namespace prefix. When developers work with XML names in LINQ to XML they always work with a fully-qualified XML name (that is, an XML namespace and a local name). However, LINQ to XML does allow you to work with and control namespace prefixes as needed.

When using LINQ to XML with Visual Basic and XML literals, you must use namespace prefixes when working with documents in namespaces.

In LINQ to XML, the class that represents XML names is <xref:System.Xml.Linq.XName>. XML names appear frequently throughout the LINQ to XML API, and wherever an XML name is required, you will find an <xref:System.Xml.Linq.XName> parameter. However, you rarely work directly with an <xref:System.Xml.Linq.XName>. <xref:System.Xml.Linq.XName> contains an implicit conversion from string.

For more information, see <xref:System.Xml.Linq.XNamespace> and <xref:System.Xml.Linq.XName>.

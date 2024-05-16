---
title: Preserve white space while loading or parsing XML - LINQ to XML
description: You can control the white space behavior of LINQ to XML methods that populate XML trees. For instance, you can remove indentation for in-memory processing, or leave it as is.
ms.date: 07/20/2015
ms.topic: how-to
---

# Preserve white space while loading or parsing XML (LINQ to XML)

This article describes how to control the white space behavior of LINQ to XML.

A common scenario is to read indented XML, create an in-memory XML tree without any white space text nodes (that is, not preserving white space), do some operations on the XML, and then save the XML with indentation. When you serialize the XML with formatting, only significant white space in the XML tree is preserved. This is the default behavior for LINQ to XML.

Another common scenario is to read and modify XML that has already been intentionally indented. You might not want to change this indentation in any way. To do this in LINQ to XML, you preserve white space when you load or parse the XML and disable formatting when you serialize the XML.

This article describes the white space behavior of methods that populate XML trees. For information about controlling white space when you serialize XML trees, see [Preserve white space while serializing](preserve-white-space-serializing.md).

## Behavior of methods that populate XML trees

The following methods in the <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XDocument> classes populate an XML tree. You can populate an XML tree from a file, a <xref:System.IO.TextReader>, an <xref:System.Xml.XmlReader>, or a string:

- <xref:System.Xml.Linq.XElement.Load%2A?displayProperty=nameWithType>
- <xref:System.Xml.Linq.XElement.Parse%2A?displayProperty=nameWithType>
- <xref:System.Xml.Linq.XDocument.Load%2A?displayProperty=nameWithType>
- <xref:System.Xml.Linq.XDocument.Parse%2A?displayProperty=nameWithType>

If the method doesn't take <xref:System.Xml.Linq.LoadOptions> as an argument, the method won't preserve insignificant white space.

In most cases, if the method takes <xref:System.Xml.Linq.LoadOptions> as an argument, you can optionally preserve insignificant white space as text nodes in the XML tree. However, if the method is loading the XML from an <xref:System.Xml.XmlReader>, then the <xref:System.Xml.XmlReader> determines whether white space will be preserved or not. Setting <xref:System.Xml.Linq.LoadOptions.PreserveWhitespace> will have no effect.

With these methods, if white space is preserved, insignificant white space is inserted into the XML tree as <xref:System.Xml.Linq.XText> nodes. If white space isn't preserved, text nodes aren't inserted.

You can create an XML tree by using an <xref:System.Xml.XmlWriter>. Nodes that are written to the <xref:System.Xml.XmlWriter> are populated in the tree. However, when you build an XML tree using this method, all nodes are preserved, regardless of whether the node is white space or not, or whether the white space is significant or not.

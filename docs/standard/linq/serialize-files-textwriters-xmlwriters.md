---
title: Serialize to files, TextWriters, and XmlWriters - LINQ to XML
description: You can serialize XML trees to a File, a TextWriter, or an XmlWriter, and you can serialize any XML component, including XDocument and XElement, to a string by using the ToString method.
ms.date: 07/20/2015
ms.topic: how-to
---

# Serialize to files, TextWriters, and XmlWriters (LINQ to XML)

You can serialize XML trees to a <xref:System.IO.File>, a <xref:System.IO.TextWriter>, or an <xref:System.Xml.XmlWriter>.

You can serialize any XML component, including <xref:System.Xml.Linq.XDocument> and <xref:System.Xml.Linq.XElement>, to a string by using the `ToString` method.

If you want to suppress formatting when serializing to a string, you can use the <xref:System.Xml.Linq.XNode.ToString%2A?displayProperty=nameWithType> method.

The default behavior when serializing to a file is to format (indent) the resulting XML document. When you indent, the insignificant white space in the XML tree isn't preserved. To serialize with formatting, use one of the overloads of the following methods that don't take <xref:System.Xml.Linq.SaveOptions> as an argument:

- <xref:System.Xml.Linq.XDocument.Save%2A?displayProperty=nameWithType>
- <xref:System.Xml.Linq.XElement.Save%2A?displayProperty=nameWithType>

If you want the option not to indent and to preserve the insignificant white space in the XML tree, use one of the overloads of the following methods that takes <xref:System.Xml.Linq.SaveOptions> as an argument:

- <xref:System.Xml.Linq.XDocument.Save%2A?displayProperty=nameWithType>
- <xref:System.Xml.Linq.XElement.Save%2A?displayProperty=nameWithType>

For examples, see the appropriate reference article.

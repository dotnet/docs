---
title: Functional transformation of XML - LINQ to XML
description: Learn about the pure functional transformation approach to modifying XML documents and how it differs from a procedural approach.
ms.date: 07/20/2015
ms.topic: how-to
---

# Functional transformation of XML (LINQ to XML)

This article discusses the pure functional transformation approach to modifying XML documents, and contrasts it with a procedural approach.

## Modifying an XML document

One of the most common tasks for an XML programmer is transforming XML from one shape to another. The shape of an XML document is the structure of the document, which includes the following:

- The hierarchy expressed by the document.
- The element and attribute names.
- The data types of the elements and attributes.

In general, the most effective approach to transforming XML from one shape to another is that of pure functional transformation. In this approach, the primary programmer task is to create a transformation which is applied to the entire XML document (or to one or more strictly defined nodes). Functional transformation is arguably the easiest to code (after a programmer is familiar with the approach), yields the most maintainable code, and is often more compact than alternative approaches.

### XML functional transformational technologies

Microsoft offers two functional transformation technologies for use on XML documents: XSLT and LINQ to XML. XSLT is supported in the <xref:System.Xml.Xsl> managed namespace and in the native COM implementation of MSXML. Although XSLT is a robust technology for manipulating XML documents, it requires expertise in a specialized domain, namely the XSLT language and its supporting APIs.

LINQ to XML provides the tools necessary to code pure functional transformations in an expressive and powerful way, within C# or Visual Basic code. For example, many of the examples in the LINQ to XML documentation use a pure functional approach. Also, in the [Tutorial: Manipulating Content in a WordprocessingML Document](xml-shape-wordprocessingml-documents.md) tutorial, we use LINQ to XML in a functional approach to manipulate information in a Microsoft Word document.

For a more complete comparison of LINQ to XML with other Microsoft XML technologies, see [LINQ to XML vs. other XML technologies](linq-xml-vs-xml-technologies.md).

XSLT is the recommended tool for  document-centric transformations when the source document has an irregular structure. However, LINQ to XML can also perform document-centric transforms. For more information, see [How to use annotations to transform LINQ to XML trees in an XSLT style](use-annotations-transform-linq-xml-trees-xslt-style.md).

## See also

- [Introduction to pure functional transformations](introduction-pure-functional-transformations.md)
- [Tutorial: Manipulate content in a WordprocessingML document](xml-shape-wordprocessingml-documents.md)
- [LINQ to XML vs. other XML technologies](linq-xml-vs-xml-technologies.md)

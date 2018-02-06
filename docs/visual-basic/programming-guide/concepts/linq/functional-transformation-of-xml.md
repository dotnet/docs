---
title: "Functional Transformation of XML (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fdbe5b91-f457-4b4e-a11b-def4bdd77bab
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# Functional Transformation of XML (Visual Basic)
This topic discusses the pure functional transformation approach to modifying XML documents, and contrasts it with a procedural approach.  
  
## Modifying an XML Document  
 One of the most common tasks for an XML programmer is transforming XML from one shape to another. The shape of an XML document is the structure of the document, which includes the following:  
  
-   The hierarchy expressed by the document.  
  
-   The element and attribute names.  
  
-   The data types of the elements and attributes.  
  
 In general, the most effective approach to transforming XML from one shape to another is that of pure functional transformation. In this approach, the primary programmer task is to create a transformation which is applied to the entire XML document (or to one or more strictly defined nodes). Functional transformation is arguably the easiest to code (after a programmer is familiar with the approach), yields the most maintainable code, and is often more compact than alternative approaches.  
  
### XML Functional Transformational Technologies  
 Microsoft offers two functional transformation technologies for use on XML documents: XSLT and LINQ to XML. XSLT is supported in the <xref:System.Xml.Xsl> managed namespace and in the native COM implementation of MSXML. Although XSLT is a robust technology for manipulating XML documents, it requires expertise in a specialized domain, namely the XSLT language and its supporting APIs.  
  
 LINQ to XML provides the tools necessary to code pure functional transformations in an expressive and powerful way, within C# or Visual Basic code. For example, many of the examples in the LINQ to XML documentation use a pure functional approach. Also, in the [Tutorial: Manipulating Content in a WordprocessingML Document (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/tutorial-manipulating-content-in-a-wordprocessingml-document.md) tutorial, we use LINQ to XML in a functional approach to manipulate information in a Microsoft Word document.  
  
 For a more complete comparison of LINQ to XML with other Microsoft XML technologies, see [LINQ to XML vs. Other XML Technologies](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-vs-other-xml-technologies.md).  
  
 XSLT is the recommended tool for  document-centric transformations when the source document has an irregular structure. However, LINQ to XML can also perform document-centric transforms. For more information, see [How to: Use Annotations to Transform LINQ to XML Trees in an XSLT Style (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-use-annotation-trees-to-transform-linq-to-xml-trees-in-an-xslt-style.md).  
  
## See Also  
 [Introduction to Pure Functional Transformations (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/introduction-to-pure-functional-transformations.md)  
 [LINQ to XML vs. Other XML Technologies](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-vs-other-xml-technologies.md)  
 [LINQ to XML vs. Other XML Technologies](http://msdn.microsoft.com/library/7ba1eecf-f09a-42de-bc80-22ca5b2e42d3)

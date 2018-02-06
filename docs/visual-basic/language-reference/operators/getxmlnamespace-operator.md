---
title: "GetXmlNamespace Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.GetXmlNamespace"
  - "GetXmlNamespace"
helpviewer_keywords: 
  - "GetXmlNamespace operator [Visual Basic]"
  - "GetXmlNamespace keyword [Visual Basic]"
ms.assetid: d0d28cfd-0755-4896-ae0b-4981aa35517c
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# GetXmlNamespace Operator (Visual Basic)
Gets the <xref:System.Xml.Linq.XNamespace> object that corresponds to the specified XML namespace prefix.  
  
## Syntax  
  
```  
GetXmlNamespace(xmlNamespacePrefix)  
```  
  
## Parts  
 `xmlNamespacePrefix`  
 Optional. The string that identifies the XML namespace prefix. If supplied, this string must be a valid XML identifier. For more information, see [Names of Declared XML Elements and Attributes](../../../visual-basic/programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md). If no prefix is specified, the default namespace is returned. If no default namespace is specified, the empty namespace is returned.  
  
## Return Value  
 The <xref:System.Xml.Linq.XNamespace> object that corresponds to the XML namespace prefix.  
  
## Remarks  
 The `GetXmlNamespace` operator gets the <xref:System.Xml.Linq.XNamespace> object that corresponds to the XML namespace prefix `xmlNamespacePrefix`.  
  
 You can use XML namespace prefixes directly in XML literals and XML axis properties. However, you must use the `GetXmlNamespace` operator to convert a namespace prefix to an <xref:System.Xml.Linq.XNamespace> object before you can use it in your code. You can append an unqualified element name to an <xref:System.Xml.Linq.XNamespace> object to get a fully qualified <xref:System.Xml.Linq.XName> object, which many [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] methods require.  
  
## Example  
 The following example imports `ns` as an XML namespace prefix. It then uses the prefix of the namespace to create an XML literal and access the first child node that has the qualified name `ns:phone`. It then passes that child node to the `ShowName` subroutine, which constructs a qualified name by using the `GetXmlNamespace` operator. The `ShowName` subroutine then passes the qualified name to the <xref:System.Xml.Linq.XNode.Ancestors%2A> method to get the parent `ns:contact` node.  
  
 [!code-vb[VbXMLSamples#38](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/getxmlnamespace-operator_1.vb)]  
  
 When you call `TestGetXmlNamespace.RunSample()`, it displays a message box that contains the following text:  
  
 `Name: Patrick Hines`  
  
## See Also  
 [Imports Statement (XML Namespace)](../../../visual-basic/language-reference/statements/imports-statement-xml-namespace.md)  
 [Accessing XML in Visual Basic](../../../visual-basic/programming-guide/language-features/xml/accessing-xml.md)

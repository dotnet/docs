---
title: "LINQ to XML Classes Overview (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f11b62b5-d522-4c23-92ae-23186dc16447
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ to XML Classes Overview (Visual Basic)
This topic provides a list of the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] classes in the <xref:System.Xml.Linq> namespace, and a short description of each.  
  
## LINQ to XML Classes  
  
### XAttribute Class  
 <xref:System.Xml.Linq.XAttribute> represents an XML attribute. For detailed information and examples, see [XAttribute Class Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/xattribute-class-overview.md).  
  
### XCData Class  
 <xref:System.Xml.Linq.XCData> represents a CDATA text node.  
  
### XComment Class  
 <xref:System.Xml.Linq.XComment> represents an XML comment.  
  
### XContainer Class  
 <xref:System.Xml.Linq.XContainer> is an abstract base class for all nodes that can have child nodes. The following classes derive from the <xref:System.Xml.Linq.XContainer> class:  
  
-   <xref:System.Xml.Linq.XElement>  
  
-   <xref:System.Xml.Linq.XDocument>  
  
### XDeclaration Class  
 <xref:System.Xml.Linq.XDeclaration> represents an XML declaration. An XML declaration is used to declare the XML version and the encoding of a document. In addition, an XML declaration specifies whether the XML document is stand-alone. If a document is stand-alone, there are no external markup declarations, either in an external DTD, or in an external parameter entity referenced from the internal subset.  
  
### XDocument Class  
 <xref:System.Xml.Linq.XDocument> represents an XML document. For detailed information and examples, see [XDocument Class Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/xdocument-class-overview.md).  
  
### XDocumentType Class  
 <xref:System.Xml.Linq.XDocumentType> represents an XML Document Type Definition (DTD).  
  
### XElement Class  
 <xref:System.Xml.Linq.XElement> represents an XML element. For detailed information and examples, see [XElement Class Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/xelement-class-overview.md).  
  
### XName Class  
 <xref:System.Xml.Linq.XName> represents names of elements (<xref:System.Xml.Linq.XElement>) and attributes (<xref:System.Xml.Linq.XAttribute>). For detailed information and examples, see [XDocument Class Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/xdocument-class-overview.md).  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is designed to make XML names as straightforward as possible. Due to their complexity, XML names are often considered to be an advanced topic in XML. Arguably, this complexity comes not from namespaces, which developers use regularly in programming, but from namespace prefixes. Namespace prefixes can be useful to reduce the keystrokes required when you input XML, or to make XML easier to read. However, prefixes are often just a shortcut for using the full XML namespace, and are not required in most cases. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] simplifies XML names by resolving all prefixes to their corresponding XML namespace. Prefixes are available, if they are required, through the <xref:System.Xml.Linq.XElement.GetPrefixOfNamespace%2A> method.  
  
 It is possible, if necessary, to control namespace prefixes. In some circumstances, if you are working with other XML systems, such as XSLT or XAML, you need to control namespace prefixes. For example, if you have an XPath expression that uses namespace prefixes and is embedded in an XSLT stylesheet, you must make sure that your XML document is serialized with namespace prefixes that match those used in the XPath expression.  
  
### XNamespace Class  
 <xref:System.Xml.Linq.XNamespace> represents a namespace for an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XAttribute>. Namespaces are a component of an <xref:System.Xml.Linq.XName>.  
  
### XNode Class  
 <xref:System.Xml.Linq.XNode> is an abstract class that represents the nodes of an XML tree. The following classes derive from the <xref:System.Xml.Linq.XNode> class:  
  
-   <xref:System.Xml.Linq.XText>  
  
-   <xref:System.Xml.Linq.XContainer>  
  
-   <xref:System.Xml.Linq.XComment>  
  
-   <xref:System.Xml.Linq.XProcessingInstruction>  
  
-   <xref:System.Xml.Linq.XDocumentType>  
  
### XNodeDocumentOrderComparer Class  
 <xref:System.Xml.Linq.XNodeDocumentOrderComparer> provides functionality to compare nodes for their document order.  
  
### XNodeEqualityComparer Class  
 <xref:System.Xml.Linq.XNodeEqualityComparer> provides functionality to compare nodes for value equality.  
  
### XObject Class  
 <xref:System.Xml.Linq.XObject> is an abstract base class of <xref:System.Xml.Linq.XNode> and <xref:System.Xml.Linq.XAttribute>. It provides annotation and event functionality.  
  
### XObjectChange Class  
 <xref:System.Xml.Linq.XObjectChange> specifies the event type when an event is raised for an <xref:System.Xml.Linq.XObject>.  
  
### XObjectChangeEventArgs Class  
 <xref:System.Xml.Linq.XObjectChangeEventArgs> provides data for the <xref:System.Xml.Linq.XObject.Changing> and <xref:System.Xml.Linq.XObject.Changed> events.  
  
### XProcessingInstruction Class  
 <xref:System.Xml.Linq.XProcessingInstruction> represents an XML processing instruction. A processing instruction communicates information to an application that processes the XML.  
  
### XText Class  
 <xref:System.Xml.Linq.XText> represents a text node. In most cases, you do not have to use this class. This class is primarily used for mixed content.  
  
## See Also  
 [LINQ to XML Programming Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-programming-overview.md)

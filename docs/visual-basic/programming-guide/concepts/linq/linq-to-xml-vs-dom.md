---
title: "LINQ to XML vs. DOM (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 18c36130-d598-40b7-9007-828232252978
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ to XML vs. DOM (Visual Basic)
This section describes some key differences between [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] and the current predominant XML programming API, the W3C Document Object Model (DOM).  
  
## New Ways to Construct XML Trees  
 In the W3C DOM, you build an XML tree from the bottom up; that is, you create a document, you create elements, and then you add the elements to the document.  
  
 For example, the following would be a typical way to create an XML tree using the Microsoft implementation of DOM, <xref:System.Xml.XmlDocument>:  
  
```vb  
Dim doc As XmlDocument = New XmlDocument()  
Dim name As XmlElement = doc.CreateElement("Name")  
name.InnerText = "Patrick Hines"  
Dim phone1 As XmlElement = doc.CreateElement("Phone")  
phone1.SetAttribute("Type", "Home")  
phone1.InnerText = "206-555-0144"  
Dim phone2 As XmlElement = doc.CreateElement("Phone")  
phone2.SetAttribute("Type", "Work")  
phone2.InnerText = "425-555-0145"  
Dim street1 As XmlElement = doc.CreateElement("Street1")  
street1.InnerText = "123 Main St"  
Dim city As XmlElement = doc.CreateElement("City")  
city.InnerText = "Mercer Island"  
Dim state As XmlElement = doc.CreateElement("State")  
state.InnerText = "WA"  
Dim postal As XmlElement = doc.CreateElement("Postal")  
postal.InnerText = "68042"  
Dim address As XmlElement = doc.CreateElement("Address")  
address.AppendChild(street1)  
address.AppendChild(city)  
address.AppendChild(state)  
address.AppendChild(postal)  
Dim contact As XmlElement = doc.CreateElement("Contact")  
contact.AppendChild(name)  
contact.AppendChild(phone1)  
contact.AppendChild(phone2)  
contact.AppendChild(address)  
Dim contacts As XmlElement = doc.CreateElement("Contacts")  
contacts.AppendChild(contact)  
doc.AppendChild(contacts)  
Console.WriteLine(doc.OuterXml)  
```  
  
 This style of coding does not visually provide much information about the structure of the XML tree. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] supports this approach to constructing an XML tree, but also supports an alternative approach, *functional construction*. In Visual Basic, functional construction uses XML literals to build an XML tree.  
  
 Here is how you would construct the same XML tree by using [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] functional construction:  
  
```vb  
Dim contacts = _  
    <Contacts>  
        <Contact>  
            <Name>Patrick Hines</Name>  
            <Phone Type="Home">206-555-0144</Phone>  
            <Phone Type="Work">425-555-0145</Phone>  
            <Address>  
                <Street1>123 Main St</Street1>  
                <City>Mercer Island</City>  
                <State>WA</State>  
                <Postal>68042</Postal>  
            </Address>  
        </Contact>  
    </Contacts>  
```  
  
 Notice that indenting the code to construct the XML tree shows the structure of the underlying XML.  
  
 For more information, see [Creating XML Trees (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/creating-xml-trees.md).  
  
## Working Directly with XML Elements  
 When you program with XML, your primary focus is usually on XML elements and perhaps on attributes. In [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], you can work directly with XML elements and attributes. For example, you can do the following:  
  
-   Create XML elements without using a document object at all. This simplifies programming when you have to work with fragments of XML trees.  
  
-   Load `T:System.Xml.Linq.XElement` objects directly from an XML file.  
  
-   Serialize `T:System.Xml.Linq.XElement` objects to a file or a stream.  
  
 Compare this to the W3C DOM, in which the XML document is used as a logical container for the XML tree. In DOM, XML nodes, including elements and attributes, must be created in the context of an XML document. Here is a fragment of the code to create a name element in DOM:  
  
```vb  
Dim doc As XmlDocument = New XmlDocument()  
Dim name As XmlElement = doc.CreateElement("Name")  
name.InnerText = "Patrick Hines"  
doc.AppendChild(name)  
```  
  
 If you want to use an element across multiple documents, you must import the nodes across documents. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] avoids this layer of complexity.  
  
 When using LINQ to XML, you use the <xref:System.Xml.Linq.XDocument> class only if you want to add a comment or processing instruction at the root level of the document.  
  
## Simplified Handling of Names and Namespaces  
 Handling names, namespaces, and namespace prefixes is generally a complex part of XML programming. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] simplifies names and namespaces by eliminating the requirement to deal with namespace prefixes. If you want to control namespace prefixes, you can. But if you decide to not explicitly control namespace prefixes, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] will assign namespace prefixes during serialization if they are required, or will serialize using default namespaces if they are not. If default namespaces are used, there will be no namespace prefixes in the resulting document. For more information, see [Working with XML Namespaces (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/working-with-xml-namespaces.md).  
  
 Another problem with the DOM is that it does not let you change the name of a node. Instead, you have to create a new node and copy all the child nodes to it, losing the original node identity. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] avoids this problem by enabling you to set the <xref:System.Xml.Linq.XName> property on a node.  
  
## Static Method Support for Loading XML  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] lets you load XML by using static methods, instead of instance methods. This simplifies loading and parsing. For more information, see [How to: Load XML from a File (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-load-xml-from-a-file.md).  
  
## Removal of Support for DTD Constructs  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] further simplifies XML programming by removing support for entities and entity references. The management of entities is complex, and is rarely used. Removing their support increases performance and simplifies the programming interface. When a [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] tree is populated, all DTD entities are expanded.  
  
## Support for Fragments  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] does not provide an equivalent for the `XmlDocumentFragment` class. In many cases, however, the `XmlDocumentFragment` concept can be handled by the result of a query that is typed as <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XNode>, or <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement>.  
  
## Support for XPathNavigator  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] provides support for <xref:System.Xml.XPath.XPathNavigator> through extension methods in the <xref:System.Xml.XPath?displayProperty=nameWithType> namespace. For more information, see <xref:System.Xml.XPath.Extensions?displayProperty=nameWithType>.  
  
## Support for White Space and Indentation  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] handles white space more simply than the DOM.  
  
 A common scenario is to read indented XML, create an in-memory XML tree without any white space text nodes (that is, not preserving white space), perform some operations on the XML, and then save the XML with indentation. When you serialize the XML with formatting, only significant white space in the XML tree is preserved. This is the default behavior for [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].  
  
 Another common scenario is to read and modify XML that has already been intentionally indented. You might not want to change this indentation in any way. In [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], you can do this by preserving white space when you load or parse the XML and disabling formatting when you serialize the XML.  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] stores white space as an <xref:System.Xml.Linq.XText> node, instead of having a specialized <xref:System.Xml.XmlNodeType.Whitespace> node type, as the DOM does.  
  
## Support for Annotations  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] elements support an extensible set of annotations. This is useful for tracking miscellaneous information about an element, such as schema information, information about whether the element is bound to a UI, or any other kind of application-specific information. For more information, see [LINQ to XML Annotations](http://msdn.microsoft.com/library/e2f0052d-61e2-48d4-9ea4-356c9cab35d5).  
  
## Support for Schema Information  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] provides support for XSD validation through extension methods in the <xref:System.Xml.Schema?displayProperty=nameWithType> namespace. You can validate that an XML tree complies with an XSD. You can populate the XML tree with the post-schema-validation infoset (PSVI). For more information, see [How to: Validate Using XSD](http://msdn.microsoft.com/library/481a97fa-6e96-46f2-8c9a-415555fac33b) and <xref:System.Xml.Schema.Extensions>.  
  
## See Also  
 [Getting Started (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/getting-started-linq-to-xml.md)

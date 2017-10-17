---
title: "Namespaces Overview (LINQ to XML)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 16283322-8238-4918-ab11-802ac6748eb7
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Namespaces Overview (LINQ to XML)
This topic introduces namespaces, the <xref:System.Xml.Linq.XName> class, and the <xref:System.Xml.Linq.XNamespace> class.  
  
## XML Names  
 XML names are often a source of complexity in XML programming. An XML name consists of an XML namespace (also called an XML namespace URI) and a local name. An XML namespace is similar to a namespace in a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)]-based program. It enables you to uniquely qualify the names of elements and attributes. This helps avoid name conflicts between various parts of an XML document. When you have declared an XML namespace, you can select a local name that only has to be unique within that namespace.  
  
 Another aspect of XML names is XML *namespace prefixes*. XML prefixes cause most of the complexity of XML names. These prefixes enable you to create a shortcut for an XML namespace, which makes the XML document more concise and understandable. However, XML prefixes depend on their context to have meaning, which adds complexity. For example, the XML prefix `aw` could be associated with one XML namespace in one part of an XML tree, and with a different XML namespace in a different part of the XML tree.  
  
 One of the advantages of using [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] with C# is that you do not have to use XML prefixes. When [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] loads or parses an XML document, each XML prefix is resolved to its corresponding XML namespace. After that, when you work with a document that uses namespaces, you almost always access the namespaces through the namespace URI, and not through the namespace prefix. When developers work with XML names in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] they always work with a fully-qualified XML name (that is, an XML namespace and a local name). However, when necessary, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] allows you to work with and control namespace prefixes.  
  
 In [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], the class that represents XML names is <xref:System.Xml.Linq.XName>. XML names appear frequently throughout the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] API, and wherever an XML name is required, you will find an <xref:System.Xml.Linq.XName> parameter. However, you rarely work directly with an <xref:System.Xml.Linq.XName>. <xref:System.Xml.Linq.XName> contains an implicit conversion from string.  
  
 For more information, see <xref:System.Xml.Linq.XNamespace> and <xref:System.Xml.Linq.XName>.  
  
## See Also  
 [Working with XML Namespaces (C#)](../../../../csharp/programming-guide/concepts/linq/working-with-xml-namespaces.md)

---
title: "Accessing XML in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "LINQ to XML [Visual Basic], accessing XML"
  - "Visual Basic code, XML"
  - "accessing XML [Visual Basic], axis properties"
  - "XML [Visual Basic], axis properties"
  - "XML [Visual Basic], accessing"
ms.assetid: c47f88b2-3cbc-4bb1-b4b9-be60f71ffc6a
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Accessing XML in Visual Basic
[!INCLUDE[vbprvb](../../../../csharp/programming-guide/concepts/linq/includes/vbprvb_md.md)] provides XML axis properties for accessing and navigating [!INCLUDE[sqltecxlinq](../../../../csharp/programming-guide/concepts/linq/includes/sqltecxlinq_md.md)] structures. These properties use a special syntax to enable you to access elements and attributes by specifying the XML names.  
  
 The following table lists the language features that enable you to access XML elements and attributes in [!INCLUDE[vbprvb](../../../../csharp/programming-guide/concepts/linq/includes/vbprvb_md.md)].  
  
### XML Axis Properties  
  
|Property description|Example|Description|  
|--------------------------|-------------|-----------------|  
|*child axis*|`contact.<phone>`|Gets all `phone` elements that are child elements of the `contact` element.|  
|*attribute axis*|`phone.@type`|Gets all `type` attributes of the `phone` element.|  
|*descendant axis*|`contacts...<name>`|Gets all `name` elements of the `contacts` element, regardless of how deep in the hierarchy they occur.|  
|*extension indexer*|`contacts...<name>(0)`|Gets the first `name` element from the sequence.|  
|*value*|`contacts...<name>.Value`|Gets the string representation of the first object in the sequence, or `Nothing` if the sequence is empty.|  
  
## In This Section  
 [How to: Access XML Descendant Elements](../../../../visual-basic/programming-guide/language-features/xml/how-to-access-xml-descendant-elements.md)  
 Shows how to use a descendant axis property to access all XML elements that have a specified name and that are contained under a specified XML element.  
  
 [How to: Access XML Child Elements](../../../../visual-basic/programming-guide/language-features/xml/how-to-access-xml-child-elements.md)  
 Shows how to use a child axis property to access all XML child elements that have a specified name in an XML element.  
  
 [How to: Access XML Attributes](../../../../visual-basic/programming-guide/language-features/xml/how-to-access-xml-attributes.md)  
 Shows how to use an attribute axis property to access all XML attributes that have a specified name in an XML element.  
  
 [How to: Declare and Use XML Namespace Prefixes](../../../../visual-basic/programming-guide/language-features/xml/how-to-declare-and-use-xml-namespace-prefixes.md)  
 Shows how to declare an XML namespace prefix and use it to create and access XML elements.  
  
## Related Sections  
 [XML Axis Properties](../../../../visual-basic/language-reference/xml-axis/xml-axis-properties.md)  
 Provides links to sections describing the various XML access properties.  
  
 [Overview of LINQ to XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/overview-of-linq-to-xml.md)  
 Provides an introduction to using [!INCLUDE[sqltecxlinq](../../../../csharp/programming-guide/concepts/linq/includes/sqltecxlinq_md.md)] in Visual Basic.  
  
 [Creating XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)  
 Provides an introduction to using XML literals in Visual Basic.  
  
 [Manipulating XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/manipulating-xml.md)  
 Provides links to sections about loading and modifying XML in Visual Basic.  
  
 [XML](../../../../visual-basic/programming-guide/language-features/xml/index.md)  
 Provides links to sections describing how to use [!INCLUDE[sqltecxlinq](../../../../csharp/programming-guide/concepts/linq/includes/sqltecxlinq_md.md)] in Visual Basic.
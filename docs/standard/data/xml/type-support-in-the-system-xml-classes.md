---
title: "Type Support in the System.Xml Classes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 63570538-06e3-4401-ad4d-ac50be90c7bf
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Type Support in the System.Xml Classes
In the .NET Framework version 2.0, the core XML classes have been enhanced to include type support features. The <xref:System.Xml.XmlReader>, <xref:System.Xml.XmlWriter>, and <xref:System.Xml.XPath.XPathNavigator> classes include type support features including the ability to convert between XML Schema types and common language runtime (CLR) types.  
  
 In the .NET Framework version 2.0, the <xref:System.Xml.XmlReader>, <xref:System.Xml.XmlWriter>, and <xref:System.Xml.XPath.XPathNavigator> classes have been enhanced to include type support features.  
  
-   The <xref:System.Xml.XmlReader> and <xref:System.Xml.XPath.XPathNavigator> classes each include a **SchemaInfo** property that returns the schema information on a node.  
  
-   The **ReadContentAs** and **ReadElementContentAs** and methods on the <xref:System.Xml.XmlReader> class read a text value and convert it to a CLR value in a single method call.  
  
-   The <xref:System.Xml.XmlWriter.WriteValue%2A> method on the <xref:System.Xml.XmlWriter> class converts a CLR type to an XML Schema type when writing out XML.  
  
-   The **ValueAs** and <xref:System.Xml.XPath.XPathNavigator.TypedValue%2A> properties on the <xref:System.Xml.XPath.XPathNavigator> class return a node value and convert it to a CLR value in a single method call.  
  
> [!NOTE]
>  In the .NET Framework version 1.0 the <xref:System.Xml.XmlConvert> class was needed to convert between XML Schema and CLR types.  
  
## In This Section  
 [Mapping XML Data Types to CLR Types](../../../../docs/standard/data/xml/mapping-xml-data-types-to-clr-types.md)  
 Describes the default mappings of XML data types to CLR types.  
  
 [XML Type Support Implementation Notes](../../../../docs/standard/data/xml/xml-type-support-implementation-notes.md)  
 Discusses some of the type support implementation details.  
  
 [Conversion of XML Data Types](../../../../docs/standard/data/xml/conversion-of-xml-data-types.md)  
 Describes how to use the <xref:System.Xml.XmlConvert> class to convert between XML Schema and CLR types.  
  
## Related Sections  
 [Accessing Strongly Typed XML Data Using XPathNavigator](../../../../docs/standard/data/xml/accessing-strongly-typed-xml-data-using-xpathnavigator.md)

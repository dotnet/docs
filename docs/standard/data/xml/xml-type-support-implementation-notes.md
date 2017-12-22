---
title: "XML Type Support Implementation Notes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 26b071f3-1261-47ef-8690-0717f5cd93c1
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XML Type Support Implementation Notes
This topic describes some implementation details that you want to be aware of.  
  
## List Mappings  
 The <xref:System.Collections.IList>, <xref:System.Collections.ICollection>, <xref:System.Collections.IEnumerable>, **Type[]**, and <xref:System.String> types are used to represent XML Schema definition language (XSD) list types.  
  
## Union Mappings  
 Union types are represented using the <xref:System.Xml.Schema.XmlAtomicValue> or <xref:System.String> type. The source type or the destination type must therefore always be either <xref:System.String> or <xref:System.Xml.Schema.XmlAtomicValue>.  
  
 If the <xref:System.Xml.Schema.XmlSchemaDatatype> object represents a list type the object converts the input string value to a list of one or more objects. If the <xref:System.Xml.Schema.XmlSchemaDatatype> represents a union type then an attempt is made to parse the input value as a member type of the union. If the parse attempt fails then the conversion is attempted with the next member of the union and so on until the conversion is successful, or there are no other member types to try, in which case an exception is thrown.  
  
## Differences Between CLR and XML Data Types  
 The following describes certain mismatches that can occur between CLR types and XML data types and how they are handled.  
  
> [!NOTE]
>  The `xs` prefix is mapped to the http://www.w3.org/2001/XMLSchema and namespace URI.  
  
### System.TimeSpan and xs:duration  
 The `xs:duration` type is partially ordered in that there are certain duration values that are different but equivalent. This means that for the `xs:duration` type value such as 1 month (P1M) is less than 32 days (P32D), larger than 27 days (P27D) and equivalent to 28, 29 or 30 days.  
  
 The <xref:System.TimeSpan> class does not support this partial ordering. Instead, it picks a specific number of days for 1 year and 1 month; 365 days and 30 days respectively.  
  
 For more information on the `xs:duration` type, see the W3C XML Schema Part 2: Datatypes Recommendation at http://www.w3.org/TR/xmlschema-2/.  
  
### xs:time, Gregorian Date Types, and System.DateTime  
 When an `xs:time` value is mapped to a <xref:System.DateTime> object, the <xref:System.DateTime.MinValue> field is used to initialize the date properties of the <xref:System.DateTime> object (such as <xref:System.DateTime.Year%2A>, <xref:System.DateTime.Month%2A>, and <xref:System.DateTime.Day%2A>) to the smallest possible <xref:System.DateTime> value.  
  
 Similarly, instances of `xs:gMonth`, `xs:gDay`, `xs:gYear`, `xs:gYearMonth` and `xs:gMonthDay` are also mapped to a <xref:System.DateTime> object. Unused properties on the <xref:System.DateTime> object are initialized to those from <xref:System.DateTime.MinValue>.  
  
> [!NOTE]
>  You cannot rely on the <xref:System.DateTime.Year%2A?displayProperty=nameWithType> value when the content is typed as `xs:gMonthDay`. The <xref:System.DateTime.Year%2A?displayProperty=nameWithType> value is always set to 1904 in this case.  
  
### xs:anyURI and System.Uri  
 When an instance of `xs:anyURI` that represents a relative URI is mapped to a <xref:System.Uri>, the <xref:System.Uri> object does not have a base URI.  
  
## See Also  
 [Type Support in the System.Xml Classes](../../../../docs/standard/data/xml/type-support-in-the-system-xml-classes.md)

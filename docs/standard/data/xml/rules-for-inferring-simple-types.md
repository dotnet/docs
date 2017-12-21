---
title: "Rules for Inferring Simple Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 394624d6-4da0-430a-8a88-46efe40f14de
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Rules for Inferring Simple Types
Describes how the <xref:System.Xml.Schema.XmlSchemaInference> class infers the data type for attributes and elements.  
  
 The <xref:System.Xml.Schema.XmlSchemaInference> class infers the data type for attributes and elements as simple types. This section describes the potential inferred types, how multiple differing values are reconciled to a single type, and how schema-defining `xsi` attributes are handled.  
  
## Inferred Types  
 The <xref:System.Xml.Schema.XmlSchemaInference> class infers element and attribute values as simple types and includes a type attribute in the resulting schema. All inferred types are simple types. No base types or facets are included as part of the resulting schema.  
  
 Values are examined individually as they are encountered in the XML document. The type is inferred for a value at the time it is examined. If a type has been inferred for an attribute or element, and a value for the attribute or element is encountered that does not match the currently inferred type, the <xref:System.Xml.Schema.XmlSchemaInference> class promotes the type for each of a set of rules. These rules are discussed in the Type Promotion section, later in this topic.  
  
 The following table lists the possible inferred types for the resulting schema.  
  
|Simple Type|Description|  
|-----------------|-----------------|  
|boolean|True, false, 0, 1.|  
|byte|Integers in the range of –128 to 127.|  
|unsignedByte|Integers in the range of 0 to 255.|  
|short|Integers in the range of –32768 to 32767.|  
|unsignedShort|Integers in the range of 0 to 65535.|  
|int|Integers in the range of –2147483648 to 2147483647.|  
|unsignedInt|Integers in the range of 0 to 4294967295.|  
|long|Integers in the range of –9223372036854775808 to 9223372036854775807.|  
|unsignedLong|Integers in the range of 0 to 18446744073709551615.|  
|integer|A finite number of digits possibly prefixed with "-".|  
|decimal|Numerical values that contain from 0 to 28 digits of precision.|  
|float|Decimals optionally followed by "E" or "e" followed by an integer value representing the exponent. Decimal values can be in the range of -16777216 to 16777216. Exponent values can be in the range of –149 to 104.<br /><br /> Float allows for special values to represent infinity and non-numeric values. Special values for float are: 0, -0, INF, -INF, NaN.|  
|double|The same as float except decimal values can be in the range of -9007199254740992 to 9007199254740992, and exponent values can be in the range of –1075 to 970.<br /><br /> Double allows for special values to represent infinity and non-numeric values. Special values for float are: 0, -0, INF, -INF, NaN.|  
|duration|The W3C duration format.|  
|dateTime|The W3C dateTime format.|  
|time|The W3C time format.|  
|date|Year values are restricted from 0001 to 9999.|  
|gYearMonth|The W3C Gregorian month and year format.|  
|string|One or more Unicode characters.|  
  
## Type Promotion  
 The <xref:System.Xml.Schema.XmlSchemaInference> class examines attribute and element values one at a time. As values are encountered, the most restrictive, unsigned type is inferred. If a type has been inferred for an attribute or element, and a new value is encountered that does not match the currently inferred type, the inferred type is promoted to a new type that applies to both the currently inferred type and the new value. The <xref:System.Xml.Schema.XmlSchemaInference> class does consider previous values when promoting the inferred type.  
  
 For example, consider the following XML fragments from two XML documents:  
  
 `<MyElement1 attr1="12" />`  
  
 `<MyElement1 attr1="52344" />`  
  
 When the first `attr1` value is encountered, the type of `attr1` is inferred as `unsignedByte` based on the value `12`. When the second `attr1` is encountered, the type is promoted to `unsignedShort` based on the currently inferred type of `unsignedByte` and the current value `52344`.  
  
 Now, consider the following XML from two XML documents:  
  
 `<MyElement2 attr2="0" />`  
  
 `<MyElement2 attr2="true" />`  
  
 When the first `attr2` value is encountered, the type of `attr2` is inferred as `unsignedByte` based on the value `0`. When the second `attr2` is encountered, the type is promoted to `string` based on the currently inferred type of `unsignedByte` and the current value `true` because the <xref:System.Xml.Schema.XmlSchemaInference> class does consider previous values when promoting the inferred type. However, if both instances of `attr2` were encountered in the same XML document and not in two different XML documents as illustrated above, `attr2` would have been inferred as `boolean`.  
  
### Ignored Attributes from the http://www.w3.org/2001/XMLSchema-instance Namespace  
 The following are schema-defining attributes that are ignored during schema inference.  
  
|Attribute|Description|  
|---------------|-----------------|  
|`xsi:type`|If an element is encountered with `xsi:type` specified, the `xsi:type` is ignored.|  
|`xsi:nil`|If an element with an `xsi:nil` attribute is encountered, its element declaration in the inferred schema has the value of `nillable="true"`. An element with an `xsi:nil` attribute set to `true` cannot have child elements.|  
|`xsi:schemaLocation`|If `xsi:schemaLocation` is encountered, it is ignored.|  
|`xsi:noNamespaceSchemaLocation`|If `xsi:noNamespaceSchemaLocation` is encountered, it is ignored.|  
  
## See Also  
 [XML Schema Object Model (SOM)](../../../../docs/standard/data/xml/xml-schema-object-model-som.md)  
 [Inferring Schemas from XML Documents](../../../../docs/standard/data/xml/inferring-schemas-from-xml-documents.md)  
 [Rules for Inferring Schema Node Types and Structure](../../../../docs/standard/data/xml/rules-for-inferring-schema-node-types-and-structure.md)

---
title: "Traversing XML Schemas"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
ms.assetid: cce69574-5861-4a30-b730-2e18d915d8ee
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Traversing XML Schemas
Traversing an XML schema using the Schema Object Model (SOM) API provides access to the elements, attributes, and types stored in the SOM. Traversing an XML schema loaded into the SOM is also the first step in editing an XML schema using the SOM API.  
  
## Traversing an XML Schema  
 The following properties of the <xref:System.Xml.Schema.XmlSchema> class provide access to the collection of all global items added to the XML schema.  
  
|Property|Object type stored in the collection or array|  
|--------------|---------------------------------------------------|  
|<xref:System.Xml.Schema.XmlSchema.Elements%2A>|<xref:System.Xml.Schema.XmlSchemaElement>|  
|<xref:System.Xml.Schema.XmlSchema.Attributes%2A>|<xref:System.Xml.Schema.XmlSchemaAttribute>|  
|<xref:System.Xml.Schema.XmlSchema.AttributeGroups%2A>|<xref:System.Xml.Schema.XmlSchemaAttributeGroup>|  
|<xref:System.Xml.Schema.XmlSchema.Groups%2A>|<xref:System.Xml.Schema.XmlSchemaGroup>|  
|<xref:System.Xml.Schema.XmlSchema.Includes%2A>|<xref:System.Xml.Schema.XmlSchemaExternal>, <xref:System.Xml.Schema.XmlSchemaInclude>, <xref:System.Xml.Schema.XmlSchemaImport>, or <xref:System.Xml.Schema.XmlSchemaRedefine>|  
|<xref:System.Xml.Schema.XmlSchema.Items%2A>|<xref:System.Xml.Schema.XmlSchemaObject> (provides access to all global level elements, attributes, and types).|  
|<xref:System.Xml.Schema.XmlSchema.Notations%2A>|<xref:System.Xml.Schema.XmlSchemaNotation>|  
|<xref:System.Xml.Schema.XmlSchema.SchemaTypes%2A>|<xref:System.Xml.Schema.XmlSchemaType>, <xref:System.Xml.Schema.XmlSchemaSimpleType>, <xref:System.Xml.Schema.XmlSchemaComplexType>|  
|<xref:System.Xml.Schema.XmlSchema.UnhandledAttributes%2A>|<xref:System.Xml.XmlAttribute> (provides access to attributes that do not belong to the schema namespace)|  
  
> [!NOTE]
>  All of the properties listed in the table above, except for the <xref:System.Xml.Schema.XmlSchema.Items%2A> property, are Post-Schema-Compilation-Infoset (PSCI) properties that are not available until the schema has been compiled. The <xref:System.Xml.Schema.XmlSchema.Items%2A> property is a pre-schema-compilation property that can be used before the schema has been compiled to access and edit all global level elements, attributes, and types.  
>   
>  The <xref:System.Xml.Schema.XmlSchema.UnhandledAttributes%2A> property provides access to all the attributes that do not belong to the schema namespace. These attributes are not processed by the schema processor.  
  
 The code example that follows demonstrates traversing the customer schema created in the [Building XML Schemas](../../../../docs/standard/data/xml/building-xml-schemas.md) topic. The code example demonstrates traversing the schema using the collections described above and writes all the elements and attributes in the schema to the console.  
  
 The sample traverses the customer schema in the following steps.  
  
1.  Adds the customer schema to a new <xref:System.Xml.Schema.XmlSchemaSet> object and then compiles it. Any schema validation warnings and errors encountered reading or compiling the schema are handled by the <xref:System.Xml.Schema.ValidationEventHandler> delegate.  
  
2.  Retrieves the compiled <xref:System.Xml.Schema.XmlSchema> object from the <xref:System.Xml.Schema.XmlSchemaSet> by iterating over the <xref:System.Xml.Schema.XmlSchemaSet.Schemas%2A> property. Because the schema is compiled, Post-Schema-Compilation-Infoset (PSCI) properties are accessible.  
  
3.  Iterates over each <xref:System.Xml.Schema.XmlSchemaElement> in the <xref:System.Xml.Schema.XmlSchemaObjectTable.Values%2A> collection of the post-schema-compilation <xref:System.Xml.Schema.XmlSchema.Elements%2A?displayProperty=nameWithType> collection writing the name of each element to the console.  
  
4.  Gets the complex type of the `Customer` element using the <xref:System.Xml.Schema.XmlSchemaComplexType> class.  
  
5.  If the complex type has any attributes, gets an <xref:System.Collections.IDictionaryEnumerator> to enumerate over each <xref:System.Xml.Schema.XmlSchemaAttribute> and writes its name to the console.  
  
6.  Gets the sequence particle of the complex type using the <xref:System.Xml.Schema.XmlSchemaSequence> class.  
  
7.  Iterates over each <xref:System.Xml.Schema.XmlSchemaElement> in the <xref:System.Xml.Schema.XmlSchemaSequence.Items%2A?displayProperty=nameWithType> collection writing the name of each child element to the console.  
  
 The following is the complete code example.  
  
 [!code-cpp[XmlSchemaTraverseExample#1](../../../../samples/snippets/cpp/VS_Snippets_Data/XmlSchemaTraverseExample/CPP/XmlSchemaTraverseExample.cpp#1)]
 [!code-csharp[XmlSchemaTraverseExample#1](../../../../samples/snippets/csharp/VS_Snippets_Data/XmlSchemaTraverseExample/CS/XmlSchemaTraverseExample.cs#1)]
 [!code-vb[XmlSchemaTraverseExample#1](../../../../samples/snippets/visualbasic/VS_Snippets_Data/XmlSchemaTraverseExample/VB/XmlSchemaTraverseExample.vb#1)]  
  
 The <xref:System.Xml.Schema.XmlSchemaElement.ElementSchemaType%2A?displayProperty=nameWithType> property can be <xref:System.Xml.Schema.XmlSchemaSimpleType>, or <xref:System.Xml.Schema.XmlSchemaComplexType> if it is a user-defined simple type or a complex type. It can also be <xref:System.Xml.Schema.XmlSchemaDatatype> if it is one of the built-in datatypes defined in the W3C XML Schema Recommendation. In the customer schema, the <xref:System.Xml.Schema.XmlSchemaElement.ElementSchemaType%2A> of the `Customer` element is <xref:System.Xml.Schema.XmlSchemaComplexType>, and the `FirstName` and `LastName` elements are <xref:System.Xml.Schema.XmlSchemaSimpleType>.  
  
 The code example in the [Building XML Schemas](../../../../docs/standard/data/xml/building-xml-schemas.md) topic used the <xref:System.Xml.Schema.XmlSchemaComplexType.Attributes%2A?displayProperty=nameWithType> collection to add the attribute `CustomerId` to the `Customer` element. This is a pre-schema-compilation property. The corresponding Post-Schema-Compilation-Infoset property is the <xref:System.Xml.Schema.XmlSchemaComplexType.AttributeUses%2A?displayProperty=nameWithType> collection, which holds all the attributes of the complex type, including the ones that are inherited through type derivation.  
  
## See Also  
 [XML Schema Object Model Overview](../../../../docs/standard/data/xml/xml-schema-object-model-overview.md)  
 [Reading and Writing XML Schemas](../../../../docs/standard/data/xml/reading-and-writing-xml-schemas.md)  
 [Building XML Schemas](../../../../docs/standard/data/xml/building-xml-schemas.md)  
 [Editing XML Schemas](../../../../docs/standard/data/xml/editing-xml-schemas.md)  
 [Including or Importing XML Schemas](../../../../docs/standard/data/xml/including-or-importing-xml-schemas.md)  
 [XmlSchemaSet for Schema Compilation](../../../../docs/standard/data/xml/xmlschemaset-for-schema-compilation.md)  
 [Post-Schema Compilation Infoset](../../../../docs/standard/data/xml/post-schema-compilation-infoset.md)

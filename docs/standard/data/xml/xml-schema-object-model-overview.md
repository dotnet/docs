---
title: "XML Schema Object Model Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 896a1e12-5655-42c6-8cdd-89c12862b34b
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XML Schema Object Model Overview
The Schema Object Model (SOM) in the Microsoft .NET Framework is a rich API that allows you to create, edit, and validate schemas programmatically. The SOM operates on XML schema documents similarly to the way the Document Object Model (DOM) operates on XML documents. XML schema documents are valid XML files that, once loaded into the SOM, convey meaning about the structure and validity of other XML documents which conform to the schema.  
  
 A schema is an XML document that defines a class of XML documents by specifying the structure or model of XML documents for a particular schema. A schema identifies the constraints on the content of the XML documents, and describes the vocabulary (rules or grammar) that compliant XML documents must follow in order to be considered schema-valid with that particular schema. Validation of an XML document is the process that ensures that the document conforms to the grammar specified by the schema.  
  
 The following are ways the SOM API in the .NET Framework enables you to create, edit, and validate schemas.  
  
-   Load and save valid schemas to and from files.  
  
-   Create in-memory schemas using strongly typed classes.  
  
-   Interact with the <xref:System.Xml.Schema.XmlSchemaSet> class to cache, compile, and retrieve schemas.  
  
-   Interact with the <xref:System.Xml.XmlReader.Create%2A> method of the <xref:System.Xml.XmlReader> class to validate XML instance documents against schemas.  
  
-   Build editors for creating and maintaining schemas.  
  
-   Dynamically edit a schema that can be complied and saved for use in the validation of XML instance documents.  
  
## The Schema Object Model  
 The SOM consists of an extensive set of classes in the <xref:System.Xml.Schema?displayProperty=nameWithType> namespace corresponding to the elements in an XML schema. For example, the `<xsd:schema>...</xsd:schema>` element maps to the <xref:System.Xml.Schema.XmlSchema?displayProperty=nameWithType> class, and all the information that can be contained within an `<xsd:schema/>` element can be represented using the <xref:System.Xml.Schema.XmlSchema> class. Similarly, the `<xsd:element>...</xsd:element>` and `<xsd:attribute>...</xsd:attribute>` elements map to the <xref:System.Xml.Schema.XmlSchemaElement?displayProperty=nameWithType> and <xref:System.Xml.Schema.XmlSchemaAttribute?displayProperty=nameWithType> classes respectively. This mapping continues for all the elements of an XML schema creating an XML schema object model in the <xref:System.Xml.Schema> namespace illustrated in the diagram that follows.  
  
 ![System.Xml.Schema Object Model](../../../../docs/standard/data/xml/media/xmlschemaobjmodeloverview.gif "XMLSchemaObjModelOverview")  
  
 For more information about each class in the <xref:System.Xml.Schema> namespace, see the <xref:System.Xml.Schema> namespace reference documentation in the .NET Framework class library.  
  
## See Also  
 [Reading and Writing XML Schemas](../../../../docs/standard/data/xml/reading-and-writing-xml-schemas.md)  
 [Building XML Schemas](../../../../docs/standard/data/xml/building-xml-schemas.md)  
 [Traversing XML Schemas](../../../../docs/standard/data/xml/traversing-xml-schemas.md)  
 [Editing XML Schemas](../../../../docs/standard/data/xml/editing-xml-schemas.md)  
 [Including or Importing XML Schemas](../../../../docs/standard/data/xml/including-or-importing-xml-schemas.md)  
 [XmlSchemaSet for Schema Compilation](../../../../docs/standard/data/xml/xmlschemaset-for-schema-compilation.md)  
 [Post-Schema Compilation Infoset](../../../../docs/standard/data/xml/post-schema-compilation-infoset.md)

---
description: "Learn more about: Post-Schema Compilation Infoset"
title: "Post-Schema Compilation Infoset"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
---
# Post-schema compilation infoset

The [World Wide Web Consortium (W3C) XML Schema Recommendation](https://www.w3.org/XML/Schema) discusses the information set (infoset) that must be exposed for pre-schema validation and post-schema compilation. The XML Schema Object Model (SOM) views this exposure before and after the <xref:System.Xml.Schema.XmlSchemaSet.Compile*> method of the <xref:System.Xml.Schema.XmlSchemaSet> is called.

 The pre-schema validation infoset is built during the editing of the schema. The post-schema compilation infoset is generated after the <xref:System.Xml.Schema.XmlSchemaSet.Compile*> method of the <xref:System.Xml.Schema.XmlSchemaSet> is called, during compilation of the schema, and is exposed as properties.

 The SOM is the object model that represents the pre-schema validation and post-schema compilation infosets; it consists of the classes in the <xref:System.Xml.Schema?displayProperty=nameWithType> namespace. All read and write properties of classes in the <xref:System.Xml.Schema> namespace belong to the pre-schema validation infoset, while all read-only properties of classes in the <xref:System.Xml.Schema> namespace belong to the post-schema compilation infoset. The exception to this rule are the following properties, which are both pre-schema validation infoset and post-schema compilation infoset properties.

|Class|Property|
|-----------|--------------|
|<xref:System.Xml.Schema.XmlSchemaObject>|<xref:System.Xml.Schema.XmlSchemaObject.Parent*>|
|<xref:System.Xml.Schema.XmlSchema>|<xref:System.Xml.Schema.XmlSchema.AttributeFormDefault*>, <xref:System.Xml.Schema.XmlSchema.BlockDefault*>, <xref:System.Xml.Schema.XmlSchema.ElementFormDefault*>, <xref:System.Xml.Schema.XmlSchema.FinalDefault*>, <xref:System.Xml.Schema.XmlSchema.TargetNamespace*>|
|<xref:System.Xml.Schema.XmlSchemaExternal>|<xref:System.Xml.Schema.XmlSchemaExternal.Schema*>|
|<xref:System.Xml.Schema.XmlSchemaAttributeGroup>|<xref:System.Xml.Schema.XmlSchemaAttributeGroup.AnyAttribute*>|
|<xref:System.Xml.Schema.XmlSchemaParticle>|<xref:System.Xml.Schema.XmlSchemaParticle.MaxOccurs*>, <xref:System.Xml.Schema.XmlSchemaParticle.MinOccurs*>|
|<xref:System.Xml.Schema.XmlSchemaComplexType>|<xref:System.Xml.Schema.XmlSchemaComplexType.AnyAttribute*>|

 For example, the <xref:System.Xml.Schema.XmlSchemaElement> and <xref:System.Xml.Schema.XmlSchemaComplexType> classes both have `BlockResolved` and `FinalResolved` properties. These properties are used to hold the values for the `Block` and `Final` properties after the schema has been compiled and validated. `BlockResolved` and `FinalResolved` are read-only properties that are part of the post-schema compilation infoset.

 The following example shows the <xref:System.Xml.Schema.XmlSchemaElement.ElementSchemaType> property of the <xref:System.Xml.Schema.XmlSchemaElement> class set after validating the schema. Before validation, the property contains a `null` reference, and the <xref:System.Xml.Schema.XmlSchemaElement.SchemaTypeName*> is set to the name of the type in question. After validation, the <xref:System.Xml.Schema.XmlSchemaElement.SchemaTypeName*> is resolved to a valid type, and the type object is available through the <xref:System.Xml.Schema.XmlSchemaElement.ElementSchemaType> property.
 [!code-csharp[PsciSample#1](../../../../samples/snippets/csharp/VS_Snippets_Data/PsciSample/CS/PsciSample.cs#1)]
 [!code-vb[PsciSample#1](../../../../samples/snippets/visualbasic/VS_Snippets_Data/PsciSample/VB/PsciSample.vb#1)]

## See also

- [XML Schema Object Model (SOM)](xml-schema-object-model-som.md)

---
description: "Learn more about: Schema Import and Export"
title: "Schema Import and Export"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF, schema import and export"
  - "XsdDataContractExporter class"
  - "XsdDataContractImporter class"
ms.assetid: 0da32b50-ccd9-463a-844c-7fe803d3bf44
---
# Schema Import and Export

Windows Communication Foundation (WCF) includes a new serialization engine, the <xref:System.Runtime.Serialization.DataContractSerializer>. The `DataContractSerializer` translates between .NET Framework objects and XML (in both directions). In addition to the serializer itself, WCF includes associated schema import and schema export mechanisms. *Schema* is a formal, precise, and machine-readable description of the shape of XML that the serializer produces or that the deserializer can access. WCF uses the World Wide Web Consortium (W3C) XML Schema definition language (XSD) as its schema representation, which is widely interoperable with numerous third-party platforms.  
  
 The schema import component, <xref:System.Runtime.Serialization.XsdDataContractImporter>, takes an XSD schema document and generates .NET Framework classes (normally data contract classes) such that the serialized forms correspond to the given schema.  
  
 For example, the following schema fragment:  
  
 [!code-csharp[c_SchemaImportExport#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#8)]
 [!code-vb[c_SchemaImportExport#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#8)]  
  
 generates the following type (simplified slightly for better readability).  
  
 [!code-csharp[c_SchemaImportExport#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/cs/source.cs#1)]
 [!code-vb[c_SchemaImportExport#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_schemaimportexport/vb/source.vb#1)]  
  
 Note that the generated type follows several data contract best practices (found in [Best Practices: Data Contract Versioning](../best-practices-data-contract-versioning.md)):  
  
- The type implements the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface. For more information, see [Forward-Compatible Data Contracts](forward-compatible-data-contracts.md).  
  
- Data members are implemented as public properties that wrap private fields.  
  
- The class is a partial class, and additions can be made without modifying generated code.  
  
 The <xref:System.Runtime.Serialization.XsdDataContractExporter> enables you to do the reverse—take types that are serializable with the `DataContractSerializer` and generate an XSD Schema document.  
  
## Fidelity Is Not Guaranteed  

 It is not guaranteed that schema or types make a round trip with total fidelity. (A *round trip* means to import a schema to create a set of classes, and export the result to create a schema again.) The same schema may not be returned. Reversing the process is also not guaranteed to preserve fidelity. (Export a type to generate its schema, and then import the type back. It is unlikely the same type is returned.)  
  
## Supported Types  

 The data contract model supports only a limited subset of the WC3 schema. Any schema that does not conform to this subset will cause an exception during the import process. For example, there is no way to specify that a data member of a data contract should be serialized as an XML attribute. Thus, schemas that require the use of XML attributes are not supported and will cause exceptions during import, because it is impossible to generate a data contract with the correct XML projection.  
  
 For example, the following schema fragment cannot be imported using the default import settings.  
  
 [!code-xml[c_SchemaImportExport#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_schemaimportexport/common/source.config#9)]  
  
 For more information, see [Data Contract Schema Reference](data-contract-schema-reference.md). If a schema does not conform to the data contract rules, use a different serialization engine. For example, the <xref:System.Xml.Serialization.XmlSerializer> uses its own separate schema import mechanism. Also, there is a special import mode in which the range of supported schema is expanded. For more information, see the section about generating <xref:System.Xml.Serialization.IXmlSerializable> types in [Importing Schema to Generate Classes](importing-schema-to-generate-classes.md).  
  
 The `XsdDataContractExporter` supports any .NET Framework types that can be serialized with the `DataContractSerializer`. For more information, see [Types Supported by the Data Contract Serializer](types-supported-by-the-data-contract-serializer.md). Note that schema generated using the `XsdDataContractExporter` is normally valid data that the `XsdDataContractImporter` can use (unless the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> is used to customize the schema).  
  
 For more information about using the <xref:System.Runtime.Serialization.XsdDataContractImporter>, see [Importing Schema to Generate Classes](importing-schema-to-generate-classes.md).  
  
 For more information about using the <xref:System.Runtime.Serialization.XsdDataContractExporter>, see [Exporting Schemas from Classes](exporting-schemas-from-classes.md).  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- <xref:System.Runtime.Serialization.XsdDataContractImporter>
- <xref:System.Runtime.Serialization.XsdDataContractExporter>
- [Importing Schema to Generate Classes](importing-schema-to-generate-classes.md)
- [Exporting Schemas from Classes](exporting-schemas-from-classes.md)

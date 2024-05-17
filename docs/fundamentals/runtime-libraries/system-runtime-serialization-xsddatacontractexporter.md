---
title: System.Runtime.Serialization.XsdDataContractExporter class
description: Learn about the System.Runtime.Serialization.XsdDataContractExporter class.
ms.date: 12/31/2023
---
# System.Runtime.Serialization.XsdDataContractExporter class

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.Runtime.Serialization.XsdDataContractExporter> class when you have created a Web service that incorporates data represented by common language runtime (CLR) types and when you need to export XML schemas for each type to be consumed by other Web services. That is, <xref:System.Runtime.Serialization.XsdDataContractExporter> transforms a set of CLR types into XML schemas. (For more information about the types that can be used, see [Types Supported by the Data Contract Serializer](../../framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md).) The schemas can then be exposed through a Web Services Description Language (WSDL) document for use by others who need to interoperate with your service.

Conversely, if you are creating a Web service that must interoperate with an existing Web service, use the <xref:System.Runtime.Serialization.XsdDataContractImporter> to transform XML schemas and create the CLR types that represent the data in a selected programming language.

The <xref:System.Runtime.Serialization.XsdDataContractExporter> generates an <xref:System.Xml.Schema.XmlSchemaSet> object that contains the collection of schemas. Access the set of schemas through the <xref:System.Xml.Schema.XmlSchemaSet.Schemas> property.

> [!NOTE]
> To quickly generate XML schema definition (XSD) files that other Web services can consume, use the <xref:System.Runtime.Serialization.XsdDataContractExporter>.

## Export schemas into an XmlSchemaSet

To create an instance of the <xref:System.Xml.Schema.XmlSchemaSet> class that contains XML schema files, you should be aware of the following.

The set of types you are exporting are recorded as an internal set of data contracts. Thus, you can call the <xref:System.Runtime.Serialization.XsdDataContractExporter.CanExport%2A> method multiple times to add new types to the schema set without degrading performance because only the new types will be added to the set. During the <xref:System.Runtime.Serialization.XsdDataContractExporter.Export%2A> operation, the existing schemas are compared to the new schemas being added. If there are conflicts, an exception will be thrown. A conflict is usually detected if two types with the same data contract name but different contracts (different members) are exported by the same <xref:System.Runtime.Serialization.XsdDataContractExporter> instance.

## Use the exporter

A recommended way of using this class is as follows:

1. Use one of the <xref:System.Runtime.Serialization.XsdDataContractExporter.CanExport%2A> overloads to determine whether the specified type or set of types can be exported. Use one of the overloads that is appropriate to your requirements.

2. Call the corresponding <xref:System.Runtime.Serialization.XsdDataContractExporter.Export%2A> method.

3. Retrieve the schemas from the <xref:System.Runtime.Serialization.XsdDataContractExporter.Schemas> property.

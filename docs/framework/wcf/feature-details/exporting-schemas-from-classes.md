---
title: "Exporting Schemas from Classes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF, schema import and export"
  - "schemas [WCF], exporting from classes"
  - "schemas [WCF]"
  - "XsdDataContractExporter class"
  - "XsdDataContractImporter class"
ms.assetid: bb57b962-70c1-45a9-93d5-e721e340a13f
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exporting Schemas from Classes
To generate XML Schema definition language (XSD) schemas from classes that are used in the data contract model, use the <xref:System.Runtime.Serialization.XsdDataContractExporter> class. This topic describes the process for creating schemas.  
  
## The Export Process  
 The schema export process starts with one or more types and produces an <xref:System.Xml.Schema.XmlSchemaSet> that describes the XML projection of these types.  
  
 The `XmlSchemaSet` is part of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]’s Schema Object Model (SOM) that represents a set of XSD Schema documents. To create XSD documents from an `XmlSchemaSet`, use the collection of schemas from the <xref:System.Xml.Schema.XmlSchemaSet.Schemas%2A> property of the `XmlSchemaSet` class. Then serialize each <xref:System.Xml.Schema.XmlSchema> object using the <xref:System.Xml.Serialization.XmlSerializer>.  
  
#### To export schemas  
  
1.  Create an instance of the <xref:System.Runtime.Serialization.XsdDataContractExporter>.  
  
2.  Optional. Pass an <xref:System.Xml.Schema.XmlSchemaSet> in the constructor. In this case, the schema generated during the schema export is added to this <xref:System.Xml.Schema.XmlSchemaSet> instance instead of starting with a blank <xref:System.Xml.Schema.XmlSchemaSet>.  
  
3.  Optional. Call one of the <xref:System.Runtime.Serialization.XsdDataContractExporter.CanExport%2A> methods. The method determines whether the specified type can be exported. The method has the same overloads as the `Export` method in the next step.  
  
4.  Call one of the <xref:System.Runtime.Serialization.XsdDataContractExporter.Export%2A> methods. There are three overloads taking a <xref:System.Type>, a <xref:System.Collections.Generic.List%601> of `Type` objects, or a <xref:System.Collections.Generic.List%601> of <xref:System.Reflection.Assembly> objects. In the last case, all types in all the given assemblies are exported.  
  
     Multiple calls to the `Export` method results in multiple items being added to the same `XmlSchemaSet`. A type is not generated into the `XmlSchemaSet` if it already exists there. Therefore, calling `Export` multiple times on the same `XsdDataContractExporter` is preferable to creating multiple instances of the `XsdDataContractExporter` class. This avoids duplicate schema types from being generated.  
  
    > [!NOTE]
    >  If there is a failure during export, the `XmlSchemaSet` will be in an unpredictable state.  
  
5.  Access the <xref:System.Xml.Schema.XmlSchemaSet> through the <xref:System.Runtime.Serialization.XsdDataContractExporter.Schemas%2A> property.  
  
## Export Options  
 You can set the <xref:System.Runtime.Serialization.XsdDataContractExporter.Options%2A> property of the <xref:System.Runtime.Serialization.XsdDataContractExporter> to an instance of the <xref:System.Runtime.Serialization.ExportOptions> class to control various aspects of the export process. Specifically, you can set the following options:  
  
-   <xref:System.Runtime.Serialization.ExportOptions.KnownTypes%2A>. This collection of `Type` represents the known types for the types being exported. ([!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md).) These known types are exported on every `Export` call in addition to the types passed to the `Export` method.  
  
-   <xref:System.Runtime.Serialization.ExportOptions.DataContractSurrogate%2A>. An <xref:System.Runtime.Serialization.IDataContractSurrogate> can be supplied through this property that will customize the export process. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Surrogates](../../../../docs/framework/wcf/extending/data-contract-surrogates.md). By default, no surrogate is used.  
  
## Helper Methods  
 In addition to its primary role of exporting schema, the `XsdDataContractExporter` provides several useful helper methods that provide information about types. These include:  
  
-   <xref:System.Runtime.Serialization.XsdDataContractExporter.GetRootElementName%2A> method. This method takes a `Type` and returns an <xref:System.Xml.XmlQualifiedName> that represents the root element name and namespace that would be used if this type were serialized as the root object.  
  
-   <xref:System.Runtime.Serialization.XsdDataContractExporter.GetSchemaTypeName%2A> method. This method takes a `Type` and returns an <xref:System.Xml.XmlQualifiedName> that represents the name of the XSD schema type that would be used if this type were exported to the schema. For <xref:System.Xml.Serialization.IXmlSerializable> types represented as anonymous types in the schema, this method returns `null`.  
  
-   <xref:System.Runtime.Serialization.XsdDataContractExporter.GetSchemaType%2A> method. This method works only with <xref:System.Xml.Serialization.IXmlSerializable> types that are represented as anonymous types in the schema, and returns `null` for all other types. For anonymous types, this method returns an <xref:System.Xml.Schema.XmlSchemaType> that represents a given `Type`.  
  
 Export options affect all of these methods.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Runtime.Serialization.XsdDataContractImporter>  
 <xref:System.Runtime.Serialization.XsdDataContractExporter>  
 [Schema Import and Export](../../../../docs/framework/wcf/feature-details/schema-import-and-export.md)  
 [Importing Schema to Generate Classes](../../../../docs/framework/wcf/feature-details/importing-schema-to-generate-classes.md)

---
title: "Inferring DataSet Relational Structure from XML"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cd2f41c6-6785-420e-aa43-3ceb0bdccdce
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Inferring DataSet Relational Structure from XML
The relational structure, or schema, of a <xref:System.Data.DataSet> is made up of tables, columns, constraints, and relations. When loading a <xref:System.Data.DataSet> from XML, the schema can be predefined, or it can be created, either explicitly or through inference, from the XML being loaded. For more information about loading the schema and contents of a <xref:System.Data.DataSet> from XML, see [Loading a DataSet from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-a-dataset-from-xml.md) and [Loading DataSet Schema Information from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml.md).  
  
 If the schema of a <xref:System.Data.DataSet> is being created from XML, the preferred method is to explicitly specify the schema using either the XML Schema definition language (XSD) (as described in [Deriving DataSet Relational Structure from XML Schema (XSD)](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/deriving-dataset-relational-structure-from-xml-schema-xsd.md)) or the XML-Data Reduced (XDR). If no XML Schema or XDR schema is available in the XML, the schema of the <xref:System.Data.DataSet> can be inferred from the structure of the XML elements and attributes.  
  
 This section describes the rules for <xref:System.Data.DataSet> schema inference by showing XML elements and attributes and their structure, and the resulting inferred <xref:System.Data.DataSet> schema.  
  
 Not all attributes present in an XML document should be included in the inference process. Namespace-qualified attributes can include metadata that is important for the XML document but not for the <xref:System.Data.DataSet> schema. Using <xref:System.Data.DataSet.InferXmlSchema%2A>, you can specify namespaces to be ignored during the inference process. For more information, see [Loading DataSet Schema Information from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml.md).  
  
## In This Section  
 [Summary of the DataSet Schema Inference Process](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/summary-of-the-dataset-schema-inference-process.md)  
 Provides a high-level summary of the rules for inferring the schema of a <xref:System.Data.DataSet> from XML.  
  
 [Inferring Tables](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-tables.md)  
 Describes the XML elements that are inferred as tables in a <xref:System.Data.DataSet>.  
  
 [Inferring Columns](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-columns.md)  
 Describes the XML elements and attributes that are inferred as table columns.  
  
 [Inferring Relationships](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-relationships.md)  
 Describes the <xref:System.Data.DataRelation> and <xref:System.Data.ForeignKeyConstraint> objects created for nested, inferred tables.  
  
 [Inferring Element Text](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-element-text.md)  
 Describes the columns that are created for text in XML elements, and explains when text in XML elements is ignored.  
  
 [Inference Limitations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inference-limitations.md)  
 Discusses the limitations of schema inference.  
  
## Related Sections  
 [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)  
 Describes how the <xref:System.Data.DataSet> object interacts with XML data.  
  
 [Deriving DataSet Relational Structure from XML Schema (XSD)](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/deriving-dataset-relational-structure-from-xml-schema-xsd.md)  
 Describes the relational structure, or schema, of a <xref:System.Data.DataSet> that is created from XML Schema definition language (XSD) schema.  
  
 [ADO.NET Overview](../../../../../docs/framework/data/adonet/ado-net-overview.md)  
 Describes the ADO.NET architecture and components and how to use them to access existing data sources and manage application data.  
  
## See Also  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

---
title: "Using XML in a DataSet"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 35138159-e199-49ec-baf7-1ec6777e171e
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Using XML in a DataSet
With ADO.NET you can fill a <xref:System.Data.DataSet> from an XML stream or document. You can use the XML stream or document to supply to the <xref:System.Data.DataSet> either data, schema information, or both. The information supplied from the XML stream or document can be combined with existing data or schema information already present in the <xref:System.Data.DataSet>.  
  
 ADO.NET also allows you to create an XML representation of a <xref:System.Data.DataSet>, with or without its schema, in order to transport the <xref:System.Data.DataSet> across HTTP for use by another application or XML-enabled platform. In an XML representation of a <xref:System.Data.DataSet>, the data is written in XML and the schema, if it is included inline in the representation, is written using the XML Schema definition language (XSD). XML and XML Schema provide a convenient format for transferring the contents of a <xref:System.Data.DataSet> to and from remote clients.  
  
## In This Section  
 [DiffGrams](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/diffgrams.md)  
 Provides details on the DiffGram, an XML format used to read and write the contents of a <xref:System.Data.DataSet>.  
  
 [Loading a DataSet from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-a-dataset-from-xml.md)  
 Discusses different options to consider when loading the contents of a <xref:System.Data.DataSet> from an XML document.  
  
 [Writing DataSet Contents as XML Data](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/writing-dataset-contents-as-xml-data.md)  
 Discusses how to generate the contents of a <xref:System.Data.DataSet> as XML data, and the different XML format options you can use.  
  
 [Loading DataSet Schema Information from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml.md)  
 Discusses the <xref:System.Data.DataSet> methods used to load the schema of a <xref:System.Data.DataSet> from XML.  
  
 [Writing DataSet Schema Information as XSD](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/writing-dataset-schema-information-as-xsd.md)  
 Discusses the uses for an XML Schema and how to generate one from a <xref:System.Data.DataSet>.  
  
 [DataSet and XmlDataDocument Synchronization](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataset-and-xmldatadocument-synchronization.md)  
 Discusses the capability available in the .NET Framework of synchronous access to both relational and hierarchical views of a single set of data, and shows how to create a synchronous relationship between a <xref:System.Data.DataSet> and an <xref:System.Xml.XmlDataDocument>.  
  
 [Nesting DataRelations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/nesting-datarelations.md)  
 Discusses the importance of nested <xref:System.Data.DataRelation> objects when representing the contents of a <xref:System.Data.DataSet> as XML data, and describes how to create them.  
  
 [Deriving DataSet Relational Structure from XML Schema (XSD)](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/deriving-dataset-relational-structure-from-xml-schema-xsd.md)  
 Describes the relational structure, or schema, of a <xref:System.Data.DataSet> that is created from XML Schema.  
  
 [Inferring DataSet Relational Structure from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-dataset-relational-structure-from-xml.md)  
 Describes the resulting relational structure, or schema, of a <xref:System.Data.DataSet> that is created when inferred from XML elements.  
  
## Related Sections  
 [ADO.NET Overview](../../../../../docs/framework/data/adonet/ado-net-overview.md)  
 Describes the ADO.NET architecture and components, and how to use them to access existing data sources as well as to manage application data.  
  
## See Also  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

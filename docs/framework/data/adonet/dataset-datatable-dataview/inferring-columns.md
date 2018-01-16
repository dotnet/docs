---
title: "Inferring Columns"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0e022699-c922-454c-93e2-957dd7e7247a
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Inferring Columns
After ADO.NET has determined from an XML document which elements to infer as tables for a <xref:System.Data.DataSet>, it then infers the columns for those tables. ADO.NET 2.0 introduced a new schema inference engine that infers a strongly typed data type for each **simpleType** element. In previous versions, the data type of an inferred **simpleType** element was always **xsd:string**.  
  
## Migration and Backward Compatibility  
 The **ReadXml** method takes an argument of type **InferSchema**. This argument allows you to specify inference behavior compatible with previous versions. The available values for the **InferSchema** enumeration are shown in the following table.  
  
 <xref:System.Data.XmlReadMode.InferSchema>  
 Provides backward compatibility by always inferring a simple type as <xref:System.String>.  
  
 <xref:System.Data.XmlReadMode.InferTypedSchema>  
 Infers a strongly typed data type. Throws an exception if used with a <xref:System.Data.DataTable>.  
  
 <xref:System.Data.XmlReadMode.IgnoreSchema>  
 Ignores any inline schema and reads data into the existing <xref:System.Data.DataSet> schema.  
  
## Attributes  
 As defined in [Inferring Tables](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-tables.md), an element with attributes will be inferred as a table. The attributes of that element will then be inferred as columns for the table. The **ColumnMapping** property of the columns will be set to **MappingType.Attribute**, to ensure that the column names will be written as attributes if the schema is written back to XML. The values of the attributes are stored in a row in the table. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1 attr1="value1" attr2="value2"/>  
</DocumentElement>  
```  
  
 The inference process will produce a table named **Element1** with two columns, **attr1** and **attr2**. The **ColumnMapping** property of both columns will be set to **MappingType.Attribute**.  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|attr1|attr2|  
|-----------|-----------|  
|value1|value2|  
  
## Elements Without Attributes or Child Elements  
 If an element has no child elements or attributes, it will be inferred as a column. The **ColumnMapping** property of the column will be set to **MappingType.Element**. The text for child elements is stored in a row in the table. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>  
    <ChildElement1>Text1</ChildElement1>  
    <ChildElement2>Text2</ChildElement2>  
  </Element1>  
</DocumentElement>  
```  
  
 The inference process will produce a table named **Element1** with two columns, **ChildElement1** and **ChildElement2**. The **ColumnMapping** property of both columns will be set to **MappingType.Element**.  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|ChildElement1|ChildElement2|  
|-------------------|-------------------|  
|Text1|Text2|  
  
## See Also  
 [Inferring DataSet Relational Structure from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-dataset-relational-structure-from-xml.md)  
 [Loading a DataSet from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-a-dataset-from-xml.md)  
 [Loading DataSet Schema Information from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml.md)  
 [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

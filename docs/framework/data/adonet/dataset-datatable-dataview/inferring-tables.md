---
title: "Inferring Tables"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 74a288d4-b8e9-4f1a-b2cd-10df92c1ed1f
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Inferring Tables
When inferring a schema for a <xref:System.Data.DataSet> from an XML document, ADO.NET first determines which XML elements represent tables. The following XML structures result in a table for the **DataSet** schema:  
  
-   Elements with attributes  
  
-   Elements with child elements  
  
-   Repeating elements  
  
## Elements with Attributes  
 Elements that have attributes specified in them result in inferred tables. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1 attr1="value1"/>  
  <Element1 attr1="value2">Text1</Element1>  
</DocumentElement>  
```  
  
 The inference process produces a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|attr1|Element1_Text|  
|-----------|--------------------|  
|value1||  
|value2|Text1|  
  
## Elements with Child Elements  
 Elements that have child elements result in inferred tables. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>  
    <ChildElement1>Text1</ChildElement1>  
  </Element1>  
</DocumentElement>  
```  
  
 The inference process produces a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|ChildElement1|  
|-------------------|  
|Text1|  
  
 The document, or root, element result in an inferred table if it has attributes or child elements that are inferred as columns. If the document element has no attributes and no child elements that would be inferred as columns, the element is inferred as a **DataSet**. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>Text1</Element1>  
  <Element2>Text2</Element2>  
</DocumentElement>  
```  
  
 The inference process produces a table named "DocumentElement."  
  
 **DataSet:** NewDataSet  
  
 **Table:** DocumentElement  
  
|Element1|Element2|  
|--------------|--------------|  
|Text1|Text2|  
  
 Alternatively, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1 attr1="value1" attr2="value2"/>  
</DocumentElement>  
```  
  
 The inference process produces a **DataSet** named "DocumentElement" that contains a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|attr1|attr2|  
|-----------|-----------|  
|value1|value2|  
  
## Repeating Elements  
 Elements that repeat result in a single inferred table. For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>Text1</Element1>  
  <Element1>Text2</Element1>  
</DocumentElement>  
```  
  
 The inference process produces a table named "Element1."  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|Element1_Text|  
|--------------------|  
|Text1|  
|Text2|  
  
## See Also  
 [Inferring DataSet Relational Structure from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-dataset-relational-structure-from-xml.md)  
 [Loading a DataSet from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-a-dataset-from-xml.md)  
 [Loading DataSet Schema Information from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml.md)  
 [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

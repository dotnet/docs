---
title: "Inferring Relationships"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8fa86a9d-6545-4a9d-b1f5-58d9742179c7
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Inferring Relationships
If an element that is inferred as a table has a child element that is also inferred as a table, a <xref:System.Data.DataRelation> will be created between the two tables. A new column with a name of **ParentTableName_Id** will be added to both the table created for the parent element, and the table created for the child element. The **ColumnMapping** property of this identity column will be set to **MappingType.Hidden**. The column will be an auto-incrementing primary key for the parent table, and will be used for the **DataRelation** between the two tables. The data type of the added identity column will be **System.Int32**, unlike the data type of all other inferred columns, which is **System.String**. A <xref:System.Data.ForeignKeyConstraint> with **DeleteRule** = **Cascade** will also be created using the new column in both the parent and child tables.  
  
 For example, consider the following XML:  
  
```xml  
<DocumentElement>  
  <Element1>  
    <ChildElement1 attr1="value1" attr2="value2"/>  
    <ChildElement2>Text2</ChildElement2>  
  </Element1>  
</DocumentElement>  
```  
  
 The inference process will produce two tables: **Element1** and **ChildElement1**.  
  
 The **Element1** table will have two columns: **Element1_Id** and **ChildElement2**. The **ColumnMapping** property of the **Element1_Id** column will be set to **MappingType.Hidden**. The **ColumnMapping** property of the **ChildElement2** column will be set to **MappingType.Element**. The **Element1_Id** column will be set as the primary key of the **Element1** table.  
  
 The **ChildElement1** table will have three columns: **attr1**, **attr2** and **Element1_Id**. The **ColumnMapping** property for the **attr1** and **attr2** columns will be set to **MappingType.Attribute**. The **ColumnMapping** property of the **Element1_Id** column will be set to **MappingType.Hidden**.  
  
 A **DataRelation** and **ForeignKeyConstraint** will be created using the **Element1_Id** columns from both tables.  
  
 **DataSet:** DocumentElement  
  
 **Table:** Element1  
  
|Element1_Id|ChildElement2|  
|------------------|-------------------|  
|0|Text2|  
  
 **Table:** ChildElement1  
  
|attr1|attr2|Element1_Id|  
|-----------|-----------|------------------|  
|value1|value2|0|  
  
 **DataRelation:** Element1_ChildElement1  
  
 **ParentTable:** Element1  
  
 **ParentColumn:** Element1_Id  
  
 **ChildTable:** ChildElement1  
  
 **ChildColumn:** Element1_Id  
  
 **Nested:** True  
  
 **ForeignKeyConstraint:** Element1_ChildElement1  
  
 **Column:** Element1_Id  
  
 **ParentTable:** Element1  
  
 **ChildTable:** ChildElement1  
  
 **DeleteRule:** Cascade  
  
 **AcceptRejectRule:** None  
  
## See Also  
 [Inferring DataSet Relational Structure from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-dataset-relational-structure-from-xml.md)  
 [Loading a DataSet from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-a-dataset-from-xml.md)  
 [Loading DataSet Schema Information from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml.md)  
 [Nesting DataRelations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/nesting-datarelations.md)  
 [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

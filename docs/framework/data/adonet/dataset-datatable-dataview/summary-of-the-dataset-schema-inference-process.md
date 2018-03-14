---
title: "Summary of the DataSet Schema Inference Process"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fd0891c8-d068-4e30-a76f-7c375f078bf7
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Summary of the DataSet Schema Inference Process
The inference process first determines, from the XML document, which elements will be inferred as tables. From the remaining XML, the inference process determines the columns for those tables. For nested tables, the inference process generates nested <xref:System.Data.DataRelation> and <xref:System.Data.ForeignKeyConstraint> objects.  
  
 Following is a brief summary of inference rules:  
  
-   Elements that have attributes are inferred as tables.  
  
-   Elements that have child elements are inferred as tables.  
  
-   Elements that repeat are inferred as a single table.  
  
-   If the document, or root, element has no attributes, and no child elements that would be inferred as columns, it is inferred as a <xref:System.Data.DataSet>. Otherwise, the document element is inferred as a table.  
  
-   Attributes are inferred as columns.  
  
-   Elements that have no attributes or child elements, and that do not repeat, are inferred as columns.  
  
-   For elements that are inferred as nested tables within other elements that are also inferred as tables, a nested **DataRelation** is created between the two tables. A new, primary key column named **TableName_Id** is added to both tables and used by the **DataRelation**. A **ForeignKeyConstraint** is created between the two tables using the **TableName_Id** column.  
  
-   For elements that are inferred as tables and that contain text but have no child elements, a new column named **TableName_Text** is created for the text of each of the elements. If an element is inferred as a table and has text, but also has child elements, the text is ignored.  
  
## See Also  
 [Inferring DataSet Relational Structure from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/inferring-dataset-relational-structure-from-xml.md)  
 [Loading a DataSet from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-a-dataset-from-xml.md)  
 [Loading DataSet Schema Information from XML](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml.md)  
 [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

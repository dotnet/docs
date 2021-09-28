---
description: "Learn more about: Summary of the DataSet Schema Inference Process"
title: "Summary of the DataSet Schema Inference Process"
ms.date: "03/30/2017"
ms.assetid: fd0891c8-d068-4e30-a76f-7c375f078bf7
---
# Summary of the DataSet Schema Inference Process

The inference process first determines, from the XML document, which elements will be inferred as tables. From the remaining XML, the inference process determines the columns for those tables. For nested tables, the inference process generates nested <xref:System.Data.DataRelation> and <xref:System.Data.ForeignKeyConstraint> objects.  
  
 The following is a brief summary of inference rules:  
  
- Elements that have attributes are inferred as tables.  
  
- Elements that have child elements are inferred as tables.  
  
- Elements that repeat are inferred as a single table.  
  
- If the document, or root, element has no attributes, and no child elements that would be inferred as columns, it is inferred as a <xref:System.Data.DataSet>. Otherwise, the document element is inferred as a table.  
  
- Attributes are inferred as columns.  
  
- Elements that have no attributes or child elements, and that do not repeat, are inferred as columns.  
  
- For elements that are inferred as nested tables within other elements that are also inferred as tables, a nested **DataRelation** is created between the two tables. A new, primary key column named **TableName_Id** is added to both tables and used by the **DataRelation**. A **ForeignKeyConstraint** is created between the two tables using the **TableName_Id** column.  
  
- For elements that are inferred as tables and that contain text but have no child elements, a new column named **TableName_Text** is created for the text of each of the elements. If an element is inferred as a table and has text, but also has child elements, the text is ignored.  
  
## See also

- [Inferring DataSet Relational Structure from XML](inferring-dataset-relational-structure-from-xml.md)
- [Loading a DataSet from XML](loading-a-dataset-from-xml.md)
- [Loading DataSet Schema Information from XML](loading-dataset-schema-information-from-xml.md)
- [Using XML in a DataSet](using-xml-in-a-dataset.md)
- [DataSets, DataTables, and DataViews](index.md)
- [ADO.NET Overview](../ado-net-overview.md)

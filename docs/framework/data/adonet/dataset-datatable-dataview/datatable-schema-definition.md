---
title: "DataTable Schema Definition"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: efbcdda4-f5a9-421d-8be2-4c194c74552f
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# DataTable Schema Definition
The schema, or structure, of a table is represented by columns and constraints. You define the schema of a <xref:System.Data.DataTable> using <xref:System.Data.DataColumn> objects as well as <xref:System.Data.ForeignKeyConstraint> and <xref:System.Data.UniqueConstraint> objects. The columns in a table can map to columns in a data source, contain calculated values from expressions, automatically increment their values, or contain primary key values.  
  
 References by name to columns, relations, and constraints in a table are case-sensitive. Two or more columns, relations, or constraints can therefore exist in a table that have the same name, but that differ in case. For example, you can have **Col1** and **col1**. In such as case, a reference to one of the columns by name must match the case of the column name exactly; otherwise an exception is thrown. For example, if the table **myTable** contains the columns **Col1** and **col1**, you would reference **Col1** by name as **myTable.Columns["Col1"]**, and **col1** as **myTable.Columns["col1"]**. Attempting to reference either of the columns as **myTable.Columns["COL1"]** would generate an exception.  
  
 The case-sensitivity rule does not apply if only one column, relation, or constraint  with a particular name exists. That is, if no other column, relation, or constraint object in the table matches the name of that particular column, relation, or constraint object, you may reference the object by name using any case, and no exception is thrown. For example, if the table has only **Col1**, you can reference it using **my.Columns["COL1"]**.  
  
> [!NOTE]
>  The <xref:System.Data.DataTable.CaseSensitive%2A> property of the **DataTable** does not affect this behavior. The **CaseSensitive** property applies to the data in a table and affects sorting, searching, filtering, enforcing constraints, and so on, but not to references to the columns, relations, and constraints.  
  
## In This Section  
 [Adding Columns to a DataTable](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/adding-columns-to-a-datatable.md)  
 Describes how to define the columns of a table using **DataColumn** objects.  
  
 [Creating Expression Columns](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/creating-expression-columns.md)  
 Explains how the **Expression** property of a column can be used to calculate values based on the values from other columns in the row.  
  
 [Creating AutoIncrement Columns](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/creating-autoincrement-columns.md)  
 Describes how a column can be set to automatically increment numerical values to ensure a unique column value per row.  
  
 [Defining Primary Keys](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/defining-primary-keys.md)  
 Describes how to specify the primary key of a table from one or more **DataColumn** objects.  
  
 [DataTable Constraints](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/datatable-constraints.md)  
 Describes how to define foreign key and unique constraints for columns in a table.  
  
## See Also  
 [DataTables](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/datatables.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

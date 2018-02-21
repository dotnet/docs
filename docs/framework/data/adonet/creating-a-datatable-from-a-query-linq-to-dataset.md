---
title: "Creating a DataTable From a Query (LINQ to DataSet)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 1b97afeb-03f8-41e2-8eb3-58aff65f7d18
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Creating a DataTable From a Query (LINQ to DataSet)
Data binding is a common use of <xref:System.Data.DataTable> object. The <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method takes the results of a query and copies the data into a <xref:System.Data.DataTable>, which can then be used for data binding. When the data operations have been performed, the new <xref:System.Data.DataTable> is merged back into the source <xref:System.Data.DataTable>.  
  
 The <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method uses the following process to create a <xref:System.Data.DataTable> from a query:  
  
1.  The <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method clones a <xref:System.Data.DataTable> from the source table (a <xref:System.Data.DataTable> object that implements the <xref:System.Linq.IQueryable%601> interface). The <xref:System.Collections.IEnumerable> source has generally originated from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] expression or method query.  
  
2.  The schema of the cloned <xref:System.Data.DataTable> is built from the columns of the first enumerated <xref:System.Data.DataRow> object in the source table and the name of the cloned table is the name of the source table with the word "query" appended to it.  
  
3.  For each row in the source table, the content of the row is copied into a new <xref:System.Data.DataRow> object, which is then inserted into the cloned table. The <xref:System.Data.DataRow.RowState%2A> and <xref:System.Data.DataRow.RowError%2A> properties are preserved across the copy operation. An <xref:System.ArgumentException> is thrown if the <xref:System.Data.DataRow> objects in the source are from different tables.  
  
4.  The cloned <xref:System.Data.DataTable> is returned after all <xref:System.Data.DataRow> objects in the input queryable table have been copied. If the source sequence does not contain any <xref:System.Data.DataRow> objects, the method returns an empty <xref:System.Data.DataTable>.  
  
 Note that calling the <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method will cause the query bound to the source table to execute.  
  
 When the <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method encounters either a null reference or nullable value type in a row in the source table, it replaces the value with <xref:System.DBNull.Value>. This way, null values are handled correctly in the returned <xref:System.Data.DataTable>.  
  
 Note: The <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method accepts as input a query that can return rows from multiple <xref:System.Data.DataTable> or <xref:System.Data.DataSet> objects. The <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method will copy the data but not the properties from the source <xref:System.Data.DataTable> or <xref:System.Data.DataSet> objects to the returned <xref:System.Data.DataTable>. You will need to explicitly set the properties on the returned <xref:System.Data.DataTable>, such as <xref:System.Data.DataTable.Locale%2A> and <xref:System.Data.DataTable.TableName%2A>.  
  
 The following example queries the SalesOrderHeader table for orders after August 8, 2001 and uses the <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> method to create a <xref:System.Data.DataTable> from that query. The <xref:System.Data.DataTable> is then bound to a <xref:System.Windows.Forms.BindingSource>, which acts as proxy for a <xref:System.Windows.Forms.DataGridView>.  
  
 [!code-csharp[DP LINQ to DataSet Examples#CopyToDataTable1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#copytodatatable1)]
 [!code-vb[DP LINQ to DataSet Examples#CopyToDataTable1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#copytodatatable1)]  
  
## Creating a Custom CopyToDataTable\<T> Method  
 The existing <xref:System.Data.DataTableExtensions.CopyToDataTable%2A> methods only operate on an <xref:System.Collections.Generic.IEnumerable%601> source where the generic parameter `T` is of type <xref:System.Data.DataRow>. Although this is useful, it does not allow tables to be created from a sequence of scalar types, from queries that return anonymous types, or from queries that perform table joins. For an example of how to implement two custom `CopyToDataTable` methods that load a table from a sequence of scalar or anonymous types, see [How to: Implement CopyToDataTable\<T> Where the Generic Type T Is Not a DataRow](../../../../docs/framework/data/adonet/implement-copytodatatable-where-type-not-a-datarow.md)s.  
  
 The examples in this section use the following custom types:  
  
 [!code-csharp[DP Custom CopyToDataTable Examples#ItemClass](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/CS/Program.cs#itemclass)]
 [!code-vb[DP Custom CopyToDataTable Examples#ItemClass](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/VB/Module1.vb#itemclass)]  
  
### Example  
 This example performs a join over the `SalesOrderHeader` and `SalesOrderDetail` tables to get online orders from the month of August and creates a table from the query.  
  
 [!code-csharp[DP Custom CopyToDataTable Examples#Join](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/CS/Program.cs#join)]
 [!code-vb[DP Custom CopyToDataTable Examples#Join](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/VB/Module1.vb#join)]  
  
### Example  
 The following example queries a collection for items of price greater than $9.99 and creates a table from the query results.  
  
 [!code-csharp[DP Custom CopyToDataTable Examples#LoadItemsIntoTable](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/CS/Program.cs#loaditemsintotable)]
 [!code-vb[DP Custom CopyToDataTable Examples#LoadItemsIntoTable](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/VB/Module1.vb#loaditemsintotable)]  
  
### Example  
 The following example queries a collection for items of price greater than 9.99 and projects the results. The returned sequence of anonymous types is loaded into an existing table.  
  
 [!code-csharp[DP Custom CopyToDataTable Examples#LoadItemsIntoExistingTable](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/CS/Program.cs#loaditemsintoexistingtable)]
 [!code-vb[DP Custom CopyToDataTable Examples#LoadItemsIntoExistingTable](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/VB/Module1.vb#loaditemsintoexistingtable)]  
  
### Example  
 The following example queries a collection for items of price greater than $9.99 and projects the results. The returned sequence of anonymous types is loaded into an existing table. The table schema is automatically expanded because the `Book` and `Movies` types are derived from the `Item` type.  
  
 [!code-csharp[DP Custom CopyToDataTable Examples#LoadItemsExpandSchema](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/CS/Program.cs#loaditemsexpandschema)]
 [!code-vb[DP Custom CopyToDataTable Examples#LoadItemsExpandSchema](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/VB/Module1.vb#loaditemsexpandschema)]  
  
### Example  
 The following example queries a collection for items of price greater than $9.99 and returns a sequence of <xref:System.Double>, which is loaded into a new table.  
  
 [!code-csharp[DP Custom CopyToDataTable Examples#LoadScalarSequence](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/CS/Program.cs#loadscalarsequence)]
 [!code-vb[DP Custom CopyToDataTable Examples#LoadScalarSequence](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP Custom CopyToDataTable Examples/VB/Module1.vb#loadscalarsequence)]  
  
## See Also  
 [Programming Guide](../../../../docs/framework/data/adonet/programming-guide-linq-to-dataset.md)  
 [Generic Field and SetField Methods](../../../../docs/framework/data/adonet/generic-field-and-setfield-methods-linq-to-dataset.md)  
 [LINQ to DataSet Examples](../../../../docs/framework/data/adonet/linq-to-dataset-examples.md)

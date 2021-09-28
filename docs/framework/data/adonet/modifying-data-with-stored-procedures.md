---
description: "Learn more about: Modifying Data with Stored Procedures"
title: "Modifying Data with Stored Procedures"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 7d8e9a46-1af6-4a02-bf61-969d77ae07e0
---
# Modifying Data with Stored Procedures

Stored procedures can accept data as input parameters and can return data as output parameters, result sets, or return values. The sample below illustrates how ADO.NET sends and receives input parameters, output parameters, and return values. The example inserts a new record into a table where the primary key column is an identity column in a SQL Server database.  
  
> [!NOTE]
> If you are using SQL Server stored procedures to edit or delete data using a <xref:System.Data.SqlClient.SqlDataAdapter>, make sure that you do not use SET NOCOUNT ON in the stored procedure definition. This causes the rows affected count returned to be zero, which the `DataAdapter` interprets as a concurrency conflict. In this event, a <xref:System.Data.DBConcurrencyException> will be thrown.  
  
## Example  

 The sample uses the following stored procedure to insert a new category into the **Northwind** **Categories** table. The stored procedure takes the value in the **CategoryName** column as an input parameter and uses the SCOPE_IDENTITY() function to retrieve the new value of the identity field, **CategoryID**, and return it in an output parameter. The RETURN statement uses the @@ROWCOUNT function to return the number of rows inserted.  
  
```sql
CREATE PROCEDURE dbo.InsertCategory  
  @CategoryName nvarchar(15),  
  @Identity int OUT  
AS  
INSERT INTO Categories (CategoryName) VALUES(@CategoryName)  
SET @Identity = SCOPE_IDENTITY()  
RETURN @@ROWCOUNT  
```  
  
 The following code example uses the `InsertCategory` stored procedure shown above as the source for the <xref:System.Data.SqlClient.SqlDataAdapter.InsertCommand%2A> of the <xref:System.Data.SqlClient.SqlDataAdapter>. The `@Identity` output parameter will be reflected in the <xref:System.Data.DataSet> after the record has been inserted into the database when the `Update` method of the <xref:System.Data.SqlClient.SqlDataAdapter> is called. The code also retrieves the return value.  
  
> [!NOTE]
> When using the <xref:System.Data.OleDb.OleDbDataAdapter>, you must specify parameters with a <xref:System.Data.ParameterDirection> of **ReturnValue** before the other parameters.  
  
 [!code-csharp[DataWorks SqlClient.SprocIdentityReturn#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlClient.SprocIdentityReturn/CS/source.cs#1)]
 [!code-vb[DataWorks SqlClient.SprocIdentityReturn#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlClient.SprocIdentityReturn/VB/source.vb#1)]  
  
## See also

- [Retrieving and Modifying Data in ADO.NET](retrieving-and-modifying-data.md)
- [DataAdapters and DataReaders](dataadapters-and-datareaders.md)
- [Executing a Command](executing-a-command.md)
- [ADO.NET Overview](ado-net-overview.md)

---
title: "Bulk Copy Operations in SQL Server"
description: Learn to use the SqlBulkCopy class to write managed code solutions that bulk copy large files into tables or views in SQL Server databases. 
ms.date: "03/30/2017"
ms.assetid: 83a7a0d2-8018-4354-97b9-0b1d99f8342b
---
# Bulk Copy Operations in SQL Server

Microsoft SQL Server includes a popular command-line utility named **bcp** for quickly bulk copying large files into tables or views in SQL Server databases. The <xref:System.Data.SqlClient.SqlBulkCopy> class allows you to write managed code solutions that provide similar functionality. There are other ways to load data into a SQL Server table (INSERT statements, for example) but <xref:System.Data.SqlClient.SqlBulkCopy> offers a significant performance advantage over them.  
  
 The <xref:System.Data.SqlClient.SqlBulkCopy> class can be used to write data only to SQL Server tables. But the data source is not limited to SQL Server; any data source can be used, as long as the data can be loaded to a <xref:System.Data.DataTable> instance or read with a <xref:System.Data.IDataReader> instance.  
  
 Using the <xref:System.Data.SqlClient.SqlBulkCopy> class, you can perform:  
  
- A single bulk copy operation  
  
- Multiple bulk copy operations  
  
- A bulk copy operation within a transaction  
  
> [!NOTE]
> When using .NET Framework version 1.1 or earlier (which does not support the <xref:System.Data.SqlClient.SqlBulkCopy> class), you can execute the SQL Server Transact-SQL **BULK INSERT** statement using the <xref:System.Data.SqlClient.SqlCommand> object.  
  
## In This Section  

 [Bulk Copy Example Setup](bulk-copy-example-setup.md)  
 Describes the tables used in the bulk copy examples and provides SQL scripts for creating the tables in the AdventureWorks database.  
  
 [Single Bulk Copy Operations](single-bulk-copy-operations.md)  
 Describes how to do a single bulk copy of data into an instance of SQL Server using the <xref:System.Data.SqlClient.SqlBulkCopy> class, and how to perform the bulk copy operation using Transact-SQL statements and the <xref:System.Data.SqlClient.SqlCommand> class.  
  
 [Multiple Bulk Copy Operations](multiple-bulk-copy-operations.md)  
 Describes how to do multiple bulk copy operations of data into an instance of SQL Server using the <xref:System.Data.SqlClient.SqlBulkCopy> class.  
  
 [Transaction and Bulk Copy Operations](transaction-and-bulk-copy-operations.md)  
 Describes how to perform a bulk copy operation within a transaction, including how to commit or rollback the transaction.  
  
## See also

- [SQL Server and ADO.NET](index.md)
- [ADO.NET Overview](../ado-net-overview.md)

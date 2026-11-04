---
description: "Learn more about the simplest approach to performing a SQL Server bulk copy operation by performing a single operation against a database."
title: "Single Bulk Copy Operations"
ms.date: "10/23/2026"
dev_langs:
  - "csharp"
  - "vb"
ms.custom: sfi-ropc-nochange
---
# Single bulk copy operations

The simplest approach to performing a SQL Server bulk copy operation is to perform a single operation against a database. By default, a bulk copy operation is performed as an isolated operation: the copy operation occurs in a non-transacted way, with no opportunity for rolling it back.

> [!NOTE]
> To roll back all or part of a bulk copy after an error, specify `SqlBulkCopyOptions.UseInternalTransaction` for per-batch transactions, or perform the copy within an existing transaction. `SqlBulkCopy` also works with <xref:System.Transactions> if the connection is enlisted implicitly or explicitly.
>
> For more information, see [Transaction and Bulk Copy Operations](transaction-and-bulk-copy-operations.md).

The general steps for performing a bulk copy operation are as follows:

1. Connect to the source server and obtain the data to be copied. Data can also come from other sources, if it can be retrieved from an <xref:System.Data.IDataReader> or <xref:System.Data.DataTable> object.

1. Connect to the destination server (unless you want `SqlBulkCopy` to establish a connection for you).

1. Create the <xref:Microsoft.Data.SqlClient.SqlBulkCopy> object and set the necessary properties.

1. Set the `DestinationTableName` property to indicate the target table for the bulk insert operation.

1. Call one of the `WriteToServer` methods.

1. Optionally, update properties and call `WriteToServer` again as necessary.

1. Call <xref:Microsoft.Data.SqlClient.SqlBulkCopy.Close*>, or wrap the bulk copy operations within a `Using` statement.

> [!CAUTION]
> Use matching source and target column data types. If the types don't match, `SqlBulkCopy` attempts to convert each source value to the target data type with the rules for <xref:Microsoft.Data.SqlClient.SqlParameter.Value*>. Conversions can affect performance and cause unexpected errors. For example, conversion from `Double` to `Decimal` can fail for some values.

## Example

The following console application demonstrates how to load data with the <xref:Microsoft.Data.SqlClient.SqlBulkCopy> class. The example uses the <xref:Microsoft.Data.SqlClient.SqlDataReader> to copy data from `Production.Product` in the SQL Server `AdventureWorks` database to a similar table in the same database.

> [!IMPORTANT]
> Before you run this sample, create the work tables described in [Bulk Copy Example Setup](bulk-copy-example-setup.md). The sample demonstrates `SqlBulkCopy` syntax. If the source and destination tables are in the same SQL Server instance, use a Transact-SQL (T-SQL) `INSERT ... SELECT` statement for a faster copy.

[!code-csharp[DataWorks BulkCopy.Single#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks BulkCopy.Single/CS/source.cs#1)]
[!code-vb[DataWorks BulkCopy.Single#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks BulkCopy.Single/VB/source.vb#1)]

## Performing a Bulk Copy Operation Using Transact-SQL and the Command Class

The following example illustrates how to use the <xref:Microsoft.Data.SqlClient.SqlCommand.ExecuteNonQuery*> method to execute the `BULK INSERT` statement.

> [!NOTE]
> The file path for the data source is relative to the server. The server process must have access to that path in order for the bulk copy operation to succeed.

```vb
Using connection As SqlConnection = New SqlConnection(connectionString)
Dim queryString As String = _
    "BULK INSERT Northwind.dbo.[Order Details] FROM " & _
    "'f:\mydata\data.tbl' WITH (FORMATFILE='f:\mydata\data.fmt' )"
connection.Open()
Dim command As New SqlCommand(queryString, connection)

command.ExecuteNonQuery()
End Using
```

```csharp
using (SqlConnection connection = new SqlConnection(connectionString))
{
string queryString =  "BULK INSERT Northwind.dbo.[Order Details] " +
    @"FROM 'f:\mydata\data.tbl' " +
    @"WITH ( FORMATFILE='f:\mydata\data.fmt' )";
connection.Open();
SqlCommand command = new SqlCommand(queryString, connection);

command.ExecuteNonQuery();
}
```

## See also

- [Bulk Copy Operations in SQL Server](bulk-copy-operations-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)

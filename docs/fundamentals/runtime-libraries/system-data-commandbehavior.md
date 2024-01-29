---
title: System.Data.CommandBehavior enum
description: Learn about the System.Data.CommandBehavior enum through these additional API remarks.
ms.date: 01/02/2024
---
# System.Data.CommandBehavior enum

[!INCLUDE [context](includes/context.md)]

The `CommandBehavior` values are used by the <xref:System.Data.IDbCommand.ExecuteReader%2A> method of <xref:System.Data.IDbCommand> and any implementing classes.

A bitwise combination of these values may be used.

`CommandBehavior` is ignored when used to define a <xref:System.Data.Sql.SqlNotificationRequest> or <xref:System.Data.SqlClient.SqlDependency> and should therefore not be used. Use the constructor that does not require a `CommandBehavior` parameter in these two cases.

## Notes on individual enumeration members

When using `KeyInfo`, .NET Framework Data Provider for SQL Server precedes the statement being executed with `SET FMTONLY OFF` and `SET NO_BROWSETABLE ON`. Users should be aware of potential side effects, such as interference with the use of `SET FMTONLY ON` statements. For more information, see [SET FMTONLY (Transact-SQL)](/sql/t-sql/statements/set-fmtonly-transact-sql).

> [!NOTE]
> Use `SequentialAccess` to retrieve large values and binary data. Otherwise, an <xref:System.OutOfMemoryException> might occur and the connection will be closed.

When you specify `SequentialAccess`, you are required to read from the columns in the order they are returned, although you are not required to read each column. Once you have read past a location in the returned stream of data, data at or before that location can no longer be read from the `DataReader`. When using the <xref:System.Data.OleDb.OleDbDataReader>, you can reread the current column value until reading past it. When using the <xref:System.Data.SqlClient.SqlDataReader>, you can read a column value only once.

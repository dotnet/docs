---
title: ADO.NET limitations
ms.date: 12/13/2019
description: Describes some of the ADO.NET limitations you might encounter.
---
# ADO.NET limitations

Microsoft.Data.Sqlite provides implementations of many of the ADO.NET abstractions, but there are some limitations.

## Database schema information

Metadata about query results is available using the <xref:Microsoft.Data.Sqlite.SqliteDataReader.GetSchemaTable%2A> method.

`DbConnection.GetSchema()` isn't implemented. This API isn't well-defined, so we recommend retrieving database metadata directly using standard SQLite APIs like the [sqlite_master](https://www.sqlite.org/fileformat.html#storage_of_the_sql_database_schema) table and the [table_info](https://www.sqlite.org/pragma.html#pragma_table_info) PRAGMA.

For more information, see [Metadata](metadata.md).

## System.Transactions

Microsoft.Data.Sqlite doesn't yet support System.Transactions. Use ADO.NET transactions instead. For more information, see [Transactions](transactions.md).

Provide feedback about the lack of support for System.Transactions on issue [#13825](https://github.com/aspnet/EntityFrameworkCore/issues/13825).

## Data adapters

`DbDataAdapter` isn't yet implemented by Microsoft.Data.Sqlite. This means you can only use ADO.NET `DataSet` and `DataTable` to load data and not update it.

Use issue [#13838](https://github.com/aspnet/EntityFrameworkCore/issues/13838) to provide feedback about implementing `DbDataAdapter`.

## Output parameters

SQLite doesn't support output parameters.

## Positional parameters

Microsoft.Data.Sqlite only supports named [parameters](parameters.md). Positional parameters aren't supported.

## Stored procedures

SQLite doesn't support stored procedures.

## Isolation levels

The `Chaos` and `Snapshot` isolation levels aren't supported in SQLite transactions.

## See also

* [Async limitations](async.md)
* [Data types](types.md)
* [Transactions](transactions.md)

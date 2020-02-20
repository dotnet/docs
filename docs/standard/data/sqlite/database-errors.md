---
title: Database errors
ms.date: 12/13/2019
description: Describes how database errors and retires are handled by the library.
---
# Database errors

<xref:Microsoft.Data.Sqlite.SqliteException> is thrown when a SQLite error is encountered. The message is provided by SQLite. The `SqliteErrorCode` and `SqliteExtendedErrorCode` properties contain the SQLite [result code](https://www.sqlite.org/rescode.html) of the error.

Errors may be encountered any time the Microsoft.Data.Sqlite interacts with the native SQLite library. The following list shows the common scenarios where errors can occur:

* Opening a connection.
* Beginning a transaction.
* Executing a command.
* Calling <xref:Microsoft.Data.Sqlite.SqliteDataReader.NextResult%2A>.

Consider carefully how your app will handle these errors.

## Locking, retries, and timeouts

SQLite is aggressive when it comes to locking tables and database files. If your app enables any concurrent database access, you'll likely encounter busy and locked errors. You can mitigate many errors by using a [shared cache](connection-strings.md#cache) and [write-ahead logging](async.md).

Whenever Microsoft.Data.Sqlite encounters a busy or locked error, it will automatically retry until it succeeds or the command timeout is reached.

You can increase the timeout of command by setting <xref:Microsoft.Data.Sqlite.SqliteCommand.CommandTimeout%2A>. The default timeout is 30 seconds. A value of `0` means no timeout.

```csharp
// Retry for 60 seconds while locked
command.CommandTimeout = 60;
```

Microsoft.Data.Sqlite sometimes needs to create an implicit command object. For example, during BeginTransaction. To set the timeout for these commands, use <xref:Microsoft.Data.Sqlite.SqliteConnection.DefaultTimeout%2A>.

```csharp
// Set the default timeout of all commands on this connection
connection.DefaultTimeout = 60;
```

## See also

* [SQLite Error Codes](https://www.sqlite.org/rescode.html)
* [File Locking In SQLite](https://www.sqlite.org/lockingv3.html)
* [Shared-Cache Mode](https://www.sqlite.org/sharedcache.html)
* [Write-Ahead Logging](https://www.sqlite.org/wal.html)

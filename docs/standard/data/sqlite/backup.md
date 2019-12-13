---
title: Online Backup - Microsoft.Data.Sqlite
author: bricelam
ms.date: 12/13/2019
description: Learn how to use SQLite's online backup feature.
---
# Online Backup

SQLite can back up database files while the app is running. This functionality is available in Microsoft.Data.Sqlite as the [BackupDatabase](/dotnet/api/microsoft.data.sqlite.sqliteconnection.backupdatabase) method on SqliteConnection.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/BackupSample/Program.cs?name=snippet_Backup)]

Currently, BackupDatabase will back up the database as quickly as possible blocking other connections from writing to the database. Issue [#13834](https://github.com/aspnet/EntityFrameworkCore/issues/13834) would provide an alternative API to back up the database in the background allowing other connections to interrupt the backup and write to the database. If you're interested, please provide feedback on the issue.

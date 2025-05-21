---
title: Online backup
ms.date: 12/13/2019
description: Learn how to use SQLite's online backup feature.
ms.topic: article
---
# Online backup

SQLite can back up database files while the app is running. This functionality is available in Microsoft.Data.Sqlite as the <xref:Microsoft.Data.Sqlite.SqliteConnection.BackupDatabase%2A> method on `SqliteConnection`.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/BackupSample/Program.cs?name=snippet_Backup)]

Currently, `BackupDatabase` will back up the database as quickly as possible and blocks other connections from writing to the database. Issue [#13834](https://github.com/dotnet/efcore/issues/13834) would provide an alternative API to back up the database in the background and allow other connections to interrupt the backup and write to the database. If you're interested, provide feedback on the issue.

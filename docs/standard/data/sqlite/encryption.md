---
title: Encryption
ms.date: 12/13/2019
description: Learn how to encrypt your database file.
---
# Encryption

SQLite doesn't support encrypting database files by default. Instead, you need to use a modified version of SQLite like [SEE](https://www.hwaci.com/sw/sqlite/see.html), [SQLCipher](https://www.zetetic.net/sqlcipher/), [SQLiteCrypt](http://www.sqlite-crypt.com/), or [wxSQLite3](https://utelle.github.io/wxsqlite3). This article demonstrates using an unsupported, open-source build of SQLCipher, but the information also applies to other solutions since they generally follow the same pattern.

## Installation

### [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet remove package Microsoft.Data.Sqlite
dotnet add package Microsoft.Data.Sqlite.Core
dotnet add package SQLitePCLRaw.bundle_e_sqlcipher
```

### [Visual Studio](#tab/visual-studio)

``` PowerShell
Remove-Package Microsoft.Data.Sqlite
Install-Package Microsoft.Data.Sqlite.Core
Install-Package SQLitePCLRaw.bundle_e_sqlcipher
```

---

For more information about using a different native library for encryption, see [Custom SQLite versions](custom-versions.md).

## Specify the key

To enable encryption, specify the key using the `Password` connection string keyword. Use <xref:Microsoft.Data.Sqlite.SqliteConnectionStringBuilder> to add or update the value from user input and avoid connection string injection attacks.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/EncryptionSample/Program.cs?name=snippet_ConnectionStringBuilder)]

## Rekeying the database

If you want to change the encryption key of a database, issue a `PRAGMA rekey` statement. To decrypt the database, specify `NULL`.

Unfortunately, SQLite doesn't support parameters in `PRAGMA` statements. Instead, use the `quote()` function to prevent SQL injection.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/EncryptionSample/Program.cs?name=snippet_Rekey)]

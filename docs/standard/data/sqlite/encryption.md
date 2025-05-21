---
title: Encryption
ms.date: 09/08/2020
description: Learn how to encrypt your database file.
ms.topic: article
---
# Encryption

SQLite doesn't support encrypting database files by default. Instead, you need to use a modified version of SQLite like [SQLCipher](https://www.zetetic.net/sqlcipher/), [SQLiteCrypt](http://www.sqlite-crypt.com/), or [wxSQLite3](https://utelle.github.io/wxsqlite3). This article demonstrates using an unsupported, open-source build of SQLCipher, but the information also applies to other solutions since they generally follow the same pattern.

## Installation

### [.NET CLI](#tab/net-cli)

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

To enable encryption on a new database, specify the key using the `Password` connection string keyword. Use <xref:Microsoft.Data.Sqlite.SqliteConnectionStringBuilder> to add or update the value from user input and avoid connection string injection attacks.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/EncryptionSample/Program.cs?name=snippet_ConnectionStringBuilder)]

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

> [!TIP]
> The method for encrypting and decrypting existing databases varies depending on which solution you're using. For example, you need to use the `sqlcipher_export()` function on SQLCipher. Check your solution's documentation for details.

## Rekeying the database

If you want to change the key of an encrypted database, issue a `PRAGMA rekey` statement.

Unfortunately, SQLite doesn't support parameters in `PRAGMA` statements. Instead, use the `quote()` function to prevent SQL injection.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/EncryptionSample/Program.cs?name=snippet_Rekey)]

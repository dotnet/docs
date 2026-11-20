---
title: "Connection String Syntax"
description: Learn about syntax of connection strings in ADO.NET. The syntax for each provider is documented in its ConnectionString property.
ms.date: "10/19/2026"
ai-usage: ai-assisted
---
# Connection string syntax

Each ADO.NET data provider has a `Connection` object that inherits from <xref:System.Data.Common.DbConnection> as well as a provider-specific <xref:System.Data.Common.DbConnection.ConnectionString> property. The specific connection string syntax for each provider is documented in its `ConnectionString` property. The following table lists Microsoft.Data.SqlClient and three providers included in .NET Framework.

| Data provider | Description |
|------------------------------|-------------|
|<xref:Microsoft.Data.SqlClient>|Provides data access for Microsoft SQL Server through the [Microsoft.Data.SqlClient NuGet package](https://www.nuget.org/packages/Microsoft.Data.SqlClient). For more information on connection string syntax, see <xref:Microsoft.Data.SqlClient.SqlConnection.ConnectionString>.|
|<xref:System.Data.OleDb>|Provides data access for data sources exposed using OLE DB. For more information on connection string syntax, see <xref:System.Data.OleDb.OleDbConnection.ConnectionString>.|
|<xref:System.Data.Odbc>|Provides data access for data sources exposed using ODBC. For more information on connection string syntax, see <xref:System.Data.Odbc.OdbcConnection.ConnectionString>.|
|<xref:System.Data.OracleClient>|Provides data access for Oracle version 8.1.7 or later. For more information on connection string syntax, see <xref:System.Data.OracleClient.OracleConnection.ConnectionString>.|

## Connection string builders

 Use the connection string builder for your data provider.

- <xref:Microsoft.Data.SqlClient.SqlConnectionStringBuilder>
- <xref:System.Data.OleDb.OleDbConnectionStringBuilder>
- <xref:System.Data.Odbc.OdbcConnectionStringBuilder>
- <xref:System.Data.OracleClient.OracleConnectionStringBuilder>

 The connection string builders allow you to construct syntactically valid connection strings at runtime, so you do not have to manually concatenate connection string values in your code. For more information, see [Connection String Builders](connection-string-builders.md).

## Windows authentication

Windows Authentication (sometimes referred to as *integrated security*) can be used to connect to data sources that support it. The syntax employed in the connection string varies by provider. The following table shows the Windows Authentication syntax used with these data providers.

| Provider       | Syntax                                                                                     |
|----------------|--------------------------------------------------------------------------------------------|
| `SqlClient`    | `Integrated Security=true;`<br /><br /> `-- or --`<br /><br /> `Integrated Security=SSPI;` |
| `OleDb`        | `Integrated Security=SSPI;`                                                                |
| `Odbc`         | `Trusted_Connection=yes;`                                                                  |
| `OracleClient` | `Integrated Security=yes;`                                                                 |

> [!NOTE]
> `Integrated Security=true` throws an exception when used with the `OleDb` provider.

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

## SqlClient connection strings

The syntax for a <xref:Microsoft.Data.SqlClient.SqlConnection> connection string is documented in the <xref:Microsoft.Data.SqlClient.SqlConnection.ConnectionString?displayProperty=nameWithType> property. You can use the <xref:Microsoft.Data.SqlClient.SqlConnection.ConnectionString> property to get or set a connection string for a SQL Server database. Most connection string keywords also map to properties in the <xref:Microsoft.Data.SqlClient.SqlConnectionStringBuilder>.

> [!IMPORTANT]
> The default setting for the `Persist Security Info` keyword is `false`. Setting it to `true` or `yes` allows security-sensitive information, including the user ID and password, to be obtained from the connection after the connection has been opened. Keep `Persist Security Info` set to `false` to ensure that an untrusted source does not have access to sensitive connection string information.

### Windows authentication with SqlClient

 Each of the following forms of syntax uses Windows Authentication to connect to the `AdventureWorks` database on the specified server.

```csharp
"Persist Security Info=False;Integrated Security=true;Initial Catalog=AdventureWorks;Server=<server>;Encrypt=true"
"Persist Security Info=False;Integrated Security=SSPI;database=AdventureWorks;server=<server>;Encrypt=true"
"Persist Security Info=False;Trusted_Connection=True;database=AdventureWorks;server=<server>;Encrypt=true"
```

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

### SQL Server authentication with SqlClient

Windows Authentication is preferred for connecting to SQL Server (on premises). However, if SQL Server Authentication is required, use the following syntax to specify a user name and password. In this example, asterisks are used to represent a valid user name and password.

```csharp
"Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer"
```

When you connect to Azure SQL Database or to Azure SQL Data Warehouse and provide a login in the format `user@servername`, make sure that the `servername` value in the login matches the value provided for `Server=`.

> [!NOTE]
> Windows authentication takes precedence over SQL Server logins. If you specify both `Integrated Security=true` as well as a user name and password, the user name and password are ignored and Windows authentication is used.

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

### Connect to a named instance of SQL Server

To connect to a named instance of SQL Server, use the *server name\instance name* syntax.

```csharp
"Data Source=<server>\\<instance>;Encrypt=true;"
```

You can also set the <xref:Microsoft.Data.SqlClient.SqlConnectionStringBuilder.DataSource> property of the `SqlConnectionStringBuilder` to the instance name when building a connection string. The <xref:Microsoft.Data.SqlClient.SqlConnection.DataSource> property of a <xref:Microsoft.Data.SqlClient.SqlConnection> object is read-only.

### Type system version changes

 The `Type System Version` keyword in a <xref:Microsoft.Data.SqlClient.SqlConnection.ConnectionString?displayProperty=nameWithType> specifies the client-side representation of SQL Server types. For more information about the `Type System Version` keyword, see <xref:Microsoft.Data.SqlClient.SqlConnection.ConnectionString?displayProperty=nameWithType>.

## Connect and attach to SQL Server Express user instances

 User instances are a feature in SQL Server Express. They allow a user running on a least-privileged local Windows account to attach and run a SQL Server database without requiring administrative privileges. A user instance executes with the user's Windows credentials, not as a service.

 For more information on working with user instances, see [SQL Server Express User Instances](./sql/sql-server-express-user-instances.md).

## Use TrustServerCertificate

 With `Encrypt=true`, `TrustServerCertificate=true` encrypts the connection but bypasses server certificate validation. Keep `TrustServerCertificate=false` for production connections and configure a verifiable server certificate.

```csharp
"TrustServerCertificate=true;"
```

> [!CAUTION]
> If you bypass certificate validation, the client can't verify the server's identity. With `Encrypt=Strict`, Microsoft.Data.SqlClient always validates the server certificate and ignores `TrustServerCertificate`.

### Enable encryption

 Microsoft.Data.SqlClient defaults to `Encrypt=Mandatory`, equivalent to `Encrypt=true`, and `TrustServerCertificate=false`. The client requires encryption and validates the server certificate. If the certificate isn't trusted or doesn't match the server name, the connection fails.

 For remote connections, specify `Encrypt=true` and configure a server certificate that the client trusts. If you migrate from System.Data.SqlClient, don't assume its encryption defaults apply to Microsoft.Data.SqlClient. For more information, see [Encryption and certificate validation in Microsoft.Data.SqlClient](/sql/connect/ado-net/encryption-and-certificate-validation).

## OleDb connection strings

 The <xref:System.Data.OleDb.OleDbConnection.ConnectionString> property of a <xref:System.Data.OleDb.OleDbConnection> allows you to get or set a connection string for an OLE DB data source, such as Microsoft Access. You can also create an `OleDb` connection string at runtime by using the <xref:System.Data.OleDb.OleDbConnectionStringBuilder> class.

### OleDb connection string syntax

 You must specify a provider name for an <xref:System.Data.OleDb.OleDbConnection> connection string. The following connection string connects to a Microsoft Access database using the Jet provider. Note that the `User ID` and `Password` keywords are optional if the database is unsecured (the default).

```csharp
Provider=Microsoft.Jet.OLEDB.4.0; Data Source=d:\Northwind.mdb;User ID=Admin;Password=;
```

 If the Jet database is secured using user-level security, you must provide the location of the workgroup information file (.mdw). The workgroup information file is used to validate the credentials presented in the connection string.

```csharp
Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\Northwind.mdb;Jet OLEDB:System Database=d:\NorthwindSystem.mdw;User ID=*****;Password=*****;
```

> [!IMPORTANT]
> It is possible to supply connection information for an `OleDbConnection` in a Universal Data Link (UDL) file; however you should avoid doing so. UDL files are not encrypted, and expose connection string information in clear text. Because a UDL file is an external file-based resource to your application, it cannot be secured using .NET Framework. UDL files are not supported for **SqlClient**.

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

### Use DataDirectory to connect to Access/Jet

 `DataDirectory` is not exclusive to `SqlClient`. It can also be used with the <xref:System.Data.OleDb> and <xref:System.Data.Odbc> .NET data providers. The following sample <xref:System.Data.OleDb.OleDbConnection> string demonstrates the syntax required to connect to the Northwind.mdb located in the application's app_data folder. The system database (System.mdw) is also stored in that location.

```csharp
"Provider=Microsoft.Jet.OLEDB.4.0;
Data Source=|DataDirectory|\Northwind.mdb;
Jet OLEDB:System Database=|DataDirectory|\System.mdw;"
```

> [!IMPORTANT]
> Specifying the location of the system database in the connection string is not required if the Access/Jet database is unsecured. Security is off by default, with all users connecting as the built-in Admin user with a blank password. Even when user-level security is correctly implemented, a Jet database remains vulnerable to attack. Therefore, storing sensitive information in an Access/Jet database is not recommended because of the inherent weakness of its file-based security scheme.

### Connect to Excel

 The Microsoft Jet provider is used to connect to an Excel workbook. In the following connection string, the `Extended Properties` keyword sets properties that are specific to Excel. "HDR=Yes;" indicates that the first row contains column names, not data, and "IMEX=1;" tells the driver to always read "intermixed" data columns as text.

```csharp
Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\MyExcel.xls;Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""
```

 Note that the double quotation character required for the `Extended Properties` must also be enclosed in double quotation marks.

### Data Shape provider connection string syntax

 Use both the `Provider` and the `Data Provider` keywords when using the Microsoft Data Shape provider. The following example uses the Shape provider to connect to a local instance of SQL Server.

```csharp
"Provider=MSDataShape;Data Provider=SQLOLEDB;Data Source=(local);Initial Catalog=pubs;Integrated Security=SSPI;"
```

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

## Odbc connection strings

 The <xref:System.Data.Odbc.OdbcConnection.ConnectionString> property of a <xref:System.Data.Odbc.OdbcConnection> allows you to get or set a connection string for an OLE DB data source. Odbc connection strings are also supported by the <xref:System.Data.Odbc.OdbcConnectionStringBuilder>.

 The following connection string uses the Microsoft Text Driver.

```csharp
Driver={Microsoft Text Driver (*.txt; *.csv)};DBQ=d:\bin
```

## Oracle connection strings

 The <xref:System.Data.OracleClient.OracleConnection.ConnectionString> property of a <xref:System.Data.OracleClient.OracleConnection> allows you to get or set a connection string for an OLE DB data source. Oracle connection strings are also supported by the <xref:System.Data.OracleClient.OracleConnectionStringBuilder> .

```csharp
Data Source=Oracle9i;User ID=*****;Password=*****;
```

 For more information on ODBC connection string syntax, see <xref:System.Data.OracleClient.OracleConnection.ConnectionString>.

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

## See also

- [Connection Strings](connection-strings.md)
- [Connecting to a Data Source](connecting-to-a-data-source.md)
- [ADO.NET Overview](ado-net-overview.md)

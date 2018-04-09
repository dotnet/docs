---
title: "Connection String Syntax"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0977aeee-04d1-4cce-bbed-750c77fce06e
caps.latest.revision: 11
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Connection String Syntax
Each .NET Framework data provider has a `Connection` object that inherits from <xref:System.Data.Common.DbConnection> as well as a provider-specific <xref:System.Data.Common.DbConnection.ConnectionString%2A> property. The specific connection string syntax for each provider is documented in its `ConnectionString` property. The following table lists the four data providers that are included in the .NET Framework.  
  
|.NET Framework data provider|Description|  
|----------------------------------|-----------------|  
|<xref:System.Data.SqlClient>|Provides data access for Microsoft SQL Server. For more information on connection string syntax, see <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A>.|  
|<xref:System.Data.OleDb>|Provides data access for data sources exposed using OLE DB. For more information on connection string syntax, see <xref:System.Data.OleDb.OleDbConnection.ConnectionString%2A>.|  
|<xref:System.Data.Odbc>|Provides data access for data sources exposed using ODBC. For more information on connection string syntax, see <xref:System.Data.Odbc.OdbcConnection.ConnectionString%2A>.|  
|<xref:System.Data.OracleClient>|Provides data access for Oracle version 8.1.7 or later. For more information on connection string syntax, see <xref:System.Data.OracleClient.OracleConnection.ConnectionString%2A>.|  
  
## Connection String Builders  
 ADO.NET 2.0 introduced the following connection string builders for the .NET Framework data providers.  
  
-   <xref:System.Data.SqlClient.SqlConnectionStringBuilder>  
  
-   <xref:System.Data.OleDb.OleDbConnectionStringBuilder>  
  
-   <xref:System.Data.Odbc.OdbcConnectionStringBuilder>  
  
-   <xref:System.Data.OracleClient.OracleConnectionStringBuilder>  
  
 The connection string builders allow you to construct syntactically valid connection strings at run time, so you do not have to manually concatenate connection string values in your code. For more information, see [Connection String Builders](../../../../docs/framework/data/adonet/connection-string-builders.md).  

## Windows Authentication  
 We recommend using Windows Authentication (sometimes referred to as *integrated security*) to connect to data sources that support it. The syntax employed in the connection string varies by provider. The following table shows the Windows Authentication syntax used with the .NET Framework data providers.  
  
|Provider|Syntax|  
|--------------|------------|  
|`SqlClient`|`Integrated Security=true;`<br /><br /> `-- or --`<br /><br /> `Integrated Security=SSPI;`|  
|`OleDb`|`Integrated Security=SSPI;`|  
|`Odbc`|`Trusted_Connection=yes;`|  
|`OracleClient`|`Integrated Security=yes;`|  
  
> [!NOTE]
>  `Integrated Security=true` throws an exception when used with the `OleDb` provider.  
  
## SqlClient Connection Strings  
The syntax for a <xref:System.Data.SqlClient.SqlConnection> connection string is documented in the <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A?displayProperty=nameWithType> property. You can use the <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A> property to get or set a connection string for a SQL Server database. If you need to connect to an earlier version of SQL Server, you must use the .NET Framework Data Provider for OleDb (<xref:System.Data.OleDb>). Most connection string keywords also map to properties in the <xref:System.Data.SqlClient.SqlConnectionStringBuilder>.  

> [!IMPORTANT]
>  The default setting for the `Persist Security Info` keyword is `false`. Setting it to `true` or `yes` allows security-sensitive information, including the user ID and password, to be obtained from the connection after the connection has been opened. Keep `Persist Security Info` set to `false` to ensure that an untrusted source does not have access to sensitive connection string information.  

### Windows authentication with SqlClient 
 Each of the following forms of syntax uses Windows Authentication to connect to the **AdventureWorks** database on a local server.  
  
```  
"Persist Security Info=False;Integrated Security=true;  
    Initial Catalog=AdventureWorks;Server=MSSQL1"  
"Persist Security Info=False;Integrated Security=SSPI;  
    database=AdventureWorks;server=(local)"  
"Persist Security Info=False;Trusted_Connection=True;  
    database=AdventureWorks;server=(local)"  
```  
  
### SQL Server authentication with SqlClient   
 Windows Authentication is preferred for connecting to SQL Server. However, if SQL Server Authentication is required, use the following syntax to specify a user name and password. In this example, asterisks are used to represent a valid user name and password.  
  
```  
"Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer"  
```  

When you connect to Azure SQL Database or to Azure SQL Data Warehouse and provide a login in the format `user@servername`, make sure that the `servername` value in the login matches the value provided for `Server=`.

> [!NOTE]
>  Windows authentication takes precedence over SQL Server logins. If you specify both Integrated Security=true as well as a user name and password, the user name and password will be ignored and Windows authentication will be used.  

### Connect to a named instance of SQL Server
To connect to a named instance of SQL Server, use the *server name\instance name* syntax.  
  
```  
Data Source=MySqlServer\MSSQL1;"  
```  
 
You can also set the <xref:System.Data.SqlClient.SqlConnectionStringBuilder.DataSource%2A> property of the `SqlConnectionStringBuilder` to the instance name when building a connection string. The <xref:System.Data.SqlClient.SqlConnection.DataSource%2A> property of a <xref:System.Data.SqlClient.SqlConnection> object is read-only.  
  
### Type System Version Changes  
 The `Type System Version` keyword in a <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A?displayProperty=nameWithType> specifies the client-side representation of [!INCLUDE[ssNoVersion](../../../../includes/ssnoversion-md.md)] types. See <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A?displayProperty=nameWithType> for more information about the `Type System Version` keyword.  
  
## Connecting and Attaching to SQL Server Express User Instances  
 User instances are a feature in SQL Server Express. They allow a user running on a least-privileged local Windows account to attach and run a SQL Server database without requiring administrative privileges. A user instance executes with the user's Windows credentials, not as a service.  
  
 For more information on working with user instances, see [SQL Server Express User Instances](../../../../docs/framework/data/adonet/sql/sql-server-express-user-instances.md).  
  
## Using TrustServerCertificate  
 The `TrustServerCertificate` keyword is valid only when connecting to a [!INCLUDE[ssNoVersion](../../../../includes/ssnoversion-md.md)] instance with a valid certificate. When `TrustServerCertificate` is set to `true`, the transport layer will use SSL to encrypt the channel and bypass walking the certificate chain to validate trust.  
  
```  
"TrustServerCertificate=true;"   
```  
  
> [!NOTE]
>  If `TrustServerCertificate` is set to `true` and encryption is turned on, the encryption level specified on the server will be used even if `Encrypt` is set to `false` in the connection string. The connection will fail otherwise.  
  
### Enabling Encryption  
 To enable encryption when a certificate has not been provisioned on the server, the **Force Protocol Encryption** and the **Trust Server Certificate** options must be set in SQL Server Configuration Manager. In this case, encryption will use a self-signed server certificate without validation if no verifiable certificate has been provisioned on the server.  
  
 Application settings cannot reduce the level of security configured in SQL Server, but can optionally strengthen it. An application can request encryption by setting the `TrustServerCertificate` and `Encrypt` keywords to `true`, guaranteeing that encryption takes place even when a server certificate has not been provisioned and **Force Protocol Encryption** has not been configured for the client. However, if `TrustServerCertificate` is not enabled in the client configuration, a provisioned server certificate is still required.  
  
 The following table describes all cases.  
  
|Force Protocol Encryption client setting|Trust Server Certificate client setting|Encrypt/Use Encryption for Data connection string/attribute|Trust Server Certificate connection string/attribute|Result|  
|----------------------------------------------|---------------------------------------------|-------------------------------------------------------------------|-----------------------------------------------------------|------------|  
|No|N/A|No (default)|Ignored|No encryption occurs.|  
|No|N/A|Yes|No (default)|Encryption occurs only if there is a verifiable server certificate, otherwise the connection attempt fails.|  
|No|N/A|Yes|Yes|Encryption occurs only if there is a verifiable server certificate, otherwise the connection attempt fails.|  
|Yes|No|Ignored|Ignored|Encryption occurs only if there is a verifiable server certificate, otherwise the connection attempt fails.|  
|Yes|Yes|No (default)|Ignored|Encryption occurs only if there is a verifiable server certificate, otherwise the connection attempt fails.|  
|Yes|Yes|Yes|No (default)|Encryption occurs only if there is a verifiable server certificate, otherwise the connection attempt fails.|  
|Yes|Yes|Yes|Yes|Encryption occurs only if there is a verifiable server certificate, otherwise the connection attempt fails.|  
  
 For more information, see [Using Encryption Without Validation](http://go.microsoft.com/fwlink/?LinkId=120500) in SQL Server Books Online.  
  
## OleDb Connection Strings  
 The <xref:System.Data.OleDb.OleDbConnection.ConnectionString%2A> property of a <xref:System.Data.OleDb.OleDbConnection> allows you to get or set a connection string for an OLE DB data source, such as Microsoft Access. You can also create an `OleDb` connection string at run time by using the <xref:System.Data.OleDb.OleDbConnectionStringBuilder> class.  
  
### OleDb Connection String Syntax  
 You must specify a provider name for an <xref:System.Data.OleDb.OleDbConnection> connection string. The following connection string connects to a Microsoft Access database using the Jet provider. Note that the `UserID` and `Password` keywords are optional if the database is unsecured (the default).  
  
```  
Provider=Microsoft.Jet.OLEDB.4.0; Data Source=d:\Northwind.mdb;User ID=Admin;Password=;   
```  
  
 If the Jet database is secured using user-level security, you must provide the location of the workgroup information file (.mdw). The workgroup information file is used to validate the credentials presented in the connection string.  
  
```  
Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\Northwind.mdb;Jet OLEDB:System Database=d:\NorthwindSystem.mdw;User ID=*****;Password=*****;  
```  
  
> [!IMPORTANT]
>  It is possible to supply connection information for an **OleDbConnection** in a Universal Data Link (UDL) file; however you should avoid doing so. UDL files are not encrypted, and expose connection string information in clear text. Because a UDL file is an external file-based resource to your application, it cannot be secured using the .NET Framework. UDL files are not supported for **SqlClient**.  
  
### Using DataDirectory to Connect to Access/Jet  
 `DataDirectory` is not exclusive to `SqlClient`. It can also be used with the <xref:System.Data.OleDb> and <xref:System.Data.Odbc> .NET data providers. The following sample <xref:System.Data.OleDb.OleDbConnection> string demonstrates the syntax required to connect to the Northwind.mdb located in the application's app_data folder. The system database (System.mdw) is also stored in that location.  
  
```  
"Provider=Microsoft.Jet.OLEDB.4.0;  
Data Source=|DataDirectory|\Northwind.mdb;  
Jet OLEDB:System Database=|DataDirectory|\System.mdw;"  
```  
  
> [!IMPORTANT]
>  Specifying the location of the system database in the connection string is not required if the Access/Jet database is unsecured. Security is off by default, with all users connecting as the built-in Admin user with a blank password. Even when user-level security is correctly implemented, a Jet database remains vulnerable to attack. Therefore, storing sensitive information in an Access/Jet database is not recommended because of the inherent weakness of its file-based security scheme.  
  
### Connecting to Excel  
 The Microsoft Jet provider is used to connect to an Excel workbook. In the following connection string, the `Extended Properties` keyword sets properties that are specific to Excel. "HDR=Yes;" indicates that the first row contains column names, not data, and "IMEX=1;" tells the driver to always read "intermixed" data columns as text.  
  
```  
Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\MyExcel.xls;Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1""  
```  
  
 Note that the double quotation character required for the `Extended Properties` must also be enclosed in double quotation marks.  
  
### Data Shape Provider Connection String Syntax  
 Use both the `Provider` and the `Data Provider` keywords when using the Microsoft Data Shape provider. The following example uses the Shape provider to connect to a local instance of SQL Server.  
  
```  
"Provider=MSDataShape;Data Provider=SQLOLEDB;Data Source=(local);Initial Catalog=pubs;Integrated Security=SSPI;"   
```  
  
## Odbc Connection Strings  
 The <xref:System.Data.Odbc.OdbcConnection.ConnectionString%2A> property of a <xref:System.Data.Odbc.OdbcConnection> allows you to get or set a connection string for an OLE DB data source. Odbc connection strings are also supported by the <xref:System.Data.Odbc.OdbcConnectionStringBuilder>.  
  
 The following connection string uses the Microsoft Text Driver.  
  
```  
Driver={Microsoft Text Driver (*.txt; *.csv)};DBQ=d:\bin  
```  
  
### Using DataDirectory to Connect to Visual FoxPro  
 The following <xref:System.Data.Odbc.OdbcConnection> connection string sample demonstrates using `DataDirectory` to connect to a Microsoft Visual FoxPro file.  
  
```  
"Driver={Microsoft Visual FoxPro Driver};  
SourceDB=|DataDirectory|\MyData.DBC;SourceType=DBC;"  
```  
  
## Oracle Connection Strings  
 The <xref:System.Data.OracleClient.OracleConnection.ConnectionString%2A> property of a <xref:System.Data.OracleClient.OracleConnection> allows you to get or set a connection string for an OLE DB data source. Oracle connection strings are also supported by the <xref:System.Data.OracleClient.OracleConnectionStringBuilder> .  
  
```  
Data Source=Oracle9i;User ID=*****;Password=*****;  
```  
  
 For more information on ODBC connection string syntax, see <xref:System.Data.OracleClient.OracleConnection.ConnectionString%2A>.  
  
## See Also  
 [Connection Strings](../../../../docs/framework/data/adonet/connection-strings.md)  
 [Connecting to a Data Source](../../../../docs/framework/data/adonet/connecting-to-a-data-source.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

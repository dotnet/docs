---
title: "Configuring Parameters and Parameter Data Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 537d8a2c-d40b-4000-83eb-bc1fcc93f707
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Configuring Parameters and Parameter Data Types
Command objects use parameters to pass values to SQL statements or stored procedures, providing type checking and validation. Unlike command text, parameter input is treated as a literal value, not as executable code. This helps guard against "SQL injection" attacks, in which an attacker inserts a command that compromises security on the server into an SQL statement.  
  
 Parameterized commands can also improve query execution performance, because they help the database server accurately match the incoming command with a proper cached query plan. For more information, see [Execution Plan Caching and Reuse](http://go.microsoft.com/fwlink/?LinkId=120424) and [Parameters and Execution Plan Reuse](http://go.microsoft.com/fwlink/?LinkId=120423) in SQL Server Books Online. In addition to the security and performance benefits, parameterized commands provide a convenient method for organizing values passed to a data source.  
  
 A <xref:System.Data.Common.DbParameter> object can be created by using its constructor, or by adding it to the <xref:System.Data.Common.DbCommand.DbParameterCollection%2A> by calling the `Add` method of the <xref:System.Data.Common.DbParameterCollection> collection. The `Add` method will take as input either constructor arguments or an existing parameter object, depending on the data provider.  
  
## Supplying the ParameterDirection Property  
 When adding parameters, you must supply a <xref:System.Data.ParameterDirection> property for parameters other than input parameters. The following table shows the `ParameterDirection` values that you can use with the <xref:System.Data.ParameterDirection> enumeration.  
  
|Member name|Description|  
|-----------------|-----------------|  
|<xref:System.Data.ParameterDirection.Input>|The parameter is an input parameter. This is the default.|  
|<xref:System.Data.ParameterDirection.InputOutput>|The parameter can perform both input and output.|  
|<xref:System.Data.ParameterDirection.Output>|The parameter is an output parameter.|  
|<xref:System.Data.ParameterDirection.ReturnValue>|The parameter represents a return value from an operation such as a stored procedure, built-in function, or user-defined function.|  
  
## Working with Parameter Placeholders  
 The syntax for parameter placeholders depends on the data source. The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data providers handle naming and specifying parameters and parameter placeholders differently. This syntax is customized to a specific data source, as described in the following table.  
  
|Data provider|Parameter naming syntax|  
|-------------------|-----------------------------|  
|<xref:System.Data.SqlClient>|Uses named parameters in the format `@`*parametername*.|  
|<xref:System.Data.OleDb>|Uses positional parameter markers indicated by a question mark (`?`).|  
|<xref:System.Data.Odbc>|Uses positional parameter markers indicated by a question mark (`?`).|  
|<xref:System.Data.OracleClient>|Uses named parameters in the format `:`*parmname* (or *parmname*).|  
  
## Specifying Parameter Data Types  
 The data type of a parameter is specific to the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data provider. Specifying the type converts the value of the `Parameter` to the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data provider type before passing the value to the data source. You may also specify the type of a `Parameter` in a generic manner by setting the `DbType` property of the `Parameter` object to a particular <xref:System.Data.DbType>.  
  
 The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data provider type of a `Parameter` object is inferred from the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type of the `Value` of the `Parameter` object, or from the `DbType` of the `Parameter` object. The following table shows the inferred `Parameter` type based on the object passed as the `Parameter` value or the specified `DbType`.  
  
|.NET Framework type|DbType|SqlDbType|OleDbType|OdbcType|OracleType|  
|-------------------------|------------|---------------|---------------|--------------|----------------|  
|<xref:System.Boolean>|Boolean|Bit|Boolean|Bit|Byte|  
|<xref:System.Byte>|Byte|TinyInt|UnsignedTinyInt|TinyInt|Byte|  
|byte[]|Binary|VarBinary`.` This implicit conversion will fail if the byte array is larger than the maximum size of a VarBinary, which is 8000 bytes.For byte arrays larger than 8000 bytes, explicitly set the <xref:System.Data.SqlDbType>.|VarBinary|Binary|Raw|  
|<xref:System.Char>|``|Inferring a <xref:System.Data.SqlDbType> from char is not supported.|Char|Char|Byte|  
|<xref:System.DateTime>|DateTime|DateTime|DBTimeStamp|DateTime|DateTime|  
|<xref:System.DateTimeOffset>|DateTimeOffset|DateTimeOffset in SQL Server 2008. Inferring a <xref:System.Data.SqlDbType> from DateTimeOffset is not supported in versions of SQL Server earlier than SQL Server 2008.|||DateTime|  
|<xref:System.Decimal>|Decimal|Decimal|Decimal|Numeric|Number|  
|<xref:System.Double>|Double|Float|Double|Double|Double|  
|<xref:System.Single>|Single|Real|Single|Real|Float|  
|<xref:System.Guid>|Guid|UniqueIdentifier|Guid|UniqueIdentifier|Raw|  
|<xref:System.Int16 >|Int16|SmallInt|SmallInt|SmallInt|Int16|  
|<xref:System.Int32>|Int32|Int|Int|Int|Int32|  
|<xref:System.Int64>|Int64|BigInt|BigInt|BigInt|Number|  
|<xref:System.Object>|Object|Variant|Variant|Inferring an OdbcType from Object is not supported.|Blob|  
|<xref:System.String>|String|NVarChar. This implicit conversion will fail if the string is larger than the maximum size of an NVarChar, which is 4000 characters. For strings larger than 4000 characters, explicitly set the <xref:System.Data.SqlDbType>.|VarWChar|NVarChar|NVarChar|  
|<xref:System.TimeSpan>|Time|Time in SQL Server 2008. Inferring a <xref:System.Data.SqlDbType> from TimeSpan is not supported in versions of SQL Server earlier than SQL Server 2008.|DBTime|Time|DateTime|  
|<xref:System.UInt16>|UInt16|Inferring a <xref:System.Data.SqlDbType> from UInt16 is not supported.|UnsignedSmallInt|Int|UInt16|  
|<xref:System.UInt32>|UInt32|Inferring a <xref:System.Data.SqlDbType> from UInt32 is not supported.|UnsignedInt|BigInt|UInt32|  
|<xref:System.UInt64>|UInt64|Inferring a <xref:System.Data.SqlDbType> from UInt64 is not supported.|UnsignedBigInt|Numeric|Number|  
||AnsiString|VarChar|VarChar|VarChar|VarChar|  
||AnsiStringFixedLength|Char|Char|Char|Char|  
|``|Currency|Money|Currency|Inferring an `OdbcType` from `Currency` is not supported.|Number|  
|``|Date|Date in SQL Server 2008. Inferring a <xref:System.Data.SqlDbType> from Date is not supported in versions of SQL Server earlier than SQL Server 2008.|DBDate|Date|DateTime|  
|``|SByte|Inferring a <xref:System.Data.SqlDbType> from SByte is not supported.|TinyInt|Inferring an `OdbcType` from SByte is not supported.|SByte|  
||StringFixedLength|NChar|WChar|NChar|NChar|  
||Time|Time in SQL Server 2008. Inferring a <xref:System.Data.SqlDbType> from Time is not supported in versions of SQL Server earlier than SQL Server 2008.|DBTime|Time|DateTime|  
||VarNumeric|Inferring a <xref:System.Data.SqlDbType> from VarNumeric is not supported.|VarNumeric|Inferring an `OdbcType` from VarNumeric is not supported.|Number|  
|user-defined type (an object with <xref:Microsoft.SqlServer.Server.SqlUserDefinedAggregateAttribute>|Object or String, depending the provider (SqlClient always returns an Object, Odbc always returns a String, and the OleDb managed data provider can see either|SqlDbType.Udt if <xref:Microsoft.SqlServer.Server.SqlUserDefinedTypeAttribute> is present, otherwise Variant|OleDbType.VarWChar (if value is null) otherwise OleDbType.Variant.|OdbcType.NVarChar|not supported|  
  
> [!NOTE]
>  Conversions from decimal to other types are narrowing conversions that round the decimal value to the nearest integer value toward zero. If the result of the conversion is not representable in the destination type, an <xref:System.OverflowException> is thrown.  
  
> [!NOTE]
>  When you send a null parameter value to the server, you must specify <xref:System.DBNull>, not `null` (`Nothing` in [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)]). The null value in the system is an empty object that has no value. <xref:System.DBNull> is used to represent null values. For more information about database nulls, see [Handling Null Values](../../../../docs/framework/data/adonet/sql/handling-null-values.md).  
  
## Deriving Parameter Information  
 Parameters can also be derived from a stored procedure using the `DbCommandBuilder` class. Both the `SqlCommandBuilder` and `OleDbCommandBuilder` classes provide a static method, `DeriveParameters`, which automatically populates the parameters collection of a command object that uses parameter information from a stored procedure. Note that `DeriveParameters` overwrites any existing parameter information for the command.  
  
> [!NOTE]
>  Deriving parameter information incurs a performance penalty because it requires an additional round trip to the data source to retrieve the information. If parameter information is known at design time, you can improve the performance of your application by setting the parameters explicitly.  
  
 For more information, see [Generating Commands with CommandBuilders](../../../../docs/framework/data/adonet/generating-commands-with-commandbuilders.md).  
  
## Using Parameters with a SqlCommand and a Stored Procedure  
 Stored procedures offer many advantages in data-driven applications. By using stored procedures, database operations can be encapsulated in a single command, optimized for best performance, and enhanced with additional security. Although a stored procedure can be called by passing the stored procedure name followed by parameter arguments as an SQL statement, by using the <xref:System.Data.Common.DbCommand.Parameters%2A> collection of the [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] <xref:System.Data.Common.DbCommand> object enables you to more explicitly define stored procedure parameters, and to access output parameters and return values.  
  
> [!NOTE]
>  Parameterized statements are executed on the server by using `sp_executesql,` which allows for query plan reuse. Local cursors or variables in the `sp_executesql` batch are not visible to the batch that calls `sp_executesql`. Changes in database context last only to the end of the `sp_executesql` statement. For more information, see SQL Server Books Online.  
  
 When using parameters with a <xref:System.Data.SqlClient.SqlCommand> to execute a SQL Server stored procedure, the names of the parameters added to the <xref:System.Data.SqlClient.SqlCommand.Parameters%2A> collection must match the names of the parameter markers in the stored procedure. The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] Data Provider for SQL Server does not support the question mark (?) placeholder for passing parameters to an SQL statement or a stored procedure. It treats parameters in the stored procedure as named parameters and searches for matching parameter markers. For example, the `CustOrderHist` stored procedure is defined by using a parameter named `@CustomerID`. When your code executes the stored procedure, it must also use a parameter named `@CustomerID`.  
  
```  
CREATE PROCEDURE dbo.CustOrderHist @CustomerID varchar(5)  
```  
  
### Example  
 This example demonstrates how to call a SQL Server stored procedure in the `Northwind` sample database. The name of the stored procedure is `dbo.SalesByCategory` and it has an input parameter named `@CategoryName` with a data type of `nvarchar(15)`. The code creates a new <xref:System.Data.SqlClient.SqlConnection> inside a using block so that the connection is disposed when the procedure ends. The <xref:System.Data.SqlClient.SqlCommand> and <xref:System.Data.SqlClient.SqlParameter> objects are created, and their properties set. A <xref:System.Data.SqlClient.SqlDataReader> executes the `SqlCommand` and returns the result set from the stored procedure, displaying the output in the console window.  
  
> [!NOTE]
>  Instead of creating `SqlCommand` and `SqlParameter` objects and then setting properties in separate statements, you can instead elect to use one of the overloaded constructors to set multiple properties in a single statement.  
  
 [!code-csharp[DataWorks SqlClient.StoredProcedure#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlClient.StoredProcedure/CS/source.cs#1)]
 [!code-vb[DataWorks SqlClient.StoredProcedure#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlClient.StoredProcedure/VB/source.vb#1)]  
  
## Using Parameters with an OleDbCommand or OdbcCommand  
 When using parameters with an <xref:System.Data.OleDb.OleDbCommand> or <xref:System.Data.Odbc.OdbcCommand>, the order of the parameters added to the `Parameters` collection must match the order of the parameters defined in your stored procedure. The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] Data Provider for OLE DB and [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] Data Provider for ODBC treat parameters in a stored procedure as placeholders and apply parameter values in order. In addition, return value parameters must be the first parameters added to the `Parameters` collection.  
  
 The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] Data Provider for OLE DB and [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] Data Provider for ODBC do not support named parameters for passing parameters to an SQL statement or a stored procedure. In this case, you must use the question mark (?) placeholder, as in the following example.  
  
```  
SELECT * FROM Customers WHERE CustomerID = ?  
```  
  
 As a result, the order in which `Parameter` objects are added to the `Parameters` collection must directly correspond to the position of the ? placeholder for the parameter.  
  
### OleDb Example  
  
```vb  
Dim command As OleDbCommand = New OleDbCommand( _  
  "SampleProc", connection)  
command.CommandType = CommandType.StoredProcedure  
  
Dim parameter As OleDbParameter = command.Parameters.Add( _  
  "RETURN_VALUE", OleDbType.Integer)  
parameter.Direction = ParameterDirection.ReturnValue  
  
parameter = command.Parameters.Add( _  
  "@InputParm", OleDbType.VarChar, 12)  
parameter.Value = "Sample Value"  
  
parameter = command.Parameters.Add( _  
  "@OutputParm", OleDbType.VarChar, 28)  
parameter.Direction = ParameterDirection.Output  
```  
  
```csharp  
OleDbCommand command = new OleDbCommand("SampleProc", connection);  
command.CommandType = CommandType.StoredProcedure;  
  
OleDbParameter parameter = command.Parameters.Add(  
  "RETURN_VALUE", OleDbType.Integer);  
parameter.Direction = ParameterDirection.ReturnValue;  
  
parameter = command.Parameters.Add(  
  "@InputParm", OleDbType.VarChar, 12);  
parameter.Value = "Sample Value";  
  
parameter = command.Parameters.Add(  
  "@OutputParm", OleDbType.VarChar, 28);  
parameter.Direction = ParameterDirection.Output;  
```  
  
## Odbc Example  
  
```vb  
Dim command As OdbcCommand = New OdbcCommand( _  
  "{ ? = CALL SampleProc(?, ?) }", connection)  
command.CommandType = CommandType.StoredProcedure  
  
Dim parameter As OdbcParameter = command.Parameters.Add("RETURN_VALUE", OdbcType.Int)  
parameter.Direction = ParameterDirection.ReturnValue  
  
parameter = command.Parameters.Add( _  
  "@InputParm", OdbcType.VarChar, 12)  
parameter.Value = "Sample Value"  
  
parameter = command.Parameters.Add( _  
  "@OutputParm", OdbcType.VarChar, 28)  
parameter.Direction = ParameterDirection.Output  
```  
  
```csharp  
OdbcCommand command = new OdbcCommand( _  
  "{ ? = CALL SampleProc(?, ?) }", connection);  
command.CommandType = CommandType.StoredProcedure;  
  
OdbcParameter parameter = command.Parameters.Add( _  
  "RETURN_VALUE", OdbcType.Int);  
parameter.Direction = ParameterDirection.ReturnValue;  
  
parameter = command.Parameters.Add( _  
  "@InputParm", OdbcType.VarChar, 12);  
parameter.Value = "Sample Value";  
  
parameter = command.Parameters.Add( _  
  "@OutputParm", OdbcType.VarChar, 28);  
parameter.Direction = ParameterDirection.Output;  
```  
  
## See Also  
 [Commands and Parameters](../../../../docs/framework/data/adonet/commands-and-parameters.md)  
 [DataAdapter Parameters](../../../../docs/framework/data/adonet/dataadapter-parameters.md)  
 [Data Type Mappings in ADO.NET](../../../../docs/framework/data/adonet/data-type-mappings-in-ado-net.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

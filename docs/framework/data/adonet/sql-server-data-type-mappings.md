---
title: "SQL Server Data Type Mappings"
description: Learn about mapping between the different type systems for SQL Server and the .NET Framework. This article summarizes how the systems interact in ADO.NET.
ms.date: "03/30/2017"
ms.assetid: fafdc31a-f435-4cd3-883f-1dfadd971277
---
# SQL Server Data Type Mappings

SQL Server and the .NET Framework are based on different type systems. For example, the .NET Framework <xref:System.Decimal> structure has a maximum scale of 28, whereas the SQL Server decimal and numeric data types have a maximum scale of 38. To maintain data integrity when reading and writing data, the  <xref:System.Data.SqlClient.SqlDataReader> exposes SQL Server–specific typed accessor methods that return objects of <xref:System.Data.SqlTypes> as well as accessor methods that return .NET Framework types. Both SQL Server types and .NET Framework types are also represented by enumerations in the <xref:System.Data.DbType> and <xref:System.Data.SqlDbType> classes, which you can use when specifying <xref:System.Data.SqlClient.SqlParameter> data types.

 The following table shows the inferred .NET Framework type, the <xref:System.Data.DbType> and <xref:System.Data.SqlDbType> enumerations, and the accessor methods for the <xref:System.Data.SqlClient.SqlDataReader>.

|SQL Server Database Engine type|.NET Framework type|SqlDbType enumeration|SqlDataReader SqlTypes typed accessor|DbType enumeration|SqlDataReader DbType typed accessor|
|-------------------------------------|-------------------------|---------------------------|-------------------------------------------|------------------------|-----------------------------------------|
|bigint|Int64|<xref:System.Data.SqlDbType.BigInt>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlInt64*>|<xref:System.Data.DbType.Int64>|<xref:System.Data.SqlClient.SqlDataReader.GetInt64*>|
|binary|Byte[]|<xref:System.Data.SqlDbType.VarBinary>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlBinary*>|<xref:System.Data.DbType.Binary>|<xref:System.Data.SqlClient.SqlDataReader.GetBytes*>|
|bit|Boolean|<xref:System.Data.SqlDbType.Bit>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlBoolean*>|<xref:System.Data.DbType.Boolean>|<xref:System.Data.SqlClient.SqlDataReader.GetBoolean*>|
|char|String<br /><br /> Char[]|<xref:System.Data.SqlDbType.Char>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlString*>|<xref:System.Data.DbType.AnsiStringFixedLength>,<br /><br /> <xref:System.Data.DbType.String>|<xref:System.Data.SqlClient.SqlDataReader.GetString*><br /><br /> <xref:System.Data.SqlClient.SqlDataReader.GetChars*>|
|date <sup>1</sup><br /><br /> (SQL Server 2008 and later)|DateTime|<xref:System.Data.SqlDbType.Date> <sup>1</sup>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlDateTime*>|<xref:System.Data.DbType.Date> <sup>1</sup>|<xref:System.Data.SqlClient.SqlDataReader.GetDateTime*>|
|datetime|DateTime|<xref:System.Data.SqlDbType.DateTime>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlDateTime*>|<xref:System.Data.DbType.DateTime>|<xref:System.Data.SqlClient.SqlDataReader.GetDateTime*>|
|datetime2<br /><br /> (SQL Server 2008 and later)|DateTime|<xref:System.Data.SqlDbType.DateTime2>|None|<xref:System.Data.DbType.DateTime2>|<xref:System.Data.SqlClient.SqlDataReader.GetDateTime*>|
|datetimeoffset<br /><br /> (SQL Server 2008 and later)|DateTimeOffset|<xref:System.Data.SqlDbType.DateTimeOffset>|none|<xref:System.Data.DbType.DateTimeOffset>|<xref:System.Data.SqlClient.SqlDataReader.GetDateTimeOffset*>|
|decimal|Decimal|<xref:System.Data.SqlDbType.Decimal>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlDecimal*>|<xref:System.Data.DbType.Decimal>|<xref:System.Data.SqlClient.SqlDataReader.GetDecimal*>|
|FILESTREAM attribute (varbinary(max))|Byte[]|<xref:System.Data.SqlDbType.VarBinary>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlBytes*>|<xref:System.Data.DbType.Binary>|<xref:System.Data.SqlClient.SqlDataReader.GetBytes*>|
|float|Double|<xref:System.Data.SqlDbType.Float>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlDouble*>|<xref:System.Data.DbType.Double>|<xref:System.Data.SqlClient.SqlDataReader.GetDouble*>|
|image|Byte[]|<xref:System.Data.SqlDbType.Binary>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlBinary*>|<xref:System.Data.DbType.Binary>|<xref:System.Data.SqlClient.SqlDataReader.GetBytes*>|
|int|Int32|<xref:System.Data.SqlDbType.Int>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlInt32*>|<xref:System.Data.DbType.Int32>|<xref:System.Data.SqlClient.SqlDataReader.GetInt32*>|
|money|Decimal|<xref:System.Data.SqlDbType.Money>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlMoney*>|<xref:System.Data.DbType.Decimal>|<xref:System.Data.SqlClient.SqlDataReader.GetDecimal*>|
|nchar|String<br /><br /> Char[]|<xref:System.Data.SqlDbType.NChar>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlString*>|<xref:System.Data.DbType.StringFixedLength>|<xref:System.Data.SqlClient.SqlDataReader.GetString*><br /><br /> <xref:System.Data.SqlClient.SqlDataReader.GetChars*>|
|ntext|String<br /><br /> Char[]|<xref:System.Data.SqlDbType.NText>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlString*>|<xref:System.Data.DbType.String>|<xref:System.Data.SqlClient.SqlDataReader.GetString*><br /><br /> <xref:System.Data.SqlClient.SqlDataReader.GetChars*>|
|numeric|Decimal|<xref:System.Data.SqlDbType.Decimal>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlDecimal*>|<xref:System.Data.DbType.Decimal>|<xref:System.Data.SqlClient.SqlDataReader.GetDecimal*>|
|nvarchar|String<br /><br /> Char[]|<xref:System.Data.SqlDbType.NVarChar>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlString*>|<xref:System.Data.DbType.String>|<xref:System.Data.SqlClient.SqlDataReader.GetString*><br /><br /> <xref:System.Data.SqlClient.SqlDataReader.GetChars*>|
|real|Single|<xref:System.Data.SqlDbType.Real>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlSingle*>|<xref:System.Data.DbType.Single>|<xref:System.Data.SqlClient.SqlDataReader.GetFloat*>|
|rowversion|Byte[]|<xref:System.Data.SqlDbType.Timestamp>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlBinary*>|<xref:System.Data.DbType.Binary>|<xref:System.Data.SqlClient.SqlDataReader.GetBytes*>|
|smalldatetime|DateTime|<xref:System.Data.SqlDbType.DateTime>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlDateTime*>|<xref:System.Data.DbType.DateTime>|<xref:System.Data.SqlClient.SqlDataReader.GetDateTime*>|
|smallint|Int16|<xref:System.Data.SqlDbType.SmallInt>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlInt16*>|<xref:System.Data.DbType.Int16>|<xref:System.Data.SqlClient.SqlDataReader.GetInt16*>|
|smallmoney|Decimal|<xref:System.Data.SqlDbType.SmallMoney>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlMoney*>|<xref:System.Data.DbType.Decimal>|<xref:System.Data.SqlClient.SqlDataReader.GetDecimal*>|
|sql_variant|Object <sup>2</sup>|<xref:System.Data.SqlDbType.Variant>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlValue*> <sup>2</sup>|<xref:System.Data.DbType.Object>|<xref:System.Data.SqlClient.SqlDataReader.GetValue*> <sup>2</sup>|
|text|String<br /><br /> Char[]|<xref:System.Data.SqlDbType.Text>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlString*>|<xref:System.Data.DbType.String>|<xref:System.Data.SqlClient.SqlDataReader.GetString*><br /><br /> <xref:System.Data.SqlClient.SqlDataReader.GetChars*>|
|time<br /><br /> (SQL Server 2008 and later)|TimeSpan|<xref:System.Data.SqlDbType.Time>|none|<xref:System.Data.DbType.Time>|<xref:System.Data.SqlClient.SqlDataReader.GetTimeSpan*>|
|timestamp|Byte[]|<xref:System.Data.SqlDbType.Timestamp>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlBinary*>|<xref:System.Data.DbType.Binary>|<xref:System.Data.SqlClient.SqlDataReader.GetBytes*>|
|tinyint|Byte|<xref:System.Data.SqlDbType.TinyInt>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlByte*>|<xref:System.Data.DbType.Byte>|<xref:System.Data.SqlClient.SqlDataReader.GetByte*>|
|uniqueidentifier|Guid|<xref:System.Data.SqlDbType.UniqueIdentifier>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlGuid*>|<xref:System.Data.DbType.Guid>|<xref:System.Data.SqlClient.SqlDataReader.GetGuid*>|
|varbinary|Byte[]|<xref:System.Data.SqlDbType.VarBinary>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlBinary*>|<xref:System.Data.DbType.Binary>|<xref:System.Data.SqlClient.SqlDataReader.GetBytes*>|
|varchar|String<br /><br /> Char[]|<xref:System.Data.SqlDbType.VarChar>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlString*>|<xref:System.Data.DbType.AnsiString>, <xref:System.Data.DbType.String>|<xref:System.Data.SqlClient.SqlDataReader.GetString*><br /><br /> <xref:System.Data.SqlClient.SqlDataReader.GetChars*>|
|xml|Xml|<xref:System.Data.SqlDbType.Xml>|<xref:System.Data.SqlClient.SqlDataReader.GetSqlXml*>|<xref:System.Data.DbType.Xml>|none|

<sup>1</sup> You cannot set the `DbType` property of a `SqlParameter` to `SqlDbType.Date`.
<sup>2</sup> Use a specific typed accessor if you know the underlying type of the `sql_variant`.

## SQL Server documentation

For more information about SQL Server data types, see [Data types (Transact-SQL)](/sql/t-sql/data-types/data-types-transact-sql).

## See also

- [SQL Server Data Types and ADO.NET](./sql/sql-server-data-types.md)
- [SQL Server Binary and Large-Value Data](./sql/sql-server-binary-and-large-value-data.md)
- [Data Type Mappings in ADO.NET](data-type-mappings-in-ado-net.md)
- [Configuring Parameters and Parameter Data Types](configuring-parameters-and-parameter-data-types.md)
- [ADO.NET Overview](ado-net-overview.md)

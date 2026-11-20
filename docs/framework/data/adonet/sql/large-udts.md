---
description: "Learn more about large UDTs, which allow a developer to extend the server's scalar type system by storing CLR objects in a SQL Server database."
title: "Large UDTs"
ms.date: "10/23/2026"
dev_langs:
  - "csharp"
  - "vb"
ms.custom: sfi-ropc-nochange
---
# Large UDTs

User-defined types (UDTs) allow a developer to extend the server's scalar type system by storing common language runtime (CLR) objects in a SQL Server database. UDTs can contain multiple elements and can have behaviors, unlike the traditional alias data types, which consist of a single SQL Server system data type.

> [!NOTE]
> For client access to large UDTs, install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package and import `Microsoft.Data.SqlClient`. SQL CLR types that define the server-side UDT remain in `Microsoft.SqlServer.Server`; don't replace those types with client-provider types.

 Previously, UDTs were restricted to a maximum size of 8 kilobytes. In SQL Server 2008, this restriction has been removed for UDTs that have a format of <xref:Microsoft.SqlServer.Server.Format.UserDefined>.

 For the complete documentation for user-defined types, see [CLR User-Defined Types](/sql/relational-databases/clr-integration-database-objects-user-defined-types/clr-user-defined-types).

## Retrieving UDT Schemas Using GetSchema

The <xref:Microsoft.Data.SqlClient.SqlConnection.GetSchema*> method returns database schema information in the <xref:System.Data.DataTable> object. For more information, see [SQL Server Schema Collections](../sql-server-schema-collections.md).

### GetSchemaTable Column Values for UDTs

The <xref:Microsoft.Data.SqlClient.SqlDataReader.GetSchemaTable*> method returns column metadata in the <xref:System.Data.DataTable> object. The following table describes the differences in the column metadata for large UDTs between SQL Server 2005 and SQL Server 2008.

|SqlDataReader column|SQL Server 2005|SQL Server 2008 and later|
|--------------------------|---------------------|-------------------------------|
|`ColumnSize`|Varies|Varies|
|`NumericPrecision`|255|255|
|`NumericScale`|255|255|
|`DataType`|`Byte[]`|UDT instance|
|`ProviderSpecificDataType`|`SqlTypes.SqlBinary`|UDT instance|
|`ProviderType`|21 (`SqlDbType.VarBinary`)|29 (`SqlDbType.Udt`)|
|`NonVersionedProviderType`|29 (`SqlDbType.Udt`)|29 (`SqlDbType.Udt`)|
|`DataTypeName`|`SqlDbType.VarBinary`|The three part name specified as *Database.SchemaName.TypeName*.|
|`IsLong`|Varies|Varies|

## SqlDataReader Considerations

The <xref:Microsoft.Data.SqlClient.SqlDataReader> class supports large UDT values in SQL Server 2008 and later versions. How the reader processes these values depends on the SQL Server version and the `Type System Version` in the connection string. For more information, see <xref:Microsoft.Data.SqlClient.SqlConnection.ConnectionString>.

When `Type System Version` is SQL Server 2005, the following <xref:Microsoft.Data.SqlClient.SqlDataReader> methods use the binary representation of large UDTs:

- <xref:Microsoft.Data.SqlClient.SqlDataReader.GetProviderSpecificFieldType*> returns the <xref:System.Type> object for <xref:System.Data.SqlTypes.SqlBinary>.
- <xref:Microsoft.Data.SqlClient.SqlDataReader.GetProviderSpecificValue*> and <xref:Microsoft.Data.SqlClient.SqlDataReader.GetSqlValue*> return <xref:System.Data.SqlTypes.SqlBinary> values.
- <xref:Microsoft.Data.SqlClient.SqlDataReader.GetProviderSpecificValues*> and <xref:Microsoft.Data.SqlClient.SqlDataReader.GetSqlValues*> fill the supplied array with provider-specific column values and return the number of elements populated. Large UDT values in that array use <xref:System.Data.SqlTypes.SqlBinary>.

For the same type-system setting, <xref:Microsoft.Data.SqlClient.SqlDataReader.GetValue*> returns the large UDT value as `Byte[]`. <xref:Microsoft.Data.SqlClient.SqlDataReader.GetValues*> fills the supplied array with column values and returns the number of elements populated. Large UDT values in that array use `Byte[]`.

 Note that no conversions are made for the current version of ADO.NET.

## Specifying SqlParameters

The following <xref:Microsoft.Data.SqlClient.SqlParameter> properties support large UDTs.

|SqlParameter Property|Description|
|---------------------------|-----------------|
|<xref:Microsoft.Data.SqlClient.SqlParameter.Value*>|Gets or sets an object that represents the value of the parameter. The default is null. The property can be `SqlBinary`, `Byte[]`, or a managed object.|
|<xref:Microsoft.Data.SqlClient.SqlParameter.SqlValue*>|Gets or sets an object that represents the value of the parameter. The default is null. The property can be `SqlBinary`, `Byte[]`, or a managed object.|
|<xref:Microsoft.Data.SqlClient.SqlParameter.Size*>|Gets or sets the size of the parameter value to resolve. The default value is 0. The property can be an integer that represents the size of the parameter value. For large UDTs, it can be the actual size of the UDT, or -1 for unknown.|

## Retrieving Data Example

 The following code fragment demonstrates how to retrieve large UDT data. The `connectionString` variable assumes a valid connection to a SQL Server database and the `commandString` variable assumes a valid `SELECT` statement with the primary key column listed first.

```csharp
using (SqlConnection connection = new SqlConnection(
    connectionString))
{
  connection.Open();
  SqlCommand command = new SqlCommand(commandString, connection);
  SqlDataReader reader = command.ExecuteReader();
  while (reader.Read())
  {
    // Retrieve the value of the Primary Key column.
    int id = reader.GetInt32(0);

    // Retrieve the value of the UDT.
    LargeUDT udt = (LargeUDT)reader[1];

    // You can also use GetSqlValue and GetValue.
    // LargeUDT udt = (LargeUDT)reader.GetSqlValue(1);
    // LargeUDT udt = (LargeUDT)reader.GetValue(1);

    Console.WriteLine(
     "ID={0} LargeUDT={1}", id, udt);
  }
reader.Close();
}
```

```vb
Using connection As New SqlConnection( _
    connectionString)
    connection.Open()
    Dim command As New SqlCommand(commandString, connection)
    Dim reader As SqlDataReader
    reader = command.ExecuteReader

    While reader.Read()
      ' Retrieve the value of the Primary Key column.
      Dim id As Int32 = reader.GetInt32(0)

      ' Retrieve the value of the UDT.
      Dim udt As LargeUDT = CType(reader(1), LargeUDT)

     ' You can also use GetSqlValue and GetValue.
     ' Dim udt As LargeUDT = CType(reader.GetSqlValue(1), LargeUDT)
     ' Dim udt As LargeUDT = CType(reader.GetValue(1), LargeUDT)

      ' Print values.
      Console.WriteLine("ID={0} LargeUDT={1}", id, udt)
    End While
    reader.Close()
End Using
```

## See also

- [Configuring Parameters and Parameter Data Types](../configuring-parameters-and-parameter-data-types.md)
- [Retrieving Database Schema Information](../retrieving-database-schema-information.md)
- [SQL Server Data Type Mappings](../sql-server-data-type-mappings.md)
- [SQL Server Binary and Large-Value Data](sql-server-binary-and-large-value-data.md)
- [ADO.NET Overview](../ado-net-overview.md)

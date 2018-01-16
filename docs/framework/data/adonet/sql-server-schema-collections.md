---
title: "SQL Server Schema Collections"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c6403cc3-d78b-4f85-bab1-ada7a3446ec5
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SQL Server Schema Collections
The Microsoft .NET Framework Data Provider for SQL Server supports additional schema collections in addition to the common schema collections. The schema collections vary slightly by the version of SQL Server you are using. To determine the list of supported schema collections, call the **GetSchema** method with no arguments, or with the schema collection name "MetaDataCollections". This will return a <xref:System.Data.DataTable> with a list of the supported schema collections, the number of restrictions that they each support, and the number of identifier parts that they use.  
  
## Databases  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|database_name|String|Name of the database.|  
|dbid|Int16|Database ID.|  
|create_date|DateTime|Creation Date of the database.|  
  
## Foreign Keys  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|CONSTRAINT_CATALOG|String|Catalog the constraint belongs to.|  
|CONSTRAINT_SCHEMA|String|Schema that contains the constraint.|  
|CONSTRAINT_NAME|String|Name.|  
|TABLE_CATALOG|String|Table Name constraint is part of.|  
|TABLE_SCHEMA|String|Schema that that contains the table.|  
|TABLE_NAME|String|Table Name|  
|CONSTRAINT_TYPE|String|Type of constraint. Only "FOREIGN KEY" is allowed.|  
|IS_DEFERRABLE|String|Specifies whether the constraint is deferrable. Returns NO.|  
|INITIALLY_DEFERRED|String|Specifies whether the constraint is initially deferrable. Returns NO.|  
  
## Indexes  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|constraint_catalog|String|Catalog that index belongs to.|  
|constraint_schema|String|Schema that contains the index.|  
|constraint_name|String|Name of the index.|  
|table_catalog|String|Table name the index is associated with.|  
|table_schema|String|Schema that contains the table the index is associated with.|  
|table_name|String|Table Name.|  
|index_name|String|Index Name.|  
  
### Indexes (SQL Server 2008)  
 Beginning with the .NET Framework version 3.5 SP1 and SQL Server 2008, the following columns have been added to the Indexes schema collection to support new spatial types, filestream and sparse columns. These columns are not supported in earlier versions of the .NET Framework and SQL Server.  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|type_desc|String|The type of the index will be one of the following:<br /><br /> -   HEAP<br />-   CLUSTERED<br />-   NONCLUSTERED<br />-   XML<br />-   SPATIAL|  
  
## IndexColumns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|constraint_catalog|String|Catalog that index belongs to.|  
|constraint_schema|String|Schema that contains the index.|  
|constraint_name|String|Name of the index.|  
|table_catalog|String|Table name the index is associated with.|  
|table_schema|String|Schema that contains the table the index is associated with.|  
|table_name|String|Table Name.|  
|column_name|String|Column name the index is associated with.|  
|ordinal_position|Int32|Column ordinal position.|  
|KeyType|Byte|The type of object.|  
|index_name|String|Index Name.|  
  
## Procedures  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|SPECIFIC_CATALOG|String|Specific name for the catalog.|  
|SPECIFIC_SCHEMA|String|Specific name of the schema.|  
|SPECIFIC_NAME|String|Specific name of the catalog.|  
|ROUTINE_CATALOG|String|Catalog the stored procedure belongs to.|  
|ROUTINE_SCHEMA|String|Schema that contains the stored procedure.|  
|ROUTINE_NAME|String|Name of the stored procedure.|  
|ROUTINE_TYPE|String|Returns PROCEDURE for stored procedures and FUNCTION for functions.|  
|CREATED|DateTime|Time the procedure was created.|  
|LAST_ALTERED|DateTime|The last time the procedure was modified.|  
  
## Procedure Parameters  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|SPECIFIC_CATALOG|String|Catalog name of the procedure for which this is a parameter.|  
|SPECIFIC_SCHEMA|String|Schema that contains the procedure for which this parameter is part of.|  
|SPECIFIC_NAME|String|Name of the procedure for which this parameter is a part of.|  
|ORDINAL_POSITION|Int32|Ordinal position of the parameter starting at 1. For the return value of a procedure, this is a 0.|  
|PARAMETER_MODE|String|Returns IN if an input parameter, OUT if an output parameter, and INOUT if an input/output parameter.|  
|IS_RESULT|String|Returns YES if indicates result of the procedure that is a function. Otherwise, returns NO.|  
|AS_LOCATOR|String|Returns YES if declared as locator. Otherwise, returns NO.|  
|PARAMETER_NAME|String|Name of the parameter. NULL if this corresponds to the return value of a function.|  
|DATA_TYPE|String|System-supplied data type.|  
|CHARACTER_MAXIMUM_LENGTH|Int32|Maximum length in characters for binary or character data types. Otherwise, returns NULL.|  
|CHARACTER_OCTET_LENGTH|Int32|Maximum length, in bytes, for binary or character data types. Otherwise, returns NULL.|  
|COLLATION_CATALOG|String|Catalog name of the collation of the parameter. If not one of the character types, returns NULL.|  
|COLLATION_SCHEMA|String|Always returns NULL.|  
|COLLATION_NAME|String|Name of the collation of the parameter. If not one of the character types, returns NULL.|  
|CHARACTER_SET_CATALOG|String|Catalog name of the character set of the parameter. If not one of the character types, returns NULL.|  
|CHARACTER_SET_SCHEMA|String|Always returns NULL.|  
|CHARACTER_SET_NAME|String|Name of the character set of the parameter. If not one of the character types, returns NULL.|  
|NUMERIC_PRECISION|Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, returns NULL.|  
|NUMERIC_PRECISION_RADIX|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, returns NULL.|  
|NUMERIC_SCALE|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, returns NULL.|  
|DATETIME_PRECISION|Int16|Precision in fractional seconds if the parameter type is datetime or smalldatetime. Otherwise, returns NULL.|  
|INTERVAL_TYPE|String|NULL. Reserved for future use by SQL Server.|  
|INTERVAL_PRECISION|Int16|NULL. Reserved for future use by SQL Server.|  
  
## Tables  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|TABLE_CATALOG|String|Catalog of the table.|  
|TABLE_SCHEMA|String|Schema that contains the table.|  
|TABLE_NAME|String|Table name.|  
|TABLE_TYPE|String|Type of table. Can be VIEW or BASE TABLE.|  
  
## Columns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|TABLE_CATALOG|String|Catalog of the table.|  
|TABLE_SCHEMA|String|Schema that contains the table.|  
|TABLE_NAME|String|Table name.|  
|COLUMN_NAME|String|Column name.|  
|ORDINAL_POSITION|Int32|Column identification number.|  
|COLUMN_DEFAULT|String|Default value of the column|  
|IS_NULLABLE|String|Nullability of the column. If this column allows NULL, this column returns YES. Otherwise, No is returned.|  
|DATA_TYPE|String|System-supplied data type.|  
|CHARACTER_MAXIMUM_LENGTH|Int32 – Sql8, Int16 – Sql7|Maximum length, in characters, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|CHARACTER_OCTET_LENGTH|Int32 – SQL8, Int16 – Sql7|Maximum length, in bytes, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|NUMERIC_PRECISION|Unsigned Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|NUMERIC_PRECISION_RADIX|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|NUMERIC_SCALE|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|DATETIME_PRECISION|Int16|Subtype code for datetime and SQL-92 interval data types. For other data types, NULL is returned.|  
|CHARACTER_SET_CATALOG|String|Returns master, indicating the database in which the character set is located, if the column is character data or text data type. Otherwise, NULL is returned.|  
|CHARACTER_SET_SCHEMA|String|Always returns NULL.|  
|CHARACTER_SET_NAME|String|Returns the unique name for the character set if this column is character data or text data type. Otherwise, NULL is returned.|  
|COLLATION_CATALOG|String|Returns master, indicating the database in which the collation is defined, if the column is character data or text data type. Otherwise, this column is NULL.|  
  
### Columns (SQL Server 2008)  
 Beginning with the .NET Framework version 3.5 SP1 and SQL Server 2008, the following columns have been added to the Columns schema collection to support new spatial types, filestream and sparse columns. These columns are not supported in earlier versions of the .NET Framework and SQL Server.  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|IS_FILESTREAM|String|YES if the column has FILESTREAM attribute.<br /><br /> NO if the column does not have FILESTREAM attribute.|  
|IS_SPARSE|String|YES if the column is a sparse column.<br /><br /> NO if the column is not a sparse column.|  
|IS_COLUMN_SET|String|YES if the column is a column set column.<br /><br /> NO if the column is not a column set column.|  
  
### AllColumns (SQL Server 2008)  
 Beginning with the .NET Framework version 3.5 SP1 and SQL Server 2008, the AllColumns schema collection has been added to support sparse columns. AllColumns is not supported in earlier versions of the .NET Framework and SQL Server.  
  
 AllColumns has the same restrictions and resulting DataTable schema as the Columns schema collection. The only difference is that AllColumns includes column set columns that are not included in the Columns schema collection. The following table describes these columns.  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|TABLE_CATALOG|String|Catalog of the table.|  
|TABLE_SCHEMA|String|Schema that contains the table.|  
|TABLE_NAME|String|Table name.|  
|COLUMN_NAME|String|Column name.|  
|ORDINAL_POSITION|Int32|Column identification number.|  
|COLUMN_DEFAULT|String|Default value of the column|  
|IS_NULLABLE|String|Nullability of the column. If this column allows NULL, this column returns YES. Otherwise, NO is returned.|  
|DATA_TYPE|String|System-supplied data type.|  
|CHARACTER_MAXIMUM_LENGTH|Int32|Maximum length, in characters, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|CHARACTER_OCTET_LENGTH|Int32|Maximum length, in bytes, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|NUMERIC_PRECISION|Unsigned Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|NUMERIC_PRECISION_RADIX|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|NUMERIC_SCALE|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|DATETIME_PRECISION|Int16|Subtype code for datetime and SQL-92 interval data types. For other data types, NULL is returned.|  
|CHARACTER_SET_CATALOG|String|Returns master, indicating the database in which the character set is located, if the column is character data or text data type. Otherwise, NULL is returned.|  
|CHARACTER_SET_SCHEMA|String|Always returns NULL.|  
|CHARACTER_SET_NAME|String|Returns the unique name for the character set if this column is character data or text data type. Otherwise, NULL is returned.|  
|COLLATION_CATALOG|String|Returns master, indicating the database in which the collation is defined, if the column is character data or text data type. Otherwise, this column is NULL.|  
|IS_FILESTREAM|String|YES if the column has FILESTREAM attribute.<br /><br /> NO if the column does not have FILESTREAM attribute.|  
|IS_SPARSE|String|YES if the column is a sparse column.<br /><br /> NO if the column is not a sparse column.|  
|IS_COLUMN_SET|String|YES if the column is a column set column.<br /><br /> NO if the column is not a column set column.|  
  
### ColumnSetColumns (SQL Server 2008)  
 Beginning with the .NET Framework version 3.5 SP1 and SQL Server 2008, the ColumnSetColumns schema collection has been added to support sparse columns. ColumnSetColumns is not supported in earlier versions of the .NET Framework and SQL Server. The ColumnSetColumns schema collection returns the schema for all of the columns in a column set. The following table describes these columns.  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|TABLE_CATALOG|String|Catalog of the table.|  
|TABLE_SCHEMA|String|Schema that contains the table.|  
|TABLE_NAME|String|Table name.|  
|COLUMN_NAME|String|Column name.|  
|ORDINAL_POSITION|Int32|Column identification number.|  
|COLUMN_DEFAULT|String|Default value of the column|  
|IS_NULLABLE|String|Nullability of the column. If this column allows NULL, this column returns YES. Otherwise, NO is returned.|  
|DATA_TYPE|String|System-supplied data type.|  
|CHARACTER_MAXIMUM_LENGTH|Int32|Maximum length, in characters, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|CHARACTER_OCTET_LENGTH|Int32|Maximum length, in bytes, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|NUMERIC_PRECISION|Unsigned Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|NUMERIC_PRECISION_RADIX|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|NUMERIC_SCALE|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|DATETIME_PRECISION|Int16|Subtype code for datetime and SQL-92 interval data types. For other data types, NULL is returned.|  
|CHARACTER_SET_CATALOG|String|Returns master, indicating the database in which the character set is located, if the column is character data or text data type. Otherwise, NULL is returned.|  
|CHARACTER_SET_SCHEMA|String|Always returns NULL.|  
|CHARACTER_SET_NAME|String|Returns the unique name for the character set if this column is character data or text data type. Otherwise, NULL is returned.|  
|COLLATION_CATALOG|String|Returns master, indicating the database in which the collation is defined, if the column is character data or text data type. Otherwise, this column is NULL.|  
|IS_FILESTREAM|String|YES if the column has FILESTREAM attribute.<br /><br /> NO if the column does not have FILESTREAM attribute.|  
|IS_SPARSE|String|YES if the column is a sparse column.<br /><br /> NO if the column is not a sparse column.|  
|IS_COLUMN_SET|String|YES if the column is a column set column.<br /><br /> NO if the column is not a column set column.|  
  
## Users  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|uid|Int16|User ID, unique in this database. 1 is the database owner.|  
|user_name|String|Username or group name, unique in this database.|  
|createdate|DateTime|Date the account was added.|  
|updatedate|DateTime|Date the account was last changed.|  
  
## Views  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|TABLE_CATALOG|String|Catalog of the view.|  
|TABLE_SCHEMA|String|Schema that contains the view.|  
|TABLE_NAME|String|View name.|  
|CHECK_OPTION|String|Type of WITH CHECK OPTION. Is CASCADE if the original view was created using the WITH CHECK OPTION. Otherwise, NONE is returned.|  
|IS_UPDATABLE|String|Specifies whether the view is updatable. Always returns NO.|  
  
## ViewColumns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|VIEW_CATALOG|String|Catalog of the view.|  
|VIEW_SCHEMA|String|Schema that contains the view.|  
|VIEW_NAME|String|View name.|  
|TABLE_CATALOG|String|Catalog of the table that is associated with this view.|  
|TABLE_SCHEMA|String|Schema that contains the table that is associated with this view.|  
|TABLE_NAME|String|Name of the table that is associated with the view. Base Table.|  
|COLUMN_NAME|String|Column name.|  
  
## UserDefinedTypes  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|assembly_name|String|The name of the file for the assembly.|  
|udt_name|String|The class name for the assembly.|  
|version_major|Object|Major Version Number.|  
|version_minor|Object|Minor Version Number.|  
|version_build|Object|Build Number.|  
|version_revision|Object|Revision Number.|  
|culture_info|Object|The culture information associated with this UDT.|  
|public_key|Object|The public key used by this Assembly.|  
|is_fixed_length|Boolean|Specifies whether length of type is always same as max_length.|  
|max_length|Int16|Maximum length of type in bytes.|  
|Create_Date|DateTime|The date the assembly was created/registered.|  
|Permission_set_desc|String|The friendly name for the permission-set/security-level for the assembly.|  
  
## See Also  
 [Retrieving Database Schema Information](../../../../docs/framework/data/adonet/retrieving-database-schema-information.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

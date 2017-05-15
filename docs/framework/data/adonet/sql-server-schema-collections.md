---
title: "SQL Server Schema Collections | Microsoft Docs"
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
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# SQL Server Schema Collections
The Microsoft .NET Framework Data Provider for SQL Server supports additional schema collections in addition to the common schema collections. The schema collections vary slightly by the version of SQL Server you are using. To determine the list of supported schema collections, call the **GetSchema** method with no arguments, or with the schema collection name "MetaDataCollections". This will return a <xref:System.Data.DataTable> with a list of the supported schema collections, the number of restrictions that they each support, and the number of identifier parts that they use.  
  
## Databases  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|database_name|String|Name of the database.|  
|Dbid|Int16|Database ID.|  
|create_date|DateTime|Creation Date of the database.|  
  
## Foreign Keys  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|constraint_catalog|String|Catalog the constraint belongs to.|  
|constraint_schema|String|Schema that contains the constraint.|  
|constraint_name|String|Name.|  
|table_catalog|String|Table Name constraint is part of.|  
|table_schema|String|Schema that that contains the table.|  
|table_name|String|Table Name|  
|constraint_type|String|Type of constraint. Only "FOREIGN KEY" is allowed.|  
|is_deferrable|String|Specifies whether the constraint is deferrable. Returns NO.|  
|initially_deferred|String|Specifies whether the constraint is initially deferrable. Returns NO.|  
  
## Indexes  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|constraint_catalog|String|Catalog that index belongs to.|  
|constraint_schema|String|Schema that contains the index.|  
|constraint_name|String|Name of the index.|  
|table_catalog|String|Table name the index is associated with.|  
|table_schema|String|Schema that contains the table the index is associated with.|  
|table_name|String|Table Name.|  
  
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
|KeyType|UInt16|The type of object.|  
  
## Procedures  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|specific_catalog|String|Specific name for the catalog.|  
|specific_schema|String|Specific name of the schema.|  
|specific_name|String|Specific name of the catalog.|  
|routine_catalog|String|Catalog the stored procedure belongs to.|  
|routine_schema|String|Schema that contains the stored procedure.|  
|routine_name|String|Name of the stored procedure.|  
|routine_type|String|Returns PROCEDURE for stored procedures and FUNCTION for functions.|  
|created|DateTime|Time the procedure was created.|  
|last_altered|DateTime|The last time the procedure was modified.|  
  
## Procedure Parameters  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|specific_catalog|String|Catalog name of the procedure for which this is a parameter.|  
|specific_schema|String|Schema that contains the procedure for which this parameter is part of.|  
|specific_name|String|Name of the procedure for which this parameter is a part of.|  
|ordinal_position|Int16|Ordinal position of the parameter starting at 1. For the return value of a procedure, this is a 0.|  
|parameter_mode|String|Returns IN if an input parameter, OUT if an output parameter, and INOUT if an input/output parameter.|  
|is_result|String|Returns YES if indicates result of the procedure that is a function. Otherwise, returns NO.|  
|as_locator|String|Returns YES if declared as locator. Otherwise, returns NO.|  
|parameter_name|String|Name of the parameter. NULL if this corresponds to the return value of a function.|  
|data_type|String|System-supplied data type.|  
|character_maximum_length|Int32|Maximum length in characters for binary or character data types. Otherwise, returns NULL.|  
|character_octet_length|Int32|Maximum length, in bytes, for binary or character data types. Otherwise, returns NULL.|  
|collation_catalog|String|Catalog name of the collation of the parameter. If not one of the character types, returns NULL.|  
|collation_schema|String|Always returns NULL.|  
|collation_name|String|Name of the collation of the parameter. If not one of the character types, returns NULL.|  
|character_set_catalog|String|Catalog name of the character set of the parameter. If not one of the character types, returns NULL.|  
|character_set_schema|String|Always returns NULL.|  
|character_set_name|String|Name of the character set of the parameter. If not one of the character types, returns NULL.|  
|numeric_precision|Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, returns NULL.|  
|numeric_precision_radix|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, returns NULL.|  
|numeric_scale|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, returns NULL.|  
|datetime_precision|Int16|Precision in fractional seconds if the parameter type is datetime or smalldatetime. Otherwise, returns NULL.|  
|interval_type|String|NULL. Reserved for future use by SQL Server.|  
|interval_precision|Int16|NULL. Reserved for future use by SQL Server.|  
  
## Tables  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|table_catalog|String|Catalog of the table.|  
|table_schema|String|Schema that contains the table.|  
|table_name|String|Table name.|  
|table_type|String|Type of table. Can be VIEW or BASE TABLE.|  
  
## Columns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|table_catalog|String|Catalog of the table.|  
|table_schema|String|Schema that contains the table.|  
|table_name|String|Table name.|  
|column_name|String|Column name.|  
|ordinal_position|Int16|Column identification number.|  
|column_default|String|Default value of the column|  
|is_nullable|String|Nullability of the column. If this column allows NULL, this column returns YES. Otherwise, No is returned.|  
|data_type|String|System-supplied data type.|  
|character_maximum_length|Int32 – Sql8, Int16 – Sql7|Maximum length, in characters, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|character_octet_length|Int32 – SQL8, Int16 – Sql7|Maximum length, in bytes, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|numeric_precision|Unsigned Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|numeric_precision_radix|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|numeric_scale|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|datetime_precision|Int16|Subtype code for datetime and SQL-92 interval data types. For other data types, NULL is returned.|  
|character_set_catalog|String|Returns master, indicating the database in which the character set is located, if the column is character data or text data type. Otherwise, NULL is returned.|  
|character_set_schema|String|Always returns NULL.|  
|character_set_name|String|Returns the unique name for the character set if this column is character data or text data type. Otherwise, NULL is returned.|  
|collation_catalog|String|Returns master, indicating the database in which the collation is defined, if the column is character data or text data type. Otherwise, this column is NULL.|  
  
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
|table_catalog|String|Catalog of the table.|  
|table_schema|String|Schema that contains the table.|  
|table_name|String|Table name.|  
|column_name|String|Column name.|  
|ordinal_position|Int16|Column identification number.|  
|column_default|String|Default value of the column|  
|is_nullable|String|Nullability of the column. If this column allows NULL, this column returns YES. Otherwise, NO is returned.|  
|data_type|String|System-supplied data type.|  
|character_maximum_length|Int32|Maximum length, in characters, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|character_octet_length|Int32|Maximum length, in bytes, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|numeric_precision|Unsigned Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|numeric_precision_radix|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|numeric_scale|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|datetime_precision|Int16|Subtype code for datetime and SQL-92 interval data types. For other data types, NULL is returned.|  
|character_set_catalog|String|Returns master, indicating the database in which the character set is located, if the column is character data or text data type. Otherwise, NULL is returned.|  
|character_set_schema|String|Always returns NULL.|  
|character_set_name|String|Returns the unique name for the character set if this column is character data or text data type. Otherwise, NULL is returned.|  
|collation_catalog|String|Returns master, indicating the database in which the collation is defined, if the column is character data or text data type. Otherwise, this column is NULL.|  
|IS_FILESTREAM|String|YES if the column has FILESTREAM attribute.<br /><br /> NO if the column does not have FILESTREAM attribute.|  
|IS_SPARSE|String|YES if the column is a sparse column.<br /><br /> NO if the column is not a sparse column.|  
|IS_COLUMN_SET|String|YES if the column is a column set column.<br /><br /> NO if the column is not a column set column.|  
  
### ColumnSetColumns (SQL Server 2008)  
 Beginning with the .NET Framework version 3.5 SP1 and SQL Server 2008, the ColumnSetColumns schema collection has been added to support sparse columns. ColumnSetColumns is not supported in earlier versions of the .NET Framework and SQL Server. The ColumnSetColumns schema collection returns the schema for all of the columns in a column set. The following table describes these columns.  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|table_catalog|String|Catalog of the table.|  
|table_schema|String|Schema that contains the table.|  
|table_name|String|Table name.|  
|column_name|String|Column name.|  
|ordinal_position|Int16|Column identification number.|  
|column_default|String|Default value of the column|  
|is_nullable|String|Nullability of the column. If this column allows NULL, this column returns YES. Otherwise, NO is returned.|  
|data_type|String|System-supplied data type.|  
|character_maximum_length|Int32|Maximum length, in characters, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|character_octet_length|Int32|Maximum length, in bytes, for binary data, character data, or text and image data. Otherwise, NULL is returned.|  
|numeric_precision|Unsigned Byte|Precision of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|numeric_precision_radix|Int16|Precision radix of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|numeric_scale|Int32|Scale of approximate numeric data, exact numeric data, integer data, or monetary data. Otherwise, NULL is returned.|  
|datetime_precision|Int16|Subtype code for datetime and SQL-92 interval data types. For other data types, NULL is returned.|  
|character_set_catalog|String|Returns master, indicating the database in which the character set is located, if the column is character data or text data type. Otherwise, NULL is returned.|  
|character_set_schema|String|Always returns NULL.|  
|character_set_name|String|Returns the unique name for the character set if this column is character data or text data type. Otherwise, NULL is returned.|  
|collation_catalog|String|Returns master, indicating the database in which the collation is defined, if the column is character data or text data type. Otherwise, this column is NULL.|  
|IS_FILESTREAM|String|YES if the column has FILESTREAM attribute.<br /><br /> NO if the column does not have FILESTREAM attribute.|  
|IS_SPARSE|String|YES if the column is a sparse column.<br /><br /> NO if the column is not a sparse column.|  
|IS_COLUMN_SET|String|YES if the column is a column set column.<br /><br /> NO if the column is not a column set column.|  
  
## Users  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|uid|Int16|User ID, unique in this database. 1 is the database owner.|  
|name|String|Username or group name, unique in this database.|  
|createdate|DateTime|Date the account was added.|  
|updatedate|DateTime|Date the account was last changed.|  
  
## Views  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|table_catalog|String|Catalog of the view.|  
|table_schema|String|Schema that contains the view.|  
|table_name|String|View name.|  
|check_option|String|Type of WITH CHECK OPTION. Is CASCADE if the original view was created using the WITH CHECK OPTION. Otherwise, NONE is returned.|  
|is_updatable|String|Specifies whether the view is updatable. Always returns NO.|  
  
## ViewColumns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|view_catalog|String|Catalog of the view.|  
|view_schema|String|Schema that contains the view.|  
|view_name|String|View name.|  
|table_catalog|String|Catalog of the table that is associated with this view.|  
|table_schema|String|Schema that contains the table that is associated with this view.|  
|table_name|String|Name of the table that is associated with the view. Base Table.|  
|column_name|String|Column name.|  
  
## UserDefinedTypes  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|assembly_name|String|The name of the file for the assembly.|  
|UDT_name|String|The class name for the assembly.|  
|version_major|Object|Major Version Number.|  
|version_minor|Object|Minor Version Number.|  
|version_build|Object|Build Number.|  
|version_revision|Object|Revision Number.|  
|Culture_info|Object|The culture information associated with this UDT.|  
|Public_key|Object|The public key used by this Assembly.|  
|Is_fixed_length|Boolean|Specifies whether length of type is always same as max_length.|  
|max_length|Int16|Maximum length of type in bytes.|  
|permission_set_desc|String|The friendly name for the permission-set/security-level for the assembly.|  
|create_date|DateTime|The date the assembly was created/registered.|  
  
## See Also  
 [Retrieving Database Schema Information](../../../../docs/framework/data/adonet/retrieving-database-schema-information.md)   
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
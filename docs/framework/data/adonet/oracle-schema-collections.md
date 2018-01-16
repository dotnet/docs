---
title: "Oracle Schema Collections"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 89a75de8-dee8-45e2-a97f-254d7e62e7e1
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Oracle Schema Collections
The Microsoft .NET Framework Data Provider for Oracle supports the following specific schema collections in addition to the common schema collections:  
  
-   Columns  
  
-   Indexes  
  
-   IndexColumns  
  
-   Procedures  
  
-   Sequences  
  
-   Synonyms  
  
-   Tables  
  
-   Users  
  
-   Views  
  
-   Functions  
  
-   Packages  
  
-   PackageBodies  
  
-   Arguments  
  
-   UniqueKeys  
  
-   PrimaryKeys  
  
-   ForeignKeys  
  
-   ForeignKeyColumns  
  
-   ProcedureParameters  
  
## Columns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the table, view or cluster.|  
|TABLE_NAME|String|Table, view, or cluster name.|  
|COLUMN_NAME|String|Column name.|  
|ID|Decimal|Sequence number of the column as created.|  
|DATATYPE|String|Datatype of the column.|  
|LENGTH|Decimal|Length of the column in bytes.|  
|PRECISION|Decimal|Decimal precision for NUMBER datatype; binary precision for FLOAT datatype, null for all other datatypes.|  
|SCALE|Decimal|Digits to right of decimal point in a number.|  
|NULLABLE|String|Specifies whether a column allows NULLs. Value is N if there is a NOT NULL constraint on the column or if the column is part of a PRIMARY KEY.|  
  
## Indexes  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the index|  
|INDEX_NAME|String|Name of the index.|  
|INDEX_TYPE|String|Type of index (NORMAL, BITMAP, FUNCTION-BASED NORMAL, FUNCTION-BASED BITMAP, or DOMAIN).|  
|TABLE_OWNER|String|Owner of the indexed object.|  
|TABLE_NAME|String|Name of the indexed object.|  
|TABLE_TYPE|String|Type of the indexed object (for example, TABLE, CLUSTER).|  
|UNIQUENESS|String|Whether the index is UNIQUE or NONUNIQUE.|  
|COMPRESSION|String|Whether the index is ENABLED or DISABLED.|  
|PREFIX_LENGTH|Decimal|Number of columns in the prefix of the compression key.|  
|TABLESPACE_NAME|String|Name of the tablespace containing the index.|  
|INI_TRANS|Decimal|Initial number of transactions.|  
|MAX_TRANS|Decimal|Maximum number of transactions.|  
|INITIAL_EXTENT|Decimal|Size of the initial extent.|  
|NEXT_EXTENT|Decimal|Size of secondary extents.|  
|MIN_EXTENTS|Decimal|Minimum number of extents allowed in the segment.|  
|MAX_EXTENTS|Decimal|Maximum number of extents allowed in the segment.|  
|PCT_INCREASE|Decimal|Percentage increase in extent size.|  
|PCT_THRESHOLD|Decimal|Threshold percentage of block space allowed per index entry.|  
|INCLUDE_COLUMN|Decimal|Column ID of the last column to be included in index-organized table primary key (non-overflow) index. This column maps to the COLUMN_ID column of the *_TAB_COLUMNS data dictionary views.|  
|FREELISTS|Decimal|Number of process freelists allocated to this segment.|  
|FREELIST_GROUPS|Decimal|Number of freelist groups allocated to this segment.|  
|PCT_FREE|Decimal|Minimum percentage of free space in a block.|  
|LOGGING|String|Logging information.|  
|BLEVEL|Decimal|B*-Tree level: depth of the index from its root block to its leaf blocks. A depth of 0 indicates that the root block and leaf block are the same.|  
|LEAF_BLOCKS|Decimal|Number of leaf blocks in the index|  
|DISTINCT_KEYS|Decimal|Number of distinct indexed values. For indexes that enforce UNIQUE and PRIMARY KEY constraints, this value is the same as the number of rows in the table (USER_TABLES.NUM_ROWS).|  
|AVG_LEAF_BLOCKS_PER_KEY|Decimal|Average number of leaf blocks in which each distinct value in the index appears rounded to the nearest integer. For indexes that enforce UNIQUE and PRIMARY KEY constraints, this value is always 1.|  
|AVG_DATA_BLOCKS_PER_KEY|Decimal|Average number of data blocks in the table that are pointed to by a distinct value in the index rounded to the nearest integer. This statistic is the average number of data blocks that contain rows that contain a given value for the indexed columns.|  
|CLUSTERING_FACTOR|Decimal|Indicates the amount of order of the rows in the table based on the values of the index.|  
|STATUS|String|Whether a nonpartitioned index is VALID or UNUSABLE.|  
|NUM_ROWS|Decimal|Number of rows in the index.|  
|SAMPLE_SIZE|Decimal|Size of the sample used to analyze the index.|  
|LAST_ANALYZED|DateTime|Date on which this index was most recently analyzed.|  
|DEGREE|String|Number of threads per instance for scanning the index.|  
|INSTANCES|String|Number of instances across which the indexes to be scanned.|  
|PARTITIONED|String|Whether this index is partitioned (YES &#124; NO).|  
|TEMPORARY|String|Whether the index is on a temporary table.|  
|GENERATED|String|Whether the name of the index is system generated (Y&#124;N).|  
|SECONDARY|String|Whether the index is a secondary object created by the ODCIIndexCreate method of the Oracle9i Data Cartridge (Y&#124;N).|  
|BUFFER_POOL|String|Name of the default buffer pool to be used for the index blocks.|  
|USER_STATS|String|Whether the statistics were entered directly by the user.|  
|DURATION|String|Indicates the duration of a temporary table: 1)SYS$SESSION: the rows are preserved for the duration of the session, 2) SYS$TRANSACTION: the rows are deleted after COMMIT, 3) Null for permanent Table.|  
|PCT_DIRECT_ACCESS|Decimal|For a secondary index on an index-organized table, the percentage of rows with VALID guess|  
|ITYP_OWNER|String|For a domain index, the owner of the indextype.|  
|ITYP_NAME|String|For a domain index, the name of the indextype.|  
|PARAMETERS|String|For a domain index, the parameter string.|  
|GLOBAL_STATS|String|For partitioned indexes, indicates whether statistics were collected by analyzing index as a whole (YES) or were estimated from statistics on underlying index partitions and subpartitions (NO).|  
|DOMIDX_STATUS|String|Reflects the status of the domain index. NULL: the specified index is not a domain index. VALID: the index is a valid domain index. IDXTYP_INVLD: the index type of this domain index is invalid.|  
|DOMIDX_OPSTATUS|String|Reflects the status of an operation that was performed on a domain index: NULL: the specified index is not a domain index. VALID: the operation performed without errors. FAILED: the operation failed with an error.|  
|FUNCIDX_STATUS|String|Indicates the status of a function-based index: NULL: this is not a function-based index, ENABLED: the function-based index is enabled, DISABLED: the function-based index is disabled.|  
|JOIN_INDEX|String|Indicates whether this is a join index or not.|  
  
## IndexColumns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|INDEX_OWNER|String|Owner of the index.|  
|INDEX_NAME|String|Name of the index.|  
|TABLE_OWNER|String|Owner of the table or cluster.|  
|TABLE_NAME|String|Name of the table or cluster.|  
|COLUMN_NAME|String|Column name or attribute of object type column.|  
|COLUMN_POSITION|Decimal|Position of column or attribute within the index.|  
|COLUMN_LENGTH|Decimal|Indexed length of the column.|  
|CHAR_LENGTH|Decimal|Maximum codepoint length of the column.|  
|DESCEND|String|Whether the column is sorted in descending order.|  
  
## Procedures  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the object.|  
|OBJECT_NAME|String|Name of the object.|  
|SUBOBJECT_NAME|String|Name of the subobject (for example, partition).|  
|OBJECT_ID|Decimal|Dictionary object number of the object.|  
|DATA_OBJECT_ID|Decimal|Dictionary object number of the segment that contains the object.|  
|LAST_DDL_TIME|DateTime|Timestamp for the last modification of the object resulting from a DDL command (including grants and revokes).|  
|TIMESTAMP|String|Timestamp for the specification of the object (character data).|  
|STATUS|String|Status of the object (VALID, INVALID, or N/A).|  
|TEMPORARY|String|Whether the object is temporary (the current session can see only data that it placed in this object itself).|  
|GENERATED|String|Was the name of this object system generated? (Y &#124; N).|  
|SECONDARY|String|Whether this is a secondary object created by the ODCIIndexCreate method of the Oracle9i Data Cartridge (Y &#124; N).|  
|CREATED|DateTime|The date the object was created.|  
  
## Sequences  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|SEQUENCE_OWNER|String|Name of the owner of the sequence.|  
|SEQUENCE_NAME|String|Sequence name.|  
|MIN_VALUE|Decimal|Minimum value of the sequence.|  
|MAX_VALUE|Decimal|Maximum value of the sequence.|  
|INCREMENT_BY|Decimal|Value by which sequence is incremented.|  
|CYCLE_FLAG|String|Does sequence wrap around on reaching limit.|  
|ORDER_FLAG|String|Are sequence numbers generated in order.|  
|CACHE_SIZE|Decimal|Number of sequence numbers to cache.|  
|LAST_NUMBER|Decimal|Last sequence number written to disk. If a sequence uses caching, the number written to disk is the last number placed in the sequence cache. This number is likely to be greater than the last sequence number that was used.|  
  
## Synonyms  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the synonym.|  
|SYNONYM_NAME|String|Name of the synonym.|  
|TABLE_OWNER|String|Owner of the object referenced by the synonym.|  
|TABLE_NAME|String|Name of the object referenced by the synonym.|  
|DB_LINK|String|Name of the database link referenced, if any.|  
  
## Tables  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the table.|  
|TABLE_NAME|String|Name of the table.|  
|TYPE|String|Type of table.|  
  
## Users  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|NAME|String|Name of the user.|  
|ID|Decimal|ID number of the user.|  
|CREATEDATE|DateTime|User creation date.|  
  
## Views  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the view.|  
|VIEW_NAME|String|Name of the view.|  
|TEXT_LENGTH|Decimal|Length of the view text.|  
|TEXT|String|View text.|  
|TYPE_TEXT_LENGTH|Decimal|Length of the type clause of the typed view.|  
|TYPE_TEXT|String|Type clause of the typed view.|  
|OID_TEXT_LENGTH|Decimal|Length of the WITH OID clause of the typed view.|  
|OID_TEXT|String|WITH OID clause of the typed view.|  
|VIEW_TYPE_OWNER|String|Owner of the type of the view if the view is a typed view.|  
|VIEW_TYPE|String|Type of the view if the view is a typed view.|  
|SUPERVIEW_NAME|String|Name of the superview.|  
  
## Functions  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the object.|  
|OBJECT_NAME|String|Name of the object.|  
|SUBOBJECT_NAME|String|Name of the subobject (for example, partition).|  
|OBJECT_ID|Decimal|Dictionary object number of the object.|  
|DATA_OBJECT_ID|Decimal|Dictionary object number of the segment that contains the object.|  
|OBJECT_TYPE|String|Type of the object.|  
|CREATED|DateTime|The date the object was created.|  
|LAST_DDL_TIME|DateTime|Timestamp for the last modification of the object resulting from a DDL command (including grants and revokes).|  
|TIMESTAMP|String|Timestamp for the specification of the object (character data)|  
|STATUS|String|Status of the object (VALID, INVALID, or N/A).|  
|TEMPORARY|String|Whether the object is temporary (the current session can see only data that it placed in this object itself).|  
|GENERATED|String|Was the name of this object system generated? (Y &#124; N).|  
|SECONDARY|String|Whether this is a secondary object created by the ODCIIndexCreate method of the Oracle9i Data Cartridge (Y &#124; N).|  
  
## Packages  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the object.|  
|OBJECT_NAME|String|Name of the object.|  
|SUBOBJECT_NAME|String|Name of the subobject (for example, partition).|  
|OBJECT_ID|Decimal|Dictionary object number of the object.|  
|DATA_OBJECT_ID|Decimal|Dictionary object number of the segment that contains the object.|  
|LAST_DDL_TIME|DateTime|Timestamp for the last modification of the object resulting from a DDL command (including grants and revokes).|  
|TIMESTAMP|String|Timestamp for the specification of the object (character data).|  
|STATUS|String|Status of the object (VALID, INVALID, or N/A).|  
|TEMPORARY|String|Whether the object is temporary (the current session can see only data that it placed in this object itself).|  
|GENERATED|String|Was the name of this object system generated? (Y &#124; N).|  
|SECONDARY|String|Whether this is a secondary object created by the ODCIIndexCreate method of the Oracle9i Data Cartridge (Y &#124; N).|  
|CREATED|DateTime|The date the object was created.|  
  
## PackageBodies  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the object.|  
|OBJECT_NAME|String|Name of the object.|  
|SUBOBJECT_NAME|String|Name of the subobject (for example, partition).|  
|OBJECT_ID|Decimal|Dictionary object number of the object.|  
|DATA_OBJECT_ID|Decimal|Dictionary object number of the segment that contains the object.|  
|LAST_DDL_TIME|DateTime|Timestamp for the last modification of the object resulting from a DDL command (including grants and revokes).|  
|TIMESTAMP|String|Timestamp for the specification of the object (character data).|  
|STATUS|String|Status of the object (VALID, INVALID, or N/A).|  
|TEMPORARY|String|Whether the object is temporary (the current session can see only data that it placed in this object itself).|  
|GENERATED|String|Was the name of this object system generated? (Y &#124; N).|  
|SECONDARY|String|Whether this is a secondary object created by the ODCIIndexCreate method of the Oracle9i Data Cartridge (Y &#124; N).|  
|CREATED|DateTime|The date the object was created.|  
  
## Arguments  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Name of the owner of the object.|  
|PACKAGE_NAME|String|Package name.|  
|OBJECT_NAME|String|Name of the procedure or function.|  
|ARGUMENT_NAME|String|Name of the argument.|  
|POSITION|Decimal|Position in argument list, or NULL for function return value.|  
|SEQUENCE|Decimal|Argument sequence, including all nesting levels.|  
|DEFAULT_VALUE|String|Default value for the argument.|  
|DEFAULT_LENGTH|Decimal|Length of default value for the argument.|  
|IN_OUT|String|Argument direction (IN, OUT, or IN/OUT).|  
|DATA_LENGTH|Decimal|Length of the column in bytes.|  
|DATA_PRECISION|Decimal|Length in decimal digits (NUMBER) or binary digits (FLOAT).|  
|DATA_SCALE|Decimal|Digits to right of decimal point in a number.|  
|DATA_TYPE|String|Data type of the argument.|  
  
## UniqueKeys  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the constraint definition.|  
|CONSTRAINT_NAME|String|Name of the constraint definition.|  
|TABLE_NAME|String|Name associated with the table (or view) with constraint definition.|  
|SEARCH_CONDITION|String|Text of search condition for a check constraint.|  
|R_OWNER|String|Owner of table referred to in a referential constraint.|  
|R_CONSTRAINT_NAME|String|Name of the unique constraint definition for referenced table.|  
|DELETE_RULE|String|Delete rule for a referential constraint (CASCADE or NO ACTION).|  
|STATUS|String|Enforcement status of constraint (ENABLED or DISABLED).|  
|DEFERRABLE|String|Whether the constraint is deferrable.|  
|VALIDATED|String|Whether all data obeys the constraint (VALIDATED or NOT VALIDATED).|  
|GENERATED|String|Whether the name of the constraint is user or system generated.|  
|BAD|String|A YES value indicates that this constraint specifies a century in an ambiguous manner. To avoid errors resulting from this ambiguity, rewrite the constraint using the TO_DATE function with a four-digit year.|  
|RELY|String|Whether an enabled constraint is enforced or unenforced.|  
|LAST_CHANGE|DateTime|When the constraint was last enabled or disabled|  
|INDEX_OWNER|String|Name of the user owning the index|  
|INDEX_NAME|String|Name of the index|  
  
## PrimaryKeys  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the constraint definition.|  
|CONSTRAINT_NAME|String|Name of the constraint definition.|  
|TABLE_NAME|String|Name associated with the table (or view) with constraint definition.|  
|SEARCH_CONDITION|String|Text of search condition for a check constraint.|  
|R_OWNER|String|Owner of table referred to in a referential constraint.|  
|R_CONSTRAINT_NAME|String|Name of the unique constraint definition for referenced table.|  
|DELETE_RULE|String|Delete rule for a referential constraint (CASCADE or NO ACTION).|  
|STATUS|String|Enforcement status of constraint (ENABLED or DISABLED).|  
|DEFERRABLE|String|Whether the constraint is deferrable.|  
|VALIDATED|String|Whether all data obeys the constraint (VALIDATED or NOT VALIDATED).|  
|GENERATED|String|Whether the name of the constraint is user or system generated.|  
|BAD|String|A YES value indicates that this constraint specifies a century in an ambiguous manner. To avoid errors resulting from this ambiguity, rewrite the constraint using the TO_DATE function with a four-digit year.|  
|RELY|String|Whether an enabled constraint is enforced or unenforced.|  
|LAST_CHANGE|DateTime|When the constraint was last enabled or disabled.|  
|INDEX_OWNER|String|Name of the user owning the index.|  
|INDEX_NAME|String|Name of the index.|  
  
## ForeignKeys  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|PRIMARY_KEY_CONSTRAINT_NAME|String|Name of the constraint definition.|  
|PRIMARY_KEY_OWNER|String|Owner of the constraint definition.|  
|PRIMARY_KEY_TABLE_NAME|String|Name associated with the table (or view) with constraint definition|  
|FOREIGN_KEY_OWNER|String|Owner of the constraint definition.|  
|FOREIGN_KEY_CONSTRIANT_NAME|String|Name of the constraint definition.|  
|FOREIGN_KEY_TABLE_NAME|String|Name associated with the table (or view) with constraint definition.|  
|SEARCH_CONDITION|String|Text of search condition for a check constraint|  
|R_OWNER|String|Owner of table referred to in a referential constraint.|  
|R_CONSTRAINT_NAME|String|Name of the unique constraint definition for referenced table.|  
|DELETE_RULE|String|Delete rule for a referential constraint (CASCADE or NO ACTION).|  
|STATUS|String|Enforcement status of constraint (ENABLED or DISABLED).|  
|VALIDATED|String|Whether all data obeys the constraint (VALIDATED or NOT VALIDATED).|  
|GENERATED|String|Whether the name of the constraint is user or system generated.|  
|RELY|String|Whether an enabled constraint is enforced or unenforced.|  
|LAST_CHANGE|DateTime|When the constraint was last enabled or disabled.|  
|INDEX_OWNER|String|Name of the user owning the index.|  
|INDEX_NAME|String|Name of the index.|  
  
## ForeignKeyColumns  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the constraint definition.|  
|CONSTRAINT_NAME|String|Name of the constraint definition.|  
|TABLE_NAME|String|Name of the table with constraint definition.|  
|COLUMN_NAME|String|Name of the column or attribute of the object type column specified in the constraint definition.|  
|POSITION|Decimal|Original position of column or attribute in the definition of the object.|  
  
## ProcedureParameters  
  
|ColumnName|DataType|Description|  
|----------------|--------------|-----------------|  
|OWNER|String|Owner of the object.|  
|OBJECT_NAME|String|Name of the procedure or function.|  
|PACKAGE_NAME|String|Name of the procedure or function.|  
|OBJECT_ID|Decimal|Object number of the object.|  
|OVERLOAD|String|Overload unique identifier.|  
|ARGUMENT_NAME|String|Name of the argument.|  
|POSITION|Decimal|Position in the argument list, or null for a function return value.|  
|SEQUENCE|Decimal|Argument sequence, including all nesting levels.|  
|DATA_LEVEL|Decimal|Nesting depth of the argument for composite types.|  
|DATA_TYPE|String|Data type of the argument.|  
|DEFAULT_VALUE|String|Default value for the argument.|  
|DEFAULT_LENGTH|Decimal|Length of the default value for the argument.|  
|IN_OUT|String|Argument Direction (IN, OUT, or IN/OUT).|  
|DATA_LENGTH|Decimal|Length of the column (in bytes).|  
|DATA_PRECISION|Decimal|Length in decimal digits (NUMBER) or binary digits (FLOAT).|  
|DATA_SCALE|Decimal|Digits to the right of the decimal point in a number.|  
|RADIX|Decimal|Argument radix for a number.|  
|CHARACTER_SET_NAME|String|Character set name for the argument.|  
|TYPE_OWNER|String|Owner of the type of the argument.|  
|TYPE_NAME|String|Name of the type of the argument. If the type is a package local type (that is, it is declared in a package specification), then this column displays the name of the package.|  
|TYPE_SUBNAME|String|Relevant only for package local types. Displays the name of the type declared in the package identified in the TYPE_NAME column.|  
|TYPE_LINK|String|Relevant only for package local types when the package identified in the TYPE_NAME column is a remote package. This column displays the database link used to refer to the remote package.|  
|PLS_TYPE|String|For numeric arguments, the name of the PL/SQL type of the argument. Null otherwise.|  
|CHAR_LENGTH|Decimal|Character limit for string data types.|  
|CHAR_USED|String|Indicates whether the byte limit (B) or char limit (C) is official for the string.|  
  
## See Also  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

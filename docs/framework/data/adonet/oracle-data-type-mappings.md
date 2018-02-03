---
title: "Oracle Data Type Mappings1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ec34ae21-bbbb-4adb-b672-83865e2a8451
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Oracle Data Type Mappings
The following table lists Oracle data types and their mappings to the <xref:System.Data.OracleClient.OracleDataReader>.  
  
|Oracle data type|.NET Framework data type returned by OracleDataReader.GetValue|OracleClient data type returned by OracleDataReader.GetOracleValue|Remarks|  
|----------------------|--------------------------------------------------------------------|------------------------------------------------------------------------|-------------|  
|**BFILE**|**Byte[]**|<xref:System.Data.OracleClient.OracleBFile>||  
|**BLOB**|**Byte[]**|<xref:System.Data.OracleClient.OracleLob>||  
|**CHAR**|**String**|<xref:System.Data.OracleClient.OracleString>||  
|**CLOB**|**String**|<xref:System.Data.OracleClient.OracleLob>||  
|**DATE**|**DateTime**|<xref:System.Data.OracleClient.OracleDateTime>||  
|**FLOAT**|**Decimal**|<xref:System.Data.OracleClient.OracleNumber>|This data type is an alias for the **NUMBER** data type, and is designed so that the <xref:System.Data.OracleClient.OracleDataReader> returns a **System.Decimal** or <xref:System.Data.OracleClient.OracleNumber> instead of a floating-point value. Using the .NET Framework data type can cause an overflow.|  
|**INTEGER**|**Decimal**|<xref:System.Data.OracleClient.OracleNumber>|This data type is an alias for the **NUMBER(38)** data type, and is designed so that the <xref:System.Data.OracleClient.OracleDataReader> returns a **System.Decimal** or <xref:System.Data.OracleClient.OracleNumber> instead of an integer value. Using the .NET Framework data type can cause an overflow.|  
|**INTERVAL YEAR TO MONTH**|**Int32**|<xref:System.Data.OracleClient.OracleMonthSpan>||  
|**INTERVAL DAY TO SECOND**|**TimeSpan**|<xref:System.Data.OracleClient.OracleTimeSpan>||  
|**LONG**|**String**|<xref:System.Data.OracleClient.OracleString>||  
|**LONG RAW**|**Byte[]**|<xref:System.Data.OracleClient.OracleBinary>||  
|**NCHAR**|**String**|<xref:System.Data.OracleClient.OracleString>||  
|**NCLOB**|**String**|<xref:System.Data.OracleClient.OracleLob>||  
|**NUMBER**|**Decimal**|<xref:System.Data.OracleClient.OracleNumber>|Using the .NET Framework data type can cause an overflow.|  
|**NVARCHAR2**|**String**|<xref:System.Data.OracleClient.OracleString>||  
|**RAW**|**Byte[]**|<xref:System.Data.OracleClient.OracleBinary>||  
|**REF CURSOR**|||The Oracle **REF CURSOR** data type is not supported by the <xref:System.Data.OracleClient.OracleDataReader> object.|  
|**ROWID**|**String**|<xref:System.Data.OracleClient.OracleString>||  
|**TIMESTAMP**|**DateTime**|<xref:System.Data.OracleClient.OracleDateTime>||  
|**TIMESTAMP WITH LOCAL TIME ZONE**|**DateTime**|<xref:System.Data.OracleClient.OracleDateTime>||  
|**TIMESTAMP WITH TIME ZONE**|**DateTime**|<xref:System.Data.OracleClient.OracleDateTime>||  
|**UNSIGNED INTEGER**|**Number**|<xref:System.Data.OracleClient.OracleNumber>|This data type is an alias for the **NUMBER(38)** data type, and is designed so that the <xref:System.Data.OracleClient.OracleDataReader> returns a **System.Decimal** or <xref:System.Data.OracleClient.OracleNumber> instead of an unsigned integer value. Using the .NET Framework data type can cause an overflow.|  
|**VARCHAR2**|**String**|<xref:System.Data.OracleClient.OracleString>||  
  
 The following table lists Oracle data types and the .NET Framework data types (**System.Data.DbType** and <xref:System.Data.OracleClient.OracleType>) to use when binding them as parameters.  
  
|Oracle data type|DbType enumeration to bind as a parameter|OracleType enumeration to bind as a parameter|Remarks|  
|----------------------|-----------------------------------------------|---------------------------------------------------|-------------|  
|**BFILE**||**BFile**|Oracle only allows binding a **BFILE** as a **BFILE** parameter. The .NET Data Provider for Oracle does not automatically construct one for you if you attempt to bind a non-**BFILE** value, such as **byte[]** or <xref:System.Data.OracleClient.OracleBinary>.|  
|**BLOB**||**Blob**|Oracle only allows binding a **BLOB** as a **BLOB** parameter. The .NET Data Provider for Oracle does not automatically construct one for you if you attempt to bind a non-**BLOB** value, such as **byte[]** or <xref:System.Data.OracleClient.OracleBinary>.|  
|**CHAR**|**AnsiStringFixedLength**|**Char**||  
|**CLOB**||**Clob**|Oracle only allows binding a **CLOB** as a **CLOB** parameter. The .NET Data Provider for Oracle does not automatically construct one for you if you attempt to bind a non-**CLOB** value, such as **System.String** or <xref:System.Data.OracleClient.OracleString>.|  
|**DATE**|**DateTime**|**DateTime**||  
|**FLOAT**|**Single, Double, Decimal**|**Float, Double, Number**|<xref:System.Data.OracleClient.OracleParameter.Size%2A> determines the **System.Data.DBType** and <xref:System.Data.OracleClient.OracleType>.|  
|**INTEGER**|**SByte, Int16, Int32, Int64, Decimal**|**SByte, Int16, Int32, Number**|<xref:System.Data.OracleClient.OracleParameter.Size%2A> determines the **System.Data.DBType** and <xref:System.Data.OracleClient.OracleType>.|  
|**INTERVAL YEAR TO MONTH**|**Int32**|**IntervalYearToMonth**|<xref:System.Data.OracleClient.OracleType> is only available when using both Oracle 9i client and server software.|  
|**INTERVAL DAY TO SECOND**|**Object**|**IntervalDayToSecond**|<xref:System.Data.OracleClient.OracleType> is only available when using both Oracle 9i client and server software.|  
|**LONG**|**AnsiString**|**LongVarChar**||  
|**LONG RAW**|**Binary**|**LongRaw**||  
|**NCHAR**|**StringFixedLength**|**NChar**||  
|**NCLOB**||**NClob**|Oracle only allows binding a **NCLOB** as a **NCLOB** parameter. The .NET Data Provider for Oracle does not automatically construct one for you if you attempt to bind a non-**NCLOB** value, such as **System.String** or <xref:System.Data.OracleClient.OracleString>.|  
|**NUMBER**|**VarNumeric**|**Number**||  
|**NVARCHAR2**|**String**|**NVarChar**||  
|**RAW**|**Binary**|**Raw**||  
|**REF CURSOR**||**Cursor**|For more information, see [Oracle REF CURSORs](../../../../docs/framework/data/adonet/oracle-ref-cursors.md).|  
|**ROWID**|**AnsiString**|**Rowid**||  
|**TIMESTAMP**|**DateTime**|**Timestamp**|<xref:System.Data.OracleClient.OracleType> is only available when using both Oracle 9i client and server software.|  
|**TIMESTAMP WITH LOCAL TIME ZONE**|**DateTime**|**TimestampLocal**|<xref:System.Data.OracleClient.OracleType> is only available when using both Oracle 9i client and server software.|  
|**TIMESTAMP WITH TIME ZONE**|**DateTime**|**TimestampWithTz**|<xref:System.Data.OracleClient.OracleType> is only available when using both Oracle 9i client and server software.|  
|**UNSIGNED INTEGER**|**Byte, UInt16, UInt32, UInt64, Decimal**|**Byte, UInt16, Uint32, Number**|<xref:System.Data.OracleClient.OracleParameter.Size%2A> determines the **System.Data.DBType** and <xref:System.Data.OracleClient.OracleType>.|  
|**VARCHAR2**|**AnsiString**|**VarChar**||  
  
 The **InputOutput**, **Output**, and **ReturnValue** **ParameterDirection** values used by the <xref:System.Data.OracleClient.OracleParameter.Value%2A> property of the <xref:System.Data.OracleClient.OracleParameter> object are .NET Framework data types, unless the input value is an Oracle data type (for example, <xref:System.Data.OracleClient.OracleNumber> or <xref:System.Data.OracleClient.OracleString>). This does not apply to **REF CURSOR**, **BFILE**, or **LOB** data types.  
  
## See Also  
 [Oracle and ADO.NET](../../../../docs/framework/data/adonet/oracle-and-adonet.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

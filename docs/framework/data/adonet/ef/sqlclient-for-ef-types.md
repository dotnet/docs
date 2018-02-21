---
title: "SqlClient for Entity FrameworkTypes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f2a95ead-c845-4e97-9fb3-04b444f7ed81
caps.latest.revision: 9
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SqlClient for Entity FrameworkTypes
The .NET Framework Data Provider for SQL Server (SqlClient) provider manifest file includes the list of the provider primitive types, facets for each type, the mappings between the conceptual and storage model primitive types, and the promotion and conversion rules between the conceptual and storage model primitive types.  
  
 The following table describes types for SQL Server 2008, [!INCLUDE[ssVersion2005](../../../../../includes/ssversion2005-md.md)], and [!INCLUDE[ssVersion2000](../../../../../includes/ssversion2000-md.md)] databases and how these types map to conceptual model types. Some new types were introduced in later versions of SQL Server are not supported in the older versions of SQL Server. These types are noted in the table below.  
  
|Provider type<br /><br /> name|Provider type<br /><br /> attributes|`EDMSimpleType`<br /><br /> name|Facets|  
|----------------------------|----------------------------------|------------------------------|------------|  
|`bit`|n/a|`Edm.Boolean`|n/a|  
|`tinyint`|n/a|`Edm.Byte`|n/a|  
|`smallint`|n/a|`Edm.Int16`|n/a|  
|`int`|n/a|`Edm.Int32`|n/a|  
|`bigint`|n/a|`Edm.Int64`|n/a|  
|`float`|n/a|`Edm.Double`|n/a|  
|`real`|n/a|`Edm.Double`|n/a|  
|`decimal`|n/a|`Edm.Decimal`|Precision:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 38<br /><br /> - Default: 18<br /><br /> - Constant: False<br /><br /> Scale:<br /><br /> - Minimum: 0<br /><br /> - Maximum: 38<br /><br /> - Default: 0<br /><br /> - Constant: False|  
|`numeric`|n/a|`Edm.Decimal`|Precision:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 38<br /><br /> - Default: 18<br /><br /> - Constant: False<br /><br /> Scale:<br /><br /> - Minimum: 0<br /><br /> - Maximum: 38<br /><br /> - Default: 0<br /><br /> - Constant: False|  
|`smallmoney`|n/a|`Edm.Decimal`|Precision:<br /><br /> - Default: 10<br /><br /> - Constant: True<br /><br /> Scale:<br /><br /> - Default: 4<br /><br /> - Constant: True|  
|`money`|n/a|`Edm.Decimal`|Precision:<br /><br /> - Default: 19<br /><br /> - Constant: True<br /><br /> Scale:<br /><br /> - Default: 4<br /><br /> - Constant: True|  
|`binary`|n/a|`Edm.Binary`|MaxLength:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 8000<br /><br /> - Default: 8000<br /><br /> - Constant: False<br /><br /> FixedLength:<br /><br /> - Default: True<br /><br /> - Constant: True|  
|`varbinary`|n/a|`Edm.Binary`|MaxLength:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 8000<br /><br /> - Default: 8000<br /><br /> - Constant: False<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`varbinary(max)`<br /><br /> Note: This type is not supported in [!INCLUDE[ssVersion2000](../../../../../includes/ssversion2000-md.md)].|n/a|`Edm.Binary`|MaxLength:<br /><br /> - Default: 214748364780<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`image`|n/a|`Edm.Binary`|MaxLength:<br /><br /> - Default: 2147483647<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`timestamp`|n/a|`Edm.Binary`|MaxLength:<br /><br /> - Default: 8<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: True<br /><br /> - Constant: True|  
|`rowversion`|n/a|`Edm.Binary`|MaxLength:<br /><br /> - Default: 8<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: True<br /><br /> - Constant: True|  
|`smalldatetime`|n/a|`Edm.DateTime`|Precision:<br /><br /> - Default: 0<br /><br /> - Constant: True|  
|`datetime`|n/a|`Edm.DateTime`|Precision:<br /><br /> - Default: 3<br /><br /> - Constant: True|  
|`date`<br /><br /> Note: This type is not supported in SQL Server 2005 and SQL Server 2000.|n/a|`Edm.DateTime`|Precision:<br /><br /> - Default: 0<br /><br /> - Constant: False|  
|`time`<br /><br /> Note: This type is not supported in SQL Server 2005 and SQL Server 2000.|n/a|`Edm.Time`|Precision:<br /><br /> - Default: 7<br /><br /> - Constant: False|  
|`datetime2`<br /><br /> Note: This type is not supported in SQL Server 2005 and SQL Server 2000.|n/a|`Edm.DateTime`|Precision:<br /><br /> - Default: 7<br /><br /> - Constant: False|  
|`datetimeoffset`<br /><br /> Note: This type is not supported in SQL Server 2005 and SQL Server 2000.|n/a|`Edm.DateTimeOffset`|Precision:<br /><br /> - Default: 7<br /><br /> - Constant: False|  
|`nvarchar`<br /><br /> Note: This type is not supported in [!INCLUDE[ssVersion2000](../../../../../includes/ssversion2000-md.md)].|n/a|`Edm.String`|MaxLength:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 4000<br /><br /> - Default: 4000<br /><br /> - Constant: False<br /><br /> Unicode:<br /><br /> - Default: True<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`varchar`<br /><br /> Note: This type is not supported in [!INCLUDE[ssVersion2000](../../../../../includes/ssversion2000-md.md)].|n/a|`Edm.String`|MaxLength:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 8000<br /><br /> - Default: 8000<br /><br /> - Constant: False<br /><br /> Unicode:<br /><br /> - Default: False<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`char`|n/a|`Edm.String`|MaxLength:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 8000<br /><br /> - Default: 8000<br /><br /> - Constant: False<br /><br /> Unicode:<br /><br /> - Default: False<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: True<br /><br /> - Constant: True|  
|`nchar`|n/a|`Edm.String`|MaxLength:<br /><br /> - Minimum: 1<br /><br /> - Maximum: 4000<br /><br /> - Default: 4000<br /><br /> - Constant: False<br /><br /> Unicode:<br /><br /> - Default: True<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: True<br /><br /> - Constant: True|  
|`varchar`(`max`)|n/a|`Edm.String`|MaxLength:<br /><br /> - Default: 2147483647<br /><br /> - Constant: True<br /><br /> Unicode:<br /><br /> - Default: False<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`nvarchar`(`max`)|n/a|`Edm.String`|MaxLength:<br /><br /> - Default: 1073741823<br /><br /> - Constant: True<br /><br /> Unicode:<br /><br /> - Default: True<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`ntext`|Equal comparable: False<br /><br /> Order comparable: False|`Edm.String`|MaxLength:<br /><br /> - Default: 1073741823<br /><br /> - Constant: True<br /><br /> Unicode:<br /><br /> - Default: False<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`text`|Equal comparable: False<br /><br /> Order comparable: False|`Edm.String`|MaxLength:<br /><br /> - Default: 2147483647<br /><br /> - Constant: True<br /><br /> Unicode:<br /><br /> - Default: False<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
|`Unique`<br /><br /> `identifier`|Equal comparable: True<br /><br /> Order comparable: True|`Edm.Guid`|n/a|  
|`xml`|Equal comparable: False<br /><br /> Order comparable: False|`Edm.String`|MaxLength:<br /><br /> - Default: 1073741823<br /><br /> - Constant: True<br /><br /> Unicode:<br /><br /> - Default: True<br /><br /> - Constant: True<br /><br /> FixedLength:<br /><br /> - Default: False<br /><br /> - Constant: True|  
  
## See Also  
 [CSDL, SSDL, and MSL Specifications](../../../../../docs/framework/data/adonet/ef/language-reference/csdl-ssdl-and-msl-specifications.md)

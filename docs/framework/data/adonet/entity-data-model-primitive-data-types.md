---
title: "Entity Data Model: Primitive Data Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7635168e-0566-4fdd-8391-7941b0d9f787
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Entity Data Model: Primitive Data Types
The Entity Data Model (EDM) supports a set of abstract primitive data types (such as String, Boolean, Int32, and so on) that are used to define [properties](../../../../docs/framework/data/adonet/property.md) in a conceptual model. These primitive data types are proxies for actual primitive data types that are supported in the storage or hosting environment, such as a SQL Server database or the common language runtime (CLR). The EDM does not define the semantics of operations or conversions over primitive data types; these semantics are defined by the storage or hosting environment. Typically, primitive data types in the EDM are mapped to corresponding primitive data types in the storage or hosting environment. For information about how the Entity Framework maps primitive types in the EDM to SQL Server data types, see [SqlClient for Entity FrameworkTypes](../../../../docs/framework/data/adonet/ef/sqlclient-for-ef-types.md).  
  
> [!NOTE]
>  The EDM does not support collections of primitive data types.  
  
 For information about structured data types in the EDM, see [entity type](../../../../docs/framework/data/adonet/entity-type.md) and [complex type](../../../../docs/framework/data/adonet/complex-type.md).  
  
## Primitive Data Types Supported in the Entity Data Model  
 The table below lists the primitive data types supported by the EDM. The table also lists the [facets](../../../../docs/framework/data/adonet/facet.md) that can be applied to each primitive data type.  
  
|Primitive Data Type|Description|Applicable Facets|  
|-------------------------|-----------------|-----------------------|  
|Binary|Contains binary data.|MaxLength, FixedLength, Nullable, Default|  
|Boolean|Contains the value `true` or `false`.|Nullable, Default|  
|Byte|Contains an unsigned 8-bit integer value.|Precision, Nullable, Default|  
|DateTime|Represents a date and time.|Precision, Nullable, Default|  
|DateTimeOffset|Contains a date and time as an offset in minutes from GMT.|Precision, Nullable, Default|  
|Decimal|Contains a numeric value with fixed precision and scale.|Precision, Nullable, Default|  
|Double|Contains a floating point number with 15 digit precision.|Precision, Nullable, Default|  
|Float|Contains a floating point number with seven digit precision.|Precision, Nullable, Default|  
|Guid|Contains a 16-byte unique identifier.|Precision, Nullable, Default|  
|Int16|Contains a signed 16-bit integer value.|Precision, Nullable, Default|  
|Int32|Contains a signed 32-bit integer value.|Precision, Nullable, Default|  
|Int64|Contains a signed 64-bit integer value.|Precision, Nullable, Default|  
|SByte|Contains a signed 8-bit integer value.|Precision, Nullable, Default|  
|String|Contains character data.|Unicode, FixedLength, MaxLength, Collation, Precision, Nullable, Default|  
|Time|Contains a time of day.|Precision, Nullable, Default|  
  
## See Also  
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)

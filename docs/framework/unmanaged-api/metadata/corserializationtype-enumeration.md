---
title: "CorSerializationType Enumeration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CorSerializationType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorSerializationType"
helpviewer_keywords: 
  - "CorSerializationType enumeration [.NET Framework metadata]"
ms.assetid: 6b1fcd11-c7fb-4be2-8910-abc862d4caf4
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorSerializationType Enumeration
Specifies how an object is serialized by the common language runtime.  
  
## Syntax  
  
```  
typedef enum CorSerializationType {  
  
    SERIALIZATION_TYPE_UNDEFINED     = 0,  
    SERIALIZATION_TYPE_BOOLEAN       = ELEMENT_TYPE_BOOLEAN,  
    SERIALIZATION_TYPE_CHAR          = ELEMENT_TYPE_CHAR,  
    SERIALIZATION_TYPE_I1            = ELEMENT_TYPE_I1,  
    SERIALIZATION_TYPE_U1            = ELEMENT_TYPE_U1,  
    SERIALIZATION_TYPE_I2            = ELEMENT_TYPE_I2,  
    SERIALIZATION_TYPE_U2            = ELEMENT_TYPE_U2,  
    SERIALIZATION_TYPE_I4            = ELEMENT_TYPE_I4,  
    SERIALIZATION_TYPE_U4            = ELEMENT_TYPE_U4,  
    SERIALIZATION_TYPE_I8            = ELEMENT_TYPE_I8,  
    SERIALIZATION_TYPE_U8            = ELEMENT_TYPE_U8,  
    SERIALIZATION_TYPE_R4            = ELEMENT_TYPE_R4,  
    SERIALIZATION_TYPE_R8            = ELEMENT_TYPE_R8,  
    SERIALIZATION_TYPE_STRING        = ELEMENT_TYPE_STRING,  
    SERIALIZATION_TYPE_SZARRAY       = ELEMENT_TYPE_SZARRAY,  
    SERIALIZATION_TYPE_TYPE          = 0x50,  
    SERIALIZATION_TYPE_TAGGED_OBJECT = 0x51,  
    SERIALIZATION_TYPE_FIELD         = 0x53,  
    SERIALIZATION_TYPE_PROPERTY      = 0x54,  
    SERIALIZATION_TYPE_ENUM          = 0x55  
  
} CorSerializationType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`SERIALIZATION_TYPE_UNDEFINED`|Serialization of the object is undefined.|  
|`SERIALIZATION_TYPE_BOOLEAN`|Object is serialized as a Boolean type|  
|`SERIALIZATION_TYPE_CHAR`|Object is serialized as a character type.|  
|`SERIALIZATION_TYPE_I1`|Object is serialized as a signed 1-byte integer.|  
|`SERIALIZATION_TYPE_U1`|Object is serialized as an unsigned 1-byte integer.|  
|`SERIALIZATION_TYPE_I2`|Object is serialized as a signed 2-byte integer.|  
|`SERIALIZATION_TYPE_U2`|Object is serialized as an unsigned 2-byte integer.|  
|`SERIALIZATION_TYPE_I4`|Object is serialized as a signed 4-byte integer.|  
|`SERIALIZATION_TYPE_U4`|Object is serialized as an unsigned 4-byte integer.|  
|`SERIALIZATION_TYPE_I8`|Object is serialized as a signed 8-byte integer.|  
|`SERIALIZATION_TYPE_U8`|Object is serialized as an unsigned 8-byte integer.|  
|`SERIALIZATION_TYPE_R4`|Object is serialized as a 4-byte floating point.|  
|`SERIALIZATION_TYPE_R8`|Object is serialized as an 8-byte floating point.|  
|`SERIALIZATION_TYPE_STRING`|Object is serialized as a System.String type.|  
|`SERIALIZATION_TYPE_SZARRAY`|Object is serialized as a single-dimensional, zero lower-bound array.|  
|`SERIALIZATION_TYPE_TYPE`|Object is serialized as a generic type.|  
|`SERIALIZATION_TYPE_TAGGED_OBJECT`|Object is serialized as a tagged object.|  
|`SERIALIZATION_TYPE_FIELD`|Object is serialized as a field.|  
|`SERIALIZATION_TYPE_PROPERTY`|Object is serialized as a property.|  
|`SERIALIZATION_TYPE_ENUM`|Object is serialized as an enumeration.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)

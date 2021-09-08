---
description: "Learn more about: COR_PRF_EVENTPIPE_PARAM_TYPE Enumeration"
title: "COR_PRF_EVENTPIPE_PARAM_TYPE Enumeration"
ms.date: "03/19/2021"
api_name: 
  - "COR_PRF_EVENTPIPE_PARAM_TYPE"
api_location: 
  - "coreclr.dll"
  - "corprof.idl"
api_type: 
  - "COM"
---
# COR_PRF_EVENTPIPE_PARAM_TYPE Enumeration

Describes the type of a parameter for an EventPipe event.
  
## Syntax  
  
```cpp  
typedef enum
{
    COR_PRF_EVENTPIPE_OBJECT = 1,
    COR_PRF_EVENTPIPE_BOOLEAN = 3,
    COR_PRF_EVENTPIPE_CHAR = 4,
    COR_PRF_EVENTPIPE_SBYTE = 5,
    COR_PRF_EVENTPIPE_BYTE = 6,
    COR_PRF_EVENTPIPE_INT16 = 7,
    COR_PRF_EVENTPIPE_UINT16 = 8,
    COR_PRF_EVENTPIPE_INT32 = 9,
    COR_PRF_EVENTPIPE_UINT32 = 10,
    COR_PRF_EVENTPIPE_INT64 = 11,
    COR_PRF_EVENTPIPE_UINT64 = 12,
    COR_PRF_EVENTPIPE_SINGLE = 13,
    COR_PRF_EVENTPIPE_DOUBLE = 14,
    COR_PRF_EVENTPIPE_DECIMAL = 15,
    COR_PRF_EVENTPIPE_DATETIME = 16,
    COR_PRF_EVENTPIPE_GUID = 17,
    COR_PRF_EVENTPIPE_STRING = 18,
    COR_PRF_EVENTPIPE_ARRAY = 19,
} COR_PRF_EVENTPIPE_PARAM_TYPE;
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_EVENTPIPE_OBJECT`|The parameter type is a self describing object.|
|`COR_PRF_EVENTPIPE_BOOLEAN`|The parameter type is a boolean.|
|`COR_PRF_EVENTPIPE_CHAR`|The parameter type is a 16 bit wide character.|
|`COR_PRF_EVENTPIPE_SBYTE`|The parameter type is a signed 8 bit integer.|
|`COR_PRF_EVENTPIPE_BYTE`|The parameter type is an unsigned 8 bit integer.|
|`COR_PRF_EVENTPIPE_INT16`|The parameter type is a signed 16 bit integer.|
|`COR_PRF_EVENTPIPE_UINT16`|The parameter type is an unsigned 16 bit integer.|
|`COR_PRF_EVENTPIPE_INT32`|The parameter type is a signed 32 bit integer.|
|`COR_PRF_EVENTPIPE_UINT32`|The parameter type is an unsigned 32 bit integer.|
|`COR_PRF_EVENTPIPE_INT64`|The parameter type is a signed 64 bit integer.|
|`COR_PRF_EVENTPIPE_UINT64`|The parameter type is an unsigned 64 bit integer.|
|`COR_PRF_EVENTPIPE_SINGLE`|The parameter type is a 32 bit floating point number.|
|`COR_PRF_EVENTPIPE_DOUBLE`|The parameter type is a 64 bit floating point number.|
|`COR_PRF_EVENTPIPE_DECIMAL`|The parameter type is a 128 bit floating point number.|
|`COR_PRF_EVENTPIPE_DATETIME`|The parameter type is a serialized DataTime structure.|
|`COR_PRF_EVENTPIPE_GUID`|The parameter type is a GUID.|
|`COR_PRF_EVENTPIPE_STRING`|The parameter type is a 16 bit null terminated wide character string.|
|`COR_PRF_EVENTPIPE_ARRAY`|The parameter type is an array of one of the preceding types.|
  
## Remarks  

 The `COR_PRF_EVENTPIPE_PARAM_TYPE` enumeration is used by the [COR_PRF_EVENTPIPE_PARAM_DESC](cor-prf-eventpipe-param-desc-structure.md) structure to indicate the type of the parameter.
  
## Requirements  

**Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** [!INCLUDE[net_core](../../../../includes/net-core-50-md.md)]
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)

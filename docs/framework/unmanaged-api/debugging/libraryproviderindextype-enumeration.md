---
description: "Learn more about: LIBRARY_PROVIDER_INDEX_TYPE Enumeration"
title: "LIBRARY_PROVIDER_INDEX_TYPE Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "LIBRARY_PROVIDER_INDEX_TYPE"
api_location: 
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
api_type: 
  - "COM"
f1_keywords: 
  - "LIBRARY_PROVIDER_INDEX_TYPE"
helpviewer_keywords: 
  - "LIBRARY_PROVIDER_INDEX_TYPE enumeration [.NET Core debugging]"
ms.assetid: a6ac2531-ddfe-46fd-88fe-8b1eabe0b255
topic_type: 
  - "apiref"
---
# LIBRARY_PROVIDER_INDEX_TYPE Enumeration

The type of index information passed to the library provider is either the identity of the requested module or of the runtime (coreclr) module.
  
## Syntax  
  
```cpp  
typedef enum 
{  
    Unknown = 0,
    Identity = 1,
    Runtime = 2,
}  LIBRARY_PROVIDER_INDEX_TYPE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`Unknown`|Invalid index type.|  
|`Identity`|The index information of the requested module.|  
|`Runtime`|The runtime module's index information.|  
  
## Remarks

The "index information" is the timestamp/file size on Windows or the build id on Linux/MacOS.
  
## Requirements  

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib
  
 **.NET Versions:** [!INCLUDE[net_core_60](../../../../includes/net-core-60-md.md)]

## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)

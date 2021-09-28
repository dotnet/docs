---
description: "Learn more about: CorDebugIlToNativeMappingTypes Enumeration"
title: "CorDebugIlToNativeMappingTypes Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugIlToNativeMappingTypes"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugIlToNativeMappingTypes"
helpviewer_keywords: 
  - "CorDebugIIToNativeMappingTypes enumeration [.NET Framework debugging]"
ms.assetid: c35e2919-42c3-4ba0-ae28-443c35f66f93
topic_type: 
  - "apiref"
---
# CorDebugIlToNativeMappingTypes Enumeration

Indicates whether a particular range of native instructions, represented by an instance of the COR_DEBUG_IL_TO_NATIVE_MAP structure, corresponds to a special code region.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugIlToNativeMappingTypes {  
    NO_MAPPING = -1,  
    PROLOG     = -2,  
    EPILOG     = -3  
} CorDebugIlToNativeMappingTypes;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`NO_MAPPING`|The range of native instructions does not correspond to any special code region.|  
|`PROLOG`|The range of native instructions corresponds to the prolog.|  
|`EPILOG`|The range of native instructions corresponds to the epilog.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [GetILToNativeMapping Method](icordebugcode-getiltonativemapping-method.md)
- [Debugging Enumerations](debugging-enumerations.md)

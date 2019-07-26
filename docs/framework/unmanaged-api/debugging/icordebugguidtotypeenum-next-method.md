---
title: "ICorDebugGuidToTypeEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugGuidToTypeEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugGuidToTypeEnum::Next"
helpviewer_keywords: 
  - "ICorDebugGuidToTypeEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugGuidToTypeEnum interface [.NET Framework debugging]"
ms.assetid: c9937666-8e18-484d-9fe0-b9ac95199530
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugGuidToTypeEnum::Next Method
Gets the specified number of [CorDebugGuidToTypeMapping](../../../../docs/framework/unmanaged-api/debugging/cordebugguidtotypemapping-structure.md) instances that map GUIDs to type information.  
  
## Syntax  
  
```cpp  
HRESULT Next(  
    [in] ULONG celt,  
    [out, size_is(celt), length_is(*pceltFetched] CorDebugGuidToTypeMapping values[  ],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  
 `celt`  
 [in] The number of GUID-to-type mapping objects to be retrieved.  
  
 `values`  
 [out] An array of pointers, each of which points to a [CorDebugGuidToTypeMapping](../../../../docs/framework/unmanaged-api/debugging/cordebugguidtotypemapping-structure.md) object that maps a Windows Runtime GUID to its corresponding ICorDebugType object.  
  
 `pceltFetched`  
 [out] A pointer to the number of [CorDebugGuidToTypeMapping](../../../../docs/framework/unmanaged-api/debugging/cordebugguidtotypemapping-structure.md) objects actually returned in `values`.  
  
## Remarks  
  
## Requirements  
 **Platforms:** Windows Runtime  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugGuidToTypeEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugguidtotypeenum-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

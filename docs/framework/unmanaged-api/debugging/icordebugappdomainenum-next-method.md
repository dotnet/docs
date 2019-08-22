---
title: "ICorDebugAppDomainEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomainEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomainEnum::Next method"
helpviewer_keywords: 
  - "ICorDebugAppDomainEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugAppDomainEnum interface [.NET Framework debugging]"
ms.assetid: b8d1def7-0ebc-4314-a3a2-fd36a75973e7
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugAppDomainEnum::Next Method
Gets the specified number of application domains from the collection, starting at the current cursor position.  
  
## Syntax  
  
```cpp  
HRESULT Next (  
    [in] ULONG celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
                           ICorDebugAppDomain *values[],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  
 `celt`  
 [in] The number of application domains to be retrieved.  
  
 `values`  
 [out] An array of pointers, each of which points to an ICorDebugAppDomain object that represents an application domain.  
  
 `pceltFetched`  
 [out] A pointer to the number of application domains actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

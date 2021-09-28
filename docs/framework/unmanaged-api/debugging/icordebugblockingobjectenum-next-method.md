---
description: "Learn more about: ICorDebugBlockingObjectEnum::Next Method"
title: "ICorDebugBlockingObjectEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugBlockingObjectEnum.Next Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBlockingObjectEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorDebugBlockingObjectEnum interface [.NET Framework debugging]"
  - "ICorDebugBlockingObjectEnum::Next method [.NET Framework debugging]"
ms.assetid: 0121753f-ebea-48d0-aeb2-ed7fda76dc60
topic_type: 
  - "apiref"
---
# ICorDebugBlockingObjectEnum::Next Method

Gets the specified number of [CorDebugBlockingObject](cordebugblockingobject-structure.md) objects from the enumeration, starting at the current position.  
  
## Syntax  
  
```cpp  
HRESULT Next([in] ULONG  celt,  
             [out, size_is(celt), length_is(*pceltFetched)]  
                           CorDebugBlockingObject values[],  
             [out] ULONG *pceltFetched;  
```  
  
## Parameters  

 `celt`  
 [in] The number of objects to retrieve.  
  
 `values`  
 [out] An array of pointers to [CorDebugBlockingObject](cordebugblockingobject-structure.md) objects.  
  
 `pceltFetched`  
 [out] A pointer to the number of objects that were retrieved.  
  
## Return Value  

 This method returns the following specific HRESULTs.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|S_FALSE|`pceltFetched` does not equal `celt`.|  
  
## Remarks  

 This method functions like a typical COM enumerator.  
  
 The input array values must be at least of size `celt`. The array will be filled with either the next `celt` values in the enumeration or with all remaining values if fewer than `celt` remain. When this method returns, `pceltFetched` will be filled with the number of values that were retrieved. If `values` contains invalid pointers or points to a buffer that is smaller than `celt`, or if `pceltFetched` is an invalid pointer, the result is undefined.  
  
> [!NOTE]
> Although the [CorDebugBlockingObject](cordebugblockingobject-structure.md) structure does not need to be released, the "ICorDebugValue" interface inside of it does need to be released.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorDebugDataTarget Interface](icordebugdatatarget-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)

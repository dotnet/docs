---
description: "Learn more about: ICorDebugProcess11::EnumerateLoaderHeapMemoryRegions Method"
title: "ICorDebugProcess11::EnumerateLoaderHeapMemoryRegions Method"
ms.date: "06/06/2022"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorDebugProcess11.EnumerateLoaderHeapMemoryRegions"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid:
topic_type: 
  - "apiref"
---
# ICorDebugProcess11::EnumerateLoaderHeapMemoryRegions Method

[Supported in .NET Framework 4.5.2 and later versions.]  
  
 Configures how the debugger handles in-memory updates to metadata within the target process.  
  
## Syntax  
  
```cpp
HRESULT EnumerateLoaderHeapMemoryRegions(
[out] ICorDebugMemoryRangeEnum** ppRanges
); 
```  
  
## Parameters  

 `ppRanges`  

## Remarks  

## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  

 **Header:** CorDebug.idl, CorDebug.h  

 **Library:** CorGuids.lib  

 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  

## See also

- [ICorDebugProcess11 Interface](icordebugprocess11-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

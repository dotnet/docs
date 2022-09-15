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

[Supported in .NET 5 and later versions.]  
  
 Enumerates ranges of native memory that are used by the .NET runtime to store internal data structures that describe .NET types and methods. The information returned is the same information that would be shown by using the SOS `eeheap-loader` command.
  
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

 **.NET Versions:** [!INCLUDE[net-core-50-plus](../../../../includes/net-core-50-md.md)]  

## See also

- [ICorDebugProcess11 Interface](icordebugprocess11-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

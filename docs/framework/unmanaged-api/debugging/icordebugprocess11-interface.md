---
description: "Learn more about: ICorDebugProcess11 Interface"
title: "ICorDebugProcess11 Interface"
ms.date: "06/06/2022"
api_name: 
  - "ICorDebugProcess11"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 71aee5f3-5e10-44fa-be69-6d8a475f2c14
topic_type: 
  - "apiref"
---
# ICorDebugProcess11 Interface

[Supported in .NET 5 and later versions.]  
  
Provides a method that enumerates ranges of native memory that are used by the .NET runtime to store internal data structures that describe .NET types and methods. The returned information is the same information that would be shown by using the SOS `eeheap -loader` command.

## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateLoaderHeapMemoryRegions Method](icordebugprocess11-enumerateloaderheapmemoryregions-method.md)|Enumerates ranges of native memory that are used by the .NET runtime to store internal data structures that describe .NET types and methods. The information returned is the same information that would be shown by using the SOS `eeheap -loader` command. |  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  

 **.NET Versions:** [!INCLUDE[net-core-50-plus](../../../../includes/net-core-50-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)

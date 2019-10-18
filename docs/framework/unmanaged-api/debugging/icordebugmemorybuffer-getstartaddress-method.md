---
title: "ICorDebugMemoryBuffer::GetStartAddress Method"
ms.date: "03/30/2017"
ms.assetid: f804d9ab-8c88-44f0-b278-5fcca7f87726
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugMemoryBuffer::GetStartAddress Method
Gets the starting address of the memory buffer.  
  
## Syntax  
  
```cpp  
HRESULT GetStartAddress(  
   [out] LPCVOID *address  
);  
```  
  
## Parameters  
 `address`  
 [out] A pointer to the starting address of the memory buffer.  
  
## Remarks  
  
> [!WARNING]
> This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMemoryBuffer Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmemorybuffer-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

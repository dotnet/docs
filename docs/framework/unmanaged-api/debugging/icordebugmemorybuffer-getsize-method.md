---
description: "Learn more about: ICorDebugMemoryBuffer::GetSize Method"
title: "ICorDebugMemoryBuffer::GetSize Method"
ms.date: "03/30/2017"
ms.assetid: 9ffd5482-268e-4680-9fd1-bfb0b7d66450
---
# ICorDebugMemoryBuffer::GetSize Method

Gets the size of the memory buffer in bytes.  
  
## Syntax  
  
```cpp  
HRESULT GetSize(  
   [out] ULONG32 *pcbBufferLength  
);  
```  
  
## Parameters  

 `pcbBufferLength`  
 [out] A pointer to the size of the memory buffer.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMemoryBuffer Interface](icordebugmemorybuffer-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

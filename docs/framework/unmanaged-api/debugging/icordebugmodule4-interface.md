---
description: "Learn more about: ICorDebugModule4 Interface"
title: "ICorDebugModule4 Interface"
ms.date: "06/06/2022"
api_name: 
  - "ICorDebugModule4"
api_location: 
  - "CorDebug.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule4"
helpviewer_keywords: 
  - "ICorDebugModule4 interface [.NET Framework debugging]"
ms.assetid:
  - "apiref"
---
# ICorDebugModule4 Interface

Provides a method that determines whether the module is loaded into memory in mapped/hydrated format.
  
## Syntax  
  
```cpp  
interface ICorDebugModule4 : IUnknown  
{  
     HRESULT IsMappedLayout(
     [out] BOOL *pIsMapped
     ); 
};  
```  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ICorDebugModule4::IsMappedLayout Method](icordebugmodule4-ismappedlayout-method.md)|Queries to see if the module is loaded into memory in mapped/hydrated format.|  
  
## Remarks  

 This interface logically extends the 'ICorDebugModule', 'ICorDebugModule2', and 'ICoreDebugModule3' interfaces.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  

 **.NET Versions:** [!INCLUDE[net-core-50-plus](../../../../includes/net-core-50-md.md)]  
  
## See also

- [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md)
- [ICorDebug Interface](icordebug-interface.md)

- [Debugging Interfaces](debugging-interfaces.md)

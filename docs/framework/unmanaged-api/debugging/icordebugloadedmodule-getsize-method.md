---
description: "Learn more about: ICorDebugLoadedModule::GetSize Method"
title: "ICorDebugLoadedModule::GetSize Method"
ms.date: "03/30/2017"
ms.assetid: aaa0e5c0-be9d-4fe1-8418-5295b9b184d6
---
# ICorDebugLoadedModule::GetSize Method

Gets the size in bytes of the loaded module.  
  
## Syntax  
  
```cpp  
HRESULT GetSize(  
   [out] ULONG32 *pcBytes  
);  
```  
  
## Parameters  

 `pcBytes`  
 [out] A pointer to the number of bytes in the loaded module.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugLoadedModule Interface](icordebugloadedmodule-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

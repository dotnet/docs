---
description: "Learn more about: ICorDebugLoadedModule::GetBaseAddress Method"
title: "ICorDebugLoadedModule::GetBaseAddress Method"
ms.date: "03/30/2017"
ms.assetid: 7c036772-d58a-47f1-a5fa-31779898ef0d
---
# ICorDebugLoadedModule::GetBaseAddress Method

Gets the base address of the loaded module.  
  
## Syntax  
  
```cpp  
HRESULT GetBaseAddress(  
   [out] CORDB_ADDRESS *pAddress  
);  
```  
  
## Parameters  

 `pAddress`  
 [out] A pointer to the base address of the loaded module.  
  
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

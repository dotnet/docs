---
title: "ICorDebugModuleDebugEvent::GetModule Method"
ms.date: "03/30/2017"
ms.assetid: b1141c35-4253-4e34-b3e4-ed406a9dea4f
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugModuleDebugEvent::GetModule Method
Gets the merged module that was just loaded or unloaded.  
  
## Syntax  
  
```cpp  
HRESULT GetModule(  
   [out]ICorDebugModule **ppModule  
);  
```  
  
## Parameters  
 `ppModule`  
 [out] A pointer to the address of an ICorDebugModule object that represents the merged module that was just loaded or unloaded.  
  
## Remarks  
 You can call the [GetEventKind](../../../../docs/framework/unmanaged-api/debugging/icordebugdebugevent-geteventkind-method.md) method to determine whether the module was loaded or unloaded.  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugModuleDebugEvent Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmoduledebugevent-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

---
title: "ICorDebugAssembly3::GetContainerAssembly Method"
ms.date: "03/30/2017"
ms.assetid: f5fddeb6-b82e-4ebb-b432-849ce8513c77
---
# ICorDebugAssembly3::GetContainerAssembly Method
Returns the container assembly of this `ICorDebugAssembly3` object.  
  
## Syntax  
  
```cpp  
HRESULT GetContainerAssembly(  
    ICorDebugAssembly **ppAssembly  
);  
```  
  
## Parameters  
 `ppAssembly`  
 A pointer to the address of an ICorDebugAssembly object that represents the container assembly, or **null** if the method call fails.  
  
## Return Value  
 `S_OK` if the method call succeeds; otherwise, `S_FALSE`, and `ppAssembly` is **null**.  
  
## Remarks  
 If this assembly has been merged with others inside a single container assembly, this method returns the container assembly. For more information and terminology, see the [ICorDebugProcess6::EnableVirtualModuleSplitting](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-enablevirtualmodulesplitting-method.md) topic.  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugAssembly3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly3-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

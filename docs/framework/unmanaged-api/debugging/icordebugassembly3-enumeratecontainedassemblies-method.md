---
title: "ICorDebugAssembly3::EnumerateContainedAssemblies Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 98f15b05-afad-4616-9e2a-1a9af31948b6
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAssembly3::EnumerateContainedAssemblies Method
Gets an enumerator for the assemblies contained in this assembly.  
  
## Syntax  
  
```  
HRESULT EnumerateContainedAssemblies(  
    ICorDebugAssemblyEnum **ppAssemblies  
);  
```  
  
#### Parameters  
 `ppAssemblies`  
 [out] A pointer to the address of an ICorDebugAssemblyEnum interface object that is the enumerator.  
  
## Return Value  
 `S_OK` if this `ICorDebugAssembly3` object is a container; otherwise, `S_FALSE`, and the enumeration is empty.  
  
## Remarks  
 Symbols are needed to enumerate the contained assemblies. If they aren't present, the method returns `S_FALSE`, and no valid enumerator is provided.  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [ICorDebugAssembly3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly3-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

---
title: "ICorDebugLoadedModule::GetSize Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: aaa0e5c0-be9d-4fe1-8418-5295b9b184d6
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugLoadedModule::GetSize Method
Gets the size in bytes of the loaded module.  
  
## Syntax  
  
```  
HRESULT GetSize(  
   [out] ULONG32 *pcBytes  
);  
```  
  
#### Parameters  
 `pcBytes`  
 [out] A pointer to the number of bytes in the loaded module.  
  
## Remarks  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [ICorDebugLoadedModule Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugloadedmodule-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

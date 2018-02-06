---
title: "ICorDebugProcess6::GetCode Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: faa538c2-60c9-4064-b996-1b4c24ebd751
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess6::GetCode Method
Gets information about the managed code at a particular code address.  
  
## Syntax  
  
```  
HRESULT GetCode(  
    [in] CORDB_ADDRESS codeAddress,   
    [out] ICorDebugCode **ppCode);  
```  
  
#### Parameters  
 `codeAddress`  
 [in] A [CORDB_ADDRESS](../../../../docs/framework/unmanaged-api/common-data-types-unmanaged-api-reference.md) value that specifies the starting address of the managed code segment.  
  
 `ppCode`  
 [out] A pointer to the address of an "ICorDebugCode" object that represents a segment of managed code.  
  
## Remarks  
  
> [!NOTE]
>  This method is available with .NET Native only.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [ICorDebugProcess6 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

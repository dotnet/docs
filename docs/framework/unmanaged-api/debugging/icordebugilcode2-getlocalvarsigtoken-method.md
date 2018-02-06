---
title: "ICorDebugILCode2::GetLocalVarSigToken Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorDebugILCode2.GetLocalVarSigToken"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 17665b77-1342-4115-94fd-9f45b0ecfb0f
topic_type: 
  - "apiref"
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILCode2::GetLocalVarSigToken Method
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Gets the metadata token for the local variable signature for the function that is represented by this instance.  
  
## Syntax  
  
```cpp
HRESULT GetLocalVarSigToken(  
   [out] mdSignature *pmdSig  
);  
```  
  
#### Parameters  
 `pmdSig`  
 [out] A pointer to the `mdSignature` token for the local variable signature for this function, or `mdSignatureNil` if there is no signature (that is, if the function doesn't have any local variables).  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [ICorDebugILCode2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode2-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)

---
title: "ICorDebugNativeFrame::GetLocalMemoryValue Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugNativeFrame.GetLocalMemoryValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::GetLocalMemoryValue"
helpviewer_keywords: 
  - "GetLocalMemoryValue method [.NET Framework debugging]"
  - "ICorDebugNativeFrame::GetLocalMemoryValue method [.NET Framework debugging]"
ms.assetid: b600b3a2-9908-42d8-8093-ab6f39e9a2c9
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugNativeFrame::GetLocalMemoryValue Method
Gets the value of an argument or local variable that is stored in the specified memory location for this native frame.  
  
## Syntax  
  
```  
HRESULT GetLocalMemoryValue (  
    [in]  CORDB_ADDRESS      address,  
    [in]  ULONG              cbSigBlob,  
    [in]  PCCOR_SIGNATURE    pvSigBlob,  
    [out] ICorDebugValue     **ppValue  
);  
```  
  
#### Parameters  
 `address`  
 [in] A `CORDB_ADDRESS` value that specifies the memory location containing the value.  
  
 `cbSigBlob`  
 [in] An integer that specifies the size of the binary metadata signature which is referenced by the `pvSigBlob` parameter.  
  
 `pvSigBlob`  
 [in] A `PCCOR_SIGNATURE` value that points to the binary metadata signature of the value's type.  
  
 `ppValue`  
 [out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified memory location.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 

---
title: "ICorDebugNativeFrame::GetLocalMemoryRegisterValue Method"
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
  - "ICorDebugNativeFrame.GetLocalMemoryRegisterValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::GetLocalMemoryRegisterValue"
helpviewer_keywords: 
  - "ICorDebugNativeFrame::GetLocalMemoryRegisterValue method [.NET Framework debugging]"
  - "GetLocalMemoryRegisterValue method"
ms.assetid: 33a19f6e-1029-4d53-af64-19591c6e58ee
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugNativeFrame::GetLocalMemoryRegisterValue Method
Gets the value of an argument or local variable, of which the low word and high word are stored in the specified register and memory location, respectively, for this native frame.  
  
## Syntax  
  
```  
HRESULT GetLocalMemoryRegisterValue (  
    [in] CORDB_ADDRESS      highWordAddress,  
    [in] CorDebugRegister   lowWordRegister,  
    [in] ULONG              cbSigBlob,  
    [in] PCCOR_SIGNATURE    pvSigBlob,  
    [out] ICorDebugValue    **ppValue  
);  
```  
  
#### Parameters  
 `highWordAddress`  
 [in] A `CORDB_ADDRESS` value that specifies the memory location containing the high word of the value.  
  
 `lowWordRegister`  
 [in] A value of the "CorDebugRegister" enumeration that specifies the register containing the low word of the value.  
  
 `cbSigBlob`  
 [in] An integer that specifies the size of the binary metadata signature which is referenced by the `pvSigBlob` parameter.  
  
 `pvSigBlob`  
 [in] A `PCCOR_SIGNATURE` value that points to the binary metadata signature of the value's type.  
  
 `ppValue`  
 [out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 

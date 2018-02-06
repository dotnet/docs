---
title: "ICorDebugNativeFrame::GetLocalRegisterValue Method"
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
  - "ICorDebugNativeFrame.GetLocalRegisterValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::GetLocalRegisterValue"
helpviewer_keywords: 
  - "GetLocalRegisterValue method [.NET Framework debugging]"
  - "ICorDebugNativeFrame::GetLocalRegisterValue method [.NET Framework debugging]"
ms.assetid: 5ccb74f3-f891-430c-b70a-e370624edde2
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugNativeFrame::GetLocalRegisterValue Method
Gets the value of an argument or local variable that is stored in the specified register for this native frame.  
  
## Syntax  
  
```  
HRESULT GetLocalRegisterValue (  
    [in]  CorDebugRegister   reg,  
    [in]  ULONG              cbSigBlob,  
    [in]  PCCOR_SIGNATURE    pvSigBlob,  
    [out] ICorDebugValue     **ppValue  
);  
```  
  
#### Parameters  
 `reg`  
 [in] A value of the "CorDebugRegister" enumeration that specifies the register containing the value.  
  
 `cbSigBlob`  
 [in] An integer that specifies the size of the binary metadata signature which is referenced by the `pvSigBlob` parameter.  
  
 `pvSigBlob`  
 [in] A `PCCOR_SIGNATURE` value that points to the binary metadata signature of the value's type.  
  
 `ppValue`  
 [out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register.  
  
## Remarks  
 The `GetLocalRegisterValue` method can be used either in a native frame or a just-in-time (JIT)-compiled frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 

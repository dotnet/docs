---
title: "ICorDebugNativeFrame::GetLocalDoubleRegisterValue Method"
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
  - "ICorDebugNativeFrame.GetLocalDoubleRegisterValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::GetLocalDoubleRegisterValue"
helpviewer_keywords: 
  - "ICorDebugNativeFrame::GetLocalDoubleRegisterValue method [.NET Framework debugging]"
  - "GetLocalDoubleRegisterValue method [.NET Framework debugging]"
ms.assetid: 1f838215-ac8a-434f-8ce6-03021d3098d9
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugNativeFrame::GetLocalDoubleRegisterValue Method
Gets the value of an argument or local variable that is stored in the two specified registers for this native frame.  
  
## Syntax  
  
```  
HRESULT GetLocalDoubleRegisterValue (  
    [in] CorDebugRegister   highWordReg,  
    [in] CorDebugRegister   lowWordReg,  
    [in] ULONG              cbSigBlob,  
    [in] PCCOR_SIGNATURE    pvSigBlob,  
    [out] ICorDebugValue    **ppValue  
);  
```  
  
#### Parameters  
 `highWordReg`  
 [in] A value of the "CorDebugRegister" enumeration that specifies the register containing the high word of the value.  
  
 `lowWordReg`  
 [in] A value of the `CorDebugRegister` enumeration that specifies the register containing the low word of the value.  
  
 `cbSigBlob`  
 [in] An integer that specifies the size of the binary metadata signature which is referenced by the `pvSigBlob` parameter.  
  
 `pvSigBlob`  
 [in] A `PCCOR_SIGNATURE` value that points to the binary metadata signature of the value's type.  
  
 `ppValue`  
 [out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified registers.  
  
## Remarks  
 The `GetLocalDoubleRegisterValue` method can be used either in a native frame or a just-in-time (JIT)-compiled frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 

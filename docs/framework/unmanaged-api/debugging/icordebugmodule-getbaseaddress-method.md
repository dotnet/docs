---
description: "Learn more about: ICorDebugModule::GetBaseAddress Method"
title: "ICorDebugModule::GetBaseAddress Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule.GetBaseAddress"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::GetBaseAddress"
helpviewer_keywords: 
  - "GetBaseAddress method [.NET Framework debugging]"
  - "ICorDebugModule::GetBaseAddress method [.NET Framework debugging]"
ms.assetid: 26a82815-1982-4eb7-92d1-5c3d318d5be4
topic_type: 
  - "apiref"
---
# ICorDebugModule::GetBaseAddress Method

Gets the base address of the module.  
  
## Syntax  
  
```cpp  
HRESULT GetBaseAddress(  
    [out] CORDB_ADDRESS *pAddress  
);  
```  
  
## Parameters  

 `pAddress`  
 [out] A `CORDB_ADDRESS` that specifies the base address of the module.  
  
## Remarks  

 If the module is a native image (that is, if the module was produced by the native image generator, NGen.exe), its base address will be zero.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

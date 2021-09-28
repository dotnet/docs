---
description: "Learn more about: ICorDebugAppDomain::GetModuleFromMetaDataInterface Method"
title: "ICorDebugAppDomain::GetModuleFromMetaDataInterface Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain.GetModuleFromMetaDataInterface"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::GetModuleFromMetaDataInterface"
helpviewer_keywords: 
  - "ICorDebugAppDomain::GetModuleFromMetaDatainterface method [.NET Framework debugging]"
  - "GetModuleFromMetaDatainterface method [.NET Framework debugging]"
ms.assetid: f35225b3-5dda-4d5a-913d-b3373e9ab81e
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain::GetModuleFromMetaDataInterface Method

Gets the module that corresponds to the given metadata interface.  
  
## Syntax  
  
```cpp  
HRESULT GetModuleFromMetaDataInterface (  
    [in] IUnknown           *pIMetaData,  
    [out] ICorDebugModule  **ppModule  
);  
```  
  
## Parameters  

 `pIMetaData`  
 [in] A pointer to an object that is one of the [Metadata interfaces](../metadata/metadata-interfaces.md).  
  
 `ppModule`  
 [out] A pointer to the address of an ICorDebugModule object that represents the module corresponding to the given metadata interface.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

---
title: "CreateAssemblyNameObject Function"
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
  - "CreateAssemblyNameObject"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateAssemblyNameObject"
helpviewer_keywords: 
  - "CreateAssemblyNameObject function [.NET Framework fusion]"
ms.assetid: 55c8b41e-fbe4-4ae0-aa29-68fbb2311691
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateAssemblyNameObject Function
Gets an interface pointer to an [IAssemblyName](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md) instance that represents the unique identity of the assembly with the specified name.  
  
## Syntax  
  
```  
HRESULT CreateAssemblyNameObject (  
    [out] LPASSEMBLYNAME  *ppAssemblyNameObj,  
    [in]  LPCWSTR         szAssemblyName,  
    [in]  DWORD           dwFlags,  
    [in]  LPVOID          pvReserved  
 );  
```  
  
#### Parameters  
 `ppAssemblyNameObj`  
 [out] The returned `IAssemblyName`.  
  
 `szAssemblyName`  
 [in] The name of the assembly for which to create the new `IAssemblyName` instance.  
  
 `dwFlags`  
 [in] Flags to pass to the object constructor.  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)

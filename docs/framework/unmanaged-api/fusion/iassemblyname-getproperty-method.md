---
title: "IAssemblyName::GetProperty Method"
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
  - "IAssemblyName.GetProperty"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName::GetProperty"
helpviewer_keywords: 
  - "IAssemblyName::GetProperty method [.NET Framework fusion]"
  - "GetProperty method [.NET Framework fusion]"
ms.assetid: e59fda62-77d5-4e37-89cb-ce7ae4627975
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAssemblyName::GetProperty Method
Gets a pointer to the property referenced by the specified property identifier.  
  
## Syntax  
  
```  
HRESULT GetProperty (  
    [in]      DWORD    PropertyId,  
    [out]     LPVOID   pvProperty,  
    [in, out] LPDWORD  pcbProperty  
);  
```  
  
#### Parameters  
 `PropertyId`  
 [in] The unique identifier for the requested property.  
  
 `pvProperty`  
 [out] The returned property data.  
  
 `pcbProperty`  
 [in, out] The size, in bytes, of `pvProperty`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)

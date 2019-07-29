---
title: "IAssemblyEnum::GetNextAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyEnum.GetNextAssembly"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyEnum::GetNextAssembly"
helpviewer_keywords: 
  - "GetNextAssembly method [.NET Framework fusion]"
  - "IAssemblyEnum::GetNextAssembly method [.NET Framework fusion]"
ms.assetid: 5d7a4ca2-5f46-4ef1-a9a2-257884e9dc11
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IAssemblyEnum::GetNextAssembly Method
Gets a pointer to the next [IAssemblyName](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md) contained in this [IAssemblyEnum](../../../../docs/framework/unmanaged-api/fusion/iassemblyenum-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetNextAssembly (  
    [in]  LPVOID          pvReserved,  
    [out] IAssemblyName   **ppName,  
    [in]  DWORD           dwFlags  
);  
```  
  
## Parameters  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
 `ppName`  
 [out] The returned `IAssemblyName` pointer.  
  
 `dwFlags`  
 [in] Reserved for future extensibility. `dwFlags` must be 0 (zero).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)
- [IAssemblyEnum Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyenum-interface.md)

---
description: "Learn more about: IAssemblyName::GetVersion Method"
title: "IAssemblyName::GetVersion Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyName.GetVersion"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName::GetVersion"
helpviewer_keywords: 
  - "IAssemblyName::GetVersion method [.NET Framework fusion]"
  - "GetVersion method, IAssemblyName interface [.NET Framework fusion]"
ms.assetid: 42230928-2c33-41fd-9519-d96efef6c7af
topic_type: 
  - "apiref"
---
# IAssemblyName::GetVersion Method

Gets the version information for the assembly referenced by this [IAssemblyName](iassemblyname-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetVersion (  
    [out] LPDWORD pdwVersionHi,  
    [out] LPDWORD pdwVersionLow  
);  
```  
  
## Parameters  

 `pdwVersionHi`  
 [out] The high 32 bits of the version.  
  
 `pdwVersionLow`  
 [out] The low 32 bits of the version.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](iassemblyname-interface.md)

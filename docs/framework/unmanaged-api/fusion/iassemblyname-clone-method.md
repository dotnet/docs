---
title: "IAssemblyName::Clone Method"
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
  - "IAssemblyName.Clone"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName::Clone"
helpviewer_keywords: 
  - "Clone method, IAssemblyName interface [.NET Framework fusion]"
  - "IAssemblyName::Clone method [.NET Framework fusion]"
ms.assetid: 7b345e08-5e16-4e3d-a044-4e19d0892943
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAssemblyName::Clone Method
Creates a shallow copy of this [IAssemblyName](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md) object.  
  
## Syntax  
  
```  
HRESULT Clone (  
    [out] IAssemblyName **pName  
);  
```  
  
#### Parameters  
 `pName`  
 [out] The returned copy of this `IAssemblyName` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)

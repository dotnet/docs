---
title: "IAssemblyEnum::Clone Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "IAssemblyEnum.Clone"
apilocation: 
  - "fusion.dll"
apitype: "COM"
f1_keywords: 
  - "IAssemblyEnum::Clone"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "Clone method, IAssemblyEnum interface [.NET Framework fusion]"
  - "IAssemblyEnum::Clone method [.NET Framework fusion]"
ms.assetid: 0014bb66-590c-486c-9ade-f2133905cd99
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# IAssemblyEnum::Clone Method
Creates a shallow copy of this [IAssemblyEnum](../../../../docs/framework/unmanaged-api/fusion/iassemblyenum-interface.md) object.  
  
## Syntax  
  
```  
HRESULT Clone (  
    [out] IAssemblyEnum   **ppEnum  
);  
```  
  
#### Parameters  
 `ppEnum`  
 [out] A pointer to the copy.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyEnum Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyenum-interface.md)
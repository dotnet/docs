---
title: "ICorThreadpool::CorChangeTimer Method"
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
  - "ICorThreadpool.CorChangeTimer"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorChangeTimer"
helpviewer_keywords: 
  - "CorChangeTimer method [.NET Framework hosting]"
  - "ICorThreadpool::CorChangeTimer method [.NET Framework hosting]"
ms.assetid: 82b03a59-5a87-43ed-9b75-e04b256e1a46
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorThreadpool::CorChangeTimer Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorChangeTimer (  
    [in]  HANDLE Timer,   
    [in]  ULONG  DueTime,   
    [in]  ULONG  Period,  
    [out] BOOL*  result  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)

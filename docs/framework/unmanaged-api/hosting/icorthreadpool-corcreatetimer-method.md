---
title: "ICorThreadpool::CorCreateTimer Method | Microsoft Docs"
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
  - "ICorThreadpool.CorCreateTimer"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "CorCreateTimer"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "CorCreateTimer method [.NET Framework hosting]"
  - "ICorThreadpool::CorCreateTimer method [.NET Framework hosting]"
ms.assetid: 0d56ef25-30f1-4499-8a1f-76e7654ec614
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorThreadpool::CorCreateTimer Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorCreateTimer (  
    [in]  HANDLE*             phNewTimer,  
    [in]  WAITORTIMERCALLBACK Callback,  
    [in]  PVOID               Parameter,  
    [in]  DWORD               DueTime,  
    [in]  DWORD               Period,  
    [out] BOOL*               result  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)
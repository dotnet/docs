---
title: "ICorThreadpool::CorGetMaxThreads Method | Microsoft Docs"
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
  - "ICorThreadpool.CorGetMaxThreads"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "CorGetMaxThreads"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "CorGetMaxThreads method [.NET Framework hosting]"
  - "ICorThreadpool::CorGetMaxThreads method [.NET Framework hosting]"
ms.assetid: 2861533a-cda0-47b3-b716-0d363505289b
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorThreadpool::CorGetMaxThreads Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorGetMaxThreads (  
    [out] DWORD *MaxWorkerThreads,  
    [out] DWORD *MaxIOCompletionThreads  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)
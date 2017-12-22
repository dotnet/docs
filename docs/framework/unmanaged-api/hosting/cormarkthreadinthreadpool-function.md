---
title: "CorMarkThreadInThreadPool Function"
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
  - "CorMarkThreadInThreadPool"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CorMarkThreadInThreadPool"
helpviewer_keywords: 
  - "CorMarkThreadInThreadPool function [.NET Framework hosting]"
ms.assetid: 3f958d41-e82e-4ec3-ae6f-16c7b3b31e3e
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorMarkThreadInThreadPool Function
Marks the currently executing thread-pool thread for the execution of managed code. Starting with the .NET Framework version 2.0, this function has no effect. It is not required, and can be removed from your code.This function is deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
void CorMarkThreadInThreadPool ();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
